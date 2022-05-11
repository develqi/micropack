using System;
using Microsoft.Extensions.DependencyInjection;

namespace Micropack.IoC;

public class ServiceLocator
{
    private static ServiceProvider _serviceProvider;
    private readonly ServiceProvider _currentServiceProvider;

    public ServiceLocator(ServiceProvider currentServiceProvider)
    {
        _currentServiceProvider = currentServiceProvider;
    }
    
    public static ServiceLocator Current => new ServiceLocator(_serviceProvider);
    
    public TService GetInstance<TService>() => _currentServiceProvider.GetService<TService>();

    public object GetInstance(Type serviceType) => _currentServiceProvider.GetService(serviceType);

    public static void SetLocatorProvider(ServiceProvider serviceProvider) => _serviceProvider = serviceProvider;
}
