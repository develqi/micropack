using Micropack.DesignPattern.Domain.Strategy;

namespace Micropack.DesignPattern.Domain
{
    public class NullRoundingFactory : IRoundingMethodFactory
    {
        public RoundingMethodStrategy GetRoundingMethodStrategy(Setting setting)
        {
            return new NullRounding();
        }
    }

}
