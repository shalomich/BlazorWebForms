using Web.SharedComponents.Infrastructure;
using Common.DI;
using Common.Web;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers();

DatabaseModule.Register(builder.Services, builder.Configuration);
SystemModule.Register(builder.Services);
ApplicationModule.Register(builder.Services, builder.Configuration);
BlazorModule.Register(builder.Services);

builder.Services.AddHttpContextAccessor();

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
    .AllowAnyOrigin()
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

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapControllers();

app.Run();
