using Xunit;
using Micropack.DesignPattern.Samples;

namespace Micropack.DesignPattern.UnitTests
{
    public class NullRefrenceTest
    {
        private readonly Setting _setting = new Setting { RoundingMethod = 0 };

        [Fact]
        public void NullRefrenceRoundigTest1()
        {
            var number = 2;
            var roundendNumber = _setting.GetRoundingMethodStrategy().Round(number);

            Assert.Equal(0, roundendNumber);
        }

        [Fact]
        public void NullRefrenceRoundigTest2()
        {
            var number = 2.1;
            var roundendNumber = _setting.GetRoundingMethodStrategy().Round(number);

            Assert.Equal(0, roundendNumber);
        }

        [Fact]
        public void NullRefrenceRoundigTest3()
        {
            var number = 2.5;
            var roundendNumber = _setting.GetRoundingMethodStrategy().Round(number);

            Assert.Equal(0, roundendNumber);
        }

        [Fact]
        public void NullRefrenceRoundigTest4()
        {
            var number = 2.6;
            var roundendNumber = _setting.GetRoundingMethodStrategy().Round(number);

            Assert.Equal(0, roundendNumber);
        }

        [Fact]
        public void NullRefrenceRoundigTest5()
        {
            var number = 3;
            var roundendNumber = _setting.GetRoundingMethodStrategy().Round(number);

            Assert.Equal(0, roundendNumber);
        }
    }
}
