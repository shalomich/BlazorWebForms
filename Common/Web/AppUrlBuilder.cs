using Common.DI;
using Microsoft.Extensions.Options;

namespace Common.Web
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
            return $"{appSettings.LegacyAppBasePath}{path}";
        }


        public string BuildNewAppUrl(string path)
        {
            return $"{appSettings.NewAppBasePath}{path}";
        }
    }
}
