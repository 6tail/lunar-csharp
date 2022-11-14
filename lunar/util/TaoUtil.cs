using System.Collections.Generic;
// ReSharper disable InconsistentNaming

namespace Lunar.Util
{
    /// <summary>
    /// 道历工具
    /// </summary>
    public static class TaoUtil
    {

        /// <summary>
        /// 三会日
        /// </summary>
        public static readonly string[] SAN_HUI = { "1-7", "7-7", "10-15" };

        /// <summary>
        /// 三元日
        /// </summary>
        public static readonly string[] SAN_YUAN = { "1-15", "7-15", "10-15" };

        /// <summary>
        /// 五腊日
        /// </summary>
        public static readonly string[] WU_LA = { "1-1", "5-5", "7-7", "10-1", "12-8" };

        /// <summary>
        /// 暗戊
        /// </summary>
        public static readonly string[] AN_WU = { "未", "戌", "辰", "寅", "午", "子", "酉", "申", "巳", "亥", "卯", "丑" };

        /// <summary>
        /// 八会日
        /// </summary>
        public static readonly Dictionary<string, string> BA_HUI = new Dictionary<string, string>();

        /// <summary>
        /// 八节日
        /// </summary>
        public static readonly Dictionary<string, string> BA_JIE = new Dictionary<string, string>();

        /// <summary>
        /// 节日
        /// </summary>
        public static readonly Dictionary<string, List<TaoFestival>> FESTIVAL = new Dictionary<string, List<TaoFestival>>();

        static TaoUtil()
        {

            BA_HUI.Add("丙午", "天会");
            BA_HUI.Add("壬午", "地会");
            BA_HUI.Add("壬子", "人会");
            BA_HUI.Add("庚午", "日会");
            BA_HUI.Add("庚申", "月会");
            BA_HUI.Add("辛酉", "星辰会");
            BA_HUI.Add("甲辰", "五行会");
            BA_HUI.Add("甲戌", "四时会");

            BA_JIE.Add("立春", "东北方度仙上圣天尊同梵炁始青天君下降");
            BA_JIE.Add("春分", "东方玉宝星上天尊同青帝九炁天君下降");
            BA_JIE.Add("立夏", "东南方好生度命天尊同梵炁始丹天君下降");
            BA_JIE.Add("夏至", "南方玄真万福天尊同赤帝三炁天君下降");
            BA_JIE.Add("立秋", "西南方太灵虚皇天尊同梵炁始素天君下降");
            BA_JIE.Add("秋分", "西方太妙至极天尊同白帝七炁天君下降");
            BA_JIE.Add("立冬", "西北方无量太华天尊同梵炁始玄天君下降");
            BA_JIE.Add("冬至", "北方玄上玉宸天尊同黑帝五炁天君下降");

            FESTIVAL.Add("1-1", new List<TaoFestival>(new[] { new TaoFestival("天腊之辰", "天腊，此日五帝会于东方九炁青天") }));
            FESTIVAL.Add("1-3", new List<TaoFestival>(new[] { new TaoFestival("郝真人圣诞"), new TaoFestival("孙真人圣诞") }));
            FESTIVAL.Add("1-5", new List<TaoFestival>(new[] { new TaoFestival("孙祖清静元君诞") }));
            FESTIVAL.Add("1-7", new List<TaoFestival>(new[] { new TaoFestival("举迁赏会", "此日上元赐福，天官同地水二官考校罪福") }));
            FESTIVAL.Add("1-9", new List<TaoFestival>(new[] { new TaoFestival("玉皇上帝圣诞") }));
            FESTIVAL.Add("1-13", new List<TaoFestival>(new[] { new TaoFestival("关圣帝君飞升") }));
            FESTIVAL.Add("1-15", new List<TaoFestival>(new[] { new TaoFestival("上元天官圣诞"), new TaoFestival("老祖天师圣诞") }));
            FESTIVAL.Add("1-19", new List<TaoFestival>(new[] { new TaoFestival("长春邱真人(邱处机)圣诞") }));
            FESTIVAL.Add("1-28", new List<TaoFestival>(new[] { new TaoFestival("许真君(许逊天师)圣诞") }));
            FESTIVAL.Add("2-1", new List<TaoFestival>(new[] { new TaoFestival("勾陈天皇大帝圣诞"), new TaoFestival("长春刘真人(刘渊然)圣诞") }));
            FESTIVAL.Add("2-2", new List<TaoFestival>(new[] { new TaoFestival("土地正神诞"), new TaoFestival("姜太公圣诞") }));
            FESTIVAL.Add("2-3", new List<TaoFestival>(new[] { new TaoFestival("文昌梓潼帝君圣诞") }));
            FESTIVAL.Add("2-6", new List<TaoFestival>(new[] { new TaoFestival("东华帝君圣诞") }));
            FESTIVAL.Add("2-13", new List<TaoFestival>(new[] { new TaoFestival("度人无量葛真君圣诞") }));
            FESTIVAL.Add("2-15", new List<TaoFestival>(new[] { new TaoFestival("太清道德天尊(太上老君)圣诞") }));
            FESTIVAL.Add("2-19", new List<TaoFestival>(new[] { new TaoFestival("慈航真人圣诞") }));
            FESTIVAL.Add("3-1", new List<TaoFestival>(new[] { new TaoFestival("谭祖(谭处端)长真真人圣诞") }));
            FESTIVAL.Add("3-3", new List<TaoFestival>(new[] { new TaoFestival("玄天上帝圣诞") }));
            FESTIVAL.Add("3-6", new List<TaoFestival>(new[] { new TaoFestival("眼光娘娘圣诞") }));
            FESTIVAL.Add("3-15", new List<TaoFestival>(new[] { new TaoFestival("天师张大真人圣诞"), new TaoFestival("财神赵公元帅圣诞") }));
            FESTIVAL.Add("3-16", new List<TaoFestival>(new[] { new TaoFestival("三茅真君得道之辰"), new TaoFestival("中岳大帝圣诞") }));
            FESTIVAL.Add("3-18", new List<TaoFestival>(new[] { new TaoFestival("王祖(王处一)玉阳真人圣诞"), new TaoFestival("后土娘娘圣诞") }));
            FESTIVAL.Add("3-19", new List<TaoFestival>(new[] { new TaoFestival("太阳星君圣诞") }));
            FESTIVAL.Add("3-20", new List<TaoFestival>(new[] { new TaoFestival("子孙娘娘圣诞") }));
            FESTIVAL.Add("3-23", new List<TaoFestival>(new[] { new TaoFestival("天后妈祖圣诞") }));
            FESTIVAL.Add("3-26", new List<TaoFestival>(new[] { new TaoFestival("鬼谷先师诞") }));
            FESTIVAL.Add("3-28", new List<TaoFestival>(new[] { new TaoFestival("东岳大帝圣诞") }));
            FESTIVAL.Add("4-1", new List<TaoFestival>(new[] { new TaoFestival("长生谭真君成道之辰") }));
            FESTIVAL.Add("4-10", new List<TaoFestival>(new[] { new TaoFestival("何仙姑圣诞") }));
            FESTIVAL.Add("4-14", new List<TaoFestival>(new[] { new TaoFestival("吕祖纯阳祖师圣诞") }));
            FESTIVAL.Add("4-15", new List<TaoFestival>(new[] { new TaoFestival("钟离祖师圣诞") }));
            FESTIVAL.Add("4-18", new List<TaoFestival>(new[] { new TaoFestival("北极紫微大帝圣诞"), new TaoFestival("泰山圣母碧霞元君诞"), new TaoFestival("华佗神医先师诞") }));
            FESTIVAL.Add("4-20", new List<TaoFestival>(new[] { new TaoFestival("眼光圣母娘娘诞") }));
            FESTIVAL.Add("4-28", new List<TaoFestival>(new[] { new TaoFestival("神农先帝诞") }));
            FESTIVAL.Add("5-1", new List<TaoFestival>(new[] { new TaoFestival("南极长生大帝圣诞") }));
            FESTIVAL.Add("5-5", new List<TaoFestival>(new[] { new TaoFestival("地腊之辰", "地腊，此日五帝会于南方三炁丹天"), new TaoFestival("南方雷祖圣诞"), new TaoFestival("地祗温元帅圣诞"), new TaoFestival("雷霆邓天君圣诞") }));
            FESTIVAL.Add("5-11", new List<TaoFestival>(new[] { new TaoFestival("城隍爷圣诞") }));
            FESTIVAL.Add("5-13", new List<TaoFestival>(new[] { new TaoFestival("关圣帝君降神"), new TaoFestival("关平太子圣诞") }));
            FESTIVAL.Add("5-18", new List<TaoFestival>(new[] { new TaoFestival("张天师圣诞") }));
            FESTIVAL.Add("5-20", new List<TaoFestival>(new[] { new TaoFestival("马祖丹阳真人圣诞") }));
            FESTIVAL.Add("5-29", new List<TaoFestival>(new[] { new TaoFestival("紫青白祖师圣诞") }));
            FESTIVAL.Add("6-1", new List<TaoFestival>(new[] { new TaoFestival("南斗星君下降") }));
            FESTIVAL.Add("6-2", new List<TaoFestival>(new[] { new TaoFestival("南斗星君下降") }));
            FESTIVAL.Add("6-3", new List<TaoFestival>(new[] { new TaoFestival("南斗星君下降") }));
            FESTIVAL.Add("6-4", new List<TaoFestival>(new[] { new TaoFestival("南斗星君下降") }));
            FESTIVAL.Add("6-5", new List<TaoFestival>(new[] { new TaoFestival("南斗星君下降") }));
            FESTIVAL.Add("6-6", new List<TaoFestival>(new[] { new TaoFestival("南斗星君下降") }));
            FESTIVAL.Add("6-10", new List<TaoFestival>(new[] { new TaoFestival("刘海蟾祖师圣诞") }));
            FESTIVAL.Add("6-15", new List<TaoFestival>(new[] { new TaoFestival("灵官王天君圣诞") }));
            FESTIVAL.Add("6-19", new List<TaoFestival>(new[] { new TaoFestival("慈航(观音)成道日") }));
            FESTIVAL.Add("6-23", new List<TaoFestival>(new[] { new TaoFestival("火神圣诞") }));
            FESTIVAL.Add("6-24", new List<TaoFestival>(new[] { new TaoFestival("南极大帝中方雷祖圣诞"), new TaoFestival("关圣帝君圣诞") }));
            FESTIVAL.Add("6-26", new List<TaoFestival>(new[] { new TaoFestival("二郎真君圣诞") }));
            FESTIVAL.Add("7-7", new List<TaoFestival>(new[] { new TaoFestival("道德腊之辰", "道德腊，此日五帝会于西方七炁素天"), new TaoFestival("庆生中会", "此日中元赦罪，地官同天水二官考校罪福") }));
            FESTIVAL.Add("7-12", new List<TaoFestival>(new[] { new TaoFestival("西方雷祖圣诞") }));
            FESTIVAL.Add("7-15", new List<TaoFestival>(new[] { new TaoFestival("中元地官大帝圣诞") }));
            FESTIVAL.Add("7-18", new List<TaoFestival>(new[] { new TaoFestival("王母娘娘圣诞") }));
            FESTIVAL.Add("7-20", new List<TaoFestival>(new[] { new TaoFestival("刘祖(刘处玄)长生真人圣诞") }));
            FESTIVAL.Add("7-22", new List<TaoFestival>(new[] { new TaoFestival("财帛星君文财神增福相公李诡祖圣诞") }));
            FESTIVAL.Add("7-26", new List<TaoFestival>(new[] { new TaoFestival("张三丰祖师圣诞") }));
            FESTIVAL.Add("8-1", new List<TaoFestival>(new[] { new TaoFestival("许真君飞升日") }));
            FESTIVAL.Add("8-3", new List<TaoFestival>(new[] { new TaoFestival("九天司命灶君诞") }));
            FESTIVAL.Add("8-5", new List<TaoFestival>(new[] { new TaoFestival("北方雷祖圣诞") }));
            FESTIVAL.Add("8-10", new List<TaoFestival>(new[] { new TaoFestival("北岳大帝诞辰") }));
            FESTIVAL.Add("8-15", new List<TaoFestival>(new[] { new TaoFestival("太阴星君诞") }));
            FESTIVAL.Add("9-1", new List<TaoFestival>(new[] { new TaoFestival("北斗九皇降世之辰") }));
            FESTIVAL.Add("9-2", new List<TaoFestival>(new[] { new TaoFestival("北斗九皇降世之辰") }));
            FESTIVAL.Add("9-3", new List<TaoFestival>(new[] { new TaoFestival("北斗九皇降世之辰") }));
            FESTIVAL.Add("9-4", new List<TaoFestival>(new[] { new TaoFestival("北斗九皇降世之辰") }));
            FESTIVAL.Add("9-5", new List<TaoFestival>(new[] { new TaoFestival("北斗九皇降世之辰") }));
            FESTIVAL.Add("9-6", new List<TaoFestival>(new[] { new TaoFestival("北斗九皇降世之辰") }));
            FESTIVAL.Add("9-7", new List<TaoFestival>(new[] { new TaoFestival("北斗九皇降世之辰") }));
            FESTIVAL.Add("9-8", new List<TaoFestival>(new[] { new TaoFestival("北斗九皇降世之辰") }));
            FESTIVAL.Add("9-9", new List<TaoFestival>(new[] { new TaoFestival("北斗九皇降世之辰"), new TaoFestival("斗姥元君圣诞"), new TaoFestival("重阳帝君圣诞"), new TaoFestival("玄天上帝飞升"), new TaoFestival("酆都大帝圣诞") }));
            FESTIVAL.Add("9-22", new List<TaoFestival>(new[] { new TaoFestival("增福财神诞") }));
            FESTIVAL.Add("9-23", new List<TaoFestival>(new[] { new TaoFestival("萨翁真君圣诞") }));
            FESTIVAL.Add("9-28", new List<TaoFestival>(new[] { new TaoFestival("五显灵官马元帅圣诞") }));
            FESTIVAL.Add("10-1", new List<TaoFestival>(new[] { new TaoFestival("民岁腊之辰", "民岁腊，此日五帝会于北方五炁黑天"), new TaoFestival("东皇大帝圣诞") }));
            FESTIVAL.Add("10-3", new List<TaoFestival>(new[] { new TaoFestival("三茅应化真君圣诞") }));
            FESTIVAL.Add("10-6", new List<TaoFestival>(new[] { new TaoFestival("天曹诸司五岳五帝圣诞") }));
            FESTIVAL.Add("10-15", new List<TaoFestival>(new[] { new TaoFestival("下元水官大帝圣诞"), new TaoFestival("建生大会", "此日下元解厄，水官同天地二官考校罪福") }));
            FESTIVAL.Add("10-18", new List<TaoFestival>(new[] { new TaoFestival("地母娘娘圣诞") }));
            FESTIVAL.Add("10-19", new List<TaoFestival>(new[] { new TaoFestival("长春邱真君飞升") }));
            FESTIVAL.Add("10-20", new List<TaoFestival>(new[] { new TaoFestival("虚靖天师(即三十代天师弘悟张真人)诞") }));
            FESTIVAL.Add("11-6", new List<TaoFestival>(new[] { new TaoFestival("西岳大帝圣诞") }));
            FESTIVAL.Add("11-9", new List<TaoFestival>(new[] { new TaoFestival("湘子韩祖圣诞") }));
            FESTIVAL.Add("11-11", new List<TaoFestival>(new[] { new TaoFestival("太乙救苦天尊圣诞") }));
            FESTIVAL.Add("11-26", new List<TaoFestival>(new[] { new TaoFestival("北方五道圣诞") }));
            FESTIVAL.Add("12-8", new List<TaoFestival>(new[] { new TaoFestival("王侯腊之辰", "王侯腊，此日五帝会于上方玄都玉京") }));
            FESTIVAL.Add("12-16", new List<TaoFestival>(new[] { new TaoFestival("南岳大帝圣诞"), new TaoFestival("福德正神诞") }));
            FESTIVAL.Add("12-20", new List<TaoFestival>(new[] { new TaoFestival("鲁班先师圣诞") }));
            FESTIVAL.Add("12-21", new List<TaoFestival>(new[] { new TaoFestival("天猷上帝圣诞") }));
            FESTIVAL.Add("12-22", new List<TaoFestival>(new[] { new TaoFestival("重阳祖师圣诞") }));
            FESTIVAL.Add("12-23", new List<TaoFestival>(new[] { new TaoFestival("祭灶王", "最适宜谢旧年太岁，开启拜新年太岁") }));
            FESTIVAL.Add("12-25", new List<TaoFestival>(new[] { new TaoFestival("玉帝巡天"), new TaoFestival("天神下降") }));
            FESTIVAL.Add("12-29", new List<TaoFestival>(new[] { new TaoFestival("清静孙真君(孙不二)成道") }));
        }
    }
}
