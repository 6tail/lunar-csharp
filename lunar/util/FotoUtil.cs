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

        private static readonly FotoFestival Y = new FotoFestival("杨公忌");
        private static readonly FotoFestival T = new FotoFestival("四天王巡行", "", true);
        private static readonly FotoFestival D = new FotoFestival("斗降", DJ, true);
        private static readonly FotoFestival S = new FotoFestival("月朔", DJ, true);
        private static readonly FotoFestival W = new FotoFestival("月望", DJ, true);
        private static readonly FotoFestival H = new FotoFestival("月晦", JS, true);
        private static readonly FotoFestival L = new FotoFestival("雷斋日", JS, true);
        private static readonly FotoFestival J = new FotoFestival("九毒日", "犯者夭亡，奇祸不测");
        private static readonly FotoFestival R = new FotoFestival("人神在阴", "犯者得病", true, "宜先一日即戒");
        private static readonly FotoFestival M = new FotoFestival("司命奏事", JS, true, "如月小，即戒廿九");
        private static readonly FotoFestival HH = new FotoFestival("月晦", JS, true, "如月小，即戒廿九");

        /// <summary>
        /// 因果犯忌
        /// </summary>
        public static readonly Dictionary<string, List<FotoFestival>> FESTIVAL = new Dictionary<string, List<FotoFestival>>
        {
            {"1-1", new List<FotoFestival>(new[] { new FotoFestival("天腊，玉帝校世人神气禄命", XL), S })},
            {"1-3", new List<FotoFestival>(new[] { new FotoFestival("万神都会", DJ), D })},
            {"1-5", new List<FotoFestival>(new[] { new FotoFestival("五虚忌") })},
            {"1-6", new List<FotoFestival>(new[] { new FotoFestival("六耗忌"), L })},
            {"1-7", new List<FotoFestival>(new[] { new FotoFestival("上会日", SS) })},
            {"1-8", new List<FotoFestival>(new[] { new FotoFestival("五殿阎罗天子诞", DJ), T })},
            {"1-9", new List<FotoFestival>(new[] { new FotoFestival("玉皇上帝诞", DJ) })},
            {"1-13", new List<FotoFestival>(new[] { Y })},
            {"1-14", new List<FotoFestival>(new[] { new FotoFestival("三元降", JS), T })},
            {"1-15", new List<FotoFestival>(new[] { new FotoFestival("三元降", JS), new FotoFestival("上元神会", DJ), W, T })},
            {"1-16", new List<FotoFestival>(new[] { new FotoFestival("三元降", JS) })},
            {"1-19", new List<FotoFestival>(new[] { new FotoFestival("长春真人诞") })},
            {"1-23", new List<FotoFestival>(new[] { new FotoFestival("三尸神奏事"), T })},
            {"1-25", new List<FotoFestival>(new[] { H, new FotoFestival("天地仓开日", "犯者损寿，子带疾") })},
            {"1-27", new List<FotoFestival>(new[] { D })},
            {"1-28", new List<FotoFestival>(new[] { R })},
            {"1-29", new List<FotoFestival>(new[] { T })},
            {"1-30", new List<FotoFestival>(new[] { HH, M, T })},
            {"2-1", new List<FotoFestival>(new[] { new FotoFestival("一殿秦广王诞", DJ), S })},
            {"2-2", new List<FotoFestival>(new[] { new FotoFestival("万神都会", DJ), new FotoFestival("福德土地正神诞", "犯者得祸") })},
            {"2-3", new List<FotoFestival>(new[] { new FotoFestival("文昌帝君诞", XL), D })},
            {"2-6", new List<FotoFestival>(new[] { new FotoFestival("东华帝君诞"), L })},
            {"2-8", new List<FotoFestival>(new[] { new FotoFestival("释迦牟尼佛出家", DJ), new FotoFestival("三殿宋帝王诞", DJ), new FotoFestival("张大帝诞", DJ), T })},
            {"2-11", new List<FotoFestival>(new[] { Y })},
            {"2-14", new List<FotoFestival>(new[] { T })},
            {"2-15", new List<FotoFestival>(new[] { new FotoFestival("释迦牟尼佛涅槃", XL), new FotoFestival("太上老君诞", XL), new FotoFestival("月望", XL, true), T })},
            {"2-17", new List<FotoFestival>(new[] { new FotoFestival("东方杜将军诞") })},
            {"2-18", new List<FotoFestival>(new[] { new FotoFestival("四殿五官王诞", XL), new FotoFestival("至圣先师孔子讳辰", XL) })},
            {"2-19", new List<FotoFestival>(new[] { new FotoFestival("观音大士诞", DJ) })},
            {"2-21", new List<FotoFestival>(new[] { new FotoFestival("普贤菩萨诞") })},
            {"2-23", new List<FotoFestival>(new[] { T })},
            {"2-25", new List<FotoFestival>(new[] { H })},
            {"2-27", new List<FotoFestival>(new[] { D })},
            {"2-28", new List<FotoFestival>(new[] { R })},
            {"2-29", new List<FotoFestival>(new[] { T })},
            {"2-30", new List<FotoFestival>(new[] { HH, M, T })},
            {"3-1", new List<FotoFestival>(new[] { new FotoFestival("二殿楚江王诞", DJ), S })},
            {"3-3", new List<FotoFestival>(new[] { new FotoFestival("玄天上帝诞", DJ), D })},
            {"3-6", new List<FotoFestival>(new[] { L })},
            {"3-8", new List<FotoFestival>(new[] { new FotoFestival("六殿卞城王诞", DJ), T })},
            {"3-9", new List<FotoFestival>(new[] { new FotoFestival("牛鬼神出", "犯者产恶胎"), Y })},
            {"3-12", new List<FotoFestival>(new[] { new FotoFestival("中央五道诞") })},
            {"3-14", new List<FotoFestival>(new[] { T })},
            {"3-15", new List<FotoFestival>(new[] { new FotoFestival("昊天上帝诞", DJ), new FotoFestival("玄坛诞", DJ), W, T })},
            {"3-16", new List<FotoFestival>(new[] { new FotoFestival("准提菩萨诞", DJ) })},
            {"3-19", new List<FotoFestival>(new[] { new FotoFestival("中岳大帝诞"), new FotoFestival("后土娘娘诞"), new FotoFestival("三茅降") })},
            {"3-20", new List<FotoFestival>(new[] { new FotoFestival("天地仓开日", SS), new FotoFestival("子孙娘娘诞") })},
            {"3-23", new List<FotoFestival>(new[] { T })},
            {"3-25", new List<FotoFestival>(new[] { H })},
            {"3-27", new List<FotoFestival>(new[] { new FotoFestival("七殿泰山王诞"), D })},
            {"3-28", new List<FotoFestival>(new[] { R, new FotoFestival("苍颉至圣先师诞", XL), new FotoFestival("东岳大帝诞") })},
            {"3-29", new List<FotoFestival>(new[] { T })},
            {"3-30", new List<FotoFestival>(new[] { HH, M, T })},
            {"4-1", new List<FotoFestival>(new[] { new FotoFestival("八殿都市王诞", DJ), S })},
            {"4-3", new List<FotoFestival>(new[] { D })},
            {"4-4", new List<FotoFestival>(new[] { new FotoFestival("万神善会", "犯者失瘼夭胎"), new FotoFestival("文殊菩萨诞") })},
            {"4-6", new List<FotoFestival>(new[] { L })},
            {"4-7", new List<FotoFestival>(new[] { new FotoFestival("南斗、北斗、西斗同降", JS), Y })},
            {"4-8", new List<FotoFestival>(new[] { new FotoFestival("释迦牟尼佛诞", DJ), new FotoFestival("万神善会", "犯者失瘼夭胎"), new FotoFestival("善恶童子降", "犯者血死"), new FotoFestival("九殿平等王诞"), T })},
            {"4-14", new List<FotoFestival>(new[] { new FotoFestival("纯阳祖师诞", JS), T })},
            {"4-15", new List<FotoFestival>(new[] { W, new FotoFestival("钟离祖师诞"), T })},
            {"4-16", new List<FotoFestival>(new[] { new FotoFestival("天地仓开日", SS) })},
            {"4-17", new List<FotoFestival>(new[] { new FotoFestival("十殿转轮王诞", DJ) })},
            {"4-18", new List<FotoFestival>(new[] { new FotoFestival("天地仓开日", SS), new FotoFestival("紫徽大帝诞", SS) })},
            {"4-20", new List<FotoFestival>(new[] { new FotoFestival("眼光圣母诞") })},
            {"4-23", new List<FotoFestival>(new[] { T })},
            {"4-25", new List<FotoFestival>(new[] { H })},
            {"4-27", new List<FotoFestival>(new[] { D })},
            {"4-28", new List<FotoFestival>(new[] { R })},
            {"4-29", new List<FotoFestival>(new[] { T })},
            {"4-30", new List<FotoFestival>(new[] { HH, M, T })},
            {"5-1", new List<FotoFestival>(new[] { new FotoFestival("南极长生大帝诞", DJ), S })},
            {"5-3", new List<FotoFestival>(new[] { D })},
            {"5-5", new List<FotoFestival>(new[] { new FotoFestival("地腊", XL), new FotoFestival("五帝校定生人官爵", XL), J, Y })},
            {"5-6", new List<FotoFestival>(new[] { J, L })},
            {"5-7", new List<FotoFestival>(new[] { J })},
            {"5-8", new List<FotoFestival>(new[] { new FotoFestival("南方五道诞"), T })},
            {"5-11", new List<FotoFestival>(new[] { new FotoFestival("天地仓开日", SS), new FotoFestival("天下都城隍诞") })},
            {"5-12", new List<FotoFestival>(new[] { new FotoFestival("炳灵公诞") })},
            {"5-13", new List<FotoFestival>(new[] { new FotoFestival("关圣降", XL) })},
            {"5-14", new List<FotoFestival>(new[] { new FotoFestival("夜子时为天地交泰", JW), T })},
            {"5-15", new List<FotoFestival>(new[] { W, J, T })},
            {"5-16", new List<FotoFestival>(new[] { new FotoFestival("九毒日", JW), new FotoFestival("天地元气造化万物之辰", JW) })},
            {"5-17", new List<FotoFestival>(new[] { J })},
            {"5-18", new List<FotoFestival>(new[] { new FotoFestival("张天师诞") })},
            {"5-22", new List<FotoFestival>(new[] { new FotoFestival("孝娥神诞", DJ) })},
            {"5-23", new List<FotoFestival>(new[] { T })},
            {"5-25", new List<FotoFestival>(new[] { J, H })},
            {"5-26", new List<FotoFestival>(new[] { J })},
            {"5-27", new List<FotoFestival>(new[] { J, D })},
            {"5-28", new List<FotoFestival>(new[] { R })},
            {"5-29", new List<FotoFestival>(new[] { T })},
            {"5-30", new List<FotoFestival>(new[] { HH, M, T })},
            {"6-1", new List<FotoFestival>(new[] { S })},
            {"6-3", new List<FotoFestival>(new[] { new FotoFestival("韦驮菩萨圣诞"), D, Y })},
            {"6-5", new List<FotoFestival>(new[] { new FotoFestival("南赡部洲转大轮", SS) })},
            {"6-6", new List<FotoFestival>(new[] { new FotoFestival("天地仓开日", SS), L })},
            {"6-8", new List<FotoFestival>(new[] { T })},
            {"6-10", new List<FotoFestival>(new[] { new FotoFestival("金粟如来诞") })},
            {"6-14", new List<FotoFestival>(new[] { T })},
            {"6-15", new List<FotoFestival>(new[] { W, T })},
            {"6-19", new List<FotoFestival>(new[] { new FotoFestival("观世音菩萨成道", DJ) })},
            {"6-23", new List<FotoFestival>(new[] { new FotoFestival("南方火神诞", "犯者遭回禄"), T })},
            {"6-24", new List<FotoFestival>(new[] { new FotoFestival("雷祖诞", XL), new FotoFestival("关帝诞", XL) })},
            {"6-25", new List<FotoFestival>(new[] { H })},
            {"6-27", new List<FotoFestival>(new[] { D })},
            {"6-28", new List<FotoFestival>(new[] { R })},
            {"6-29", new List<FotoFestival>(new[] { T })},
            {"6-30", new List<FotoFestival>(new[] { HH, M, T })},
            {"7-1", new List<FotoFestival>(new[] { S, Y })},
            {"7-3", new List<FotoFestival>(new[] { D })},
            {"7-5", new List<FotoFestival>(new[] { new FotoFestival("中会日", SS, false, "一作初七") })},
            {"7-6", new List<FotoFestival>(new[] { L })},
            {"7-7", new List<FotoFestival>(new[] { new FotoFestival("道德腊", XL), new FotoFestival("五帝校生人善恶", XL), new FotoFestival("魁星诞", XL) })},
            {"7-8", new List<FotoFestival>(new[] { T })},
            {"7-10", new List<FotoFestival>(new[] { new FotoFestival("阴毒日", "", false, "大忌") })},
            {"7-12", new List<FotoFestival>(new[] { new FotoFestival("长真谭真人诞") })},
            {"7-13", new List<FotoFestival>(new[] { new FotoFestival("大势至菩萨诞", JS) })},
            {"7-14", new List<FotoFestival>(new[] { new FotoFestival("三元降", JS), T })},
            {"7-15", new List<FotoFestival>(new[] { W, new FotoFestival("三元降", DJ), new FotoFestival("地官校籍", DJ), T })},
            {"7-16", new List<FotoFestival>(new[] { new FotoFestival("三元降", JS) })},
            {"7-18", new List<FotoFestival>(new[] { new FotoFestival("西王母诞", DJ) })},
            {"7-19", new List<FotoFestival>(new[] { new FotoFestival("太岁诞", DJ) })},
            {"7-22", new List<FotoFestival>(new[] { new FotoFestival("增福财神诞", XL) })},
            {"7-23", new List<FotoFestival>(new[] { T })},
            {"7-25", new List<FotoFestival>(new[] { H })},
            {"7-27", new List<FotoFestival>(new[] { D })},
            {"7-28", new List<FotoFestival>(new[] { R })},
            {"7-29", new List<FotoFestival>(new[] { Y, T })},
            {"7-30", new List<FotoFestival>(new[] { new FotoFestival("地藏菩萨诞", DJ), HH, M, T })},
            {"8-1", new List<FotoFestival>(new[] { S, new FotoFestival("许真君诞") })},
            {"8-3", new List<FotoFestival>(new[] { D, new FotoFestival("北斗诞", XL), new FotoFestival("司命灶君诞", "犯者遭回禄") })},
            {"8-5", new List<FotoFestival>(new[] { new FotoFestival("雷声大帝诞", DJ) })},
            {"8-6", new List<FotoFestival>(new[] { L })},
            {"8-8", new List<FotoFestival>(new[] { T })},
            {"8-10", new List<FotoFestival>(new[] { new FotoFestival("北斗大帝诞") })},
            {"8-12", new List<FotoFestival>(new[] { new FotoFestival("西方五道诞") })},
            {"8-14", new List<FotoFestival>(new[] { T })},
            {"8-15", new List<FotoFestival>(new[] { W, new FotoFestival("太明朝元", "犯者暴亡", false, "宜焚香守夜"), T })},
            {"8-16", new List<FotoFestival>(new[] { new FotoFestival("天曹掠刷真君降", "犯者贫夭") })},
            {"8-18", new List<FotoFestival>(new[] { new FotoFestival("天人兴福之辰", "", false, "宜斋戒，存想吉事") })},
            {"8-23", new List<FotoFestival>(new[] { new FotoFestival("汉恒候张显王诞"), T })},
            {"8-24", new List<FotoFestival>(new[] { new FotoFestival("灶君夫人诞") })},
            {"8-25", new List<FotoFestival>(new[] { H })},
            {"8-27", new List<FotoFestival>(new[] { D, new FotoFestival("至圣先师孔子诞", XL), Y })},
            {"8-28", new List<FotoFestival>(new[] { R, new FotoFestival("四天会事") })},
            {"8-29", new List<FotoFestival>(new[] { T })},
            {"8-30", new List<FotoFestival>(new[] { new FotoFestival("诸神考校", "犯者夺算"), HH, M, T })},
            {"9-1", new List<FotoFestival>(new[] { S, new FotoFestival("南斗诞", XL), new FotoFestival("北斗九星降世", DJ, false, "此九日俱宜斋戒") })},
            {"9-3", new List<FotoFestival>(new[] { D, new FotoFestival("五瘟神诞") })},
            {"9-6", new List<FotoFestival>(new[] { L })},
            {"9-8", new List<FotoFestival>(new[] { T })},
            {"9-9", new List<FotoFestival>(new[] { new FotoFestival("斗母诞", XL), new FotoFestival("酆都大帝诞"), new FotoFestival("玄天上帝飞升") })},
            {"9-10", new List<FotoFestival>(new[] { new FotoFestival("斗母降", DJ) })},
            {"9-11", new List<FotoFestival>(new[] { new FotoFestival("宜戒") })},
            {"9-13", new List<FotoFestival>(new[] { new FotoFestival("孟婆尊神诞") })},
            {"9-14", new List<FotoFestival>(new[] { T })},
            {"9-15", new List<FotoFestival>(new[] { W, T })},
            {"9-17", new List<FotoFestival>(new[] { new FotoFestival("金龙四大王诞", "犯者遭水厄") })},
            {"9-19", new List<FotoFestival>(new[] { new FotoFestival("日宫月宫会合", JS), new FotoFestival("观世音菩萨诞", JS) })},
            {"9-23", new List<FotoFestival>(new[] { T })},
            {"9-25", new List<FotoFestival>(new[] { H, Y })},
            {"9-27", new List<FotoFestival>(new[] { D })},
            {"9-28", new List<FotoFestival>(new[] { R })},
            {"9-29", new List<FotoFestival>(new[] { T })},
            {"9-30", new List<FotoFestival>(new[] { new FotoFestival("药师琉璃光佛诞", "犯者危疾"), HH, M, T })},
            {"10-1", new List<FotoFestival>(new[] { S, new FotoFestival("民岁腊", DJ), new FotoFestival("四天王降", "犯者一年内死") })},
            {"10-3", new List<FotoFestival>(new[] { D, new FotoFestival("三茅诞") })},
            {"10-5", new List<FotoFestival>(new[] { new FotoFestival("下会日", JS), new FotoFestival("达摩祖师诞", JS) })},
            {"10-6", new List<FotoFestival>(new[] { L, new FotoFestival("天曹考察", DJ) })},
            {"10-8", new List<FotoFestival>(new[] { new FotoFestival("佛涅槃日", "", false, "大忌色欲"), T })},
            {"10-10", new List<FotoFestival>(new[] { new FotoFestival("四天王降", "犯者一年内死") })},
            {"10-11", new List<FotoFestival>(new[] { new FotoFestival("宜戒") })},
            {"10-14", new List<FotoFestival>(new[] { new FotoFestival("三元降", JS), T })},
            {"10-15", new List<FotoFestival>(new[] { W, new FotoFestival("三元降", DJ), new FotoFestival("下元水府校籍", DJ), T })},
            {"10-16", new List<FotoFestival>(new[] { new FotoFestival("三元降", JS), T })},
            {"10-23", new List<FotoFestival>(new[] { Y, T })},
            {"10-25", new List<FotoFestival>(new[] { H })},
            {"10-27", new List<FotoFestival>(new[] { D, new FotoFestival("北极紫徽大帝降") })},
            {"10-28", new List<FotoFestival>(new[] { R })},
            {"10-29", new List<FotoFestival>(new[] { T })},
            {"10-30", new List<FotoFestival>(new[] { HH, M, T })},
            {"11-1", new List<FotoFestival>(new[] { S })},
            {"11-3", new List<FotoFestival>(new[] { D })},
            {"11-4", new List<FotoFestival>(new[] { new FotoFestival("至圣先师孔子诞", XL) })},
            {"11-6", new List<FotoFestival>(new[] { new FotoFestival("西岳大帝诞") })},
            {"11-8", new List<FotoFestival>(new[] { T })},
            {"11-11", new List<FotoFestival>(new[] { new FotoFestival("天地仓开日", DJ), new FotoFestival("太乙救苦天尊诞", DJ) })},
            {"11-14", new List<FotoFestival>(new[] { T })},
            {"11-15", new List<FotoFestival>(new[] { new FotoFestival("月望", "上半夜犯男死 下半夜犯女死"), new FotoFestival("四天王巡行", "上半夜犯男死 下半夜犯女死") })},
            {"11-17", new List<FotoFestival>(new[] { new FotoFestival("阿弥陀佛诞") })},
            {"11-19", new List<FotoFestival>(new[] { new FotoFestival("太阳日宫诞", "犯者得奇祸") })},
            {"11-21", new List<FotoFestival>(new[] { Y })},
            {"11-23", new List<FotoFestival>(new[] { new FotoFestival("张仙诞", "犯者绝嗣"), T })},
            {"11-25", new List<FotoFestival>(new[] { new FotoFestival("掠刷大夫降", "犯者遭大凶"), H })},
            {"11-26", new List<FotoFestival>(new[] { new FotoFestival("北方五道诞") })},
            {"11-27", new List<FotoFestival>(new[] { D })},
            {"11-28", new List<FotoFestival>(new[] { R })},
            {"11-29", new List<FotoFestival>(new[] { T })},
            {"11-30", new List<FotoFestival>(new[] { HH, M, T })},
            {"12-1", new List<FotoFestival>(new[] { S })},
            {"12-3", new List<FotoFestival>(new[] { D })},
            {"12-6", new List<FotoFestival>(new[] { new FotoFestival("天地仓开日", JS), L })},
            {"12-7", new List<FotoFestival>(new[] { new FotoFestival("掠刷大夫降", "犯者得恶疾") })},
            {"12-8", new List<FotoFestival>(new[] { new FotoFestival("王侯腊", DJ), new FotoFestival("释迦如来成佛之辰"), T, new FotoFestival("初旬内戊日，亦名王侯腊", DJ) })},
            {"12-12", new List<FotoFestival>(new[] { new FotoFestival("太素三元君朝真") })},
            {"12-14", new List<FotoFestival>(new[] { T })},
            {"12-15", new List<FotoFestival>(new[] { W, T })},
            {"12-16", new List<FotoFestival>(new[] { new FotoFestival("南岳大帝诞") })},
            {"12-19", new List<FotoFestival>(new[] { Y })},
            {"12-20", new List<FotoFestival>(new[] { new FotoFestival("天地交道", "犯者促寿") })},
            {"12-21", new List<FotoFestival>(new[] { new FotoFestival("天猷上帝诞") })},
            {"12-23", new List<FotoFestival>(new[] { new FotoFestival("五岳诞降"), T })},
            {"12-24", new List<FotoFestival>(new[] { new FotoFestival("司今朝天奏人善恶", "犯者得大祸") })},
            {"12-25", new List<FotoFestival>(new[] { new FotoFestival("三清玉帝同降，考察善恶", "犯者得奇祸"), H })},
            {"12-27", new List<FotoFestival>(new[] { D })},
            {"12-28", new List<FotoFestival>(new[] { R })},
            {"12-29", new List<FotoFestival>(new[] { new FotoFestival("华严菩萨诞"), T })},
            {"12-30", new List<FotoFestival>(new[] { new FotoFestival("诸神下降，察访善恶", "犯者男女俱亡") })}
        };

        /// <summary>
        /// 纪念日
        /// </summary>
        public static readonly Dictionary<string, List<string>> OTHER_FESTIVAL = new Dictionary<string, List<string>>
        {
            {"1-1", new List<string>(new[] { "弥勒菩萨圣诞" })},
            {"1-6", new List<string>(new[] { "定光佛圣诞" })},
            {"2-8", new List<string>(new[] { "释迦牟尼佛出家" })},
            {"2-15", new List<string>(new[] { "释迦牟尼佛涅槃" })},
            {"2-19", new List<string>(new[] { "观世音菩萨圣诞" })},
            {"2-21", new List<string>(new[] { "普贤菩萨圣诞" })},
            {"3-16", new List<string>(new[] { "准提菩萨圣诞" })},
            {"4-4", new List<string>(new[] { "文殊菩萨圣诞" })},
            {"4-8", new List<string>(new[] { "释迦牟尼佛圣诞" })},
            {"4-15", new List<string>(new[] { "佛吉祥日" })},
            {"4-28", new List<string>(new[] { "药王菩萨圣诞" })},
            {"5-13", new List<string>(new[] { "伽蓝菩萨圣诞" })},
            {"6-3", new List<string>(new[] { "韦驮菩萨圣诞" })},
            {"6-19", new List<string>(new[] { "观音菩萨成道" })},
            {"7-13", new List<string>(new[] { "大势至菩萨圣诞" })},
            {"7-15", new List<string>(new[] { "佛欢喜日" })},
            {"7-24", new List<string>(new[] { "龙树菩萨圣诞" })},
            {"7-30", new List<string>(new[] { "地藏菩萨圣诞" })},
            {"8-15", new List<string>(new[] { "月光菩萨圣诞" })},
            {"8-22", new List<string>(new[] { "燃灯佛圣诞" })},
            {"9-9", new List<string>(new[] { "摩利支天菩萨圣诞" })},
            {"9-19", new List<string>(new[] { "观世音菩萨出家" })},
            {"9-30", new List<string>(new[] { "药师琉璃光佛圣诞" })},
            {"10-5", new List<string>(new[] { "达摩祖师圣诞" })},
            {"10-20", new List<string>(new[] { "文殊菩萨出家" })},
            {"11-17", new List<string>(new[] { "阿弥陀佛圣诞" })},
            {"11-19", new List<string>(new[] { "日光菩萨圣诞" })},
            {"12-8", new List<string>(new[] { "释迦牟尼佛成道" })},
            {"12-23", new List<string>(new[] { "监斋菩萨圣诞" })},
            {"12-29", new List<string>(new[] { "华严菩萨圣诞" })}
        };

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
