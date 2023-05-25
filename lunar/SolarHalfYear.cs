using System;
using System.Collections.Generic;
// ReSharper disable InconsistentNaming
// ReSharper disable MemberCanBePrivate.Global

namespace Lunar
{
    /// <summary>
    /// 阳历半年
    /// </summary>
    public sealed class SolarHalfYear
    {
        /// <summary>
        /// 年
        /// </summary>
        private int Year { get; }

        /// <summary>
        /// 月
        /// </summary>
        private int Month { get; }

        /// <summary>
        /// 半年的月数
        /// </summary>
        public const int MONTH_COUNT = 6;

        /// <summary>
        /// 默认当前日期
        /// </summary>
        public SolarHalfYear(): this(DateTime.Now)
        {
        }

        /// <summary>
        /// 通过日期初始化
        /// </summary>
        /// <param name="date">日期</param>
        public SolarHalfYear(DateTime date): this(date.Year, date.Month)
        {
        }

        /// <summary>
        /// 通过年月初始化
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        public SolarHalfYear(int year, int month)
        {
            Year = year;
            Month = month;
        }

        /// <summary>
        /// 通过指定日期获取阳历半年
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns>阳历半年</returns>
        public static SolarHalfYear FromDate(DateTime date)
        {
            return new SolarHalfYear(date);
        }

        /// <summary>
        /// 通过指定年月获取阳历半年
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns>阳历半年</returns>
        public static SolarHalfYear FromYm(int year, int month)
        {
            return new SolarHalfYear(year, month);
        }

        /// <summary>
        /// 半年序号，从1开始
        /// </summary>
        public int Index => (int)Math.Ceiling(Month * 1D / MONTH_COUNT);

        /// <summary>
        /// 半年推移
        /// </summary>
        /// <param name="halfYears">推移的半年数，负数为倒推</param>
        /// <returns>推移后的半年</returns>
        public SolarHalfYear Next(int halfYears)
        {
            var m = SolarMonth.FromYm(Year, Month).Next(MONTH_COUNT * halfYears);
            return new SolarHalfYear(m.Year, m.Month);
        }

        /// <summary>
        /// 获取本半年的月份
        /// </summary>
        /// <returns>本半年的月份列表</returns>
        public IEnumerable<SolarMonth> Months
        {
            get
            {
                var index = Index - 1;
                for (var i = 0; i < MONTH_COUNT; i++)
                {
                    yield return new SolarMonth(Year, MONTH_COUNT * index + i + 1);
                }
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Year + "." + Index;
        }

        /// <summary>
        /// 
        /// </summary>
        public string FullString => Year + "年" + (Index == 1 ? "上" : "下") + "半年";
    }
}
