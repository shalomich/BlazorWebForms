using BlazorWebForms.Web.Common.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorWebForms.Web.Infrastructure
{
    public class ServiceConfiguration
    {
        public static IServiceCollection GetServices()
        {
            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder()
                .Add(new LegacyConfigurationProvider())
                .Build();

            DatabaseModule.Register(services, configuration);
            SystemModule.Register(services);
            ApplicationModule.Register(services, configuration);

            return services;
        }
    }
}