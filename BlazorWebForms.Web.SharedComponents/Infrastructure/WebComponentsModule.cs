using Microsoft.AspNetCore.Http;

namespace BlazorWebForms.Web.SharedComponents.Infrastructure
{
    public static class WebComponentsModule
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(sp => new HttpClient(new AuthenticationCookieHandler(new HttpClientHandler())) 
            {
                BaseAddress = new Uri(configuration["App:GatewayBasePath"] ?? string.Empty)
            });
        }
    }
}
