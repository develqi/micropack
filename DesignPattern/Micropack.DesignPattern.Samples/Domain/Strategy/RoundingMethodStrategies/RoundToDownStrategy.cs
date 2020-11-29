using System;

namespace Micropack.DesignPattern.Samples
{
    public class RoundToDownRoundingMethodStrategy : IRoundingMethodStrategy
    {
        public int Round(decimal point) => (int)Math.Round(point, MidpointRounding.AwayFromZero);
    }
}
