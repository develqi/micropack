using Micropack.DesignPattern.Strategy;

namespace Micropack.DesignPattern.Samples
{
    public interface IRoundingMethodStrategy : IStrategy
    {
        int Round(decimal point);
    }
}
