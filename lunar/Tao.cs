using System.Collections.Generic;
using System.Text;
using com.nlf.calendar.util;
namespace com.nlf.calendar
{
    /// <summary>
    /// 道历
    /// </summary>
    public class Tao
    {
        public const int BIRTH_YEAR = -2697;

        /// <summary>
        /// 阴历
        /// </summary>
        private Lunar lunar;

        public Tao(Lunar lunar)
        {
            this.lunar = lunar;
        }

        public static Tao fromLunar(Lunar lunar)
        {
            return new Tao(lunar);
        }

        public static Tao fromYmdHms(int year, int month, int day, int hour, int minute, int second)
        {
            return Tao.fromLunar(Lunar.fromYmdHms(year + BIRTH_YEAR, month, day, hour, minute, second));
        }

        public static Tao fromYmd(int year, int month, int day)
        {
            return fromYmdHms(year, month, day, 0, 0, 0);
        }

        public Lunar getLunar()
        {
            return lunar;
        }

        public int getYear()
        {
            return lunar.getYear() - BIRTH_YEAR;
        }

        public int getMonth()
        {
            return lunar.getMonth();
        }

        public int getDay()
        {
            return lunar.getDay();
        }

        public string getYearInChinese()
        {
            char[] y = (getYear() + "").ToCharArray();
            StringBuilder s = new StringBuilder();
            for (int i = 0, j = y.Length; i < j; i++)
            {
                s.Append(LunarUtil.NUMBER[y[i] - '0']);
            }
            return s.ToString();
        }

        public string getMonthInChinese()
        {
            return lunar.getMonthInChinese();
        }

        public string getDayInChinese()
        {
            return lunar.getDayInChinese();
        }

        public List<TaoFestival> getFestivals()
        {
            List<TaoFestival> l = new List<TaoFestival>();
            try
            {
                l.AddRange(TaoUtil.FESTIVAL[getMonth() + "-" + getDay()]);
            }
            catch { }
            string jq = lunar.getJieQi();
            if ("冬至".Equals(jq))
            {
                l.Add(new TaoFestival("元始天尊圣诞"));
            }
            else if ("夏至".Equals(jq))
            {
                l.Add(new TaoFestival("灵宝天尊圣诞"));
            }
            // 八节日
            try
            {
                l.Add(new TaoFestival(TaoUtil.BA_JIE[jq]));
            }
            catch { }
            // 八会日
            try
            {
                l.Add(new TaoFestival(TaoUtil.BA_HUI[lunar.getDayInGanZhi()]));
            }
            catch { }
            return l;
        }

        private bool isDayIn(string[] days)
        {
            string md = getMonth() + "-" + getDay();
            foreach (string d in days)
            {
                if (md.Equals(d))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 是否三会日
        /// </summary>
        /// <returns>true/false</returns>
        public bool isDaySanHui()
        {
            return isDayIn(TaoUtil.SAN_HUI);
        }

        /// <summary>
        /// 是否三元日
        /// </summary>
        /// <returns>true/false</returns>
        public bool isDaySanYuan()
        {
            return isDayIn(TaoUtil.SAN_YUAN);
        }

        /// <summary>
        /// 是否五腊日
        /// </summary>
        /// <returns>true/false</returns>
        public bool isDayWuLa()
        {
            return isDayIn(TaoUtil.WU_LA);
        }

        /// <summary>
        /// 是否八节日
        /// </summary>
        /// <returns>true/false</returns>
        public bool isDayBaJie()
        {
            return TaoUtil.BA_JIE.ContainsKey(lunar.getJieQi());
        }

        /// <summary>
        /// 是否八会日
        /// </summary>
        /// <returns>true/false</returns>
        public bool isDayBaHui()
        {
            return TaoUtil.BA_HUI.ContainsKey(lunar.getDayInGanZhi());
        }

        public string toString()
        {
            return getYearInChinese() + "年" + getMonthInChinese() + "月" + getDayInChinese();
        }

        public string toFullString()
        {
            return "道歷" + getYearInChinese() + "年，天運" + lunar.getYearInGanZhi() + "年，" + lunar.getMonthInGanZhi() + "月，" + lunar.getDayInGanZhi() + "日。" + getMonthInChinese() + "月" + getDayInChinese() + "日，" + lunar.getTimeZhi() + "時。";
        }

        public override string ToString()
        {
            return toString();
        }
    }

}
