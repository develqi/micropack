
namespace Micropack.DesignPattern.Samples.Singleton
{
    public class ProgramSetup4
    {
        public string SiteName { get; set; } = "Assistance.com";

        private ProgramSetup4()
        {
            
        }

        // remove readonly
        private static ProgramSetup4 _instance;

        private static readonly object _lock = new object();

        public static ProgramSetup4 Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new ProgramSetup4();
                    }
                }

                return _instance;
            }
        }
    }
}
