using System;
using System.Collections.Generic;
using System.Text;
using com.nlf.calendar.util;
using System.Text.RegularExpressions;

namespace com.nlf.calendar
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
            foreach (int y in LEAP_11)
            {
                LEAP.Add(y, 13);
            }
            foreach (int y in LEAP_12)
            {
                LEAP.Add(y, 14);
            }
        }

        /// <summary>
        /// 年
        /// </summary>
        private int year;

        /// <summary>
        /// 天干下标
        /// </summary>
        private int ganIndex;

        /// <summary>
        /// 地支下标
        /// </summary>
        private int zhiIndex;

        private List<LunarMonth> months = new List<LunarMonth>();

        private List<double> jieQiJulianDays = new List<double>();

        /// <summary>
        /// 通过农历年初始化
        /// </summary>
        /// <param name="lunarYear">农历年</param>
        public LunarYear(int lunarYear)
        {
            this.year = lunarYear;
            int offset = lunarYear - 4;
            int yearGanIndex = offset % 10;
            int yearZhiIndex = offset % 12;
            if (yearGanIndex < 0)
            {
                yearGanIndex += 10;
            }
            if (yearZhiIndex < 0)
            {
                yearZhiIndex += 12;
            }
            this.ganIndex = yearGanIndex;
            this.zhiIndex = yearZhiIndex;
            compute();
        }

        /// <summary>
        /// 通过农历年初始化
        /// </summary>
        /// <param name="lunarYear">农历年</param>
        /// <returns>农历年</returns>
        public static LunarYear fromYear(int lunarYear)
        {
            LunarYear obj = null;
            try
            {
                obj = CACHE[lunarYear];
            }
            catch { }
            if (null == obj)
            {
                obj = new LunarYear(lunarYear);
                CACHE.Add(lunarYear, obj);
            }
            return obj;
        }

        private void compute()
        {
            // 节气(中午12点)
            double[] jq = new double[27];
            // 合朔，即每月初一(中午12点)
            double[] hs = new double[16];
            // 每月天数
            int[] dayCounts = new int[hs.Length - 1];

            int currentYear = this.year;

            int year = currentYear - 2000;
            // 从上年的大雪到下年的立春
            for (int i = 0, j = Lunar.JIE_QI_IN_USE.Length; i < j; i++)
            {
                // 精确的节气
                double t = 36525 * ShouXingUtil.saLonT((year + (17 + i) * 15d / 360) * ShouXingUtil.PI_2);
                t += ShouXingUtil.ONE_THIRD - ShouXingUtil.dtT(t);
                jieQiJulianDays.Add(t + Solar.J2000);
                // 按中午12点算的节气
                if (i > 0 && i < 28)
                {
                    jq[i - 1] = Math.Round(t);
                }
            }

            // 冬至前的初一
            double w = ShouXingUtil.calcShuo(jq[0]);
            if (w > jq[0])
            {
                w -= 29.5306;
            }
            // 递推每月初一
            for (int i = 0, j = hs.Length; i < j; i++)
            {
                hs[i] = ShouXingUtil.calcShuo(w + 29.5306 * i);
            }
            // 每月天数
            for (int i = 0, j = dayCounts.Length; i < j; i++)
            {
                dayCounts[i] = (int)(hs[i + 1] - hs[i]);
            }

            int currentYearLeap = -1;
            try
            {
                currentYearLeap = LEAP[currentYear];
            }
            catch { }
            if (-1 == currentYearLeap)
            {
                currentYearLeap = -1;
                if (hs[13] <= jq[24])
                {
                    int i = 1;
                    while (hs[i + 1] > jq[2 * i] && i < 13)
                    {
                        i++;
                    }
                    currentYearLeap = i;
                }
            }

            int prevYear = currentYear - 1;
            int prevYearLeap = -1;
            try
            {
                prevYearLeap = LEAP[prevYear];
            }
            catch { }
            prevYearLeap = -1 == prevYearLeap ? -1 : prevYearLeap - 12;

            int y = prevYear;
            int m = 11;
            for (int i = 0, j = dayCounts.Length; i < j; i++)
            {
                int cm = m;
                bool isNextLeap = false;
                if (y == currentYear && i == currentYearLeap)
                {
                    cm = -cm;
                }
                else if (y == prevYear && i == prevYearLeap)
                {
                    cm = -cm;
                }
                if (y == currentYear && i + 1 == currentYearLeap)
                {
                    isNextLeap = true;
                }
                else if (y == prevYear && i + 1 == prevYearLeap)
                {
                    isNextLeap = true;
                }
                this.months.Add(new LunarMonth(y, cm, dayCounts[i], hs[i] + Solar.J2000));
                if (!isNextLeap)
                {
                    m++;
                }
                if (m == 13)
                {
                    m = 1;
                    y++;
                }
            }
        }

        /// <summary>
        /// 获取年
        /// </summary>
        /// <returns>年</returns>
        public int getYear()
        {
            return year;
        }

        /// <summary>
        /// 获取天干序号，从0开始
        /// </summary>
        /// <returns>序号</returns>
        public int getGanIndex()
        {
            return ganIndex;
        }

        /// <summary>
        /// 获取地支序号，从0开始
        /// </summary>
        /// <returns>序号</returns>
        public int getZhiIndex()
        {
            return zhiIndex;
        }

        /// <summary>
        /// 获取天干
        /// </summary>
        /// <returns>天干</returns>
        public string getGan()
        {
            return LunarUtil.GAN[ganIndex + 1];
        }

        /// <summary>
        /// 获取地支
        /// </summary>
        /// <returns>地支</returns>
        public string getZhi()
        {
            return LunarUtil.ZHI[zhiIndex + 1];
        }

        /// <summary>
        /// 获取干支
        /// </summary>
        /// <returns>干支</returns>
        public string getGanZhi()
        {
            return getGan() + getZhi();
        }

        public List<LunarMonth> getMonths()
        {
            return months;
        }

        public List<Double> getJieQiJulianDays()
        {
            return jieQiJulianDays;
        }

        public LunarMonth getMonth(int lunarMonth)
        {
            foreach (LunarMonth m in months)
            {
                if (m.getYear() == year && m.getMonth() == lunarMonth)
                {
                    return m;
                }
            }
            return null;
        }

        public int getLeapMonth()
        {
            foreach (LunarMonth m in months)
            {
                if (m.getYear() == year && m.isLeap())
                {
                    return Math.Abs(m.getMonth());
                }
            }
            return 0;
        }

        public override string ToString()
        {
            return year + "";
        }

        public string toFullString()
        {
            return year + "年";
        }

        protected string getZaoByGan(int index, string name)
        {
            int offset = index - Solar.fromJulianDay(getMonth(1).getFirstJulianDay()).getLunar().getDayGanIndex();
            if (offset < 0)
            {
                offset += 10;
            }
            return new Regex("几", RegexOptions.Singleline).Replace(name, LunarUtil.NUMBER[offset + 1], 1);
        }

        protected string getZaoByZhi(int index, string name)
        {
            int offset = index - Solar.fromJulianDay(getMonth(1).getFirstJulianDay()).getLunar().getDayZhiIndex();
            if (offset < 0)
            {
                offset += 12;
            }
            return new Regex("几", RegexOptions.Singleline).Replace(name, LunarUtil.NUMBER[offset + 1], 1);
        }

        /// <summary>
        /// 获取几鼠偷粮
        /// </summary>
        /// <returns>几鼠偷粮</returns>
        public string getTouLiang()
        {
            return getZaoByZhi(0, "几鼠偷粮");
        }

        /// <summary>
        /// 获取草子几分
        /// </summary>
        /// <returns>草子几分</returns>
        public string getCaoZi()
        {
            return getZaoByZhi(0, "草子几分");
        }

        /// <summary>
        /// 获取耕田（正月第一个丑日是初几，就是几牛耕田）
        /// </summary>
        /// <returns>几牛耕田</returns>
        public string getGengTian()
        {
            return getZaoByZhi(1, "几牛耕田");
        }

        /// <summary>
        /// 获取花收几分
        /// </summary>
        /// <returns>花收几分</returns>
        public string getHuaShou()
        {
            return getZaoByZhi(3, "花收几分");
        }

        /// <summary>
        /// 获取治水（正月第一个辰日是初几，就是几龙治水）
        /// </summary>
        /// <returns>几龙治水</returns>
        public string getZhiShui()
        {
            return getZaoByZhi(4, "几龙治水");
        }

        /// <summary>
        /// 获取几马驮谷
        /// </summary>
        /// <returns>几马驮谷</returns>
        public string getTuoGu()
        {
            return getZaoByZhi(6, "几马驮谷");
        }

        /// <summary>
        /// 获取几鸡抢米
        /// </summary>
        /// <returns>几鸡抢米</returns>
        public string getQiangMi()
        {
            return getZaoByZhi(9, "几鸡抢米");
        }

        /// <summary>
        /// 获取几姑看蚕
        /// </summary>
        /// <returns>几姑看蚕</returns>
        public string getKanCan()
        {
            return getZaoByZhi(9, "几姑看蚕");
        }

        /// <summary>
        /// 获取几屠共猪
        /// </summary>
        /// <returns>几屠共猪</returns>
        public string getGongZhu()
        {
            return getZaoByZhi(11, "几屠共猪");
        }

        /// <summary>
        /// 获取甲田几分
        /// </summary>
        /// <returns>甲田几分</returns>
        public string getJiaTian()
        {
            return getZaoByGan(0, "甲田几分");
        }

        /// <summary>
        /// 获取分饼（正月第一个丙日是初几，就是几人分饼）
        /// </summary>
        /// <returns>几人分饼</returns>
        public string getFenBing()
        {
            return getZaoByGan(2, "几人分饼");
        }

        /// <summary>
        /// 获取得金（正月第一个辛日是初几，就是几日得金）
        /// </summary>
        /// <returns>几日得金</returns>
        public string getDeJin()
        {
            return getZaoByGan(7, "几日得金");
        }

        /// <summary>
        /// 获取几人几丙
        /// </summary>
        /// <returns>几人几丙</returns>
        public string getRenBing()
        {
            return getZaoByGan(2, getZaoByZhi(2, "几人几丙"));
        }

        /// <summary>
        /// 获取几人几锄
        /// </summary>
        /// <returns>几人几锄</returns>
        public string getRenChu()
        {
            return getZaoByGan(3, getZaoByZhi(2, "几人几锄"));
        }

        /// <summary>
        /// 获取三元
        /// </summary>
        /// <returns>元</returns>
        public string getYuan()
        {
            return YUAN[((year + 2696) / 60) % 3] + "元";
        }

        /// <summary>
        /// 获取九运
        /// </summary>
        /// <returns>运</returns>
        public string getYun()
        {
            return YUN[((year + 2696) / 20) % 9] + "运";
        }

        /// <summary>
        /// 获取九星
        /// </summary>
        /// <returns>九星</returns>
        public NineStar getNineStar()
        {
            int index = LunarUtil.getJiaZiIndex(getGanZhi()) + 1;
            int yuan = ((this.year + 2696) / 60) % 3;
            int offset = (62 + yuan * 3 - index) % 9;
            if (0 == offset)
            {
                offset = 9;
            }
            return NineStar.fromIndex(offset - 1);
        }

        /// <summary>
        /// 获取喜神方位
        /// </summary>
        /// <returns>方位，如艮</returns>
        public string getPositionXi()
        {
            return LunarUtil.POSITION_XI[ganIndex + 1];
        }

        /// <summary>
        /// 获取喜神方位描述
        /// </summary>
        /// <returns>方位描述，如东北</returns>
        public string getPositionXiDesc()
        {
            return LunarUtil.POSITION_DESC[getPositionXi()];
        }

        /// <summary>
        /// 获取阳贵神方位
        /// </summary>
        /// <returns>方位，如艮</returns>
        public string getPositionYangGui()
        {
            return LunarUtil.POSITION_YANG_GUI[ganIndex + 1];
        }

        /// <summary>
        /// 获取阳贵神方位描述
        /// </summary>
        /// <returns>方位描述，如东北</returns>
        public string getPositionYangGuiDesc()
        {
            return LunarUtil.POSITION_DESC[getPositionYangGui()];
        }

        /**
         * 获取阴贵神方位
         *
         * @return 阴贵神方位，如艮
         */
        public string getPositionYinGui()
        {
            return LunarUtil.POSITION_YIN_GUI[ganIndex + 1];
        }

        /// <summary>
        /// 获取阴贵神方位描述
        /// </summary>
        /// <returns>方位描述，如东北</returns>
        public string getPositionYinGuiDesc()
        {
            return LunarUtil.POSITION_DESC[getPositionYinGui()];
        }

        /// <summary>
        /// 获取福神方位（默认流派：2）
        /// </summary>
        /// <returns>方位，如艮</returns>
        public string getPositionFu()
        {
            return getPositionFu(2);
        }

        /// <summary>
        /// 获取福神方位
        /// </summary>
        /// <param name="sect">流派，1或2</param>
        /// <returns>方位，如艮</returns>
        public string getPositionFu(int sect)
        {
            return (1 == sect ? LunarUtil.POSITION_FU : LunarUtil.POSITION_FU_2)[ganIndex + 1];
        }

        /// <summary>
        /// 获取福神方位描述（默认流派：2）
        /// </summary>
        /// <returns>方位描述，如东北</returns>
        public string getPositionFuDesc()
        {
            return getPositionFuDesc(2);
        }

        /// <summary>
        /// 获取福神方位描述
        /// </summary>
        /// <param name="sect">流派，1或2</param>
        /// <returns>方位描述，如东北</returns>
        public string getPositionFuDesc(int sect)
        {
            return LunarUtil.POSITION_DESC[getPositionFu(sect)];
        }

        /// <summary>
        /// 获取财神方位
        /// </summary>
        /// <returns>方位，如艮</returns>
        public string getPositionCai()
        {
            return LunarUtil.POSITION_CAI[ganIndex + 1];
        }

        /// <summary>
        /// 获取财神方位描述
        /// </summary>
        /// <returns>方位描述，如东北</returns>
        public string getPositionCaiDesc()
        {
            return LunarUtil.POSITION_DESC[getPositionCai()];
        }

        /// <summary>
        /// 获取太岁方位
        /// </summary>
        /// <returns>方位，如艮</returns>
        public string getPositionTaiSui()
        {
            return LunarUtil.POSITION_TAI_SUI_YEAR[zhiIndex];
        }

        /// <summary>
        /// 获取太岁方位描述
        /// </summary>
        /// <returns>方位描述，如东北</returns>
        public string getPositionTaiSuiDesc()
        {
            return LunarUtil.POSITION_DESC[getPositionTaiSui()];
        }
    }
}
