
namespace Micropack.DesignPattern.Domain.Singleton
{
    // this class is not lazy-load and not theared-safe
    public class ProgramSetup
    {
        public string SiteName { get; set; } = "Assistance.com";

        private ProgramSetup()
        {

        }

        public static ProgramSetup Instance = new ProgramSetup();
    }
}
