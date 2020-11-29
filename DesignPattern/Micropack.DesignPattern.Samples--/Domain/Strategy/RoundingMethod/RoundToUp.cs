using System;

namespace Micropack.DesignPattern.Domain.Strategy
{
    public class RoundToUp : RoundingMethodStrategy
    {
        public override int Round(double number)
        {
            return (int)Math.Ceiling(number);
        }
    }
}
  