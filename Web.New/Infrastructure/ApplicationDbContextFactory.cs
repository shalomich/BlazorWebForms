using Common.DI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Common;

namespace Web.New.Infrastructure
{
    /// <summary>
    /// Application database context factory.
    /// </summary>
    /// <remarks>Used for creation migrations.</remarks>
    internal class ApplicationDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        /// <inheritdoc/>
        public AppDbContext CreateDbContext(string[] args)
        {
            var services = new ServiceCollection();

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AppDbContext>();
            DatabaseModule.Register(services, configuration);

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider.GetRequiredService<AppDbContext>();
        }
    }
}