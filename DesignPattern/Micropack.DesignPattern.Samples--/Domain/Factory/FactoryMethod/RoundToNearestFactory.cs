using Micropack.DesignPattern.Domain.Strategy;

namespace Micropack.DesignPattern.Domain
{
    public class RoundToNearestFactory : IRoundingMethodFactory
    {
        public RoundingMethodStrategy GetRoundingMethodStrategy(Setting setting)
        {
            return new RoundToNearest();
        }
    }
}
