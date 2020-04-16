using System;
using System.Collections.Generic;
using System.Text;
using com.nlf.calendar.util;

namespace com.nlf.calendar
{
    /// <summary>
    /// 阳历周
    /// </summary>
    public class SolarWeek
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
        /// 日
        /// </summary>
        private int day;
        
        /// <summary>
        /// 星期几作为一周的开始，1234560分别代表星期一至星期天
        /// </summary>
        private int start;
        
        /// <summary>
        /// 默认当月
        /// </summary>
        /// <param name="start">星期几作为一周的开始，1234560分别代表星期一至星期天</param>
        public SolarWeek(int start):this(DateTime.Now,start)
        {
        }

        /// <summary>
        /// 通过日期初始化
        /// </summary>
        /// <param name="date">日期</param>
        /// <param name="start">星期几作为一周的开始，1234560分别代表星期一至星期天</param>
        public SolarWeek(DateTime date, int start):this(date.Year,date.Month,date.Day,start)
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
            this.year = year;
            this.month = month;
            this.day = day;
            this.start = start;
        }

        /// <summary>
        /// 通过指定日期获取阳历周
        /// </summary>
        /// <param name="date">日期</param>
        /// <param name="start">星期几作为一周的开始，1234560分别代表星期一至星期天</param>
        /// <returns>阳历周</returns>
        public static SolarWeek fromDate(DateTime date, int start)
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
        public static SolarWeek fromYmd(int year, int month, int day, int start)
        {
            return new SolarWeek(year, month, day, start);
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
        /// <returns>1到12</returns>
        public int getMonth()
        {
            return month;
        }

        /// <summary>
        /// 获取日期
        /// </summary>
        /// <returns>1到31之间的数字</returns>
        public int getDay()
        {
            return day;
        }

        /// <summary>
        /// 获取星期几作为一周的开始，1234560分别代表星期一至星期天
        /// </summary>
        /// <returns>1234560分别代表星期一至星期天</returns>
        public int getStart()
        {
            return start;
        }

        /// <summary>
        /// 获取当前日期是在当月第几周
        /// </summary>
        /// <returns>周序号，从1开始</returns>
        public int getIndex()
        {
            DateTime firstDay = new DateTime(year, month, 1);
            int firstDayWeek = Convert.ToInt32(firstDay.DayOfWeek.ToString("d"));
            return (int)Math.Ceiling((day + firstDayWeek - start) * 1D / SolarUtil.WEEK.Length);
        }

        /// <summary>
        /// 周推移
        /// </summary>
        /// <param name="weeks">推移的周数，负数为倒推</param>
        /// <param name="separateMonth">是否按月单独计算</param>
        /// <returns>推移后的阳历周</returns>
        public SolarWeek next(int weeks, bool separateMonth)
        {
            if (0 == weeks)
            {
                return new SolarWeek(year, month, day, start);
            }
            if (separateMonth)
            {
                int n = weeks;
                DateTime c = new DateTime(year, month, day);
                SolarWeek week = new SolarWeek(c, start);
                int m = this.month;
                bool plus = n > 0;
                while (0 != n)
                {
                    c.AddDays(plus ? 7 : -7);
                    week = new SolarWeek(c, start);
                    int weekMonth = week.getMonth();
                    if (m != weekMonth)
                    {
                        int index = week.getIndex();
                        if (plus)
                        {
                            if (1 == index)
                            {
                                Solar firstDay = week.getFirstDay();
                                week = new SolarWeek(firstDay.getYear(), firstDay.getMonth(), firstDay.getDay(), start);
                                weekMonth = week.getMonth();
                            }
                            else
                            {
                                c = new DateTime(week.getYear(), week.getMonth(), 1);
                                week = new SolarWeek(c, start);
                            }
                        }
                        else
                        {
                            int size = SolarUtil.getWeeksOfMonth(week.getYear(), week.getMonth(), start);
                            if (size == index)
                            {
                                Solar firstDay = week.getFirstDay();
                                Solar lastDay = firstDay.next(6);
                                week = new SolarWeek(lastDay.getYear(), lastDay.getMonth(), lastDay.getDay(), start);
                                weekMonth = week.getMonth();
                            }
                            else
                            {
                                c = new DateTime(week.getYear(), week.getMonth(), SolarUtil.getDaysOfMonth(week.getYear(), week.getMonth()));
                                week = new SolarWeek(c, start);
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
                DateTime c = new DateTime(year, month, day);
                c.AddDays(weeks * 7);
                return new SolarWeek(c, start);
            }
        }

        /// <summary>
        /// 获取本周第一天的阳历日期（可能跨月）
        /// </summary>
        /// <returns>本周第一天的阳历日期</returns>
        public Solar getFirstDay()
        {
            DateTime c = new DateTime(year, month, day);
            int week = Convert.ToInt32(c.DayOfWeek.ToString("d"));
            int prev = week - start;
            if (prev < 0)
            {
                prev += 7;
            }
            c.AddDays(-prev);
            return new Solar(c);
        }

        /// <summary>
        /// 获取本周第一天的阳历日期（仅限当月）
        /// </summary>
        /// <returns>本周第一天的阳历日期</returns>
        public Solar getFirstDayInMonth()
        {
            List<Solar> days = getDays();
            foreach (Solar day in days)
            {
                if (month == day.getMonth())
                {
                    return day;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取本周的阳历日期列表（可能跨月）
        /// </summary>
        /// <returns>本周的阳历日期列表</returns>
        public List<Solar> getDays()
        {
            Solar firstDay = getFirstDay();
            List<Solar> l = new List<Solar>();
            l.Add(firstDay);
            for (int i = 1; i < 7; i++)
            {
                l.Add(firstDay.next(i));
            }
            return l;
        }

        /// <summary>
        /// 获取本周的阳历日期列表（仅限当月）
        /// </summary>
        /// <returns>本周的阳历日期列表（仅限当月）</returns>
        public List<Solar> getDaysInMonth()
        {
            List<Solar> days = this.getDays();
            List<Solar> l = new List<Solar>();
            foreach (Solar day in days)
            {
                if (month != day.getMonth())
                {
                    continue;
                }
                l.Add(day);
            }
            return l;
        }

        public override string ToString()
        {
            return year + "." + month + "." + getIndex();
        }

        public string toFullString()
        {
            return year + "年" + month + "月第" + getIndex() + "周";
        }
    }
}
