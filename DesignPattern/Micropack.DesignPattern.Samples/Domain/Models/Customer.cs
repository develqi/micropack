using Micropack.DesignPattern.Strategy;
using System;

namespace Micropack.DesignPattern.Samples
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public DateTimeOffset Birthday { get; set; }

        public string Name { get; set; }

        public int Point { get; set; }

        public LoyaltyLevels LoyaltyLevel { get; set; }

        public void UpdatePoint(Setting setting, decimal purchaseAmount)
        {
            //var points = Strategies.GetStrategy<PointCalculatorStrategy>(LoyaltyLevels.Gold).CalculatePoint(purchaseAmount);

            var point = LoyaltyLevel.GetStrategy<PointCalculatorStrategy>().CalculatePoint(purchaseAmount);

            var roundedPoint = setting.RoundingMethod.GetStrategy<IRoundingMethodStrategy>().Round(point);

            Point += roundedPoint;
        }

    }
}
