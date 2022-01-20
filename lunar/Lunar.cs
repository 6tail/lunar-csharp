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
        /// 日对应的天干下标（八字流派1，晚子时日柱算明天），0-9
        /// </summary>
        private int dayGanIndexExact;

        /// <summary>
        /// 日对应的地支下标（八字流派1，晚子时日柱算明天），0-11
        /// </summary>
        private int dayZhiIndexExact;

        /// <summary>
        /// 日对应的天干下标（八字流派2，晚子时日柱算当天），0-9
        /// </summary>
        private int dayGanIndexExact2;

        /// <summary>
        /// 日对应的地支下标（八字流派2，晚子时日柱算当天），0-11
        /// </summary>
        private int dayZhiIndexExact2;

        /// <summary>
        /// 月对应的天干下标（以节交接当天起算），0-9
        /// </summary>
        private int monthGanIndex;

        /// <summary>
        /// 月对应的地支下标（以节交接当天起算），0-11
        /// </summary>
        private int monthZhiIndex;

        /// <summary>
        /// 月对应的天干下标（八字流派1，晚子时日柱算明天），0-9
        /// </summary>
        private int monthGanIndexExact;

        /// <summary>
        /// 月对应的地支下标（八字流派1，晚子时日柱算明天），0-11
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
        /// 八字
        /// </summary>
        private EightChar eightChar = null;

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
            LunarYear y = LunarYear.fromYear(lunarYear);
            LunarMonth m = y.getMonth(lunarMonth);
            if (null == m)
            {
                throw new ArgumentOutOfRangeException("wrong lunar year " + lunarYear + " month " + lunarMonth);
            }
            if (lunarDay < 1)
            {
                throw new ArgumentOutOfRangeException("lunar day must bigger than 0");
            }
            int days = m.getDayCount();
            if (lunarDay > days)
            {
                throw new ArgumentOutOfRangeException("only " + days + " days in lunar year " + lunarYear + " month " + lunarMonth);
            }
            this.year = lunarYear;
            this.month = lunarMonth;
            this.day = lunarDay;
            this.hour = hour;
            this.minute = minute;
            this.second = second;
            Solar noon = Solar.fromJulianDay(m.getFirstJulianDay() + lunarDay - 1);
            this.solar = Solar.fromYmdHms(noon.getYear(), noon.getMonth(), noon.getDay(), hour, minute, second);
            compute(y);
        }

        /// <summary>
        /// 通过阳历日期初始化
        /// </summary>
        /// <param name="date">阳历日期</param>
        public Lunar(DateTime date)
        {
            solar = new Solar(date);
            int currentYear = solar.getYear();
            int currentMonth = solar.getMonth();
            int currentDay = solar.getDay();
            LunarYear ly = LunarYear.fromYear(currentYear);            
            foreach (LunarMonth m in ly.getMonths())
            {
                // 初一
                Solar firstDay = Solar.fromJulianDay(m.getFirstJulianDay());
                int days = ExactDate.getDaysBetween(firstDay.getYear(), firstDay.getMonth(), firstDay.getDay(), currentYear, currentMonth, currentDay);
                if (days < m.getDayCount())
                {
                    year = m.getYear();
                    month = m.getMonth();
                    day = days + 1;
                    break;
                }
            }
            hour = solar.getHour();
            minute = solar.getMinute();
            second = solar.getSecond();
            compute(ly);
        }

        /// <summary>
        /// 计算节气表
        /// </summary>
        private void computeJieQi(LunarYear lunarYear)
        {
            List<double> julianDays = lunarYear.getJieQiJulianDays();
            for (int i = 0, j = JIE_QI_IN_USE.Length; i < j; i++)
            {
                jieQi.Add(JIE_QI_IN_USE[i], Solar.fromJulianDay(julianDays[i]));
            }
        }

        /// <summary>
        /// 计算干支纪年
        /// </summary>
        private void computeYear()
        {
            //以正月初一开始
            int offset = year - 4;
            yearGanIndex = offset % 10;
            yearZhiIndex = offset % 12;

            if (yearGanIndex < 0)
            {
                yearGanIndex += 10;
            }

            if (yearZhiIndex < 0)
            {
                yearZhiIndex += 12;
            }

            //以立春作为新一年的开始的干支纪年
            int g = yearGanIndex;
            int z = yearZhiIndex;

            //精确的干支纪年，以立春交接时刻为准
            int gExact = yearGanIndex;
            int zExact = yearZhiIndex;

            int solarYear = solar.getYear();
            string solarYmd = solar.toYmd();
            string solarYmdHms = solar.toYmdHms();

            //获取立春的阳历时刻
            Solar liChun = jieQi["立春"];
            if (liChun.getYear() != solarYear)
            {
                liChun = jieQi["LI_CHUN"];
            }
            string liChunYmd = liChun.toYmd();
            string liChunYmdHms = liChun.toYmdHms();

            //阳历和阴历年份相同代表正月初一及以后
            if (year == solarYear)
            {
                //立春日期判断
                if (solarYmd.CompareTo(liChunYmd) < 0)
                {
                    g--;
                    z--;
                }
                //立春交接时刻判断
                if (solarYmdHms.CompareTo(liChunYmdHms) < 0)
                {
                    gExact--;
                    zExact--;
                }
            }
            else if (year < solarYear)
            {
                if (solarYmd.CompareTo(liChunYmd) >= 0)
                {
                    g++;
                    z++;
                }
                if (solarYmdHms.CompareTo(liChunYmdHms) >= 0)
                {
                    gExact++;
                    zExact++;
                }
            }

            yearGanIndexByLiChun = (g < 0 ? g + 10 : g) % 10;
            yearZhiIndexByLiChun = (z < 0 ? z + 12 : z) % 12;

            yearGanIndexExact = (gExact < 0 ? gExact + 10 : gExact) % 10;
            yearZhiIndexExact = (zExact < 0 ? zExact + 12 : zExact) % 12;
        }

        /**
         * 干支纪月计算
         */
        private void computeMonth()
        {
            Solar start = null;
            Solar end;
            string ymd = solar.toYmd();
            string time = solar.toYmdHms();
            int size = JIE_QI_IN_USE.Length;

            //序号：大雪以前-3，大雪到小寒之间-2，小寒到立春之间-1，立春之后0
            int index = -3;
            for (int i = 0; i < size; i += 2)
            {
                end = jieQi[JIE_QI_IN_USE[i]];
                string symd = null == start ? ymd : start.toYmd();
                if (ymd.CompareTo(symd) >= 0 && ymd.CompareTo(end.toYmd()) < 0)
                {
                    break;
                }
                start = end;
                index++;
            }

            //干偏移值（以立春当天起算）
            int offset = (((yearGanIndexByLiChun + (index < 0 ? 1 : 0)) % 5 + 1) * 2) % 10;
            monthGanIndex = ((index < 0 ? index + 10 : index) + offset) % 10;
            monthZhiIndex = ((index < 0 ? index + 12 : index) + LunarUtil.BASE_MONTH_ZHI_INDEX) % 12;

            start = null;
            index = -3;
            for (int i = 0; i < size; i += 2)
            {
                end = jieQi[JIE_QI_IN_USE[i]];
                string stime = null == start ? time : start.toYmdHms();
                if (time.CompareTo(stime) >= 0 && time.CompareTo(end.toYmdHms()) < 0)
                {
                    break;
                }
                start = end;
                index++;
            }

            //干偏移值（以立春交接时刻起算）
            offset = (((yearGanIndexExact + (index < 0 ? 1 : 0)) % 5 + 1) * 2) % 10;
            monthGanIndexExact = ((index < 0 ? index + 10 : index) + offset) % 10;
            monthZhiIndexExact = ((index < 0 ? index + 12 : index) + LunarUtil.BASE_MONTH_ZHI_INDEX) % 12;
        }

        /// <summary>
        /// 干支纪日计算
        /// </summary>
        private void computeDay()
        {
            Solar noon = Solar.fromYmdHms(solar.getYear(), solar.getMonth(), solar.getDay(), 12, 0, 0);
            int offset = (int)noon.getJulianDay() - 11;
            dayGanIndex = offset % 10;
            dayZhiIndex = offset % 12;

            int dayGanExact = dayGanIndex;
            int dayZhiExact = dayZhiIndex;

            // 八字流派2，晚子时（夜子/子夜）日柱算当天
            dayGanIndexExact2 = dayGanExact;
            dayZhiIndexExact2 = dayZhiExact;

            // 八字流派1，晚子时（夜子/子夜）日柱算明天
            string hm = (hour < 10 ? "0" : "") + hour + ":" + (minute < 10 ? "0" : "") + minute;
            if (hm.CompareTo("23:00") >= 0 && hm.CompareTo("23:59") <= 0)
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

            dayGanIndexExact = dayGanExact;
            dayZhiIndexExact = dayZhiExact;
        }

        /// <summary>
        /// 干支纪时计算
        /// </summary>
        private void computeTime()
        {
            string hm = (hour < 10 ? "0" : "") + hour + ":" + (minute < 10 ? "0" : "") + minute;
            timeZhiIndex = LunarUtil.getTimeZhiIndex(hm);
            timeGanIndex = (dayGanIndexExact % 5 * 2 + timeZhiIndex) % 10;
        }

        /// <summary>
        /// 星期计算
        /// </summary>
        private void computeWeek()
        {
            this.weekIndex = solar.getWeek();
        }

        private void compute(LunarYear lunarYear)
        {
            computeJieQi(lunarYear);
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

        /// <summary>
        /// 获取日天干（八字流派1，晚子时日柱算明天）
        /// </summary>
        /// <returns>日天干，如甲</returns>
        public string getDayGanExact()
        {
            return LunarUtil.GAN[dayGanIndexExact + 1];
        }

        /// <summary>
        /// 获取日天干（八字流派2，晚子时日柱算当天）
        /// </summary>
        /// <returns>日天干，如甲</returns>
        public string getDayGanExact2()
        {
            return LunarUtil.GAN[dayGanIndexExact2 + 1];
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
        /// 获取日地支（八字流派1，晚子时日柱算明天）
        /// </summary>
        /// <returns>日地支，如卯</returns>
        public string getDayZhiExact()
        {
            return LunarUtil.ZHI[dayZhiIndexExact + 1];
        }

        /// <summary>
        /// 获取日地支（八字流派2，晚子时日柱算当天）
        /// </summary>
        /// <returns>日地支，如卯</returns>
        public string getDayZhiExact2()
        {
            return LunarUtil.ZHI[dayZhiIndexExact2 + 1];
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

        /// <summary>
        /// 获取干支纪日（日柱，八字流派1，晚子时日柱算明天）
        /// </summary>
        /// <returns>干支纪日（日柱），如己卯</returns>
        public string getDayInGanZhiExact()
        {
            return getDayGanExact() + getDayZhiExact();
        }

        /// <summary>
        /// 获取干支纪日（日柱，八字流派2，晚子时日柱算当天）
        /// </summary>
        /// <returns>干支纪日（日柱），如己卯</returns>
        public string getDayInGanZhiExact2()
        {
            return getDayGanExact2() + getDayZhiExact2();
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

        /// <summary>
        /// 获取节
        /// </summary>
        /// <returns>节</returns>
        public string getJie()
        {
            for (int i = 0, j = JIE_QI_IN_USE.Length; i < j; i += 2)
            {
                string key = JIE_QI_IN_USE[i];
                Solar d = jieQi[key];
                if (d.getYear() == solar.getYear() && d.getMonth() == solar.getMonth() && d.getDay() == solar.getDay())
                {
                    return convertJieQi(key);
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
            for (int i = 1, j = JIE_QI_IN_USE.Length; i < j; i += 2)
            {
                string key = JIE_QI_IN_USE[i];
                Solar d = jieQi[key];
                if (d.getYear() == solar.getYear() && d.getMonth() == solar.getMonth() && d.getDay() == solar.getDay())
                {
                    return convertJieQi(key);
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
            if (Math.Abs(month) == 12 && day >= 29 && year != next(1).getYear()) {
                l.Add("除夕");
            }
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

        [Obsolete("This method is obsolete, use method getDayPositionXi instead")]
        public string getPositionXi()
        {
            return getDayPositionXi();
        }

        [Obsolete("This method is obsolete, use method getDayPositionXiDesc instead")]
        public string getPositionXiDesc()
        {
            return getDayPositionXiDesc();
        }

        [Obsolete("This method is obsolete, use method getDayPositionYangGui instead")]
        public string getPositionYangGui()
        {
            return getDayPositionYangGui();
        }

        [Obsolete("This method is obsolete, use method getDayPositionYangGuiDesc instead")]
        public string getPositionYangGuiDesc()
        {
            return getDayPositionYangGuiDesc();
        }

        [Obsolete("This method is obsolete, use method getDayPositionYinGui instead")]
        public string getPositionYinGui()
        {
            return getDayPositionYinGui();
        }

        [Obsolete("This method is obsolete, use method getDayPositionYinGuiDesc instead")]
        public string getPositionYinGuiDesc()
        {
            return getDayPositionYinGuiDesc();
        }

        [Obsolete("This method is obsolete, use method getDayPositionFu instead")]
        public string getPositionFu()
        {
            return getDayPositionFu();
        }

        [Obsolete("This method is obsolete, use method getDayPositionFuDesc instead")]
        public string getPositionFuDesc()
        {
            return getDayPositionFuDesc();
        }

        [Obsolete("This method is obsolete, use method getDayPositionCai instead")]
        public string getPositionCai()
        {
            return getDayPositionCai();
        }

        [Obsolete("This method is obsolete, use method getDayPositionCaiDesc instead")]
        public string getPositionCaiDesc()
        {
            return getDayPositionCaiDesc();
        }

        /// <summary>
        /// 获取日喜神方位
        /// </summary>
        /// <returns>喜神方位，如艮</returns>
        public string getDayPositionXi()
        {
            return LunarUtil.POSITION_XI[dayGanIndex + 1];
        }

        /// <summary>
        /// 获取日喜神方位描述
        /// </summary>
        /// <returns>喜神方位描述，如东北</returns>
        public string getDayPositionXiDesc()
        {
            return LunarUtil.POSITION_DESC[getDayPositionXi()];
        }

        /// <summary>
        /// 获取日阳贵神方位
        /// </summary>
        /// <returns>阳贵神方位，如艮</returns>
        public string getDayPositionYangGui()
        {
            return LunarUtil.POSITION_YANG_GUI[dayGanIndex + 1];
        }

        /// <summary>
        /// 获取日阳贵神方位描述
        /// </summary>
        /// <returns>阳贵神方位描述，如东北</returns>
        public string getDayPositionYangGuiDesc()
        {
            return LunarUtil.POSITION_DESC[getDayPositionYangGui()];
        }

        /// <summary>
        /// 获取日阴贵神方位
        /// </summary>
        /// <returns>阴贵神方位，如艮</returns>
        public string getDayPositionYinGui()
        {
            return LunarUtil.POSITION_YIN_GUI[dayGanIndex + 1];
        }

        /// <summary>
        /// 获取日阴贵神方位描述
        /// </summary>
        /// <returns>阴贵神方位描述，如东北</returns>
        public string getDayPositionYinGuiDesc()
        {
            return LunarUtil.POSITION_DESC[getDayPositionYinGui()];
        }

        /// <summary>
        /// 获取日福神方位
        /// </summary>
        /// <returns>福神方位，如艮</returns>
        public string getDayPositionFu()
        {
            return getDayPositionFu(2);
        }

        /// <summary>
        /// 获取日福神方位
        /// </summary>
        /// <param name="sect">流派，可选1或2</param>
        /// <returns>福神方位，如艮</returns>
        public string getDayPositionFu(int sect)
        {
            return (1 == sect ? LunarUtil.POSITION_FU : LunarUtil.POSITION_FU_2)[dayGanIndex + 1];
        }

        /// <summary>
        /// 获取日福神方位描述
        /// </summary>
        /// <returns>方位描述，如东北</returns>
        public string getDayPositionFuDesc()
        {
            return getDayPositionFuDesc(2);
        }

        /// <summary>
        /// 获取日福神方位描述
        /// </summary>
        /// <param name="sect">流派，可选1或2</param>
        /// <returns>方位描述，如东北</returns>
        public string getDayPositionFuDesc(int sect)
        {
            return LunarUtil.POSITION_DESC[getDayPositionFu(sect)];
        }

        /// <summary>
        /// 获取日财神方位
        /// </summary>
        /// <returns>方位，如艮</returns>
        public string getDayPositionCai()
        {
            return LunarUtil.POSITION_CAI[dayGanIndex + 1];
        }

        /// <summary>
        /// 获取日财神方位描述
        /// </summary>
        /// <returns>方位描述，如东北</returns>
        public string getDayPositionCaiDesc()
        {
            return LunarUtil.POSITION_DESC[getDayPositionCai()];
        }

        /// <summary>
        /// 获取年太岁方位
        /// </summary>
        /// <param name="sect">流派：2为新年以立春零点起算；1为新年以正月初一起算；3为新年以立春节气交接的时刻起算</param>
        /// <returns>方位</returns>
        public string getYearPositionTaiSui(int sect)
        {
            int yearZhiIndex;
            switch (sect)
            {
                case 1:
                    yearZhiIndex = this.yearZhiIndex;
                    break;
                case 3:
                    yearZhiIndex = this.yearZhiIndexExact;
                    break;
                default:
                    yearZhiIndex = this.yearZhiIndexByLiChun;
                    break;
            }
            return LunarUtil.POSITION_TAI_SUI_YEAR[yearZhiIndex];
        }

        /// <summary>
        /// 获取年太岁方位（默认流派2新年以立春零点起算）
        /// </summary>
        /// <returns>方位</returns>
        public string getYearPositionTaiSui()
        {
            return getYearPositionTaiSui(2);
        }

        /// <summary>
        /// 获取年太岁方位描述
        /// </summary>
        /// <param name="sect">流派：2为新年以立春零点起算；1为新年以正月初一起算；3为新年以立春节气交接的时刻起算</param>
        /// <returns>方位描述，如东北</returns>
        public string getYearPositionTaiSuiDesc(int sect)
        {
            return LunarUtil.POSITION_DESC[getYearPositionTaiSui(sect)];
        }

        protected string getMonthPositionTaiSui(int monthZhiIndex, int monthGanIndex)
        {
            string p;
            int m = monthZhiIndex - LunarUtil.BASE_MONTH_ZHI_INDEX;
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
        /// 获取月太岁方位（默认流派2新的一月以节交接当天零点起算）
        /// </summary>
        /// <returns>方位，如艮</returns>
        public string getMonthPositionTaiSui()
        {
            return getMonthPositionTaiSui(2);
        }

        /// <summary>
        /// 获取月太岁方位
        /// </summary>
        /// <param name="sect">流派：2为新的一月以节交接当天零点起算；3为新的一月以节交接准确时刻起算</param>
        /// <returns>方位，如艮</returns>
        public string getMonthPositionTaiSui(int sect)
        {
            int monthZhiIndex;
            int monthGanIndex;
            switch (sect)
            {
                case 3:
                    monthZhiIndex = this.monthZhiIndexExact;
                    monthGanIndex = this.monthGanIndexExact;
                    break;
                default:
                    monthZhiIndex = this.monthZhiIndex;
                    monthGanIndex = this.monthGanIndex;
                    break;
            }
            return getMonthPositionTaiSui(monthZhiIndex, monthGanIndex);
        }

        /// <summary>
        /// 获取月太岁方位描述（默认流派2新的一月以节交接当天零点起算）
        /// </summary>
        /// <returns>方位描述，如东北</returns>
        public string getMonthPositionTaiSuiDesc()
        {
            return getMonthPositionTaiSuiDesc(2);
        }

        /// <summary>
        /// 获取月太岁方位描述
        /// </summary>
        /// <param name="sect">流派：2为新的一月以节交接当天零点起算；3为新的一月以节交接准确时刻起算</param>
        /// <returns>方位描述，如东北</returns>
        public string getMonthPositionTaiSuiDesc(int sect)
        {
            return LunarUtil.POSITION_DESC[getMonthPositionTaiSui(sect)];
        }

        protected string getDayPositionTaiSui(string dayInGanZhi, int yearZhiIndex)
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
        /// 获取日太岁方位（默认流派2新年以立春零点起算）
        /// </summary>
        /// <returns>方位，如艮</returns>
        public string getDayPositionTaiSui()
        {
            return getDayPositionTaiSui(2);
        }

        /// <summary>
        /// 获取日太岁方位
        /// </summary>
        /// <param name="sect">流派：2新年以立春零点起算；1新年以正月初一起算；3新年以立春节气交接的时刻起算</param>
        /// <returns>方位，如艮</returns>
        public string getDayPositionTaiSui(int sect)
        {
            string dayInGanZhi;
            int yearZhiIndex;
            switch (sect)
            {
                case 1:
                    dayInGanZhi = getDayInGanZhi();
                    yearZhiIndex = this.yearZhiIndex;
                    break;
                case 3:
                    dayInGanZhi = getDayInGanZhi();
                    yearZhiIndex = this.yearZhiIndexExact;
                    break;
                default:
                    dayInGanZhi = getDayInGanZhiExact2();
                    yearZhiIndex = this.yearZhiIndexByLiChun;
                    break;
            }
            return getDayPositionTaiSui(dayInGanZhi, yearZhiIndex);
        }

        /// <summary>
        /// 获取日太岁方位描述（默认流派2新年以立春零点起算）
        /// </summary>
        /// <returns>方位描述，如东北</returns>
        public string getDayPositionTaiSuiDesc()
        {
            return getDayPositionTaiSuiDesc(2);
        }

        /// <summary>
        /// 获取日太岁方位描述
        /// </summary>
        /// <param name="sect">流派：2新年以立春零点起算；1新年以正月初一起算；3新年以立春节气交接的时刻起算</param>
        /// <returns>方位描述，如东北</returns>
        public string getDayPositionTaiSuiDesc(int sect)
        {
            return LunarUtil.POSITION_DESC[getDayPositionTaiSui(sect)];
        }

        /// <summary>
        /// 获取年太岁方位描述（默认流派2新年以立春零点起算）
        /// </summary>
        /// <returns>方位描述</returns>
        public string getYearPositionTaiSuiDesc()
        {
            return getYearPositionTaiSuiDesc(2);
        }

        /// <summary>
        /// 获取时辰喜神方位
        /// </summary>
        /// <returns>喜神方位，如艮</returns>
        public string getTimePositionXi()
        {
            return LunarUtil.POSITION_XI[timeGanIndex + 1];
        }

        /// <summary>
        /// 获取时辰喜神方位描述
        /// </summary>
        /// <returns>喜神方位描述，如东北</returns>
        public string getTimePositionXiDesc()
        {
            return LunarUtil.POSITION_DESC[getTimePositionXi()];
        }

        /// <summary>
        /// 获取时辰阳贵神方位
        /// </summary>
        /// <returns>阳贵神方位，如艮</returns>
        public string getTimePositionYangGui()
        {
            return LunarUtil.POSITION_YANG_GUI[timeGanIndex + 1];
        }

        /// <summary>
        /// 获取时辰阳贵神方位描述
        /// </summary>
        /// <returns>阳贵神方位描述，如东北</returns>
        public string getTimePositionYangGuiDesc()
        {
            return LunarUtil.POSITION_DESC[getTimePositionYangGui()];
        }

        /// <summary>
        /// 获取时辰阴贵神方位
        /// </summary>
        /// <returns>阴贵神方位，如艮</returns>
        public string getTimePositionYinGui()
        {
            return LunarUtil.POSITION_YIN_GUI[timeGanIndex + 1];
        }

        /// <summary>
        /// 获取时辰阴贵神方位描述
        /// </summary>
        /// <returns>阴贵神方位描述，如东北</returns>
        public string getTimePositionYinGuiDesc()
        {
            return LunarUtil.POSITION_DESC[getTimePositionYinGui()];
        }

        /// <summary>
        /// 获取时辰福神方位
        /// </summary>
        /// <returns>福神方位，如艮</returns>
        public string getTimePositionFu()
        {
            return getTimePositionFu(2);
        }

        /// <summary>
        /// 获取时辰福神方位
        /// </summary>
        /// <param name="sect">流派，可选1或2</param>
        /// <returns>福神方位，如艮</returns>
        public string getTimePositionFu(int sect)
        {
            return (1 == sect ? LunarUtil.POSITION_FU : LunarUtil.POSITION_FU_2)[timeGanIndex + 1];
        }

        /// <summary>
        /// 获取时辰福神方位描述
        /// </summary>
        /// <returns>福神方位描述，如东北</returns>
        public string getTimePositionFuDesc()
        {
            return getTimePositionFuDesc(2);
        }

        /// <summary>
        /// 获取时辰福神方位描述
        /// </summary>
        /// <param name="sect">流派，可选1或2</param>
        /// <returns>福神方位描述，如东北</returns>
        public string getTimePositionFuDesc(int sect)
        {
            return LunarUtil.POSITION_DESC[getTimePositionFu(sect)];
        }

        /// <summary>
        /// 获取时辰财神方位
        /// </summary>
        /// <returns>财神方位，如艮</returns>
        public string getTimePositionCai()
        {
            return LunarUtil.POSITION_CAI[timeGanIndex + 1];
        }

        /// <summary>
        /// 获取时辰财神方位描述
        /// </summary>
        /// <returns>财神方位描述，如东北</returns>
        public string getTimePositionCaiDesc()
        {
            return LunarUtil.POSITION_DESC[getTimePositionCai()];
        }

        [Obsolete("This method is obsolete, use method getDayChong instead")]
        public string getChong()
        {
            return getDayChong();
        }

        /// <summary>
        /// 获取日冲
        /// </summary>
        /// <returns>日冲，如申</returns>
        public string getDayChong()
        {
            return LunarUtil.CHONG[dayZhiIndex + 1];
        }

        /// <summary>
        /// 获取时冲
        /// </summary>
        /// <returns>时冲，如申</returns>
        public string getTimeChong()
        {
            return LunarUtil.CHONG[timeZhiIndex + 1];
        }

        [Obsolete("This method is obsolete, use method getDayChongGan instead")]
        public string getChongGan()
        {
            return getDayChongGan();
        }

        /// <summary>
        /// 获取无情之克的日冲天干
        /// </summary>
        /// <returns>无情之克的日冲天干，如甲</returns>
        public string getDayChongGan()
        {
            return LunarUtil.CHONG_GAN[dayGanIndex + 1];
        }

        /// <summary>
        /// 获取无情之克的时冲天干
        /// </summary>
        /// <returns>无情之克的时冲天干，如甲</returns>
        public string getTimeChongGan()
        {
            return LunarUtil.CHONG_GAN[timeGanIndex + 1];
        }

        [Obsolete("This method is obsolete, use method getDayChongGanTie instead")]
        public string getChongGanTie()
        {
            return getDayChongGanTie();
        }

        /// <summary>
        /// 获取有情之克的日冲天干
        /// </summary>
        /// <returns>有情之克的日冲天干，如甲</returns>
        public string getDayChongGanTie()
        {
            return LunarUtil.CHONG_GAN_TIE[dayGanIndex + 1];
        }

        /// <summary>
        /// 获取有情之克的时冲天干
        /// </summary>
        /// <returns>有情之克的时冲天干，如甲</returns>
        public string getTimeChongGanTie()
        {
            return LunarUtil.CHONG_GAN_TIE[timeGanIndex + 1];
        }

        [Obsolete("This method is obsolete, use method getDayChongShengXiao instead")]
        public string getChongShengXiao()
        {
            return getDayChongShengXiao();
        }

        /// <summary>
        /// 获取日冲生肖
        /// </summary>
        /// <returns>日冲生肖，如猴</returns>
        public string getDayChongShengXiao()
        {
            string chong = getDayChong();
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
        /// 获取时冲生肖
        /// </summary>
        /// <returns>时冲生肖，如猴</returns>
        public string getTimeChongShengXiao()
        {
            string chong = getTimeChong();
            for (int i = 0, j = LunarUtil.ZHI.Length; i < j; i++)
            {
                if (LunarUtil.ZHI[i].Equals(chong))
                {
                    return LunarUtil.SHENGXIAO[i];
                }
            }
            return "";
        }

        [Obsolete("This method is obsolete, use method getDayChongDesc instead")]
        public string getChongDesc()
        {
            return getDayChongDesc();
        }

        /// <summary>
        /// 获取日冲描述
        /// </summary>
        /// <returns>日冲描述，如(壬申)猴</returns>
        public string getDayChongDesc()
        {
            return "(" + getDayChongGan() + getDayChong() + ")" + getDayChongShengXiao();
        }

        /// <summary>
        /// 获取时冲描述
        /// </summary>
        /// <returns>时冲描述，如(壬申)猴</returns>
        public string getTimeChongDesc()
        {
            return "(" + getTimeChongGan() + getTimeChong() + ")" + getTimeChongShengXiao();
        }

        [Obsolete("This method is obsolete, use method getDaySha instead")]
        public string getSha()
        {
            return getDaySha();
        }

        /// <summary>
        /// 获取日煞
        /// </summary>
        /// <returns>日煞，如北</returns>
        public string getDaySha()
        {
            return LunarUtil.SHA[getDayZhi()];
        }

        /// <summary>
        /// 获取时煞
        /// </summary>
        /// <returns>时煞，如北</returns>
        public string getTimeSha()
        {
            return LunarUtil.SHA[getTimeZhi()];
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

        [Obsolete("This method is obsolete, use method getEightChar instead")]
        public List<string> getBaZi()
        {
            EightChar baZi = getEightChar();
            List<string> l = new List<string>(4);
            l.Add(baZi.getYear());
            l.Add(baZi.getMonth());
            l.Add(baZi.getDay());
            l.Add(baZi.getTime());
            return l;
        }

        [Obsolete("This method is obsolete, use method getEightChar instead")]
        public List<string> getBaZiWuXing()
        {
            EightChar baZi = getEightChar();
            List<string> l = new List<string>(4);
            l.Add(baZi.getYearWuXing());
            l.Add(baZi.getMonthWuXing());
            l.Add(baZi.getDayWuXing());
            l.Add(baZi.getTimeWuXing());
            return l;
        }

        [Obsolete("This method is obsolete, use method getEightChar instead")]
        public List<string> getBaZiNaYin()
        {
            EightChar baZi = getEightChar();
            List<string> l = new List<string>(4);
            l.Add(baZi.getYearNaYin());
            l.Add(baZi.getMonthNaYin());
            l.Add(baZi.getDayNaYin());
            l.Add(baZi.getTimeNaYin());
            return l;
        }

        [Obsolete("This method is obsolete, use method getEightChar instead")]
        public List<string> getBaZiShiShenGan()
        {
            EightChar baZi = getEightChar();
            List<string> l = new List<string>(4);
            l.Add(baZi.getYearNaYin());
            l.Add(baZi.getMonthNaYin());
            l.Add(baZi.getDayNaYin());
            l.Add(baZi.getTimeNaYin());
            return l;
        }

        [Obsolete("This method is obsolete, use method getEightChar instead")]
        public List<string> getBaZiShiShenZhi()
        {
            EightChar baZi = getEightChar();
            List<string> l = new List<string>(4);
            l.Add(baZi.getYearShiShenZhi()[0]);
            l.Add(baZi.getMonthShiShenZhi()[0]);
            l.Add(baZi.getDayShiShenZhi()[0]);
            l.Add(baZi.getTimeShiShenZhi()[0]);
            return l;
        }

        [Obsolete("This method is obsolete, use method getEightChar instead")]
        public List<string> getBaZiShiShenYearZhi()
        {
            return eightChar.getYearShiShenZhi();
        }

        [Obsolete("This method is obsolete, use method getEightChar instead")]
        public List<string> getBaZiShiShenMonthZhi()
        {
            return eightChar.getMonthShiShenZhi();
        }

        [Obsolete("This method is obsolete, use method getEightChar instead")]
        public List<string> getBaZiShiShenDayZhi()
        {
            return eightChar.getDayShiShenZhi();
        }

        [Obsolete("This method is obsolete, use method getEightChar instead")]
        public List<string> getBaZiShiShenTimeZhi()
        {
            return eightChar.getTimeShiShenZhi();
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
            int offset = LunarUtil.ZHI_TIAN_SHEN_OFFSET[monthZhi];
            return LunarUtil.TIAN_SHEN[(dayZhiIndex + offset) % 12 + 1];
        }

        /// <summary>
        /// 获取值时天神
        /// </summary>
        /// <returns>值时天神</returns>
        public string getTimeTianShen()
        {
            string dayZhi = getDayZhiExact();
            int offset = LunarUtil.ZHI_TIAN_SHEN_OFFSET[dayZhi];
            return LunarUtil.TIAN_SHEN[(timeZhiIndex + offset) % 12 + 1];
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
        /// 获取值时天神类型：黄道/黑道
        /// </summary>
        /// <returns>值时天神类型：黄道/黑道</returns>
        public string getTimeTianShenType()
        {
            return LunarUtil.TIAN_SHEN_TYPE[getTimeTianShen()];
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
        /// 获取值时天神吉凶
        /// </summary>
        /// <returns>吉/凶</returns>
        public string getTimeTianShenLuck()
        {
            return LunarUtil.TIAN_SHEN_TYPE_LUCK[getTimeTianShenType()];
        }

        /// <summary>
        /// 获取逐日胎神方位
        /// </summary>
        /// <returns>逐日胎神方位</returns>
        public string getDayPositionTai()
        {
            return LunarUtil.POSITION_TAI_DAY[LunarUtil.getJiaZiIndex(getDayInGanZhi())];
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

        /// <summary>
        /// 获取每日宜，如果没有，返回["无"]
        /// </summary>
        /// <returns>宜</returns>
        public List<string> getDayYi()
        {
            return LunarUtil.getDayYi(getMonthInGanZhiExact(), getDayInGanZhi());
        }

        /// <summary>
        /// 获取每日忌，如果没有，返回["无"]
        /// </summary>
        /// <returns>忌</returns>
        public List<string> getDayJi()
        {
            return LunarUtil.getDayJi(getMonthInGanZhiExact(), getDayInGanZhi());
        }

        /// <summary>
        /// 获取日吉神（宜趋），如果没有，返回["无"]
        /// </summary>
        /// <returns>日吉神</returns>
        public List<string> getDayJiShen()
        {
            return LunarUtil.getDayJiShen(getMonth(), getDayInGanZhi());
        }

        /// <summary>
        /// 获取日凶煞（宜忌），如果没有，返回["无"]
        /// </summary>
        /// <returns>日凶煞</returns>
        public List<string> getDayXiongSha()
        {
            return LunarUtil.getDayXiongSha(getMonth(), getDayInGanZhi());
        }

        /// <summary>
        /// 获取时辰宜，如果没有，返回["无"]
        /// </summary>
        /// <returns>宜</returns>
        public List<string> getTimeYi()
        {
            return LunarUtil.getTimeYi(getDayInGanZhiExact(), getTimeInGanZhi());
        }

        /// <summary>
        /// 获取时辰忌，如果没有，返回["无"]
        /// </summary>
        /// <returns>忌</returns>
        public List<string> getTimeJi()
        {
            return LunarUtil.getTimeJi(getDayInGanZhiExact(), getTimeInGanZhi());
        }

        /// <summary>
        /// 获取月相
        /// </summary>
        /// <returns>月相</returns>
        public string getYueXiang()
        {
            return LunarUtil.YUE_XIANG[day];
        }

        protected NineStar getYearNineStar(string yearInGanZhi)
        {
            int index = LunarUtil.getJiaZiIndex(yearInGanZhi) + 1;
            int yearOffset = 0;
            if (index != LunarUtil.getJiaZiIndex(this.getYearInGanZhi()) + 1)
            {
                yearOffset = -1;
            }
            int yuan = ((this.year + yearOffset + 2696) / 60) % 3;
            int offset = (62 + yuan * 3 - index) % 9;
            if (0 == offset)
            {
                offset = 9;
            }
            return NineStar.fromIndex(offset - 1);
        }

        /// <summary>
        /// 获取值年九星（流年紫白星起例歌诀：年上吉星论甲子，逐年星逆中宫起；上中下作三元汇，一上四中七下兑。）
        /// </summary>
        /// <param name="sect">流派：2为新年以立春零点起算；1为新年以正月初一起算；3为新年以立春节气交接的时刻起算</param>
        /// <returns>九星</returns>
        public NineStar getYearNineStar(int sect)
        {
            string yearInGanZhi;
            switch (sect)
            {
                case 1:
                    yearInGanZhi = this.getYearInGanZhi();
                    break;
                case 3:
                    yearInGanZhi = this.getYearInGanZhiExact();
                    break;
                default:
                    yearInGanZhi = this.getYearInGanZhiByLiChun();
                    break;
            }
            return getYearNineStar(yearInGanZhi);
        }

        /// <summary>
        /// 获取值年九星（默认流派2新年以立春零点起算。流年紫白星起例歌诀：年上吉星论甲子，逐年星逆中宫起；上中下作三元汇，一上四中七下兑。）
        /// </summary>
        /// <returns>九星</returns>
        public NineStar getYearNineStar()
        {
            return getYearNineStar(2);
        }

        protected NineStar getMonthNineStar(int yearZhiIndex, int monthZhiIndex)
        {
            int index = yearZhiIndex % 3;
            int n = 27 - (index * 3);
            if (monthZhiIndex < LunarUtil.BASE_MONTH_ZHI_INDEX)
            {
                n -= 3;
            }
            int offset = (n - monthZhiIndex) % 9;
            return NineStar.fromIndex(offset);
        }

        /// <summary>
        /// 获取值月九星（月紫白星歌诀：子午卯酉八白起，寅申巳亥二黑求，辰戌丑未五黄中。）
        /// </summary>
        /// <param name="sect">流派：2为新的一月以节交接当天零点起算；3为新的一月以节交接准确时刻起算</param>
        /// <returns>九星</returns>
        public NineStar getMonthNineStar(int sect)
        {
            int yearZhiIndex;
            int monthZhiIndex;
            switch (sect)
            {
                case 1:
                    yearZhiIndex = this.yearZhiIndex;
                    monthZhiIndex = this.monthZhiIndex;
                    break;
                case 3:
                    yearZhiIndex = this.yearZhiIndexExact;
                    monthZhiIndex = this.monthZhiIndexExact;
                    break;
                default:
                    yearZhiIndex = this.yearZhiIndexByLiChun;
                    monthZhiIndex = this.monthZhiIndex;
                    break;
            }
            return getMonthNineStar(yearZhiIndex, monthZhiIndex);
        }

        /// <summary>
        /// 获取值月九星（流派2新的一月以节交接当天零点起算。月紫白星歌诀：子午卯酉八白起，寅申巳亥二黑求，辰戌丑未五黄中。）
        /// </summary>
        /// <returns>九星</returns>
        public NineStar getMonthNineStar()
        {
            return getMonthNineStar(2);
        }

        /// <summary>
        /// 获取值日九星（日家紫白星歌诀：日家白法不难求，二十四气六宫周；冬至雨水及谷雨，阳顺一七四中游；夏至处暑霜降后，九三六星逆行求。）
        /// </summary>
        /// <returns>九星</returns>
        public NineStar getDayNineStar()
        {
            string solarYmd = solar.toYmd();
            Solar dongZhi = jieQi["冬至"];
            Solar dongZhi2 = jieQi["DONG_ZHI"];
            Solar xiaZhi = jieQi["夏至"];
            int dongZhiIndex = LunarUtil.getJiaZiIndex(dongZhi.getLunar().getDayInGanZhi());
            int dongZhiIndex2 = LunarUtil.getJiaZiIndex(dongZhi2.getLunar().getDayInGanZhi());
            int xiaZhiIndex = LunarUtil.getJiaZiIndex(xiaZhi.getLunar().getDayInGanZhi());
            Solar solarShunBai;
            Solar solarShunBai2;
            Solar solarNiZi;
            if (dongZhiIndex > 29)
            {
                solarShunBai = dongZhi.next(60 - dongZhiIndex);
            }
            else
            {
                solarShunBai = dongZhi.next(-dongZhiIndex);
            }
            string solarShunBaiYmd = solarShunBai.toYmd();
            if (dongZhiIndex2 > 29)
            {
                solarShunBai2 = dongZhi2.next(60 - dongZhiIndex2);
            }
            else
            {
                solarShunBai2 = dongZhi2.next(-dongZhiIndex2);
            }
            string solarShunBaiYmd2 = solarShunBai2.toYmd();
            if (xiaZhiIndex > 29)
            {
                solarNiZi = xiaZhi.next(60 - xiaZhiIndex);
            }
            else
            {
                solarNiZi = xiaZhi.next(-xiaZhiIndex);
            }
            string solarNiZiYmd = solarNiZi.toYmd();
            int offset = 0;
            if (solarYmd.CompareTo(solarShunBaiYmd) >= 0 && solarYmd.CompareTo(solarNiZiYmd) < 0)
            {
                offset = ExactDate.getDaysBetween(solarShunBai.getCalendar(), this.getSolar().getCalendar()) % 9;
            }
            else if (solarYmd.CompareTo(solarNiZiYmd) >= 0 && solarYmd.CompareTo(solarShunBaiYmd2) < 0)
            {
                offset = 8 - (ExactDate.getDaysBetween(solarNiZi.getCalendar(), this.getSolar().getCalendar()) % 9);
            }
            else if (solarYmd.CompareTo(solarShunBaiYmd2) >= 0)
            {
                offset = ExactDate.getDaysBetween(solarShunBai2.getCalendar(), this.getSolar().getCalendar()) % 9;
            }
            else if (solarYmd.CompareTo(solarShunBaiYmd) < 0)
            {
                offset = (8 + ExactDate.getDaysBetween(this.getSolar().getCalendar(), solarShunBai.getCalendar())) % 9;
            }
            return NineStar.fromIndex(offset);
        }

        /// <summary>
        /// 获取值时九星（时家紫白星歌诀：三元时白最为佳，冬至阳生顺莫差，孟日七宫仲一白，季日四绿发萌芽，每把时辰起甲子，本时星耀照光华，时星移入中宫去，顺飞八方逐细查。夏至阴生逆回首，孟归三碧季加六，仲在九宫时起甲，依然掌中逆轮跨。）
        /// </summary>
        /// <returns>值时九星</returns>
        public NineStar getTimeNineStar()
        {
            //顺逆
            string solarYmd = solar.toYmd();
            bool asc = false;
            if (solarYmd.CompareTo(jieQi["冬至"].toYmd()) >= 0 && solarYmd.CompareTo(jieQi["夏至"].toYmd()) < 0)
            {
                asc = true;
            }
            else if (solarYmd.CompareTo(jieQi["DONG_ZHI"].toYmd()) >= 0)
            {
                asc = true;
            }
            int start = asc ? 6 : 2;
            string dayZhi = getDayZhi();
            if ("子午卯酉".Contains(dayZhi))
            {
                start = asc ? 0 : 8;
            }
            else if ("辰戌丑未".Contains(dayZhi))
            {
                start = asc ? 3 : 5;
            }
            int index = asc ? start + timeZhiIndex : start + 9 - timeZhiIndex;
            return new NineStar(index % 9);
        }

        public Dictionary<string, Solar> getJieQiTable()
        {
            return jieQi;
        }

        /// <summary>
        /// 获取下一节（顺推的第一个节）
        /// </summary>
        /// <returns>节气</returns>
        public JieQi getNextJie()
        {
            return getNextJie(false);
        }

        /// <summary>
        /// 获取下一节（顺推的第一个节）
        /// </summary>
        /// <param name="wholeDay">是否按天计</param>
        /// <returns>节气</returns>
        public JieQi getNextJie(bool wholeDay)
        {
            int l = JIE_QI_IN_USE.Length / 2;
            string[] conditions = new string[l];
            for (int i = 0; i < l; i++)
            {
                conditions[i] = JIE_QI_IN_USE[i * 2];
            }
            return getNearJieQi(true, conditions, wholeDay);
        }

         /// <summary>
        /// 获取上一节（逆推的第一个节）
        /// </summary>
        /// <returns>节气</returns>
        public JieQi getPrevJie()
        {
            return getPrevJie(false);
        }

        /// <summary>
        /// 获取上一节（逆推的第一个节）
        /// </summary>
        /// <param name="wholeDay">是否按天计</param>
        /// <returns>节气</returns>
        public JieQi getPrevJie(bool wholeDay)
        {
            int l = JIE_QI_IN_USE.Length / 2;
            string[] conditions = new string[l];
            for (int i = 0; i < l; i++)
            {
                conditions[i] = JIE_QI_IN_USE[i * 2];
            }
            return getNearJieQi(false, conditions, wholeDay);
        }

        /// <summary>
        /// 获取下一气令（顺推的第一个气令）
        /// </summary>
        /// <returns>节气</returns>
        public JieQi getNextQi()
        {
            return getNextQi(false);
        }

        /// <summary>
        /// 获取下一气令（顺推的第一个气令）
        /// </summary>
        /// <param name="wholeDay">是否按天计</param>
        /// <returns>节气</returns>
        public JieQi getNextQi(bool wholeDay)
        {
            int l = JIE_QI_IN_USE.Length / 2;
            string[] conditions = new string[l];
            for (int i = 0; i < l; i++)
            {
                conditions[i] = JIE_QI_IN_USE[i * 2 + 1];
            }
            return getNearJieQi(true, conditions, wholeDay);
        }

        /// <summary>
        /// 获取上一气令（逆推的第一个气令）
        /// </summary>
        /// <returns>节气</returns>
        public JieQi getPrevQi()
        {
            return getPrevQi(false);
        }

        /// <summary>
        /// 获取上一气令（逆推的第一个气令）
        /// </summary>
        /// <param name="wholeDay">是否按天计</param>
        /// <returns>节气</returns>
        public JieQi getPrevQi(bool wholeDay)
        {
            int l = JIE_QI_IN_USE.Length / 2;
            string[] conditions = new string[l];
            for (int i = 0; i < l; i++)
            {
                conditions[i] = JIE_QI_IN_USE[i * 2 + 1];
            }
            return getNearJieQi(false, conditions, wholeDay);
        }

        /// <summary>
        /// 获取下一节气（顺推的第一个节气）
        /// </summary>
        /// <returns>节气</returns>
        public JieQi getNextJieQi()
        {
            return getNextJieQi(false);
        }

        /// <summary>
        /// 获取下一节气（顺推的第一个节气）
        /// </summary>
        /// <param name="wholeDay">是否按天计</param>
        /// <returns>节气</returns>
        public JieQi getNextJieQi(bool wholeDay)
        {
            return getNearJieQi(true, null, wholeDay);
        }

        /// <summary>
        /// 获取上一节气（逆推的第一个节气）
        /// </summary>
        /// <returns>节气</returns>
        public JieQi getPrevJieQi()
        {
            return getPrevJieQi(false);
        }

        /// <summary>
        /// 获取上一节气（逆推的第一个节气）
        /// </summary>
        /// <param name="wholeDay">是否按天计</param>
        /// <returns>节气</returns>
        public JieQi getPrevJieQi(bool wholeDay)
        {
            return getNearJieQi(false, null, wholeDay);
        }

        /// <summary>
        /// 获取最近的节气，如果未找到匹配的，返回null
        /// </summary>
        /// <param name="forward">是否顺推，true为顺推，false为逆推</param>
        /// <param name="conditions">过滤条件，如果设置过滤条件，仅返回匹配该名称的</param>
        /// <param name="wholeDay">是否按天计</param>
        /// <returns>节气</returns>
        private JieQi getNearJieQi(bool forward, string[] conditions, bool wholeDay)
        {
            string name = null;
            Solar near = null;
            List<string> filters = new List<string>();
            if (null != conditions)
            {
                foreach (string cond in conditions)
                {
                    if (!filters.Contains(cond))
                    {
                        filters.Add(cond);
                    }
                }
            }
            bool filter = filters.Count > 0;
            string today = wholeDay ? solar.toYmd() : solar.toYmdHms();
            foreach (KeyValuePair<string, Solar> entry in jieQi)
            {
                string jq = entry.Key;
                if (filter)
                {
                    if (!filters.Contains(jq))
                    {
                        continue;
                    }
                }
                Solar current = entry.Value;
                string day = wholeDay ? current.toYmd() : current.toYmdHms();
                if (forward)
                {
                    if (day.CompareTo(today) < 0)
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
                        string nearDay = wholeDay ? near.toYmd() : near.toYmdHms();
                        if (day.CompareTo(nearDay) < 0)
                        {
                            name = jq;
                            near = current;
                        }
                    }
                }
                else
                {
                    if (day.CompareTo(today) > 0)
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
                        string nearDay = wholeDay ? near.toYmd() : near.toYmdHms();
                        if (day.CompareTo(nearDay) > 0)
                        {
                            name = jq;
                            near = current;
                        }
                    }
                }

            }
            if (null == near)
            {
                return null;
            }
            return new JieQi(convertJieQi(name), near);
        }

        protected string convertJieQi(string name)
        {
            string jq = name;
            if ("DONG_ZHI".Equals(jq))
            {
                jq = "冬至";
            }
            else if ("DA_HAN".Equals(jq))
            {
                jq = "大寒";
            }
            else if ("XIAO_HAN".Equals(jq))
            {
                jq = "小寒";
            }
            else if ("LI_CHUN".Equals(jq))
            {
                jq = "立春";
            }
            else if ("DA_XUE".Equals(jq))
            {
                jq = "大雪";
            }
            else if ("YU_SHUI".Equals(jq))
            {
                jq = "雨水";
            }
            else if ("JING_ZHE".Equals(jq))
            {
                jq = "惊蛰";
            }
            return jq;
        }

        /// <summary>
        /// 获取节气名称，如果无节气，返回空字符串
        /// </summary>
        /// <returns>节气名称</returns>
        public string getJieQi()
        {
            foreach (KeyValuePair<string, Solar> jq in jieQi)
            {
                Solar d = jq.Value;
                if (d.getYear() == solar.getYear() && d.getMonth() == solar.getMonth() && d.getDay() == solar.getDay())
                {
                    return convertJieQi(jq.Key);
                }

            }
            return "";
        }

        /// <summary>
        /// 获取当天节气对象，如果无节气，返回null
        /// </summary>
        /// <returns>节气对象</returns>
        public JieQi getCurrentJieQi()
        {
            foreach (KeyValuePair<string, Solar> jq in jieQi)
            {
                Solar d = jq.Value;
                if (d.getYear() == solar.getYear() && d.getMonth() == solar.getMonth() && d.getDay() == solar.getDay())
                {
                    return new JieQi(convertJieQi(jq.Key), d);
                }

            }
            return null;
        }

        /// <summary>
        /// 获取当天节令对象，如果无节令，返回null
        /// </summary>
        /// <returns>节气对象</returns>
        public JieQi getCurrentJie()
        {
            for (int i = 0, j = JIE_QI_IN_USE.Length; i < j; i += 2)
            {
                string key = JIE_QI_IN_USE[i];
                Solar d = jieQi[key];
                if (d.getYear() == solar.getYear() && d.getMonth() == solar.getMonth() && d.getDay() == solar.getDay())
                {
                    return new JieQi(convertJieQi(key), d);
                }
            }
            return null;
        }

        /// <summary>
        /// 获取当天气令对象，如果无气令，返回null
        /// </summary>
        /// <returns>节气对象</returns>
        public JieQi getCurrentQi()
        {
            for (int i = 1, j = JIE_QI_IN_USE.Length; i < j; i += 2)
            {
                string key = JIE_QI_IN_USE[i];
                Solar d = jieQi[key];
                if (d.getYear() == solar.getYear() && d.getMonth() == solar.getMonth() && d.getDay() == solar.getDay())
                {
                    return new JieQi(convertJieQi(key), d);
                }
            }
            return null;
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
            string jq = getJieQi();
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
            s.Append(getDayPositionXi());
            s.Append("](");
            s.Append(getDayPositionXiDesc());
            s.Append(") 阳贵神方位[");
            s.Append(getDayPositionYangGui());
            s.Append("](");
            s.Append(getDayPositionYangGuiDesc());
            s.Append(") 阴贵神方位[");
            s.Append(getDayPositionYinGui());
            s.Append("](");
            s.Append(getDayPositionYinGuiDesc());
            s.Append(") 福神方位[");
            s.Append(getDayPositionFu());
            s.Append("](");
            s.Append(getDayPositionFuDesc());
            s.Append(") 财神方位[");
            s.Append(getDayPositionCai());
            s.Append("](");
            s.Append(getDayPositionCaiDesc());
            s.Append(") 冲[");
            s.Append(getDayChongDesc());
            s.Append("] 煞[");
            s.Append(getDaySha());
            s.Append("]");
            return s.ToString();
        }

        public string toString()
        {
            return getYearInChinese() + "年" + getMonthInChinese() + "月" + getDayInChinese();
        }


        public override string ToString()
        {
            return toString();
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

        public int getTimeGanIndex()
        {
            return timeGanIndex;
        }

        public int getTimeZhiIndex()
        {
            return timeZhiIndex;
        }

        public int getDayGanIndex()
        {
            return dayGanIndex;
        }

        public int getDayZhiIndex()
        {
            return dayZhiIndex;
        }

        public int getMonthGanIndex()
        {
            return monthGanIndex;
        }

        public int getMonthZhiIndex()
        {
            return monthZhiIndex;
        }

        public int getYearGanIndex()
        {
            return yearGanIndex;
        }

        public int getYearZhiIndex()
        {
            return yearZhiIndex;
        }

        public int getYearGanIndexByLiChun()
        {
            return yearGanIndexByLiChun;
        }

        public int getYearZhiIndexByLiChun()
        {
            return yearZhiIndexByLiChun;
        }

        public int getDayGanIndexExact()
        {
            return dayGanIndexExact;
        }

        public int getDayGanIndexExact2()
        {
            return dayGanIndexExact2;
        }

        public int getDayZhiIndexExact()
        {
            return dayZhiIndexExact;
        }

        public int getDayZhiIndexExact2()
        {
            return dayZhiIndexExact2;
        }

        public int getMonthGanIndexExact()
        {
            return monthGanIndexExact;
        }

        public int getMonthZhiIndexExact()
        {
            return monthZhiIndexExact;
        }

        public int getYearGanIndexExact()
        {
            return yearGanIndexExact;
        }

        public int getYearZhiIndexExact()
        {
            return yearZhiIndexExact;
        }

        public Solar getSolar()
        {
            return solar;
        }

        /// <summary>
        /// 获取往后推几天的农历日期，如果要往前推，则天数用负数
        /// </summary>
        /// <param name="days">天数</param>
        /// <returns>农历日期</returns>
        public Lunar next(int days)
        {
            return solar.next(days).getLunar();
        }

        public EightChar getEightChar()
        {
            if (null == eightChar)
            {
                eightChar = new EightChar(this);
            }
            return eightChar;
        }

        /// <summary>
        /// 获取年所在旬（以正月初一作为新年的开始）
        /// </summary>
        /// <returns>旬</returns>
        public string getYearXun()
        {
            return LunarUtil.getXun(getYearInGanZhi());
        }

        /// <summary>
        /// 获取年所在旬（以立春当天作为新年的开始）
        /// </summary>
        /// <returns>旬</returns>
        public string getYearXunByLiChun()
        {
            return LunarUtil.getXun(getYearInGanZhiByLiChun());
        }

        /// <summary>
        /// 获取年所在旬（以立春交接时刻作为新年的开始）
        /// </summary>
        /// <returns>旬</returns>
        public string getYearXunExact()
        {
            return LunarUtil.getXun(getYearInGanZhiExact());
        }

        /// <summary>
        /// 获取值年空亡（以正月初一作为新年的开始）
        /// </summary>
        /// <returns>空亡(旬空)</returns>
        public string getYearXunKong()
        {
            return LunarUtil.getXunKong(getYearInGanZhi());
        }

        /// <summary>
        /// 获取值年空亡（以立春当天作为新年的开始）
        /// </summary>
        /// <returns>空亡(旬空)</returns>
        public string getYearXunKongByLiChun()
        {
            return LunarUtil.getXunKong(getYearInGanZhiByLiChun());
        }

        /// <summary>
        /// 获取值年空亡（以立春交接时刻作为新年的开始）
        /// </summary>
        /// <returns>空亡(旬空)</returns>
        public string getYearXunKongExact()
        {
            return LunarUtil.getXunKong(getYearInGanZhiExact());
        }

        /// <summary>
        /// 获取月所在旬（以节交接当天起算）
        /// </summary>
        /// <returns>旬</returns>
        public string getMonthXun()
        {
            return LunarUtil.getXun(getMonthInGanZhi());
        }

        /// <summary>
        /// 获取月所在旬（以节交接时刻起算）
        /// </summary>
        /// <returns>旬</returns>
        public string getMonthXunExact()
        {
            return LunarUtil.getXun(getMonthInGanZhiExact());
        }

        /// <summary>
        /// 获取值月空亡（以节交接当天起算）
        /// </summary>
        /// <returns>空亡(旬空)</returns>
        public string getMonthXunKong()
        {
            return LunarUtil.getXunKong(getMonthInGanZhi());
        }

        /// <summary>
        /// 获取值月空亡（以节交接时刻起算）
        /// </summary>
        /// <returns>空亡(旬空)</returns>
        public string getMonthXunKongExact()
        {
            return LunarUtil.getXunKong(getMonthInGanZhiExact());
        }

        /// <summary>
        /// 获取日所在旬（以节交接当天起算）
        /// </summary>
        /// <returns>旬</returns>
        public string getDayXun()
        {
            return LunarUtil.getXun(getDayInGanZhi());
        }

        /// <summary>
        /// 获取日所在旬（八字流派1，晚子时日柱算明天）
        /// </summary>
        /// <returns>旬</returns>
        public string getDayXunExact()
        {
            return LunarUtil.getXun(getDayInGanZhiExact());
        }

        /// <summary>
        /// 获取日所在旬（八字流派2，晚子时日柱算当天）
        /// </summary>
        /// <returns>旬</returns>
        public string getDayXunExact2()
        {
            return LunarUtil.getXun(getDayInGanZhiExact2());
        }

        /// <summary>
        /// 获取值日空亡
        /// </summary>
        /// <returns>空亡(旬空)</returns>
        public string getDayXunKong()
        {
            return LunarUtil.getXunKong(getDayInGanZhi());
        }

        /// <summary>
        /// 获取值日空亡（八字流派1，晚子时日柱算明天）
        /// </summary>
        /// <returns>空亡(旬空)</returns>
        public string getDayXunKongExact()
        {
            return LunarUtil.getXunKong(getDayInGanZhiExact());
        }

        /// <summary>
        /// 获取值日空亡（八字流派2，晚子时日柱算当天）
        /// </summary>
        /// <returns>空亡(旬空)</returns>
        public string getDayXunKongExact2()
        {
            return LunarUtil.getXunKong(getDayInGanZhiExact2());
        }

        /// <summary>
        /// 获取时辰所在旬
        /// </summary>
        /// <returns>旬</returns>
        public string getTimeXun()
        {
            return LunarUtil.getXun(getTimeInGanZhi());
        }

        /// <summary>
        /// 获取值时空亡
        /// </summary>
        /// <returns>空亡(旬空)</returns>
        public string getTimeXunKong()
        {
            return LunarUtil.getXunKong(getTimeInGanZhi());
        }

        /// <summary>
        /// 获取数九
        /// </summary>
        /// <returns>数九，如果不是数九天，返回null</returns>
        public ShuJiu getShuJiu()
        {
            DateTime currentCalendar = ExactDate.fromYmd(solar.getYear(), solar.getMonth(), solar.getDay());
            Solar start = jieQi["DONG_ZHI"];
            DateTime startCalendar = ExactDate.fromYmd(start.getYear(), start.getMonth(), start.getDay());
            if (currentCalendar.CompareTo(startCalendar) < 0)
            {
                start = jieQi["冬至"];
                startCalendar = ExactDate.fromYmd(start.getYear(), start.getMonth(), start.getDay());
            }
            DateTime endCalendar = startCalendar.AddDays(81);
            if (currentCalendar.CompareTo(startCalendar) < 0 || currentCalendar.CompareTo(endCalendar) >= 0)
            {
                return null;
            }
            int days = ExactDate.getDaysBetween(startCalendar, currentCalendar);
            return new ShuJiu(LunarUtil.NUMBER[days / 9 + 1] + "九", days % 9 + 1);
        }

        /// <summary>
        /// 获取三伏
        /// </summary>
        /// <returns>三伏，如果不是伏天，返回null</returns>
        public Fu getFu()
        {
            DateTime currentCalendar = ExactDate.fromYmd(solar.getYear(), solar.getMonth(), solar.getDay());
            Solar xiaZhi = jieQi["夏至"];
            Solar liQiu = jieQi["立秋"];
            DateTime startCalendar = ExactDate.fromYmd(xiaZhi.getYear(), xiaZhi.getMonth(), xiaZhi.getDay());
            int add = 6 - xiaZhi.getLunar().getDayGanIndex();
            if (add < 0)
            {
                add += 10;
            }
            add += 20;
            startCalendar = startCalendar.AddDays(add);
            if (currentCalendar.CompareTo(startCalendar) < 0)
            {
                return null;
            }
            int days = ExactDate.getDaysBetween(startCalendar, currentCalendar);
            if (days < 10)
            {
                return new Fu("初伏", days + 1);
            }
            startCalendar = startCalendar.AddDays(10);
            days = ExactDate.getDaysBetween(startCalendar, currentCalendar);
            if (days < 10)
            {
                return new Fu("中伏", days + 1);
            }
            startCalendar = startCalendar.AddDays(10);
            DateTime liQiuCalendar = ExactDate.fromYmd(liQiu.getYear(), liQiu.getMonth(), liQiu.getDay());
            days = ExactDate.getDaysBetween(startCalendar, currentCalendar);
            if (liQiuCalendar.CompareTo(startCalendar) <= 0)
            {
                if (days < 10)
                {
                    return new Fu("末伏", days + 1);
                }
            }
            else
            {
                if (days < 10)
                {
                    return new Fu("中伏", days + 11);
                }
                startCalendar = startCalendar.AddDays(10);
                days = ExactDate.getDaysBetween(startCalendar, currentCalendar);
                if (days < 10)
                {
                    return new Fu("末伏", days + 1);
                }
            } return null;
        }

        /// <summary>
        /// 获取六曜
        /// </summary>
        /// <returns>六曜</returns>
        public string getLiuYao()
        {
            return LunarUtil.LIU_YAO[(Math.Abs(month) + day - 2) % 6];
        }

        /// <summary>
        /// 获取物候
        /// </summary>
        /// <returns>物候</returns>
        public string getWuHou()
        {
            JieQi jieQi = getPrevJieQi(true);
            string name = jieQi.getName();
            int offset = 0;
            for (int i = 0, j = JIE_QI.Length; i < j; i++)
            {
                if (name.Equals(JIE_QI[i]))
                {
                    offset = i;
                    break;
                }
            }
            Solar startSolar = jieQi.getSolar();
            int days = ExactDate.getDaysBetween(startSolar.getYear(), startSolar.getMonth(), startSolar.getDay(), solar.getYear(), solar.getMonth(), solar.getDay());
            return LunarUtil.WU_HOU[(offset * 3 + days / 5) % LunarUtil.WU_HOU.Length];
        }

        public string getHou()
        {
            JieQi jieQi = getPrevJieQi(true);
            string name = jieQi.getName();
            Solar startSolar = jieQi.getSolar();
            int days = ExactDate.getDaysBetween(startSolar.getYear(), startSolar.getMonth(), startSolar.getDay(), solar.getYear(), solar.getMonth(), solar.getDay());
            return name + " " + LunarUtil.HOU[(days / 5) % LunarUtil.HOU.Length];
        }

        /// <summary>
        /// 获取日禄
        /// </summary>
        /// <returns>日禄</returns>
        public string getDayLu()
        {
            string gan = LunarUtil.LU[getDayGan()];
            string zhi = null;
            try
            {
                zhi = LunarUtil.LU[getDayZhi()];
            }
            catch { }
            string lu = gan + "命互禄";
            if (null != zhi)
            {
                lu += " " + zhi + "命进禄";
            }
            return lu;
        }

        /// <summary>
        /// 获取时辰
        /// </summary>
        /// <returns>时辰</returns>
        public LunarTime getTime()
        {
            return new LunarTime(year, month, day, hour, minute, second);
        }

        /// <summary>
        /// 获取当天的时辰列表
        /// </summary>
        /// <returns>时辰列表</returns>
        public List<LunarTime> getTimes()
        {
            List<LunarTime> l = new List<LunarTime>();
            l.Add(new LunarTime(year, month, day, 0, 0, 0));
            for (int i = 0; i < 12; i++)
            {
                l.Add(new LunarTime(year, month, day, (i + 1) * 2 - 1, 0, 0));
            }
            return l;
        }

        /// <summary>
        /// 获取佛历
        /// </summary>
        /// <returns>佛历</returns>
        public Foto getFoto()
        {
            return Foto.fromLunar(this);
        }

        /// <summary>
        /// 获取道历
        /// </summary>
        /// <returns>道历</returns>
        public Tao getTao()
        {
            return Tao.fromLunar(this);
        }
    }
}
