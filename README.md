# Gradual Migration from ASP.NET Web Forms to Blazor

This directory demonstrates a practical approach to gradually migrate a legacy ASP.NET Web Forms application to modern Blazor while maintaining full backward compatibility and operational continuity.

## Overview

This solution demonstrates how to:

- **Run both applications side-by-side** without downtime
- **Share authentication state** between Web Forms and Blazor
- **Reuse Blazor components** within Web Forms pages (via Web Components)

## Architecture

### High-Level Architecture Diagram

```
┌─────────────────────────────────────────────────────────────┐
│                     Gateway (YARP)                          │
│                                                             │
│  Routes:                                                    │
│  • /new/**  → Blazor Server App                             │
│  • /**      → ASP.NET Web Forms (default)                   │
└──────────────┬────────────────────────┬─────────────────────┘
               │                        │
               ▼                        ▼
┌──────────────────────────┐ ┌──────────────────────────────┐
│   Blazor Server App      │ │   ASP.NET Web Forms          │
│  (BlazorWebForms.Web.New)│ │   (BlazorWebForms.Web)       │
│                          │ │                              │
│   • New Blazor pages     │ │   • Legacy ASPX pages        │
│   • Server-side rendering│ │   • Existing functionality   │
│   • Full Blazor features │ │   • Embeds Blazor components │
└────────┬─────────────────┘ └──────────┬───────────────────┘
         │                              │
         └──────────────┬───────────────┘
                        │
                        ▼
         ┌──────────────────────────────┐
         │  Blazor Web Components       │
         │  (WebAssembly - Standalone)  │
         │  SharedComponents Project    │
         │                              │
         │  • Custom Web Elements       │
         │  • Shared in both apps       │
         └──────────────────────────────┘
```

### Projects Structure

1. **BlazorWebForms.Web**
   - Legacy application
   - Hosts Blazor Web Components via WebAssembly

2. **BlazorWebForms.Web.New**
   - New Blazor Server application
   - Runs on `/new` path

3. **BlazorWebForms.Web.SharedComponents**
   - Blazor components compiled as **Custom Web Elements**
   - Can be embedded in both Web Forms and Blazor pages
   - Standalone WebAssembly bundle

4. **BlazorWebForms.Web.Gateway**
   - Routes traffic between legacy and new applications
   - Single entry point for users
   - Transparent routing based on URL paths

## Key Components

### 1. Gateway (YARP Reverse Proxy)

**Purpose**: Single entry point that routes requests to appropriate application

**Configuration** ([BlazorWebForms.Web.Gateway/appsettings.json](BlazorWebForms.Web.Gateway/appsettings.json)):

```json
{
  "ReverseProxy": {
    "Routes": {
      "blazor": {
        "ClusterId": "blazor",
        "Order": 1,
        "Match": { "Path": "/new/{**catch-all}" }
      },
      "default": {
        "ClusterId": "default",
        "Order": 100,
        "Match": { "Path": "{**catch-all}" }
      }
    },
    "Clusters": {
      "blazor": {
        "Destinations": {
          "destination1": { "Address": "https://localhost:7269" }
        }
      },
      "default": {
        "Destinations": {
          "destination1": { "Address": "https://localhost:44322" }
        }
      }
    }
  }
}
```

### 2. Shared Authentication

Both applications share authentication state using:

- **Shared cookies** (`.AspNet.ApplicationCookie`)
- **ASP.NET Data Protection** keys stored in Redis
- Same authentication scheme configuration

**Web Forms Configuration** ([BlazorWebForms.Web/Web.config](BlazorWebForms.Web/Web.config)):
```xml
<appSettings>
  <add key="App.RedisConnection" value="localhost:6379"/>
</appSettings>
```

```csharp
internal class Startup
{
    public void Configuration(IAppBuilder app)
    {
        var appSettings = Global.ApplicationContainer.Resolve<IOptions<AppSettings>>();

        var dataProtectionProvider = CreateDataProtectionProvider(appSettings.Value.RedisConnection);

        app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            LoginPath = new PathString(LegacyAppPaths.LoginPath),
            Provider = new CookieAuthenticationProvider
            {
                OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<UserManager<ApplicationUser>, ApplicationUser>(
                    validateInterval: TimeSpan.FromMinutes(30),
                    regenerateIdentity: (manager, user) => manager.CreateIdentityAsync(user, AuthenticationConstants.AuthenticationType))
            },
            CookieName = AuthenticationConstants.CookieName,
            AuthenticationType = AuthenticationConstants.AuthenticationType,
            TicketDataFormat = new AspNetTicketDataFormat(new DataProtectorShim(
                dataProtectionProvider.CreateProtector(
                    "Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware",
                    // Must match the Scheme name used in the ASP.NET Core app, i.e. IdentityConstants.ApplicationScheme
                    AuthenticationConstants.AuthenticationType,
                    "v2"))),
            CookieManager = new ChunkingCookieManager()
        });
    }

    private static IDataProtectionProvider CreateDataProtectionProvider(string redisConnection)
    {
        var mux = ConnectionMultiplexer.Connect(redisConnection);

        var tempDir = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? ".", "DataProtection"));
        if (!tempDir.Exists)
        {
            Directory.CreateDirectory(tempDir.FullName);
        }

        return DataProtectionProvider.Create(tempDir, builder =>
        {
            builder.SetApplicationName(AuthenticationConstants.ApplicationName);
            builder.PersistKeysToStackExchangeRedis(mux, AuthenticationConstants.RedisPersistKey);
        });
    }
}
```

**Blazor Configuration** ([BlazorWebForms.Web.New/Program.cs](BlazorWebForms.Web.New/Program.cs)):
```csharp
builder.Services.AddAuthentication(AuthenticationConstants.AuthenticationType)
    .AddCookie(AuthenticationConstants.AuthenticationType, options =>
    {
        options.Cookie.Name = AuthenticationConstants.CookieName;
        options.Cookie.Path = "/";
    });

var redis = ConnectionMultiplexer.Connect(redisConnection);

builder.Services
    .AddDataProtection()
    .SetApplicationName(AuthenticationConstants.ApplicationName)
    .PersistKeysToStackExchangeRedis(redis, AuthenticationConstants.RedisPersistKey);
```

### 3. Blazor Web Components (Custom Elements)

Blazor components are exposed as **standard Web Components** that can be used in any HTML page, including Web Forms.

**Registration** ([BlazorWebForms.Web.SharedComponents/Program.cs](BlazorWebForms.Web.SharedComponents/Program.cs)):
```csharp
builder.RootComponents.RegisterCustomElement<AppHeader>("app-header");
builder.RootComponents.RegisterCustomElement<AppProvider>("app-provider");
builder.RootComponents.RegisterCustomElement<ProjectCreateButton>("project-create-button");
builder.RootComponents.RegisterCustomElement<AppDatePicker>("app-date-picker");
```

**Usage in Web Forms** ([BlazorWebForms.Web/Site.Master](BlazorWebForms.Web/Site.Master)):
```html
<app-header 
    logout-path="<%= LegacyAppPaths.LogoutPath %>" 
    is-authenticated="<%=Request.IsAuthenticated%>">
</app-header>
```

## Migration Strategy

- Create Gateway with YARP for routing  
- Set up shared authentication (Redis + Data Protection)  
- Create SharedComponents project  
- Create initial Blazor Server application  

For each feature/page:
- Create new Blazor page in `/new` path
- Update links to point to new pages

## Update Connection Strings

**Web Forms** - [BlazorWebForms.Web/Web.config](BlazorWebForms.Web/Web.config):
```xml
<connectionStrings>
  <add name="DefaultConnection" 
       connectionString="Server=localhost;Database=blazor-webforms;Uid=postgres;Pwd=123;" 
       providerName="Npgsql" />
</connectionStrings>
<appSettings>
  <add key="App.GatewayBasePath" value="https://localhost:7169" />
  <add key="App.RedisConnection" value="localhost:6379"/>
</appSettings>
```

**Blazor** - [BlazorWebForms.Web.New/appsettings.json](BlazorWebForms.Web.New/appsettings.json):
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=blazor-webforms;Uid=postgres;Pwd=123;",
    "Redis": "localhost:6379"
  },
  "App": {
    "GatewayBasePath": "https://localhost:7169"
  }
}
```

## Common Challenges

### Authentication State Not Syncing

**Problem**: User logs in on Web Forms but Blazor shows as unauthenticated

**Solution**:
- Verify Redis connection in both apps
- Check Data Protection configuration matches exactly
- Ensure cookie names and paths are identical
- Verify `ApplicationName` is the same