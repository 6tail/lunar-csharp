using System;
using System.Collections.Generic;
using System.Text;

namespace com.nlf.calendar
{
    /// <summary>
    /// 阳历季度
    /// </summary>
    public class SolarSeason
    {
        /// <summary>
        /// 年
        /// </summary>
        private int year;

        /// <summary>
        /// 月
        /// </summary>
        private int month;

        /// <summary>
        /// 一个季度的月数
        /// </summary>
        public const int MONTH_COUNT = 3;

        /// <summary>
        /// 默认当前日期
        /// </summary>
        public SolarSeason()
            : this(DateTime.Now)
        {
        }

        /// <summary>
        /// 通过日期初始化
        /// </summary>
        /// <param name="date">日期</param>
        public SolarSeason(DateTime date)
        {
            year = date.Year;
            month = date.Month;
        }

        /// <summary>
        /// 通过年月初始化
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        public SolarSeason(int year, int month)
        {
            this.year = year;
            this.month = month;
        }

        /// <summary>
        /// 通过指定日期获取阳历季度
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns>阳历季度</returns>
        public static SolarSeason fromDate(DateTime date)
        {
            return new SolarSeason(date);
        }

        /// <summary>
        /// 通过指定年月获取阳历季度
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns>阳历季度</returns>
        public static SolarSeason fromYm(int year, int month)
        {
            return new SolarSeason(year, month);
        }

        /// <summary>
        /// 获取年
        /// </summary>
        /// <returns>年</returns>
        public int getYear()
        {
            return year;
        }

        /// <summary>
        /// 获取月
        /// </summary>
        /// <returns>月</returns>
        public int getMonth()
        {
            return month;
        }

        /// <summary>
        /// 获取当月是第几季度
        /// </summary>
        /// <returns>季度序号，从1开始</returns>
        public int getIndex()
        {
            return (int)Math.Ceiling(month * 1D / MONTH_COUNT);
        }

        /// <summary>
        /// 季度推移
        /// </summary>
        /// <param name="seasons">推移的季度数，负数为倒推</param>
        /// <returns>推移后的季度</returns>
        public SolarSeason next(int seasons)
        {
            if (0 == seasons)
            {
                return new SolarSeason(year, month);
            }
            DateTime c = new DateTime(year, month, 1);
            c.AddMonths(MONTH_COUNT * seasons);
            return new SolarSeason(c);
        }

        /// <summary>
        /// 获取本季度的月份
        /// </summary>
        /// <returns>本季度的月份列表</returns>
        public List<SolarMonth> getMonths()
        {
            List<SolarMonth> l = new List<SolarMonth>();
            int index = getIndex() - 1;
            for (int i = 0; i < MONTH_COUNT; i++)
            {
                l.Add(new SolarMonth(year, MONTH_COUNT * index + i + 1));
            }
            return l;
        }

        public override string ToString()
        {
            return year + "." + getIndex();
        }

        public string toFullString()
        {
            return year + "年" + getIndex() + "季度";
        }
    }
}
