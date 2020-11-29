
using System.Threading;

namespace Micropack.DesignPattern.Domain.Singleton
{
    public class ProgramSetup7
    {
        public string SiteName { get; set; } = "Assistance.com";

        private ProgramSetup7()
        {

        }

        // remove readonly
        private static ProgramSetup7 _instance;

        private static readonly ReaderWriterLockSlim _reader = new ReaderWriterLockSlim();

        public static ProgramSetup7 Instance
        {
            get
            {
                if (_instance == null)
                {
                    _reader.EnterReadLock();
                    //_reader.EnterWriteLock();

                    try
                    {
                        if (_instance == null)
                            _instance = new ProgramSetup7();
                    }
                    finally
                    {
                        _reader.ExitReadLock();
                        //_reader.ExitWriteLock();
                    }
                }

                return _instance;
            }
        }
    }
}
