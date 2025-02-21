using Web.SharedComponents.Infrastructure;
using Common.DI;
using Common.Web;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Components.Web;
using Web.SharedComponents.Components;
using Web.New;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddControllers();

DatabaseModule.Register(builder.Services, builder.Configuration);
SystemModule.Register(builder.Services);
ApplicationModule.Register(builder.Services, builder.Configuration);
BlazorModule.Register(builder.Services);
WebComponentsModule.Register(builder.Services, builder.Configuration);

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpForwarder();

// https://learn.microsoft.com/en-us/aspnet/core/security/cookie-sharing?view=aspnetcore-9.0#share-authentication-cookies-between-aspnet-4x-and-aspnet-core-apps
builder.Services.AddAuthentication(AuthenticationConstants.AuthenticationType)
    .AddCookie(AuthenticationConstants.AuthenticationType, options =>
    {
        options.Cookie.Name = AuthenticationConstants.CookieName;
        options.Cookie.Path = "/";
    });

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(AuthenticationConstants.PersistKeysPath))
    .SetApplicationName(AuthenticationConstants.ApplicationName);

builder.Services.AddCors(options => options.AddPolicy("AllowFrontend", builder => builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .SetPreflightMaxAge(TimeSpan.FromDays(1))
));

// TODO: Use Redis for keys storage.
//var redisConnection = builder.Configuration.GetConnectionString("Redis");

//if (!string.IsNullOrEmpty(redisConnection))
//{
//    var redis = ConnectionMultiplexer.Connect(redisConnection);

//    builder.Services.AddDataProtection()
//        .PersistKeysToStackExchangeRedis(redis);
//}

builder.Services.AddCors(options => options.AddPolicy("AllowFrontend", builder => builder
    .WithOrigins("https://localhost:44322")
    .AllowCredentials()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .SetPreflightMaxAge(TimeSpan.FromDays(1))));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();

app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapControllers();

app.MapForwarder("/Scripts/{**catchAll}", configuration["App:LegacyAppBasePath"]).Add(static builder 
    => ((RouteEndpointBuilder)builder).Order = 1);

app.MapForwarder("/Content/{**catchAll}", configuration["App:LegacyAppBasePath"]).Add(static builder 
    => ((RouteEndpointBuilder)builder).Order = 2);

app.MapForwarder("/bundles/{**catchAll}", configuration["App:LegacyAppBasePath"]).Add(static builder 
    => ((RouteEndpointBuilder)builder).Order = 3);

//app.MapForwarder("/_framework/{**catchAll}", configuration["App:LegacyAppBasePath"]).Add(static builder 
//    => ((RouteEndpointBuilder)builder).Order = 4);

app.MapForwarder("/projects/{**catchAll}", configuration["App:LegacyAppBasePath"]).Add(static builder
    => ((RouteEndpointBuilder)builder).Order = 5);

app.Run();
