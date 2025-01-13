using System;
using Common.UseCases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common.DI
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
