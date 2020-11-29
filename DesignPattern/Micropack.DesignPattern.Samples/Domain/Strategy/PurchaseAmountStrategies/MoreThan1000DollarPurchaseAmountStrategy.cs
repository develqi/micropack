namespace Micropack.DesignPattern.Samples
{
    public class MoreThan1000DollarPurchaseAmountStrategy : IPurchaseAmounrStrategy
    {
        public decimal GetFinalPrice(decimal purchaseAmount)
        {
            return purchaseAmount * 25 / 100;
        }
    }
}
