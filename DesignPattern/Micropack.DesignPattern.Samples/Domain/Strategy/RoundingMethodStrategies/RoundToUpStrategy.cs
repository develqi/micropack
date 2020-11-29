using System;

namespace Micropack.DesignPattern.Samples
{
    public class RoundToUpRoundingMethodStrategy : IRoundingMethodStrategy
    {
        public int Round(decimal point) => (int)Math.Ceiling(point);
    }
}
