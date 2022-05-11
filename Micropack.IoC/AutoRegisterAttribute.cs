using System;
using Microsoft.Extensions.DependencyInjection;

namespace Micropack.IoC;

[AttributeUsage(AttributeTargets.Class)]
public class AutoRegisterAttribute : Attribute
{
    public ServiceLifetime ServiceLifetime { get; set; } = ServiceLifetime.Scoped;
}
