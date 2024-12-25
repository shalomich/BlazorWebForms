using System;
using Domain.UseCases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.DI
{
    public class SystemModule
    {
        public static void Register(IServiceCollection services)
        {
            try
            {
                services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(GetProjectsQuery).Assembly));
            }
            catch (Exception exception)
            {
                var a = 1;
            }
        }
    }
}
