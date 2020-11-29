using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Micropack.DesignPattern.ChainOfResponsibility
{
    public interface IChainConfigurator<TContext> where TContext : class
    {
        IChainConfigurator<TContext> Add<TChain>() where TChain : TContext;

        void Configure();
    }

    public class ChainConfigurator<TChain> : IChainConfigurator<TChain> where TChain : class
    {
        private List<Type> _types;
        private Type _interfaceType;
        private readonly IServiceCollection _services;

        public ChainConfigurator(IServiceCollection services)
        {
            _services = services;
            _types = new List<Type>();
            _interfaceType = typeof(TChain);
        }

        public void Configure()
        {
            if (_types.Count == 0)
                throw new InvalidOperationException($"No implementation defined for {_interfaceType.Name}");

            bool first = true;
            foreach (var type in _types)
            {
                ConfigureType(type, first);
                first = false;
            }
        }

        public IChainConfigurator<TChain> Add<TImplementation>() where TImplementation : TChain
        {
            var type = typeof(TImplementation);

            if (!_interfaceType.IsAssignableFrom(type))
                throw new ArgumentException($"{type.Name} type is not an implementation of {_interfaceType.Name}", nameof(type));

            _types.Add(type);

            return this;
        }

        private void ConfigureType(Type currentType, bool first)
        {
            var nextType = _types.SkipWhile(x => x != currentType).SkipWhile(x => x == currentType).FirstOrDefault();

            var ctor = currentType.GetConstructors().OrderByDescending(x => x.GetParameters().Count()).First();

            var parameter = Expression.Parameter(typeof(IServiceProvider), "x");

            var ctorParameters = ctor.GetParameters().Select(x =>
            {
                if (_interfaceType.IsAssignableFrom(x.ParameterType))
                {
                    if (nextType == null)
                        return Expression.Constant(null, _interfaceType);
                    else
                        return Expression.Call(typeof(ServiceProviderServiceExtensions), "GetRequiredService", new Type[] { nextType }, parameter);
                }

                return (Expression)Expression.Call(typeof(ServiceProviderServiceExtensions), "GetRequiredService", new Type[] { x.ParameterType }, parameter);
            });

            var body = Expression.New(ctor, ctorParameters.ToArray());

            var resolveType = first ? _interfaceType : currentType;

            var expressionType = Expression.GetFuncType(typeof(IServiceProvider), resolveType);
            var expression = Expression.Lambda(expressionType, body, parameter);

            Func<IServiceProvider, object> c = (Func<IServiceProvider, object>)expression.Compile();

            _services.AddTransient(resolveType, c);
        }
    }
}

