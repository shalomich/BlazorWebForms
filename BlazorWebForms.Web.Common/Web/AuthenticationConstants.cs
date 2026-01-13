namespace BlazorWebForms.Web.Common.Web
{
    public static class AuthenticationConstants
    {
        public const string CookieName = ".AspNet.ApplicationCookie";

        public const string AuthenticationType = "Identity.Application";

        public const string ApplicationName = "SharedCookieApp";

        // Redis key used to store Data Protection XML payloads
        public const string RedisPersistKey = "DataProtection-Keys";

        // TODO: Use Redis for storage.
        public const string PersistKeysPath = @"C:\Users\User\Desktop\PersistKeys";
    }
}
