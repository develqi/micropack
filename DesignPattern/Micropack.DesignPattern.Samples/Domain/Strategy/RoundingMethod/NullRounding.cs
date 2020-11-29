
namespace Micropack.DesignPattern.Samples.Strategy
{
    public class NullRounding : RoundingMethodStrategy
    {
        public override int Round(double number)
        {
            return 0;
        }
    }
}
