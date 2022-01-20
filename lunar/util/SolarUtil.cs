using System;
using System.Collections.Generic;
using System.Text;

namespace com.nlf.calendar.util
{
    /// <summary>
    /// 阳历工具
    /// </summary>
    public class SolarUtil
    {
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
            OTHER_FESTIVAL.Add("1-10", new List<string>(new string[] { "中国人民警察节", "中国公安110宣传日" }));
            OTHER_FESTIVAL.Add("1-21", new List<string>(new string[] { "列宁逝世纪念日" }));
            OTHER_FESTIVAL.Add("1-26", new List<string>(new string[] { "国际海关日" }));
            OTHER_FESTIVAL.Add("2-2", new List<string>(new string[] { "世界湿地日" }));
            OTHER_FESTIVAL.Add("2-4", new List<string>(new string[] { "世界抗癌日" }));
            OTHER_FESTIVAL.Add("2-7", new List<string>(new string[] { "京汉铁路罢工纪念" }));
            OTHER_FESTIVAL.Add("2-10", new List<string>(new string[] { "国际气象节" }));
            OTHER_FESTIVAL.Add("2-19", new List<string>(new string[] { "邓小平逝世纪念日" }));
            OTHER_FESTIVAL.Add("2-21", new List<string>(new string[] { "国际母语日" }));
            OTHER_FESTIVAL.Add("2-24", new List<string>(new string[] { "第三世界青年日" }));
            OTHER_FESTIVAL.Add("3-1", new List<string>(new string[] { "国际海豹日" }));
            OTHER_FESTIVAL.Add("3-3", new List<string>(new string[] { "全国爱耳日" }));
            OTHER_FESTIVAL.Add("3-5", new List<string>(new string[] { "周恩来诞辰纪念日", "中国青年志愿者服务日" }));
            OTHER_FESTIVAL.Add("3-6", new List<string>(new string[] { "世界青光眼日" }));
            OTHER_FESTIVAL.Add("3-12", new List<string>(new string[] { "孙中山逝世纪念日" }));
            OTHER_FESTIVAL.Add("3-14", new List<string>(new string[] { "马克思逝世纪念日" }));
            OTHER_FESTIVAL.Add("3-17", new List<string>(new string[] { "国际航海日" }));
            OTHER_FESTIVAL.Add("3-18", new List<string>(new string[] { "全国科技人才活动日" }));
            OTHER_FESTIVAL.Add("3-21", new List<string>(new string[] { "世界森林日", "世界睡眠日" }));
            OTHER_FESTIVAL.Add("3-22", new List<string>(new string[] { "世界水日" }));
            OTHER_FESTIVAL.Add("3-23", new List<string>(new string[] { "世界气象日" }));
            OTHER_FESTIVAL.Add("3-24", new List<string>(new string[] { "世界防治结核病日" }));
            OTHER_FESTIVAL.Add("4-2", new List<string>(new string[] { "国际儿童图书日" }));
            OTHER_FESTIVAL.Add("4-7", new List<string>(new string[] { "世界卫生日" }));
            OTHER_FESTIVAL.Add("4-22", new List<string>(new string[] { "列宁诞辰纪念日" }));
            OTHER_FESTIVAL.Add("4-23", new List<string>(new string[] { "世界图书和版权日" }));
            OTHER_FESTIVAL.Add("4-26", new List<string>(new string[] { "世界知识产权日" }));
            OTHER_FESTIVAL.Add("5-3", new List<string>(new string[] { "世界新闻自由日" }));
            OTHER_FESTIVAL.Add("5-5", new List<string>(new string[] { "马克思诞辰纪念日" }));
            OTHER_FESTIVAL.Add("5-8", new List<string>(new string[] { "世界红十字日" }));
            OTHER_FESTIVAL.Add("5-11", new List<string>(new string[] { "世界肥胖日" }));
            OTHER_FESTIVAL.Add("5-27", new List<string>(new string[] { "上海解放日" }));
            OTHER_FESTIVAL.Add("5-31", new List<string>(new string[] { "世界无烟日" }));
            OTHER_FESTIVAL.Add("6-5", new List<string>(new string[] { "世界环境日" }));
            OTHER_FESTIVAL.Add("6-6", new List<string>(new string[] { "全国爱眼日" }));
            OTHER_FESTIVAL.Add("6-8", new List<string>(new string[] { "世界海洋日" }));
            OTHER_FESTIVAL.Add("6-11", new List<string>(new string[] { "中国人口日" }));
            OTHER_FESTIVAL.Add("6-14", new List<string>(new string[] { "世界献血日" }));
            OTHER_FESTIVAL.Add("7-1", new List<string>(new string[] { "香港回归纪念日" }));
            OTHER_FESTIVAL.Add("7-7", new List<string>(new string[] { "中国人民抗日战争纪念日" }));
            OTHER_FESTIVAL.Add("7-11", new List<string>(new string[] { "世界人口日" }));
            OTHER_FESTIVAL.Add("8-5", new List<string>(new string[] { "恩格斯逝世纪念日" }));
            OTHER_FESTIVAL.Add("8-6", new List<string>(new string[] { "国际电影节" }));
            OTHER_FESTIVAL.Add("8-12", new List<string>(new string[] { "国际青年日" }));
            OTHER_FESTIVAL.Add("8-22", new List<string>(new string[] { "邓小平诞辰纪念日" }));
            OTHER_FESTIVAL.Add("9-3", new List<string>(new string[] { "中国抗日战争胜利纪念日" }));
            OTHER_FESTIVAL.Add("9-8", new List<string>(new string[] { "世界扫盲日" }));
            OTHER_FESTIVAL.Add("9-9", new List<string>(new string[] { "毛泽东逝世纪念日" }));
            OTHER_FESTIVAL.Add("9-14", new List<string>(new string[] { "世界清洁地球日" }));
            OTHER_FESTIVAL.Add("9-18", new List<string>(new string[] { "九一八事变纪念日" }));
            OTHER_FESTIVAL.Add("9-20", new List<string>(new string[] { "全国爱牙日" }));
            OTHER_FESTIVAL.Add("9-21", new List<string>(new string[] { "国际和平日" }));
            OTHER_FESTIVAL.Add("9-27", new List<string>(new string[] { "世界旅游日" }));
            OTHER_FESTIVAL.Add("10-4", new List<string>(new string[] { "世界动物日" }));
            OTHER_FESTIVAL.Add("10-10", new List<string>(new string[] { "辛亥革命纪念日" }));
            OTHER_FESTIVAL.Add("10-13", new List<string>(new string[] { "中国少年先锋队诞辰日" }));
            OTHER_FESTIVAL.Add("10-25", new List<string>(new string[] { "抗美援朝纪念日" }));
            OTHER_FESTIVAL.Add("11-12", new List<string>(new string[] { "孙中山诞辰纪念日" }));
            OTHER_FESTIVAL.Add("11-17", new List<string>(new string[] { "国际大学生节" }));
            OTHER_FESTIVAL.Add("11-28", new List<string>(new string[] { "恩格斯诞辰纪念日" }));
            OTHER_FESTIVAL.Add("12-1", new List<string>(new string[] { "世界艾滋病日" }));
            OTHER_FESTIVAL.Add("12-12", new List<string>(new string[] { "西安事变纪念日" }));
            OTHER_FESTIVAL.Add("12-13", new List<string>(new string[] { "国家公祭日" }));
            OTHER_FESTIVAL.Add("12-26", new List<string>(new string[] { "毛泽东诞辰纪念日" }));
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
        /// 获取某年有多少天（平年365天，闰年366天）
        /// </summary>
        /// <param name="year">年</param>
        /// <returns>天数</returns>
        public static int getDaysOfYear(int year)
        {
            return isLeapYear(year) ? 366 : 365;
        }

        /// <summary>
        /// 获取某年某月有多少天
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns>天数</returns>
        public static int getDaysOfMonth(int year, int month)
        {
            if (1582 == year && 10 == month)
            {
                return 21;
            }
            return DateTime.DaysInMonth(year, month);
        }

        /// <summary>
        /// 获取某天为当年的第几天
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <returns>第几天</returns>
        public static int getDaysInYear(int year, int month, int day)
        {
            int days = 0;
            for (int i = 1; i < month; i++)
            {
                days += getDaysOfMonth(year, i);
            }
            days += day;
            if (1582 == year && 10 == month && day >= 15)
            {
                days -= 10;
            }
            return days;
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
            DateTime firstDay = ExactDate.fromYmd(year, month, 1);
            int week = Convert.ToInt32(firstDay.DayOfWeek.ToString("d"));
            return (int)Math.Ceiling((days + week - start) * 1D / WEEK.Length);
        }
    }
}
