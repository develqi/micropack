
using System.Threading;

namespace Micropack.DesignPattern.Samples.Singleton
{
    public class ProgramSetup5
    {
        public string SiteName { get; set; } = "Assistance.com";

        private ProgramSetup5()
        {

        }

        // remove readonly
        private static ProgramSetup5 _instance;

        private static readonly Mutex _mutex = new Mutex(false, "Setup");

        public static ProgramSetup5 Instance
        {
            get
            {
                if (_instance == null)
                {
                    _mutex.WaitOne();

                    if (_instance == null)
                        _instance = new ProgramSetup5();

                    _mutex.ReleaseMutex();
                }

                return _instance;
            }
        }
    }
}
