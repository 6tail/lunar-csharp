using System;
using System.Collections.Generic;
using System.Text;
using com.nlf.calendar.util;

namespace com.nlf.calendar
{
    /// <summary>
    /// 农历月
    /// </summary>
    public class LunarMonth
    {
        /// <summary>
        /// 农历年
        /// </summary>
        private int year;

        /// <summary>
        /// 农历月：1-12，闰月为负数，如闰2月为-2
        /// </summary>
        private int month;

        /// <summary>
        /// 天数，大月30天，小月29天
        /// </summary>
        private int dayCount;

        /// <summary>
        /// 初一的儒略日
        /// </summary>
        private double firstJulianDay;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="lunarYear">农历年</param>
        /// <param name="lunarMonth">农历月：1-12，闰月为负数，如闰2月为-2</param>
        /// <param name="dayCount">天数</param>
        /// <param name="firstJulianDay">初一的儒略日</param>
        public LunarMonth(int lunarYear, int lunarMonth, int dayCount, double firstJulianDay)
        {
            this.year = lunarYear;
            this.month = lunarMonth;
            this.dayCount = dayCount;
            this.firstJulianDay = firstJulianDay;
        }

        /// <summary>
        /// 通过农历年月初始化
        /// </summary>
        /// <param name="lunarYear">农历年</param>
        /// <param name="lunarMonth">农历月：1-12，闰月为负数，如闰2月为-2</param>
        /// <returns>农历月</returns>
        public static LunarMonth fromYm(int lunarYear, int lunarMonth)
        {
            return LunarYear.fromYear(lunarYear).getMonth(lunarMonth);
        }

        /// <summary>
        /// 获取农历年
        /// </summary>
        /// <returns>农历年</returns>
        public int getYear()
        {
            return year;
        }

        /// <summary>
        /// 获取农历月
        /// </summary>
        /// <returns>农历月：1-12，闰月为负数，如闰2月为-2</returns>
        public int getMonth()
        {
            return month;
        }

        /// <summary>
        /// 是否闰月
        /// </summary>
        /// <returns>true/false</returns>
        public bool isLeap()
        {
            return month < 0;
        }

        /// <summary>
        /// 获取天数
        /// </summary>
        /// <returns>天数</returns>
        public int getDayCount()
        {
            return dayCount;
        }

        /// <summary>
        /// 获取初一的儒略日
        /// </summary>
        /// <returns>初一的儒略日</returns>
        public double getFirstJulianDay()
        {
            return firstJulianDay;
        }

        /// <summary>
        /// 获取太岁方位
        /// </summary>
        /// <returns>太岁方位，如艮</returns>
        public string getPositionTaiSui()
        {
            string p;
            int m = Math.Abs(month);
            switch (m)
            {
                case 1:
                case 5:
                case 9:
                    p = "艮";
                    break;
                case 3:
                case 7:
                case 11:
                    p = "坤";
                    break;
                case 4:
                case 8:
                case 12:
                    p = "巽";
                    break;
                default:
                    p = LunarUtil.POSITION_GAN[Solar.fromJulianDay(this.getFirstJulianDay()).getLunar().getMonthGanIndex()];
                    break;
            }
            return p;
        }

        /// <summary>
        /// 获取太岁方位描述
        /// </summary>
        /// <returns>方位描述，如东北</returns>
        public string getPositionTaiSuiDesc()
        {
            return LunarUtil.POSITION_DESC[getPositionTaiSui()];
        }

        /// <summary>
        /// 获取月九星
        /// </summary>
        /// <returns>九星</returns>
        public NineStar getNineStar()
        {
            int index = LunarYear.fromYear(year).getZhiIndex() % 3;
            int m = Math.Abs(month);
            int monthZhiIndex = (13 + m) % 12;
            int n = 27 - (index * 3);
            if (monthZhiIndex < LunarUtil.BASE_MONTH_ZHI_INDEX)
            {
                n -= 3;
            }
            int offset = (n - monthZhiIndex) % 9;
            return NineStar.fromIndex(offset);
        }

        public override string ToString()
        {
            return year + "年" + (isLeap() ? "闰" : "") + LunarUtil.MONTH[Math.Abs(month)] + "月(" + dayCount + "天)";
        }
    }
}