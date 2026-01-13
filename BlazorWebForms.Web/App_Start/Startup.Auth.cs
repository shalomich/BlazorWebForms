using System.IO;
using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Interop;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNet.Identity;
using BlazorWebForms.Web.App_Start;
using BlazorWebForms.Web.Common.Web;
using BlazorWebForms.Domain.Entities;
using StackExchange.Redis;
using Web;
using Autofac;
using Microsoft.Extensions.Options;
using BlazorWebForms.Web.Common.DI;

[assembly: OwinStartup(typeof(Startup))]
namespace BlazorWebForms.Web.App_Start
{
    internal class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // https://learn.microsoft.com/en-us/aspnet/core/security/cookie-sharing?view=aspnetcore-9.0#share-authentication-cookies-between-aspnet-4x-and-aspnet-core-apps

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
                // Settings to configure shared cookie with ASP.NET Core app
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
            try
            {
                var mux = ConnectionMultiplexer.Connect(redisConnection);

                // Use a temporary directory for the DataProtection provider instance (it won't be used for key persistence when Redis is available)
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
            catch (Exception)
            {
                var physicalDir = new DirectoryInfo(AuthenticationConstants.PersistKeysPath);
                if (!physicalDir.Exists)
                {
                    Directory.CreateDirectory(physicalDir.FullName);
                }

                return DataProtectionProvider.Create(physicalDir, builder =>
                {
                    builder.SetApplicationName(AuthenticationConstants.ApplicationName);
                });
            }
        }
    }
}