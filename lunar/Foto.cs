using System.Collections.Generic;
using System.Text;
using com.nlf.calendar.util;
namespace com.nlf.calendar
{
    /// <summary>
    /// 佛历
    /// </summary>
    public class Foto
    {
        public const int DEAD_YEAR = -543;

        /// <summary>
        /// 阴历
        /// </summary>
        private Lunar lunar;

        public Foto(Lunar lunar)
        {
            this.lunar = lunar;
        }

        public static Foto fromLunar(Lunar lunar)
        {
            return new Foto(lunar);
        }

        public static Foto fromYmdHms(int lunarYear, int lunarMonth, int lunarDay, int hour, int minute, int second)
        {
            return Foto.fromLunar(Lunar.fromYmdHms(lunarYear + DEAD_YEAR - 1, lunarMonth, lunarDay, hour, minute, second));
        }

        public static Foto fromYmd(int lunarYear, int lunarMonth, int lunarDay)
        {
            return fromYmdHms(lunarYear, lunarMonth, lunarDay, 0, 0, 0);
        }

        public Lunar getLunar()
        {
            return lunar;
        }

        public int getYear()
        {
            int sy = lunar.getSolar().getYear();
            int y = sy - DEAD_YEAR;
            if (sy == lunar.getYear())
            {
                y++;
            }
            return y;
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

        public List<FotoFestival> getFestivals()
        {
            List<FotoFestival> l = new List<FotoFestival>();
            try
            {
                l.AddRange(FotoUtil.FESTIVAL[getMonth() + "-" + getDay()]);
             }
            catch { }
            return l;
        }

        public bool isMonthZhai()
        {
            int m = getMonth();
            return 1 == m || 5 == m || 9 == m;
        }

        public bool isDayYangGong()
        {
            foreach (FotoFestival f in getFestivals())
            {
                if ("杨公忌".Equals(f.getName()))
                {
                    return true;
                }
            }
            return false;
        }

        public bool isDayZhaiShuoWang()
        {
            int d = getDay();
            return 1 == d || 15 == d;
        }

        public bool isDayZhaiSix()
        {
            int d = getDay();
            if (8 == d || 14 == d || 15 == d || 23 == d || 29 == d || 30 == d)
            {
                return true;
            }
            else if (28 == d)
            {
                LunarMonth m = LunarMonth.fromYm(lunar.getYear(), getMonth());
                return null != m && 30 != m.getDayCount();
            }
            return false;
        }

        public bool isDayZhaiTen()
        {
            int d = getDay();
            return 1 == d || 8 == d || 14 == d || 15 == d || 18 == d || 23 == d || 24 == d || 28 == d || 29 == d || 30 == d;
        }

        public bool isDayZhaiGuanYin()
        {
            string k = getMonth() + "-" + getDay();
            foreach (string d in FotoUtil.DAY_ZHAI_GUAN_YIN)
            {
                if (k.Equals(d))
                {
                    return true;
                }
            }
            return false;
        }

        public string toString()
        {
            return getYearInChinese() + "年" + getMonthInChinese() + "月" + getDayInChinese();
        }

        public string toFullString()
        {
            StringBuilder s = new StringBuilder();
            s.Append(toString());
            foreach (FotoFestival f in getFestivals())
            {
                s.Append(" (");
                s.Append(f);
                s.Append(")");
            }
            return s.ToString();
        }

        public override string ToString()
        {
            return toString();
        }
    }

}
