using System;

namespace Micropack.DateTimeProviders
{
    public static class DateTimeOffsetExtensions
    {
        public static DateTimeOffset Begining(this DateTimeOffset date)
        {
            return new DateTimeOffset(date.Year, date.Month, date.Day, 0, 0, 0, TimeSpan.MinValue);
        }

        public static DateTimeOffset Ending(this DateTimeOffset date)
        {
            return new DateTimeOffset(date.Year, date.Month, date.Day, 23, 59, 59, TimeSpan.MinValue);
        }

        public static DateTimeOffset AddWeeks(this DateTimeOffset date, double weeks)
        {
            return date.AddDays(weeks * 7);
        }

        public static DateTimeOffset AddMonths(this DateTimeOffset date, double months)
        {
            var daysOfMonth = 30;

            //switch (date.Month)
            //{
            //    case 2:
            //        daysOfMonth = 28;
            //        break;

            //    case 4:
            //    case 6:
            //    case 9:
            //    case 11:
            //        daysOfMonth = 30;
            //        break;

            //    case 1:
            //    case 3:
            //    case 5:
            //    case 7:
            //    case 8:
            //    case 10:
            //    case 12:
            //        daysOfMonth = 31;
            //        break;
            //}
 
            return date.AddDays(months * daysOfMonth);
        }

        public static DateTimeOffset AddYears(this DateTimeOffset date, double years)
        {
            var daysOfYear = 364; // ToDo: check now year days count 

            return date.AddDays(years * daysOfYear);
        }

        //public static DateTimeModel Today(this DateTimeOffset date)
        //{
        //    return new DateTimeModel(date.Begining(), date.Ending());
        //}

        //public static DateTimeModel Yesterday(this DateTimeOffset date)
        //{
        //    return new DateTimeModel(date.Begining(), date.Ending());
        //}

        //public static DateTimeModel LastWeek(this DateTimeOffset date)
        //{
        //    return new DateTimeModel(date.Begining(), date.Ending());
        //}

        //public static DateTimeModel LastMonth(this DateTimeOffset date)
        //{
        //    return new DateTimeModel(date.Begining(), date.Ending());
        //}

        //public static DateTimeModel LastYear(this DateTimeOffset date)
        //{
        //    return new DateTimeModel(date.Begining(), date.Ending());
        //}
    }
}
