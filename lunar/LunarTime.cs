using System;
using System.Collections.Generic;
using Lunar.Util;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable IdentifierTypo

// TODO: 可访问性调整

namespace Lunar
{
    /// <summary>
    /// 时辰
    /// </summary>
    public sealed class LunarTime
    {
        /// <summary>
        /// 天干下标，0-9
        /// </summary>
        public int GanIndex { get; }

        /// <summary>
        /// 地支下标，0-11
        /// </summary>
        public int ZhiIndex { get; }

        /// <summary>
        /// 阴历
        /// </summary>
        public Lunar Lunar { get; }

        /// <summary>
        /// 通过农历年月日时初始化
        /// </summary>
        /// <param name="lunarYear">年（农历）</param>
        /// <param name="lunarMonth">月（农历），1到12，闰月为负，即闰2月=-2</param>
        /// <param name="lunarDay">日（农历），1到31</param>
        /// <param name="hour">小时（阳历）</param>
        /// <param name="minute">分钟（阳历）</param>
        /// <param name="second">秒钟（阳历）</param>
        public LunarTime(int lunarYear, int lunarMonth, int lunarDay, int hour, int minute, int second)
        {
            Lunar = Lunar.FromYmdHms(lunarYear, lunarMonth, lunarDay, hour, minute, second);
            ZhiIndex = LunarUtil.GetTimeZhiIndex((hour < 10 ? "0" : "") + hour + ":" + (minute < 10 ? "0" : "") + minute);
            GanIndex = (Lunar.DayGanIndexExact % 5 * 2 + ZhiIndex) % 10;
        }

        /// <summary>
        /// 通过指定农历年月日获取时辰
        /// </summary>
        /// <param name="lunarYear">年（农历）</param>
        /// <param name="lunarMonth">月（农历），1到12，闰月为负，即闰2月=-2</param>
        /// <param name="lunarDay">日（农历），1到31</param>
        /// <param name="hour">小时（阳历）</param>
        /// <param name="minute">分钟（阳历）</param>
        /// <param name="second">秒钟（阳历）</param>
        /// <returns>时辰</returns>
        public static LunarTime FromYmdHms(int lunarYear, int lunarMonth, int lunarDay, int hour, int minute, int second)
        {
            return new LunarTime(lunarYear, lunarMonth, lunarDay, hour, minute, second);
        }

        /// <summary>
        /// 生肖，如虎
        /// </summary>
        public string ShengXiao => LunarUtil.SHENGXIAO[ZhiIndex + 1];

        /// <summary>
        /// 地支
        /// </summary>
        public string Zhi => LunarUtil.ZHI[ZhiIndex + 1];

        /// <summary>
        /// 天干
        /// </summary>
        public string Gan => LunarUtil.GAN[GanIndex + 1];

        /// <summary>
        /// 干支（时柱）
        /// </summary>
        public string GanZhi => Gan + Zhi;

        /// <summary>
        /// 喜神方位，如艮
        /// </summary>
        public string PositionXi => LunarUtil.POSITION_XI[GanIndex + 1];

        /// <summary>
        /// 喜神方位描述，如东北
        /// </summary>
        public string PositionXiDesc => LunarUtil.POSITION_DESC[PositionXi];

        /// <summary>
        /// 阳贵神方位，如艮
        /// </summary>
        public string PositionYangGui => LunarUtil.POSITION_YANG_GUI[GanIndex + 1];

        /// <summary>
        /// 阳贵神方位描述，如东北
        /// </summary>
        public string PositionYangGuiDesc => LunarUtil.POSITION_DESC[PositionYangGui];

        /// <summary>
        /// 阴贵神方位，如艮
        /// </summary>
        public string PositionYinGui => LunarUtil.POSITION_YIN_GUI[GanIndex + 1];

        /// <summary>
        /// 阴贵神方位描述，如东北
        /// </summary>
        public string PositionYinGuiDesc => LunarUtil.POSITION_DESC[PositionYinGui];

        /// <summary>
        /// 福神方位(流派2)，如艮
        /// </summary>
        public string PositionFu => GetPositionFu();

        /// <summary>
        /// 获取福神方位
        /// </summary>
        /// <param name="sect">流派，可选1或2</param>
        /// <returns>福神方位，如艮</returns>
        public string GetPositionFu(int sect = 2)
        {
            return (1 == sect ? LunarUtil.POSITION_FU : LunarUtil.POSITION_FU_2)[GanIndex + 1];
        }

        /// <summary>
        /// 福神方位描述(流派2)，如东北
        /// </summary>
        public string PositionFuDesc => GetPositionFuDesc();

        /// <summary>
        /// 获取福神方位描述
        /// </summary>
        /// <param name="sect">流派，可选1或2</param>
        /// <returns>福神方位描述，如东北</returns>
        public string GetPositionFuDesc(int sect = 2)
        {
            return LunarUtil.POSITION_DESC[GetPositionFu(sect)];
        }

        /// <summary>
        /// 财神方位，如艮
        /// </summary>
        public string PositionCai => LunarUtil.POSITION_CAI[GanIndex + 1];

        /// <summary>
        /// 财神方位描述，如东北
        /// </summary>
        /// <returns></returns>
        public string PositionCaiDesc => LunarUtil.POSITION_DESC[PositionCai];

        /// <summary>
        /// 冲，如申
        /// </summary>
        /// <returns></returns>
        public string Chong => LunarUtil.CHONG[ZhiIndex];

        /// <summary>
        /// 无情之克的冲天干，如甲
        /// </summary>
        public string ChongGan => LunarUtil.CHONG_GAN[GanIndex];

        /// <summary>
        /// 有情之克的冲天干，如甲
        /// </summary>
        public string ChongGanTie => LunarUtil.CHONG_GAN_TIE[GanIndex];

        /// <summary>
        /// 冲生肖，如猴
        /// </summary>
        public string ChongShengXiao
        {
            get
            {
                for (int i = 0, j = LunarUtil.ZHI.Count; i < j; i++)
                {
                    if (LunarUtil.ZHI[i].Equals(Chong))
                    {
                        return LunarUtil.SHENGXIAO[i];
                    }
                }
                return "";
            }
        }

        /// <summary>
        /// 冲描述，如(壬申)猴
        /// </summary>
        public string ChongDesc => "(" + ChongGan + Chong + ")" + ChongShengXiao;

        /// <summary>
        /// 煞，如北
        /// </summary>
        public string Sha => LunarUtil.SHA[Zhi];

        /// <summary>
        /// 纳音，如剑锋金
        /// </summary>
        public string NaYin => LunarUtil.NAYIN[GanZhi];

        /// <summary>
        /// 天神
        /// </summary>
        public string TianShen => LunarUtil.TIAN_SHEN[(ZhiIndex + LunarUtil.ZHI_TIAN_SHEN_OFFSET[Lunar.DayZhiExact]) % 12 + 1];

        /// <summary>
        /// 天神类型：黄道/黑道
        /// </summary>
        public string TianShenType => LunarUtil.TIAN_SHEN_TYPE[TianShen];

        /// <summary>
        /// 天神吉凶：吉/凶
        /// </summary>
        public string TianShenLuck => LunarUtil.TIAN_SHEN_TYPE_LUCK[TianShenType];

        /// <summary>
        /// 宜，如果没有，返回["无"]
        /// </summary>
        public IEnumerable<string> Yi => LunarUtil.GetTimeYi(Lunar.DayInGanZhiExact, GanZhi);

        /// <summary>
        /// 忌，如果没有，返回["无"]
        /// </summary>
        public IEnumerable<string> Ji => LunarUtil.GetTimeJi(Lunar.DayInGanZhiExact, GanZhi);

        /// <summary>
        /// 九星（时家紫白星歌诀：三元时白最为佳，冬至阳生顺莫差，孟日七宫仲一白，季日四绿发萌芽，每把时辰起甲子，本时星耀照光华，时星移入中宫去，顺飞八方逐细查。夏至阴生逆回首，孟归三碧季加六，仲在九宫时起甲，依然掌中逆轮跨。）
        /// </summary>
        public NineStar NineStar
        {
            get
            {
                var solarYmd = Lunar.Solar.Ymd;
                var jieQi = Lunar.JieQiTable;
                // 顺逆
                var asc = string.Compare(solarYmd, jieQi["冬至"].Ymd, StringComparison.Ordinal) >= 0 && string.Compare(solarYmd, jieQi["夏至"].Ymd, StringComparison.Ordinal) < 0;
                var start = asc ? 7 : 3;
                var dayZhi = Lunar.DayZhi;
                if ("子午卯酉".Contains(dayZhi))
                {
                    start = asc ? 1 : 9;
                }
                else if ("辰戌丑未".Contains(dayZhi))
                {
                    start = asc ? 4 : 6;
                }
                var index = asc ? start + ZhiIndex - 1 : start - ZhiIndex - 1;
                if (index > 8)
                {
                    index -= 9;
                }
                if (index < 0)
                {
                    index += 9;
                }
                return new NineStar(index);
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return GanZhi;
        }

        /// <summary>
        /// 旬
        /// </summary>
        public string Xun => LunarUtil.GetXun(GanZhi);

        /// <summary>
        /// 空亡(旬空)
        /// </summary>
        public string XunKong => LunarUtil.GetXunKong(GanZhi);

        /// <summary>
        /// 当前时辰的最早时分，如：21:00
        /// </summary>
        public string MinHm
        {
            get
            {
                var hour = Lunar.Hour;
                if (hour < 1)
                {
                    return "00:00";
                }
                if (hour > 22)
                {
                    return "23:00";
                }
                if (hour % 2 == 0)
                {
                    hour -= 1;
                }
                return (hour < 10 ? "0" : "") + hour + ":00";
            }
        }

        /// <summary>
        /// 当前时辰的最晚时分，如：22:59
        /// </summary>
        public string MaxHm
        {
            get
            {
                var hour = Lunar.Hour;
                if (hour < 1)
                {
                    return "00:59";
                }
                if (hour > 22)
                {
                    return "23:59";
                }
                if (hour % 2 != 0)
                {
                    hour += 1;
                }
                return (hour < 10 ? "0" : "") + hour + ":59";
            }
        }

    }
}
