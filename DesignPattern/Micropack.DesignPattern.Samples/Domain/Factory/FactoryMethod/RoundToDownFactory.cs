using Micropack.DesignPattern.Samples.Strategy;

namespace Micropack.DesignPattern.Samples
{
    public class RoundToDownFactory : IRoundingMethodFactory
    {
        public RoundingMethodStrategy GetRoundingMethodStrategy(Setting setting)
        {
            return new RoundToDown();
        }
    }
}
