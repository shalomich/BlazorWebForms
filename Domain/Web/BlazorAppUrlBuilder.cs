using Domain.DI;
using Microsoft.Extensions.Options;

namespace Domain.Web
{
    public class BlazorAppUrlBuilder
    {
        private readonly AppSettings appSettings;

        public const string ProjectDetailsTemplate = "/projects/{id:int}";

        public BlazorAppUrlBuilder(
            IOptions<AppSettings> appSettingsOptions)
        {
            appSettings = appSettingsOptions.Value;
        }

        /// <inheritdoc/>
        public string BuildProjectDetailsUrl(int projectId)
        {
            var path = ProjectDetailsTemplate.Replace("{id:int}", projectId.ToString());

            return BuildUrl(path);
        }

        public string BuildWebFormsAppUrl(string path)
        {
            return $"{appSettings.WebFormsAppBasePath}{path}";
        }


        private string BuildUrl(string path)
        {
            return $"{appSettings.BlazorAppBasePath}{path}";
        }
    }
}
