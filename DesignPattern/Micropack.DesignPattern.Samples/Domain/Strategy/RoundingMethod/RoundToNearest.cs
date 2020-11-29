using System;

namespace Micropack.DesignPattern.Samples.Strategy
{
    public class RoundToNearest : RoundingMethodStrategy
    {
        public override int Round(double number)
        {
            return (int)Math.Round(number);
        }
    }
}
