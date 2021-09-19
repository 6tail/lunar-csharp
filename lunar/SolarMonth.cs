using System;
using System.Collections.Generic;
using System.Text;
using com.nlf.calendar.util;

namespace com.nlf.calendar
{
    public class SolarMonth
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
        /// 默认日期
        /// </summary>
        public SolarMonth()
            : this(DateTime.Now)
        {
        }

        /// <summary>
        /// 通过日期初始化
        /// </summary>
        /// <param name="date">日期</param>
        public SolarMonth(DateTime date)
        {
            year = date.Year;
            month = date.Month;
        }

        /// <summary>
        /// 通过年月初始化
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        public SolarMonth(int year, int month)
        {
            this.year = year;
            this.month = month;
        }

        /// <summary>
        /// 通过指定日期获取阳历月
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns>阳历月</returns>
        public static SolarMonth fromDate(DateTime date)
        {
            return new SolarMonth(date);
        }

        /// <summary>
        /// 通过指定年月获取阳历月
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns>阳历月</returns>
        public static SolarMonth fromYm(int year, int month)
        {
            return new SolarMonth(year, month);
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
        /// 获取本月的阳历日期列表
        /// </summary>
        /// <returns>阳历日期列表</returns>
        public List<Solar> getDays()
        {
            List<Solar> l = new List<Solar>(31);
            Solar d = new Solar(year, month, 1);
            l.Add(d);
            int days = SolarUtil.getDaysOfMonth(year, month);
            for (int i = 1; i < days; i++)
            {
                l.Add(d.next(i));
            }
            return l;
        }

        /// <summary>
        /// 获取往后推几个月的阳历月，如果要往前推，则月数用负数
        /// </summary>
        /// <param name="months">月数</param>
        /// <returns>阳历月</returns>
        public SolarMonth next(int months)
        {
            DateTime c = ExactDate.fromYmd(year, month, 1);
            c = c.AddMonths(months);
            return new SolarMonth(c);
        }

        public override string ToString()
        {
            return year + "-" + month;
        }

        public string toFullString()
        {
            return year + "年" + month + "月";
        }
    }
}