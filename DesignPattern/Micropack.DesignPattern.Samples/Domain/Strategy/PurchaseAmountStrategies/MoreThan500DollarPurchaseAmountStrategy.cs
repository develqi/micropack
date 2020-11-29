namespace Micropack.DesignPattern.Samples
{
    public class MoreThan500DollarPurchaseAmountStrategy : IPurchaseAmounrStrategy
    {
        public decimal GetFinalPrice(decimal purchaseAmount)
        {
            return purchaseAmount * 15 / 100;
        }
    }
}
