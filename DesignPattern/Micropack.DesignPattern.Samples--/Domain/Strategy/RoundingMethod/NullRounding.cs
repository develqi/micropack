
namespace Micropack.DesignPattern.Domain.Strategy
{
    public class NullRounding : RoundingMethodStrategy
    {
        public override int Round(double number)
        {
            return 0;
        }
    }
}
