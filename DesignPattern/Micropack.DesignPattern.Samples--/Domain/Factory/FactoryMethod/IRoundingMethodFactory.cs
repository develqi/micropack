using Micropack.DesignPattern.Domain.Strategy;

namespace Micropack.DesignPattern.Domain
{
    public interface IRoundingMethodFactory
    {
        RoundingMethodStrategy GetRoundingMethodStrategy(Setting setting);
    }
}
 