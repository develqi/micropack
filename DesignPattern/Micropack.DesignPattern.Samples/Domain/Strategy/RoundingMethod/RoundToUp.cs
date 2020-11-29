using System;

namespace Micropack.DesignPattern.Samples.Strategy
{
    public class RoundToUp : RoundingMethodStrategy
    {
        public override int Round(double number)
        {
            return (int)Math.Ceiling(number);
        }
    }
}
  