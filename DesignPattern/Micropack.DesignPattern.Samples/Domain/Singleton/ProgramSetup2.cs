
namespace Micropack.DesignPattern.Samples.Singleton
{
    // this class is not lazy-load and not theared-safe
    public class ProgramSetup2
    {
        public string SiteName { get; set; } = "Assistance.com";

        private ProgramSetup2()
        {

        }

        private static readonly ProgramSetup2 _instance = new ProgramSetup2();

        public static ProgramSetup2 Instance => _instance;
    }
}
