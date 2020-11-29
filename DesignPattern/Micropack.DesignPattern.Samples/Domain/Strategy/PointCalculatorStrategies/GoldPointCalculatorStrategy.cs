
namespace Micropack.DesignPattern.Samples
{
    public class GoldPointCalculatorStrategy : PointCalculatorStrategy
    {
        public override decimal CalculatePoint(decimal purchaseAmount) => purchaseAmount / 80; // 1 point per each $80 purchase
    }
}
