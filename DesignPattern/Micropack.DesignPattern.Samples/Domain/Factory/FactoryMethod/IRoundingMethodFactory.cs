using Micropack.DesignPattern.Samples.Strategy;

namespace Micropack.DesignPattern.Samples
{
    public interface IRoundingMethodFactory
    {
        RoundingMethodStrategy GetRoundingMethodStrategy(Setting setting);
    }
}
 