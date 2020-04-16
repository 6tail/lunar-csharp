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
        /// 月对应的天干下标，0-9
        /// </summary>
        private int monthGanIndex;

        /// <summary>
        /// 月对应的地支下标，0-11
        /// </summary>
        private int monthZhiIndex;
 
        /// <summary>
        /// 年对应的天干下标，0-9
        /// </summary>
        private int yearGanIndex;
        
        /// <summary>
        /// 年对应的地支下标，0-11
        /// </summary>
        private int yearZhiIndex;

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
        public Lunar(int lunarYear, int lunarMonth, int lunarDay) : this(lunarYear, lunarMonth, lunarDay, 0, 0) { }

        /// <summary>
        /// 通过农历年月日时初始化
        /// </summary>
        /// <param name="lunarYear">年（农历）</param>
        /// <param name="lunarMonth">月（农历），1到12，闰月为负，即闰2月=-2</param>
        /// <param name="lunarDay">日（农历），1到31</param>
        /// <param name="hour">小时（阳历）</param>
        /// <param name="minute">分钟（阳历）</param>
        public Lunar(int lunarYear, int lunarMonth, int lunarDay, int hour, int minute)
        {
            this.year = lunarYear;
            this.month = lunarMonth;
            this.day = lunarDay;
            this.hour = hour;
            this.minute = minute;
            compute();
            this.solar = toSolar();
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
            compute();
        }

        private Solar toSolar()
        {
            DateTime c = new DateTime(SolarUtil.BASE_YEAR, SolarUtil.BASE_MONTH - 1, SolarUtil.BASE_DAY, hour, minute, 0);
            c.AddDays(dayOffset);
            return new Solar(c);
        }

        private void compute()
        {
            yearGanIndex = (year - 4) % 10;
            yearZhiIndex = (year - 4) % 12;

            int m = Math.Abs(month);
            int leapMonth = LunarUtil.getLeapMonth(year);
            if (0 == leapMonth || m < leapMonth || month == leapMonth)
            {
                m -= 1;
            }
            monthGanIndex = (m + (yearGanIndex % 5 + 1) * 2) % 10;
            monthZhiIndex = (m + LunarUtil.BASE_MONTH_ZHI_INDEX) % 12;

            dayOffset = LunarUtil.computeAddDays(year, month, day);
            int addDays = (dayOffset + LunarUtil.BASE_DAY_GANZHI_INDEX) % 60;
            dayGanIndex = addDays % 10;
            dayZhiIndex = addDays % 12;

            timeZhiIndex = LunarUtil.getTimeZhiIndex((hour < 10 ? "0" : "") + hour + ":" + (minute < 10 ? "0" : "") + minute);
            timeGanIndex = timeZhiIndex % 10;

            weekIndex = (dayOffset + LunarUtil.BASE_WEEK_INDEX) % 7;
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
        /// <returns>农历</returns>
        public static Lunar fromYmdHm(int lunarYear, int lunarMonth, int lunarDay, int hour, int minute)
        {
            return new Lunar(lunarYear, lunarMonth, lunarDay, hour, minute);
        }

        [Obsolete("This method is obsolete, use method getYearGan instead")]
        public string getGan()
        {
            return getYearGan();
        }

        /// <summary>
        /// 获取年份的天干
        /// </summary>
        /// <returns>天干，如辛</returns>
        public string getYearGan()
        {
            return LunarUtil.GAN[yearGanIndex + 1];
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
        /// 获取年份的地支
        /// </summary>
        /// <returns>地支，如亥</returns>
        public string getYearZhi()
        {
            return LunarUtil.ZHI[yearZhiIndex + 1];
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
        /// 获取日地支
        /// </summary>
        /// <returns>日地支，如卯</returns>
        public string getDayZhi()
        {
            return LunarUtil.ZHI[dayZhiIndex + 1];
        }

        /// <summary>
        /// 获取干支纪年（年柱）
        /// </summary>
        /// <returns>年份的干支（年柱），如辛亥</returns>
        public string getYearInGanZhi()
        {
            return getYearGan() + getYearZhi();
        }

        /// <summary>
        /// 获取干支纪月（月柱）,月天干口诀：甲己丙寅首，乙庚戊寅头。丙辛从庚寅，丁壬壬寅求，戊癸甲寅居，周而复始流。月地支：正月起寅。
        /// </summary>
        /// <returns>干支纪月（月柱），如己卯</returns>
        public string getMonthInGanZhi()
        {
            return getMonthGan() + getMonthZhi();
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
        /// 获取年生肖
        /// </summary>
        /// <returns>年生肖，如虎</returns>
        public string getYearShengXiao()
        {
            return LunarUtil.SHENGXIAO[yearZhiIndex + 1];
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
            string s = "";
            int solarYear = solar.getYear();
            int solarMonth = solar.getMonth();
            int solarDay = solar.getDay();
            int index = 0;
            int ry = solarYear - SolarUtil.BASE_YEAR + 1;
            while (ry >= LunarUtil.JIE_YEAR[solarMonth - 1][index])
            {
                index++;
            }
            int term = LunarUtil.JIE_MAP[solarMonth - 1][4 * index + ry % 4];
            if (ry == 121 && solarMonth == 4)
            {
                term = 5;
            }
            if (ry == 132 && solarMonth == 4)
            {
                term = 5;
            }
            if (ry == 194 && solarMonth == 6)
            {
                term = 6;
            }
            if (solarDay == term)
            {
                s = LunarUtil.JIE[solarMonth - 1];
            }
            return s;
        }

        /// <summary>
        /// 获取气
        /// </summary>
        /// <returns>气</returns>
        public string getQi()
        {
            string s = "";
            int solarYear = solar.getYear();
            int solarMonth = solar.getMonth();
            int solarDay = solar.getDay();
            int index = 0;
            int ry = solarYear - SolarUtil.BASE_YEAR + 1;
            while (ry >= LunarUtil.QI_YEAR[solarMonth - 1][index])
            {
                index++;
            }
            int term = LunarUtil.QI_MAP[solarMonth - 1][4 * index + ry % 4];
            if (ry == 171 && solarMonth == 3)
            {
                term = 21;
            }
            if (ry == 181 && solarMonth == 5)
            {
                term = 21;
            }
            if (solarDay == term)
            {
                s = LunarUtil.QI[solarMonth - 1];
            }
            return s;
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
        /// 获取八字，男性也称乾造，女性也称坤造
        /// </summary>
        /// <returns>八字（男性也称乾造，女性也称坤造）</returns>
        public List<string> getBaZi()
        {
            List<string> l = new List<string>(4);
            string timeGan = LunarUtil.GAN[(dayGanIndex % 5 * 12 + timeZhiIndex) % 10 + 1];
            l.Add(getYearInGanZhi());
            l.Add(getMonthInGanZhi());
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

        public Solar getSolar()
        {
            return solar;
        }
    }
}
