using System;
using Microsoft.Extensions.DependencyInjection;

namespace Micropack.DesignPattern.Strategy
{
    public class ServiceLocator
    {
        private ServiceProvider _currentServiceProvider;
        private static ServiceProvider _serviceProvider;

        public ServiceLocator(ServiceProvider currentServiceProvider)
        {
            _currentServiceProvider = currentServiceProvider;
        }

        public static ServiceLocator Current => new ServiceLocator(_serviceProvider);

        public static void SetLocatorProvider(ServiceProvider serviceProvider) => _serviceProvider = serviceProvider;


        public TService GetInstance<TService>() => _currentServiceProvider.GetService<TService>();

        public object GetInstance(Type serviceType) => _currentServiceProvider.GetService(serviceType);
    }
}
