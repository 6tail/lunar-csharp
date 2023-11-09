using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lunar.Util;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
// ReSharper disable MemberCanBePrivate.Global

namespace Lunar
{
    /// <summary>
    /// 农历日期
    /// </summary>
    public class Lunar
    {
        /// <summary>
        /// 节气表，国标以冬至为首个节气
        /// </summary>
        public static readonly string[] JIE_QI = { "冬至", "小寒", "大寒", "立春", "雨水", "惊蛰", "春分", "清明", "谷雨", "立夏", "小满", "芒种", "夏至", "小暑", "大暑", "立秋", "处暑", "白露", "秋分", "寒露", "霜降", "立冬", "小雪", "大雪" };

        /// <summary>
        /// 实际的节气表
        /// </summary>
        public static readonly string[] JIE_QI_IN_USE = { "DA_XUE", "冬至", "小寒", "大寒", "立春", "雨水", "惊蛰", "春分", "清明", "谷雨", "立夏", "小满", "芒种", "夏至", "小暑", "大暑", "立秋", "处暑", "白露", "秋分", "寒露", "霜降", "立冬", "小雪", "大雪", "DONG_ZHI", "XIAO_HAN", "DA_HAN", "LI_CHUN", "YU_SHUI", "JING_ZHE" };

        /// <summary>
        /// 农历年
        /// </summary>
        public int Year { get; }

        /// <summary>
        /// 农历月，闰月为负，即闰2月=-2
        /// </summary>
        public int Month { get; }

        /// <summary>
        /// 农历日
        /// </summary>
        public int Day { get; }

        /// <summary>
        /// 对应阳历
        /// </summary>
        public Solar Solar { get; }

        /// <summary>
        /// 时对应的天干下标，0-9
        /// </summary>
        public int TimeGanIndex { get; set; }

        /// <summary>
        /// 时对应的地支下标，0-11
        /// </summary>
        public int TimeZhiIndex { get; set; }

        /// <summary>
        /// 日对应的天干下标，0-9
        /// </summary>
        public int DayGanIndex { get; set; }

        /// <summary>
        /// 日对应的地支下标，0-11
        /// </summary>
        public int DayZhiIndex { get; set; }

        /// <summary>
        /// 日对应的天干下标（八字流派1，晚子时日柱算明天），0-9
        /// </summary>
        public int DayGanIndexExact { get; set; }

        /// <summary>
        /// 日对应的地支下标（八字流派1，晚子时日柱算明天），0-11
        /// </summary>
        public int DayZhiIndexExact { get; set; }

        /// <summary>
        /// 日对应的天干下标（八字流派2，晚子时日柱算当天），0-9
        /// </summary>
        public int DayGanIndexExact2 { get; set; }

        /// <summary>
        /// 日对应的地支下标（八字流派2，晚子时日柱算当天），0-11
        /// </summary>
        public int DayZhiIndexExact2 { get; set; }

        /// <summary>
        /// 月对应的天干下标（以节交接当天起算），0-9
        /// </summary>
        public int MonthGanIndex { get; set; }

        /// <summary>
        /// 月对应的地支下标（以节交接当天起算），0-11
        /// </summary>
        public int MonthZhiIndex { get; set; }

        /// <summary>
        /// 月对应的天干下标（八字流派1，晚子时日柱算明天），0-9
        /// </summary>
        public int MonthGanIndexExact { get; set; }

        /// <summary>
        /// 月对应的地支下标（八字流派1，晚子时日柱算明天），0-11
        /// </summary>
        public int MonthZhiIndexExact { get; set; }

        /// <summary>
        /// 年对应的天干下标（国标，以正月初一为起点），0-9
        /// </summary>
        public int YearGanIndex { get; set; }

        /// <summary>
        /// 年对应的地支下标（国标，以正月初一为起点），0-11
        /// </summary>
        public int YearZhiIndex { get; set; }

        /// <summary>
        /// 年对应的天干下标（月干计算用，以立春为起点），0-9
        /// </summary>
        public int YearGanIndexByLiChun { get; set; }

        /// <summary>
        /// 年对应的地支下标（月支计算用，以立春为起点），0-11
        /// </summary>
        public int YearZhiIndexByLiChun { get; set; }

        /// <summary>
        /// 年对应的天干下标（最精确的，供八字用，以立春交接时刻为起点），0-9
        /// </summary>
        public int YearGanIndexExact { get; set; }

        /// <summary>
        /// 年对应的地支下标（最精确的，供八字用，以立春交接时刻为起点），0-11
        /// </summary>
        public int YearZhiIndexExact { get; set; }

        /// <summary>
        /// 周下标，0-6
        /// </summary>
        public int WeekIndex { get; set; }

        /// <summary>
        /// 阳历小时
        /// </summary>
        public int Hour { get; }

        /// <summary>
        /// 阳历分钟
        /// </summary>
        public int Minute { get; }

        /// <summary>
        /// 阳历秒钟
        /// </summary>
        public int Second { get; }

        /// <summary>
        /// 节气表
        /// </summary>
        public Dictionary<string, Solar> JieQiTable { get; } = new Dictionary<string, Solar>();

        private EightChar.EightChar _eightChar;

        /// <summary>
        /// 八字
        /// </summary>
        public EightChar.EightChar EightChar => _eightChar ?? (_eightChar = new EightChar.EightChar(this));

        private Foto _foto;
        
        /// <summary>
        /// 佛历
        /// </summary>
        public Foto Foto => _foto ?? (_foto = Foto.FromLunar(this));

        private Tao _tao;

        /// <summary>
        /// 道历
        /// </summary>
        public Tao Tao => _tao ?? (_tao = Tao.FromLunar(this));

        /// <summary>
        /// 默认使用当前日期初始化
        /// </summary>
        public Lunar(): this(DateTime.Now)
        {
        }

        /// <summary>
        /// 通过农历年月日时分秒初始化
        /// </summary>
        /// <param name="lunarYear">年（农历）</param>
        /// <param name="lunarMonth">月（农历），1到12，闰月为负，即闰2月=-2</param>
        /// <param name="lunarDay">日（农历），1到31</param>
        /// <param name="hour">小时（阳历）</param>
        /// <param name="minute">分钟（阳历）</param>
        /// <param name="second">秒钟（阳历）</param>
        public Lunar(int lunarYear, int lunarMonth, int lunarDay, int hour = 0, int minute = 0, int second = 0)
        {
            var y = LunarYear.FromYear(lunarYear);
            var m = y.GetMonth(lunarMonth);
            if (null == m)
            {
                throw new ArgumentException($"wrong lunar year {lunarYear} month {lunarMonth}");
            }
            if (lunarDay < 1)
            {
                throw new ArgumentException("lunar day must bigger than 0");
            }
            var days = m.DayCount;
            if (lunarDay > days)
            {
                throw new ArgumentException($"only {days} days in lunar year {lunarYear} month {lunarMonth}");
            }
            Year = lunarYear;
            Month = lunarMonth;
            Day = lunarDay;
            Hour = hour;
            Minute = minute;
            Second = second;
            var noon = Solar.FromJulianDay(m.FirstJulianDay + lunarDay - 1);
            Solar = Solar.FromYmdHms(noon.Year, noon.Month, noon.Day, hour, minute, second);
            if (noon.Year != lunarYear) {
                y = LunarYear.FromYear(noon.Year);
            }
            Compute(y);
        }

        /// <summary>
        /// 通过阳历初始化
        /// </summary>
        /// <param name="solar">阳历</param>
        public Lunar(Solar solar)
        {
            var ly = LunarYear.FromYear(solar.Year);            
            foreach (var m in ly.Months)
            {
                var days = solar.Subtract(Solar.FromJulianDay(m.FirstJulianDay));
                if (days < m.DayCount)
                {
                    Year = m.Year;
                    Month = m.Month;
                    Day = days + 1;
                    break;
                }
            }
            Hour = solar.Hour;
            Minute = solar.Minute;
            Second = solar.Second;
            Solar = solar;
            Compute(ly);
        }
        
        /// <summary>
        /// 通过阳历日期初始化
        /// </summary>
        /// <param name="date">阳历日期</param>
        public Lunar(DateTime date): this(Solar.FromDate(date))
        {
        }

        /// <summary>
        /// 计算节气表
        /// </summary>
        private void ComputeJieQi(LunarYear lunarYear)
        {
            var julianDays = lunarYear.JieQiJulianDays;
            for (int i = 0, j = JIE_QI_IN_USE.Length; i < j; i++)
            {
                JieQiTable.Add(JIE_QI_IN_USE[i], Solar.FromJulianDay(julianDays[i]));
            }
        }

        /// <summary>
        /// 计算干支纪年
        /// </summary>
        private void ComputeYear()
        {
            // 以正月初一开始
            var offset = Year - 4;
            YearGanIndex = offset % 10;
            YearZhiIndex = offset % 12;

            if (YearGanIndex < 0)
            {
                YearGanIndex += 10;
            }

            if (YearZhiIndex < 0)
            {
                YearZhiIndex += 12;
            }

            // 以立春作为新一年的开始的干支纪年
            var g = YearGanIndex;
            var z = YearZhiIndex;

            // 精确的干支纪年，以立春交接时刻为准
            var gExact = YearGanIndex;
            var zExact = YearZhiIndex;

            var solarYear = Solar.Year;
            var solarYmd = Solar.Ymd;
            var solarYmdHms = Solar.YmdHms;

            // 获取立春的阳历时刻
            var liChun = JieQiTable["立春"];
            if (liChun.Year != solarYear)
            {
                liChun = JieQiTable["LI_CHUN"];
            }
            var liChunYmd = liChun.Ymd;
            var liChunYmdHms = liChun.YmdHms;

            // 阳历和阴历年份相同代表正月初一及以后
            if (Year == solarYear)
            {
                // 立春日期判断
                if (string.Compare(solarYmd, liChunYmd, StringComparison.Ordinal) < 0)
                {
                    g--;
                    z--;
                }
                // 立春交接时刻判断
                if (string.Compare(solarYmdHms, liChunYmdHms, StringComparison.Ordinal) < 0)
                {
                    gExact--;
                    zExact--;
                }
            }
            else if (Year < solarYear)
            {
                if (string.Compare(solarYmd, liChunYmd, StringComparison.Ordinal) >= 0)
                {
                    g++;
                    z++;
                }
                if (string.Compare(solarYmdHms, liChunYmdHms, StringComparison.Ordinal) >= 0)
                {
                    gExact++;
                    zExact++;
                }
            }

            YearGanIndexByLiChun = (g < 0 ? g + 10 : g) % 10;
            YearZhiIndexByLiChun = (z < 0 ? z + 12 : z) % 12;

            YearGanIndexExact = (gExact < 0 ? gExact + 10 : gExact) % 10;
            YearZhiIndexExact = (zExact < 0 ? zExact + 12 : zExact) % 12;
        }

        /**
         * 干支纪月计算
         */
        private void ComputeMonth()
        {
            Solar start = null;
            Solar end;
            var ymd = Solar.Ymd;
            var time = Solar.YmdHms;
            var size = JIE_QI_IN_USE.Length;

            // 序号：大雪以前-3，大雪到小寒之间-2，小寒到立春之间-1，立春之后0
            var index = -3;
            for (var i = 0; i < size; i += 2)
            {
                end = JieQiTable[JIE_QI_IN_USE[i]];
                var symd = null == start ? ymd : start.Ymd;
                if (string.Compare(ymd, symd, StringComparison.Ordinal) >= 0 && string.Compare(ymd, end.Ymd, StringComparison.Ordinal) < 0)
                {
                    break;
                }
                start = end;
                index++;
            }

            //干偏移值（以立春当天起算）
            var offset = (((YearGanIndexByLiChun + (index < 0 ? 1 : 0)) % 5 + 1) * 2) % 10;
            MonthGanIndex = ((index < 0 ? index + 10 : index) + offset) % 10;
            MonthZhiIndex = ((index < 0 ? index + 12 : index) + LunarUtil.BASE_MONTH_ZHI_INDEX) % 12;

            start = null;
            index = -3;
            for (var i = 0; i < size; i += 2)
            {
                end = JieQiTable[JIE_QI_IN_USE[i]];
                var stime = null == start ? time : start.YmdHms;
                if (string.Compare(time, stime, StringComparison.Ordinal) >= 0 && string.Compare(time, end.YmdHms, StringComparison.Ordinal) < 0)
                {
                    break;
                }
                start = end;
                index++;
            }

            //干偏移值（以立春交接时刻起算）
            offset = (((YearGanIndexExact + (index < 0 ? 1 : 0)) % 5 + 1) * 2) % 10;
            MonthGanIndexExact = ((index < 0 ? index + 10 : index) + offset) % 10;
            MonthZhiIndexExact = ((index < 0 ? index + 12 : index) + LunarUtil.BASE_MONTH_ZHI_INDEX) % 12;
        }

        /// <summary>
        /// 干支纪日计算
        /// </summary>
        private void ComputeDay()
        {
            var noon = Solar.FromYmdHms(Solar.Year, Solar.Month, Solar.Day, 12);
            var offset = (int)noon.JulianDay - 11;
            DayGanIndex = offset % 10;
            DayZhiIndex = offset % 12;

            var dayGanExact = DayGanIndex;
            var dayZhiExact = DayZhiIndex;

            // 八字流派2，晚子时（夜子/子夜）日柱算当天
            DayGanIndexExact2 = dayGanExact;
            DayZhiIndexExact2 = dayZhiExact;

            // 八字流派1，晚子时（夜子/子夜）日柱算明天
            var hm = Hour.ToString().PadLeft(2, '0') + ":" + Minute.ToString().PadLeft(2, '0');
            if (string.Compare(hm, "23:00", StringComparison.Ordinal) >= 0 && string.Compare(hm, "23:59", StringComparison.Ordinal) <= 0)
            {
                dayGanExact++;
                if (dayGanExact >= 10)
                {
                    dayGanExact -= 10;
                }
                dayZhiExact++;
                if (dayZhiExact >= 12)
                {
                    dayZhiExact -= 12;
                }
            }

            DayGanIndexExact = dayGanExact;
            DayZhiIndexExact = dayZhiExact;
        }

        /// <summary>
        /// 干支纪时计算
        /// </summary>
        private void ComputeTime()
        {
            var hm = Hour.ToString().PadLeft(2, '0') + ":" + Minute.ToString().PadLeft(2, '0');
            TimeZhiIndex = LunarUtil.GetTimeZhiIndex(hm);
            TimeGanIndex = (DayGanIndexExact % 5 * 2 + TimeZhiIndex) % 10;
        }
        
        private void ComputeWeek()
        {
            WeekIndex = Solar.Week;
        }

        private void Compute(LunarYear lunarYear)
        {
            ComputeJieQi(lunarYear);
            ComputeYear();
            ComputeMonth();
            ComputeDay();
            ComputeTime();
            ComputeWeek();
        }

        /// <summary>
        /// 通过指定阳历日期获取农历
        /// </summary>
        /// <param name="date">阳历日期</param>
        /// <returns>农历</returns>
        public static Lunar FromDate(DateTime date)
        {
            return new Lunar(date);
        }

        /// <summary>
        /// 通过指定农历年月日时分秒获取农历
        /// </summary>
        /// <param name="lunarYear">年（农历）</param>
        /// <param name="lunarMonth">月（农历），1到12，闰月为负，即闰2月=-2</param>
        /// <param name="lunarDay">日（农历），1到31</param>
        /// <param name="hour">小时（阳历）</param>
        /// <param name="minute">分钟（阳历）</param>
        /// <param name="second">秒钟（阳历）</param>
        /// <returns>农历</returns>
        public static Lunar FromYmdHms(int lunarYear, int lunarMonth, int lunarDay, int hour = 0, int minute = 0, int second = 0)
        {
            return new Lunar(lunarYear, lunarMonth, lunarDay, hour, minute, second);
        }

        /// <summary>
        /// 年天干（以正月初一作为新年的开始），如辛
        /// </summary>
        public string YearGan => LunarUtil.GAN[YearGanIndex + 1];

        /// <summary>
        /// 年天干（以立春当天作为新年的开始），如辛
        /// </summary>
        public string YearGanByLiChun => LunarUtil.GAN[YearGanIndexByLiChun + 1];

        /// <summary>
        /// 最精确的年天干（以立春交接的时刻作为新年的开始），如辛
        /// </summary>
        public string YearGanExact => LunarUtil.GAN[YearGanIndexExact + 1];

        /// <summary>
        /// 月天干，如己
        /// </summary>
        public string MonthGan => LunarUtil.GAN[MonthGanIndex + 1];

        /// <summary>
        /// 精确的月天干（以节交接时刻起算），如己
        /// </summary>
        public string MonthGanExact => LunarUtil.GAN[MonthGanIndexExact + 1];

        /// <summary>
        /// 日天干，如甲
        /// </summary>
        public string DayGan => LunarUtil.GAN[DayGanIndex + 1];

        /// <summary>
        /// 日天干（八字流派1，晚子时日柱算明天），如甲
        /// </summary>
        public string DayGanExact => LunarUtil.GAN[DayGanIndexExact + 1];

        /// <summary>
        /// 日天干（八字流派2，晚子时日柱算当天），如甲
        /// </summary>
        public string DayGanExact2 =>  LunarUtil.GAN[DayGanIndexExact2 + 1];

        /// <summary>
        /// 年地支（以正月初一作为新年的开始），如亥
        /// </summary>
        public string YearZhi => LunarUtil.ZHI[YearZhiIndex + 1];

        /// <summary>
        /// 年地支（以立春当天作为新年的开始），如亥
        /// </summary>
        public string YearZhiByLiChun => LunarUtil.ZHI[YearZhiIndexByLiChun + 1];

        /// <summary>
        /// 最精确的年地支（以立春交接的时刻作为新年的开始），如亥
        /// </summary>
        public string YearZhiExact => LunarUtil.ZHI[YearZhiIndexExact + 1];

        /// <summary>
        /// 月地支，如卯
        /// </summary>
        public string MonthZhi => LunarUtil.ZHI[MonthZhiIndex + 1];

        /// <summary>
        /// 精确的月地支（以节交接时刻起算），如卯
        /// </summary>
        public string MonthZhiExact => LunarUtil.ZHI[MonthZhiIndexExact + 1];

        /// <summary>
        /// 日地支，如卯
        /// </summary>
        public string DayZhi => LunarUtil.ZHI[DayZhiIndex + 1];

        /// <summary>
        /// 日地支（八字流派1，晚子时日柱算明天），如卯
        /// </summary>
        public string DayZhiExact => LunarUtil.ZHI[DayZhiIndexExact + 1];

        /// <summary>
        /// 日地支（八字流派2，晚子时日柱算当天），如卯
        /// </summary>
        /// <returns>日地支</returns>
        public string DayZhiExact2 => LunarUtil.ZHI[DayZhiIndexExact2 + 1];

        /// <summary>
        /// 干支纪年（年柱）（以正月初一作为新年的开始），如辛亥
        /// </summary>
        public string YearInGanZhi => $"{YearGan}{YearZhi}";

        /// <summary>
        /// 干支纪年（年柱）（以立春当天作为新年的开始），如辛亥
        /// </summary>
        public string YearInGanZhiByLiChun => $"{YearGanByLiChun}{YearZhiByLiChun}";

        /// <summary>
        /// 干支纪年（年柱）（以立春交接的时刻作为新年的开始），如辛亥
        /// </summary>
        public string YearInGanZhiExact => $"{YearGanExact}{YearZhiExact}";

        /// <summary>
        /// 干支纪月（月柱）（以节交接当天起算），如己卯，月天干口诀：甲己丙寅首，乙庚戊寅头。丙辛从庚寅，丁壬壬寅求，戊癸甲寅居，周而复始流。月地支：正月起寅。
        /// </summary>
        public string MonthInGanZhi => $"{MonthGan}{MonthZhi}";

        /// <summary>
        /// 精确的干支纪月（月柱）（以节交接时刻起算），如己卯，月天干口诀：甲己丙寅首，乙庚戊寅头。丙辛从庚寅，丁壬壬寅求，戊癸甲寅居，周而复始流。月地支：正月起寅。
        /// </summary>
        public string MonthInGanZhiExact => $"{MonthGanExact}{MonthZhiExact}";

        /// <summary>
        /// 干支纪日（日柱），如己卯
        /// </summary>
        public string DayInGanZhi => $"{DayGan}{DayZhi}";

        /// <summary>
        /// 干支纪日（日柱，八字流派1，晚子时日柱算明天），如己卯
        /// </summary>
        public string DayInGanZhiExact => $"{DayGanExact}{DayZhiExact}";

        /// <summary>
        /// 干支纪日（日柱，八字流派2，晚子时日柱算当天），如己卯
        /// </summary>
        public string DayInGanZhiExact2 => $"{DayGanExact2}{DayZhiExact2}";

        /// <summary>
        /// 年生肖（以正月初一起算），如虎
        /// </summary>
        public string YearShengXiao => LunarUtil.SHENGXIAO[YearZhiIndex + 1];

        /// <summary>
        /// 年生肖（以立春当天起算），如虎
        /// </summary>
        public string YearShengXiaoByLiChun => LunarUtil.SHENGXIAO[YearZhiIndexByLiChun + 1];

        /// <summary>
        /// 精确的年生肖（以立春交接时刻起算），如虎
        /// </summary>
        public string YearShengXiaoExact => LunarUtil.SHENGXIAO[YearZhiIndexExact + 1];

        /// <summary>
        /// 月生肖，如虎
        /// </summary>
        public string MonthShengXiao => LunarUtil.SHENGXIAO[MonthZhiIndex + 1];

        /// <summary>
        /// 日生肖，如虎
        /// </summary>
        public string DayShengXiao => LunarUtil.SHENGXIAO[DayZhiIndex + 1];

        /// <summary>
        /// 时辰生肖，如虎
        /// </summary>
        public string TimeShengXiao => LunarUtil.SHENGXIAO[TimeZhiIndex + 1];

        /// <summary>
        /// 中文年，如二〇〇一
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
        /// 中文月，如正
        /// </summary>
        public string MonthInChinese => (Month < 0 ? "闰" : "") + LunarUtil.MONTH[Math.Abs(Month)];

        /// <summary>
        /// 中文日，如初一
        /// </summary>
        public string DayInChinese => LunarUtil.DAY[Day];

        /// <summary>
        /// 时辰地支
        /// </summary>
        public string TimeZhi => LunarUtil.ZHI[TimeZhiIndex + 1];

        /// <summary>
        /// 时辰天干
        /// </summary>
        public string TimeGan => LunarUtil.GAN[TimeGanIndex + 1];

        /// <summary>
        /// 时辰干支（时柱）
        /// </summary>
        public string TimeInGanZhi => $"{TimeGan}{TimeZhi}";

        /// <summary>
        /// 农历季节
        /// </summary>
        public string Season => LunarUtil.SEASON[Math.Abs(Month)];

        /// <summary>
        /// 节令
        /// </summary>
        public string Jie
        {
            get
            {
                for (int i = 0, j = JIE_QI_IN_USE.Length; i < j; i += 2)
                {
                    var key = JIE_QI_IN_USE[i];
                    var d = JieQiTable[key];
                    if (d.Year == Solar.Year && d.Month == Solar.Month && d.Day == Solar.Day)
                    {
                        return ConvertJieQi(key);
                    }
                }
                return "";
            }
        }

        /// <summary>
        /// 气令
        /// </summary>
        public string Qi
        {
            get
            {
                for (int i = 1, j = JIE_QI_IN_USE.Length; i < j; i += 2)
                {
                    var key = JIE_QI_IN_USE[i];
                    var d = JieQiTable[key];
                    if (d.Year == Solar.Year && d.Month == Solar.Month && d.Day == Solar.Day)
                    {
                        return ConvertJieQi(key);
                    }
                }
                return "";
            }
        }

        /// <summary>
        /// 星期，0123456，0代表周日，1代表周一
        /// </summary>
        public int Week => WeekIndex;

        /// <summary>
        /// 星期中文，日一二三四五六
        /// </summary>
        public string WeekInChinese => SolarUtil.WEEK[Week];

        /// <summary>
        /// 宿
        /// </summary>
        public string Xiu => LunarUtil.XIU[DayZhi + Week];

        /// <summary>
        /// 宿吉凶，吉/凶
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
        /// 节日列表，有可能一天会有多个节日
        /// </summary>
        public List<string> Festivals
        {
            get
            {
                var l = new List<string>();
                try
                {
                    l.Add(LunarUtil.FESTIVAL[$"{Month}-{Day}"]);
                }
                catch
                {
                    // ignored
                }

                if (Math.Abs(Month) == 12 && Day >= 29 && Year != Next(1).Year) {
                    l.Add("除夕");
                }
                return l;
            }
        }

        /// <summary>
        /// 非正式的节日列表，有可能一天会有多个节日，如中元节
        /// </summary>
        public List<string> OtherFestivals
        {
            get
            {
                var l = new List<string>();
                try
                {
                    l.AddRange(LunarUtil.OTHER_FESTIVAL[$"{Month}-{Day}"]);
                }
                catch
                {
                    // ignored
                }

                var solarYmd = Solar.Ymd;
                var jq = JieQiTable["清明"];
                if (solarYmd.Equals(jq.Next(-1).Ymd))
                {
                    l.Add("寒食节");
                }

                jq = JieQiTable["立春"];
                var offset = 4 - jq.Lunar.DayGanIndex;
                if (offset < 0)
                {
                    offset += 10;
                }
                if (solarYmd.Equals(jq.Next(offset + 40).Ymd))
                {
                    l.Add("春社");
                }

                jq = JieQiTable["立秋"];
                offset = 4 - jq.Lunar.DayGanIndex;
                if (offset < 0)
                {
                    offset += 10;
                }
                if (solarYmd.Equals(jq.Next(offset + 40).Ymd))
                {
                    l.Add("秋社");
                }
                return l;
            }
        }

        /// <summary>
        /// 彭祖百忌天干
        /// </summary>
        public string PengZuGan => LunarUtil.PENGZU_GAN[DayGanIndex + 1];

        /// <summary>
        /// 彭祖百忌地支
        /// </summary>
        public string PengZuZhi => LunarUtil.PENGZU_ZHI[DayZhiIndex + 1];

        /// <summary>
        /// 日喜神方位，如艮
        /// </summary>
        public string DayPositionXi => LunarUtil.POSITION_XI[DayGanIndex + 1];

        /// <summary>
        /// 日喜神方位描述，如东北
        /// </summary>
        public string DayPositionXiDesc => LunarUtil.POSITION_DESC[DayPositionXi];

        /// <summary>
        /// 日阳贵神方位，如艮
        /// </summary>
        public string DayPositionYangGui => LunarUtil.POSITION_YANG_GUI[DayGanIndex + 1];

        /// <summary>
        /// 日阳贵神方位描述，如东北
        /// </summary>
        public string DayPositionYangGuiDesc => LunarUtil.POSITION_DESC[DayPositionYangGui];

        /// <summary>
        /// 日阴贵神方位，如艮
        /// </summary>
        public string DayPositionYinGui => LunarUtil.POSITION_YIN_GUI[DayGanIndex + 1];

        /// <summary>
        /// 日阴贵神方位描述，如东北
        /// </summary>
        public string DayPositionYinGuiDesc => LunarUtil.POSITION_DESC[DayPositionYinGui];

        /// <summary>
        /// 日福神方位，流派2，如艮
        /// </summary>
        public string DayPositionFu => GetDayPositionFu();

        /// <summary>
        /// 获取日福神方位
        /// </summary>
        /// <param name="sect">流派，可选1或2</param>
        /// <returns>福神方位，如艮</returns>
        public string GetDayPositionFu(int sect = 2)
        {
            return (1 == sect ? LunarUtil.POSITION_FU : LunarUtil.POSITION_FU_2)[DayGanIndex + 1];
        }

        /// <summary>
        /// 日福神方位描述，如东北
        /// </summary>
        public string DayPositionFuDesc => GetDayPositionFuDesc();

        /// <summary>
        /// 获取日福神方位描述
        /// </summary>
        /// <param name="sect">流派，可选1或2</param>
        /// <returns>方位描述，如东北</returns>
        public string GetDayPositionFuDesc(int sect = 2)
        {
            return LunarUtil.POSITION_DESC[GetDayPositionFu(sect)];
        }

        /// <summary>
        /// 日财神方位，如艮
        /// </summary>
        public string DayPositionCai => LunarUtil.POSITION_CAI[DayGanIndex + 1];

        /// <summary>
        /// 日财神方位描述，如东北
        /// </summary>
        public string DayPositionCaiDesc => LunarUtil.POSITION_DESC[DayPositionCai];

        /// <summary>
        /// 获取年太岁方位
        /// </summary>
        /// <param name="sect">流派：2为新年以立春零点起算；1为新年以正月初一起算；3为新年以立春节气交接的时刻起算</param>
        /// <returns>方位</returns>
        public string GetYearPositionTaiSui(int sect = 2)
        {
            int yearZhiIndex;
            switch (sect)
            {
                case 1:
                    yearZhiIndex = YearZhiIndex;
                    break;
                case 3:
                    yearZhiIndex = YearZhiIndexExact;
                    break;
                default:
                    yearZhiIndex = YearZhiIndexByLiChun;
                    break;
            }
            return LunarUtil.POSITION_TAI_SUI_YEAR[yearZhiIndex];
        }

        /// <summary>
        /// 年太岁方位（流派2新年以立春零点起算）
        /// </summary>
        public string YearPositionTaiSui => GetYearPositionTaiSui();
        
        /// <summary>
        /// 年太岁方位描述（流派2新年以立春零点起算），如东北
        /// </summary>
        public string YearPositionTaiSuiDesc => GetYearPositionTaiSuiDesc();

        /// <summary>
        /// 年太岁方位描述
        /// </summary>
        /// <param name="sect">流派：2为新年以立春零点起算；1为新年以正月初一起算；3为新年以立春节气交接的时刻起算</param>
        /// <returns>方位描述，如东北</returns>
        public string GetYearPositionTaiSuiDesc(int sect = 2)
        {
            return LunarUtil.POSITION_DESC[GetYearPositionTaiSui(sect)];
        }

        /// <summary>
        /// 计算月太岁方
        /// </summary>
        /// <param name="monthZhiIndex">月支序号</param>
        /// <param name="monthGanIndex">月干序号</param>
        /// <returns>太岁方</returns>
        protected string GetMonthPositionTaiSui(int monthZhiIndex, int monthGanIndex)
        {
            string p;
            var m = monthZhiIndex - LunarUtil.BASE_MONTH_ZHI_INDEX;
            if (m < 0)
            {
                m += 12;
            }
            switch (m)
            {
                case 0:
                case 4:
                case 8:
                    p = "艮";
                    break;
                case 2:
                case 6:
                case 10:
                    p = "坤";
                    break;
                case 3:
                case 7:
                case 11:
                    p = "巽";
                    break;
                default:
                    p = LunarUtil.POSITION_GAN[monthGanIndex];
                    break;
            }
            return p;
        }

        /// <summary>
        /// 月太岁方位（流派2新的一月以节交接当天零点起算），如艮
        /// </summary>
        public string MonthPositionTaiSui => GetMonthPositionTaiSui();

        /// <summary>
        /// 获取月太岁方位
        /// </summary>
        /// <param name="sect">流派：2为新的一月以节交接当天零点起算；3为新的一月以节交接准确时刻起算</param>
        /// <returns>方位，如艮</returns>
        public string GetMonthPositionTaiSui(int sect = 2)
        {
            int monthZhiIndex;
            int monthGanIndex;
            switch (sect)
            {
                case 3:
                    monthZhiIndex = MonthZhiIndexExact;
                    monthGanIndex = MonthGanIndexExact;
                    break;
                default:
                    monthZhiIndex = MonthZhiIndex;
                    monthGanIndex = MonthGanIndex;
                    break;
            }
            return GetMonthPositionTaiSui(monthZhiIndex, monthGanIndex);
        }

        /// <summary>
        /// 月太岁方位描述（流派2新的一月以节交接当天零点起算），如东北
        /// </summary>
        public string MonthPositionTaiSuiDesc => GetMonthPositionTaiSuiDesc();

        /// <summary>
        /// 获取月太岁方位描述
        /// </summary>
        /// <param name="sect">流派：2为新的一月以节交接当天零点起算；3为新的一月以节交接准确时刻起算</param>
        /// <returns>方位描述，如东北</returns>
        public string GetMonthPositionTaiSuiDesc(int sect = 2)
        {
            return LunarUtil.POSITION_DESC[GetMonthPositionTaiSui(sect)];
        }

        /// <summary>
        /// 计算日太岁方
        /// </summary>
        /// <param name="dayInGanZhi">日干序号</param>
        /// <param name="yearZhiIndex">年支序号</param>
        /// <returns>太岁方</returns>
        protected string GetDayPositionTaiSui(string dayInGanZhi, int yearZhiIndex)
        {
            string p;
            if ("甲子,乙丑,丙寅,丁卯,戊辰,已巳".Contains(dayInGanZhi))
            {
                p = "震";
            }
            else if ("丙子,丁丑,戊寅,已卯,庚辰,辛巳".Contains(dayInGanZhi))
            {
                p = "离";
            }
            else if ("戊子,已丑,庚寅,辛卯,壬辰,癸巳".Contains(dayInGanZhi))
            {
                p = "中";
            }
            else if ("庚子,辛丑,壬寅,癸卯,甲辰,乙巳".Contains(dayInGanZhi))
            {
                p = "兑";
            }
            else if ("壬子,癸丑,甲寅,乙卯,丙辰,丁巳".Contains(dayInGanZhi))
            {
                p = "坎";
            }
            else
            {
                p = LunarUtil.POSITION_TAI_SUI_YEAR[yearZhiIndex];
            }
            return p;
        }

        /// <summary>
        /// 获取日太岁方位（流派2新年以立春零点起算），如艮
        /// </summary>
        public string DayPositionTaiSui => GetDayPositionTaiSui();

        /// <summary>
        /// 获取日太岁方位
        /// </summary>
        /// <param name="sect">流派：2新年以立春零点起算；1新年以正月初一起算；3新年以立春节气交接的时刻起算</param>
        /// <returns>方位，如艮</returns>
        public string GetDayPositionTaiSui(int sect = 2)
        {
            string dayInGanZhi;
            int yearZhiIndex;
            switch (sect)
            {
                case 1:
                    dayInGanZhi = DayInGanZhi;
                    yearZhiIndex = YearZhiIndex;
                    break;
                case 3:
                    dayInGanZhi = DayInGanZhi;
                    yearZhiIndex = YearZhiIndexExact;
                    break;
                default:
                    dayInGanZhi = DayInGanZhiExact2;
                    yearZhiIndex = YearZhiIndexByLiChun;
                    break;
            }
            return GetDayPositionTaiSui(dayInGanZhi, yearZhiIndex);
        }

        /// <summary>
        /// 日太岁方位描述（流派2新年以立春零点起算），如东北
        /// </summary>
        public string DayPositionTaiSuiDesc => GetDayPositionTaiSuiDesc();

        /// <summary>
        /// 获取日太岁方位描述
        /// </summary>
        /// <param name="sect">流派：2新年以立春零点起算；1新年以正月初一起算；3新年以立春节气交接的时刻起算</param>
        /// <returns>方位描述，如东北</returns>
        public string GetDayPositionTaiSuiDesc(int sect = 2)
        {
            return LunarUtil.POSITION_DESC[GetDayPositionTaiSui(sect)];
        }

        /// <summary>
        /// 时辰喜神方位，如艮
        /// </summary>
        public string TimePositionXi => LunarUtil.POSITION_XI[TimeGanIndex + 1];

        /// <summary>
        /// 时辰喜神方位描述，如东北
        /// </summary>
        public string TimePositionXiDesc => LunarUtil.POSITION_DESC[TimePositionXi];

        /// <summary>
        /// 时辰阳贵神方位，如艮
        /// </summary>
        public string TimePositionYangGui => LunarUtil.POSITION_YANG_GUI[TimeGanIndex + 1];

        /// <summary>
        /// 时辰阳贵神方位描述，如东北
        /// </summary>
        public string TimePositionYangGuiDesc => LunarUtil.POSITION_DESC[TimePositionYangGui];

        /// <summary>
        /// 时辰阴贵神方位，如艮
        /// </summary>
        public string TimePositionYinGui => LunarUtil.POSITION_YIN_GUI[TimeGanIndex + 1];

        /// <summary>
        /// 时辰阴贵神方位描述，如东北
        /// </summary>
        public string TimePositionYinGuiDesc => LunarUtil.POSITION_DESC[TimePositionYinGui];

        /// <summary>
        /// 时辰福神方位（流派2），如艮
        /// </summary>
        public string TimePositionFu => GetTimePositionFu();

        /// <summary>
        /// 获取时辰福神方位
        /// </summary>
        /// <param name="sect">流派，可选1或2</param>
        /// <returns>福神方位，如艮</returns>
        public string GetTimePositionFu(int sect = 2)
        {
            return (1 == sect ? LunarUtil.POSITION_FU : LunarUtil.POSITION_FU_2)[TimeGanIndex + 1];
        }

        /// <summary>
        /// 时辰福神方位描述（流派2），如东北
        /// </summary>
        public string TimePositionFuDesc => GetTimePositionFuDesc();

        /// <summary>
        /// 获取时辰福神方位描述
        /// </summary>
        /// <param name="sect">流派，可选1或2</param>
        /// <returns>福神方位描述，如东北</returns>
        public string GetTimePositionFuDesc(int sect = 2)
        {
            return LunarUtil.POSITION_DESC[GetTimePositionFu(sect)];
        }

        /// <summary>
        /// 时辰财神方位，如艮
        /// </summary>
        public string TimePositionCai => LunarUtil.POSITION_CAI[TimeGanIndex + 1];

        /// <summary>
        /// 时辰财神方位描述，如东北
        /// </summary>
        public string TimePositionCaiDesc => LunarUtil.POSITION_DESC[TimePositionCai];

        /// <summary>
        /// 日冲，如申
        /// </summary>
        public string DayChong => LunarUtil.CHONG[DayZhiIndex];

        /// <summary>
        /// 时冲，如申
        /// </summary>
        public string TimeChong => LunarUtil.CHONG[TimeZhiIndex];

        /// <summary>
        /// 无情之克的日冲天干，如甲
        /// </summary>
        public string DayChongGan => LunarUtil.CHONG_GAN[DayGanIndex];

        /// <summary>
        /// 无情之克的时冲天干，如甲
        /// </summary>
        public string TimeChongGan => LunarUtil.CHONG_GAN[TimeGanIndex];

        /// <summary>
        /// 有情之克的日冲天干，如甲
        /// </summary>
        public string DayChongGanTie => LunarUtil.CHONG_GAN_TIE[DayGanIndex];

        /// <summary>
        /// 有情之克的时冲天干，如甲
        /// </summary>
        public string TimeChongGanTie => LunarUtil.CHONG_GAN_TIE[TimeGanIndex];

        /// <summary>
        /// 日冲生肖，如猴
        /// </summary>
        public string DayChongShengXiao
        {
            get
            {
                for (int i = 0, j = LunarUtil.ZHI.Length; i < j; i++)
                {
                    if (LunarUtil.ZHI[i].Equals(DayChong))
                    {
                        return LunarUtil.SHENGXIAO[i];
                    }
                }
                return "";
            }
        }

        /// <summary>
        /// 时冲生肖，如猴
        /// </summary>
        public string TimeChongShengXiao
        {
            get
            {
                string chong = TimeChong;
                for (int i = 0, j = LunarUtil.ZHI.Length; i < j; i++)
                {
                    if (LunarUtil.ZHI[i].Equals(chong))
                    {
                        return LunarUtil.SHENGXIAO[i];
                    }
                }
                return "";
            }
        }

        /// <summary>
        /// 日冲描述，如(壬申)猴
        /// </summary>
        public string DayChongDesc => $"({DayChongGan}{DayChong}){DayChongShengXiao}";

        /// <summary>
        /// 时冲描述，如(壬申)猴
        /// </summary>
        public string TimeChongDesc => $"({TimeChongGan}{TimeChong}){TimeChongShengXiao}";

        /// <summary>
        /// 日煞，如北
        /// </summary>
        public string DaySha => LunarUtil.SHA[DayZhi];

        /// <summary>
        /// 时煞，如北
        /// </summary>
        public string TimeSha => LunarUtil.SHA[TimeZhi];

        /// <summary>
        /// 年纳音，如剑锋金
        /// </summary>
        public string YearNaYin => LunarUtil.NAYIN[YearInGanZhi];

        /// <summary>
        /// 月纳音，如剑锋金
        /// </summary>
        public string MonthNaYin => LunarUtil.NAYIN[MonthInGanZhi];

        /// <summary>
        /// 日纳音，如剑锋金
        /// </summary>
        public string DayNaYin => LunarUtil.NAYIN[DayInGanZhi];

        /// <summary>
        /// 时辰纳音，如剑锋金
        /// </summary>
        public string TimeNaYin => LunarUtil.NAYIN[TimeInGanZhi];

        /// <summary>
        /// 十二执星：建、除、满、平、定、执、破、危、成、收、开、闭。当月支与日支相同即为建，依次类推
        /// </summary>
        public string ZhiXing
        {
            get
            {
                var offset = DayZhiIndex - MonthZhiIndex;
                if (offset < 0)
                {
                    offset += 12;
                }
                return LunarUtil.ZHI_XING[offset + 1];
            }
        }

        /// <summary>
        /// 值日天神
        /// </summary>
        public string DayTianShen => LunarUtil.TIAN_SHEN[(DayZhiIndex + LunarUtil.ZHI_TIAN_SHEN_OFFSET[MonthZhi]) % 12 + 1];

        /// <summary>
        /// 值时天神
        /// </summary>
        public string TimeTianShen => LunarUtil.TIAN_SHEN[(TimeZhiIndex + LunarUtil.ZHI_TIAN_SHEN_OFFSET[DayZhiExact]) % 12 + 1];

        /// <summary>
        /// 值日天神类型：黄道/黑道
        /// </summary>
        public string DayTianShenType => LunarUtil.TIAN_SHEN_TYPE[DayTianShen];

        /// <summary>
        /// 值时天神类型：黄道/黑道
        /// </summary>
        public string TimeTianShenType => LunarUtil.TIAN_SHEN_TYPE[TimeTianShen];

        /// <summary>
        /// 值日天神吉凶：吉/凶
        /// </summary>
        public string DayTianShenLuck => LunarUtil.TIAN_SHEN_TYPE_LUCK[DayTianShenType];

        /// <summary>
        /// 值时天神吉凶：吉/凶
        /// </summary>
        public string TimeTianShenLuck => LunarUtil.TIAN_SHEN_TYPE_LUCK[TimeTianShenType];

        /// <summary>
        /// 逐日胎神方位
        /// </summary>
        public string DayPositionTai => LunarUtil.POSITION_TAI_DAY[LunarUtil.GetJiaZiIndex(DayInGanZhi)];

        /// <summary>
        /// 逐月胎神方位，闰月无
        /// </summary>
        public string MonthPositionTai => Month < 0 ? "" : LunarUtil.POSITION_TAI_MONTH[Month - 1];

        /// <summary>
        /// 日宜，如果没有，返回["无"]
        /// </summary>
        public List<string> DayYi => LunarUtil.GetDayYi(MonthInGanZhiExact, DayInGanZhi);

        /// <summary>
        /// 日忌，如果没有，返回["无"]
        /// </summary>
        public List<string> DayJi => LunarUtil.GetDayJi(MonthInGanZhiExact, DayInGanZhi);

        /// <summary>
        /// 日吉神（宜趋），如果没有，返回["无"]
        /// </summary>
        public List<string> DayJiShen => LunarUtil.GetDayJiShen(Month, DayInGanZhi);

        /// <summary>
        /// 日凶煞（宜忌），如果没有，返回["无"]
        /// </summary>
        public List<string> DayXiongSha => LunarUtil.GetDayXiongSha(Month, DayInGanZhi);

        /// <summary>
        /// 时辰宜，如果没有，返回["无"]
        /// </summary>
        /// <returns>宜</returns>
        public List<string> TimeYi => LunarUtil.GetTimeYi(DayInGanZhiExact, TimeInGanZhi);

        /// <summary>
        /// 时辰忌，如果没有，返回["无"]
        /// </summary>
        public List<string> TimeJi => LunarUtil.GetTimeJi(DayInGanZhiExact, TimeInGanZhi);

        /// <summary>
        /// 月相
        /// </summary>
        public string YueXiang => LunarUtil.YUE_XIANG[Day];

        /// <summary>
        /// 计算年九星
        /// </summary>
        /// <param name="yearInGanZhi">年干支</param>
        /// <returns>九星</returns>
        protected NineStar GetYearNineStar(string yearInGanZhi)
        {
            var indexExact = LunarUtil.GetJiaZiIndex(yearInGanZhi) + 1;
            var index = LunarUtil.GetJiaZiIndex(YearInGanZhi) + 1;
            var yearOffset = indexExact - index;
            if (yearOffset > 1) {
                yearOffset -= 60;
            } else if (yearOffset < -1) {
                yearOffset += 60;
            }
            var yuan = (Year + yearOffset + 2696) / 60 % 3;
            var offset = (62 + yuan * 3 - indexExact) % 9;
            if (0 == offset)
            {
                offset = 9;
            }
            return NineStar.FromIndex(offset - 1);
        }

        /// <summary>
        /// 获取值年九星（流年紫白星起例歌诀：年上吉星论甲子，逐年星逆中宫起；上中下作三元汇，一上四中七下兑。）
        /// </summary>
        /// <param name="sect">流派：2为新年以立春零点起算；1为新年以正月初一起算；3为新年以立春节气交接的时刻起算</param>
        /// <returns>九星</returns>
        public NineStar GetYearNineStar(int sect = 2)
        {
            string yearInGanZhi;
            switch (sect)
            {
                case 1:
                    yearInGanZhi = this.YearInGanZhi;
                    break;
                case 3:
                    yearInGanZhi = this.YearInGanZhiExact;
                    break;
                default:
                    yearInGanZhi = this.YearInGanZhiByLiChun;
                    break;
            }
            return GetYearNineStar(yearInGanZhi);
        }

        /// <summary>
        /// 值年九星（流派2新年以立春零点起算。流年紫白星起例歌诀：年上吉星论甲子，逐年星逆中宫起；上中下作三元汇，一上四中七下兑。）
        /// </summary>
        public NineStar YearNineStar => GetYearNineStar();

        /// <summary>
        /// 计算月九星
        /// </summary>
        /// <param name="yearZhiIndex">年支序号</param>
        /// <param name="monthZhiIndex">月支序号</param>
        /// <returns>九星</returns>
        protected NineStar GetMonthNineStar(int yearZhiIndex, int monthZhiIndex)
        {
            var n = 27 - yearZhiIndex % 3 * 3;
            if (monthZhiIndex < LunarUtil.BASE_MONTH_ZHI_INDEX)
            {
                n -= 3;
            }
            var offset = (n - monthZhiIndex) % 9;
            return NineStar.FromIndex(offset);
        }

        /// <summary>
        /// 获取值月九星（月紫白星歌诀：子午卯酉八白起，寅申巳亥二黑求，辰戌丑未五黄中。）
        /// </summary>
        /// <param name="sect">流派：2为新的一月以节交接当天零点起算；3为新的一月以节交接准确时刻起算</param>
        /// <returns>九星</returns>
        public NineStar GetMonthNineStar(int sect = 2)
        {
            int yearZhiIndex;
            int monthZhiIndex;
            switch (sect)
            {
                case 1:
                    yearZhiIndex = YearZhiIndex;
                    monthZhiIndex = MonthZhiIndex;
                    break;
                case 3:
                    yearZhiIndex = YearZhiIndexExact;
                    monthZhiIndex = MonthZhiIndexExact;
                    break;
                default:
                    yearZhiIndex = YearZhiIndexByLiChun;
                    monthZhiIndex = MonthZhiIndex;
                    break;
            }
            return GetMonthNineStar(yearZhiIndex, monthZhiIndex);
        }

        /// <summary>
        /// 值月九星（流派2新的一月以节交接当天零点起算。月紫白星歌诀：子午卯酉八白起，寅申巳亥二黑求，辰戌丑未五黄中。）
        /// </summary>
        public NineStar MonthNineStar => GetMonthNineStar();

        /// <summary>
        /// 值日九星（日家紫白星歌诀：日家白法不难求，二十四气六宫周；冬至雨水及谷雨，阳顺一七四中游；夏至处暑霜降后，九三六星逆行求。）
        /// </summary>
        public NineStar DayNineStar
        {
            get
            {
                var solarYmd = Solar.Ymd;
                var dongZhi = JieQiTable["冬至"];
                var dongZhi2 = JieQiTable["DONG_ZHI"];
                var xiaZhi = JieQiTable["夏至"];
                var dongZhiIndex = LunarUtil.GetJiaZiIndex(dongZhi.Lunar.DayInGanZhi);
                var dongZhiIndex2 = LunarUtil.GetJiaZiIndex(dongZhi2.Lunar.DayInGanZhi);
                var xiaZhiIndex = LunarUtil.GetJiaZiIndex(xiaZhi.Lunar.DayInGanZhi);
                var solarShunBai = dongZhiIndex > 29 ? dongZhi.Next(60 - dongZhiIndex) : dongZhi.Next(-dongZhiIndex);

                var solarShunBaiYmd = solarShunBai.Ymd;
                var solarShunBai2 = dongZhiIndex2 > 29 ? dongZhi2.Next(60 - dongZhiIndex2) : dongZhi2.Next(-dongZhiIndex2);

                var solarShunBaiYmd2 = solarShunBai2.Ymd;
                var solarNiZi = xiaZhiIndex > 29 ? xiaZhi.Next(60 - xiaZhiIndex) : xiaZhi.Next(-xiaZhiIndex);

                var solarNiZiYmd = solarNiZi.Ymd;
                var offset = 0;
                if (string.Compare(solarYmd, solarShunBaiYmd, StringComparison.Ordinal) >= 0 && string.Compare(solarYmd, solarNiZiYmd, StringComparison.Ordinal) < 0)
                {
                    offset = Solar.Subtract(solarShunBai) % 9;
                }
                else if (string.Compare(solarYmd, solarNiZiYmd, StringComparison.Ordinal) >= 0 && string.Compare(solarYmd, solarShunBaiYmd2, StringComparison.Ordinal) < 0)
                {
                    offset = 8 - (Solar.Subtract(solarNiZi) % 9);
                }
                else if (string.Compare(solarYmd, solarShunBaiYmd2, StringComparison.Ordinal) >= 0)
                {
                    offset = Solar.Subtract(solarShunBai2) % 9;
                }
                else if (string.Compare(solarYmd, solarShunBaiYmd, StringComparison.Ordinal) < 0)
                {
                    offset = (8 + solarShunBai.Subtract(Solar)) % 9;
                }

                return NineStar.FromIndex(offset);
            }
        }

        /// <summary>
        /// 值时九星（时家紫白星歌诀：三元时白最为佳，冬至阳生顺莫差，孟日七宫仲一白，季日四绿发萌芽，每把时辰起甲子，本时星耀照光华，时星移入中宫去，顺飞八方逐细查。夏至阴生逆回首，孟归三碧季加六，仲在九宫时起甲，依然掌中逆轮跨。）
        /// </summary>
        public NineStar TimeNineStar
        {
            get
            {
                // 顺逆
                var solarYmd = Solar.Ymd;
                var asc = false;
                if (string.Compare(solarYmd, JieQiTable["冬至"].Ymd, StringComparison.Ordinal) >= 0 && string.Compare(solarYmd, JieQiTable["夏至"].Ymd, StringComparison.Ordinal) < 0)
                {
                    asc = true;
                }
                else if (string.Compare(solarYmd, JieQiTable["DONG_ZHI"].Ymd, StringComparison.Ordinal) >= 0)
                {
                    asc = true;
                }

                var start = asc ? 6 : 2;
                var dayZhi = DayZhi;
                if ("子午卯酉".Contains(dayZhi))
                {
                    start = asc ? 0 : 8;
                }
                else if ("辰戌丑未".Contains(dayZhi))
                {
                    start = asc ? 3 : 5;
                }

                var index = asc ? start + TimeZhiIndex : start + 9 - TimeZhiIndex;
                return new NineStar(index % 9);
            }
        }

        /// <summary>
        /// 获取下一节（顺推的第一个节）
        /// </summary>
        /// <param name="wholeDay">是否按天计</param>
        /// <returns>节气</returns>
        public JieQi GetNextJie(bool wholeDay = false)
        {
            var l = JIE_QI_IN_USE.Length / 2;
            var conditions = new string[l];
            for (var i = 0; i < l; i++)
            {
                conditions[i] = JIE_QI_IN_USE[i * 2];
            }
            return GetNearJieQi(true, conditions, wholeDay);
        }

        /// <summary>
        /// 获取上一节（逆推的第一个节）
        /// </summary>
        /// <param name="wholeDay">是否按天计</param>
        /// <returns>节气</returns>
        public JieQi GetPrevJie(bool wholeDay = false)
        {
            var l = JIE_QI_IN_USE.Length / 2;
            var conditions = new string[l];
            for (var i = 0; i < l; i++)
            {
                conditions[i] = JIE_QI_IN_USE[i * 2];
            }
            return GetNearJieQi(false, conditions, wholeDay);
        }

        /// <summary>
        /// 获取下一气令（顺推的第一个气令）
        /// </summary>
        /// <param name="wholeDay">是否按天计</param>
        /// <returns>节气</returns>
        public JieQi GetNextQi(bool wholeDay = false)
        {
            var l = JIE_QI_IN_USE.Length / 2;
            var conditions = new string[l];
            for (var i = 0; i < l; i++)
            {
                conditions[i] = JIE_QI_IN_USE[i * 2 + 1];
            }
            return GetNearJieQi(true, conditions, wholeDay);
        }

        /// <summary>
        /// 获取上一气令（逆推的第一个气令）
        /// </summary>
        /// <param name="wholeDay">是否按天计</param>
        /// <returns>节气</returns>
        public JieQi GetPrevQi(bool wholeDay = false)
        {
            var l = JIE_QI_IN_USE.Length / 2;
            var conditions = new string[l];
            for (var i = 0; i < l; i++)
            {
                conditions[i] = JIE_QI_IN_USE[i * 2 + 1];
            }
            return GetNearJieQi(false, conditions, wholeDay);
        }

        /// <summary>
        /// 获取下一节气（顺推的第一个节气）
        /// </summary>
        /// <param name="wholeDay">是否按天计</param>
        /// <returns>节气</returns>
        public JieQi GetNextJieQi(bool wholeDay = false)
        {
            return GetNearJieQi(true, null, wholeDay);
        }

        /// <summary>
        /// 获取上一节气（逆推的第一个节气）
        /// </summary>
        /// <param name="wholeDay">是否按天计</param>
        /// <returns>节气</returns>
        public JieQi GetPrevJieQi(bool wholeDay = false)
        {
            return GetNearJieQi(false, null, wholeDay);
        }

        /// <summary>
        /// 获取最近的节气，如果未找到匹配的，返回null
        /// </summary>
        /// <param name="forward">是否顺推，true为顺推，false为逆推</param>
        /// <param name="conditions">过滤条件，如果设置过滤条件，仅返回匹配该名称的</param>
        /// <param name="wholeDay">是否按天计</param>
        /// <returns>节气</returns>
        private JieQi GetNearJieQi(bool forward, string[] conditions, bool wholeDay)
        {
            string name = null;
            Solar near = null;
            var filters = new List<string>();
            if (null != conditions)
            {
                foreach (var cond in conditions)
                {
                    if (!filters.Contains(cond))
                    {
                        filters.Add(cond);
                    }
                }
            }
            var filter = filters.Count > 0;
            var today = wholeDay ? Solar.Ymd : Solar.YmdHms;
            foreach (var entry in JieQiTable)
            {
                var jq = ConvertJieQi(entry.Key);
                if (filter)
                {
                    if (!filters.Contains(jq))
                    {
                        continue;
                    }
                }

                var current = entry.Value;
                var day = wholeDay ? current.Ymd : current.YmdHms;
                if (forward)
                {
                    if (string.Compare(day, today, StringComparison.Ordinal) < 0)
                    {
                        continue;
                    }
                    if (null == near)
                    {
                        name = jq;
                        near = current;
                    }
                    else
                    {
                        var nearDay = wholeDay ? near.Ymd : near.YmdHms;
                        if (string.Compare(day, nearDay, StringComparison.Ordinal) < 0)
                        {
                            name = jq;
                            near = current;
                        }
                    }
                }
                else
                {
                    if (string.Compare(day, today, StringComparison.Ordinal) > 0)
                    {
                        continue;
                    }
                    if (null == near)
                    {
                        name = jq;
                        near = current;
                    }
                    else
                    {
                        var nearDay = wholeDay ? near.Ymd : near.YmdHms;
                        if (string.Compare(day, nearDay, StringComparison.Ordinal) > 0)
                        {
                            name = jq;
                            near = current;
                        }
                    }
                }

            }
            return null == near ? null : new JieQi(name, near);
        }

        /// <summary>
        /// 转节气名
        /// </summary>
        /// <param name="name">节气名</param>
        /// <returns>正式的节气名</returns>
        protected string ConvertJieQi(string name)
        {
            var jq = name;
            switch (jq)
            {
                case "DONG_ZHI":
                    jq = "冬至";
                    break;
                case "DA_HAN":
                    jq = "大寒";
                    break;
                case "XIAO_HAN":
                    jq = "小寒";
                    break;
                case "LI_CHUN":
                    jq = "立春";
                    break;
                case "DA_XUE":
                    jq = "大雪";
                    break;
                case "YU_SHUI":
                    jq = "雨水";
                    break;
                case "JING_ZHE":
                    jq = "惊蛰";
                    break;
            }
            return jq;
        }

        /// <summary>
        /// 节气名称，如果无节气，返回空字符串
        /// </summary>
        public string JieQi
        {
            get
            {
                foreach (var entry in JieQiTable)
                {
                    var d = entry.Value;
                    if (d.Year == Solar.Year && d.Month == Solar.Month && d.Day == Solar.Day)
                    {
                        return ConvertJieQi(entry.Key);
                    }
                }
                return "";
            }
        }

        /// <summary>
        /// 当天节气对象，如果无节气，返回null
        /// </summary>
        public JieQi CurrentJieQi => (from jq in JieQiTable let d = jq.Value where d.Year == Solar.Year && d.Month == Solar.Month && d.Day == Solar.Day select new JieQi(ConvertJieQi(jq.Key), d)).FirstOrDefault();

        /// <summary>
        /// 当天节令对象，如果无节令，返回null
        /// </summary>
        public JieQi CurrentJie
        {
            get
            {
                for (int i = 0, j = JIE_QI_IN_USE.Length; i < j; i += 2)
                {
                    var key = JIE_QI_IN_USE[i];
                    var d = JieQiTable[key];
                    if (d.Year == Solar.Year && d.Month == Solar.Month && d.Day == Solar.Day)
                    {
                        return new JieQi(ConvertJieQi(key), d);
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// 当天气令对象，如果无气令，返回null
        /// </summary>
        public JieQi CurrentQi
        {
            get
            {
                for (int i = 1, j = JIE_QI_IN_USE.Length; i < j; i += 2)
                {
                    var key = JIE_QI_IN_USE[i];
                    var d = JieQiTable[key];
                    if (d.Year == Solar.Year && d.Month == Solar.Month && d.Day == Solar.Day)
                    {
                        return new JieQi(ConvertJieQi(key), d);
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// 完整字符串输出
        /// </summary>
        public string FullString
        {
            get
            {
                StringBuilder s = new StringBuilder();
                s.Append(ToString());
                s.Append(' ');
                s.Append(YearInGanZhi);
                s.Append('(');
                s.Append(YearShengXiao);
                s.Append(")年 ");
                s.Append(MonthInGanZhi);
                s.Append('(');
                s.Append(MonthShengXiao);
                s.Append(")月 ");
                s.Append(DayInGanZhi);
                s.Append('(');
                s.Append(DayShengXiao);
                s.Append(")日 ");
                s.Append(TimeZhi);
                s.Append('(');
                s.Append(TimeShengXiao);
                s.Append(")时 纳音[");
                s.Append(YearNaYin);
                s.Append(' ');
                s.Append(MonthNaYin);
                s.Append(' ');
                s.Append(DayNaYin);
                s.Append(' ');
                s.Append(TimeNaYin);
                s.Append("] 星期");
                s.Append(WeekInChinese);
                foreach (var f in Festivals)
                {
                    s.Append(" (");
                    s.Append(f);
                    s.Append(')');
                }

                foreach (var f in OtherFestivals)
                {
                    s.Append(" (");
                    s.Append(f);
                    s.Append(')');
                }

                var jq = JieQi;
                if (jq.Length > 0)
                {
                    s.Append(" [");
                    s.Append(jq);
                    s.Append(']');
                }

                s.Append(' ');
                s.Append(Gong);
                s.Append('方');
                s.Append(Shou);
                s.Append(" 星宿[");
                s.Append(Xiu);
                s.Append(Zheng);
                s.Append(Animal);
                s.Append("](");
                s.Append(XiuLuck);
                s.Append(") 彭祖百忌[");
                s.Append(PengZuGan);
                s.Append(' ');
                s.Append(PengZuZhi);
                s.Append("] 喜神方位[");
                s.Append(DayPositionXi);
                s.Append("](");
                s.Append(DayPositionXiDesc);
                s.Append(") 阳贵神方位[");
                s.Append(DayPositionYangGui);
                s.Append("](");
                s.Append(DayPositionYangGuiDesc);
                s.Append(") 阴贵神方位[");
                s.Append(DayPositionYinGui);
                s.Append("](");
                s.Append(DayPositionYinGuiDesc);
                s.Append(") 福神方位[");
                s.Append(DayPositionFu);
                s.Append("](");
                s.Append(DayPositionFuDesc);
                s.Append(") 财神方位[");
                s.Append(DayPositionCai);
                s.Append("](");
                s.Append(DayPositionCaiDesc);
                s.Append(") 冲[");
                s.Append(DayChongDesc);
                s.Append("] 煞[");
                s.Append(DaySha);
                s.Append(']');
                return s.ToString();
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{YearInChinese}年{MonthInChinese}月{DayInChinese}";
        }

        /// <summary>
        /// 获取往后推几天的农历日期，如果要往前推，则天数用负数
        /// </summary>
        /// <param name="days">天数</param>
        /// <returns>农历日期</returns>
        public Lunar Next(int days)
        {
            return Solar.Next(days).Lunar;
        }

        /// <summary>
        /// 年所在旬（以正月初一作为新年的开始）
        /// </summary>
        public string YearXun => LunarUtil.GetXun(YearInGanZhi);

        /// <summary>
        /// 年所在旬（以立春当天作为新年的开始）
        /// </summary>
        public string YearXunByLiChun => LunarUtil.GetXun(YearInGanZhiByLiChun);

        /// <summary>
        /// 年所在旬（以立春交接时刻作为新年的开始）
        /// </summary>
        public string YearXunExact => LunarUtil.GetXun(YearInGanZhiExact);

        /// <summary>
        /// 值年空亡(旬空)（以正月初一作为新年的开始）
        /// </summary>
        public string YearXunKong => LunarUtil.GetXunKong(YearInGanZhi);

        /// <summary>
        /// 值年空亡(旬空)（以立春当天作为新年的开始）
        /// </summary>
        public string YearXunKongByLiChun => LunarUtil.GetXunKong(YearInGanZhiByLiChun);

        /// <summary>
        /// 值年空亡(旬空)（以立春交接时刻作为新年的开始）
        /// </summary>
        public string YearXunKongExact => LunarUtil.GetXunKong(YearInGanZhiExact);

        /// <summary>
        /// 月所在旬（以节交接当天起算）
        /// </summary>
        public string MonthXun => LunarUtil.GetXun(MonthInGanZhi);

        /// <summary>
        /// 月所在旬（以节交接时刻起算）
        /// </summary>
        public string MonthXunExact => LunarUtil.GetXun(MonthInGanZhiExact);

        /// <summary>
        /// 值月空亡(旬空)（以节交接当天起算）
        /// </summary>
        public string MonthXunKong => LunarUtil.GetXunKong(MonthInGanZhi);

        /// <summary>
        /// 值月空亡(旬空)（以节交接时刻起算）
        /// </summary>
        public string MonthXunKongExact => LunarUtil.GetXunKong(MonthInGanZhiExact);

        /// <summary>
        /// 日所在旬（以节交接当天起算）
        /// </summary>
        public string DayXun => LunarUtil.GetXun(DayInGanZhi);

        /// <summary>
        /// 日所在旬（八字流派1，晚子时日柱算明天）
        /// </summary>
        public string DayXunExact => LunarUtil.GetXun(DayInGanZhiExact);

        /// <summary>
        /// 日所在旬（八字流派2，晚子时日柱算当天）
        /// </summary>
        public string DayXunExact2 => LunarUtil.GetXun(DayInGanZhiExact2);

        /// <summary>
        /// 值日空亡(旬空)
        /// </summary>
        public string DayXunKong => LunarUtil.GetXunKong(DayInGanZhi);

        /// <summary>
        /// 值日空亡(旬空)（八字流派1，晚子时日柱算明天）
        /// </summary>
        public string DayXunKongExact => LunarUtil.GetXunKong(DayInGanZhiExact);

        /// <summary>
        /// 值日空亡(旬空)（八字流派2，晚子时日柱算当天）
        /// </summary>
        /// <returns>空亡(旬空)</returns>
        public string DayXunKongExact2 => LunarUtil.GetXunKong(DayInGanZhiExact2);

        /// <summary>
        /// 时辰所在旬
        /// </summary>
        public string TimeXun => LunarUtil.GetXun(TimeInGanZhi);

        /// <summary>
        /// 值时空亡(旬空)
        /// </summary>
        public string TimeXunKong => LunarUtil.GetXunKong(TimeInGanZhi);

        /// <summary>
        /// 数九，如果不是数九天，返回null
        /// </summary>
        public ShuJiu ShuJiu
        {
            get
            {
                var current = new Solar(Solar.Year, Solar.Month, Solar.Day);
                var start = JieQiTable["DONG_ZHI"];
                start = new Solar(start.Year, start.Month, start.Day);
                if (current.IsBefore(start))
                {
                    start = JieQiTable["冬至"];
                    start = new Solar(start.Year, start.Month, start.Day);
                }

                var end = new Solar(start.Year, start.Month, start.Day).Next(81);
                
                if (current.IsBefore(start) || !current.IsBefore(end))
                {
                    return null;
                }

                var days = current.Subtract(start);
                return new ShuJiu($"{LunarUtil.NUMBER[days / 9 + 1]}九", days % 9 + 1);
            }
        }

        /// <summary>
        /// 三伏，如果不是伏天，返回null
        /// </summary>
        public Fu Fu
        {
            get
            { 
                var current = new Solar(Solar.Year, Solar.Month, Solar.Day);
                var xiaZhi = JieQiTable["夏至"];
                var liQiu = JieQiTable["立秋"];
                var start = new Solar(xiaZhi.Year, xiaZhi.Month, xiaZhi.Day);
                var add = 6 - xiaZhi.Lunar.DayGanIndex;
                if (add < 0)
                {
                    add += 10;
                }
                add += 20;
                start = start.Next(add);
                if (current.IsBefore(start))
                {
                    return null;
                }

                var days = current.Subtract(start);
                if (days < 10)
                {
                    return new Fu("初伏", days + 1);
                }

                start = start.Next(10);
                days = current.Subtract(start);
                if (days < 10)
                {
                    return new Fu("中伏", days + 1);
                }
                start = start.Next(10);
                days = current.Subtract(start);
                var liQiuSolar = new Solar(liQiu.Year, liQiu.Month, liQiu.Day);
                if (liQiuSolar.IsAfter(start))
                {
                    if (days < 10)
                    {
                        return new Fu("中伏", days + 11);
                    }
                    start = start.Next(10);
                    days = current.Subtract(start);
                }
                if (days < 10)
                {
                    return new Fu("末伏", days + 1);
                }
                return null;
            }
        }

        /// <summary>
        /// 六曜
        /// </summary>
        public string LiuYao => LunarUtil.LIU_YAO[(Math.Abs(Month) + Day - 2) % 6];

        /// <summary>
        /// 物候
        /// </summary>
        public string WuHou
        {
            get
            {
                var jieQi = GetPrevJieQi(true);
                var offset = 0;
                for (int i = 0, j = JIE_QI.Length; i < j; i++)
                {
                    if (jieQi.Name.Equals(JIE_QI[i]))
                    {
                        offset = i;
                        break;
                    }
                }
                var index = Solar.Subtract(jieQi.Solar) / 5;
                if (index > 2) {
                    index = 2;
                }
                return LunarUtil.WU_HOU[(offset * 3 + index) % LunarUtil.WU_HOU.Length];
            }
        }

        /// <summary>
        /// 候
        /// </summary>
        public string Hou
        {
            get
            {
                var jieQi = GetPrevJieQi(true);
                var max = LunarUtil.HOU.Length - 1;
                var offset = Solar.Subtract(jieQi.Solar) / 5;
                if (offset > max)
                {
                    offset = max;
                }
                return $"{jieQi.Name} {LunarUtil.HOU[offset]}";
            }
        }

        /// <summary>
        /// 日禄
        /// </summary>
        public string DayLu
        {
            get
            {
                var gan = LunarUtil.LU[DayGan];
                string zhi = null;
                try
                {
                    zhi = LunarUtil.LU[DayZhi];
                }
                catch
                {
                    // ignored
                }

                var lu = $"{gan}命互禄";
                if (null != zhi)
                {
                    lu = $"{lu} {zhi}命进禄";
                }
                return lu;
            }
        }

        /// <summary>
        /// 时辰
        /// </summary>
        public LunarTime Time => new LunarTime(Year, Month, Day, Hour, Minute, Second);

        /// <summary>
        /// 当天的时辰列表
        /// </summary>
        public List<LunarTime> Times
        {
            get
            {
                var l = new List<LunarTime> {new LunarTime(Year, Month, Day, 0, 0, 0)};
                for (var i = 0; i < 12; i++)
                {
                    l.Add(new LunarTime(Year, Month, Day, (i + 1) * 2 - 1, 0, 0));
                }
                return l;
            }
        }
    }
}
