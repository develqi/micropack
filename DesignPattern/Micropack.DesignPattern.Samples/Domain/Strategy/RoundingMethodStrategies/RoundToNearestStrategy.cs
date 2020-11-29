using System;

namespace Micropack.DesignPattern.Samples
{
    public class RoundToNearestRoundingMethodStrategy : IRoundingMethodStrategy
    {
        public int Round(decimal point) => (int)Math.Round(point);
    }
}
