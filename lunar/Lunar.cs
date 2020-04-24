using System;
using System.Collections.Generic;
using System.Text;
using com.nlf.calendar.util;

namespace com.nlf.calendar
{
    /// <summary>
    /// 农历日期
    /// </summary>
    public class Lunar
    {
        /** 1角度对应的弧度 */
        private const double RAD_PER_DEGREE = Math.PI / 180;
        /** 1弧度对应的角度 */
        private const double DEGREE_PER_RAD = 180 / Math.PI;
        /** 1弧度对应的角秒 */
        private const double SECOND_PER_RAD = 180 * 3600 / Math.PI;
        /** 节气表，国标以冬至为首个节气 */
        private static readonly string[] JIE_QI = { "冬至", "小寒", "大寒", "立春", "雨水", "惊蛰", "春分", "清明", "谷雨", "立夏", "小满", "芒种", "夏至", "小暑", "大暑", "立秋", "处暑", "白露", "秋分", "寒露", "霜降", "立冬", "小雪", "大雪" };
        /** 黄经周期项 */
        private static readonly double[] E10 = { 1.75347045673, 0.00000000000, 0.0000000000, 0.03341656456, 4.66925680417, 6283.0758499914, 0.00034894275, 4.62610241759, 12566.1516999828, 0.00003417571, 2.82886579606, 3.5231183490, 0.00003497056, 2.74411800971, 5753.3848848968, 0.00003135896, 3.62767041758, 77713.7714681205, 0.00002676218, 4.41808351397, 7860.4193924392, 0.00002342687, 6.13516237631, 3930.2096962196, 0.00001273166, 2.03709655772, 529.6909650946, 0.00001324292, 0.74246356352, 11506.7697697936, 0.00000901855, 2.04505443513, 26.2983197998, 0.00001199167, 1.10962944315, 1577.3435424478, 0.00000857223, 3.50849156957, 398.1490034082, 0.00000779786, 1.17882652114, 5223.6939198022, 0.00000990250, 5.23268129594, 5884.9268465832, 0.00000753141, 2.53339053818, 5507.5532386674, 0.00000505264, 4.58292563052, 18849.2275499742, 0.00000492379, 4.20506639861, 775.5226113240, 0.00000356655, 2.91954116867, 0.0673103028, 0.00000284125, 1.89869034186, 796.2980068164, 0.00000242810, 0.34481140906, 5486.7778431750, 0.00000317087, 5.84901952218, 11790.6290886588, 0.00000271039, 0.31488607649, 10977.0788046990, 0.00000206160, 4.80646606059, 2544.3144198834, 0.00000205385, 1.86947813692, 5573.1428014331, 0.00000202261, 2.45767795458, 6069.7767545534, 0.00000126184, 1.08302630210, 20.7753954924, 0.00000155516, 0.83306073807, 213.2990954380, 0.00000115132, 0.64544911683, 0.9803210682, 0.00000102851, 0.63599846727, 4694.0029547076, 0.00000101724, 4.26679821365, 7.1135470008, 0.00000099206, 6.20992940258, 2146.1654164752, 0.00000132212, 3.41118275555, 2942.4634232916, 0.00000097607, 0.68101272270, 155.4203994342, 0.00000085128, 1.29870743025, 6275.9623029906, 0.00000074651, 1.75508916159, 5088.6288397668, 0.00000101895, 0.97569221824, 15720.8387848784, 0.00000084711, 3.67080093025, 71430.6956181291, 0.00000073547, 4.67926565481, 801.8209311238, 0.00000073874, 3.50319443167, 3154.6870848956, 0.00000078756, 3.03698313141, 12036.4607348882, 0.00000079637, 1.80791330700, 17260.1546546904, 0.00000085803, 5.98322631256, 161000.6857376741, 0.00000056963, 2.78430398043, 6286.5989683404, 0.00000061148, 1.81839811024, 7084.8967811152, 0.00000069627, 0.83297596966, 9437.7629348870, 0.00000056116, 4.38694880779, 14143.4952424306, 0.00000062449, 3.97763880587, 8827.3902698748, 0.00000051145, 0.28306864501, 5856.4776591154, 0.00000055577, 3.47006009062, 6279.5527316424, 0.00000041036, 5.36817351402, 8429.2412664666, 0.00000051605, 1.33282746983, 1748.0164130670, 0.00000051992, 0.18914945834, 12139.5535091068, 0.00000049000, 0.48735065033, 1194.4470102246, 0.00000039200, 6.16832995016, 10447.3878396044, 0.00000035566, 1.77597314691, 6812.7668150860, 0.00000036770, 6.04133859347, 10213.2855462110, 0.00000036596, 2.56955238628, 1059.3819301892, 0.00000033291, 0.59309499459, 17789.8456197850, 0.00000035954, 1.70876111898, 2352.8661537718 };
        /** 黄经泊松1项 */
        private static readonly double[] E11 = { 6283.31966747491, 0.00000000000, 0.0000000000, 0.00206058863, 2.67823455584, 6283.0758499914, 0.00004303430, 2.63512650414, 12566.1516999828, 0.00000425264, 1.59046980729, 3.5231183490, 0.00000108977, 2.96618001993, 1577.3435424478, 0.00000093478, 2.59212835365, 18849.2275499742, 0.00000119261, 5.79557487799, 26.2983197998, 0.00000072122, 1.13846158196, 529.6909650946, 0.00000067768, 1.87472304791, 398.1490034082, 0.00000067327, 4.40918235168, 5507.5532386674, 0.00000059027, 2.88797038460, 5223.6939198022, 0.00000055976, 2.17471680261, 155.4203994342, 0.00000045407, 0.39803079805, 796.2980068164, 0.00000036369, 0.46624739835, 775.5226113240, 0.00000028958, 2.64707383882, 7.1135470008, 0.00000019097, 1.84628332577, 5486.7778431750, 0.00000020844, 5.34138275149, 0.9803210682, 0.00000018508, 4.96855124577, 213.2990954380, 0.00000016233, 0.03216483047, 2544.3144198834, 0.00000017293, 2.99116864949, 6275.9623029906 };
        /** 黄经泊松2项 */
        private static readonly double[] E12 = { 0.00052918870, 0.00000000000, 0.0000000000, 0.00008719837, 1.07209665242, 6283.0758499914, 0.00000309125, 0.86728818832, 12566.1516999828, 0.00000027339, 0.05297871691, 3.5231183490, 0.00000016334, 5.18826691036, 26.2983197998, 0.00000015752, 3.68457889430, 155.4203994342, 0.00000009541, 0.75742297675, 18849.2275499742, 0.00000008937, 2.05705419118, 77713.7714681205, 0.00000006952, 0.82673305410, 775.5226113240, 0.00000005064, 4.66284525271, 1577.3435424478 };
        private static readonly double[] E13 = { 0.00000289226, 5.84384198723, 6283.0758499914, 0.00000034955, 0.00000000000, 0.0000000000, 0.00000016819, 5.48766912348, 12566.1516999828 };
        private static readonly double[] E14 = { 0.00000114084, 3.14159265359, 0.0000000000, 0.00000007717, 4.13446589358, 6283.0758499914, 0.00000000765, 3.83803776214, 12566.1516999828 };
        private static readonly double[] E15 = { 0.00000000878, 3.14159265359, 0.0000000000 };
        /** 黄纬周期项 */
        private static readonly double[] E20 = { 0.00000279620, 3.19870156017, 84334.6615813083, 0.00000101643, 5.42248619256, 5507.5532386674, 0.00000080445, 3.88013204458, 5223.6939198022, 0.00000043806, 3.70444689758, 2352.8661537718, 0.00000031933, 4.00026369781, 1577.3435424478, 0.00000022724, 3.98473831560, 1047.7473117547, 0.00000016392, 3.56456119782, 5856.4776591154, 0.00000018141, 4.98367470263, 6283.0758499914, 0.00000014443, 3.70275614914, 9437.7629348870, 0.00000014304, 3.41117857525, 10213.2855462110 };
        private static readonly double[] E21 = { 0.00000009030, 3.89729061890, 5507.5532386674, 0.00000006177, 1.73038850355, 5223.6939198022 };
        /** 离心率 */
        private static readonly double[] GXC_E = { 0.016708634, -0.000042037, -0.0000001267 };
        /** 近点 */
        private static readonly double[] GXC_P = { 102.93735 / DEGREE_PER_RAD, 1.71946 / DEGREE_PER_RAD, 0.00046 / DEGREE_PER_RAD };
        /** 太平黄经 */
        private static readonly double[] GXC_L = { 280.4664567 / DEGREE_PER_RAD, 36000.76982779 / DEGREE_PER_RAD, 0.0003032028 / DEGREE_PER_RAD, 1 / 49931000 / DEGREE_PER_RAD, -1 / 153000000 / DEGREE_PER_RAD };
        /** 光行差常数 */
        private static readonly double GXC_K = 20.49552 / SECOND_PER_RAD;
        /** 章动表 */
        private static readonly double[] ZD = { 2.1824391966, -33.757045954, 0.0000362262, 3.7340E-08, -2.8793E-10, -171996, -1742, 92025, 89, 3.5069406862, 1256.663930738, 0.0000105845, 6.9813E-10, -2.2815E-10, -13187, -16, 5736, -31, 1.3375032491, 16799.418221925, -0.0000511866, 6.4626E-08, -5.3543E-10, -2274, -2, 977, -5, 4.3648783932, -67.514091907, 0.0000724525, 7.4681E-08, -5.7586E-10, 2062, 2, -895, 5, 0.0431251803, -628.301955171, 0.0000026820, 6.5935E-10, 5.5705E-11, -1426, 34, 54, -1, 2.3555557435, 8328.691425719, 0.0001545547, 2.5033E-07, -1.1863E-09, 712, 1, -7, 0, 3.4638155059, 1884.965885909, 0.0000079025, 3.8785E-11, -2.8386E-10, -517, 12, 224, -6, 5.4382493597, 16833.175267879, -0.0000874129, 2.7285E-08, -2.4750E-10, -386, -4, 200, 0, 3.6930589926, 25128.109647645, 0.0001033681, 3.1496E-07, -1.7218E-09, -301, 0, 129, -1, 3.5500658664, 628.361975567, 0.0000132664, 1.3575E-09, -1.7245E-10, 217, -5, -95, 3 };


        /// <summary>
        /// 农历年
        /// </summary>
        private int year;

        /// <summary>
        /// 农历月，闰月为负，即闰2月=-2
        /// </summary>
        private int month;

        /// <summary>
        /// 农历日
        /// </summary>
        private int day;

        /// <summary>
        /// 对应阳历
        /// </summary>
        private Solar solar;

        /// <summary>
        /// 相对于基准日的偏移天数
        /// </summary>
        private int dayOffset;

        /// <summary>
        /// 时对应的天干下标，0-9
        /// </summary>
        private int timeGanIndex;

        /// <summary>
        /// 时对应的地支下标，0-11
        /// </summary>
        private int timeZhiIndex;

        /// <summary>
        /// 日对应的天干下标，0-9
        /// </summary>
        private int dayGanIndex;

        /// <summary>
        /// 日对应的地支下标，0-11
        /// </summary>
        private int dayZhiIndex;

        /// <summary>
        /// 月对应的天干下标（以节交接当天起算），0-9
        /// </summary>
        private int monthGanIndex;

        /// <summary>
        /// 月对应的地支下标（以节交接当天起算），0-11
        /// </summary>
        private int monthZhiIndex;

        /// <summary>
        /// 月对应的天干下标（最精确的，供八字用，以节交接时刻起算），0-9
        /// </summary>
        private int monthGanIndexExact;

        /// <summary>
        /// 月对应的地支下标（最精确的，供八字用，以节交接时刻起算），0-11
        /// </summary>
        private int monthZhiIndexExact;

        /// <summary>
        /// 年对应的天干下标（国标，以正月初一为起点），0-9
        /// </summary>
        private int yearGanIndex;

        /// <summary>
        /// 年对应的地支下标（国标，以正月初一为起点），0-11
        /// </summary>
        private int yearZhiIndex;

        /// <summary>
        /// 年对应的天干下标（月干计算用，以立春为起点），0-9
        /// </summary>
        private int yearGanIndexByLiChun;

        /// <summary>
        /// 年对应的地支下标（月支计算用，以立春为起点），0-11
        /// </summary>
        private int yearZhiIndexByLiChun;

        /// <summary>
        /// 年对应的天干下标（最精确的，供八字用，以立春交接时刻为起点），0-9
        /// </summary>
        private int yearGanIndexExact;

        /// <summary>
        /// 年对应的地支下标（最精确的，供八字用，以立春交接时刻为起点），0-11
        /// </summary>
        private int yearZhiIndexExact;

        /// <summary>
        /// 周下标，0-6
        /// </summary>
        private int weekIndex;

        /// <summary>
        /// 阳历小时
        /// </summary>
        private int hour;

        /// <summary>
        /// 阳历分钟
        /// </summary>
        private int minute;

        /// <summary>
        /// 阳历秒钟
        /// </summary>
        private int second;

        /// <summary>
        /// 节气表
        /// </summary>
        private Dictionary<string, Solar> jieQi = new Dictionary<string, Solar>();

        /// <summary>
        /// 默认使用当前日期初始化
        /// </summary>
        public Lunar()
            : this(DateTime.Now)
        {
        }

        /// <summary>
        /// 通过农历年月日初始化
        /// </summary>
        /// <param name="lunarYear">年（农历）</param>
        /// <param name="lunarMonth">月（农历），1到12，闰月为负，即闰2月=-2</param>
        /// <param name="lunarDay">日（农历），1到31</param>
        public Lunar(int lunarYear, int lunarMonth, int lunarDay) : this(lunarYear, lunarMonth, lunarDay, 0, 0, 0) { }

        /// <summary>
        /// 通过农历年月日时初始化
        /// </summary>
        /// <param name="lunarYear">年（农历）</param>
        /// <param name="lunarMonth">月（农历），1到12，闰月为负，即闰2月=-2</param>
        /// <param name="lunarDay">日（农历），1到31</param>
        /// <param name="hour">小时（阳历）</param>
        /// <param name="minute">分钟（阳历）</param>
        /// <param name="second">秒钟（阳历）</param>
        public Lunar(int lunarYear, int lunarMonth, int lunarDay, int hour, int minute, int second)
        {
            this.year = lunarYear;
            this.month = lunarMonth;
            this.day = lunarDay;
            this.hour = hour;
            this.minute = minute;
            this.second = second;
            dayOffset = LunarUtil.computeAddDays(year, month, day);
            this.solar = toSolar();
            compute();
        }

        /// <summary>
        /// 通过阳历日期初始化
        /// </summary>
        /// <param name="date">阳历日期</param>
        public Lunar(DateTime date)
        {
            solar = new Solar(date);
            int y = solar.getYear();
            int m = solar.getMonth();
            int d = solar.getDay();
            int startYear, startMonth, startDay;
            int lunarYear, lunarMonth, lunarDay;
            if (y < 2000)
            {
                startYear = SolarUtil.BASE_YEAR;
                startMonth = SolarUtil.BASE_MONTH;
                startDay = SolarUtil.BASE_DAY;
                lunarYear = LunarUtil.BASE_YEAR;
                lunarMonth = LunarUtil.BASE_MONTH;
                lunarDay = LunarUtil.BASE_DAY;
            }
            else
            {
                startYear = SolarUtil.BASE_YEAR + 99;
                startMonth = 1;
                startDay = 1;
                lunarYear = LunarUtil.BASE_YEAR + 99;
                lunarMonth = 11;
                lunarDay = 25;
            }
            int diff = 0;
            for (int i = startYear; i < y; i++)
            {
                diff += 365;
                if (SolarUtil.isLeapYear(i))
                {
                    diff += 1;
                }
            }
            for (int i = startMonth; i < m; i++)
            {
                diff += SolarUtil.getDaysOfMonth(y, i);
            }
            diff += d - startDay;
            lunarDay += diff;
            int lastDate = LunarUtil.getDaysOfMonth(lunarYear, lunarMonth);
            while (lunarDay > lastDate)
            {
                lunarDay -= lastDate;
                lunarMonth = LunarUtil.nextMonth(lunarYear, lunarMonth);
                if (lunarMonth == 1)
                {
                    lunarYear++;
                }
                lastDate = LunarUtil.getDaysOfMonth(lunarYear, lunarMonth);
            }
            year = lunarYear;
            month = lunarMonth;
            day = lunarDay;
            hour = solar.getHour();
            minute = solar.getMinute();
            second = solar.getSecond();
            dayOffset = LunarUtil.computeAddDays(year, month, day);
            compute();
        }

        private Solar toSolar()
        {
            DateTime c = new DateTime(SolarUtil.BASE_YEAR, SolarUtil.BASE_MONTH - 1, SolarUtil.BASE_DAY, hour, minute, second);
            c.AddDays(dayOffset);
            return new Solar(c);
        }

        /// <summary>
        /// 计算节气表（冬至的太阳黄经是-90度或270度）
        /// </summary>
        private void computeJieQi()
        {
            //儒略日，冬至在阳历上一年，所以这里多减1年以从去年开始
            double jd = 365.2422 * (solar.getYear() - 2001);
            for (int i = 0, j = JIE_QI.Length; i < j; i++)
            {
                double t = calJieQi(jd + i * 15.2, i * 15 - 90) + Solar.J2000 + 8D / 24;
                jieQi.Add(JIE_QI[i], Solar.fromJulianDay(t));
            }
        }

        /// <summary>
        /// 计算干支纪年
        /// </summary>
        private void computeYear()
        {
            yearGanIndex = (year + LunarUtil.BASE_YEAR_GANZHI_INDEX) % 10;
            yearZhiIndex = (year + LunarUtil.BASE_YEAR_GANZHI_INDEX) % 12;

            //以立春作为新一年的开始的干支纪年
            int g = yearGanIndex;
            int z = yearZhiIndex;

            //精确的干支纪年，以立春交接时刻为准
            int gExact = yearGanIndex;
            int zExact = yearZhiIndex;

            if (year == solar.getYear())
            {
                //获取立春的阳历时刻
                Solar liChun = jieQi["立春"];
                //立春日期判断
                if (solar.toYmd().CompareTo(liChun.toYmd()) < 0)
                {
                    g--;
                    if (g < 0)
                    {
                        g += 10;
                    }
                    z--;
                    if (z < 0)
                    {
                        z += 12;
                    }
                }
                //立春交接时刻判断
                if (solar.toYmdhms().CompareTo(liChun.toYmdhms()) < 0)
                {
                    gExact--;
                    if (gExact < 0)
                    {
                        gExact += 10;
                    }
                    zExact--;
                    if (zExact < 0)
                    {
                        zExact += 12;
                    }
                }
            }
            yearGanIndexByLiChun = g;
            yearZhiIndexByLiChun = z;

            yearGanIndexExact = gExact;
            yearZhiIndexExact = zExact;
        }

        /**
         * 干支纪月计算
         */
        private void computeMonth()
        {
            Solar start = null;
            Solar end;
            //干偏移值（以立春当天起算）
            int gOffset = ((yearGanIndexByLiChun % 5 + 1) * 2) % 10;
            //干偏移值（以立春交接时刻起算）
            int gOffsetExact = ((yearGanIndexExact % 5 + 1) * 2) % 10;

            //序号：大雪到小寒之间-2，小寒到立春之间-1，立春之后0
            int index = -2;
            foreach (string jie in LunarUtil.JIE)
            {
                end = jieQi[jie];
                string ymd = solar.toYmd();
                string symd = null == start ? ymd : start.toYmd();
                string eymd = end.toYmd();
                if (ymd.CompareTo(symd) >= 0 && ymd.CompareTo(eymd) < 0)
                {
                    break;
                }
                start = end;
                index++;
            }
            if (index < 0)
            {
                index += 12;
            }

            monthGanIndex = (index + gOffset) % 10;
            monthZhiIndex = (index + LunarUtil.BASE_MONTH_ZHI_INDEX) % 12;

            //序号：大雪到小寒之间-2，小寒到立春之间-1，立春之后0
            int indexExact = -2;
            foreach (string jie in LunarUtil.JIE)
            {
                end = jieQi[jie];
                string time = solar.toYmdhms();
                string stime = null == start ? time : start.toYmdhms();
                string etime = end.toYmdhms();
                if (time.CompareTo(stime) >= 0 && time.CompareTo(etime) < 0)
                {
                    break;
                }
                start = end;
                indexExact++;
            }
            if (indexExact < 0)
            {
                indexExact += 12;
            }
            monthGanIndexExact = (indexExact + gOffsetExact) % 10;
            monthZhiIndexExact = (indexExact + LunarUtil.BASE_MONTH_ZHI_INDEX) % 12;
        }

        /// <summary>
        /// 干支纪日计算
        /// </summary>
        private void computeDay()
        {
            int addDays = (dayOffset + LunarUtil.BASE_DAY_GANZHI_INDEX) % 60;
            dayGanIndex = addDays % 10;
            dayZhiIndex = addDays % 12;
        }

        /// <summary>
        /// 干支纪时计算
        /// </summary>
        private void computeTime()
        {
            timeZhiIndex = LunarUtil.getTimeZhiIndex((hour < 10 ? "0" : "") + hour + ":" + (minute < 10 ? "0" : "") + minute);
            timeGanIndex = timeZhiIndex % 10;
        }

        /// <summary>
        /// 星期计算
        /// </summary>
        private void computeWeek()
        {
            weekIndex = (dayOffset + LunarUtil.BASE_WEEK_INDEX) % 7;
        }

        private void compute()
        {
            computeJieQi();
            computeYear();
            computeMonth();
            computeDay();
            computeTime();
            computeWeek();
        }

        /// <summary>
        /// 通过指定阳历日期获取农历
        /// </summary>
        /// <param name="date">阳历日期</param>
        /// <returns>农历</returns>
        public static Lunar fromDate(DateTime date)
        {
            return new Lunar(date);
        }

        /// <summary>
        /// 通过指定农历年月日获取农历
        /// </summary>
        /// <param name="lunarYear">年（农历）</param>
        /// <param name="lunarMonth">月（农历），1到12，闰月为负，即闰2月=-2</param>
        /// <param name="lunarDay">日（农历），1到31</param>
        /// <returns>农历</returns>
        public static Lunar fromYmd(int lunarYear, int lunarMonth, int lunarDay)
        {
            return new Lunar(lunarYear, lunarMonth, lunarDay);
        }

        /// <summary>
        /// 通过指定农历年月日获取农历
        /// </summary>
        /// <param name="lunarYear">年（农历）</param>
        /// <param name="lunarMonth">月（农历），1到12，闰月为负，即闰2月=-2</param>
        /// <param name="lunarDay">日（农历），1到31</param>
        /// <param name="hour">小时（阳历）</param>
        /// <param name="minute">分钟（阳历）</param>
        /// <param name="second">秒钟（阳历）</param>
        /// <returns>农历</returns>
        public static Lunar fromYmdHms(int lunarYear, int lunarMonth, int lunarDay, int hour, int minute, int second)
        {
            return new Lunar(lunarYear, lunarMonth, lunarDay, hour, minute, second);
        }

        [Obsolete("This method is obsolete, use method getYearGan instead")]
        public string getGan()
        {
            return getYearGan();
        }

        /// <summary>
        /// 获取年份的天干（以正月初一作为新年的开始）
        /// </summary>
        /// <returns>天干，如辛</returns>
        public string getYearGan()
        {
            return LunarUtil.GAN[yearGanIndex + 1];
        }

        /// <summary>
        /// 获取年份的天干（以立春当天作为新年的开始）
        /// </summary>
        /// <returns>天干，如辛</returns>
        public string getYearGanByLiChun()
        {
            return LunarUtil.GAN[yearGanIndexByLiChun + 1];
        }

        /// <summary>
        /// 获取最精确的年份天干（以立春交接的时刻作为新年的开始）
        /// </summary>
        /// <returns>天干，如辛</returns>
        public string getYearGanExact()
        {
            return LunarUtil.GAN[yearGanIndexExact + 1];
        }

        /// <summary>
        /// 获取月天干
        /// </summary>
        /// <returns>月天干，如己</returns>
        public string getMonthGan()
        {
            return LunarUtil.GAN[monthGanIndex + 1];
        }

        /// <summary>
        /// 获取精确的月天干（以节交接时刻起算）
        /// </summary>
        /// <returns>月天干，如己</returns>
        public string getMonthGanExact()
        {
            return LunarUtil.GAN[monthGanIndexExact + 1];
        }

        /// <summary>
        /// 获取日天干
        /// </summary>
        /// <returns>日天干，如甲</returns>
        public string getDayGan()
        {
            return LunarUtil.GAN[dayGanIndex + 1];
        }

        [Obsolete("This method is obsolete, use method getYearZhi instead")]
        public string getZhi()
        {
            return getYearZhi();
        }

        /// <summary>
        /// 获取年份的地支（以正月初一作为新年的开始）
        /// </summary>
        /// <returns>地支，如亥</returns>
        public string getYearZhi()
        {
            return LunarUtil.ZHI[yearZhiIndex + 1];
        }

        /// <summary>
        /// 获取年份的地支（以立春当天作为新年的开始）
        /// </summary>
        /// <returns>地支，如亥</returns>
        public string getYearZhiByLiChun()
        {
            return LunarUtil.ZHI[yearZhiIndexByLiChun + 1];
        }

        /// <summary>
        /// 获取最精确的年份地支（以立春交接的时刻作为新年的开始）
        /// </summary>
        /// <returns>地支，如亥</returns>
        public string getYearZhiExact()
        {
            return LunarUtil.ZHI[yearZhiIndexExact + 1];
        }

        /// <summary>
        /// 获取月地支
        /// </summary>
        /// <returns>月地支，如卯</returns>
        public string getMonthZhi()
        {
            return LunarUtil.ZHI[monthZhiIndex + 1];
        }

        /// <summary>
        /// 获取精确的月地支（以节交接时刻起算）
        /// </summary>
        /// <returns>月地支，如卯</returns>
        public string getMonthZhiExact()
        {
            return LunarUtil.ZHI[monthZhiIndexExact + 1];
        }

        /// <summary>
        /// 获取日地支
        /// </summary>
        /// <returns>日地支，如卯</returns>
        public string getDayZhi()
        {
            return LunarUtil.ZHI[dayZhiIndex + 1];
        }

        /// <summary>
        /// 获取干支纪年（年柱）（以正月初一作为新年的开始）
        /// </summary>
        /// <returns>年份的干支（年柱），如辛亥</returns>
        public string getYearInGanZhi()
        {
            return getYearGan() + getYearZhi();
        }

        /// <summary>
        /// 获取干支纪年（年柱）（以立春当天作为新年的开始）
        /// </summary>
        /// <returns>年份的干支（年柱），如辛亥</returns>
        public string getYearInGanZhiByLiChun()
        {
            return getYearGanByLiChun() + getYearZhiByLiChun();
        }

        /// <summary>
        /// 获取干支纪年（年柱）（以立春交接的时刻作为新年的开始）
        /// </summary>
        /// <returns>年份的干支（年柱），如辛亥</returns>
        public string getYearInGanZhiExact()
        {
            return getYearGanExact() + getYearZhiExact();
        }

        /// <summary>
        /// 获取干支纪月（月柱）（以节交接当天起算），月天干口诀：甲己丙寅首，乙庚戊寅头。丙辛从庚寅，丁壬壬寅求，戊癸甲寅居，周而复始流。月地支：正月起寅。
        /// </summary>
        /// <returns>干支纪月（月柱），如己卯</returns>
        public string getMonthInGanZhi()
        {
            return getMonthGan() + getMonthZhi();
        }

        /// <summary>
        /// 获取精确的干支纪月（月柱）（以节交接时刻起算），月天干口诀：甲己丙寅首，乙庚戊寅头。丙辛从庚寅，丁壬壬寅求，戊癸甲寅居，周而复始流。月地支：正月起寅。
        /// </summary>
        /// <returns>干支纪月（月柱），如己卯</returns>
        public string getMonthInGanZhiExact()
        {
            return getMonthGanExact() + getMonthZhiExact();
        }

        /// <summary>
        /// 获取干支纪日（日柱）
        /// </summary>
        /// <returns>干支纪日（日柱），如己卯</returns>
        public string getDayInGanZhi()
        {
            return getDayGan() + getDayZhi();
        }

        [Obsolete("This method is obsolete, use method getYearShengXiao instead")]
        public string getShengxiao()
        {
            return getYearShengXiao();
        }


        /// <summary>
        /// 获取年生肖（以正月初一起算）
        /// </summary>
        /// <returns>年生肖，如虎</returns>
        public string getYearShengXiao()
        {
            return LunarUtil.SHENGXIAO[yearZhiIndex + 1];
        }

        /// <summary>
        /// 获取年生肖（以立春当天起算）
        /// </summary>
        /// <returns>年生肖，如虎</returns>
        public string getYearShengXiaoByLiChun()
        {
            return LunarUtil.SHENGXIAO[yearZhiIndexByLiChun + 1];
        }

        /// <summary>
        /// 获取精确的年生肖（以立春交接时刻起算）
        /// </summary>
        /// <returns>年生肖，如虎</returns>
        public string getYearShengXiaoExact()
        {
            return LunarUtil.SHENGXIAO[yearZhiIndexExact + 1];
        }

        /// <summary>
        /// 获取月生肖
        /// </summary>
        /// <returns>月生肖，如虎</returns>
        public string getMonthShengXiao()
        {
            return LunarUtil.SHENGXIAO[monthZhiIndex + 1];
        }

        /// <summary>
        /// 获取日生肖
        /// </summary>
        /// <returns>日生肖，如虎</returns>
        public string getDayShengXiao()
        {
            return LunarUtil.SHENGXIAO[dayZhiIndex + 1];
        }

        /// <summary>
        /// 获取时辰生肖
        /// </summary>
        /// <returns>时辰生肖，如虎</returns>
        public string getTimeShengXiao()
        {
            return LunarUtil.SHENGXIAO[timeZhiIndex + 1];
        }

        /// <summary>
        /// 获取中文的年
        /// </summary>
        /// <returns>中文年，如二零零一</returns>
        public string getYearInChinese()
        {
            char[] y = (year + "").ToCharArray();
            StringBuilder s = new StringBuilder();
            for (int i = 0, j = y.Length; i < j; i++)
            {
                s.Append(LunarUtil.NUMBER[y[i] - '0']);
            }
            return s.ToString();
        }

        /// <summary>
        /// 获取中文的月
        /// </summary>
        /// <returns>中文月，如正</returns>
        public string getMonthInChinese()
        {
            return (month < 0 ? "闰" : "") + LunarUtil.MONTH[Math.Abs(month)];
        }

        /// <summary>
        /// 获取中文日
        /// </summary>
        /// <returns>中文日，如初一</returns>
        public string getDayInChinese()
        {
            return LunarUtil.DAY[day];
        }

        /// <summary>
        /// 获取时辰（地支）
        /// </summary>
        /// <returns>时辰（地支）</returns>
        public string getTimeZhi()
        {
            return LunarUtil.ZHI[timeZhiIndex + 1];
        }

        /// <summary>
        /// 获取时辰（天干）
        /// </summary>
        /// <returns>时辰（天干）</returns>
        public string getTimeGan()
        {
            return LunarUtil.GAN[timeGanIndex + 1];
        }

        /// <summary>
        /// 获取时辰干支（时柱）
        /// </summary>
        /// <returns>时辰干支（时柱）</returns>
        public string getTimeInGanZhi()
        {
            return getTimeGan() + getTimeZhi();
        }

        /// <summary>
        /// 获取季节
        /// </summary>
        /// <returns>农历季节</returns>
        public string getSeason()
        {
            return LunarUtil.SEASON[Math.Abs(month)];
        }

        private double mrad(double rad)
        {
            double pi2 = 2 * Math.PI;
            rad = rad % pi2;
            return rad < 0 ? rad + pi2 : rad;
        }

        private void gxc(double t, double[] pos)
        {
            double t1 = t / 36525;
            double t2 = t1 * t1;
            double t3 = t2 * t1;
            double t4 = t3 * t1;
            double l = GXC_L[0] + GXC_L[1] * t1 + GXC_L[2] * t2 + GXC_L[3] * t3 + GXC_L[4] * t4;
            double p = GXC_P[0] + GXC_P[1] * t1 + GXC_P[2] * t2;
            double e = GXC_E[0] + GXC_E[1] * t1 + GXC_E[2] * t2;
            double dl = l - pos[0], dp = p - pos[0];
            pos[0] -= GXC_K * (Math.Cos(dl) - e * Math.Cos(dp)) / Math.Cos(pos[1]);
            pos[1] -= GXC_K * Math.Sin(pos[1]) * (Math.Sin(dl) - e * Math.Sin(dp));
            pos[0] = mrad(pos[0]);
        }

        private double enn(double[] f, double ennt)
        {
            double v = 0;
            for (int i = 0, j = f.Length; i < j; i += 3)
            {
                v += f[i] * Math.Cos(f[i + 1] + ennt * f[i + 2]);
            }
            return v;
        }

        /// <summary>
        /// 计算日心坐标中地球的位置
        /// </summary>
        /// <param name="t">儒略日</param>
        /// <returns>地球坐标</returns>
        private double[] calEarth(double t)
        {
            double t1 = t / 365250;
            double[] r = new double[2];
            double t2 = t1 * t1, t3 = t2 * t1, t4 = t3 * t1, t5 = t4 * t1;
            r[0] = mrad(enn(E10, t1) + enn(E11, t1) * t1 + enn(E12, t1) * t2 + enn(E13, t1) * t3 + enn(E14, t1) * t4 + enn(E15, t1) * t5);
            r[1] = enn(E20, t1) + enn(E21, t1) * t1;
            return r;
        }

        /// <summary>
        /// 计算黄经章动
        /// </summary>
        /// <param name="t">J2000起算儒略日数</param>
        /// <returns>黄经章动</returns>
        private double hjzd(double t)
        {
            double lon = 0;
            double t1 = t / 36525;
            double c, t2 = t1 * t1, t3 = t2 * t1, t4 = t3 * t1;
            for (int i = 0, j = ZD.Length; i < j; i += 9)
            {
                c = ZD[i] + ZD[i + 1] * t1 + ZD[i + 2] * t2 + ZD[i + 3] * t3 + ZD[i + 4] * t4;
                lon += (ZD[i + 5] + ZD[i + 6] * t1 / 10) * Math.Sin(c);
            }
            lon /= SECOND_PER_RAD * 10000;
            return lon;
        }

        /// <summary>
        /// 地心坐标中的日月位置计算（计算t时刻太阳黄经与角度的差）
        /// </summary>
        /// <param name="t">J2000起算儒略日数</param>
        /// <param name="rad">弧度</param>
        /// <returns>角度差</returns>
        private double calRad(double t, double rad)
        {
            // 计算太阳真位置(先算出日心坐标中地球的位置)
            double[] pos = calEarth(t);
            pos[0] += Math.PI;
            // 转为地心坐标
            pos[1] = -pos[1];
            // 补周年光行差
            gxc(t, pos);
            // 补黄经章动
            pos[0] += hjzd(t);
            return mrad(rad - pos[0]);
        }

        /// <summary>
        /// 太阳黄经达某角度的时刻计算(用于节气计算)
        /// </summary>
        /// <param name="t1">J2000起算儒略日数</param>
        /// <param name="degree">角度</param>
        /// <returns>时刻</returns>
        private double calJieQi(double t1, double degree)
        {
            // 对于节气计算,应满足t在t1到t1+360天之间,对于Y年第n个节气(n=0是春分),t1可取值Y*365.2422+n*15.2
            double t2 = t1, t = 0, v;
            // 在t1到t2范围内求解(范气360天范围),结果置于t
            t2 += 360;
            // 待搜索目标角
            double rad = degree * RAD_PER_DEGREE;
            // 利用截弦法计算
            // v1,v2为t1,t2时对应的黄经
            double v1 = calRad(t1, rad);
            double v2 = calRad(t2, rad);
            // 减2pi作用是将周期性角度转为连续角度
            if (v1 < v2)
            {
                v2 -= 2 * Math.PI;
            }
            // k是截弦的斜率
            double k = 1, k2;
            // 快速截弦求根,通常截弦三四次就已达所需精度
            for (int i = 0; i < 10; i++)
            {
                // 算出斜率
                k2 = (v2 - v1) / (t2 - t1);
                // 差商可能为零,应排除
                if (Math.Abs(k2) > 1e-15)
                {
                    k = k2;
                }
                t = t1 - v1 / k;
                // 直线逼近法求根(直线方程的根)
                v = calRad(t, rad);
                // 一次逼近后,v1就已接近0,如果很大,则应减1周
                if (v > 1)
                {
                    v -= 2 * Math.PI;
                }
                // 已达精度
                if (Math.Abs(v) < 1e-8)
                {
                    break;
                }
                t1 = t2;
                v1 = v2;
                t2 = t;
                // 下一次截弦
                v2 = v;
            }
            return t;
        }

        /// <summary>
        /// 获取节
        /// </summary>
        /// <returns>节</returns>
        public string getJie()
        {
            foreach (string jie in LunarUtil.JIE)
            {
                Solar d = jieQi[jie];
                if (d.getYear() == solar.getYear() && d.getMonth() == solar.getMonth() && d.getDay() == solar.getDay())
                {
                    return jie;
                }
            }
            return "";
        }

        /// <summary>
        /// 获取气
        /// </summary>
        /// <returns>气</returns>
        public string getQi()
        {
            foreach (string qi in LunarUtil.QI)
            {
                Solar d = jieQi[qi];
                if (d.getYear() == solar.getYear() && d.getMonth() == solar.getMonth() && d.getDay() == solar.getDay())
                {
                    return qi;
                }
            }
            return "";
        }

        /// <summary>
        /// 获取星期，0代表周日，1代表周一
        /// </summary>
        /// <returns>0123456</returns>
        public int getWeek()
        {
            return weekIndex;
        }

        /// <summary>
        /// 获取星期的中文
        /// </summary>
        /// <returns>日一二三四五六</returns>
        public string getWeekInChinese()
        {
            return SolarUtil.WEEK[getWeek()];
        }

        /// <summary>
        /// 获取宿
        /// </summary>
        /// <returns>宿</returns>
        public string getXiu()
        {
            return LunarUtil.XIU[getDayZhi() + getWeek()];
        }

        /// <summary>
        /// 获取宿吉凶
        /// </summary>
        /// <returns>吉/凶</returns>
        public string getXiuLuck()
        {
            return LunarUtil.XIU_LUCK[getXiu()];
        }

        /// <summary>
        /// 获取宿歌诀
        /// </summary>
        /// <returns>宿歌诀</returns>
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

        /// <summary>
        /// 获取节日，有可能一天会有多个节日
        /// </summary>
        /// <returns></returns>
        public List<string> getFestivals()
        {
            List<string> l = new List<string>();
            try
            {
                l.Add(LunarUtil.FESTIVAL[month + "-" + day]);
            }
            catch { }
            return l;
        }

        /// <summary>
        /// 获取非正式的节日，有可能一天会有多个节日
        /// </summary>
        /// <returns>非正式的节日列表，如中元节</returns>
        public List<string> getOtherFestivals()
        {
            List<string> l = new List<string>();
            try
            {
                l.AddRange(LunarUtil.OTHER_FESTIVAL[month + "-" + day]);
            }
            catch { }
            return l;
        }

        /// <summary>
        /// 获取彭祖百忌天干
        /// </summary>
        /// <returns>彭祖百忌天干</returns>
        public string getPengZuGan()
        {
            return LunarUtil.PENGZU_GAN[dayGanIndex + 1];
        }

        /// <summary>
        /// 获取彭祖百忌地支
        /// </summary>
        /// <returns>彭祖百忌地支</returns>
        public string getPengZuZhi()
        {
            return LunarUtil.PENGZU_ZHI[dayZhiIndex + 1];
        }

        /// <summary>
        /// 获取喜神方位
        /// </summary>
        /// <returns>喜神方位，如艮</returns>
        public string getPositionXi()
        {
            return LunarUtil.POSITION_XI[dayGanIndex + 1];
        }

        /// <summary>
        /// 获取喜神方位描述
        /// </summary>
        /// <returns>喜神方位描述，如东北</returns>
        public string getPositionXiDesc()
        {
            return LunarUtil.POSITION_DESC[getPositionXi()];
        }

        /// <summary>
        /// 获取阳贵神方位
        /// </summary>
        /// <returns>阳贵神方位，如艮</returns>
        public string getPositionYangGui()
        {
            return LunarUtil.POSITION_YANG_GUI[dayGanIndex + 1];
        }

        /// <summary>
        /// 获取阳贵神方位描述
        /// </summary>
        /// <returns>阳贵神方位描述，如东北</returns>
        public string getPositionYangGuiDesc()
        {
            return LunarUtil.POSITION_DESC[getPositionYangGui()];
        }

        /// <summary>
        /// 获取阴贵神方位
        /// </summary>
        /// <returns>阴贵神方位，如艮</returns>
        public string getPositionYinGui()
        {
            return LunarUtil.POSITION_YIN_GUI[dayGanIndex + 1];
        }

        /// <summary>
        /// 获取阴贵神方位描述
        /// </summary>
        /// <returns>阴贵神方位描述，如东北</returns>
        public string getPositionYinGuiDesc()
        {
            return LunarUtil.POSITION_DESC[getPositionYinGui()];
        }

        /// <summary>
        /// 获取福神方位
        /// </summary>
        /// <returns>福神方位，如艮</returns>
        public string getPositionFu()
        {
            return LunarUtil.POSITION_FU[dayGanIndex + 1];
        }

        /// <summary>
        /// 获取福神方位描述
        /// </summary>
        /// <returns>福神方位描述，如东北</returns>
        public string getPositionFuDesc()
        {
            return LunarUtil.POSITION_DESC[getPositionFu()];
        }

        /// <summary>
        /// 获取财神方位
        /// </summary>
        /// <returns>财神方位，如艮</returns>
        public string getPositionCai()
        {
            return LunarUtil.POSITION_CAI[dayGanIndex + 1];
        }

        /// <summary>
        /// 获取财神方位描述
        /// </summary>
        /// <returns>财神方位描述，如东北</returns>
        public string getPositionCaiDesc()
        {
            return LunarUtil.POSITION_DESC[getPositionCai()];
        }

        /// <summary>
        /// 获取冲
        /// </summary>
        /// <returns>冲，如申</returns>
        public string getChong()
        {
            return LunarUtil.CHONG[dayZhiIndex + 1];
        }

        /// <summary>
        /// 获取无情之克的冲天干
        /// </summary>
        /// <returns>无情之克的冲天干，如甲</returns>
        public string getChongGan()
        {
            return LunarUtil.CHONG_GAN[dayGanIndex + 1];
        }

        /// <summary>
        /// 获取有情之克的冲天干
        /// </summary>
        /// <returns>有情之克的冲天干，如甲</returns>
        public string getChongGanTie()
        {
            return LunarUtil.CHONG_GAN_TIE[dayGanIndex + 1];
        }

        /// <summary>
        /// 获取冲生肖
        /// </summary>
        /// <returns>冲生肖，如猴</returns>
        public string getChongShengXiao()
        {
            string chong = getChong();
            for (int i = 0, j = LunarUtil.ZHI.Length; i < j; i++)
            {
                if (LunarUtil.ZHI[i].Equals(chong))
                {
                    return LunarUtil.SHENGXIAO[i];
                }
            }
            return "";
        }

        /// <summary>
        /// 获取冲描述
        /// </summary>
        /// <returns>冲描述，如(壬申)猴</returns>
        public string getChongDesc()
        {
            return "(" + getChongGan() + getChong() + ")" + getChongShengXiao();
        }

        /// <summary>
        /// 获取煞
        /// </summary>
        /// <returns>煞，如北</returns>
        public string getSha()
        {
            return LunarUtil.SHA[getDayZhi()];
        }

        /// <summary>
        /// 获取年纳音
        /// </summary>
        /// <returns>年纳音，如剑锋金</returns>
        public string getYearNaYin()
        {
            return LunarUtil.NAYIN[getYearInGanZhi()];
        }

        /// <summary>
        /// 获取月纳音
        /// </summary>
        /// <returns>月纳音，如剑锋金</returns>
        public string getMonthNaYin()
        {
            return LunarUtil.NAYIN[getMonthInGanZhi()];
        }

        /// <summary>
        /// 获取日纳音
        /// </summary>
        /// <returns>日纳音，如剑锋金</returns>
        public string getDayNaYin()
        {
            return LunarUtil.NAYIN[getDayInGanZhi()];
        }

        /// <summary>
        /// 获取时辰纳音
        /// </summary>
        /// <returns>时辰纳音，如剑锋金</returns>
        public string getTimeNaYin()
        {
            return LunarUtil.NAYIN[getTimeInGanZhi()];
        }

        /// <summary>
        /// 获取八字，男性也称乾造，女性也称坤造（以立春交接时刻作为新年的开始）
        /// </summary>
        /// <returns>八字（男性也称乾造，女性也称坤造）</returns>
        public List<string> getBaZi()
        {
            List<string> l = new List<string>(4);
            string timeGan = LunarUtil.GAN[(dayGanIndex % 5 * 12 + timeZhiIndex) % 10 + 1];
            l.Add(getYearInGanZhiExact());
            l.Add(getMonthInGanZhiExact());
            l.Add(getDayInGanZhi());
            l.Add(timeGan + getTimeZhi());
            return l;
        }

        /// <summary>
        /// 获取八字五行
        /// </summary>
        /// <returns>八字五行</returns>
        public List<string> getBaZiWuXing()
        {
            List<string> baZi = getBaZi();
            List<string> l = new List<string>(baZi.Count);
            foreach (string ganZhi in baZi)
            {
                string gan = ganZhi.Substring(0, 1);
                string zhi = ganZhi.Substring(1);
                l.Add(LunarUtil.WU_XING_GAN[gan] + LunarUtil.WU_XING_ZHI[zhi]);
            }
            return l;
        }

        /// <summary>
        /// 获取八字纳音
        /// </summary>
        /// <returns>八字纳音</returns>
        public List<string> getBaZiNaYin()
        {
            List<string> baZi = getBaZi();
            List<string> l = new List<string>(baZi.Count);
            foreach (string ganZhi in baZi)
            {
                l.Add(LunarUtil.NAYIN[ganZhi]);
            }
            return l;
        }

        /// <summary>
        /// 获取八字天干十神，日柱十神为日主，其余三柱根据天干十神表查询
        /// </summary>
        /// <returns>八字天干十神</returns>
        public List<string> getBaZiShiShenGan()
        {
            List<string> baZi = getBaZi();
            string yearGan = baZi[0].Substring(0, 1);
            string monthGan = baZi[1].Substring(0, 1);
            string dayGan = baZi[2].Substring(0, 1);
            string timeGan = baZi[3].Substring(0, 1);
            List<string> l = new List<string>(baZi.Count);
            l.Add(LunarUtil.SHI_SHEN_GAN[dayGan + yearGan]);
            l.Add(LunarUtil.SHI_SHEN_GAN[dayGan + monthGan]);
            l.Add("日主");
            l.Add(LunarUtil.SHI_SHEN_GAN[dayGan + timeGan]);
            return l;
        }

        /// <summary>
        /// 获取八字地支十神，根据地支十神表查询
        /// </summary>
        /// <returns>八字地支十神</returns>
        public List<string> getBaZiShiShenZhi()
        {
            List<string> baZi = getBaZi();
            string dayGan = baZi[2].Substring(0, 1);
            List<string> l = new List<string>(baZi.Count);
            foreach (string ganZhi in baZi)
            {
                string zhi = ganZhi.Substring(1);
                l.Add(LunarUtil.SHI_SHEN_ZHI[dayGan + zhi + LunarUtil.ZHI_HIDE_GAN[zhi][0]]);
            }
            return l;
        }

        /// <summary>
        /// 获取十二执星：建、除、满、平、定、执、破、危、成、收、开、闭。当月支与日支相同即为建，依次类推
        /// </summary>
        /// <returns>执星</returns>
        public string getZhiXing()
        {
            int offset = dayZhiIndex - monthZhiIndex;
            if (offset < 0)
            {
                offset += 12;
            }
            return LunarUtil.ZHI_XING[offset + 1];
        }

        /// <summary>
        /// 获取值日天神
        /// </summary>
        /// <returns>值日天神</returns>
        public string getDayTianShen()
        {
            string monthZhi = getMonthZhi();
            int offset = LunarUtil.MONTH_ZHI_TIAN_SHEN_OFFSET[monthZhi];
            return LunarUtil.TIAN_SHEN[(dayZhiIndex + offset) % 12 + 1];
        }

        /// <summary>
        /// 获取值日天神类型：黄道/黑道
        /// </summary>
        /// <returns>值日天神类型：黄道/黑道</returns>
        public string getDayTianShenType()
        {
            return LunarUtil.TIAN_SHEN_TYPE[getDayTianShen()];
        }

        /// <summary>
        /// 获取值日天神吉凶
        /// </summary>
        /// <returns>吉/凶</returns>
        public string getDayTianShenLuck()
        {
            return LunarUtil.TIAN_SHEN_TYPE_LUCK[getDayTianShenType()];
        }

        /// <summary>
        /// 获取逐日胎神方位
        /// </summary>
        /// <returns>逐日胎神方位</returns>
        public string getDayPositionTai()
        {
            int offset = dayGanIndex - dayZhiIndex;
            if (offset < 0)
            {
                offset += 12;
            }
            return LunarUtil.POSITION_TAI_DAY[offset * 5 + dayGanIndex];
        }

        /// <summary>
        /// 获取逐月胎神方位，闰月无
        /// </summary>
        /// <returns>逐月胎神方位</returns>
        public string getMonthPositionTai()
        {
            if (month < 0)
            {
                return "";
            }
            return LunarUtil.POSITION_TAI_MONTH[month - 1];
        }

        public Dictionary<string, Solar> getJieQiTable()
        {
            return jieQi;
        }

        public string toFullString()
        {
            StringBuilder s = new StringBuilder();
            s.Append(ToString());
            s.Append(" ");
            s.Append(getYearInGanZhi());
            s.Append("(");
            s.Append(getYearShengXiao());
            s.Append(")年 ");
            s.Append(getMonthInGanZhi());
            s.Append("(");
            s.Append(getMonthShengXiao());
            s.Append(")月 ");
            s.Append(getDayInGanZhi());
            s.Append("(");
            s.Append(getDayShengXiao());
            s.Append(")日 ");
            s.Append(getTimeZhi());
            s.Append("(");
            s.Append(getTimeShengXiao());
            s.Append(")时 纳音[");
            s.Append(getYearNaYin());
            s.Append(" ");
            s.Append(getMonthNaYin());
            s.Append(" ");
            s.Append(getDayNaYin());
            s.Append(" ");
            s.Append(getTimeNaYin());
            s.Append("] 星期");
            s.Append(getWeekInChinese());
            foreach (string f in getFestivals())
            {
                s.Append(" (");
                s.Append(f);
                s.Append(")");
            }
            foreach (string f in getOtherFestivals())
            {
                s.Append(" (");
                s.Append(f);
                s.Append(")");
            }
            string jq = getJie() + getQi();
            if (jq.Length > 0)
            {
                s.Append(" [");
                s.Append(jq);
                s.Append("]");
            }
            s.Append(" ");
            s.Append(getGong());
            s.Append("方");
            s.Append(getShou());
            s.Append(" 星宿[");
            s.Append(getXiu());
            s.Append(getZheng());
            s.Append(getAnimal());
            s.Append("](");
            s.Append(getXiuLuck());
            s.Append(") 彭祖百忌[");
            s.Append(getPengZuGan());
            s.Append(" ");
            s.Append(getPengZuZhi());
            s.Append("] 喜神方位[");
            s.Append(getPositionXi());
            s.Append("](");
            s.Append(getPositionXiDesc());
            s.Append(") 阳贵神方位[");
            s.Append(getPositionYangGui());
            s.Append("](");
            s.Append(getPositionYangGuiDesc());
            s.Append(") 阴贵神方位[");
            s.Append(getPositionYinGui());
            s.Append("](");
            s.Append(getPositionYinGuiDesc());
            s.Append(") 福神方位[");
            s.Append(getPositionFu());
            s.Append("](");
            s.Append(getPositionFuDesc());
            s.Append(") 财神方位[");
            s.Append(getPositionCai());
            s.Append("](");
            s.Append(getPositionCaiDesc());
            s.Append(") 冲[");
            s.Append(getChongDesc());
            s.Append("] 煞[");
            s.Append(getSha());
            s.Append("]");
            return s.ToString();
        }

        public override string ToString()
        {
            return getYearInChinese() + "年" + getMonthInChinese() + "月" + getDayInChinese();
        }

        /// <summary>
        /// 获取年份
        /// </summary>
        /// <returns>年份，如2015</returns>
        public int getYear()
        {
            return year;
        }

        /// <summary>
        /// 获取月份
        /// </summary>
        /// <returns>1到12，负数为闰月</returns>
        public int getMonth()
        {
            return month;
        }

        /// <summary>
        /// 获取日期
        /// </summary>
        /// <returns>日期</returns>
        public int getDay()
        {
            return day;
        }

        /// <summary>
        /// 获取小时
        /// </summary>
        /// <returns>0到23之间的数字</returns>
        public int getHour()
        {
            return hour;
        }

        /// <summary>
        /// 获取分钟
        /// </summary>
        /// <returns>0到59之间的数字</returns>
        public int getMinute()
        {
            return minute;
        }

        /// <summary>
        /// 获取秒钟
        /// </summary>
        /// <returns>0到59之间的数字</returns>
        public int getSecond()
        {
            return second;
        }

        public Solar getSolar()
        {
            return solar;
        }
    }
}
