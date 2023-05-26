using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Lunar.Util
{
    /// <summary>
    /// 阳历工具
    /// </summary>
    public static class SolarUtil
    {
        /// <summary>
        /// 星期
        /// </summary>
        public static IReadOnlyList<string> WEEK { get; } =
            Array.AsReadOnly(new[] { "日", "一", "二", "三", "四", "五", "六" });

        /// <summary>
        /// 每月天数
        /// </summary>
        public static IReadOnlyList<int> DAYS_OF_MONTH { get; } =
            Array.AsReadOnly(new[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 });

        /// <summary>
        /// 星座
        /// </summary>
        public static IReadOnlyList<string> XING_ZUO { get; } =
            Array.AsReadOnly(new[] { 
                "白羊", "金牛", "双子", "巨蟹", "狮子", "处女", "天秤",
                "天蝎", "射手", "摩羯", "水瓶", "双鱼" });

        /// <summary>
        /// 节日
        /// </summary>
        public static IReadOnlyDictionary<string, string> FESTIVAL { get; }

        /// <summary>
        /// 按星期的节日
        /// </summary>
        public static IReadOnlyDictionary<string, string> WEEK_FESTIVAL { get; }

        /// <summary>
        /// 非正式节日
        /// </summary>
        public static IReadOnlyDictionary<string, IReadOnlyList<string>> OTHER_FESTIVAL { get; }

        static SolarUtil()
        {
            var festival = new Dictionary<string, string> {
                { "1-1", "元旦节" },
                { "2-14", "情人节" },
                { "3-8", "妇女节" },
                { "3-12", "植树节" },
                { "3-15", "消费者权益日" },
                { "4-1", "愚人节" },
                { "5-1", "劳动节" },
                { "5-4", "青年节" },
                { "6-1", "儿童节" },
                { "7-1", "建党节" },
                { "8-1", "建军节" },
                { "9-10", "教师节" },
                { "10-1", "国庆节" },
                { "10-31", "万圣节前夜" },
                { "11-1", "万圣节" },
                { "12-24", "平安夜" },
                { "12-25", "圣诞节" }
            };
            FESTIVAL = new ReadOnlyDictionary<string, string>(festival);

            var weekFestival = new Dictionary<string, string> {
                { "3-0-1", "全国中小学生安全教育日" },
                { "5-2-0", "母亲节" },
                { "5-3-0", "全国助残日" },
                { "6-3-0", "父亲节" },
                { "9-3-6", "全民国防教育日" },
                { "10-1-1", "世界住房日" },
                { "11-4-4", "感恩节" }
            };
            WEEK_FESTIVAL = new ReadOnlyDictionary<string, string>(weekFestival);

            var otherFestival = new Dictionary<string, IReadOnlyList<string>> {
                { "1-8", Array.AsReadOnly(new[] { "周恩来逝世纪念日" }) },
                { "1-10", Array.AsReadOnly(new[] { "中国人民警察节" }) },
                { "1-14", Array.AsReadOnly(new[] { "日记情人节" }) },
                { "1-21", Array.AsReadOnly(new[] { "列宁逝世纪念日" }) },
                { "1-26", Array.AsReadOnly(new[] { "国际海关日" }) },
                { "1-27", Array.AsReadOnly(new[] { "国际大屠杀纪念日" }) },
                { "2-2", Array.AsReadOnly(new[] { "世界湿地日" }) },
                { "2-4", Array.AsReadOnly(new[] { "世界抗癌日" }) },
                { "2-7", Array.AsReadOnly(new[] { "京汉铁路罢工纪念日" }) },
                { "2-10", Array.AsReadOnly(new[] { "国际气象节" }) },
                { "2-19", Array.AsReadOnly(new[] { "邓小平逝世纪念日" }) },
                { "2-20", Array.AsReadOnly(new[] { "世界社会公正日" }) },
                { "2-21", Array.AsReadOnly(new[] { "国际母语日" }) },
                { "2-24", Array.AsReadOnly(new[] { "第三世界青年日" }) },
                { "3-1", Array.AsReadOnly(new[] { "国际海豹日" }) },
                { "3-3", Array.AsReadOnly(new[] { "世界野生动植物日", "全国爱耳日" }) },
                { "3-5", Array.AsReadOnly(new[] { "周恩来诞辰纪念日", "中国青年志愿者服务日" }) },
                { "3-6", Array.AsReadOnly(new[] { "世界青光眼日" }) },
                { "3-7", Array.AsReadOnly(new[] { "女生节" }) },
                { "3-12", Array.AsReadOnly(new[] { "孙中山逝世纪念日" }) },
                { "3-14", Array.AsReadOnly(new[] { "马克思逝世纪念日", "白色情人节" }) },
                { "3-17", Array.AsReadOnly(new[] { "国际航海日" }) },
                { "3-18", Array.AsReadOnly(new[] { "全国科技人才活动日", "全国爱肝日" }) },
                { "3-20", Array.AsReadOnly(new[] { "国际幸福日" }) },
                { "3-21", Array.AsReadOnly(new[] { "世界森林日", "世界睡眠日", "国际消除种族歧视日" }) },
                { "3-22", Array.AsReadOnly(new[] { "世界水日" }) },
                { "3-23", Array.AsReadOnly(new[] { "世界气象日" }) },
                { "3-24", Array.AsReadOnly(new[] { "世界防治结核病日" }) },
                { "3-29", Array.AsReadOnly(new[] { "中国黄花岗七十二烈士殉难纪念日" }) },
                { "4-2", Array.AsReadOnly(new[] { "国际儿童图书日", "世界自闭症日" }) },
                { "4-4", Array.AsReadOnly(new[] { "国际地雷行动日" }) },
                { "4-7", Array.AsReadOnly(new[] { "世界卫生日" }) },
                { "4-8", Array.AsReadOnly(new[] { "国际珍稀动物保护日" }) },
                { "4-12", Array.AsReadOnly(new[] { "世界航天日" }) },
                { "4-14", Array.AsReadOnly(new[] { "黑色情人节" }) },
                { "4-15", Array.AsReadOnly(new[] { "全民国家安全教育日" }) },
                { "4-22", Array.AsReadOnly(new[] { "世界地球日", "列宁诞辰纪念日" }) },
                { "4-23", Array.AsReadOnly(new[] { "世界读书日" }) },
                { "4-24", Array.AsReadOnly(new[] { "中国航天日" }) },
                { "4-25", Array.AsReadOnly(new[] { "儿童预防接种宣传日" }) },
                { "4-26", Array.AsReadOnly(new[] { "世界知识产权日", "全国疟疾日" }) },
                { "4-28", Array.AsReadOnly(new[] { "世界安全生产与健康日" }) },
                { "4-30", Array.AsReadOnly(new[] { "全国交通安全反思日" }) },
                { "5-2", Array.AsReadOnly(new[] { "世界金枪鱼日" }) },
                { "5-3", Array.AsReadOnly(new[] { "世界新闻自由日" }) },
                { "5-5", Array.AsReadOnly(new[] { "马克思诞辰纪念日" }) },
                { "5-8", Array.AsReadOnly(new[] { "世界红十字日" }) },
                { "5-11", Array.AsReadOnly(new[] { "世界肥胖日" }) },
                { "5-12", Array.AsReadOnly(new[] { "全国防灾减灾日", "护士节" }) },
                { "5-14", Array.AsReadOnly(new[] { "玫瑰情人节" }) },
                { "5-15", Array.AsReadOnly(new[] { "国际家庭日" }) },
                { "5-19", Array.AsReadOnly(new[] { "中国旅游日" }) },
                { "5-20", Array.AsReadOnly(new[] { "网络情人节" }) },
                { "5-22", Array.AsReadOnly(new[] { "国际生物多样性日" }) },
                { "5-25", Array.AsReadOnly(new[] { "525心理健康节" }) },
                { "5-27", Array.AsReadOnly(new[] { "上海解放日" }) },
                { "5-29", Array.AsReadOnly(new[] { "国际维和人员日" }) },
                { "5-30", Array.AsReadOnly(new[] { "中国五卅运动纪念日" }) },
                { "5-31", Array.AsReadOnly(new[] { "世界无烟日" }) },
                { "6-3", Array.AsReadOnly(new[] { "世界自行车日" }) },
                { "6-5", Array.AsReadOnly(new[] { "世界环境日" }) },
                { "6-6", Array.AsReadOnly(new[] { "全国爱眼日" }) },
                { "6-8", Array.AsReadOnly(new[] { "世界海洋日" }) },
                { "6-11", Array.AsReadOnly(new[] { "中国人口日" }) },
                { "6-14", Array.AsReadOnly(new[] { "世界献血日", "亲亲情人节" }) },
                { "6-17", Array.AsReadOnly(new[] { "世界防治荒漠化与干旱日" }) },
                { "6-20", Array.AsReadOnly(new[] { "世界难民日" }) },
                { "6-21", Array.AsReadOnly(new[] { "国际瑜伽日" }) },
                { "6-25", Array.AsReadOnly(new[] { "全国土地日" }) },
                { "6-26", Array.AsReadOnly(new[] { "国际禁毒日", "联合国宪章日" }) },
                { "7-1", Array.AsReadOnly(new[] { "香港回归纪念日" }) },
                { "7-6", Array.AsReadOnly(new[] { "国际接吻日", "朱德逝世纪念日" }) },
                { "7-7", Array.AsReadOnly(new[] { "七七事变纪念日" }) },
                { "7-11", Array.AsReadOnly(new[] { "世界人口日", "中国航海日" }) },
                { "7-14", Array.AsReadOnly(new[] { "银色情人节" }) },
                { "7-18", Array.AsReadOnly(new[] { "曼德拉国际日" }) },
                { "7-30", Array.AsReadOnly(new[] { "国际友谊日" }) },
                { "8-3", Array.AsReadOnly(new[] { "男人节" }) },
                { "8-5", Array.AsReadOnly(new[] { "恩格斯逝世纪念日" }) },
                { "8-6", Array.AsReadOnly(new[] { "国际电影节" }) },
                { "8-8", Array.AsReadOnly(new[] { "全民健身日" }) },
                { "8-9", Array.AsReadOnly(new[] { "国际土著人日" }) },
                { "8-12", Array.AsReadOnly(new[] { "国际青年节" }) },
                { "8-14", Array.AsReadOnly(new[] { "绿色情人节" }) },
                { "8-19", Array.AsReadOnly(new[] { "世界人道主义日", "中国医师节" }) },
                { "8-22", Array.AsReadOnly(new[] { "邓小平诞辰纪念日" }) },
                { "8-29", Array.AsReadOnly(new[] { "全国测绘法宣传日" }) },
                { "9-3", Array.AsReadOnly(new[] { "中国抗日战争胜利纪念日" }) },
                { "9-5", Array.AsReadOnly(new[] { "中华慈善日" }) },
                { "9-8", Array.AsReadOnly(new[] { "世界扫盲日" }) },
                { "9-9", Array.AsReadOnly(new[] { "毛泽东逝世纪念日", "全国拒绝酒驾日" }) },
                { "9-14", Array.AsReadOnly(new[] { "世界清洁地球日", "相片情人节" }) },
                { "9-15", Array.AsReadOnly(new[] { "国际民主日" }) },
                { "9-16", Array.AsReadOnly(new[] { "国际臭氧层保护日" }) },
                { "9-17", Array.AsReadOnly(new[] { "世界骑行日" }) },
                { "9-18", Array.AsReadOnly(new[] { "九一八事变纪念日" }) },
                { "9-20", Array.AsReadOnly(new[] { "全国爱牙日" }) },
                { "9-21", Array.AsReadOnly(new[] { "国际和平日" }) },
                { "9-27", Array.AsReadOnly(new[] { "世界旅游日" }) },
                { "9-30", Array.AsReadOnly(new[] { "中国烈士纪念日" }) },
                { "10-1", Array.AsReadOnly(new[] { "国际老年人日" }) },
                { "10-2", Array.AsReadOnly(new[] { "国际非暴力日" }) },
                { "10-4", Array.AsReadOnly(new[] { "世界动物日" }) },
                { "10-11", Array.AsReadOnly(new[] { "国际女童日" }) },
                { "10-10", Array.AsReadOnly(new[] { "辛亥革命纪念日" }) },
                { "10-13", Array.AsReadOnly(new[] { "国际减轻自然灾害日", "中国少年先锋队诞辰日" }) },
                { "10-14", Array.AsReadOnly(new[] { "葡萄酒情人节" }) },
                { "10-16", Array.AsReadOnly(new[] { "世界粮食日" }) },
                { "10-17", Array.AsReadOnly(new[] { "全国扶贫日" }) },
                { "10-20", Array.AsReadOnly(new[] { "世界统计日" }) },
                { "10-24", Array.AsReadOnly(new[] { "世界发展信息日", "程序员节" }) },
                { "10-25", Array.AsReadOnly(new[] { "抗美援朝纪念日" }) },
                { "11-5", Array.AsReadOnly(new[] { "世界海啸日" }) },
                { "11-8", Array.AsReadOnly(new[] { "记者节" }) },
                { "11-9", Array.AsReadOnly(new[] { "全国消防日" }) },
                { "11-11", Array.AsReadOnly(new[] { "光棍节" }) },
                { "11-12", Array.AsReadOnly(new[] { "孙中山诞辰纪念日" }) },
                { "11-14", Array.AsReadOnly(new[] { "电影情人节" }) },
                { "11-16", Array.AsReadOnly(new[] { "国际宽容日" }) },
                { "11-17", Array.AsReadOnly(new[] { "国际大学生节" }) },
                { "11-19", Array.AsReadOnly(new[] { "世界厕所日" }) },
                { "11-28", Array.AsReadOnly(new[] { "恩格斯诞辰纪念日" }) },
                { "11-29", Array.AsReadOnly(new[] { "国际声援巴勒斯坦人民日" }) },
                { "12-1", Array.AsReadOnly(new[] { "世界艾滋病日" }) },
                { "12-2", Array.AsReadOnly(new[] { "全国交通安全日" }) },
                { "12-3", Array.AsReadOnly(new[] { "世界残疾人日" }) },
                { "12-4", Array.AsReadOnly(new[] { "全国法制宣传日" }) },
                { "12-5", Array.AsReadOnly(new[] { "世界弱能人士日", "国际志愿人员日" }) },
                { "12-7", Array.AsReadOnly(new[] { "国际民航日" }) },
                { "12-9", Array.AsReadOnly(new[] { "世界足球日", "国际反腐败日" }) },
                { "12-10", Array.AsReadOnly(new[] { "世界人权日" }) },
                { "12-11", Array.AsReadOnly(new[] { "国际山岳日" }) },
                { "12-12", Array.AsReadOnly(new[] { "西安事变纪念日" }) },
                { "12-13", Array.AsReadOnly(new[] { "国家公祭日" }) },
                { "12-14", Array.AsReadOnly(new[] { "拥抱情人节" }) },
                { "12-18", Array.AsReadOnly(new[] { "国际移徙者日" }) },
                { "12-26", Array.AsReadOnly(new[] { "毛泽东诞辰纪念日" }) }
            };
            OTHER_FESTIVAL = new ReadOnlyDictionary<string, IReadOnlyList<string>>(otherFestival);
        }

        /// <summary>
        /// 是否闰年
        /// </summary>
        /// <param name="year">年</param>
        /// <returns>true/false 闰年/非闰年</returns>
        public static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }

        /// <summary>
        /// 获取某年有多少天（平年365天，闰年366天）
        /// </summary>
        /// <param name="year">年</param>
        /// <returns>天数</returns>
        public static int GetDaysOfYear(int year)
        {
            if (1582 == year) {
                return 355;
            }
            return IsLeapYear(year) ? 366 : 365;
        }

        /// <summary>
        /// 获取某年某月有多少天
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns>天数</returns>
        public static int GetDaysOfMonth(int year, int month)
        {
            if (1582 == year && 10 == month)
            {
                return 21;
            }
            int m = month - 1;
            int d = DAYS_OF_MONTH[m];
            //公历闰年2月多一天
            if (m == 1 && IsLeapYear(year)) {
                d++;
            }
            return d;
        }

        /// <summary>
        /// 获取某天为当年的第几天
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <returns>第几天</returns>
        public static int GetDaysInYear(int year, int month, int day)
        {
            var days = 0;
            for (var i = 1; i < month; i++)
            {
                days += GetDaysOfMonth(year, i);
            }
            var d = day;
            if (1582 == year && 10 == month) {
                if (day >= 15) {
                    d -= 10;
                } else if (day > 4)
                {
                    throw new ArgumentException($"wrong solar year {year} month {month} day {day}");
                }
            }
            days += d;
            return days;
        }

        /// <summary>
        /// 获取某年某月有多少周
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="start">星期几作为一周的开始，1234560分别代表星期一至星期天</param>
        /// <returns>周数</returns>
        public static int GetWeeksOfMonth(int year, int month, int start)
        {
            return (int) Math.Ceiling((GetDaysOfMonth(year, month) + Solar.FromYmdHms(year, month, 1).Week - start) * 1D / WEEK.Count);
        }
        
        /// <summary>
        /// 获取两个日期之间相差的天数（如果日期a比日期b小，天数为正，如果日期a比日期b大，天数为负）
        /// </summary>
        /// <param name="ay">年a</param>
        /// <param name="am">月a</param>
        /// <param name="ad">日a</param>
        /// <param name="by">年b</param>
        /// <param name="bm">月b</param>
        /// <param name="bd">日b</param>
        /// <returns>天数</returns>
        public static int GetDaysBetween(int ay, int am, int ad, int by, int bm, int bd)
        {
            int n;
            int days;
            int i;
            if (ay == by)
            {
                n = GetDaysInYear(by, bm, bd) - GetDaysInYear(ay, am, ad);
            }
            else if (ay > by)
            {
                days = GetDaysOfYear(by) - GetDaysInYear(by, bm, bd);
                for (i = by + 1; i < ay; i++)
                {
                    days += GetDaysOfYear(i);
                }
                days += GetDaysInYear(ay, am, ad);
                n = -days;
            }
            else
            {
                days = GetDaysOfYear(ay) - GetDaysInYear(ay, am, ad);
                for (i = ay + 1; i < by; i++)
                {
                    days += GetDaysOfYear(i);
                }
                days += GetDaysInYear(by, bm, bd);
                n = days;
            }
            return n;
        }
    }
}
