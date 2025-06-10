using MudBlazor.Services;

namespace BlazorWebForms.Web.SharedComponents.Infrastructure
{
    public static class BlazorModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddMudServices();
            services.AddSingleton(AppTheme.Create());
        }
    }
}
