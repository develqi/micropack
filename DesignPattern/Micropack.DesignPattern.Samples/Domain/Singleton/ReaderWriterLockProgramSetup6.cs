
using System.Threading;

namespace Micropack.DesignPattern.Samples.Singleton
{
    public class ProgramSetup6
    {
        public string SiteName { get; set; } = "Assistance.com";

        private ProgramSetup6()
        {

        }

        // remove readonly
        private static ProgramSetup6 _instance;

        private static readonly ReaderWriterLock _reader = new ReaderWriterLock();

        public static ProgramSetup6 Instance
        {
            get
            {
                if (_instance == null)
                {
                    _reader.AcquireReaderLock(0);

                    try
                    {
                        if (_instance == null)
                            _instance = new ProgramSetup6();
                    }
                    finally
                    {
                        _reader.ReleaseReaderLock();
                    }
                }

                return _instance;
            }
        }
    }
}
