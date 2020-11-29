using System;

namespace Micropack.DateTimeProviders
{
    public interface ITodayProvider
    {
        DateTime StartDateTime { get; }

        DateTime EndDateTime { get; }
    }

    public class TodayProvider : ITodayProvider
    {
        private readonly DateTime _now;

        public TodayProvider()
        {
            _now = DateTime.Now;
        }

        public DateTime StartDateTime => new DateTime(_now.Year, _now.Month, _now.Day, 0, 0, 0);

        public DateTime EndDateTime => new DateTime(_now.Year, _now.Month, _now.Day, 23, 59, 59);
    }
}
