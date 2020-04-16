using System;
using System.Collections.Generic;
using System.Text;

namespace com.nlf.calendar
{
    /// <summary>
    /// 阳历年
    /// </summary>
    public class SolarYear
    {
        /// <summary>
        /// 年
        /// </summary>
        private int year;

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
            year = date.Year;
        }

        /// <summary>
        /// 通过年初始化
        /// </summary>
        /// <param name="year">年</param>
        public SolarYear(int year)
        {
            this.year = year;
        }

        /// <summary>
        /// 通过指定日期获取阳历年
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns>阳历年</returns>
        public static SolarYear fromDate(DateTime date)
        {
            return new SolarYear(date);
        }

        /// <summary>
        /// 通过指定年份获取阳历年
        /// </summary>
        /// <param name="year">年</param>
        /// <returns>阳历年</returns>
        public static SolarYear fromYear(int year)
        {
            return new SolarYear(year);
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
        /// 获取本年的阳历月列表
        /// </summary>
        /// <returns>阳历月列表</returns>
        public List<SolarMonth> getMonths()
        {
            List<SolarMonth> l = new List<SolarMonth>(MONTH_COUNT);
            SolarMonth m = new SolarMonth(year, 1);
            l.Add(m);
            for (int i = 1; i < MONTH_COUNT; i++)
            {
                l.Add(m.next(i));
            }
            return l;
        }

        /// <summary>
        /// 获取往后推几年的阳历年，如果要往前推，则年数用负数
        /// </summary>
        /// <param name="years">年数</param>
        /// <returns>阳历年</returns>
        public SolarYear next(int years)
        {
            DateTime c = new DateTime(year, 1, 1);
            c.AddYears(years);
            return new SolarYear(c);
        }

        public override string ToString()
        {
            return year + "";
        }

        public string toFullString()
        {
            return year + "年";
        }
    }
}
