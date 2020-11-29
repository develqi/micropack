using Micropack.DesignPattern.Strategy;

namespace Micropack.DesignPattern.Samples
{
    public interface IPurchaseAmounrStrategy : IStrategy
    {
        decimal GetFinalPrice(decimal purchaseAmount);
    }
}
