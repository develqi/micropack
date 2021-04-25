using Microsoft.Extensions.DependencyInjection;
using System;

namespace Micropack.IoC
{
    public class AutoRegisterAttribute : Attribute
    {
        public ServiceLifetime ServiceLifetime { get; set; } = ServiceLifetime.Scoped;
    }
}
