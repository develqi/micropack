namespace Micropack.DesignPattern.Samples
{
    public class NullRoundingMethodStrategy : IRoundingMethodStrategy
    {
        public int Round(decimal point) => (int)point;
    }
}
