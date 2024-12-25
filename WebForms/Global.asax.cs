using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Integration.Web;
using WebForms.Infrastructure;

namespace WebForms
{
    public class Global : HttpApplication, IContainerProviderAccessor
    {
        // Provider that holds the application container.
        static IContainerProvider containerProvider;

        // Instance property that will be used by Autofac HttpModules
        // to resolve and inject dependencies.
        public IContainerProvider ContainerProvider
        {
            get { return containerProvider; }
        }

        void Application_Start(object sender, EventArgs e)
        {
            RegisterServices();

            // Код, выполняемый при запуске приложения
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterServices()
        {
            var services = ServiceConfiguration.GetServices();

            var builder = new ContainerBuilder();

            builder.Populate(services);

            containerProvider = new ContainerProvider(builder.Build());
        }
    }
}