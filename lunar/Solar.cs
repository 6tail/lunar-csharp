using System;
using System.Collections.Generic;
using System.Text;
using Lunar.Util;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable IdentifierTypo

namespace Lunar
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
        public int Year { get; }

        /// <summary>
        /// 月
        /// </summary>
        public int Month { get; }

        /// <summary>
        /// 日
        /// </summary>
        public int Day { get; }

        /// <summary>
        /// 时
        /// </summary>
        public int Hour { get; }

        /// <summary>
        /// 分
        /// </summary>
        public int Minute { get; }

        /// <summary>
        /// 秒
        /// </summary>
        public int Second { get; }

        /// <summary>
        /// 日历
        /// </summary>
        public DateTime Calendar { get; }

        /// <summary>
        /// 默认使用当前日期初始化
        /// </summary>
        public Solar(): this(DateTime.Now)
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
        public Solar(int year, int month, int day, int hour = 0, int minute = 0, int second = 0)
        {
            if (year == 1582 && month == 10)
            {
                if (day >= 15)
                {
                    day -= 10;
                }
            }
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;
            Calendar = ExactDate.FromYmdHms(year, month, day, hour, minute, second);
        }

        /// <summary>
        /// 通过日期初始化
        /// </summary>
        /// <param name="date">日期</param>
        public Solar(DateTime date): this(date.Year, date.Month, date.Day, date.Hour, date.Minute,date.Second)
        {
        }

        /// <summary>
        /// 通过儒略日初始化
        /// </summary>
        /// <param name="julianDay">儒略日</param>
        public Solar(double julianDay)
        {
            var d = (int)(julianDay + 0.5);
            var f = julianDay + 0.5 - d;

            if (d >= 2299161)
            {
                var c = (int)((d - 1867216.25) / 36524.25);
                d += 1 + c - (int)(c * 1D / 4);
            }
            d += 1524;
            var year = (int)((d - 122.1) / 365.25);
            d -= (int)(365.25 * year);
            var month = (int)(d * 1D / 30.601);
            d -= (int)(30.601 * month);
            var day = d;
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
            var hour = (int)f;

            f -= hour;
            f *= 60;
            var minute = (int)f;

            f -= minute;
            f *= 60;
            var second = (int)Math.Round(f);

            if (second > 59)
            {
                second -= 60;
                minute++;
            }
            if (minute > 59)
            {
                minute -= 60;
                hour++;
            }
            Calendar = ExactDate.FromYmdHms(year, month, day, hour, minute, second);
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;
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
        public static Solar FromYmdHms(int year, int month, int day, int hour = 0, int minute = 0,int second = 0)
        {
            return new Solar(year, month, day, hour, minute,second);
        }

        /// <summary>
        /// 通过指定日期获取阳历
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns>阳历</returns>
        public static Solar FromDate(DateTime date)
        {
            return new Solar(date);
        }

        /// <summary>
        /// 通过指定儒略日获取阳历
        /// </summary>
        /// <param name="julianDay">儒略日</param>
        /// <returns>阳历</returns>
        public static Solar FromJulianDay(double julianDay)
        {
            return new Solar(julianDay);
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
        public static List<Solar> FromBaZi(string yearGanZhi, string monthGanZhi, string dayGanZhi, string timeGanZhi, int sect = 2, int baseYear = 1900)
        {
            sect = (1 == sect) ? 1 : 2;
            var l = new List<Solar>();
            var today = new Solar();
            var lunar = today.Lunar;
            var offsetYear = LunarUtil.GetJiaZiIndex(lunar.YearInGanZhiExact) - LunarUtil.GetJiaZiIndex(yearGanZhi);
            if (offsetYear < 0)
            {
                offsetYear += 60;
            }
            var startYear = lunar.Year - offsetYear;
            var hour = 0;
            var timeZhi = timeGanZhi.Substring(1);
            for (int i = 0, j = LunarUtil.ZHI.Length; i < j; i++)
            {
                if (LunarUtil.ZHI[i].Equals(timeZhi))
                {
                    hour = (i - 1) * 2;
                }
            }
            while (startYear >= baseYear)
            {
                var year = startYear - 1;
                var counter = 0;
                var month = 12;
                int day;
                var found = false;
                while (counter < 15)
                {
                    if (year >= baseYear)
                    {
                        day = 1;
                        var solar = new Solar(year, month, day, hour);
                        lunar = solar.Lunar;
                        if (lunar.YearInGanZhiExact.Equals(yearGanZhi) && lunar.MonthInGanZhiExact.Equals(monthGanZhi))
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
                    Solar solar = new Solar(year, month, day, hour);
                    while (counter < 61)
                    {
                        lunar = solar.Lunar;
                        string dgz = (2 == sect) ? lunar.DayInGanZhiExact2 : lunar.DayInGanZhiExact;
                        if (lunar.YearInGanZhiExact.Equals(yearGanZhi) && lunar.MonthInGanZhiExact.Equals(monthGanZhi) && dgz.Equals(dayGanZhi) && lunar.TimeInGanZhi.Equals(timeGanZhi))
                        {
                            l.Add(solar);
                            break;
                        }
                        solar = solar.Next(1);
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
        public bool LeapYear => SolarUtil.IsLeapYear(Year);

        /// <summary>
        /// 星期，0代表周日，1代表周一
        /// </summary>
        public int Week => Convert.ToInt32(Calendar.DayOfWeek.ToString("d"));

        /// <summary>
        /// 星期的中文：日一二三四五六
        /// </summary>
        public string WeekInChinese => SolarUtil.WEEK[Week];

        /// <summary>
        /// 星座
        /// </summary>
        public string XingZuo
        {
            get
            {
                var index = 11;
                var y = Month * 100 + Day;
                switch (y)
                {
                    case >= 321 and <= 419:
                        index = 0;
                        break;
                    case >= 420 and <= 520:
                        index = 1;
                        break;
                    case >= 521 and <= 621:
                        index = 2;
                        break;
                    case >= 622 and <= 722:
                        index = 3;
                        break;
                    case >= 723 and <= 822:
                        index = 4;
                        break;
                    case >= 823 and <= 922:
                        index = 5;
                        break;
                    case >= 923 and <= 1023:
                        index = 6;
                        break;
                    case >= 1024 and <= 1122:
                        index = 7;
                        break;
                    case >= 1123 and <= 1221:
                        index = 8;
                        break;
                    case >= 1222:
                    case <= 119:
                        index = 9;
                        break;
                    case <= 218:
                        index = 10;
                        break;
                }
                return SolarUtil.XING_ZUO[index];
            }
        }

        /// <summary>
        /// 节日，有可能一天会有多个节日
        /// </summary>
        public List<string> Festivals
        {
            get
            {
                var l = new List<string>();
                //获取几月几日对应的节日
                try
                {
                    l.Add(SolarUtil.FESTIVAL[Month + "-" + Day]);
                }
                catch
                {
                    // ignored
                }

                //计算几月第几个星期几对应的节日
                var weeks = (int)Math.Ceiling(Day / 7D);
                //星期几，0代表星期天
                try
                {
                    l.Add(SolarUtil.WEEK_FESTIVAL[Month + "-" + weeks + "-" + Week]);
                }
                catch
                {
                    // ignored
                }

                if (Day + 7 <= SolarUtil.GetDaysOfMonth(Year, Month)) return l;
                try
                {
                    l.Add(SolarUtil.WEEK_FESTIVAL[Month + "-0-" + Week]);
                }
                catch
                {
                    // ignored
                }

                return l;
            }
        }

        public List<string> OtherFestivals
        {
            get
            {
                var l = new List<string>();
                try
                {
                    var fs = SolarUtil.OTHER_FESTIVAL[Month + "-" + Day];
                    l.AddRange(fs);
                }
                catch
                {
                    // ignored
                }
                return l;
            }
        }

        /// <summary>
        /// 阴历
        /// </summary>
        public Lunar Lunar => new Lunar(Calendar);

        /// <summary>
        /// 儒略日
        /// </summary>
        public double JulianDay
        {
            get
            {
                var y = Year;
                var m = Month;
                var d = Day + ((Second * 1D / 60 + Minute) / 60 + Hour) / 24;
                var n = 0;
                var g = y * 372 + m * 31 + (int)d >= 588829;
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
        }

        public override string ToString()
        {
            return Ymd;
        }

        public string Ymd
        {
            get
            {
                var d = Day;
                if (Year == 1582 && Month == 10)
                {
                    if (d >= 5)
                    {
                        d += 10;
                    }
                }
                var y = Year + "";
                while (y.Length < 4)
                {
                    y = "0" + y;
                }
                return y + "-" + (Month < 10 ? "0" : "") + Month + "-" + (d < 10 ? "0" : "") + d;
            }
        }

        public string YmdHms => Ymd + " " + (Hour < 10 ? "0" : "") + Hour + ":" + (Minute < 10 ? "0" : "") + Minute + ":" + (Second < 10 ? "0" : "") + Second;

        public string FullString
        {
            get
            {
                var s = new StringBuilder();
                s.Append(YmdHms);
                if (LeapYear)
                {
                    s.Append(' ');
                    s.Append("闰年");
                }
                s.Append(' ');
                s.Append("星期");
                s.Append(WeekInChinese);

                s.Append(' ');
                s.Append(XingZuo);
                s.Append('座');
                return s.ToString();
            }
        }

        /// <summary>
        /// 获取往后推几天的阳历日期，如果要往前推，则天数用负数
        /// </summary>
        /// <param name="days">天数</param>
        /// <param name="onlyWorkday">是否仅工作日</param>
        /// <returns>阳历日期</returns>
        public Solar Next(int days, bool onlyWorkday = false)
        {
            var c = ExactDate.FromYmdHms(Year, Month, Day, Hour, Minute, Second);
            if (0 == days) return new Solar(c);
            if (!onlyWorkday)
            {
                c = c.AddDays(days);
            }
            else
            {
                var rest = Math.Abs(days);
                var add = days < 1 ? -1 : 1;
                while (rest > 0)
                {
                    c = c.AddDays(add);
                    var work = true;
                    var holiday = HolidayUtil.GetHoliday(c.Year, c.Month, c.Day);
                    if (null == holiday)
                    {
                        var week = c.DayOfWeek.ToString("d");
                        if ("0".Equals(week)||"6".Equals(week))
                        {
                            work = false;
                        }
                    }
                    else
                    {
                        work = holiday.Work;
                    }
                    if (work)
                    {
                        rest--;
                    }
                }
            }
            return new Solar(c);
        }
    }
}