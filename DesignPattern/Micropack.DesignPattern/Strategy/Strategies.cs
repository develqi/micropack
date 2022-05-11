using System;
using Micropack.IoC;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Micropack.DesignPattern.Strategy
{
    public interface IStrategyExpression
    {
        StrategyProfile CreateStrategy<TModel, TStrategy>() where TStrategy : IStrategy where TModel : class, new();

        StrategyProfile ForCondition<TModel>(Expression<Func<TModel, bool>> expression, Action<StrategyConfiguration> action) where TModel : class, new();
    }

    public class StrategyConfiguration
    {
        private readonly IServiceCollection _services;

        public StrategyConfiguration(IServiceCollection services)
        {
            _services = services;
        }

        public void UseStrategy<TStrategy>(ServiceLifetime lifetime = ServiceLifetime.Transient) where TStrategy : class, IStrategy, new()
        {
            _services.Add(ServiceDescriptor.Describe(typeof(TStrategy), typeof(TStrategy), lifetime));
        }
    }

    public class Strategies
    {
        public static void AddStrategyProfile<TProfile>() where TProfile : StrategyProfile
        {
            //
        }

        public static TStrategy GetStrategy<TStrategy>(object condition) where TStrategy : IStrategy
        {
            return (TStrategy)ServiceLocator.Current.GetInstance(typeof(TStrategy));
        }
    }

    public class StrategyProfile : IStrategyExpression
    {
        private readonly List<IStrategy> _strategies = new List<IStrategy>();

        public StrategyProfile CreateStrategy<TModel, TStrategy>() where TStrategy : IStrategy where TModel : class, new()
        {
            _strategies.Add(typeof(TStrategy) as IStrategy);
            return this;
        }

        public StrategyProfile Add<TCondition, TStrategy>()
        {
            return this;
        }

        public StrategyProfile ForCondition<TModel>(Expression<Func<TModel, bool>> expression, Action<StrategyConfiguration> action) where TModel : class, new()
        {
            //_strategies.Add(typeof(TStrategy) as IStrategy);
            return this;
        }

        public StrategyProfile UseStrategy<TStrategy>() where TStrategy : class, IStrategy, new()
        {
            _strategies.Add(typeof(TStrategy) as IStrategy);
            return this;
        }


        public StrategyProfile CreateEnumStrategy<TEnum, TStrategy>() where TStrategy : IStrategy where TEnum : struct, IConvertible
        {
            if(typeof(TEnum).IsEnum)
            {
                var values = typeof(TEnum).GetEnumValues();

                for (var value = 0; value < values.Length; value++)
                {
                    var val = values.GetValue(value);
                }
            }

            _strategies.Add(typeof(TStrategy) as IStrategy);
            return this;
        }
    }
}
