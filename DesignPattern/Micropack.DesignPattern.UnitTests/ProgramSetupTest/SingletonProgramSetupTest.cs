using Xunit;
using Micropack.DesignPattern.Samples.Singleton;

namespace Micropack.DesignPattern.UnitTests
{
    public class SingletonProgramSetupTest
    {
        [Fact]
        public void NullRefrenceRoundigTest1()
        {
            var siteName = ProgramSetup.Instance.SiteName;

            //var siteName2 = ProgramSetup.Instance.SiteName;

            //var siteName3 = ProgramSetup.Instance.SiteName;

            //ProgramSetup.Count = 123;


            Assert.Equal("Micropack", siteName);
        }
    }
}
