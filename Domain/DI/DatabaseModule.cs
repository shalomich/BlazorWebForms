using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.DI
{
    /// <summary>
    /// Register Database context as dependency.
    /// </summary>
    public static class DatabaseModule
    {
        /// <summary>
        /// Register dependencies.
        /// </summary>
        /// <param name="services">Services.</param>
        /// <param name="configuration">Configuration.</param>
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    sqlOptions =>
                        sqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.GetName().Name)),
                    ServiceLifetime.Transient);
        }
    }
}
