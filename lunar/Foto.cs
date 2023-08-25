using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lunar.Util;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable MemberCanBePrivate.Global

namespace Lunar
{
    /// <summary>
    /// 佛历
    /// </summary>
    public class Foto
    {
        /// <summary>
        /// 佛涅磐年
        /// </summary>
        public const int DEAD_YEAR = -543;

        /// <summary>
        /// 阴历
        /// </summary>
        public Lunar Lunar { get; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="lunar">阴历</param>
        public Foto(Lunar lunar)
        {
            Lunar = lunar;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="lunar">阴历</param>
        /// <returns>佛历</returns>
        public static Foto FromLunar(Lunar lunar)
        {
            return new Foto(lunar);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="lunarYear">阴历年</param>
        /// <param name="lunarMonth">阴历月</param>
        /// <param name="lunarDay">阴历日</param>
        /// <param name="hour">小时</param>
        /// <param name="minute">分钟</param>
        /// <param name="second">秒钟</param>
        /// <returns>佛历</returns>
        public static Foto FromYmdHms(int lunarYear, int lunarMonth, int lunarDay, int hour = 0, int minute = 0, int second = 0)
        {
            return FromLunar(Lunar.FromYmdHms(lunarYear + DEAD_YEAR - 1, lunarMonth, lunarDay, hour, minute, second));
        }

        /// <summary>
        /// 年
        /// </summary>
        public int Year
        {
            get
            {
                var sy = Lunar.Solar.Year;
                var y = sy - DEAD_YEAR;
                if (sy == Lunar.Year)
                {
                    y++;
                }
                return y;
            }
        }

        /// <summary>
        /// 月
        /// </summary>
        public int Month => Lunar.Month;

        /// <summary>
        /// 日
        /// </summary>
        public int Day => Lunar.Day;

        /// <summary>
        /// 中文年
        /// </summary>
        public string YearInChinese
        {
            get
            {
                var y = Year.ToString().ToCharArray();
                var s = new StringBuilder();
                for (int i = 0, j = y.Length; i < j; i++)
                {
                    s.Append(LunarUtil.NUMBER[y[i] - '0']);
                }
                return s.ToString();
            }
        }

        /// <summary>
        /// 中文月
        /// </summary>
        public string MonthInChinese => Lunar.MonthInChinese;

        /// <summary>
        /// 中文日
        /// </summary>
        public string DayInChinese => Lunar.DayInChinese;

        /// <summary>
        /// 因果犯忌
        /// </summary>
        public List<FotoFestival> Festivals
        {
            get
            {
                var l = new List<FotoFestival>();
                try
                {
                    l.AddRange(FotoUtil.FESTIVAL[Math.Abs(Month) + "-" + Day]);
                }
                catch
                {
                    // ignored
                }

                return l;
            }
        }
        
        /// <summary>
        /// 纪念日
        /// </summary>
        public List<string> OtherFestivals
        {
            get
            {
                var l = new List<string>();
                try
                {
                    var fs = FotoUtil.OTHER_FESTIVAL[$"{Month}-{Day}"];
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
        /// 月斋
        /// </summary>
        public bool MonthZhai => Month == 1 || Month == 5 || Month == 9;

        /// <summary>
        /// 杨公忌日
        /// </summary>
        public bool DayYangGong
        {
            get
            {
                return Festivals.Any(f => "杨公忌".Equals(f.Name));
            }
        }

        /// <summary>
        /// 朔望斋日
        /// </summary>
        public bool DayZhaiShuoWang => Day == 1 || Day == 15;

        /// <summary>
        /// 六斋日
        /// </summary>
        public bool DayZhaiSix
        {
            get
            {
                switch (Day)
                {
                    case 8:
                    case 14:
                    case 15:
                    case 23:
                    case 29:
                    case 30:
                        return true;
                    case 28:
                    {
                        var m = LunarMonth.FromYm(Lunar.Year, Month);
                        return null != m && 30 != m.DayCount;
                    }
                    default:
                        return false;
                }
            }
        }

        /// <summary>
        /// 十斋日
        /// </summary>
        public bool DayZhaiTen => Day == 1 || Day == 8  || Day == 14  || Day == 15  || Day == 18  || Day == 23  || Day == 24  || Day == 28  || Day == 29  || Day == 30;

        /// <summary>
        /// 观音斋日
        /// </summary>
        public bool DayZhaiGuanYin
        {
            get
            {
                var k = $"{Month}-{Day}";
                return FotoUtil.DAY_ZHAI_GUAN_YIN.Any(d => k.Equals(d));
            }
        }

        /// <summary>
        /// 宿
        /// </summary>
        public string Xiu => FotoUtil.GetXiu(Month, Day);

        /// <summary>
        /// 宿吉凶
        /// </summary>
        public string XiuLuck => LunarUtil.XIU_LUCK[Xiu];

        /// <summary>
        /// 宿歌诀
        /// </summary>
        public string XiuSong => LunarUtil.XIU_SONG[Xiu];

        /// <summary>
        /// 政
        /// </summary>
        public string Zheng => LunarUtil.ZHENG[Xiu];

        /// <summary>
        /// 动物
        /// </summary>
        public string Animal => LunarUtil.ANIMAL[Xiu];

        /// <summary>
        /// 宫
        /// </summary>
        public string Gong => LunarUtil.GONG[Xiu];

        /// <summary>
        /// 兽
        /// </summary>
        public string Shou => LunarUtil.SHOU[Gong];

        /// <summary>
        /// 完整字符串输出
        /// </summary>
        public string FullString
        {
            get
            {
                var s = new StringBuilder();
                s.Append(ToString());
                foreach (var f in Festivals)
                {
                    s.Append(" (");
                    s.Append(f);
                    s.Append(')');
                }
                return s.ToString();
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{YearInChinese}年{MonthInChinese}月{DayInChinese}";
        }
    }

}
