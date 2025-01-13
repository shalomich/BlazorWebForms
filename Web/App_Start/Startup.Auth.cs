using System.IO;
using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Interop;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNet.Identity;
using Web.App_Start;
using Common.Entities;
using Common.Web;

[assembly: OwinStartup(typeof(Startup))]
namespace Web.App_Start
{
    internal class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // https://learn.microsoft.com/en-us/aspnet/core/security/cookie-sharing?view=aspnetcore-9.0#share-authentication-cookies-between-aspnet-4x-and-aspnet-core-apps
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
                    DataProtectionProvider.Create(new DirectoryInfo(@"C:\Users\User\Desktop\PersistKeys"),
                    builder => builder
                        .SetApplicationName(AuthenticationConstants.ApplicationName))
                        .CreateProtector(
                            "Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware",
                            // Must match the Scheme name used in the ASP.NET Core app, i.e. IdentityConstants.ApplicationScheme
                            AuthenticationConstants.AuthenticationType,
                            "v2"))),
                CookieManager = new ChunkingCookieManager()
            });
        }
    }
}