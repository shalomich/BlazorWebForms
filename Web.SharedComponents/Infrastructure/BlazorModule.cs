using MudBlazor.Services;

namespace Web.SharedComponents.Infrastructure
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
