using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace WebForms.Infrastructure
{
    /// <summary>
    /// Provider for migration from System.Configuration to Microsoft.Extensions.Configuration.
    /// </summary>
    internal class LegacyConfigurationProvider : ConfigurationProvider, IConfigurationSource
    {
        /// <inheritdoc/>
        public override void Load()
        {
            foreach (ConnectionStringSettings connectionString in System.Configuration.ConfigurationManager.ConnectionStrings)
            {
                Data.Add($"ConnectionStrings:{connectionString.Name}", connectionString.ConnectionString);
            }

            foreach (var settingKey in System.Configuration.ConfigurationManager.AppSettings.AllKeys)
            {
                Data.Add(settingKey.Replace('.', ':'), System.Configuration.ConfigurationManager.AppSettings[settingKey]);
            }
        }

        /// <inheritdoc/>
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return this;
        }
    }
}