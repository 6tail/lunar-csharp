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

        private static readonly Dictionary<string, int> CHANG_SHENG_OFFSET = new Dictionary<string, int>
        {
            //阳
            {"甲", 1},
            {"丙", 10},
            {"戊", 10},
            {"庚", 7},
            {"壬", 4},
            //阴
            {"乙", 6},
            {"丁", 9},
            {"己", 9},
            {"辛", 0},
            {"癸", 3}
        };

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

        /// <summary>
        /// 从阴历初始化
        /// </summary>
        /// <param name="lunar">阴历</param>
        public EightChar(Lunar lunar)
        {
            Lunar = lunar;
        }

        /// <summary>
        /// 从阴历创建八字
        /// </summary>
        /// <param name="lunar">阴历</param>
        /// <returns>八字</returns>
        public static EightChar FromLunar(Lunar lunar)
        {
            return new EightChar(lunar);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{Year} {Month} {Day} {Time}";
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
        public string YearWuXing => $"{LunarUtil.WU_XING_GAN[YearGan]}{LunarUtil.WU_XING_ZHI[YearZhi]}";

        /// <summary>
        /// 年纳音
        /// </summary>
        public string YearNaYin => LunarUtil.NAYIN[Year];

        /// <summary>
        /// 年天干十神
        /// </summary>
        public string YearShiShenGan => LunarUtil.SHI_SHEN[$"{DayGan}{YearGan}"];

        private List<string> GetShiShenZhi(string zhi)
        {
            var hideGan = LunarUtil.ZHI_HIDE_GAN[zhi];
            var l = new List<string>(hideGan.Count);
            l.AddRange(hideGan.Select(gan => LunarUtil.SHI_SHEN[$"{DayGan}{gan}"]));
            return l;
        }

        /// <summary>
        /// 年十神支
        /// </summary>
        public List<string> YearShiShenZhi => GetShiShenZhi(YearZhi);

        /// <summary>
        /// 日干序号
        /// </summary>
        public int DayGanIndex =>  (2 == Sect) ? Lunar.DayGanIndexExact2 : Lunar.DayGanIndexExact;

        /// <summary>
        /// 日支序号
        /// </summary>
        public int DayZhiIndex => (2 == Sect) ? Lunar.DayZhiIndexExact2 : Lunar.DayZhiIndexExact;

        private string GetDiShi(int zhiIndex)
        {
            var index = CHANG_SHENG_OFFSET[DayGan] + (DayGanIndex % 2 == 0 ? zhiIndex : -zhiIndex);
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

        /// <summary>
        /// 年地势
        /// </summary>
        public string YearDiShi => GetDiShi(Lunar.YearZhiIndexExact);

        /// <summary>
        /// 月柱
        /// </summary>
        public string Month => Lunar.MonthInGanZhiExact;

        /// <summary>
        /// 月干
        /// </summary>
        public string MonthGan => Lunar.MonthGanExact;

        /// <summary>
        /// 月支
        /// </summary>
        public string MonthZhi => Lunar.MonthZhiExact;

        /// <summary>
        /// 月藏干
        /// </summary>
        public List<string> MonthHideGan => LunarUtil.ZHI_HIDE_GAN[MonthZhi];

        /// <summary>
        /// 月五行
        /// </summary>
        public string MonthWuXing => $"{LunarUtil.WU_XING_GAN[MonthGan]}{LunarUtil.WU_XING_ZHI[MonthZhi]}";

        /// <summary>
        /// 月纳音
        /// </summary>
        public string MonthNaYin => LunarUtil.NAYIN[Month];

        /// <summary>
        /// 月十神干
        /// </summary>
        public string MonthShiShenGan => LunarUtil.SHI_SHEN[$"{DayGan}{MonthGan}"];

        /// <summary>
        /// 月十神支
        /// </summary>
        public List<string> MonthShiShenZhi => GetShiShenZhi(MonthZhi);

        /// <summary>
        /// 月地势
        /// </summary>
        public string MonthDiShi => GetDiShi(Lunar.MonthZhiIndexExact);

        /// <summary>
        /// 日柱
        /// </summary>
        public string Day => (2 == Sect) ? Lunar.DayInGanZhiExact2 : Lunar.DayInGanZhiExact;

        /// <summary>
        /// 日干
        /// </summary>
        public string DayGan => (2 == Sect) ? Lunar.DayGanExact2 : Lunar.DayGanExact;

        /// <summary>
        /// 日支
        /// </summary>
        public string DayZhi => (2 == Sect) ? Lunar.DayZhiExact2 : Lunar.DayZhiExact;

        /// <summary>
        /// 日支藏干
        /// </summary>
        public List<string> DayHideGan => LunarUtil.ZHI_HIDE_GAN[DayZhi];

        /// <summary>
        /// 日五行
        /// </summary>
        public string DayWuXing => $"{LunarUtil.WU_XING_GAN[DayGan]}{LunarUtil.WU_XING_ZHI[DayZhi]}";

        /// <summary>
        /// 日纳音
        /// </summary>
        public string DayNaYin => LunarUtil.NAYIN[Day];

        /// <summary>
        /// 日十神干
        /// </summary>
        public string DayShiShenGan => "日主";

        /// <summary>
        /// 日十神支
        /// </summary>
        public List<string> DayShiShenZhi => GetShiShenZhi(DayZhi);

        /// <summary>
        /// 日地势
        /// </summary>
        public string DayDiShi => GetDiShi(DayZhiIndex);

        /// <summary>
        /// 时柱
        /// </summary>
        public string Time => Lunar.TimeInGanZhi;

        /// <summary>
        /// 时干
        /// </summary>
        public string TimeGan => Lunar.TimeGan;

        /// <summary>
        /// 时支
        /// </summary>
        public string TimeZhi => Lunar.TimeZhi;

        /// <summary>
        /// 时支藏干
        /// </summary>
        public List<string> TimeHideGan => LunarUtil.ZHI_HIDE_GAN[TimeZhi];

        /// <summary>
        /// 时五行
        /// </summary>
        public string TimeWuXing => $"{LunarUtil.WU_XING_GAN[Lunar.TimeGan]}{LunarUtil.WU_XING_ZHI[Lunar.TimeZhi]}";

        /// <summary>
        /// 时纳音
        /// </summary>
        public string TimeNaYin => LunarUtil.NAYIN[Time];

        /// <summary>
        /// 时十神干
        /// </summary>
        public string TimeShiShenGan => LunarUtil.SHI_SHEN[$"{DayGan}{TimeGan}"];

        /// <summary>
        /// 时十神支
        /// </summary>
        public List<string> TimeShiShenZhi => GetShiShenZhi(TimeZhi);

        /// <summary>
        /// 时地势
        /// </summary>
        public string TimeDiShi => GetDiShi(Lunar.TimeZhiIndex);

        /// <summary>
        /// 胎元
        /// </summary>
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
                return $"{LunarUtil.GAN[ganIndex + 1]}{LunarUtil.ZHI[zhiIndex + 1]}";
            }
        }

        /// <summary>
        /// 胎元纳音
        /// </summary>
        public string TaiYuanNaYin => LunarUtil.NAYIN[TaiYuan];

        /// <summary>
        /// 胎息
        /// </summary>
        public string TaiXi
        {
            get
            {
                var ganIndex = 2 == Sect ? Lunar.DayGanIndexExact2 : Lunar.DayGanIndexExact;
                var zhiIndex = 2 == Sect ? Lunar.DayZhiIndexExact2 : Lunar.DayZhiIndexExact;
                return $"{LunarUtil.HE_GAN_5[ganIndex]}{LunarUtil.HE_ZHI_6[zhiIndex]}";
            }
        }

        /// <summary>
        /// 胎息纳音
        /// </summary>
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
                    if (MonthZhi.Equals(MONTH_ZHI[i]))
                    {
                        monthZhiIndex = i;
                        break;
                    }
                }
                for (int i = 0, j = MONTH_ZHI.Length; i < j; i++)
                {
                    if (TimeZhi.Equals(MONTH_ZHI[i]))
                    {
                        timeZhiIndex = i;
                        break;
                    }
                }
                var offset = monthZhiIndex + timeZhiIndex;
                offset = (offset >= 14 ? 26 : 14) - offset;
                var ganIndex = (Lunar.YearGanIndexExact + 1) * 2 + offset;
                while (ganIndex > 10) {
                    ganIndex -= 10;
                }
                return LunarUtil.GAN[ganIndex] + MONTH_ZHI[offset];
            }
        }

        /// <summary>
        /// 命宫纳音
        /// </summary>
        public string MingGongNaYin => LunarUtil.NAYIN[MingGong];

        /// <summary>
        /// 身宫
        /// </summary>
        public string ShenGong
        {
            get
            {
                var monthZhiIndex = 0;
                var timeZhiIndex = 0;
                for (int i = 0, j = MONTH_ZHI.Length; i < j; i++)
                {
                    if (MonthZhi.Equals(MONTH_ZHI[i]))
                    {
                        monthZhiIndex = i;
                        break;
                    }
                }
                for (int i = 0, j = LunarUtil.ZHI.Length; i < j; i++)
                {
                    if (TimeZhi.Equals(LunarUtil.ZHI[i]))
                    {
                        timeZhiIndex = i;
                        break;
                    }
                }
                var offset = (monthZhiIndex + timeZhiIndex - 1) % 12;
                var ganIndex = (Lunar.YearGanIndexExact + 1) * 2 + offset;
                while (ganIndex > 10) {
                    ganIndex -= 10;
                }
                return LunarUtil.GAN[ganIndex + 1] + MONTH_ZHI[offset + 1];
            }
        }

        /// <summary>
        /// 身宫纳音
        /// </summary>
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