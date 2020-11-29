
using System.Threading;

namespace Micropack.DesignPattern.Samples.Singleton
{
    public class ProgramSetup8
    {
        public string SiteName { get; set; } = "Assistance.com";

        private ProgramSetup8()
        {

        }

        // remove readonly
        private static ProgramSetup8 _instance;

        private static readonly object _lock = new object();

        public static ProgramSetup8 Instance
        {
            get
            {
                if (_instance == null)
                {
                    Monitor.Enter(_lock);

                    try
                    {
                        if (_instance == null)
                            _instance = new ProgramSetup8();
                    }
                    finally
                    {
                        Monitor.Exit(_lock);
                    }
                }

                return _instance;
            }
        }
    }
}
