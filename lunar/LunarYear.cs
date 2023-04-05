using System;
using System.Collections.Generic;
using System.Linq;
using Lunar.Util;
using System.Text.RegularExpressions;
// ReSharper disable InconsistentNaming
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable IdentifierTypo

namespace Lunar
{
    /// <summary>
    /// 农历年
    /// </summary>
    public class LunarYear
    {
        /// <summary>
        /// 元
        /// </summary>
        private static readonly string[] YUAN = { "下", "上", "中" };

        /// <summary>
        /// 运
        /// </summary>
        private static readonly string[] YUN = { "七", "八", "九", "一", "二", "三", "四", "五", "六" };

        /// <summary>
        /// 闰冬月年份
        /// </summary>
        private static readonly int[] LEAP_11 = { 75, 94, 170, 238, 265, 322, 389, 469, 553, 583, 610, 678, 735, 754, 773, 849, 887, 936, 1050, 1069, 1126, 1145, 1164, 1183, 1259, 1278, 1308, 1373, 1403, 1441, 1460, 1498, 1555, 1593, 1612, 1631, 1642, 2033, 2128, 2147, 2242, 2614, 2728, 2910, 3062, 3244, 3339, 3616, 3711, 3730, 3825, 4007, 4159, 4197, 4322, 4341, 4379, 4417, 4531, 4599, 4694, 4713, 4789, 4808, 4971, 5085, 5104, 5161, 5180, 5199, 5294, 5305, 5476, 5677, 5696, 5772, 5791, 5848, 5886, 6049, 6068, 6144, 6163, 6258, 6402, 6440, 6497, 6516, 6630, 6641, 6660, 6679, 6736, 6774, 6850, 6869, 6899, 6918, 6994, 7013, 7032, 7051, 7070, 7089, 7108, 7127, 7146, 7222, 7271, 7290, 7309, 7366, 7385, 7404, 7442, 7461, 7480, 7491, 7499, 7594, 7624, 7643, 7662, 7681, 7719, 7738, 7814, 7863, 7882, 7901, 7939, 7958, 7977, 7996, 8034, 8053, 8072, 8091, 8121, 8159, 8186, 8216, 8235, 8254, 8273, 8311, 8330, 8341, 8349, 8368, 8444, 8463, 8474, 8493, 8531, 8569, 8588, 8626, 8664, 8683, 8694, 8702, 8713, 8721, 8751, 8789, 8808, 8816, 8827, 8846, 8884, 8903, 8922, 8941, 8971, 9036, 9066, 9085, 9104, 9123, 9142, 9161, 9180, 9199, 9218, 9256, 9294, 9313, 9324, 9343, 9362, 9381, 9419, 9438, 9476, 9514, 9533, 9544, 9552, 9563, 9571, 9582, 9601, 9639, 9658, 9666, 9677, 9696, 9734, 9753, 9772, 9791, 9802, 9821, 9886, 9897, 9916, 9935, 9954, 9973, 9992 };

        /// <summary>
        /// 闰腊月年份
        /// </summary>
        private static readonly int[] LEAP_12 = { 37, 56, 113, 132, 151, 189, 208, 227, 246, 284, 303, 341, 360, 379, 417, 436, 458, 477, 496, 515, 534, 572, 591, 629, 648, 667, 697, 716, 792, 811, 830, 868, 906, 925, 944, 963, 982, 1001, 1020, 1039, 1058, 1088, 1153, 1202, 1221, 1240, 1297, 1335, 1392, 1411, 1422, 1430, 1517, 1525, 1536, 1574, 3358, 3472, 3806, 3988, 4751, 4941, 5066, 5123, 5275, 5343, 5438, 5457, 5495, 5533, 5552, 5715, 5810, 5829, 5905, 5924, 6421, 6535, 6793, 6812, 6888, 6907, 7002, 7184, 7260, 7279, 7374, 7556, 7746, 7757, 7776, 7833, 7852, 7871, 7966, 8015, 8110, 8129, 8148, 8224, 8243, 8338, 8406, 8425, 8482, 8501, 8520, 8558, 8596, 8607, 8615, 8645, 8740, 8778, 8835, 8865, 8930, 8960, 8979, 8998, 9017, 9055, 9074, 9093, 9112, 9150, 9188, 9237, 9275, 9332, 9351, 9370, 9408, 9427, 9446, 9457, 9465, 9495, 9560, 9590, 9628, 9647, 9685, 9715, 9742, 9780, 9810, 9818, 9829, 9848, 9867, 9905, 9924, 9943, 9962, 10000 };

        private static readonly Dictionary<int, int> LEAP = new Dictionary<int, int>();

        private static readonly Dictionary<int, LunarYear> CACHE = new Dictionary<int, LunarYear>();

        static LunarYear()
        {
            foreach (var y in LEAP_11)
            {
                LEAP.Add(y, 13);
            }
            foreach (var y in LEAP_12)
            {
                LEAP.Add(y, 14);
            }
        }

        /// <summary>
        /// 年
        /// </summary>
        public int Year { get; }

        /// <summary>
        /// 天干下标
        /// </summary>
        public int GanIndex { get; }

        /// <summary>
        /// 地支下标
        /// </summary>
        public int ZhiIndex { get; }

        public List<LunarMonth> Months { get; } = new List<LunarMonth>();

        public List<double> JieQiJulianDays { get; } = new List<double>();

        /// <summary>
        /// 通过农历年初始化
        /// </summary>
        /// <param name="lunarYear">农历年</param>
        public LunarYear(int lunarYear)
        {
            Year = lunarYear;
            var offset = lunarYear - 4;
            var yearGanIndex = offset % 10;
            var yearZhiIndex = offset % 12;
            if (yearGanIndex < 0)
            {
                yearGanIndex += 10;
            }
            if (yearZhiIndex < 0)
            {
                yearZhiIndex += 12;
            }
            GanIndex = yearGanIndex;
            ZhiIndex = yearZhiIndex;
            Compute();
        }

        /// <summary>
        /// 通过农历年初始化
        /// </summary>
        /// <param name="lunarYear">农历年</param>
        /// <returns>农历年</returns>
        public static LunarYear FromYear(int lunarYear)
        {
            LunarYear obj = null;
            try
            {
                obj = CACHE[lunarYear];
            }
            catch
            {
                // ignored
            }
            if (null == obj)
            {
                obj = new LunarYear(lunarYear);
                try
                {
                    CACHE.Add(lunarYear, obj);
                }
                catch
                {
                    // ignored
                }
            }
            return obj;
        }

        private void Compute()
        {
            // 节气(中午12点)
            var jq = new double[27];
            // 合朔，即每月初一(中午12点)
            var hs = new double[16];
            // 每月天数
            var dayCounts = new int[hs.Length - 1];

            var year = Year - 2000;
            // 从上年的大雪到下年的立春
            for (int i = 0, j = Lunar.JIE_QI_IN_USE.Length; i < j; i++)
            {
                // 精确的节气
                var t = 36525 * ShouXingUtil.SaLonT((year + (17 + i) * 15d / 360) * ShouXingUtil.PI_2);
                t += ShouXingUtil.ONE_THIRD - ShouXingUtil.DtT(t);
                JieQiJulianDays.Add(t + Solar.J2000);
                // 按中午12点算的节气
                if (i > 0 && i < 28)
                {
                    jq[i - 1] = Math.Round(t);
                }
            }

            // 冬至前的初一
            var w = ShouXingUtil.CalcShuo(jq[0]);
            if (w > jq[0]) {
                if (Year != 41 && Year != 193 && Year != 288 && Year != 345 && Year != 918 && Year != 1013) {
                    w -= 29.5306;
                }
            }
            // 递推每月初一
            for (int i = 0, j = hs.Length; i < j; i++)
            {
                hs[i] = ShouXingUtil.CalcShuo(w + 29.5306 * i);
            }
            // 每月天数
            for (int i = 0, j = dayCounts.Length; i < j; i++)
            {
                dayCounts[i] = (int)(hs[i + 1] - hs[i]);
            }
            
            var prevYear = Year - 1;
            var leapYear = -1;
            var leapIndex = -1;

            try
            {
                leapIndex = LEAP[Year];
                leapYear = Year;
            }
            catch
            {
                try
                {
                    leapIndex = LEAP[prevYear] - 12;
                    leapYear = prevYear;
                }
                catch
                {
                    if (hs[13] <= jq[24])
                    {
                        var i = 1;
                        while (hs[i + 1] > jq[2 * i] && i < 13)
                        {
                            i++;
                        }
                        leapYear = Year;
                        leapIndex = i;
                    }
                }
            }

            var y = prevYear;
            var m = 11;
            var index = m;
            for (int i = 0, j = dayCounts.Length; i < j; i++)
            {
                var cm = m;
                if (y == leapYear && i == leapIndex)
                {
                    cm = -cm;
                }
                Months.Add(new LunarMonth(y, cm, dayCounts[i], hs[i] + Solar.J2000, index));
                if (y != leapYear || i + 1 != leapIndex)
                {
                    m++;
                }
                index++;
                if (m == 13)
                {
                    m = 1;
                    index = 1;
                    y++;
                }
            }
        }

        /// <summary>
        /// 天干
        /// </summary>
        public string Gan => LunarUtil.GAN[GanIndex + 1];

        /// <summary>
        /// 地支
        /// </summary>
        public string Zhi => LunarUtil.ZHI[ZhiIndex + 1];

        /// <summary>
        /// 获取干支
        /// </summary>
        public string GanZhi => Gan + Zhi;

        public LunarMonth GetMonth(int lunarMonth)
        {
            return Months.FirstOrDefault(m => m.Year == Year && m.Month == lunarMonth);
        }

        public int LeapMonth => (from m in Months where m.Year == Year && m.Leap select Math.Abs(m.Month)).FirstOrDefault();

        /// <summary>
        /// 获取总天数
        /// </summary>
        public int DayCount => Months.Where(m => m.Year == Year).Sum(m => m.DayCount);

        /// <summary>
        /// 获取当年的农历月们
        /// </summary>
        public List<LunarMonth> MonthsInYear => Months.Where(m => m.Year == Year).ToList();
        
        public override string ToString()
        {
            return Year + "";
        }

        public string FullString => Year + "年";

        protected string GetZaoByGan(int index, string name)
        {
            var offset = index - Solar.FromJulianDay(GetMonth(1).FirstJulianDay).Lunar.DayGanIndex;
            if (offset < 0)
            {
                offset += 10;
            }
            return new Regex("几", RegexOptions.Singleline).Replace(name, LunarUtil.NUMBER[offset + 1], 1);
        }

        protected string GetZaoByZhi(int index, string name)
        {
            var offset = index - Solar.FromJulianDay(GetMonth(1).FirstJulianDay).Lunar.DayZhiIndex;
            if (offset < 0)
            {
                offset += 12;
            }
            return new Regex("几", RegexOptions.Singleline).Replace(name, LunarUtil.NUMBER[offset + 1], 1);
        }

        /// <summary>
        /// 几鼠偷粮
        /// </summary>
        /// <returns>几鼠偷粮</returns>
        public string TouLiang => GetZaoByZhi(0, "几鼠偷粮");

        /// <summary>
        /// 草子几分
        /// </summary>
        public string CaoZi => GetZaoByZhi(0, "草子几分");

        /// <summary>
        /// 几牛耕田（正月第一个丑日是初几，就是几牛耕田）
        /// </summary>
        public string GengTian => GetZaoByZhi(1, "几牛耕田");

        /// <summary>
        /// 花收几分
        /// </summary>
        public string HuaShou => GetZaoByZhi(3, "花收几分");

        /// <summary>
        /// 几龙治水（正月第一个辰日是初几，就是几龙治水）
        /// </summary>
        public string ZhiShui => GetZaoByZhi(4, "几龙治水");

        /// <summary>
        /// 几马驮谷
        /// </summary>
        public string TuoGu => GetZaoByZhi(6, "几马驮谷");

        /// <summary>
        /// 几鸡抢米
        /// </summary>
        public string QiangMi => GetZaoByZhi(9, "几鸡抢米");

        /// <summary>
        /// 几姑看蚕
        /// </summary>
        public string KanCan => GetZaoByZhi(9, "几姑看蚕");

        /// <summary>
        /// 几屠共猪
        /// </summary>
        public string GongZhu => GetZaoByZhi(11, "几屠共猪");

        /// <summary>
        /// 甲田几分
        /// </summary>
        public string JiaTian => GetZaoByGan(0, "甲田几分");

        /// <summary>
        /// 几人分饼（正月第一个丙日是初几，就是几人分饼）
        /// </summary>
        public string FenBing => GetZaoByGan(2, "几人分饼");

        /// <summary>
        /// 几日得金（正月第一个辛日是初几，就是几日得金）
        /// </summary>
        public string DeJin => GetZaoByGan(7, "几日得金");

        /// <summary>
        /// 几人几丙
        /// </summary>
        public string RenBing => GetZaoByGan(2, GetZaoByZhi(2, "几人几丙"));

        /// <summary>
        /// 几人几锄
        /// </summary>
        public string RenChu => GetZaoByGan(3, GetZaoByZhi(2, "几人几锄"));

        /// <summary>
        /// 三元
        /// </summary>
        public string Yuan => YUAN[(Year + 2696) / 60 % 3] + "元";

        /// <summary>
        /// 九运
        /// </summary>
        public string Yun => YUN[(Year + 2696) / 20 % 9] + "运";

        /// <summary>
        /// 九星
        /// </summary>
        public NineStar NineStar
        {
            get
            {
                var index = LunarUtil.GetJiaZiIndex(GanZhi) + 1;
                var yuan = (Year + 2696) / 60 % 3;
                var offset = (62 + yuan * 3 - index) % 9;
                if (0 == offset)
                {
                    offset = 9;
                }
                return NineStar.FromIndex(offset - 1);
            }
        }

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
        /// 福神方位，如艮（流派2）
        /// </summary>
        public string PositionFu => GetPositionFu();

        /// <summary>
        /// 福神方位描述，如东北（流派2）
        /// </summary>
        public string PositionFuDesc => GetPositionFuDesc();

        /// <summary>
        /// 获取福神方位
        /// </summary>
        /// <param name="sect">流派，1或2</param>
        /// <returns>方位，如艮</returns>
        public string GetPositionFu(int sect = 2)
        {
            return (1 == sect ? LunarUtil.POSITION_FU : LunarUtil.POSITION_FU_2)[GanIndex + 1];
        }

        /// <summary>
        /// 获取福神方位描述
        /// </summary>
        /// <param name="sect">流派，1或2</param>
        /// <returns>方位描述，如东北</returns>
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
        public string PositionCaiDesc => LunarUtil.POSITION_DESC[PositionCai];

        /// <summary>
        /// 太岁方位，如艮
        /// </summary>
        public string PositionTaiSui => LunarUtil.POSITION_TAI_SUI_YEAR[ZhiIndex];

        /// <summary>
        /// 太岁方位描述，如东北
        /// </summary>
        public string PositionTaiSuiDesc => LunarUtil.POSITION_DESC[PositionTaiSui];

        /// <summary>
        /// 往后推几年的阴历年，如果要往前推，则年数用负数
        /// </summary>
        /// <param name="n">年数</param>
        /// <returns>阴历年</returns>
        public LunarYear Next(int n)
        {
            return FromYear(Year + n);
        }
    }
}
