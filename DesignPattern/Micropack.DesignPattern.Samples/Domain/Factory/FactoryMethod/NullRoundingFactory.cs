using Micropack.DesignPattern.Samples.Strategy;

namespace Micropack.DesignPattern.Samples
{
    public class NullRoundingFactory : IRoundingMethodFactory
    {
        public RoundingMethodStrategy GetRoundingMethodStrategy(Setting setting)
        {
            return new NullRounding();
        }
    }

}
