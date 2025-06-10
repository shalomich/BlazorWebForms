using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorWebForms.Web.Common.Web
{
    public static class AuthenticationConstants
    {
        public const string CookieName = ".AspNet.ApplicationCookie";

        public const string AuthenticationType = "Identity.Application";

        public const string ApplicationName = "SharedCookieApp";

        // TODO: Use Redis for storage.
        public const string PersistKeysPath = @"C:\Users\User\Desktop\PersistKeys";
    }
}
