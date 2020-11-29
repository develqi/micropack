using Xunit;
using Micropack.DesignPattern.Samples;

namespace Micropack.DesignPattern.UnitTests
{
    public class RoundToNearestTest
    {
        private readonly Setting _setting = new Setting { RoundingMethod = RoundingMethods.RoundToNearest };

        [Fact]
        public void RoundigToNearestTest1()
        {
            var number = 2;
            var roundendNumber = _setting.GetRoundingMethodStrategy().Round(number);

            Assert.Equal(2, roundendNumber);
        }

        [Fact]
        public void RoundigToNearestTest2()
        {
            var number = 2.1;
            var roundendNumber = _setting.GetRoundingMethodStrategy().Round(number);

            Assert.Equal(2, roundendNumber);
        }

        [Fact]
        public void RoundigToNearestTest3()
        {
            var number = 1.5;
            var roundendNumber = _setting.GetRoundingMethodStrategy().Round(number);

            Assert.Equal(2, roundendNumber);
        }

        [Fact]
        public void RoundigToNearestTest4()
        {
            var number = 2.5;
            var roundendNumber = _setting.GetRoundingMethodStrategy().Round(number);

            Assert.Equal(2, roundendNumber);
        }

        [Fact]
        public void RoundigToNearestTest5()
        {
            var number = 3.5;
            var roundendNumber = _setting.GetRoundingMethodStrategy().Round(number);

            Assert.Equal(4, roundendNumber);
        }

        [Fact]
        public void RoundigToNearestTest6()
        {
            var number = 2.6;
            var roundendNumber = _setting.GetRoundingMethodStrategy().Round(number);

            Assert.Equal(3, roundendNumber);
        }

        [Fact]
        public void RoundigToNearestTest7()
        {
            var number = 3;
            var roundendNumber = _setting.GetRoundingMethodStrategy().Round(number);

            Assert.Equal(3, roundendNumber);
        }
    }
}
