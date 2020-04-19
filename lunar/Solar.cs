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
        /// 2000年儒略日数(2000-1-1 12:00:00 UTC)
        /// </summary>
        public const double J2000 = 2451545;

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
        /// 秒
        /// </summary>
        private int second;

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
            : this(year, month, day, 0, 0, 0)
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
        /// <param name="second">秒钟，0到59</param>
        public Solar(int year, int month, int day, int hour, int minute,int second)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.hour = hour;
            this.minute = minute;
            this.calendar = new DateTime(year, month, day, hour, minute, second);
        }

        /// <summary>
        /// 通过日期初始化
        /// </summary>
        /// <param name="date">日期</param>
        public Solar(DateTime date)
            : this(date.Year, date.Month, date.Day, date.Hour, date.Minute,date.Second)
        {
        }

        /// <summary>
        /// 通过儒略日初始化
        /// </summary>
        /// <param name="julianDay">儒略日</param>
        public Solar(double julianDay)
        {
            julianDay += 0.5;

            // 日数的整数部份
            double a = int2(julianDay);
            // 日数的小数部分
            double f = julianDay - a;
            double D;

            if (a > 2299161)
            {
                D = int2((a - 1867216.25) / 36524.25);
                a += 1 + D - int2(D / 4);
            }
            // 向前移4年零2个月
            a += 1524;
            double y = int2((a - 122.1) / 365.25);
            // 去除整年日数后余下日数
            D = a - int2(365.25 * y);
            double m = (int)int2(D / 30.6001);
            // 去除整月日数后余下日数
            double d = (int)int2(D - int2(m * 30.6001));
            y -= 4716;
            m--;
            if (m > 12)
            {
                m -= 12;
            }
            if (m <= 2)
            {
                y++;
            }

            // 日的小数转为时分秒
            f *= 24;
            double h = (int)int2(f);

            f -= h;
            f *= 60;
            double mi = int2(f);

            f -= mi;
            f *= 60;
            double s = int2(f);

            calendar = new DateTime((int)y, (int)m, (int)d, (int)h, (int)mi, (int)s);

            year = calendar.Year;
            month = calendar.Month;
            day = calendar.Day;
            hour = calendar.Hour;
            minute = calendar.Minute;
            second = calendar.Second;
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
        /// <param name="second">秒钟，0到59</param>
        /// <returns>阳历</returns>
        public static Solar fromYmdHms(int year, int month, int day, int hour, int minute,int second)
        {
            return new Solar(year, month, day, hour, minute,second);
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
        /// 通过指定儒略日获取阳历
        /// </summary>
        /// <param name="julianDay">儒略日</param>
        /// <returns>阳历</returns>
        public static Solar fromJulianDay(double julianDay)
        {
            return new Solar(julianDay);
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

        public int getSecond()
        {
            return second;
        }

        public DateTime getCalendar()
        {
            return calendar;
        }

        public Lunar getLunar()
        {
            return new Lunar(calendar);
        }

        private double int2(double v)
        {
            v = Math.Floor(v);
            return v < 0 ? v + 1 : v;
        }

        /// <summary>
        /// 获取儒略日
        /// </summary>
        /// <returns>儒略日</returns>
        public double getJulianDay()
        {
            double y = this.year;
            double m = this.month;
            double n = 0;

            if (m <= 2)
            {
                m += 12;
                y--;
            }

            // 判断是否为UTC日1582*372+10*31+15
            if (this.year * 372 + this.month * 31 + this.day >= 588829)
            {
                n = int2(y / 100);
                // 加百年闰
                n = 2 - n + int2(n / 4);
            }

            // 加上年引起的偏移日数
            n += int2(365.2500001 * (y + 4716));
            // 加上月引起的偏移日数及日偏移数
            n += int2(30.6 * (m + 1)) + this.day;
            n += ((this.second * 1D / 60 + this.minute) / 60 + this.hour) / 24 - 1524.5;
            return n;
        }


        public override string ToString()
        {
            return toYmd();
        }

        public String toYmd()
        {
            return year + "-" + (month < 10 ? "0" : "") + month + "-" + (day < 10 ? "0" : "") + day;
        }

        public String toYmdhms()
        {
            return toYmd() + " " + (hour < 10 ? "0" : "") + hour + ":" + (minute < 10 ? "0" : "") + minute + ":" + (second < 10 ? "0" : "") + second;
        }

        public string toFullString()
        {
            StringBuilder s = new StringBuilder();
            s.Append(toYmdhms());
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
            DateTime c = new DateTime(year, month, day, hour, minute, second);
            c.AddDays(days);
            return new Solar(c);
        }
    }
}