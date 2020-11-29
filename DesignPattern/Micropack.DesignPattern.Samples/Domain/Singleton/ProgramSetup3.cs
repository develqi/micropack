
namespace Micropack.DesignPattern.Samples.Singleton
{
    // this class is lazy-load but not theared-safe
    public class ProgramSetup3
    {
        public string SiteName { get; set; } = "Assistance.com";

        private ProgramSetup3()
        {

        }

        // remove readonly
        private static ProgramSetup3 _instance;

        public static ProgramSetup3 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ProgramSetup3();

                return _instance;
            }
        }
    }   
}
