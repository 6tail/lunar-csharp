using System;
using Lunar.Util;

namespace Lunar
{
    /// <summary>
    /// 日期
    /// </summary>
    public class ExactDate
    {
        public static DateTime FromYmdHms(int year, int month, int day, int hour = 0, int minute = 0, int second = 0)
        {
            if (year < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(year),"solar year must bigger than 0");
            }
            return new DateTime(year, month, day, hour, minute, second, 0, DateTimeKind.Utc);
        }

        public static DateTime FromDate(DateTime date)
        {
            return FromYmdHms(date.Year, date.Month, date.Day, date.Hour, date.Minute,date.Second);
        }

        /// <summary>
        /// 获取两个日期之间相差的天数（如果日期a比日期b小，天数为正，如果日期a比日期b大，天数为负）
        /// </summary>
        /// <param name="ay">年a</param>
        /// <param name="am">月a</param>
        /// <param name="ad">日a</param>
        /// <param name="by">年b</param>
        /// <param name="bm">月b</param>
        /// <param name="bd">日b</param>
        /// <returns></returns>
        public static int GetDaysBetween(int ay, int am, int ad, int by, int bm, int bd)
        {
            int n;
            int days;
            int i;
            if (ay == by)
            {
                n = SolarUtil.GetDaysInYear(by, bm, bd) - SolarUtil.GetDaysInYear(ay, am, ad);
            }
            else if (ay > by)
            {
                days = SolarUtil.GetDaysOfYear(by) - SolarUtil.GetDaysInYear(by, bm, bd);
                for (i = by + 1; i < ay; i++)
                {
                    days += SolarUtil.GetDaysOfYear(i);
                }
                days += SolarUtil.GetDaysInYear(ay, am, ad);
                n = -days;
            }
            else
            {
                days = SolarUtil.GetDaysOfYear(ay) - SolarUtil.GetDaysInYear(ay, am, ad);
                for (i = ay + 1; i < by; i++)
                {
                    days += SolarUtil.GetDaysOfYear(i);
                }
                days += SolarUtil.GetDaysInYear(by, bm, bd);
                n = days;
            }
            return n;
        }

        /// <summary>
        /// 获取两个日期之间相差的天数（如果日期a比日期b小，天数为正，如果日期a比日期b大，天数为负）
        /// </summary>
        /// <param name="date0">日期a</param>
        /// <param name="date1">日期b</param>
        /// <returns>天数</returns>
        public static int GetDaysBetween(DateTime date0, DateTime date1)
        {
            return GetDaysBetween(date0.Year, date0.Month, date0.Day, date1.Year, date1.Month, date1.Day);
        }
    }
}
