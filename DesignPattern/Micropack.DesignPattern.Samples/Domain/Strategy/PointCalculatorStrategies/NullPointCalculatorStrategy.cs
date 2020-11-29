namespace Micropack.DesignPattern.Samples
{
    public class NullPointCalculatorStrategy : PointCalculatorStrategy
    {
        public override decimal CalculatePoint(decimal purchaseAmount) => 0;
    }
}
