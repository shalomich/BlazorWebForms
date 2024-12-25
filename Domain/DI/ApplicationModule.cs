using Domain.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.DI
{
    public static class ApplicationModule
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<BlazorAppUrlBuilder>();
            services.Configure<AppSettings>(configuration.GetSection("App"));
        }
    }
}
