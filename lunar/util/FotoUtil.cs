using System;
using System.Collections.Generic;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable MemberCanBePrivate.Global

namespace Lunar.Util
{
    /// <summary>
    /// 佛历工具
    /// </summary>
    public static class FotoUtil
    {

        /// <summary>
        /// 观音斋日期
        /// </summary>
        public static readonly string[] DAY_ZHAI_GUAN_YIN = { "1-8", "2-7", "2-9", "2-19", "3-3", "3-6", "3-13", "4-22", "5-3", "5-17", "6-16", "6-18", "6-19", "6-23", "7-13", "8-16", "9-19", "9-23", "10-2", "11-19", "11-24", "12-25" };

        private const string DJ = "犯者夺纪";
        private const string JS = "犯者减寿";
        private const string SS = "犯者损寿";
        private const string XL = "犯者削禄夺纪";
        private const string JW = "犯者三年内夫妇俱亡";

        private static readonly FotoFestival Y = new("杨公忌");
        private static readonly FotoFestival T = new("四天王巡行", "", true);
        private static readonly FotoFestival D = new("斗降", DJ, true);
        private static readonly FotoFestival S = new("月朔", DJ, true);
        private static readonly FotoFestival W = new("月望", DJ, true);
        private static readonly FotoFestival H = new("月晦", JS, true);
        private static readonly FotoFestival L = new("雷斋日", JS, true);
        private static readonly FotoFestival J = new("九毒日", "犯者夭亡，奇祸不测");
        private static readonly FotoFestival R = new("人神在阴", "犯者得病", true, "宜先一日即戒");
        private static readonly FotoFestival M = new("司命奏事", JS, true, "如月小，即戒廿九");
        private static readonly FotoFestival HH = new("月晦", JS, true, "如月小，即戒廿九");

        public static readonly Dictionary<string, List<FotoFestival>> FESTIVAL = new();

        static FotoUtil()
        {
            FESTIVAL.Add("1-1", new List<FotoFestival>(new[] { new("天腊，玉帝校世人神气禄命", XL), S }));
            FESTIVAL.Add("1-3", new List<FotoFestival>(new[] { new("万神都会", DJ), D }));
            FESTIVAL.Add("1-5", new List<FotoFestival>(new FotoFestival[] { new("五虚忌") }));
            FESTIVAL.Add("1-6", new List<FotoFestival>(new[] { new("六耗忌"), L }));
            FESTIVAL.Add("1-7", new List<FotoFestival>(new FotoFestival[] { new("上会日", SS) }));
            FESTIVAL.Add("1-8", new List<FotoFestival>(new[] { new("五殿阎罗天子诞", DJ), T }));
            FESTIVAL.Add("1-9", new List<FotoFestival>(new FotoFestival[] { new("玉皇上帝诞", DJ) }));
            FESTIVAL.Add("1-13", new List<FotoFestival>(new[] { Y }));
            FESTIVAL.Add("1-14", new List<FotoFestival>(new[] { new("三元降", JS), T }));
            FESTIVAL.Add("1-15", new List<FotoFestival>(new[] { new("三元降", JS), new("上元神会", DJ), W, T }));
            FESTIVAL.Add("1-16", new List<FotoFestival>(new FotoFestival[] { new("三元降", JS) }));
            FESTIVAL.Add("1-19", new List<FotoFestival>(new FotoFestival[] { new("长春真人诞") }));
            FESTIVAL.Add("1-23", new List<FotoFestival>(new[] { new("三尸神奏事"), T }));
            FESTIVAL.Add("1-25", new List<FotoFestival>(new[] { H, new("天地仓开日", "犯者损寿，子带疾") }));
            FESTIVAL.Add("1-27", new List<FotoFestival>(new[] { D }));
            FESTIVAL.Add("1-28", new List<FotoFestival>(new[] { R }));
            FESTIVAL.Add("1-29", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("1-30", new List<FotoFestival>(new[] { HH, M, T }));
            FESTIVAL.Add("2-1", new List<FotoFestival>(new[] { new("一殿秦广王诞", DJ), S }));
            FESTIVAL.Add("2-2", new List<FotoFestival>(new FotoFestival[] { new("万神都会", DJ), new("福德土地正神诞", "犯者得祸") }));
            FESTIVAL.Add("2-3", new List<FotoFestival>(new[] { new("文昌帝君诞", XL), D }));
            FESTIVAL.Add("2-6", new List<FotoFestival>(new[] { new("东华帝君诞"), L }));
            FESTIVAL.Add("2-8", new List<FotoFestival>(new[] { new("释迦牟尼佛出家", DJ), new("三殿宋帝王诞", DJ), new("张大帝诞", DJ), T }));
            FESTIVAL.Add("2-11", new List<FotoFestival>(new[] { Y }));
            FESTIVAL.Add("2-14", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("2-15", new List<FotoFestival>(new[] { new("释迦牟尼佛涅槃", XL), new("太上老君诞", XL), new("月望", XL, true), T }));
            FESTIVAL.Add("2-17", new List<FotoFestival>(new FotoFestival[] { new("东方杜将军诞") }));
            FESTIVAL.Add("2-18", new List<FotoFestival>(new FotoFestival[] { new("四殿五官王诞", XL), new("至圣先师孔子讳辰", XL) }));
            FESTIVAL.Add("2-19", new List<FotoFestival>(new FotoFestival[] { new("观音大士诞", DJ) }));
            FESTIVAL.Add("2-21", new List<FotoFestival>(new FotoFestival[] { new("普贤菩萨诞") }));
            FESTIVAL.Add("2-23", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("2-25", new List<FotoFestival>(new[] { H }));
            FESTIVAL.Add("2-27", new List<FotoFestival>(new[] { D }));
            FESTIVAL.Add("2-28", new List<FotoFestival>(new[] { R }));
            FESTIVAL.Add("2-29", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("2-30", new List<FotoFestival>(new[] { HH, M, T }));
            FESTIVAL.Add("3-1", new List<FotoFestival>(new[] { new("二殿楚江王诞", DJ), S }));
            FESTIVAL.Add("3-3", new List<FotoFestival>(new[] { new("玄天上帝诞", DJ), D }));
            FESTIVAL.Add("3-6", new List<FotoFestival>(new[] { L }));
            FESTIVAL.Add("3-8", new List<FotoFestival>(new[] { new("六殿卞城王诞", DJ), T }));
            FESTIVAL.Add("3-9", new List<FotoFestival>(new[] { new("牛鬼神出", "犯者产恶胎"), Y }));
            FESTIVAL.Add("3-12", new List<FotoFestival>(new FotoFestival[] { new("中央五道诞") }));
            FESTIVAL.Add("3-14", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("3-15", new List<FotoFestival>(new[] { new("昊天上帝诞", DJ), new("玄坛诞", DJ), W, T }));
            FESTIVAL.Add("3-16", new List<FotoFestival>(new FotoFestival[] { new("准提菩萨诞", DJ) }));
            FESTIVAL.Add("3-19", new List<FotoFestival>(new FotoFestival[] { new("中岳大帝诞"), new("后土娘娘诞"), new("三茅降") }));
            FESTIVAL.Add("3-20", new List<FotoFestival>(new FotoFestival[] { new("天地仓开日", SS), new("子孙娘娘诞") }));
            FESTIVAL.Add("3-23", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("3-25", new List<FotoFestival>(new[] { H }));
            FESTIVAL.Add("3-27", new List<FotoFestival>(new[] { new("七殿泰山王诞"), D }));
            FESTIVAL.Add("3-28", new List<FotoFestival>(new[] { R, new("苍颉至圣先师诞", XL), new("东岳大帝诞") }));
            FESTIVAL.Add("3-29", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("3-30", new List<FotoFestival>(new[] { HH, M, T }));
            FESTIVAL.Add("4-1", new List<FotoFestival>(new[] { new("八殿都市王诞", DJ), S }));
            FESTIVAL.Add("4-3", new List<FotoFestival>(new[] { D }));
            FESTIVAL.Add("4-4", new List<FotoFestival>(new FotoFestival[] { new("万神善会", "犯者失瘼夭胎"), new("文殊菩萨诞") }));
            FESTIVAL.Add("4-6", new List<FotoFestival>(new[] { L }));
            FESTIVAL.Add("4-7", new List<FotoFestival>(new[] { new("南斗、北斗、西斗同降", JS), Y }));
            FESTIVAL.Add("4-8", new List<FotoFestival>(new[] { new("释迦牟尼佛诞", DJ), new("万神善会", "犯者失瘼夭胎"), new("善恶童子降", "犯者血死"), new("九殿平等王诞"), T }));
            FESTIVAL.Add("4-14", new List<FotoFestival>(new[] { new("纯阳祖师诞", JS), T }));
            FESTIVAL.Add("4-15", new List<FotoFestival>(new[] { W, new("钟离祖师诞"), T }));
            FESTIVAL.Add("4-16", new List<FotoFestival>(new FotoFestival[] { new("天地仓开日", SS) }));
            FESTIVAL.Add("4-17", new List<FotoFestival>(new FotoFestival[] { new("十殿转轮王诞", DJ) }));
            FESTIVAL.Add("4-18", new List<FotoFestival>(new FotoFestival[] { new("天地仓开日", SS), new("紫徽大帝诞", SS) }));
            FESTIVAL.Add("4-20", new List<FotoFestival>(new FotoFestival[] { new("眼光圣母诞") }));
            FESTIVAL.Add("4-23", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("4-25", new List<FotoFestival>(new[] { H }));
            FESTIVAL.Add("4-27", new List<FotoFestival>(new[] { D }));
            FESTIVAL.Add("4-28", new List<FotoFestival>(new[] { R }));
            FESTIVAL.Add("4-29", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("4-30", new List<FotoFestival>(new[] { HH, M, T }));
            FESTIVAL.Add("5-1", new List<FotoFestival>(new[] { new("南极长生大帝诞", DJ), S }));
            FESTIVAL.Add("5-3", new List<FotoFestival>(new[] { D }));
            FESTIVAL.Add("5-5", new List<FotoFestival>(new[] { new("地腊", XL), new("五帝校定生人官爵", XL), J, Y }));
            FESTIVAL.Add("5-6", new List<FotoFestival>(new[] { J, L }));
            FESTIVAL.Add("5-7", new List<FotoFestival>(new[] { J }));
            FESTIVAL.Add("5-8", new List<FotoFestival>(new[] { new("南方五道诞"), T }));
            FESTIVAL.Add("5-11", new List<FotoFestival>(new FotoFestival[] { new("天地仓开日", SS), new("天下都城隍诞") }));
            FESTIVAL.Add("5-12", new List<FotoFestival>(new FotoFestival[] { new("炳灵公诞") }));
            FESTIVAL.Add("5-13", new List<FotoFestival>(new FotoFestival[] { new("关圣降", XL) }));
            FESTIVAL.Add("5-14", new List<FotoFestival>(new[] { new("夜子时为天地交泰", JW), T }));
            FESTIVAL.Add("5-15", new List<FotoFestival>(new[] { W, J, T }));
            FESTIVAL.Add("5-16", new List<FotoFestival>(new FotoFestival[] { new("九毒日", JW), new("天地元气造化万物之辰", JW) }));
            FESTIVAL.Add("5-17", new List<FotoFestival>(new[] { J }));
            FESTIVAL.Add("5-18", new List<FotoFestival>(new FotoFestival[] { new("张天师诞") }));
            FESTIVAL.Add("5-22", new List<FotoFestival>(new FotoFestival[] { new("孝娥神诞", DJ) }));
            FESTIVAL.Add("5-23", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("5-25", new List<FotoFestival>(new[] { J, H }));
            FESTIVAL.Add("5-26", new List<FotoFestival>(new[] { J }));
            FESTIVAL.Add("5-27", new List<FotoFestival>(new[] { J, D }));
            FESTIVAL.Add("5-28", new List<FotoFestival>(new[] { R }));
            FESTIVAL.Add("5-29", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("5-30", new List<FotoFestival>(new[] { HH, M, T }));
            FESTIVAL.Add("6-1", new List<FotoFestival>(new[] { S }));
            FESTIVAL.Add("6-3", new List<FotoFestival>(new[] { new("韦驮菩萨圣诞"), D, Y }));
            FESTIVAL.Add("6-5", new List<FotoFestival>(new FotoFestival[] { new("南赡部洲转大轮", SS) }));
            FESTIVAL.Add("6-6", new List<FotoFestival>(new[] { new("天地仓开日", SS), L }));
            FESTIVAL.Add("6-8", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("6-10", new List<FotoFestival>(new FotoFestival[] { new("金粟如来诞") }));
            FESTIVAL.Add("6-14", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("6-15", new List<FotoFestival>(new[] { W, T }));
            FESTIVAL.Add("6-19", new List<FotoFestival>(new FotoFestival[] { new("观世音菩萨成道", DJ) }));
            FESTIVAL.Add("6-23", new List<FotoFestival>(new[] { new("南方火神诞", "犯者遭回禄"), T }));
            FESTIVAL.Add("6-24", new List<FotoFestival>(new FotoFestival[] { new("雷祖诞", XL), new("关帝诞", XL) }));
            FESTIVAL.Add("6-25", new List<FotoFestival>(new[] { H }));
            FESTIVAL.Add("6-27", new List<FotoFestival>(new[] { D }));
            FESTIVAL.Add("6-28", new List<FotoFestival>(new[] { R }));
            FESTIVAL.Add("6-29", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("6-30", new List<FotoFestival>(new[] { HH, M, T }));
            FESTIVAL.Add("7-1", new List<FotoFestival>(new[] { S, Y }));
            FESTIVAL.Add("7-3", new List<FotoFestival>(new[] { D }));
            FESTIVAL.Add("7-5", new List<FotoFestival>(new FotoFestival[] { new("中会日", SS, false, "一作初七") }));
            FESTIVAL.Add("7-6", new List<FotoFestival>(new[] { L }));
            FESTIVAL.Add("7-7", new List<FotoFestival>(new FotoFestival[] { new("道德腊", XL), new("五帝校生人善恶", XL), new("魁星诞", XL) }));
            FESTIVAL.Add("7-8", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("7-10", new List<FotoFestival>(new FotoFestival[] { new("阴毒日", "", false, "大忌") }));
            FESTIVAL.Add("7-12", new List<FotoFestival>(new FotoFestival[] { new("长真谭真人诞") }));
            FESTIVAL.Add("7-13", new List<FotoFestival>(new FotoFestival[] { new("大势至菩萨诞", JS) }));
            FESTIVAL.Add("7-14", new List<FotoFestival>(new[] { new("三元降", JS), T }));
            FESTIVAL.Add("7-15", new List<FotoFestival>(new[] { W, new("三元降", DJ), new("地官校籍", DJ), T }));
            FESTIVAL.Add("7-16", new List<FotoFestival>(new FotoFestival[] { new("三元降", JS) }));
            FESTIVAL.Add("7-18", new List<FotoFestival>(new FotoFestival[] { new("西王母诞", DJ) }));
            FESTIVAL.Add("7-19", new List<FotoFestival>(new FotoFestival[] { new("太岁诞", DJ) }));
            FESTIVAL.Add("7-22", new List<FotoFestival>(new FotoFestival[] { new("增福财神诞", XL) }));
            FESTIVAL.Add("7-23", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("7-25", new List<FotoFestival>(new[] { H }));
            FESTIVAL.Add("7-27", new List<FotoFestival>(new[] { D }));
            FESTIVAL.Add("7-28", new List<FotoFestival>(new[] { R }));
            FESTIVAL.Add("7-29", new List<FotoFestival>(new[] { Y, T }));
            FESTIVAL.Add("7-30", new List<FotoFestival>(new[] { new("地藏菩萨诞", DJ), HH, M, T }));
            FESTIVAL.Add("8-1", new List<FotoFestival>(new[] { S, new("许真君诞") }));
            FESTIVAL.Add("8-3", new List<FotoFestival>(new[] { D, new("北斗诞", XL), new("司命灶君诞", "犯者遭回禄") }));
            FESTIVAL.Add("8-5", new List<FotoFestival>(new FotoFestival[] { new("雷声大帝诞", DJ) }));
            FESTIVAL.Add("8-6", new List<FotoFestival>(new[] { L }));
            FESTIVAL.Add("8-8", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("8-10", new List<FotoFestival>(new FotoFestival[] { new("北斗大帝诞") }));
            FESTIVAL.Add("8-12", new List<FotoFestival>(new FotoFestival[] { new("西方五道诞") }));
            FESTIVAL.Add("8-14", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("8-15", new List<FotoFestival>(new[] { W, new("太明朝元", "犯者暴亡", false, "宜焚香守夜"), T }));
            FESTIVAL.Add("8-16", new List<FotoFestival>(new FotoFestival[] { new("天曹掠刷真君降", "犯者贫夭") }));
            FESTIVAL.Add("8-18", new List<FotoFestival>(new FotoFestival[] { new("天人兴福之辰", "", false, "宜斋戒，存想吉事") }));
            FESTIVAL.Add("8-23", new List<FotoFestival>(new[] { new("汉恒候张显王诞"), T }));
            FESTIVAL.Add("8-24", new List<FotoFestival>(new FotoFestival[] { new("灶君夫人诞") }));
            FESTIVAL.Add("8-25", new List<FotoFestival>(new[] { H }));
            FESTIVAL.Add("8-27", new List<FotoFestival>(new[] { D, new("至圣先师孔子诞", XL), Y }));
            FESTIVAL.Add("8-28", new List<FotoFestival>(new[] { R, new("四天会事") }));
            FESTIVAL.Add("8-29", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("8-30", new List<FotoFestival>(new[] { new("诸神考校", "犯者夺算"), HH, M, T }));
            FESTIVAL.Add("9-1", new List<FotoFestival>(new[] { S, new("南斗诞", XL), new("北斗九星降世", DJ, false, "此九日俱宜斋戒") }));
            FESTIVAL.Add("9-3", new List<FotoFestival>(new[] { D, new("五瘟神诞") }));
            FESTIVAL.Add("9-6", new List<FotoFestival>(new[] { L }));
            FESTIVAL.Add("9-8", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("9-9", new List<FotoFestival>(new FotoFestival[] { new("斗母诞", XL), new("酆都大帝诞"), new("玄天上帝飞升") }));
            FESTIVAL.Add("9-10", new List<FotoFestival>(new FotoFestival[] { new("斗母降", DJ) }));
            FESTIVAL.Add("9-11", new List<FotoFestival>(new FotoFestival[] { new("宜戒") }));
            FESTIVAL.Add("9-13", new List<FotoFestival>(new FotoFestival[] { new("孟婆尊神诞") }));
            FESTIVAL.Add("9-14", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("9-15", new List<FotoFestival>(new[] { W, T }));
            FESTIVAL.Add("9-17", new List<FotoFestival>(new FotoFestival[] { new("金龙四大王诞", "犯者遭水厄") }));
            FESTIVAL.Add("9-19", new List<FotoFestival>(new FotoFestival[] { new("日宫月宫会合", JS), new("观世音菩萨诞", JS) }));
            FESTIVAL.Add("9-23", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("9-25", new List<FotoFestival>(new[] { H, Y }));
            FESTIVAL.Add("9-27", new List<FotoFestival>(new[] { D }));
            FESTIVAL.Add("9-28", new List<FotoFestival>(new[] { R }));
            FESTIVAL.Add("9-29", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("9-30", new List<FotoFestival>(new[] { new("药师琉璃光佛诞", "犯者危疾"), HH, M, T }));
            FESTIVAL.Add("10-1", new List<FotoFestival>(new[] { S, new("民岁腊", DJ), new("四天王降", "犯者一年内死") }));
            FESTIVAL.Add("10-3", new List<FotoFestival>(new[] { D, new("三茅诞") }));
            FESTIVAL.Add("10-5", new List<FotoFestival>(new FotoFestival[] { new("下会日", JS), new("达摩祖师诞", JS) }));
            FESTIVAL.Add("10-6", new List<FotoFestival>(new[] { L, new("天曹考察", DJ) }));
            FESTIVAL.Add("10-8", new List<FotoFestival>(new[] { new("佛涅槃日", "", false, "大忌色欲"), T }));
            FESTIVAL.Add("10-10", new List<FotoFestival>(new FotoFestival[] { new("四天王降", "犯者一年内死") }));
            FESTIVAL.Add("10-11", new List<FotoFestival>(new FotoFestival[] { new("宜戒") }));
            FESTIVAL.Add("10-14", new List<FotoFestival>(new[] { new("三元降", JS), T }));
            FESTIVAL.Add("10-15", new List<FotoFestival>(new[] { W, new("三元降", DJ), new("下元水府校籍", DJ), T }));
            FESTIVAL.Add("10-16", new List<FotoFestival>(new[] { new("三元降", JS), T }));
            FESTIVAL.Add("10-23", new List<FotoFestival>(new[] { Y, T }));
            FESTIVAL.Add("10-25", new List<FotoFestival>(new[] { H }));
            FESTIVAL.Add("10-27", new List<FotoFestival>(new[] { D, new("北极紫徽大帝降") }));
            FESTIVAL.Add("10-28", new List<FotoFestival>(new[] { R }));
            FESTIVAL.Add("10-29", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("10-30", new List<FotoFestival>(new[] { HH, M, T }));
            FESTIVAL.Add("11-1", new List<FotoFestival>(new[] { S }));
            FESTIVAL.Add("11-3", new List<FotoFestival>(new[] { D }));
            FESTIVAL.Add("11-4", new List<FotoFestival>(new FotoFestival[] { new("至圣先师孔子诞", XL) }));
            FESTIVAL.Add("11-6", new List<FotoFestival>(new FotoFestival[] { new("西岳大帝诞") }));
            FESTIVAL.Add("11-8", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("11-11", new List<FotoFestival>(new FotoFestival[] { new("天地仓开日", DJ), new("太乙救苦天尊诞", DJ) }));
            FESTIVAL.Add("11-14", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("11-15", new List<FotoFestival>(new FotoFestival[] { new("月望", "上半夜犯男死 下半夜犯女死"), new("四天王巡行", "上半夜犯男死 下半夜犯女死") }));
            FESTIVAL.Add("11-17", new List<FotoFestival>(new FotoFestival[] { new("阿弥陀佛诞") }));
            FESTIVAL.Add("11-19", new List<FotoFestival>(new FotoFestival[] { new("太阳日宫诞", "犯者得奇祸") }));
            FESTIVAL.Add("11-21", new List<FotoFestival>(new[] { Y }));
            FESTIVAL.Add("11-23", new List<FotoFestival>(new[] { new("张仙诞", "犯者绝嗣"), T }));
            FESTIVAL.Add("11-25", new List<FotoFestival>(new[] { new("掠刷大夫降", "犯者遭大凶"), H }));
            FESTIVAL.Add("11-26", new List<FotoFestival>(new FotoFestival[] { new("北方五道诞") }));
            FESTIVAL.Add("11-27", new List<FotoFestival>(new[] { D }));
            FESTIVAL.Add("11-28", new List<FotoFestival>(new[] { R }));
            FESTIVAL.Add("11-29", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("11-30", new List<FotoFestival>(new[] { HH, M, T }));
            FESTIVAL.Add("12-1", new List<FotoFestival>(new[] { S }));
            FESTIVAL.Add("12-3", new List<FotoFestival>(new[] { D }));
            FESTIVAL.Add("12-6", new List<FotoFestival>(new[] { new("天地仓开日", JS), L }));
            FESTIVAL.Add("12-7", new List<FotoFestival>(new FotoFestival[] { new("掠刷大夫降", "犯者得恶疾") }));
            FESTIVAL.Add("12-8", new List<FotoFestival>(new[] { new("王侯腊", DJ), new("释迦如来成佛之辰"), T, new("初旬内戊日，亦名王侯腊", DJ) }));
            FESTIVAL.Add("12-12", new List<FotoFestival>(new FotoFestival[] { new("太素三元君朝真") }));
            FESTIVAL.Add("12-14", new List<FotoFestival>(new[] { T }));
            FESTIVAL.Add("12-15", new List<FotoFestival>(new[] { W, T }));
            FESTIVAL.Add("12-16", new List<FotoFestival>(new FotoFestival[] { new("南岳大帝诞") }));
            FESTIVAL.Add("12-19", new List<FotoFestival>(new[] { Y }));
            FESTIVAL.Add("12-20", new List<FotoFestival>(new FotoFestival[] { new("天地交道", "犯者促寿") }));
            FESTIVAL.Add("12-21", new List<FotoFestival>(new FotoFestival[] { new("天猷上帝诞") }));
            FESTIVAL.Add("12-23", new List<FotoFestival>(new[] { new("五岳诞降"), T }));
            FESTIVAL.Add("12-24", new List<FotoFestival>(new FotoFestival[] { new("司今朝天奏人善恶", "犯者得大祸") }));
            FESTIVAL.Add("12-25", new List<FotoFestival>(new[] { new("三清玉帝同降，考察善恶", "犯者得奇祸"), H }));
            FESTIVAL.Add("12-27", new List<FotoFestival>(new[] { D }));
            FESTIVAL.Add("12-28", new List<FotoFestival>(new[] { R }));
            FESTIVAL.Add("12-29", new List<FotoFestival>(new[] { new("华严菩萨诞"), T }));
            FESTIVAL.Add("12-30", new List<FotoFestival>(new FotoFestival[] { new("诸神下降，察访善恶", "犯者男女俱亡") }));
        }

        /// <summary>
        /// 27星宿，佛教从印度传入中国，印度把28星宿改为27星宿，把牛宿(牛金牛)纳入了女宿(女土蝠)。
        /// </summary>
        public static readonly string[] XIU_27 = { "角", "亢", "氐", "房", "心", "尾", "箕", "斗", "女", "虚", "危", "室", "壁", "奎", "娄", "胃", "昴", "毕", "觜", "参", "井", "鬼", "柳", "星", "张", "翼", "轸" };

        /// <summary>
        /// 每月初一的27星宿偏移
        /// </summary>
        private static readonly int[] XIU_OFFSET = { 11, 13, 15, 17, 19, 21, 24, 0, 2, 4, 7, 9 };

        /// <summary>
        /// 获取27星宿
        /// </summary>
        /// <param name="month">佛历月</param>
        /// <param name="day">佛历日</param>
        /// <returns>星宿</returns>
        public static string GetXiu(int month, int day)
        {
            return XIU_27[(XIU_OFFSET[Math.Abs(month) - 1] + day - 1) % XIU_27.Length];
        }
    }
}
