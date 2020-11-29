using Xunit;
using Micropack.DesignPattern.Samples;

namespace Micropack.DesignPattern.UnitTests
{
    public class RoundToDownTest
    {
        private readonly Setting _setting = new Setting { RoundingMethod = RoundingMethods.RoundToDown };

        [Fact]
        public void RoundigToDownTest1()
        {
            var number = 2;
            var roundendNumber = _setting.GetRoundingMethodStrategy().Round(number);

            Assert.Equal(2, roundendNumber);
        }

        [Fact]
        public void RoundigToDownTest2()
        {
            var number = 2.1;
            var roundendNumber = _setting.GetRoundingMethodStrategy().Round(number);

            Assert.Equal(2, roundendNumber);
        }

        [Fact]
        public void RoundigToDownTest3()
        {
            var number = 2.5;
            var roundendNumber = _setting.GetRoundingMethodStrategy().Round(number);

            Assert.Equal(2, roundendNumber);
        }

        [Fact]
        public void RoundigToDownTest4()
        {
            var number = 2.6;
            var roundendNumber = _setting.GetRoundingMethodStrategy().Round(number);

            Assert.Equal(2, roundendNumber);
        }

        [Fact]
        public void RoundigToDownTest5()
        {
            var number = 3;
            var roundendNumber = _setting.GetRoundingMethodStrategy().Round(number);

            Assert.Equal(3, roundendNumber);
        }
    }
}
