using System;
using System.Collections.Generic;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming

// TODO: 可访问性调整

namespace Lunar
{
    /// <summary>
    /// 阳历年
    /// </summary>
    public sealed class SolarYear
    {
        /// <summary>
        /// 年
        /// </summary>
        public int Year { get; }

        /// <summary>
        /// 一年的月数
        /// </summary>
        public const int MONTH_COUNT = 12;

        /// <summary>
        /// 默认当年
        /// </summary>
        public SolarYear()
            : this(DateTime.Now)
        {
        }

        /// <summary>
        /// 通过日期初始化
        /// </summary>
        /// <param name="date"></param>
        public SolarYear(DateTime date)
        {
            Year = date.Year;
        }

        /// <summary>
        /// 通过年初始化
        /// </summary>
        /// <param name="year">年</param>
        public SolarYear(int year)
        {
            Year = year;
        }

        /// <summary>
        /// 通过指定日期获取阳历年
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns>阳历年</returns>
        public static SolarYear FromDate(DateTime date)
        {
            return new SolarYear(date);
        }

        /// <summary>
        /// 通过指定年份获取阳历年
        /// </summary>
        /// <param name="year">年</param>
        /// <returns>阳历年</returns>
        public static SolarYear FromYear(int year)
        {
            return new SolarYear(year);
        }

        /// <summary>
        /// 本年的阳历月列表
        /// </summary>
        public List<SolarMonth> Months
        {
            get
            {
                var l = new List<SolarMonth>(MONTH_COUNT);
                var m = new SolarMonth(Year, 1);
                l.Add(m);
                for (var i = 1; i < MONTH_COUNT; i++)
                {
                    l.Add(m.Next(i));
                }
                return l;
            }
        }

        /// <summary>
        /// 获取往后推几年的阳历年，如果要往前推，则年数用负数
        /// </summary>
        /// <param name="years">年数</param>
        /// <returns>阳历年</returns>
        public SolarYear Next(int years)
        {
            return new SolarYear(Year + years);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Year + "";
        }
        /// <summary>
        /// 
        /// </summary>
        public string FullString => Year + "年";
    }
}
