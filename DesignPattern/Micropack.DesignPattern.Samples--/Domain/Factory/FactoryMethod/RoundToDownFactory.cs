using Micropack.DesignPattern.Domain.Strategy;

namespace Micropack.DesignPattern.Domain
{
    public class RoundToDownFactory : IRoundingMethodFactory
    {
        public RoundingMethodStrategy GetRoundingMethodStrategy(Setting setting)
        {
            return new RoundToDown();
        }
    }
}
