using System.Collections.Generic;
using System.Linq;
using Lunar.Util;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable MemberCanBePrivate.Global

namespace Lunar.EightChar
{
    /// <summary>
    /// 八字
    /// </summary>
    public class EightChar
    {
        /// <summary>
        /// 月支，按正月起寅排列
        /// </summary>
        public static readonly string[] MONTH_ZHI = { "", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥", "子", "丑" };
        
        /// <summary>
        /// 长生十二神
        /// </summary>
        public static readonly string[] CHANG_SHENG = { "长生", "沐浴", "冠带", "临官", "帝旺", "衰", "病", "死", "墓", "绝", "胎", "养" };
        
        private static readonly Dictionary<string, int> CHANG_SHENG_OFFSET = new Dictionary<string, int>();

        static EightChar()
        {
            //阳
            CHANG_SHENG_OFFSET.Add("甲", 1);
            CHANG_SHENG_OFFSET.Add("丙", 10);
            CHANG_SHENG_OFFSET.Add("戊", 10);
            CHANG_SHENG_OFFSET.Add("庚", 7);
            CHANG_SHENG_OFFSET.Add("壬", 4);
            //阴
            CHANG_SHENG_OFFSET.Add("乙", 6);
            CHANG_SHENG_OFFSET.Add("丁", 9);
            CHANG_SHENG_OFFSET.Add("己", 9);
            CHANG_SHENG_OFFSET.Add("辛", 0);
            CHANG_SHENG_OFFSET.Add("癸", 3);
        }

        private int _sect = 2;

        /// <summary>
        /// 流派，2晚子时日柱按当天，1晚子时日柱按明天
        /// </summary>
        public int Sect
        {
            set => _sect = (1 == value) ? 1 : 2;
            get => _sect;
        }

        /// <summary>
        /// 阴历
        /// </summary>
        public Lunar Lunar { get; }

        public EightChar(Lunar lunar)
        {
            Lunar = lunar;
        }

        public static EightChar FromLunar(Lunar lunar)
        {
            return new EightChar(lunar);
        }

        public override string ToString()
        {
            return Year + " " + Month + " " + Day + " " + Time;
        }

        /// <summary>
        /// 年柱
        /// </summary>
        public string Year => Lunar.YearInGanZhiExact;

        /// <summary>
        /// 年天干
        /// </summary>
        public string YearGan => Lunar.YearGanExact;

        /// <summary>
        /// 年地支
        /// </summary>
        public string YearZhi => Lunar.YearZhiExact;

        /// <summary>
        /// 年藏干
        /// </summary>
        public List<string> YearHideGan => LunarUtil.ZHI_HIDE_GAN[YearZhi];

        /// <summary>
        /// 年五行
        /// </summary>
        public string YearWuXing => LunarUtil.WU_XING_GAN[YearGan] + LunarUtil.WU_XING_ZHI[YearZhi];

        /// <summary>
        /// 年纳音
        /// </summary>
        public string YearNaYin => LunarUtil.NAYIN[Year];

        /// <summary>
        /// 年天干十神
        /// </summary>
        public string YearShiShenGan => LunarUtil.SHI_SHEN_GAN[DayGan + YearGan];

        private List<string> GetShiShenZhi(string zhi)
        {
            var hideGan = LunarUtil.ZHI_HIDE_GAN[zhi];
            var l = new List<string>(hideGan.Count);
            l.AddRange(hideGan.Select(gan => LunarUtil.SHI_SHEN_ZHI[DayGan + zhi + gan]));
            return l;
        }

        public List<string> YearShiShenZhi => GetShiShenZhi(YearZhi);

        public int DayGanIndex =>  (2 == Sect) ? Lunar.DayGanIndexExact2 : Lunar.DayGanIndexExact;

        public int DayZhiIndex => (2 == Sect) ? Lunar.DayZhiIndexExact2 : Lunar.DayZhiIndexExact;

        private string GetDiShi(int zhiIndex)
        {
            var offset = CHANG_SHENG_OFFSET[DayGan];
            var index = offset + (DayGanIndex % 2 == 0 ? zhiIndex : -zhiIndex);
            if (index >= 12)
            {
                index -= 12;
            }
            if (index < 0)
            {
                index += 12;
            }
            return CHANG_SHENG[index];
        }

        public string YearDiShi => GetDiShi(Lunar.YearZhiIndexExact);

        public string Month => Lunar.MonthInGanZhiExact;

        public string MonthGan => Lunar.MonthGanExact;

        public string MonthZhi => Lunar.MonthZhiExact;

        public List<string> MonthHideGan => LunarUtil.ZHI_HIDE_GAN[MonthZhi];

        public string MonthWuXing => LunarUtil.WU_XING_GAN[MonthGan] + LunarUtil.WU_XING_ZHI[MonthZhi];

        public string MonthNaYin => LunarUtil.NAYIN[Month];

        public string MonthShiShenGan => LunarUtil.SHI_SHEN_GAN[DayGan + MonthGan];

        public List<string> MonthShiShenZhi => GetShiShenZhi(MonthZhi);

        public string MonthDiShi => GetDiShi(Lunar.MonthZhiIndexExact);

        public string Day => (2 == Sect) ? Lunar.DayInGanZhiExact2 : Lunar.DayInGanZhiExact;

        public string DayGan => (2 == Sect) ? Lunar.DayGanExact2 : Lunar.DayGanExact;

        public string DayZhi => (2 == Sect) ? Lunar.DayZhiExact2 : Lunar.DayZhiExact;

        public List<string> DayHideGan => LunarUtil.ZHI_HIDE_GAN[DayZhi];

        public string DayWuXing => LunarUtil.WU_XING_GAN[DayGan] + LunarUtil.WU_XING_ZHI[DayZhi];

        public string DayNaYin => LunarUtil.NAYIN[Day];

        public string DayShiShenGan => "日主";

        public List<string> DayShiShenZhi => GetShiShenZhi(DayZhi);

        public string DayDiShi => GetDiShi(DayZhiIndex);

        public string Time => Lunar.TimeInGanZhi;

        public string TimeGan => Lunar.TimeGan;

        public string TimeZhi => Lunar.TimeZhi;

        public List<string> TimeHideGan => LunarUtil.ZHI_HIDE_GAN[TimeZhi];

        public string TimeWuXing => LunarUtil.WU_XING_GAN[Lunar.TimeGan] + LunarUtil.WU_XING_ZHI[Lunar.TimeZhi];

        public string TimeNaYin => LunarUtil.NAYIN[Time];

        public string TimeShiShenGan => LunarUtil.SHI_SHEN_GAN[DayGan + TimeGan];

        public List<string> TimeShiShenZhi => GetShiShenZhi(TimeZhi);

        public string TimeDiShi => GetDiShi(Lunar.TimeZhiIndex);

        public string TaiYuan
        {
            get
            {
                var ganIndex = Lunar.MonthGanIndexExact + 1;
                if (ganIndex >= 10)
                {
                    ganIndex -= 10;
                }
                var zhiIndex = Lunar.MonthZhiIndexExact + 3;
                if (zhiIndex >= 12)
                {
                    zhiIndex -= 12;
                }
                return LunarUtil.GAN[ganIndex + 1] + LunarUtil.ZHI[zhiIndex + 1];
            }
        }

        public string TaiYuanNaYin => LunarUtil.NAYIN[TaiYuan];

        public string TaiXi
        {
            get
            {
                var ganIndex = 2 == Sect ? Lunar.DayGanIndexExact2 : Lunar.DayGanIndexExact;
                var zhiIndex = 2 == Sect ? Lunar.DayZhiIndexExact2 : Lunar.DayZhiIndexExact;
                return LunarUtil.HE_GAN_5[ganIndex] + LunarUtil.HE_ZHI_6[zhiIndex];
            }
        }

        public string TaiXiNaYin => LunarUtil.NAYIN[TaiXi];

        /// <summary>
        /// 命宫
        /// </summary>
        public string MingGong
        {
            get
            {
                var monthZhiIndex = 0;
                var timeZhiIndex = 0;
                for (int i = 0, j = MONTH_ZHI.Length; i < j; i++)
                {
                    var zhi = MONTH_ZHI[i];
                    if (Lunar.MonthZhiExact.Equals(zhi))
                    {
                        monthZhiIndex = i;
                    }
                    if (Lunar.TimeZhi.Equals(zhi))
                    {
                        timeZhiIndex = i;
                    }
                }
                var zhiIndex = 26 - (monthZhiIndex + timeZhiIndex);
                if (zhiIndex > 12)
                {
                    zhiIndex -= 12;
                }
                var jiaZiIndex = LunarUtil.GetJiaZiIndex(Lunar.MonthInGanZhiExact) - (monthZhiIndex - zhiIndex);
                if (jiaZiIndex >= 60)
                {
                    jiaZiIndex -= 60;
                }
                if (jiaZiIndex < 0)
                {
                    jiaZiIndex += 60;
                }
                return LunarUtil.JIA_ZI[jiaZiIndex];
            }
        }

        public string MingGongNaYin => LunarUtil.NAYIN[MingGong];

        public string ShenGong
        {
            get
            {
                var monthZhiIndex = 0;
                var timeZhiIndex = 0;
                for (int i = 0, j = MONTH_ZHI.Length; i < j; i++)
                {
                    var zhi = MONTH_ZHI[i];
                    if (Lunar.MonthZhiExact.Equals(zhi))
                    {
                        monthZhiIndex = i;
                    }
                    if (Lunar.TimeZhi.Equals(zhi))
                    {
                        timeZhiIndex = i;
                    }
                }
                var zhiIndex = 2 + monthZhiIndex + timeZhiIndex;
                if (zhiIndex > 12)
                {
                    zhiIndex -= 12;
                }
                var jiaZiIndex = LunarUtil.GetJiaZiIndex(Lunar.MonthInGanZhiExact) - (monthZhiIndex - zhiIndex);
                if (jiaZiIndex >= 60)
                {
                    jiaZiIndex -= 60;
                }
                if (jiaZiIndex < 0)
                {
                    jiaZiIndex += 60;
                }
                return LunarUtil.JIA_ZI[jiaZiIndex];
            }
        }

        public string ShenGongNaYin => LunarUtil.NAYIN[ShenGong];

        /// <summary>
        /// 获取运
        /// </summary>
        /// <param name="gender">性别：1男，0女</param>
        /// <param name="sect">流派，1按天数和时辰数计算，3天1年，1天4个月，1时辰10天；2按分钟数计算</param>
        /// <returns>运</returns>
        public Yun GetYun(int gender, int sect = 1)
        {
            return new Yun(this, gender, sect);
        }

        /// <summary>
        /// 年柱所在旬
        /// </summary>
        public string YearXun => Lunar.YearXunExact;

        /// <summary>
        /// 年柱旬空(空亡)
        /// </summary>
        public string YearXunKong => Lunar.YearXunKongExact;

        /// <summary>
        /// 月柱所在旬
        /// </summary>
        public string MonthXun => Lunar.MonthXunExact;

        /// <summary>
        /// 月柱旬空(空亡)
        /// </summary>
        public string MonthXunKong => Lunar.MonthXunKongExact;

        /// <summary>
        /// 日柱所在旬
        /// </summary>
        public string DayXun => (2 == Sect) ? Lunar.DayXunExact2 : Lunar.DayXunExact;

        /// <summary>
        /// 日柱旬空(空亡)
        /// </summary>
        public string DayXunKong => (2 == Sect) ? Lunar.DayXunKongExact2 : Lunar.DayXunKongExact;

        /// <summary>
        /// 时柱所在旬
        /// </summary>
        public string TimeXun => Lunar.TimeXun;

        /// <summary>
        /// 时柱旬空(空亡)
        /// </summary>
        public string TimeXunKong => Lunar.TimeXunKong;

    }
}