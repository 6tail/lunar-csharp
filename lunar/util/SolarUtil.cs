using System;
using System.Collections.Generic;
using System.Text;

namespace com.nlf.calendar.util
{
    /// <summary>
    /// 阳历工具，基准日期为1901年1月1日，对应农历1900年十一月十一
    /// </summary>
    public class SolarUtil
    {
        /// <summary>
        /// 阳历基准年
        /// </summary>
        public const int BASE_YEAR = 1901;

        /// <summary>
        /// 阳历基准月
        /// </summary>
        public const int BASE_MONTH = 1;

        /// <summary>
        /// 阳历基准日
        /// </summary>
        public const int BASE_DAY = 1;

        /// <summary>
        /// 星期
        /// </summary>
        public static readonly string[] WEEK = { "日", "一", "二", "三", "四", "五", "六" };

        /// <summary>
        /// 每月天数
        /// </summary>
        public static readonly int[] DAYS_OF_MONTH = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        /// <summary>
        /// 星座
        /// </summary>
        public static readonly string[] XINGZUO = { "白羊", "金牛", "双子", "巨蟹", "狮子", "处女", "天秤", "天蝎", "射手", "摩羯", "水瓶", "双鱼" };

        public static readonly Dictionary<string,string> FESTIVAL = new Dictionary<string,string>();
        public static readonly Dictionary<string, string> WEEK_FESTIVAL = new Dictionary<string, string>();
        public static readonly Dictionary<string, List<string>> OTHER_FESTIVAL = new Dictionary<string, List<string>>();

        static SolarUtil()
        {
            FESTIVAL.Add("1-1", "元旦节");
            FESTIVAL.Add("2-14", "情人节");
            FESTIVAL.Add("3-8", "妇女节");
            FESTIVAL.Add("3-12", "植树节");
            FESTIVAL.Add("3-15", "消费者权益日");
            FESTIVAL.Add("4-1", "愚人节");
            FESTIVAL.Add("5-1", "劳动节");
            FESTIVAL.Add("5-4", "青年节");
            FESTIVAL.Add("6-1", "儿童节");
            FESTIVAL.Add("7-1", "建党节");
            FESTIVAL.Add("8-1", "建军节");
            FESTIVAL.Add("9-10", "教师节");
            FESTIVAL.Add("10-1", "国庆节");
            FESTIVAL.Add("12-24", "平安夜");
            FESTIVAL.Add("12-25", "圣诞节");

            WEEK_FESTIVAL.Add("5-2-0", "母亲节");
            WEEK_FESTIVAL.Add("6-3-0", "父亲节");
            WEEK_FESTIVAL.Add("11-4-4", "感恩节");

            OTHER_FESTIVAL.Add("1-8", new List<string>(new string[]{"周恩来逝世纪念日"}));
        }

        /// <summary>
        /// 是否闰年
        /// </summary>
        /// <param name="year">年</param>
        /// <returns>true/false 闰年/非闰年</returns>
        public static bool isLeapYear(int year)
        {
            return DateTime.IsLeapYear(year);
        }

        /// <summary>
        /// 获取某年某月有多少天
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns>天数</returns>
        public static int getDaysOfMonth(int year, int month)
        {
            return DateTime.DaysInMonth(year, month);
        }

        /// <summary>
        /// 获取某年某月有多少周
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="start">星期几作为一周的开始，1234560分别代表星期一至星期天</param>
        /// <returns>周数</returns>
        public static int getWeeksOfMonth(int year, int month, int start)
        {
            int days = getDaysOfMonth(year, month);
            DateTime firstDay = new DateTime(year, month, 1);
            int week = Convert.ToInt32(firstDay.DayOfWeek.ToString("d"));
            return (int)Math.Ceiling((days + week - start) * 1D / WEEK.Length);
        }
    }
}
