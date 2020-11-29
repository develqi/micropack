using Xunit;
using Micropack.DesignPattern.Samples;

namespace Micropack.DesignPattern.UnitTests
{
    public class RoundToUpTest
    {
        private readonly Setting _setting = new Setting { RoundingMethod = RoundingMethods.RoundToUp };

        [Fact]
        public void RoundigToUpTest1()
        {
            var number = 2;
            var roundendNumber = _setting.GetRoundingMethodStrategy().Round(number);

            Assert.Equal(2, roundendNumber);
        }

        [Fact]
        public void RoundigToUpTest2()
        {
            var number = 2.1;
            var roundendNumber = _setting.GetRoundingMethodStrategy().Round(number);

            Assert.Equal(3, roundendNumber);
        }

        [Fact]
        public void RoundigToUpTest3()
        {
            var number = 2.5;
            var roundendNumber = _setting.GetRoundingMethodStrategy().Round(number);

            Assert.Equal(3, roundendNumber);
        }

        [Fact]
        public void RoundigToUpTest4()
        {
            var number = 2.6;
            var roundendNumber = _setting.GetRoundingMethodStrategy().Round(number);

            Assert.Equal(3, roundendNumber);
        }

        [Fact]
        public void RoundigToUpTest5()
        {
            var number = 3;
            var roundendNumber = _setting.GetRoundingMethodStrategy().Round(number);

            Assert.Equal(3, roundendNumber);
        }
    }
}
