using System.Collections.Generic;
using System.Text;
using Lunar.Util;
using System;
using System.Linq;
// ReSharper disable InconsistentNaming
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable IdentifierTypo

namespace Lunar
{
    /// <summary>
    /// 道历
    /// </summary>
    public sealed class Tao
    {
        /// <summary>
        /// 道历元年
        /// </summary>
        public const int BIRTH_YEAR = -2697;

        /// <summary>
        /// 阴历
        /// </summary>
        private Lunar Lunar { get; }

        /// <summary>
        /// 从农历创建道历
        /// </summary>
        /// <param name="lunar">农历</param>
        public Tao(Lunar lunar)
        {
            Lunar = lunar;
        }

        /// <summary>
        /// 从农历创建道历
        /// </summary>
        /// <param name="lunar">农历</param>
        /// <returns>道历</returns>
        public static Tao FromLunar(Lunar lunar)
        {
            return new Tao(lunar);
        }

        /// <summary>
        /// 通过指定道历年月日时分秒获取道历
        /// </summary>
        /// <param name="year">年（道历）</param>
        /// <param name="month">月（农历），1到12，闰月为负，即闰2月=-2</param>
        /// <param name="day">日（农历），1到31</param>
        /// <param name="hour">小时（阳历）</param>
        /// <param name="minute">分钟（阳历）</param>
        /// <param name="second">秒钟（阳历）</param>
        /// <returns>道历</returns>
        public static Tao FromYmdHms(int year, int month, int day, int hour = 0, int minute = 0, int second = 0)
        {
            return FromLunar(Lunar.FromYmdHms(year + BIRTH_YEAR, month, day, hour, minute, second));
        }

        /// <summary>
        /// 年
        /// </summary>
        public int Year => Lunar.Year - BIRTH_YEAR;

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
                var y = (Year + "").ToCharArray();
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
        /// 节日
        /// </summary>
        public List<TaoFestival> Festivals
        {
            get
            {
                var l = new List<TaoFestival>();
                try
                {
                    l.AddRange(TaoUtil.FESTIVAL[Month + "-" + Day]);
                }
                catch
                {
                    // ignored
                }

                var jq = Lunar.JieQi;
                switch (jq)
                {
                    case "冬至":
                        l.Add(new TaoFestival("元始天尊圣诞"));
                        break;
                    case "夏至":
                        l.Add(new TaoFestival("灵宝天尊圣诞"));
                        break;
                }

                // 八节日
                try
                {
                    l.Add(new TaoFestival(TaoUtil.BA_JIE[jq]));
                }
                catch
                {
                    // ignored
                }

                // 八会日
                try
                {
                    l.Add(new TaoFestival(TaoUtil.BA_HUI[Lunar.DayInGanZhi]));
                }
                catch
                {
                    // ignored
                }

                return l;
            }
        }

        private bool IsDayIn(string[] days)
        {
            var md = Month + "-" + Day;
            return days.Any(d => md.Equals(d));
        }

        /// <summary>
        /// 是否三会日
        /// </summary>
        public bool DaySanHui => IsDayIn(TaoUtil.SAN_HUI);

        /// <summary>
        /// 是否三元日
        /// </summary>
        public bool DaySanYuan => IsDayIn(TaoUtil.SAN_YUAN);

        /// <summary>
        /// 是否五腊日
        /// </summary>
        public bool DayWuLa => IsDayIn(TaoUtil.WU_LA);

        /// <summary>
        /// 是否八节日
        /// </summary>
        public bool DayBaJie => TaoUtil.BA_JIE.ContainsKey(Lunar.JieQi);

        /// <summary>
        /// 是否八会日
        /// </summary>
        public bool DayBaHui => TaoUtil.BA_HUI.ContainsKey(Lunar.DayInGanZhi);

        /// <summary>
        /// 是否明戊日
        /// </summary>
        public bool DayMingWu => "戊".Equals(Lunar.DayGan);

        /// <summary>
        /// 是否暗戊日
        /// </summary>
        public bool DayAnWu => Lunar.DayZhi.Equals(TaoUtil.AN_WU[Math.Abs(Month) - 1]);

        /// <summary>
        /// 是否戊日
        /// </summary>
        public bool DayWu => DayMingWu || DayAnWu;

        /// <summary>
        /// 是否天赦日
        /// </summary>
        public bool DayTianShe
        {
            get
            {
                var ret = false;
                var mz = Lunar.MonthZhi;
                var dgz = Lunar.DayInGanZhi;
                if ("寅卯辰".Contains(mz))
                {
                    if ("戊寅".Equals(dgz))
                    {
                        ret = true;
                    }
                }
                else if ("巳午未".Contains(mz))
                {
                    if ("甲午".Equals(dgz))
                    {
                        ret = true;
                    }
                }
                else if ("申酉戌".Contains(mz))
                {
                    if ("戊申".Equals(dgz))
                    {
                        ret = true;
                    }
                }
                else if ("亥子丑".Contains(mz))
                {
                    if ("甲子".Equals(dgz))
                    {
                        ret = true;
                    }
                }

                return ret;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string FullString => "道歷" + YearInChinese + "年，天運" + Lunar.YearInGanZhi + "年，" + Lunar.MonthInGanZhi + "月，" + Lunar.DayInGanZhi + "日。" + MonthInChinese + "月" + DayInChinese + "日，" + Lunar.TimeZhi + "時。";

        /// <inheritdoc />
        public override string ToString()
        {
            return YearInChinese + "年" + MonthInChinese + "月" + DayInChinese;
        }
    }

}
