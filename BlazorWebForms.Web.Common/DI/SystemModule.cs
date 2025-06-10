using BlazorWebForms.UseCases.GetProjects;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorWebForms.Web.Common.DI
{
    public class SystemModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(GetProjectsQuery).Assembly));
        }
    }
}
