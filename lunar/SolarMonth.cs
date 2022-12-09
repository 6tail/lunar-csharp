using System;
using System.Collections.Generic;
using Lunar.Util;
// ReSharper disable MemberCanBePrivate.Global

namespace Lunar
{
    /// <summary>
    /// 阳历月
    /// </summary>
    public class SolarMonth
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
        /// 默认日期
        /// </summary>
        public SolarMonth(): this(DateTime.Now)
        {
        }

        /// <summary>
        /// 通过日期初始化
        /// </summary>
        /// <param name="date">日期</param>
        public SolarMonth(DateTime date): this(date.Year, date.Month)
        {
        }

        /// <summary>
        /// 通过年月初始化
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        public SolarMonth(int year, int month)
        {
            Year = year;
            Month = month;
        }

        /// <summary>
        /// 通过指定日期获取阳历月
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns>阳历月</returns>
        public static SolarMonth FromDate(DateTime date)
        {
            return new SolarMonth(date);
        }

        /// <summary>
        /// 通过指定年月获取阳历月
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns>阳历月</returns>
        public static SolarMonth FromYm(int year, int month)
        {
            return new SolarMonth(year, month);
        }

        /// <summary>
        /// 本月的阳历日期列表
        /// </summary>
        public List<Solar> Days
        {
            get
            {
                var l = new List<Solar>(31);
                var d = new Solar(Year, Month, 1);
                l.Add(d);
                var days = SolarUtil.GetDaysOfMonth(Year, Month);
                for (var i = 1; i < days; i++)
                {
                    l.Add(d.Next(i));
                }
                return l;
            }
        }
        
        /// <summary>
        /// 获取本月的阳历周列表
        /// </summary>
        /// <param name="start">星期几作为一周的开始，1234560分别代表星期一至星期天</param>
        /// <returns>周列表</returns>
        public List<SolarWeek> GetWeeks(int start) {
            var l = new List<SolarWeek>();
            var week = SolarWeek.FromYmd(Year, Month, 1, start);
            while (true) {
                l.Add(week);
                week = week.Next(1, false);
                var firstDay = week.FirstDay;
                if (firstDay.Year > Year || firstDay.Month > Month) {
                    break;
                }
            }
            return l;
        }

        /// <summary>
        /// 获取往后推几个月的阳历月，如果要往前推，则月数用负数
        /// </summary>
        /// <param name="months">月数</param>
        /// <returns>阳历月</returns>
        public SolarMonth Next(int months)
        {
            var c = ExactDate.FromYmdHms(Year, Month, 1);
            c = c.AddMonths(months);
            return new SolarMonth(c);
        }

        public override string ToString()
        {
            return Year + "-" + Month;
        }

        public string FullString => Year + "年" + Month + "月";
    }
}