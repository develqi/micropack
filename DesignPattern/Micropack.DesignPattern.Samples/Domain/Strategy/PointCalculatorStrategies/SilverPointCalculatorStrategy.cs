namespace Micropack.DesignPattern.Samples
{
    public class SilverPointCalculatorStrategy : PointCalculatorStrategy
    {
        public override decimal CalculatePoint(decimal purchaseAmount) => purchaseAmount / 90; // 1 point per each $90 purchase
    }
}
