using System;
using System.Collections.Generic;
using System.Text;
using com.nlf.calendar.util;

namespace com.nlf.calendar
{
    /// <summary>
    /// 阳历日期
    /// </summary>
    public class Solar
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
        /// 时
        /// </summary>
        private int hour;

        /// <summary>
        /// 分
        /// </summary>
        private int minute;

        /// <summary>
        /// 日历
        /// </summary>
        private DateTime calendar;

        /// <summary>
        /// 默认使用当前日期初始化
        /// </summary>
        public Solar()
            : this(DateTime.Now)
        {
        }

        /// <summary>
        /// 通过年月日初始化
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月，1到12</param>
        /// <param name="day">日，1到31</param>
        public Solar(int year, int month, int day)
            : this(year, month, day, 0, 0)
        {
        }

        /// <summary>
        /// 通过年月日时分初始化
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月，1到12</param>
        /// <param name="day">日，1到31</param>
        /// <param name="hour">小时，0到23</param>
        /// <param name="minute">分钟，0到59</param>
        public Solar(int year, int month, int day, int hour, int minute)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.hour = hour;
            this.minute = minute;
            this.calendar = new DateTime(year, month, day, hour, minute, 0);
        }

        /// <summary>
        /// 通过日期初始化
        /// </summary>
        /// <param name="date">日期</param>
        public Solar(DateTime date)
            : this(date.Year, date.Month, date.Day, date.Hour, date.Minute)
        {
        }

        /// <summary>
        /// 通过指定年月日获取阳历
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月，1到12</param>
        /// <param name="day">日，1到31</param>
        /// <returns>阳历</returns>
        public static Solar fromYmd(int year, int month, int day)
        {
            return new Solar(year, month, day);
        }

        /// <summary>
        /// 通过指定年月日时分获取阳历
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月，1到12</param>
        /// <param name="day">日，1到31</param>
        /// <param name="hour">小时，0到23</param>
        /// <param name="minute">分钟，0到59</param>
        /// <returns>阳历</returns>
        public static Solar fromYmdHm(int year, int month, int day, int hour, int minute)
        {
            return new Solar(year, month, day, hour, minute);
        }

        /// <summary>
        /// 通过指定日期获取阳历
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns>阳历</returns>
        public static Solar fromDate(DateTime date)
        {
            return new Solar(date);
        }

        /// <summary>
        /// 是否闰年
        /// </summary>
        /// <returns>true/false 闰年/非闰年</returns>
        public Boolean isLeapYear()
        {
            return SolarUtil.isLeapYear(year);
        }

        /// <summary>
        /// 获取星期，0代表周日，1代表周一
        /// </summary>
        /// <returns>0123456</returns>
        public int getWeek()
        {
            return Convert.ToInt32(calendar.DayOfWeek.ToString("d"));
        }

        /// <summary>
        /// 获取星期的中文
        /// </summary>
        /// <returns>日一二三四五六</returns>
        public string getWeekInChinese()
        {
            return SolarUtil.WEEK[getWeek()];
        }

        [Obsolete("This method is obsolete, use method getXingZuo instead")]
        public string getXingzuo()
        {
            return getXingZuo();
        }

        /// <summary>
        /// 获取星座
        /// </summary>
        /// <returns>星座</returns>
        public string getXingZuo()
        {
            int index = 11, m = month, d = day;
            int y = m * 100 + d;
            if (y >= 321 && y <= 419)
            {
                index = 0;
            }
            else if (y >= 420 && y <= 520)
            {
                index = 1;
            }
            else if (y >= 521 && y <= 620)
            {
                index = 2;
            }
            else if (y >= 621 && y <= 722)
            {
                index = 3;
            }
            else if (y >= 723 && y <= 822)
            {
                index = 4;
            }
            else if (y >= 823 && y <= 922)
            {
                index = 5;
            }
            else if (y >= 923 && y <= 1022)
            {
                index = 6;
            }
            else if (y >= 1023 && y <= 1121)
            {
                index = 7;
            }
            else if (y >= 1122 && y <= 1221)
            {
                index = 8;
            }
            else if (y >= 1222 || y <= 119)
            {
                index = 9;
            }
            else if (y <= 218)
            {
                index = 10;
            }
            return SolarUtil.XINGZUO[index];
        }

        /// <summary>
        /// 获取节日，有可能一天会有多个节日
        /// </summary>
        /// <returns>劳动节等</returns>
        public List<string> getFestivals()
        {
            List<string> l = new List<string>();
            //获取几月几日对应的节日
            try
            {
                l.Add(SolarUtil.FESTIVAL[month + "-" + day]);
            }
            catch { }
            //计算几月第几个星期几对应的节日
            //第几周

            DateTime firstDay = new DateTime(year, month, 1);
            int firstDayWeek = Convert.ToInt32(firstDay.DayOfWeek.ToString("d"));
            int weekInMonth = (int)Math.Ceiling((day + firstDayWeek) * 1D / SolarUtil.WEEK.Length);
            //星期几，0代表星期天
            int week = getWeek();
            //星期天很奇葩，会多算一周，需要减掉
            if (0 == week)
            {
                weekInMonth--;
            }
            try
            {
                l.Add(SolarUtil.WEEK_FESTIVAL[month + "-" + weekInMonth + "-" + week]);
            }
            catch { }
            return l;
        }

        public List<string> getOtherFestivals()
        {
            List<string> l = new List<string>();
            try
            {
                List<string> fs = SolarUtil.OTHER_FESTIVAL[month + "-" + day];
                l.AddRange(fs);
            }
            catch { }
            return l;
        }

        public int getYear()
        {
            return year;
        }

        public int getMonth()
        {
            return month;
        }

        public int getDay()
        {
            return day;
        }

        public int getHour()
        {
            return hour;
        }

        public int getMinute()
        {
            return minute;
        }

        public DateTime getCalendar()
        {
            return calendar;
        }

        public Lunar getLunar()
        {
            return new Lunar(calendar);
        }

        public override string ToString()
        {
            return year + "-" + (month < 10 ? "0" : "") + month + "-" + (day < 10 ? "0" : "") + day;
        }

        public string toFullString()
        {
            StringBuilder s = new StringBuilder();
            s.Append(ToString());
            s.Append(" ");
            s.Append(hour < 10 ? "0" : "");
            s.Append(hour);
            s.Append(":");
            s.Append(minute < 10 ? "0" : "");
            s.Append(minute);
            if (isLeapYear())
            {
                s.Append(" ");
                s.Append("闰年");
            }
            s.Append(" ");
            s.Append("星期");
            s.Append(getWeekInChinese());

            s.Append(" ");
            s.Append(getXingZuo());
            s.Append("座");
            return s.ToString();
        }

        /// <summary>
        /// 获取往后推几天的阳历日期，如果要往前推，则天数用负数
        /// </summary>
        /// <param name="days">天数</param>
        /// <returns>阳历日期</returns>
        public Solar next(int days)
        {
            DateTime c = new DateTime(year, month, day, hour, minute, 0);
            c.AddDays(days);
            return new Solar(c);
        }
    }
}