using System;
using System.Collections.Generic;
using System.Linq;
using Lunar.Util;
// ReSharper disable MemberCanBePrivate.Global

namespace Lunar
{
    /// <summary>
    /// 阳历周
    /// </summary>
    public class SolarWeek
    {
        /// <summary>
        /// 年
        /// </summary>
        public int Year { get; }
        
        /// <summary>
        /// 月
        /// </summary>
        public int Month { get; }
        
        /// <summary>
        /// 日
        /// </summary>
        public int Day { get; }
        
        /// <summary>
        /// 星期几作为一周的开始，1234560分别代表星期一至星期天
        /// </summary>
        public int Start { get; }
        
        /// <summary>
        /// 默认当月
        /// </summary>
        /// <param name="start">星期几作为一周的开始，1234560分别代表星期一至星期天</param>
        public SolarWeek(int start): this(DateTime.Now, start)
        {
        }

        /// <summary>
        /// 通过日期初始化
        /// </summary>
        /// <param name="date">日期</param>
        /// <param name="start">星期几作为一周的开始，1234560分别代表星期一至星期天</param>
        public SolarWeek(DateTime date, int start):this(date.Year, date.Month, date.Day, start)
        {
        }

        /// <summary>
        /// 通过年月初始化
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月，1到12</param>
        /// <param name="day">日，1到31</param>
        /// <param name="start">星期几作为一周的开始，1234560分别代表星期一至星期天</param>
        public SolarWeek(int year, int month, int day, int start)
        {
            Year = year;
            Month = month;
            Day = day;
            Start = start;
        }

        /// <summary>
        /// 通过指定日期获取阳历周
        /// </summary>
        /// <param name="date">日期</param>
        /// <param name="start">星期几作为一周的开始，1234560分别代表星期一至星期天</param>
        /// <returns>阳历周</returns>
        public static SolarWeek FromDate(DateTime date, int start)
        {
            return new SolarWeek(date, start);
        }

        /// <summary>
        /// 通过指定年月日获取阳历周
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月，1到12</param>
        /// <param name="day">日，1到31</param>
        /// <param name="start">星期几作为一周的开始，1234560分别代表星期一至星期天</param>
        /// <returns>阳历周</returns>
        public static SolarWeek FromYmd(int year, int month, int day, int start)
        {
            return new SolarWeek(year, month, day, start);
        }

        /// <summary>
        /// 当前日期是在当月第几周，从1开始
        /// </summary>
        public int Index
        {
            get
            {
                var offset = Solar.FromYmdHms(Year, Month, 1).Week - Start;
                if (offset < 0)
                {
                    offset += 7;
                }
                return (int)Math.Ceiling((Day + offset) * 1D / 7);
            }
        }

        /// <summary>
        /// 当前日期是在当年第几周，从1开始
        /// </summary>
        public int IndexInYear
        {
            get
            {
                var offset = Solar.FromYmdHms(Year, 1, 1).Week - Start;
                if (offset < 0)
                {
                    offset += 7;
                }
                return (int) Math.Ceiling((SolarUtil.GetDaysInYear(Year, Month, Day) + offset) * 1D / 7);
            }
        }

        /// <summary>
        /// 周推移
        /// </summary>
        /// <param name="weeks">推移的周数，负数为倒推</param>
        /// <param name="separateMonth">是否按月单独计算</param>
        /// <returns>推移后的阳历周</returns>
        public SolarWeek Next(int weeks, bool separateMonth)
        {
            if (0 == weeks)
            {
                return new SolarWeek(Year, Month, Day, Start);
            }
            var solar = Solar.FromYmdHms(Year, Month, Day);
            if (separateMonth)
            {
                var n = weeks;
                var week = new SolarWeek(solar.Year, solar.Month, solar.Day, Start);
                var m = Month;
                var plus = n > 0;
                while (0 != n)
                {
                    solar = solar.Next(plus ? 7 : -7);
                    week = new SolarWeek(solar.Year, solar.Month, solar.Day, Start);
                    var weekMonth = week.Month;
                    if (m != weekMonth)
                    {
                        var index = week.Index;
                        if (plus)
                        {
                            if (1 == index)
                            {
                                var firstDay = week.FirstDay;
                                week = new SolarWeek(firstDay.Year, firstDay.Month, firstDay.Day, Start);
                                weekMonth = week.Month;
                            }
                            else
                            {
                                solar = Solar.FromYmdHms(week.Year, week.Month, 1);
                                week = new SolarWeek(solar.Year, solar.Month, solar.Day, Start);
                            }
                        }
                        else
                        {
                            var size = SolarUtil.GetWeeksOfMonth(week.Year, week.Month, Start);
                            if (size == index)
                            {
                                var firstDay = week.FirstDay;
                                var lastDay = firstDay.Next(6);
                                week = new SolarWeek(lastDay.Year, lastDay.Month, lastDay.Day, Start);
                                weekMonth = week.Month;
                            }
                            else
                            {
                                solar = Solar.FromYmdHms(week.Year, week.Month, SolarUtil.GetDaysOfMonth(week.Year, week.Month));
                                week = new SolarWeek(solar.Year, solar.Month, solar.Day, Start);
                            }
                        }
                        m = weekMonth;
                    }
                    n -= plus ? 1 : -1;
                }
                return week;
            }
            else
            {
                solar = solar.Next(weeks * 7);
                return new SolarWeek(solar.Year, solar.Month, solar.Day, Start);
            }
        }

        /// <summary>
        /// 本周第一天的阳历日期（可能跨月）
        /// </summary>
        public Solar FirstDay
        {
            get
            {
                var solar = Solar.FromYmdHms(Year, Month, Day);
                var prev = solar.Week - Start;
                if (prev < 0)
                {
                    prev += 7;
                }
                return solar.Next(-prev);
            }
        }

        /// <summary>
        /// 本周第一天的阳历日期（仅限当月）
        /// </summary>
        public Solar FirstDayInMonth
        {
            get
            {
                return Days.FirstOrDefault(day => Month == day.Month);
            }
        }

        /// <summary>
        /// 本周的阳历日期列表（可能跨月）
        /// </summary>
        public List<Solar> Days
        {
            get
            {
                var firstDay = FirstDay;
                var l = new List<Solar> {firstDay};
                for (var i = 1; i < 7; i++)
                {
                    l.Add(firstDay.Next(i));
                }
                return l;
            }
        }

        /// <summary>
        /// 本周的阳历日期列表（仅限当月）
        /// </summary>
        public List<Solar> DaysInMonth
        {
            get
            {
                return Days.Where(day => Month == day.Month).ToList();
            }
        }

        public override string ToString()
        {
            return Year + "." + Month + "." + Index;
        }

        public string FullString => Year + "年" + Month + "月第" + Index + "周";
    }
}
