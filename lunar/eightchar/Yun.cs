using com.nlf.calendar.util;
using System;

namespace com.nlf.calendar.eightchar
{
    /// <summary>
    /// 运
    /// </summary>
    public class Yun
    {
        /// <summary>
        /// 性别(1男，0女)
        /// </summary>
        private int gender;

        /// <summary>
        /// 起运年数
        /// </summary>
        private int startYear;

        /// <summary>
        /// 起运月数
        /// </summary>
        private int startMonth;

        /// <summary>
        /// 起运天数
        /// </summary>
        private int startDay;

        /// <summary>
        /// 起运小时
        /// </summary>
        private int startHour;

        /// <summary>
        /// 是否顺推
        /// </summary>
        private bool forward;

        private Lunar lunar;

        public Yun(EightChar eightChar, int gender)
            : this(eightChar, gender, 1)
        {
        }

        public Yun(EightChar eightChar, int gender, int sect)
        {
            this.lunar = eightChar.getLunar();
            this.gender = gender;
            bool yang = 0 == lunar.getYearGanIndexExact() % 2;
            bool man = 1 == gender;
            forward = (yang && man) || (!yang && !man);
            computeStart(sect);
        }

        /// <summary>
        /// 起运计算
        /// </summary>
        private void computeStart(int sect)
        {
            JieQi prev = lunar.getPrevJie();
            JieQi next = lunar.getNextJie();
            Solar current = lunar.getSolar();
            Solar start = forward ? current : prev.getSolar();
            Solar end = forward ? next.getSolar() : current;

            int year;
            int month;
            int day;
            int hour = 0;

            if (2 == sect)
            {
                long minutes = (long)(new TimeSpan(end.getCalendar().Ticks - start.getCalendar().Ticks).TotalMinutes);
                long y = minutes / 4320;
                minutes -= y * 4320;
                long m = minutes / 360;
                minutes -= m * 360;
                long d = minutes / 12;
                minutes -= d * 12;
                long h = minutes * 2;
                year = (int)y;
                month = (int)m;
                day = (int)d;
                hour = (int)h;
            }
            else
            {
                int endTimeZhiIndex = (end.getHour() == 23) ? 11 : LunarUtil.getTimeZhiIndex(end.toYmdHms().Substring(11, 5));
                int startTimeZhiIndex = (start.getHour() == 23) ? 11 : LunarUtil.getTimeZhiIndex(start.toYmdHms().Substring(11, 5));
                // 时辰差
                int hourDiff = endTimeZhiIndex - startTimeZhiIndex;
                int dayDiff = ExactDate.getDaysBetween(start.getYear(), start.getMonth(), start.getDay(), end.getYear(), end.getMonth(), end.getDay());
                if (hourDiff < 0)
                {
                    hourDiff += 12;
                    dayDiff--;
                }
                int monthDiff = hourDiff * 10 / 30;
                month = dayDiff * 4 + monthDiff;
                day = hourDiff * 10 - monthDiff * 30;
                year = month / 12;
                month = month - year * 12;
            }          
            this.startYear = year;
            this.startMonth = month;
            this.startDay = day;
            this.startHour = hour;
        }

        /// <summary>
        /// 获取性别
        /// </summary>
        /// <returns>性别(1男 ， 0女)</returns>
        public int getGender()
        {
            return gender;
        }

        /// <summary>
        /// 获取起运年数
        /// </summary>
        /// <returns>起运年数</returns>
        public int getStartYear()
        {
            return startYear;
        }

        /// <summary>
        /// 获取起运月数
        /// </summary>
        /// <returns>起运月数</returns>
        public int getStartMonth()
        {
            return startMonth;
        }

        /// <summary>
        /// 获取起运天数
        /// </summary>
        /// <returns>起运天数</returns>
        public int getStartDay()
        {
            return startDay;
        }

        /// <summary>
        /// 获取起运小时数
        /// </summary>
        /// <returns>起运小时数</returns>
        public int getStartHour()
        {
            return startHour;
        }

        /// <summary>
        /// 是否顺推
        /// </summary>
        /// <returns>true/false</returns>
        public bool isForward()
        {
            return forward;
        }

        public Lunar getLunar()
        {
            return lunar;
        }

        /// <summary>
        /// 获取起运的阳历日期
        /// </summary>
        /// <returns>阳历日期</returns>
        public Solar getStartSolar()
        {
            Solar birth = lunar.getSolar();
            DateTime c = ExactDate.fromYmdHms(birth.getYear(), birth.getMonth(), birth.getDay(), birth.getHour(), birth.getMinute(), birth.getSecond());
            c = c.AddYears(startYear);
            c = c.AddMonths(startMonth);
            c = c.AddDays(startDay);
            c = c.AddHours(startHour);
            return Solar.fromDate(c);
        }

        /// <summary>
        /// 获取大运
        /// </summary>
        /// <param name="n">轮数</param>
        /// <returns>大运</returns>
        public DaYun[] getDaYun(int n)
        {
            DaYun[] l = new DaYun[n];
            for (int i = 0; i < n; i++)
            {
                l[i] = new DaYun(this, i);
            }
            return l;
        }

        /// <summary>
        /// 获取10轮大运
        /// </summary>
        /// <returns>大运</returns>
        public DaYun[] getDaYun()
        {
            return getDaYun(10);
        }

    }

}
