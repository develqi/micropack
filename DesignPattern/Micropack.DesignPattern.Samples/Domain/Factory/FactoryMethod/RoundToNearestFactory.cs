using Micropack.DesignPattern.Samples.Strategy;

namespace Micropack.DesignPattern.Samples
{
    public class RoundToNearestFactory : IRoundingMethodFactory
    {
        public RoundingMethodStrategy GetRoundingMethodStrategy(Setting setting)
        {
            return new RoundToNearest();
        }
    }
}
