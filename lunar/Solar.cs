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
        public Solar(int year, int month, int day, int hour, int minute, int second)
        {
            if (year == 1582 && month == 10)
            {
                if (day >= 15)
                {
                    day -= 10;
                }
            }
            this.year = year;
            this.month = month;
            this.day = day;
            this.hour = hour;
            this.minute = minute;
            this.second = second;
            this.calendar = ExactDate.fromYmdHms(year, month, day, hour, minute, second);
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
            int d = (int)(julianDay + 0.5);
            double f = julianDay + 0.5 - d;
            int c;

            if (d >= 2299161)
            {
                c = (int)((d - 1867216.25) / 36524.25);
                d += 1 + c - (int)(c * 1D / 4);
            }
            d += 1524;
            int year = (int)((d - 122.1) / 365.25);
            d -= (int)(365.25 * year);
            int month = (int)(d * 1D / 30.601);
            d -= (int)(30.601 * month);
            int day = d;
            if (month > 13)
            {
                month -= 13;
                year -= 4715;
            }
            else
            {
                month -= 1;
                year -= 4716;
            }
            f *= 24;
            int hour = (int)f;

            f -= hour;
            f *= 60;
            int minute = (int)f;

            f -= minute;
            f *= 60;
            int second = (int)Math.Round(f);

            if (second == 60)
            {
                second = 59;
            }
            calendar = ExactDate.fromYmdHms(year, month, day, hour, minute, second);
            this.year = year;
            this.month = month;
            this.day = day;
            this.hour = hour;
            this.minute = minute;
            this.second = second;
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
        /// 通过八字获取阳历列表（流派2，晚子时日柱按当天，起始年为1900）
        /// </summary>
        /// <param name="yearGanZhi">年柱</param>
        /// <param name="monthGanZhi">月柱</param>
        /// <param name="dayGanZhi">日柱</param>
        /// <param name="timeGanZhi">时柱</param>
        /// <returns>符合的阳历列表</returns>
        public static List<Solar> fromBaZi(string yearGanZhi, string monthGanZhi, string dayGanZhi, string timeGanZhi)
        {
            return fromBaZi(yearGanZhi, monthGanZhi, dayGanZhi, timeGanZhi, 2);
        }

        /// <summary>
        /// 通过八字获取阳历列表（起始年为1900）
        /// </summary>
        /// <param name="yearGanZhi">年柱</param>
        /// <param name="monthGanZhi">月柱</param>
        /// <param name="dayGanZhi">日柱</param>
        /// <param name="timeGanZhi">时柱</param>
        /// <param name="sect">流派，2晚子时日柱按当天，1晚子时日柱按明天</param>
        /// <returns>符合的阳历列表</returns>
        public static List<Solar> fromBaZi(string yearGanZhi, string monthGanZhi, string dayGanZhi, string timeGanZhi, int sect)
        {
            return fromBaZi(yearGanZhi, monthGanZhi, dayGanZhi, timeGanZhi, sect, 1900);
        }

        /// <summary>
        /// 通过八字获取阳历列表
        /// </summary>
        /// <param name="yearGanZhi">年柱</param>
        /// <param name="monthGanZhi">月柱</param>
        /// <param name="dayGanZhi">日柱</param>
        /// <param name="timeGanZhi">时柱</param>
        /// <param name="sect">流派，2晚子时日柱按当天，1晚子时日柱按明天</param>
        /// <param name="baseYear">起始年</param>
        /// <returns>符合的阳历列表</returns>
        public static List<Solar> fromBaZi(string yearGanZhi, string monthGanZhi, string dayGanZhi, string timeGanZhi, int sect, int baseYear)
        {
            sect = (1 == sect) ? 1 : 2;
            List<Solar> l = new List<Solar>();
            Solar today = new Solar();
            Lunar lunar = today.getLunar();
            int offsetYear = LunarUtil.getJiaZiIndex(lunar.getYearInGanZhiExact()) - LunarUtil.getJiaZiIndex(yearGanZhi);
            if (offsetYear < 0)
            {
                offsetYear = offsetYear + 60;
            }
            int startYear = today.getYear() - offsetYear;
            int hour = 0;
            string timeZhi = timeGanZhi.Substring(1);
            for (int i = 0, j = LunarUtil.ZHI.Length; i < j; i++)
            {
                if (LunarUtil.ZHI[i].Equals(timeZhi))
                {
                    hour = (i - 1) * 2;
                }
            }
            while (startYear >= baseYear)
            {
                int year = startYear - 1;
                int counter = 0;
                int month = 12;
                int day;
                bool found = false;
                while (counter < 15)
                {
                    if (year >= baseYear)
                    {
                        day = 1;
                        Solar solar = new Solar(year, month, day, hour, 0, 0);
                        lunar = solar.getLunar();
                        if (lunar.getYearInGanZhiExact().Equals(yearGanZhi) && lunar.getMonthInGanZhiExact().Equals(monthGanZhi))
                        {
                            found = true;
                            break;
                        }
                    }
                    month++;
                    if (month > 12)
                    {
                        month = 1;
                        year++;
                    }
                    counter++;
                }
                if (found)
                {
                    counter = 0;
                    month--;
                    if (month < 1)
                    {
                        month = 12;
                        year--;
                    }
                    day = 1;
                    Solar solar = new Solar(year, month, day, hour, 0, 0);
                    while (counter < 61)
                    {
                        lunar = solar.getLunar();
                        string dgz = (2 == sect) ? lunar.getDayInGanZhiExact2() : lunar.getDayInGanZhiExact();
                        if (lunar.getYearInGanZhiExact().Equals(yearGanZhi) && lunar.getMonthInGanZhiExact().Equals(monthGanZhi) && dgz.Equals(dayGanZhi) && lunar.getTimeInGanZhi().Equals(timeGanZhi))
                        {
                            l.Add(solar);
                            break;
                        }
                        solar = solar.next(1);
                        counter++;
                    }
                }
                startYear -= 60;
            }
            return l;
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
            int index = 11;
            int y = month * 100 + day;
            if (y >= 321 && y <= 419)
            {
                index = 0;
            }
            else if (y >= 420 && y <= 520)
            {
                index = 1;
            }
            else if (y >= 521 && y <= 621)
            {
                index = 2;
            }
            else if (y >= 622 && y <= 722)
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
            else if (y >= 923 && y <= 1023)
            {
                index = 6;
            }
            else if (y >= 1024 && y <= 1122)
            {
                index = 7;
            }
            else if (y >= 1123 && y <= 1221)
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
            int weeks = (int)Math.Ceiling(day / 7D);
            //星期几，0代表星期天
            int week = getWeek();
            try
            {
                l.Add(SolarUtil.WEEK_FESTIVAL[month + "-" + weeks + "-" + week]);
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

        /// <summary>
        /// 获取儒略日
        /// </summary>
        /// <returns>儒略日</returns>
        public double getJulianDay()
        {
            int y = this.year;
            int m = this.month;
            double d = this.day + ((this.second * 1D / 60 + this.minute) / 60 + this.hour) / 24;
            int n = 0;
            bool g = false;
            if (y * 372 + m * 31 + (int)d >= 588829)
            {
                g = true;
            }
            if (m <= 2)
            {
                m += 12;
                y--;
            }
            if (g)
            {
                n = (int)(y * 1D / 100);
                n = 2 - n + (int)(n * 1D / 4);
            }
            return (int)(365.25 * (y + 4716)) + (int)(30.6001 * (m + 1)) + d + n - 1524.5;
        }


        public override string ToString()
        {
            return toString();
        }

        public string toString()
        {
            return toYmd();
        }

        public string toYmd()
        {
            int d = this.day;
            if (this.year == 1582 && this.month == 10)
            {
                if (d >= 5)
                {
                    d += 10;
                }
            }
            string y = this.year + "";
            while (y.Length < 4)
            {
                y = "0" + y;
            }
            return y + "-" + (month < 10 ? "0" : "") + month + "-" + (d < 10 ? "0" : "") + d;
        }

        [Obsolete("This method is obsolete, use method toYmdHms instead")]
        public string toYmdhms()
        {
            return toYmdHms();
        }

        public string toYmdHms()
        {
            return toYmd() + " " + (hour < 10 ? "0" : "") + hour + ":" + (minute < 10 ? "0" : "") + minute + ":" + (second < 10 ? "0" : "") + second;
        }

        public string toFullString()
        {
            StringBuilder s = new StringBuilder();
            s.Append(toYmdHms());
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
            return next(days, false);
        }

        /// <summary>
        /// 获取往后推几天的阳历日期，如果要往前推，则天数用负数
        /// </summary>
        /// <param name="days">天数</param>
        /// <param name="onlyWorkday">是否仅工作日</param>
        /// <returns>阳历日期</returns>
        public Solar next(int days, bool onlyWorkday)
        {
            DateTime c = ExactDate.fromYmdHms(year, month, day, hour, minute, second);
            if (0 != days)
            {
                if (!onlyWorkday)
                {
                    c = c.AddDays(days);
                }
                else
                {
                    int rest = Math.Abs(days);
                    int add = days < 1 ? -1 : 1;
                    while (rest > 0)
                    {
                        c = c.AddDays(add);
                        bool work = true;
                        Holiday holiday = HolidayUtil.getHoliday(c.Year, c.Month, c.Day);
                        if (null == holiday)
                        {
                            string week = c.DayOfWeek.ToString("d");
                            if ("0".Equals(week)||"6".Equals(week))
                            {
                                work = false;
                            }
                        }
                        else
                        {
                            work = holiday.isWork();
                        }
                        if (work)
                        {
                            rest--;
                        }
                    }
                }
            }
            return new Solar(c);
        }
    }
}