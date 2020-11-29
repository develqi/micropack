namespace Micropack.DesignPattern.Samples
{
    public class MoreThan100DollarPurchaseAmountStrategy : IPurchaseAmounrStrategy
    {
        public decimal GetFinalPrice(decimal purchaseAmount)
        {
            return purchaseAmount * 5 / 100;
        }
    }
}
