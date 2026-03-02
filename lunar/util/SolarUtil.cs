using System;
using System.Collections.Generic;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Lunar.Util
{
    /// <summary>
    /// 阳历工具
    /// </summary>
    public static class SolarUtil
    {
        /// <summary>
        /// 星期
        /// </summary>
        public static readonly string[] WEEK = { "日", "一", "二", "三", "四", "五", "六" };

        /// <summary>
        /// 每月天数
        /// </summary>
        public static readonly int[] DAYS_OF_MONTH = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        #region Fields -> TextResource

        /// <summary>
        /// 星座
        /// </summary>
        public static string[] XING_ZUO => TextResource.Instance.XING_ZUO;

        /// <summary>
        /// 节日
        /// </summary>
        public static Dictionary<string, string> FESTIVAL => TextResource.Instance.SOLAR_FESTIVAL;

        /// <summary>
        /// 按星期的节日
        /// </summary>
        public static Dictionary<string, string> WEEK_FESTIVAL => TextResource.Instance.SOLAR_WEEK_FESTIVAL;

        /// <summary>
        /// 非正式节日
        /// </summary>
        public static Dictionary<string, List<string>> OTHER_FESTIVAL => TextResource.Instance.SOLAR_OTHER_FESTIVAL;

        #endregion

        /// <summary>
        /// 是否闰年
        /// </summary>
        /// <param name="year">年</param>
        /// <returns>true/false 闰年/非闰年</returns>
        public static bool IsLeapYear(int year)
        {
            if (year < 1600) 
            {
                return year % 4 == 0;
            }
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }

        /// <summary>
        /// 获取某年有多少天（平年365天，闰年366天）
        /// </summary>
        /// <param name="year">年</param>
        /// <returns>天数</returns>
        public static int GetDaysOfYear(int year)
        {
            if (1582 == year) {
                return 355;
            }
            return IsLeapYear(year) ? 366 : 365;
        }

        /// <summary>
        /// 获取某年某月有多少天
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns>天数</returns>
        public static int GetDaysOfMonth(int year, int month)
        {
            if (1582 == year && 10 == month)
            {
                return 21;
            }
            int m = month - 1;
            int d = DAYS_OF_MONTH[m];
            //公历闰年2月多一天
            if (m == 1 && IsLeapYear(year)) {
                d++;
            }
            return d;
        }

        /// <summary>
        /// 获取某天为当年的第几天
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <returns>第几天</returns>
        public static int GetDaysInYear(int year, int month, int day)
        {
            var days = 0;
            for (var i = 1; i < month; i++)
            {
                days += GetDaysOfMonth(year, i);
            }
            var d = day;
            if (1582 == year && 10 == month) {
                if (day >= 15) {
                    d -= 10;
                } else if (day > 4)
                {
                    throw new ArgumentException($"wrong solar year {year} month {month} day {day}");
                }
            }
            days += d;
            return days;
        }

        /// <summary>
        /// 获取某年某月有多少周
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="start">星期几作为一周的开始，1234560分别代表星期一至星期天</param>
        /// <returns>周数</returns>
        public static int GetWeeksOfMonth(int year, int month, int start)
        {
            return (int) Math.Ceiling((GetDaysOfMonth(year, month) + Solar.FromYmdHms(year, month, 1).Week - start) * 1D / WEEK.Length);
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
        /// <returns>天数</returns>
        public static int GetDaysBetween(int ay, int am, int ad, int by, int bm, int bd)
        {
            int n;
            int days;
            int i;
            if (ay == by)
            {
                n = GetDaysInYear(by, bm, bd) - GetDaysInYear(ay, am, ad);
            }
            else if (ay > by)
            {
                days = GetDaysOfYear(by) - GetDaysInYear(by, bm, bd);
                for (i = by + 1; i < ay; i++)
                {
                    days += GetDaysOfYear(i);
                }
                days += GetDaysInYear(ay, am, ad);
                n = -days;
            }
            else
            {
                days = GetDaysOfYear(ay) - GetDaysInYear(ay, am, ad);
                for (i = ay + 1; i < by; i++)
                {
                    days += GetDaysOfYear(i);
                }
                days += GetDaysInYear(by, bm, bd);
                n = days;
            }
            return n;
        }
    }
}
