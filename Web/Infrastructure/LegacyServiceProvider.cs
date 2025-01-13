using Autofac;
using Autofac.Integration.Web;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Web;

namespace Web.Infrastructure
{
    /// <summary>
    /// Legacy service provider.
    /// </summary>
    internal class LegacyServiceProvider : IDisposable
    {
        private bool disposed;

        private IContainerProvider containerProvider;
        private IServiceScope serviceScope;

        /// <summary>
        /// Constructor.
        /// </summary>
        private LegacyServiceProvider(IContainerProvider containerProvider)
        {
            this.containerProvider = containerProvider;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose pattern implementation.
        /// </summary>
        /// <param name="disposing">Dispose managed resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                serviceScope?.Dispose();
            }

            disposed = true;
        }

        /// <summary>
        /// Set required service.
        /// </summary>
        public T GetRequiredService<T>() where T : class
        {
            return containerProvider.RequestLifetime.Resolve<T>();
        }

        /// <summary>
        /// Create LegacyServiceProvider instance.
        /// </summary>
        public static LegacyServiceProvider Create()
        {
            var containerAccessor = (IContainerProviderAccessor)HttpContext.Current.ApplicationInstance;

            return new LegacyServiceProvider(containerAccessor.ContainerProvider);
        }

        /// <summary>
        /// Creates scoped service provider.
        /// </summary>
        public IServiceProvider CreateScoped()
        {
            var serviceScopeFactory = GetRequiredService<IServiceScopeFactory>();
            serviceScope = serviceScopeFactory.CreateScope();
            return serviceScope.ServiceProvider;
        }
    }
}
