using System;
using System.Collections.Generic;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming

namespace Lunar
{
    /// <summary>
    /// 阳历季度
    /// </summary>
    public sealed class SolarSeason
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
        /// 一个季度的月数
        /// </summary>
        public const int MONTH_COUNT = 3;

        /// <summary>
        /// 默认当前日期
        /// </summary>
        public SolarSeason(): this(DateTime.Now)
        {
        }

        /// <summary>
        /// 通过日期初始化
        /// </summary>
        /// <param name="date">日期</param>
        public SolarSeason(DateTime date): this(date.Year, date.Month)
        {
        }

        /// <summary>
        /// 通过年月初始化
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        public SolarSeason(int year, int month)
        {
            Year = year;
            Month = month;
        }

        /// <summary>
        /// 通过指定日期获取阳历季度
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns>阳历季度</returns>
        public static SolarSeason FromDate(DateTime date)
        {
            return new SolarSeason(date);
        }

        /// <summary>
        /// 通过指定年月获取阳历季度
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns>阳历季度</returns>
        public static SolarSeason FromYm(int year, int month)
        {
            return new SolarSeason(year, month);
        }

        /// <summary>
        /// 当月是第几季度，从1开始
        /// </summary>
        public int Index => (int)Math.Ceiling(Month * 1D / MONTH_COUNT);

        /// <summary>
        /// 推移
        /// </summary>
        /// <param name="seasons">推移的季度数，负数为倒推</param>
        /// <returns>推移后的季度</returns>
        public SolarSeason Next(int seasons)
        {
            SolarMonth m = SolarMonth.FromYm(Year, Month).Next(MONTH_COUNT * seasons);
            return new SolarSeason(m.Year, m.Month);
        }

        /// <summary>
        /// 本季度的月份列表
        /// </summary>
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
            return $"{Year}.{Index}";
        }

        /// <summary>
        /// 
        /// </summary>
        public string FullString => $"{Year}年{Index}季度";
    }
}
