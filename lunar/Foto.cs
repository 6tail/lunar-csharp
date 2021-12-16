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

        /// <summary>
        /// 获取星宿
        /// </summary>
        /// <returns>星宿</returns>
        public string getXiu()
        {
            return FotoUtil.getXiu(getMonth(), getDay());
        }

        /// <summary>
        /// 获取宿吉凶
        /// </summary>
        /// <returns>吉凶</returns>
        public string getXiuLuck()
        {
            return LunarUtil.XIU_LUCK[getXiu()];
        }

        /// <summary>
        /// 获取宿歌诀
        /// </summary>
        /// <returns>星宿歌诀</returns>
        public string getXiuSong()
        {
            return LunarUtil.XIU_SONG[getXiu()];
        }

        /// <summary>
        /// 获取政
        /// </summary>
        /// <returns>政</returns>
        public string getZheng()
        {
            return LunarUtil.ZHENG[getXiu()];
        }

        /// <summary>
        /// 获取动物
        /// </summary>
        /// <returns>动物</returns>
        public string getAnimal()
        {
            return LunarUtil.ANIMAL[getXiu()];
        }

        /// <summary>
        /// 获取宫
        /// </summary>
        /// <returns>宫</returns>
        public string getGong()
        {
            return LunarUtil.GONG[getXiu()];
        }

        /// <summary>
        /// 获取兽
        /// </summary>
        /// <returns>兽</returns>
        public string getShou()
        {
            return LunarUtil.SHOU[getGong()];
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
