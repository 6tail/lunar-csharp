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
        /// 默认使用当前日期初始化
        /// </summary>
        public Solar() : this(DateTime.Now)
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
            if (1582 == year && 10 == month)
            {
                if (day > 4 && day < 15)
                {
                    throw new ArgumentException($"wrong solar year {year} month {month} day {day}");
                }
            }

            if (month < 1 || month > 12)
            {
                throw new ArgumentException($"wrong month {month}");
            }

            if (day < 1 || day > 31)
            {
                throw new ArgumentException($"wrong day {day}");
            }

            if (hour < 0 || hour > 23)
            {
                throw new ArgumentException($"wrong hour {hour}");
            }

            if (minute < 0 || minute > 59)
            {
                throw new ArgumentException($"wrong minute {minute}");
            }

            if (second < 0 || second > 59)
            {
                throw new ArgumentException($"wrong second {second}");
            }

            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        /// <summary>
        /// 通过日期初始化
        /// </summary>
        /// <param name="date">日期</param>
        public Solar(DateTime date) : this(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second)
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
            if (hour > 23)
            {
                hour -= 24;
                day += 1;
            }
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
        public static Solar FromYmdHms(int year, int month, int day, int hour = 0, int minute = 0, int second = 0)
        {
            return new Solar(year, month, day, hour, minute, second);
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
        public static List<Solar> FromBaZi(string yearGanZhi, string monthGanZhi, string dayGanZhi, string timeGanZhi,
            int sect = 2, int baseYear = 1900)
        {
            sect = (1 == sect) ? 1 : 2;
            var l = new List<Solar>();
            // 月地支距寅月的偏移值
            var m = LunarUtil.find(monthGanZhi.Substring(1), LunarUtil.ZHI, -1) - 2;
            if (m < 0)
            {
                m += 12;
            }

            // 月天干要一致
            if (((LunarUtil.find(yearGanZhi.Substring(0, 1), LunarUtil.GAN, -1) + 1) * 2 + m) % 10 !=
                LunarUtil.find(monthGanZhi.Substring(0, 1), LunarUtil.GAN, -1))
            {
                return l;
            }

            // 1年的立春是辛酉，序号57
            var y = LunarUtil.GetJiaZiIndex(yearGanZhi) - 57;
            if (y < 0)
            {
                y += 60;
            }

            y++;
            // 节令偏移值
            m *= 2;
            // 时辰地支转时刻，子时按零点算
            var h = LunarUtil.find(timeGanZhi.Substring(1), LunarUtil.ZHI, -1) * 2;
            int[] hours = { h };
            if (0 == h && 2 == sect)
            {
                hours = new[] { 0, 23 };
            }

            var startYear = baseYear - 1;

            // 结束年
            var endYear = DateTime.Now.Year;

            while (y <= endYear)
            {
                if (y >= startYear)
                {
                    // 立春为寅月的开始
                    var solarTime = Lunar.FromYmdHms(y, 1, 1).JieQiTable[Lunar.JIE_QI_IN_USE[4 + m]];
                    // 节令推移，年干支和月干支就都匹配上了
                    if (solarTime.Year >= baseYear)
                    {
                        // 日干支和节令干支的偏移值
                        var d = LunarUtil.GetJiaZiIndex(dayGanZhi) - LunarUtil.GetJiaZiIndex(solarTime.Lunar.DayInGanZhiExact2);
                        if (d < 0)
                        {
                            d += 60;
                        }

                        if (d > 0)
                        {
                            // 从节令推移天数
                            solarTime = solarTime.Next(d);
                        }

                        foreach (var hour in hours)
                        {
                            var mi = 0;
                            var s = 0;
                            if (d == 0 && hour == solarTime.Hour)
                            {
                                // 如果正好是节令当天，且小时和节令的小时数相等的极端情况，把分钟和秒钟带上
                                mi = solarTime.Minute;
                                s = solarTime.Second;
                            }

                            // 验证一下
                            var solar = FromYmdHms(solarTime.Year, solarTime.Month, solarTime.Day, hour, mi, s);
                            var lunar = solar.Lunar;
                            var dgz = (2 == sect) ? lunar.DayInGanZhiExact2 : lunar.DayInGanZhiExact;
                            if (lunar.YearInGanZhiExact.Equals(yearGanZhi) &&
                                lunar.MonthInGanZhiExact.Equals(monthGanZhi) && dgz.Equals(dayGanZhi) &&
                                lunar.TimeInGanZhi.Equals(timeGanZhi))
                            {
                                l.Add(solar);
                            }
                        }
                    }
                }
                y += 60;
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
        public int Week => ((int)(JulianDay + 0.5) + 7000001) % 7;

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
                if (SolarUtil.FESTIVAL.TryGetValue(Month + "-" + Day, out var festival))
                    l.Add(festival);

                //计算几月第几个星期几对应的节日
                var weeks = (int)Math.Ceiling(Day / 7D);
                //星期几，0代表星期天
                if (SolarUtil.WEEK_FESTIVAL.TryGetValue(Month + "-" + weeks + "-" + Week, out var festival2))
                    l.Add(festival2);

                if (Day + 7 <= SolarUtil.GetDaysOfMonth(Year, Month)) return l;
                if (SolarUtil.WEEK_FESTIVAL.TryGetValue(Month + "-0-" + Week, out var festival3))
                    l.Add(festival3);

                return l;
            }
        }

        /// <summary>
        /// 非正式节日
        /// </summary>
        public List<string> OtherFestivals
        {
            get
            {
                var l = new List<string>();
                if (SolarUtil.OTHER_FESTIVAL.TryGetValue(Month + "-" + Day, out var festivals))
                    l.AddRange(festivals);
                return l;
            }
        }

        /// <summary>
        /// 阴历
        /// </summary>
        public Lunar Lunar => new Lunar(this);

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

        /// <inheritdoc />
        public override string ToString()
        {
            return Ymd;
        }

        /// <summary>
        /// yyyy-MM-dd
        /// </summary>
        public string Ymd
        {
            get
            {
                var y = Year + "";
                while (y.Length < 4)
                {
                    y = "0" + y;
                }
                return y + "-" + (Month < 10 ? "0" : "") + Month + "-" + (Day < 10 ? "0" : "") + Day;
            }
        }

        /// <summary>
        /// yyyy-MM-dd HH:mm:ss
        /// </summary>
        public string YmdHms => Ymd + " " + (Hour < 10 ? "0" : "") + Hour + ":" + (Minute < 10 ? "0" : "") + Minute + ":" + (Second < 10 ? "0" : "") + Second;

        /// <summary>
        /// 完整字符串输出
        /// </summary>
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
        /// 阳历日期相减，获得相差天数
        /// </summary>
        /// <param name="solar">阳历</param>
        /// <returns>天数</returns>
        public int Subtract(Solar solar)
        {
            return SolarUtil.GetDaysBetween(solar.Year, solar.Month, solar.Day, Year, Month, Day);
        }

        /// <summary>
        /// 阳历日期相减，获得相差分钟数
        /// </summary>
        /// <param name="solar">阳历</param>
        /// <returns>分钟数</returns>
        public int SubtractMinute(Solar solar)
        {
            var days = Subtract(solar);
            var cm = Hour * 60 + Minute;
            var sm = solar.Hour * 60 + solar.Minute;
            var m = cm - sm;
            if (m < 0)
            {
                m += 1440;
                days--;
            }
            m += days * 1440;
            return m;
        }

        /// <summary>
        /// 是否在指定日期之后
        /// </summary>
        /// <param name="solar">阳历</param>
        /// <returns>true/false</returns>
        public bool IsAfter(Solar solar)
        {
            if (Year > solar.Year)
            {
                return true;
            }
            if (Year < solar.Year)
            {
                return false;
            }
            if (Month > solar.Month)
            {
                return true;
            }
            if (Month < solar.Month)
            {
                return false;
            }
            if (Day > solar.Day)
            {
                return true;
            }
            if (Day < solar.Day)
            {
                return false;
            }
            if (Hour > solar.Hour)
            {
                return true;
            }
            if (Hour < solar.Hour)
            {
                return false;
            }
            if (Minute > solar.Minute)
            {
                return true;
            }
            if (Minute < solar.Minute)
            {
                return false;
            }
            return Second > solar.Second;
        }

        /// <summary>
        /// 是否在指定日期之前
        /// </summary>
        /// <param name="solar">阳历</param>
        /// <returns>true/false</returns>
        public bool IsBefore(Solar solar)
        {
            if (Year > solar.Year)
            {
                return false;
            }
            if (Year < solar.Year)
            {
                return true;
            }
            if (Month > solar.Month)
            {
                return false;
            }
            if (Month < solar.Month)
            {
                return true;
            }
            if (Day > solar.Day)
            {
                return false;
            }
            if (Day < solar.Day)
            {
                return true;
            }
            if (Hour > solar.Hour)
            {
                return false;
            }
            if (Hour < solar.Hour)
            {
                return true;
            }
            if (Minute > solar.Minute)
            {
                return false;
            }
            if (Minute < solar.Minute)
            {
                return true;
            }
            return Second < solar.Second;
        }

        /// <summary>
        /// 年推移
        /// </summary>
        /// <param name="years">年数</param>
        /// <returns>阳历</returns>
        public Solar NextYear(int years)
        {
            var y = Year + years;
            var m = Month;
            var d = Day;
            if (1582 == y && 10 == m)
            {
                if (d > 4 && d < 15)
                {
                    d += 10;
                }
            }
            else if (2 == m)
            {
                if (d > 28)
                {
                    if (!SolarUtil.IsLeapYear(y))
                    {
                        d = 28;
                    }
                }
            }
            return new Solar(y, m, d, Hour, Minute, Second);
        }

        /// <summary>
        /// 月推移
        /// </summary>
        /// <param name="months">月数</param>
        /// <returns>阳历</returns>
        public Solar NextMonth(int months)
        {
            var month = SolarMonth.FromYm(Year, Month).Next(months);
            var y = month.Year;
            var m = month.Month;
            var d = Day;
            if (1582 == y && 10 == m)
            {
                if (d > 4 && d < 15)
                {
                    d += 10;
                }
            }
            else
            {
                var maxDay = SolarUtil.GetDaysOfMonth(y, m);
                if (d > maxDay)
                {
                    d = maxDay;
                }
            }
            return new Solar(y, m, d, Hour, Minute, Second);
        }

        /// <summary>
        /// 日推移
        /// </summary>
        /// <param name="days">天数</param>
        /// <returns>阳历</returns>
        public Solar NextDay(int days)
        {
            var y = Year;
            var m = Month;
            var d = Day;
            if (1582 == y && 10 == m)
            {
                if (d > 4)
                {
                    d -= 10;
                }
            }
            if (days > 0)
            {
                d += days;
                var daysInMonth = SolarUtil.GetDaysOfMonth(y, m);
                while (d > daysInMonth)
                {
                    d -= daysInMonth;
                    m++;
                    if (m > 12)
                    {
                        m = 1;
                        y++;
                    }
                    daysInMonth = SolarUtil.GetDaysOfMonth(y, m);
                }
            }
            else if (days < 0)
            {
                while (d + days <= 0)
                {
                    m--;
                    if (m < 1)
                    {
                        m = 12;
                        y--;
                    }
                    d += SolarUtil.GetDaysOfMonth(y, m);
                }
                d += days;
            }
            if (1582 == y && 10 == m)
            {
                if (d > 4)
                {
                    d += 10;
                }
            }
            return new Solar(y, m, d, Hour, Minute, Second);
        }

        /// <summary>
        /// 获取往后推几天的阳历日期，如果要往前推，则天数用负数
        /// </summary>
        /// <param name="days">天数</param>
        /// <param name="onlyWorkday">是否仅工作日</param>
        /// <returns>阳历日期</returns>
        public Solar Next(int days, bool onlyWorkday = false)
        {
            if (!onlyWorkday)
            {
                return NextDay(days);
            }
            var solar = new Solar(Year, Month, Day, Hour, Minute, Second);
            if (days != 0)
            {
                var rest = Math.Abs(days);
                var add = days < 0 ? -1 : 1;
                while (rest > 0)
                {
                    solar = solar.Next(add);
                    var work = true;
                    var holiday = HolidayUtil.GetHoliday(solar.Year, solar.Month, solar.Day);
                    if (null == holiday)
                    {
                        var week = solar.Week;
                        if (0 == week || 6 == week)
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
                        rest -= 1;
                    }
                }
            }
            return solar;
        }

        /// <summary>
        /// 小时推移
        /// </summary>
        /// <param name="hours">小时数</param>
        /// <returns>阳历</returns>
        public Solar NextHour(int hours)
        {
            var h = Hour + hours;
            var n = h < 0 ? -1 : 1;
            var hour = Math.Abs(h);
            var days = hour / 24 * n;
            hour = (hour % 24) * n;
            if (hour < 0)
            {
                hour += 24;
                days--;
            }
            var solar = Next(days);
            return new Solar(solar.Year, solar.Month, solar.Day, hour, solar.Minute, solar.Second);
        }

        /// <summary>
        /// 获取薪资比例(感谢 https://gitee.com/smr1987)
        /// </summary>
        /// <returns>薪资比例：1/2/3</returns>
        public int GetSalaryRate()
        {
            switch (Month)
            {
                // 元旦节
                case 1 when Day == 1:
                // 劳动节
                case 5 when Day == 1:
                // 国庆
                case 10 when Day >= 1 && Day <= 3:
                    return 3;
            }

            var lunarMonth = Lunar.Month;
            var lunarDay = Lunar.Day;
            switch (lunarMonth)
            {
                // 春节
                case 1 when lunarDay >= 1 && lunarDay <= 3:
                // 端午
                case 5 when lunarDay == 5:
                // 中秋
                case 8 when lunarDay == 15:
                    return 3;
            }

            // 清明
            if ("清明".Equals(Lunar.JieQi))
            {
                return 3;
            }
            var holiday = HolidayUtil.GetHoliday(Year, Month, Day);
            if (null != holiday)
            {
                // 法定假日非上班
                if (!holiday.Work)
                {
                    return 2;
                }
            }
            else
            {
                // 周末
                var week = Week;
                if (week == 6 || week == 0)
                {
                    return 2;
                }
            }
            // 工作日
            return 1;
        }
    }
}