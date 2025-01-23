using Common.Web;
using Microsoft.AspNetCore.DataProtection;
using StackExchange.Redis;

namespace Web.New.Infrastructure.DI
{
    /// <summary>
    /// Register Database context as dependency.
    /// </summary>
    public static class DataProtectionModule
    {
        /// <summary>
        /// Register dependencies.
        /// </summary>
        /// <param name="services">Services.</param>
        /// <param name="configuration">Configuration.</param>
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.GetSection("Redis")
                .Get<RedisSettings>();

            if (settings is null)
            {
                throw new InvalidOperationException("Redis settings is required");
            }

            var redis = ConnectionMultiplexer.Connect($"{settings.Host}:{settings.Port}");

            services.AddDataProtection()
                .PersistKeysToStackExchangeRedis(redis)
                .SetApplicationName(AuthenticationConstants.ApplicationName);
        }
    }

    /// <summary>
    /// Redis settings.
    /// </summary>
    public class RedisSettings
    {
        /// <summary>
        /// Host.
        /// </summary>
        public string? Host { get; set; }

        /// <summary>
        /// Port.
        /// </summary>
        public string? Port { get; set; }
    }
}
