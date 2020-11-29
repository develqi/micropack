using System;

namespace Micropack.DateTimeProviders
{
    public class DateTimeModel
    {
        public DateTimeModel(DateTimeOffset beginning, DateTimeOffset ending)
        {
            Beginning = beginning;
            Ending = ending;
        }

        public DateTimeOffset Beginning { get; }

        public DateTimeOffset Ending { get; }

        //public long BeginningToUnixTimeSeconds => Beginning.ToUnixTimeSeconds();

        //public long BeginningToUnixTimeMilliseconds => Beginning.ToUnixTimeMilliseconds();

        //public long EndingToUnixTimeSeconds => Ending.ToUnixTimeSeconds();

        //public long EndingToUnixTimeMilliseconds => Ending.ToUnixTimeMilliseconds();
    }
}
