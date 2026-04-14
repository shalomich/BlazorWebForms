using System;
using BlazorWebForms.Web.Common.DI;
using Microsoft.Extensions.Options;

namespace BlazorWebForms.Web.Common.Web
{
    public class AppUrlBuilder
    {
        private readonly AppSettings appSettings;

        public AppUrlBuilder(
            IOptions<AppSettings> appSettingsOptions)
        {
            appSettings = appSettingsOptions.Value;
        }

        public string BuildLegacyAppUrl(string path)
        {
            var baseUri = new Uri(appSettings.LegacyAppBasePath);
            return new Uri(baseUri, path).ToString();
        }


        public string BuildNewAppUrl(string path)
        {
            var baseUri = new Uri(appSettings.NewAppBasePath);
            return new Uri($"{baseUri}new/{path}").ToString();
        }
    }
}
