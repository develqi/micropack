using Micropack.DesignPattern.Domain.Strategy;

namespace Micropack.DesignPattern.Domain
{
    public class RoundToUpFactory : IRoundingMethodFactory
    {
        public RoundingMethodStrategy GetRoundingMethodStrategy(Setting setting)
        {
            return new RoundToUp();
        }
    }
}
