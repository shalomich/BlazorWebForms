using Common.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common.DI
{
    public static class ApplicationModule
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AppUrlBuilder>();
            services.Configure<AppSettings>(configuration.GetSection("App"));
        }
    }
}
