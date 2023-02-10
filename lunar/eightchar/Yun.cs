using Lunar.Util;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Lunar.EightChar
{
    /// <summary>
    /// 运
    /// </summary>
    public class Yun
    {
        /// <summary>
        /// 性别(1男，0女)
        /// </summary>
        public int Gender { get; }

        /// <summary>
        /// 起运年数
        /// </summary>
        public int StartYear { get; }

        /// <summary>
        /// 起运月数
        /// </summary>
        public int StartMonth { get; }

        /// <summary>
        /// 起运天数
        /// </summary>
        public int StartDay { get; }

        /// <summary>
        /// 起运小时
        /// </summary>
        public int StartHour { get; }

        /// <summary>
        /// 是否顺推
        /// </summary>
        public bool Forward { get; }

        public Lunar Lunar { get; }

        public Yun(EightChar eightChar, int gender, int sect = 1)
        {
            Lunar = eightChar.Lunar;
            Gender = gender;
            var yang = 0 == Lunar.YearGanIndexExact % 2;
            var man = 1 == gender;
            Forward = (yang && man) || (!yang && !man);
            
            // 起运计算
            var prev = Lunar.GetPrevJie();
            var next = Lunar.GetNextJie();
            var current = Lunar.Solar;
            var start = Forward ? current : prev.Solar;
            var end = Forward ? next.Solar : current;

            int year;
            int month;
            int day;
            var hour = 0;

            if (2 == sect)
            {
                var minutes = end.SubtractMinute(start);
                var y = minutes / 4320;
                minutes -= y * 4320;
                var m = minutes / 360;
                minutes -= m * 360;
                var d = minutes / 12;
                minutes -= d * 12;
                var h = minutes * 2;
                year = y;
                month = m;
                day = d;
                hour = h;
            }
            else
            {
                var endTimeZhiIndex = (end.Hour == 23) ? 11 : LunarUtil.GetTimeZhiIndex(end.YmdHms.Substring(11, 5));
                var startTimeZhiIndex = (start.Hour == 23) ? 11 : LunarUtil.GetTimeZhiIndex(start.YmdHms.Substring(11, 5));
                // 时辰差
                var hourDiff = endTimeZhiIndex - startTimeZhiIndex;
                var dayDiff = end.Subtract(start);
                if (hourDiff < 0)
                {
                    hourDiff += 12;
                    dayDiff--;
                }
                var monthDiff = hourDiff * 10 / 30;
                month = dayDiff * 4 + monthDiff;
                day = hourDiff * 10 - monthDiff * 30;
                year = month / 12;
                month = month - year * 12;
            }          
            StartYear = year;
            StartMonth = month;
            StartDay = day;
            StartHour = hour;
        }

        /// <summary>
        /// 获取起运的阳历日期
        /// </summary>
        /// <returns>阳历日期</returns>
        public Solar StartSolar
        {
            get
            {
                var solar = Lunar.Solar;
                solar = solar.NextYear(StartYear);
                solar = solar.NextMonth(StartMonth);
                solar = solar.Next(StartDay);
                return solar.NextHour(StartHour);
            }
        }

        /// <summary>
        /// 获取大运
        /// </summary>
        /// <param name="n">轮数</param>
        /// <returns>大运</returns>
        public DaYun[] GetDaYun(int n = 10)
        {
            var l = new DaYun[n];
            for (var i = 0; i < n; i++)
            {
                l[i] = new DaYun(this, i);
            }
            return l;
        }
    }

}
