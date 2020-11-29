using System;

namespace Micropack.DesignPattern.Domain.Strategy
{
    public class RoundToDown : RoundingMethodStrategy
    {
        public override int Round(double number)
        {
            return (int)Math.Floor(number);
        }
    }
}
