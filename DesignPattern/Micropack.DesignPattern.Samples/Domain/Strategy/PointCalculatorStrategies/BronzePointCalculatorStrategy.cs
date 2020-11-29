namespace Micropack.DesignPattern.Samples
{
    public class BronzePointCalculatorStrategy : PointCalculatorStrategy
    {
        public override decimal CalculatePoint(decimal purchaseAmount) => purchaseAmount / 100; // 1 point per each $100 purchase
    }
}
