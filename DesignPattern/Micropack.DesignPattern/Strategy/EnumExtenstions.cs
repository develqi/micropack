using System;
using Micropack.IoC;

namespace Micropack.DesignPattern.Strategy
{
    public static class EnumExtenstions
    {
        public static TStrategy GetStrategy<TStrategy>(this Enum enumValue) where TStrategy : IStrategy
        {
             return ServiceLocator.Current.GetInstance<Func<Enum, TStrategy>>()(enumValue);
        }
    }
}
