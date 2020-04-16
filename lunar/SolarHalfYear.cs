using System;
using System.Collections.Generic;
using System.Text;

namespace com.nlf.calendar
{
    /// <summary>
    /// 阳历半年
    /// </summary>
    public class SolarHalfYear
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
        /// 半年的月数
        /// </summary>
        public const int MONTH_COUNT = 6;

        /// <summary>
        /// 默认当前日期
        /// </summary>
        public SolarHalfYear()
            : this(DateTime.Now)
        {
        }

        /// <summary>
        /// 通过日期初始化
        /// </summary>
        /// <param name="date">日期</param>
        public SolarHalfYear(DateTime date)
        {
            year = date.Year;
            month = date.Month;
        }

        /// <summary>
        /// 通过年月初始化
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        public SolarHalfYear(int year, int month)
        {
            this.year = year;
            this.month = month;
        }

        /// <summary>
        /// 通过指定日期获取阳历半年
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns>阳历半年</returns>
        public static SolarHalfYear fromDate(DateTime date)
        {
            return new SolarHalfYear(date);
        }

        /// <summary>
        /// 通过指定年月获取阳历半年
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns>阳历半年</returns>
        public static SolarHalfYear fromYm(int year, int month)
        {
            return new SolarHalfYear(year, month);
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
        /// 获取当月是第几半年
        /// </summary>
        /// <returns>半年序号，从1开始</returns>
        public int getIndex()
        {
            return (int)Math.Ceiling(month * 1D / MONTH_COUNT);
        }

        /// <summary>
        /// 半年推移
        /// </summary>
        /// <param name="halfYears">推移的半年数，负数为倒推</param>
        /// <returns>推移后的半年</returns>
        public SolarHalfYear next(int halfYears)
        {
            if (0 == halfYears)
            {
                return new SolarHalfYear(year, month);
            }
            DateTime c = new DateTime(year, month, 1);
            c.AddMonths(MONTH_COUNT * halfYears);
            return new SolarHalfYear(c);
        }

        /// <summary>
        /// 获取本半年的月份
        /// </summary>
        /// <returns>本半年的月份列表</returns>
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
            return year + "年" + (getIndex() == 1 ? "上" : "下") + "半年";
        }
    }
}
