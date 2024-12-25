using Domain.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebForms.Infrastructure
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