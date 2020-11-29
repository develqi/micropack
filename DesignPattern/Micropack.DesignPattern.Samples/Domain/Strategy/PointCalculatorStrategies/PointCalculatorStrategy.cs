using Micropack.DesignPattern.Strategy;

namespace Micropack.DesignPattern.Samples
{
    public abstract class PointCalculatorStrategy : IStrategy
    {
        public abstract decimal CalculatePoint(decimal purchaseAmount);
    }
}
