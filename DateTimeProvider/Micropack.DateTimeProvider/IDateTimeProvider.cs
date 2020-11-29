using System;

namespace Micropack.DateTimeProviders
{
    public interface IDateTimeProvider
    {
        DateTimeModel GetToday();

        DateTimeModel GetYesterday();

        DateTimeModel GetLastWeek();

        DateTimeModel GetLastMonth();

        DateTimeModel GetLastYear();
    }

    public class DateTimeProvider : IDateTimeProvider
    {
        public static DateTimeOffset Now => DateTimeOffset.UtcNow;

        public DateTimeModel GetLastMonth()
        {
            throw new NotImplementedException();
        }

        public DateTimeModel GetLastWeek()
        {
            var lastWeek = Now.AddWeeks(-1);

            return new DateTimeModel(Now.Begining(), lastWeek.Ending());
        }

        public DateTimeModel GetLastYear()
        {
            throw new NotImplementedException();
        }

        public DateTimeModel GetToday()
        {
            return new DateTimeModel(Now.Begining(), Now.Ending());
        }

        public DateTimeModel GetYesterday()
        {
            var yesterday = Now.AddDays(-1);

            return new DateTimeModel(yesterday.Begining(), yesterday.Ending());
        }
    }
}
