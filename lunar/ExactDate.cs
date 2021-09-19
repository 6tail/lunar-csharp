using System;
using System.Collections.Generic;
using System.Text;

namespace com.nlf.calendar
{
    class ExactDate
    {
        public static DateTime fromYmdHms(int year, int month, int day, int hour, int minute, int second)
        {
            if (year < 1)
            {
                throw new ArgumentOutOfRangeException("solar year must bigger than 0");
            }
            return new DateTime(year, month, day, hour, minute, second, 0, DateTimeKind.Utc);
        }

        public static DateTime fromYmd(int year, int month, int day)
        {
            return fromYmdHms(year, month, day, 0, 0, 0);
        }

        public static DateTime fromDate(DateTime date)
        {
            return fromYmdHms(date.Year, date.Month, date.Day, date.Hour, date.Minute,date.Second);
        }
    }
}
