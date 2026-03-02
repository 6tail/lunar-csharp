using System.Collections.Generic;

namespace Lunar.Util
{
    /// <summary>
    /// 字串資料 (繁體)
    /// </summary>
    public class TextResourceBaseCht : TextResource
    {


        /// <summary>
        /// 六曜
        /// </summary>
        public override string[] LIU_YAO { get; } = { "先勝", "友引", "先負", "佛滅", "大安", "赤口" };



        /// <summary>
        /// 物候
        /// </summary>
        public override string[] WU_HOU { get; } = { "蚯蚓結", "麋角解", "水泉動", "雁北鄉", "鵲始巢", "雉始雊", "雞始乳", "徵鳥厲疾", "水澤腹堅", "東風解凍", "蟄蟲始振", "魚陟負冰", "獺祭魚", "候雁北", "草木萌動", "桃始華", "倉庚鳴", "鷹化為鳩", "玄鳥至", "雷乃發聲", "始電", "桐始華", "田鼠化為鴽", "虹始見", "萍始生", "鳴鳩拂其羽", "戴勝降於桑", "螻蟈鳴", "蚯蚓出", "王瓜生", "苦菜秀", "靡草死", "麥秋至", "螳螂生", "鵙始鳴", "反舌無聲", "鹿角解", "蜩始鳴", "半夏生", "溫風至", "蟋蟀居壁", "鷹始摯", "腐草為螢", "土潤溽暑", "大雨行時", "涼風至", "白露降", "寒蟬鳴", "鷹乃祭鳥", "天地始肅", "禾乃登", "鴻雁來", "玄鳥歸", "群鳥養羞", "雷始收聲", "蟄蟲坯戶", "水始涸", "鴻雁來賓", "雀入大水為蛤", "菊有黃花", "豺乃祭獸", "草木黃落", "蟄蟲咸俯", "水始冰", "地始凍", "雉入大水為蜃", "虹藏不見", "天氣上升地氣下降", "閉塞而成冬", "鶡鴠不鳴", "虎始交", "荔挺出" };



        /// <summary>
        /// 喜神方位，《喜神方位歌》：甲己在艮乙庚乾，丙辛坤位喜神安。丁壬只在離宮坐，戊癸原在在巽間。
        /// </summary>
        public override string[] POSITION_XI { get; } = { "", "艮", "乾", "坤", "離", "巽", "艮", "乾", "坤", "離", "巽" };

        /// <summary>
        /// 陽貴方位，《陽貴神歌》：甲戊坤艮位，乙己是坤坎，庚辛居離艮，丙丁兌與乾，震巽屬何日，壬癸貴神安。
        /// </summary>
        public override string[] POSITION_YANG_GUI { get; } = { "", "坤", "坤", "兌", "乾", "艮", "坎", "離", "艮", "震", "巽" };

        /// <summary>
        /// 陰貴方位，《陰貴神歌》：甲戊見牛羊，乙己鼠猴鄉，丙丁豬雞位，壬癸蛇兔藏，庚辛逢虎馬，此是貴神方。
        /// </summary>
        public override string[] POSITION_YIN_GUI { get; } = { "", "艮", "坎", "乾", "兌", "坤", "坤", "艮", "離", "巽", "震" };

        /// <summary>
        /// 《福神方位歌》流派 1：甲乙東南是福神，丙丁正東是堪宜，戊北己南庚辛坤，壬在乾方癸在西。
        /// </summary>
        public override string[] POSITION_FU { get; } = { "", "巽", "巽", "震", "震", "坎", "離", "坤", "坤", "乾", "兌" };


        /// <summary>
        /// 財神方位，《財神方位歌》：甲乙東北是財神，丙丁向在西南尋，戊己正北坐方位，庚辛正東去安身，壬癸原來正南坐，便是財神方位真。
        /// </summary>
        public override string[] POSITION_CAI { get; } = { "", "艮", "艮", "坤", "坤", "坎", "坎", "震", "震", "離", "離" };

        /// <summary>
        /// 逐日胎神方位
        /// </summary>
        public override string[] POSITION_TAI_DAY { get; } =
        {
            "占門碓 外東南", "碓磨廁 外東南", "廚灶爐 外正南", "倉庫門 外正南", "房床棲 外正南", "占門床 外正南", "占碓磨 外正南", "廚灶廁 外西南", "倉庫爐 外西南", "房床門 外西南",
            "占門棲 外西南", "碓磨床 外西南", "廚灶碓 外西南", "倉庫廁 外正西", "房床爐 外正西", "占大門 外正西", "碓磨棲 外正西", "廚灶床 外正西", "倉庫碓 外西北", "房床廁 外西北",
            "占門爐 外西北", "碓磨門 外西北", "廚灶棲 外西北", "倉庫床 外西北", "房床碓 外正北", "占門廁 外正北", "碓磨爐 外正北", "廚灶門 外正北", "倉庫棲 外正北", "占房床 房內北",
            "占門碓 房內北", "碓磨廁 房內北", "廚灶爐 房內北", "倉庫門 房內北", "床房棲 房內中", "占門床 房內中", "占碓磨 房內南", "廚灶廁 房內南", "倉庫爐 房內南", "房床門 房內西",
            "占門棲 房內東", "碓磨床 房內東", "廚灶碓 房內東", "倉庫廁 房內東", "房床爐 房內中", "占大門 外東北", "碓磨棲 外東北", "廚灶床 外東北", "倉庫碓 外東北", "房床廁 外東北",
            "占門爐 外東北", "碓磨門 外正東", "廚灶棲 外正東", "倉庫床 外正東", "房床碓 外正東", "占門廁 外正東", "碓磨爐 外東南", "廚灶門 外東南", "倉庫棲 外東南", "占房床 外東南"
        };

        /// <summary>
        /// 逐月胎神方位
        /// </summary>
        public override string[] POSITION_TAI_MONTH { get; } = { "占房床", "占戶窗", "占門堂", "占廚灶", "占房床", "占床倉", "占碓磨", "占廁戶", "占門房", "占房床", "占灶爐", "占房床" };

        /// <summary>
        /// 年太歲方位
        /// </summary>
        public override string[] POSITION_TAI_SUI_YEAR { get; } = { "坎", "艮", "艮", "震", "巽", "巽", "離", "坤", "坤", "兌", "坎", "坎" };

        /// <summary>
        /// 天干方位
        /// </summary>
        public override string[] POSITION_GAN { get; } = { "震", "震", "離", "離", "中", "中", "兌", "兌", "坎", "坎" };

        /// <summary>
        /// 地支方位
        /// </summary>
        public override string[] POSITION_ZHI { get; } = { "坎", "中", "震", "震", "中", "離", "離", "中", "兌", "兌", "中", "坎" };



        /// <summary>
        /// 十二值星
        /// </summary>
        public override string[] ZHI_XING { get; } = { "", "建", "除", "滿", "平", "定", "執", "破", "危", "成", "收", "開", "閉" };

        /// <summary>
        /// 十二天神
        /// </summary>
        public override string[] TIAN_SHEN { get; } = { "", "青龍", "明堂", "天刑", "朱雀", "金匱", "天德", "白虎", "玉堂", "天牢", "玄武", "司命", "勾陳" };

        /// <summary>
        /// 宜忌
        /// </summary>
        public override string[] YI_JI { get; } = { "祭祀", "祈福", "求嗣", "開光", "塑繪", "齊醮", "齋醮", "沐浴", "酬神", "造廟", "祀灶", "焚香", "謝土", "出火", "雕刻", "嫁娶", "訂婚", "納採", "問名", "納婿", "歸寧", "安床", "合帳", "冠笄", "訂盟", "進人口", "裁衣", "挽面", "開容", "修墳", "啟鑽", "破土", "安葬", "立碑", "成服", "除服", "開生墳", "合壽木", "入殮", "移柩", "普渡", "入宅", "安香", "安門", "修造", "起基", "動土", "上梁", "豎柱", "開井開池", "作陂放水", "拆卸", "破屋", "壞垣", "補垣", "伐木做梁", "作灶", "解除", "開柱眼", "穿屏扇架", "蓋屋合脊", "開廁", "造倉", "塞穴", "平治道塗", "造橋", "作廁", "築堤", "開池", "伐木", "開渠", "掘井", "掃舍", "放水", "造屋", "合脊", "造畜稠", "修門", "定磉", "作梁", "修飾垣牆", "架馬", "開市", "掛匾", "納財", "求財", "開倉", "買車", "置產", "僱傭", "出貨財", "安機械", "造車器", "經絡", "醞釀", "作染", "鼓鑄", "造船", "割蜜", "栽種", "取漁", "結網", "牧養", "安碓磑", "習藝", "入學", "理髮", "探病", "見貴", "乘船", "渡水", "針灸", "出行", "移徙", "分居", "剃頭", "整手足甲", "納畜", "捕捉", "畋獵", "教牛馬", "會親友", "赴任", "求醫", "治病", "詞訟", "起基動土", "破屋壞垣", "蓋屋", "造倉庫", "立券交易", "交易", "立券", "安機", "會友", "求醫療病", "諸事不宜", "餘事勿取", "行喪", "斷蟻", "歸岫", "無" };

        /// <summary>
        /// 神煞
        /// </summary>
        public override string[] SHEN_SHA { get; } = { "天恩", "鳴吠", "母倉", "不將", "四相", "鳴吠對", "五合", "三合", "除神", "月德", "月空", "月德合", "月恩", "時陰", "五富", "生氣", "金匱", "相日", "陰德", "六合", "益後", "青龍", "續世", "明堂", "王日", "要安", "官日", "吉期", "福德", "六儀", "金堂", "寶光", "民日", "臨日", "天馬", "敬安", "普護", "驛馬", "天後", "陽德", "天喜", "天醫", "司命", "聖心", "玉宇", "守日", "時德", "解神", "時陽", "天倉", "天巫", "玉堂", "福生", "天德", "天德合", "天願", "天赦", "天符", "陰神", "解除", "五虛", "五離", "重日", "複日", "血支", "天賊", "土符", "遊禍", "白虎", "小耗", "致死", "河魁", "劫煞", "月煞", "月建", "往亡", "大時", "大敗", "咸池", "厭對", "招搖", "九坎", "九焦", "天罡", "死神", "月害", "死氣", "月破", "大耗", "天牢", "元武", "月厭", "月虛", "歸忌", "小時", "天刑", "朱雀", "九空", "天吏", "地火", "四擊", "大煞", "勾陳", "八專", "災煞", "天火", "血忌", "土府", "月刑", "觸水龍", "地囊", "八風", "四廢", "四忌", "四窮", "五墓", "陰錯", "四耗", "陽錯", "孤辰", "小會", "大會", "八龍", "七鳥", "九虎", "六蛇", "天狗", "行狠", "了戾", "歲薄", "逐陣", "三喪", "三陰", "陰道衝陽", "陰位", "陰陽交破", "陰陽俱錯", "陰陽擊衝", "鬼哭", "單陰", "絕陰", "純陽", "陽錯陰衝", "七符", "成日", "孤陽", "絕陽", "純陰", "大退", "四離", "陽破陰衝" };

        /// <summary>
        /// 彭祖百忌.天干
        /// </summary>
        public override string[] PENGZU_GAN { get; } = { "", "甲不開倉財物耗散", "乙不栽植千株不長", "丙不修灶必見災殃", "丁不剃頭頭必生瘡", "戊不受田田主不祥", "己不破券二比並亡", "庚不經絡織機虛張", "辛不合醬主人不嘗", "壬不泱水更難提防", "癸不詞訟理弱敵強" };

        /// <summary>
        /// 彭祖百忌.地支
        /// </summary>
        public override string[] PENGZU_ZHI { get; } = { "", "子不問卜自惹禍殃", "丑不冠帶主不還鄉", "寅不祭祀神鬼不嘗", "卯不穿井水泉不香", "辰不哭泣必主重喪", "巳不遠行財物伏藏", "午不苫蓋屋主更張", "未不服藥毒氣入腸", "申不安床鬼祟入房", "酉不會客醉坐顛狂", "戌不吃犬作怪上床", "亥不嫁娶不利新郎" };

        /// <summary>
        /// 月
        /// </summary>
        public override string[] MONTH { get; } = { "", "正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "冬", "臘" };


        /// <summary>
        /// 生肖
        /// </summary>
        public override string[] SHENGXIAO { get; } = { "", "鼠", "牛", "虎", "兔", "龍", "蛇", "馬", "羊", "猴", "雞", "狗", "豬" };

        /// <summary>
        /// 月相
        /// </summary>
        public override string[] YUE_XIANG { get; } = { "", "朔", "既朔", "蛾眉新", "蛾眉新", "蛾眉", "夕", "上弦", "上弦", "九夜", "宵", "宵", "宵", "漸盈凸", "小望", "望", "既望", "立待", "居待", "寢待", "更待", "漸虧凸", "下弦", "下弦", "有明", "有明", "蛾眉殘", "蛾眉殘", "殘", "曉", "晦" };


        /// <summary>
        /// 天神類型：黃道，黑道
        /// </summary>
        public override Dictionary<string, string> TIAN_SHEN_TYPE { get; } = new Dictionary<string, string>
        {
            {"青龍", "黃道"},
            {"明堂", "黃道"},
            {"金匱", "黃道"},
            {"天德", "黃道"},
            {"玉堂", "黃道"},
            {"司命", "黃道"},

            {"天刑", "黑道"},
            {"朱雀", "黑道"},
            {"白虎", "黑道"},
            {"天牢", "黑道"},
            {"玄武", "黑道"},
            {"勾陳", "黑道"}
        };

        /// <summary>
        /// 天神類型吉凶
        /// </summary>
        public override Dictionary<string, string> TIAN_SHEN_TYPE_LUCK { get; } = new Dictionary<string, string>
        {
            {"黃道", "吉"},
            {"黑道", "凶"}
        };

        /// <summary>
        /// 節日
        /// </summary>
        public override Dictionary<string, string> FESTIVAL { get; } = new Dictionary<string, string>
        {
            {"1-1", "春節"},
            {"1-15", "元宵節"},
            {"2-2", "龍頭節"},
            {"5-5", "端午節"},
            {"7-7", "七夕節"},
            {"8-15", "中秋節"},
            {"9-9", "重陽節"},
            {"12-8", "臘八節"}
        };

        /// <summary>
        /// 非正式節日
        /// </summary>
        public override Dictionary<string, List<string>> OTHER_FESTIVAL { get; } = new Dictionary<string, List<string>>
        {
            {"1-4", new List<string>(new[] {"接神日"})},
            {"1-5", new List<string>(new[] {"隔開日"})},
            {"1-7", new List<string>(new[] {"人日"})},
            {"1-8", new List<string>(new[] {"穀日", "順星節"})},
            {"1-9", new List<string>(new[] {"天日"})},
            {"1-10", new List<string>(new[] {"地日"})},
            {"1-20", new List<string>(new[] {"天穿節"})},
            {"1-25", new List<string>(new[] {"填倉節"})},
            {"1-30", new List<string>(new[] {"正月晦"})},
            {"2-1", new List<string>(new[] {"中和節"})},
            {"2-2", new List<string>(new[] {"社日節"})},
            {"3-3", new List<string>(new[] {"上巳節"})},
            {"5-20", new List<string>(new[] {"分龍節"})},
            {"5-25", new List<string>(new[] {"會龍節"})},
            {"6-6", new List<string>(new[] {"天贶節"})},
            {"6-24", new List<string>(new[] {"觀蓮節"})},
            {"6-25", new List<string>(new[] {"五穀母節"})},
            {"7-15", new List<string>(new[] {"中元節"})},
            {"7-22", new List<string>(new[] {"財神節"})},
            {"7-29", new List<string>(new[] {"地藏節"})},
            {"8-1", new List<string>(new[] {"天灸日"})},
            {"10-1", new List<string>(new[] {"寒衣節"})},
            {"10-10", new List<string>(new[] {"十成節"})},
            {"10-15", new List<string>(new[] {"下元節"})},
            {"12-7", new List<string>(new[] {"驅儺日"})},
            {"12-16", new List<string>(new[] {"尾牙"})},
            {"12-24", new List<string>(new[] {"祭灶日"})}
        };

        /// <summary>
        /// 28 星宿對照表，地支+星期
        /// </summary>
        public override Dictionary<string, string> XIU { get; } = new Dictionary<string, string>
        {
            {"申1", "畢"},
            {"申2", "翼"},
            {"申3", "箕"},
            {"申4", "奎"},
            {"申5", "鬼"},
            {"申6", "氐"},
            {"申0", "虛"},

            {"子1", "畢"},
            {"子2", "翼"},
            {"子3", "箕"},
            {"子4", "奎"},
            {"子5", "鬼"},
            {"子6", "氐"},
            {"子0", "虛"},

            {"辰1", "畢"},
            {"辰2", "翼"},
            {"辰3", "箕"},
            {"辰4", "奎"},
            {"辰5", "鬼"},
            {"辰6", "氐"},
            {"辰0", "虛"},

            {"巳1", "危"},
            {"巳2", "觜"},
            {"巳3", "軫"},
            {"巳4", "斗"},
            {"巳5", "婁"},
            {"巳6", "柳"},
            {"巳0", "房"},

            {"酉1", "危"},
            {"酉2", "觜"},
            {"酉3", "軫"},
            {"酉4", "斗"},
            {"酉5", "婁"},
            {"酉6", "柳"},
            {"酉0", "房"},

            {"丑1", "危"},
            {"丑2", "觜"},
            {"丑3", "軫"},
            {"丑4", "斗"},
            {"丑5", "婁"},
            {"丑6", "柳"},
            {"丑0", "房"},

            {"寅1", "心"},
            {"寅2", "室"},
            {"寅3", "參"},
            {"寅4", "角"},
            {"寅5", "牛"},
            {"寅6", "胃"},
            {"寅0", "星"},

            {"午1", "心"},
            {"午2", "室"},
            {"午3", "參"},
            {"午4", "角"},
            {"午5", "牛"},
            {"午6", "胃"},
            {"午0", "星"},

            {"戌1", "心"},
            {"戌2", "室"},
            {"戌3", "參"},
            {"戌4", "角"},
            {"戌5", "牛"},
            {"戌6", "胃"},
            {"戌0", "星"},

            {"亥1", "張"},
            {"亥2", "尾"},
            {"亥3", "壁"},
            {"亥4", "井"},
            {"亥5", "亢"},
            {"亥6", "女"},
            {"亥0", "昴"},

            {"卯1", "張"},
            {"卯2", "尾"},
            {"卯3", "壁"},
            {"卯4", "井"},
            {"卯5", "亢"},
            {"卯6", "女"},
            {"卯0", "昴"},

            {"未1", "張"},
            {"未2", "尾"},
            {"未3", "壁"},
            {"未4", "井"},
            {"未5", "亢"},
            {"未6", "女"},
            {"未0", "昴"}
        };

        /// <summary>
        /// 星宿對應吉凶
        /// </summary>
        public override Dictionary<string, string> XIU_LUCK { get; } = new Dictionary<string, string>
        {
            {"角", "吉"},
            {"亢", "凶"},
            {"氐", "凶"},
            {"房", "吉"},
            {"心", "凶"},
            {"尾", "吉"},
            {"箕", "吉"},
            {"斗", "吉"},
            {"牛", "凶"},
            {"女", "凶"},
            {"虛", "凶"},
            {"危", "凶"},
            {"室", "吉"},
            {"壁", "吉"},
            {"奎", "凶"},
            {"婁", "吉"},
            {"胃", "吉"},
            {"昴", "凶"},
            {"畢", "吉"},
            {"觜", "凶"},
            {"參", "吉"},
            {"井", "吉"},
            {"鬼", "凶"},
            {"柳", "凶"},
            {"星", "凶"},
            {"張", "吉"},
            {"翼", "凶"},
            {"軫", "吉"}
        };

        /// <summary>
        /// 星宿歌
        /// </summary>
        public override Dictionary<string, string> XIU_SONG { get; } = new Dictionary<string, string>
        {
            {"角", "角星造作主榮昌，外進田財及女郎，嫁娶婚姻出貴子，文人及第見君王，惟有埋葬不可用，三年之後主瘟疫，起工修築墳基地，堂前立見主人凶。"},
            {"亢", "亢星造作長房當，十日之中主有殃，田地消磨官失職，接運定是虎狼傷，嫁娶婚姻用此日，兒孫新婦守空房，埋葬若還用此日，當時害禍主重傷。"},
            {"氐", "氐星造作主災凶，費盡田園倉庫空，埋葬不可用此日，懸繩吊頸禍重重，若是婚姻離別散，夜招浪子入房中，行船必定遭沉沒，更生聾啞子孫窮。"},
            {"房", "房星造作田園進，錢財牛馬遍山崗，更招外處田莊宅，榮華富貴福祿康，埋葬若然用此日，高官進職拜君王，嫁娶嫦娥至月殿，三年抱子至朝堂。"},
            {"心", "心星造作大為凶，更遭刑訟獄囚中，忤逆官非宅產退，埋葬卒暴死相從，婚姻若是用此日，子死兒亡淚滿胸，三年之內連遭禍，事事教君沒始終。"},
            {"尾", "尾星造作主天恩，富貴榮華福祿增，招財進寶興家宅，和合婚姻貴子孫，埋葬若能依此日，男清女正子孫興，開門放水招田宅，代代公侯遠播名。"},
            {"箕", "箕星造作主高強，歲歲年年大吉昌，埋葬修墳大吉利，田蠶牛馬遍山崗，開門放水招田宅，箧滿金銀谷滿倉，福蔭高官加祿位，六親豐祿樂安康。"},
            {"斗", "斗星造作主招財，文武官員位鼎台，田宅家財千萬進，墳堂修築貴富來，開門放水招牛馬，旺蠶男女主和諧，遇此吉宿來照護，時支福慶永無災。"},
            {"牛", "牛星造作主災危，九橫三災不可推，家宅不安人口退，田蠶不利主人衰，嫁娶婚姻皆自損，金銀財谷漸無之，若是開門並放水，牛豬羊馬亦傷悲。"},
            {"女", "女星造作損婆娘，兄弟相嫌似虎狼，埋葬生災逢鬼怪，顛邪疾病主瘟惶，為事遭官財失散，瀉利留連不可當，開門放水用此日，全家財散主離鄉。"},
            {"虛", "虛星造作主災殃，男女孤眠不一雙，內亂風聲無禮節，兒孫媳婦伴人床，開門放水遭災禍，虎咬蛇傷又卒亡，三三五五連年病，家破人亡不可當。"},
            {"危", "危星不可造高樓，自遭刑吊見血光，三年孩子遭水厄，後生出外永不還，埋葬若還逢此日，周年百日取高堂，三年兩載一悲傷，開門放水到官堂。"},
            {"室", "室星修造進田牛，兒孫代代近王侯，家貴榮華天上至，壽如彭祖八千秋，開門放水招財帛，和合婚姻生貴兒，埋葬若能依此日，門庭興旺福無休。"},
            {"壁", "壁星造作主增財，絲蠶大熟福滔天，奴婢自來人口進，開門放水出英賢，埋葬招財官品進，家中諸事樂陶然，婚姻吉利主貴子，早播名譽著祖鞭。"},
            {"奎", "奎星造作得禎祥，家內榮和大吉昌，若是埋葬陰卒死，當年定主兩三傷，看看軍令刑傷到，重重官事主瘟惶，開門放水遭災禍，三年兩次損兒郎。"},
            {"婁", "婁星修造起門庭，財旺家和事事興，外進錢財百日進，一家兄弟播高名，婚姻進益生貴子，玉帛金銀箱滿盈，放水開門皆吉利，男榮女貴壽康寧。"},
            {"胃", "胃星造作事如何，家貴榮華喜氣多，埋葬貴臨官祿位，夫婦齊眉永保康，婚姻遇此家富貴，三災九禍不逢他，從此門前多吉慶，兒孫代代拜金階。"},
            {"昴", "昴星造作進田牛，埋葬官災不得休，重喪二日三人死，盡賣田園不記增，開門放水招災禍，三歲孩兒白了頭，婚姻不可逢此日，死別生離是可愁。"},
            {"畢", "畢星造作主光前，買得田園有餘錢，埋葬此日添官職，田蠶大熟永豐年，開門放水多吉慶，合家人口得安然，婚姻若得逢此日，生得孩兒福壽全。"},
            {"觜", "觜星造作有徒刑，三年必定主伶丁，埋葬卒死多因此，取定寅年使殺人，三喪不止皆由此，一人藥毒二人身，家門田地皆退敗，倉庫金銀化作塵。"},
            {"參", "參星造作旺人家，文星照耀大光華，只因造作田財旺，埋葬招疾哭黃沙，開門放水加官職，房房子孫見田加，婚姻許遁遭刑克，男女朝開幕落花。"},
            {"井", "井星造作旺蠶田，金榜題名第一光，埋葬須防驚卒死，狂顛風疾入黃泉，開門放水招財帛，牛馬豬羊旺莫言，貴人田塘來入宅，兒孫興旺有餘錢。"},
            {"鬼", "鬼星起造卒人亡，堂前不見主人郎，埋葬此日官祿至，兒孫代代近君王，開門放水須傷死，嫁娶夫妻不久長，修土築牆傷產女，手扶雙女淚汪汪。"},
            {"柳", "柳星造作主遭官，晝夜偷閉不暫安，埋葬瘟惶多疾病，田園退盡守冬寒，開門放水遭聾瞎，腰駝背曲似弓彎，更有棒刑宜謹慎，婦人隨客走盤桓。"},
            {"星", "星宿日好造新房，進職加官近帝王，不可埋葬並放水，凶星臨位女人亡，生離死別無心戀，要自歸休別嫁郎，孔子九曲殊難度，放水開門天命傷。"},
            {"張", "張星日好造龍軒，年年並見進莊田，埋葬不久升官職，代代為官近帝前，開門放水招財帛，婚姻和合福綿綿，田蠶人滿倉庫滿，百般順意自安然。"},
            {"翼", "翼星不利架高堂，三年二載見瘟惶，埋葬若還逢此日，子孫必定走他鄉，婚姻此日不宜利，歸家定是不相當，開門放水家須破，少女戀花貪外郎。"},
            {"軫", "軫星臨水造龍宮，代代為官受皇封，富貴榮華增壽祿，庫滿倉盈自昌隆，埋葬文昌來照助，宅舍安寧不見凶，更有為官沾帝寵，婚姻龍子入龍宮。"}
        };

        /// <summary>
        /// 獸
        /// </summary>
        public override Dictionary<string, string> SHOU { get; } = new Dictionary<string, string>
        {
            {"東", "青龍"},
            {"南", "朱雀"},
            {"西", "白虎"},
            {"北", "玄武"}
        };

        /// <summary>
        /// 煞
        /// </summary>
        public override Dictionary<string, string> SHA { get; } = new Dictionary<string, string>
        {
            {"子", "南"},
            {"丑", "東"},
            {"寅", "北"},
            {"卯", "西"},
            {"辰", "南"},
            {"巳", "東"},
            {"午", "北"},
            {"未", "西"},
            {"申", "南"},
            {"酉", "東"},
            {"戌", "北"},
            {"亥", "西"}
        };

        /// <summary>
        /// 方位描述
        /// </summary>
        public override Dictionary<string, string> POSITION_DESC { get; } = new Dictionary<string, string>
        {
            {"坎", "正北"},
            {"艮", "東北"},
            {"震", "正東"},
            {"巽", "東南"},
            {"離", "正南"},
            {"坤", "西南"},
            {"兌", "正西"},
            {"乾", "西北"},
            {"中", "中宮"}
        };

        /// <summary>
        /// 宮
        /// </summary>
        public override Dictionary<string, string> GONG { get; } = new Dictionary<string, string>
        {
            {"角", "東"},
            {"井", "南"},
            {"奎", "西"},
            {"斗", "北"},
            {"亢", "東"},
            {"鬼", "南"},
            {"婁", "西"},
            {"牛", "北"},
            {"氐", "東"},
            {"柳", "南"},
            {"胃", "西"},
            {"女", "北"},
            {"房", "東"},
            {"星", "南"},
            {"昴", "西"},
            {"虛", "北"},
            {"心", "東"},
            {"張", "南"},
            {"畢", "西"},
            {"危", "北"},
            {"尾", "東"},
            {"翼", "南"},
            {"觜", "西"},
            {"室", "北"},
            {"箕", "東"},
            {"軫", "南"},
            {"參", "西"},
            {"壁", "北"}
        };

        /// <summary>
        /// 政
        /// </summary>
        public override Dictionary<string, string> ZHENG { get; } = new Dictionary<string, string>
        {
            {"角", "木"}, {"井", "木"}, {"奎", "木"}, {"斗", "木"},
            {"亢", "金"}, {"鬼", "金"}, {"婁", "金"}, {"牛", "金"},
            {"氐", "土"}, {"柳", "土"}, {"胃", "土"}, {"女", "土"},
            {"房", "日"}, {"星", "日"}, {"昴", "日"}, {"虛", "日"},
            {"心", "月"}, {"張", "月"}, {"畢", "月"}, {"危", "月"},
            {"尾", "火"}, {"翼", "火"}, {"觜", "火"}, {"室", "火"},
            {"箕", "水"}, {"軫", "水"}, {"參", "水"}, {"壁", "水"}
        };

        /// <summary>
        /// 動物
        /// </summary>
        public override Dictionary<string, string> ANIMAL { get; } = new Dictionary<string, string>
        {
            {"角", "蛟"}, {"斗", "獬"}, {"奎", "狼"}, {"井", "犴"},
            {"亢", "龍"}, {"牛", "牛"}, {"婁", "狗"}, {"鬼", "羊"},
            {"女", "蝠"}, {"氐", "貉"}, {"胃", "彘"}, {"柳", "獐"},
            {"房", "兔"}, {"虛", "鼠"}, {"昴", "雞"}, {"星", "馬"},
            {"心", "狐"}, {"危", "燕"}, {"畢", "烏"}, {"張", "鹿"},
            {"尾", "虎"}, {"室", "豬"}, {"觜", "猴"}, {"翼", "蛇"},
            {"箕", "豹"}, {"壁", "獝"}, {"參", "猿"}, {"軫", "蚓"}
        };

        /// <summary>
        /// 天干五行
        /// </summary>
        public override Dictionary<string, string> WU_XING_GAN { get; } = new Dictionary<string, string>
        {
            {"甲", "木"}, {"乙", "木"}, {"丙", "火"}, {"丁", "火"}, {"戊", "土"},
            {"己", "土"}, {"庚", "金"}, {"辛", "金"}, {"壬", "水"}, {"癸", "水"}
        };

        /// <summary>
        /// 地支五行
        /// </summary>
        public override Dictionary<string, string> WU_XING_ZHI { get; } = new Dictionary<string, string>
        {
            {"寅", "木"}, {"卯", "木"}, {"巳", "火"}, {"午", "火"}, {"辰", "土"},
            {"丑", "土"}, {"戌", "土"}, {"未", "土"}, {"申", "金"}, {"酉", "金"},
            {"亥", "水"}, {"子", "水"}
        };

        /// <summary>
        /// 納音
        /// </summary>
        public override Dictionary<string, string> NAYIN { get; } = new Dictionary<string, string>
        {
            {"甲子", "海中金"}, {"甲午", "沙中金"}, {"丙寅", "爐中火"}, {"丙申", "山下火"},
            {"戊辰", "大林木"}, {"戊戌", "平地木"}, {"庚午", "路旁土"}, {"庚子", "壁上土"},
            {"壬申", "劍鋒金"}, {"壬寅", "金箔金"}, {"甲戌", "山頭火"}, {"甲辰", "覆燈火"},
            {"丙子", "澗下水"}, {"丙午", "天河水"}, {"戊寅", "城頭土"}, {"戊申", "大驛土"},
            {"庚辰", "白蠟金"}, {"庚戌", "釵釧金"}, {"壬午", "楊柳木"}, {"壬子", "桑柘木"},
            {"甲申", "泉中水"}, {"甲寅", "大溪水"}, {"丙戌", "屋上土"}, {"丙辰", "沙中土"},
            {"戊子", "霹靂火"}, {"戊午", "天上火"}, {"庚寅", "松柏木"}, {"庚申", "石榴木"},
            {"壬辰", "長流水"}, {"壬戌", "大海水"}, {"乙丑", "海中金"}, {"乙未", "沙中金"},
            {"丁卯", "爐中火"}, {"丁酉", "山下火"}, {"己巳", "大林木"}, {"己亥", "平地木"},
            {"辛未", "路旁土"}, {"辛丑", "壁上土"}, {"癸酉", "劍鋒金"}, {"癸卯", "金箔金"},
            {"乙亥", "山頭火"}, {"乙巳", "覆燈火"}, {"丁丑", "澗下水"}, {"丁未", "天河水"},
            {"己卯", "城頭土"}, {"己酉", "大驛土"}, {"辛巳", "白蠟金"}, {"辛亥", "釵釧金"},
            {"癸未", "楊柳木"}, {"癸丑", "桑柘木"}, {"乙酉", "泉中水"}, {"乙卯", "大溪水"},
            {"丁亥", "屋上土"}, {"丁巳", "沙中土"}, {"己丑", "霹靂火"}, {"己未", "天上火"},
            {"辛卯", "松柏木"}, {"辛酉", "石榴木"}, {"癸巳", "長流水"}, {"癸亥", "大海水"}
        };

        /// <summary>
        /// 十神，天干+天干為鍵
        /// </summary>
        public override Dictionary<string, string> SHI_SHEN { get; } = new Dictionary<string, string>
        {
            {"甲甲", "比肩"}, {"甲乙", "劫財"}, {"甲丙", "食神"}, {"甲丁", "傷官"}, {"甲戊", "偏財"},
            {"甲己", "正財"}, {"甲庚", "七殺"}, {"甲辛", "正官"}, {"甲壬", "偏印"}, {"甲癸", "正印"},
            {"乙乙", "比肩"}, {"乙甲", "劫財"}, {"乙丁", "食神"}, {"乙丙", "傷官"}, {"乙己", "偏財"},
            {"乙戊", "正財"}, {"乙辛", "七殺"}, {"乙庚", "正官"}, {"乙癸", "偏印"}, {"乙壬", "正印"},
            {"丙丙", "比肩"}, {"丙丁", "劫財"}, {"丙戊", "食神"}, {"丙己", "傷官"}, {"丙庚", "偏財"},
            {"丙辛", "正財"}, {"丙壬", "七殺"}, {"丙癸", "正官"}, {"丙甲", "偏印"}, {"丙乙", "正印"},
            {"丁丁", "比肩"}, {"丁丙", "劫財"}, {"丁己", "食神"}, {"丁戊", "傷官"}, {"丁辛", "偏財"},
            {"丁庚", "正財"}, {"丁癸", "七殺"}, {"丁壬", "正官"}, {"丁乙", "偏印"}, {"丁甲", "正印"},
            {"戊戊", "比肩"}, {"戊己", "劫財"}, {"戊庚", "食神"}, {"戊辛", "傷官"}, {"戊壬", "偏財"},
            {"戊癸", "正財"}, {"戊甲", "七殺"}, {"戊乙", "正官"}, {"戊丙", "偏印"}, {"戊丁", "正印"},
            {"己己", "比肩"}, {"己戊", "劫財"}, {"己辛", "食神"}, {"己庚", "傷官"}, {"己癸", "偏財"},
            {"己壬", "正財"}, {"己乙", "七殺"}, {"己甲", "正官"}, {"己丁", "偏印"}, {"己丙", "正印"},
            {"庚庚", "比肩"}, {"庚辛", "劫財"}, {"庚壬", "食神"}, {"庚癸", "傷官"}, {"庚甲", "偏財"},
            {"庚乙", "正財"}, {"庚丙", "七殺"}, {"庚丁", "正官"}, {"庚戊", "偏印"}, {"庚己", "正印"},
            {"辛辛", "比肩"}, {"辛庚", "劫財"}, {"辛癸", "食神"}, {"辛壬", "傷官"}, {"辛乙", "偏財"},
            {"辛甲", "正財"}, {"辛丁", "七殺"}, {"辛丙", "正官"}, {"辛己", "偏印"}, {"辛戊", "正印"},
            {"壬壬", "比肩"}, {"壬癸", "劫財"}, {"壬甲", "食神"}, {"壬乙", "傷官"}, {"壬丙", "偏財"},
            {"壬丁", "正財"}, {"壬戊", "七殺"}, {"壬己", "正官"}, {"壬庚", "偏印"}, {"壬辛", "正印"},
            {"癸癸", "比肩"}, {"癸壬", "劫財"}, {"癸乙", "食神"}, {"癸甲", "傷官"}, {"癸丁", "偏財"},
            {"癸丙", "正財"}, {"癸己", "七殺"}, {"癸戊", "正官"}, {"癸辛", "偏印"}, {"癸庚", "正印"}
        };



        /// <summary>
        /// 八會日
        /// </summary>
        public override Dictionary<string, string> BA_HUI { get; } = new Dictionary<string, string>
        {
            { "丙午", "天會" }, { "壬午", "地會" }, { "壬子", "人會" }, { "庚午", "日會" },
            { "庚申", "月會" }, { "辛酉", "星辰會" }, { "甲辰", "五行會" }, { "甲戌", "四時會" }
        };

        /// <summary>
        /// 八節日
        /// </summary>
        public override Dictionary<string, string> BA_JIE { get; } = new Dictionary<string, string>
        {
            {"立春", "東北方度仙上聖天尊同梵炁始青天君下降"},
            {"春分", "東方玉寶星上天尊同青帝九炁天君下降"},
            {"立夏", "東南方好生度命天尊同梵炁始丹天君下降"},
            {"夏至", "南方玄真萬福天尊同赤帝三炁天君下降"},
            {"立秋", "西南方太靈虛皇天尊同梵炁始素天君下降"},
            {"秋分", "西方太妙至極天尊同白帝七炁天君下降"},
            {"立冬", "西北方無量太華天尊同梵炁始玄天君下降"},
            {"冬至", "北方玄上玉宸天尊同黑帝五炁天君下降"}
        };

        /// <summary>
        /// 道曆節日數據
        /// </summary>
        public override Dictionary<string, string[]> TAO_FESTIVAL_DATA { get; } = new Dictionary<string, string[]>
        {
            ["1-1"] = new[] { "天臘之辰", "天臘，此日五帝會於東方九炁青天" },
            ["1-3"] = new[] { "郝真人聖誕", "孫真人聖誕" },
            ["1-5"] = new[] { "孫祖清靜元君誕" },
            ["1-7"] = new[] { "舉遷賞會", "此日上元賜福，天官同地水二官考校罪福" },
            ["1-9"] = new[] { "玉皇上帝聖誕" },
            ["1-13"] = new[] { "關聖帝君飛昇" },
            ["1-15"] = new[] { "上元天官聖誕", "老祖天師聖誕" },
            ["1-19"] = new[] { "長春邱真人 (邱處機) 聖誕" },
            ["1-28"] = new[] { "許真君 (許遜天師) 聖誕" },
            ["2-1"] = new[] { "勾陳天皇大帝聖誕", "長春劉真人 (劉淵然) 聖誕" },
            ["2-2"] = new[] { "土地正神誕", "姜太公聖誕" },
            ["2-3"] = new[] { "文昌梓潼帝君聖誕" },
            ["2-6"] = new[] { "東華帝君聖誕" },
            ["2-13"] = new[] { "度人無量葛真君聖誕" },
            ["2-15"] = new[] { "太清道德天尊 (太上老君) 聖誕" },
            ["2-19"] = new[] { "慈航真人聖誕" },
            ["3-1"] = new[] { "譚祖 (譚處端) 長真真人聖誕" },
            ["3-3"] = new[] { "玄天上帝聖誕" },
            ["3-6"] = new[] { "眼光娘娘聖誕" },
            ["3-15"] = new[] { "天師張大真人聖誕", "財神趙公元帥聖誕" },
            ["3-16"] = new[] { "三茅真君得道之辰", "中岳大帝聖誕" },
            ["3-18"] = new[] { "王祖 (王處一) 玉陽真人聖誕", "後土娘娘聖誕" },
            ["3-19"] = new[] { "太陽星君聖誕" },
            ["3-20"] = new[] { "子孫娘娘聖誕" },
            ["3-23"] = new[] { "天后媽祖聖誕" },
            ["3-26"] = new[] { "鬼谷先師誕" },
            ["3-28"] = new[] { "東岳大帝聖誕" },
            ["4-1"] = new[] { "長生譚真君成道之辰" },
            ["4-10"] = new[] { "何仙姑聖誕" },
            ["4-14"] = new[] { "呂祖純陽祖師聖誕" },
            ["4-15"] = new[] { "鍾離祖師聖誕" },
            ["4-18"] = new[] { "北極紫微大帝聖誕", "泰山聖母碧霞元君誕", "華佗神醫先師誕" },
            ["4-20"] = new[] { "眼光聖母娘娘誕" },
            ["4-28"] = new[] { "神農先帝誕" },
            ["5-1"] = new[] { "南極長生大帝聖誕" },
            ["5-5"] = new[] { "地臘之辰", "地臘，此日五帝會於南方三炁丹天", "南方雷祖聖誕", "地祗溫元帥聖誕", "雷霆鄧天君聖誕" },
            ["5-11"] = new[] { "城隍爺聖誕" },
            ["5-13"] = new[] { "關聖帝君降神", "關平太子聖誕" },
            ["5-18"] = new[] { "張天師聖誕" },
            ["5-20"] = new[] { "馬祖丹陽真人聖誕" },
            ["5-29"] = new[] { "紫青白祖師聖誕" },
            ["6-1"] = new[] { "南斗星君下降" },
            ["6-2"] = new[] { "南斗星君下降" },
            ["6-3"] = new[] { "南斗星君下降" },
            ["6-4"] = new[] { "南斗星君下降" },
            ["6-5"] = new[] { "南斗星君下降" },
            ["6-6"] = new[] { "南斗星君下降" },
            ["6-10"] = new[] { "劉海蟾祖師聖誕" },
            ["6-15"] = new[] { "靈官王天君聖誕" },
            ["6-19"] = new[] { "慈航 (觀音) 成道日" },
            ["6-23"] = new[] { "火神聖誕" },
            ["6-24"] = new[] { "南極大帝中方雷祖聖誕", "關聖帝君聖誕" },
            ["6-26"] = new[] { "二郎真君聖誕" },
            ["7-7"] = new[] { "道德臘之辰", "道德臘，此日五帝會於西方七炁素天", "慶生中會", "此日中元赦罪，地官同天水二官考校罪福" },
            ["7-12"] = new[] { "西方雷祖聖誕" },
            ["7-15"] = new[] { "中元地官大帝聖誕" },
            ["7-18"] = new[] { "王母娘娘聖誕" },
            ["7-20"] = new[] { "劉祖 (劉處玄) 長生真人聖誕" },
            ["7-22"] = new[] { "財帛星君文財神增福相公李詭祖聖誕" },
            ["7-26"] = new[] { "張三豐祖師聖誕" },
            ["8-1"] = new[] { "許真君飛昇日" },
            ["8-3"] = new[] { "九天司命灶君誕" },
            ["8-5"] = new[] { "北方雷祖聖誕" },
            ["8-10"] = new[] { "北岳大帝誕辰" },
            ["8-15"] = new[] { "太陰星君誕" },
            ["9-1"] = new[] { "北斗九皇降世之辰" },
            ["9-2"] = new[] { "北斗九皇降世之辰" },
            ["9-3"] = new[] { "北斗九皇降世之辰" },
            ["9-4"] = new[] { "北斗九皇降世之辰" },
            ["9-5"] = new[] { "北斗九皇降世之辰" },
            ["9-6"] = new[] { "北斗九皇降世之辰" },
            ["9-7"] = new[] { "北斗九皇降世之辰" },
            ["9-8"] = new[] { "北斗九皇降世之辰" },
            ["9-9"] = new[] { "北斗九皇降世之辰", "斗姥元君聖誕", "重陽帝君聖誕", "玄天上帝飛昇", "酆都大帝聖誕" },
            ["9-22"] = new[] { "增福財神誕" },
            ["9-23"] = new[] { "薩翁真君聖誕" },
            ["9-28"] = new[] { "五顯靈官馬元帥聖誕" },
            ["10-1"] = new[] { "民歲臘之辰", "民歲臘，此日五帝會於北方五炁黑天", "東皇大帝聖誕" },
            ["10-3"] = new[] { "三茅應化真君聖誕" },
            ["10-6"] = new[] { "天曹諸司五岳五帝聖誕" },
            ["10-15"] = new[] { "下元水官大帝聖誕", "建生大會", "此日下元解厄，水官同天地二官考校罪福" },
            ["10-18"] = new[] { "地母娘娘聖誕" },
            ["10-19"] = new[] { "長春邱真君飛昇" },
            ["10-20"] = new[] { "虛靖天師 (即三十代天師弘悟張真人) 誕" },
            ["11-6"] = new[] { "西岳大帝聖誕" },
            ["11-9"] = new[] { "湘子韓祖聖誕" },
            ["11-11"] = new[] { "太乙救苦天尊聖誕" },
            ["11-26"] = new[] { "北方五道聖誕" },
            ["12-8"] = new[] { "王侯臘之辰", "王侯臘，此日五帝會於上方玄都玉京" },
            ["12-16"] = new[] { "南岳大帝聖誕", "福德正神誕" },
            ["12-20"] = new[] { "魯班先師聖誕" },
            ["12-21"] = new[] { "天猷上帝聖誕" },
            ["12-22"] = new[] { "重陽祖師聖誕" },
            ["12-23"] = new[] { "祭灶王", "最適宜謝舊年太歲，開啟拜新年太歲" },
            ["12-25"] = new[] { "玉帝巡天", "天神下降" },
            ["12-29"] = new[] { "清靜孫真君 (孫不二) 成道" }
        };

        /// <summary>
        /// 星座
        /// </summary>
        public override string[] XING_ZUO { get; } = { "牡羊", "金牛", "雙子", "巨蟹", "獅子", "處女", "天秤", "天蠍", "射手", "摩羯", "水瓶", "雙魚" };

        /// <summary>
        /// 陽曆節日
        /// </summary>
        public override Dictionary<string, string> SOLAR_FESTIVAL { get; } = new Dictionary<string, string>
        {
            { "1-1", "元旦" }, { "2-14", "情人節" }, { "3-8", "婦女節" }, { "3-12", "植樹節" },
            { "3-15", "消費者權益日" }, { "4-1", "愚人節" }, { "5-1", "勞動節" }, { "5-4", "青年節" },
            { "6-1", "兒童節" }, { "7-1", "建黨節" }, { "8-1", "建軍節" }, { "9-10", "教師節" },
            { "10-1", "國慶節" }, { "10-31", "萬聖節前夕" }, { "11-1", "萬聖節" },
            { "12-24", "平安夜" }, { "12-25", "聖誕節" }
        };

        /// <summary>
        /// 陽曆按星期的節日
        /// </summary>
        public override Dictionary<string, string> SOLAR_WEEK_FESTIVAL { get; } = new Dictionary<string, string>
        {
            { "5-2-0", "母親節" }, { "11-4-4", "感恩節" }
        };

        /// <summary>
        /// 陽曆非正式節日
        /// </summary>
        public override Dictionary<string, List<string>> SOLAR_OTHER_FESTIVAL { get; } = new Dictionary<string, List<string>>
        {           
        };

        private const string DJ = "犯者奪紀";
        private const string JS = "犯者減壽";
        private const string SS = "犯者損壽";
        private const string XL = "犯者削祿奪紀";
        private const string JW = "犯者三年內夫婦俱亡";

        private static FotoFestival Y = new FotoFestival("楊公忌");
        private static FotoFestival T = new FotoFestival("四天王巡行", "", true);
        private static FotoFestival D = new FotoFestival("斗降", DJ, true);
        private static FotoFestival S = new FotoFestival("月朔", DJ, true);
        private static FotoFestival W = new FotoFestival("月望", DJ, true);
        private static FotoFestival H = new FotoFestival("月晦", JS, true);
        private static FotoFestival L = new FotoFestival("雷齋日", JS, true);
        private static FotoFestival J = new FotoFestival("九毒日", "犯者夭亡，奇禍不測");
        private static FotoFestival R = new FotoFestival("人神在陰", "犯者得病", true, "宜先一日即戒");
        private static FotoFestival M = new FotoFestival("司命奏事", JS, true, "如月小，即戒廿九");
        private static FotoFestival HH = new FotoFestival("月晦", JS, true, "如月小，即戒廿九");

        /// <summary>
        /// 因果犯忌
        /// </summary>
        public override Dictionary<string, List<FotoFestival>> FOTO_FESTIVAL { get; } = new Dictionary<string, List<FotoFestival>>
        {
            {"1-1", new List<FotoFestival>(new[] { new FotoFestival("天臘，玉帝校世人神氣祿命", XL), S })},
            {"1-3", new List<FotoFestival>(new[] { new FotoFestival("萬神都會", DJ), D })},
            {"1-5", new List<FotoFestival>(new[] { new FotoFestival("五虛忌") })},
            {"1-6", new List<FotoFestival>(new[] { new FotoFestival("六耗忌"), L })},
            {"1-7", new List<FotoFestival>(new[] { new FotoFestival("上會日", SS) })},
            {"1-8", new List<FotoFestival>(new[] { new FotoFestival("五殿閻羅天子誕", DJ), T })},
            {"1-9", new List<FotoFestival>(new[] { new FotoFestival("玉皇上帝誕", DJ) })},
            {"1-13", new List<FotoFestival>(new[] { Y })},
            {"1-14", new List<FotoFestival>(new[] { new FotoFestival("三元降", JS), T })},
            {"1-15", new List<FotoFestival>(new[] { new FotoFestival("三元降", JS), new FotoFestival("上元神會", DJ), W, T })},
            {"1-16", new List<FotoFestival>(new[] { new FotoFestival("三元降", JS) })},
            {"1-19", new List<FotoFestival>(new[] { new FotoFestival("長春真人誕") })},
            {"1-23", new List<FotoFestival>(new[] { new FotoFestival("三屍神奏事"), T })},
            {"1-25", new List<FotoFestival>(new[] { H, new FotoFestival("天地倉開日", "犯者損壽，子帶疾") })},
            {"1-27", new List<FotoFestival>(new[] { D })},
            {"1-28", new List<FotoFestival>(new[] { R })},
            {"1-29", new List<FotoFestival>(new[] { T })},
            {"1-30", new List<FotoFestival>(new[] { HH, M, T })},
            {"2-1", new List<FotoFestival>(new[] { new FotoFestival("一殿秦廣王誕", DJ), S })},
            {"2-2", new List<FotoFestival>(new[] { new FotoFestival("萬神都會", DJ), new FotoFestival("福德土地正神誕", "犯者得禍") })},
            {"2-3", new List<FotoFestival>(new[] { new FotoFestival("文昌帝君誕", XL), D })},
            {"2-6", new List<FotoFestival>(new[] { new FotoFestival("東華帝君誕"), L })},
            {"2-8", new List<FotoFestival>(new[] { new FotoFestival("釋迦牟尼佛出家", DJ), new FotoFestival("三殿宋帝王誕", DJ), new FotoFestival("張大帝誕", DJ), T })},
            {"2-11", new List<FotoFestival>(new[] { Y })},
            {"2-14", new List<FotoFestival>(new[] { T })},
            {"2-15", new List<FotoFestival>(new[] { new FotoFestival("釋迦牟尼佛涅槃", XL), new FotoFestival("太上老君誕", XL), new FotoFestival("月望", XL, true), T })},
            {"2-17", new List<FotoFestival>(new[] { new FotoFestival("東方杜將軍誕") })},
            {"2-18", new List<FotoFestival>(new[] { new FotoFestival("四殿五官王誕", XL), new FotoFestival("至聖先師孔子諱辰", XL) })},
            {"2-19", new List<FotoFestival>(new[] { new FotoFestival("觀音大士誕", DJ) })},
            {"2-21", new List<FotoFestival>(new[] { new FotoFestival("普賢菩薩誕") })},
            {"2-23", new List<FotoFestival>(new[] { T })},
            {"2-25", new List<FotoFestival>(new[] { H })},
            {"2-27", new List<FotoFestival>(new[] { D })},
            {"2-28", new List<FotoFestival>(new[] { R })},
            {"2-29", new List<FotoFestival>(new[] { T })},
            {"2-30", new List<FotoFestival>(new[] { HH, M, T })},
            {"3-1", new List<FotoFestival>(new[] { new FotoFestival("二殿楚江王誕", DJ), S })},
            {"3-3", new List<FotoFestival>(new[] { new FotoFestival("玄天上帝誕", DJ), D })},
            {"3-6", new List<FotoFestival>(new[] { L })},
            {"3-8", new List<FotoFestival>(new[] { new FotoFestival("六殿卞城王誕", DJ), T })},
            {"3-9", new List<FotoFestival>(new[] { new FotoFestival("牛鬼神出", "犯者產惡胎"), Y })},
            {"3-12", new List<FotoFestival>(new[] { new FotoFestival("中央五道誕") })},
            {"3-14", new List<FotoFestival>(new[] { T })},
            {"3-15", new List<FotoFestival>(new[] { new FotoFestival("昊天上帝誕", DJ), new FotoFestival("玄壇誕", DJ), W, T })},
            {"3-16", new List<FotoFestival>(new[] { new FotoFestival("準提菩薩誕", DJ) })},
            {"3-19", new List<FotoFestival>(new[] { new FotoFestival("中岳大帝誕"), new FotoFestival("後土娘娘誕"), new FotoFestival("三茅降") })},
            {"3-20", new List<FotoFestival>(new[] { new FotoFestival("天地倉開日", SS), new FotoFestival("子孫娘娘誕") })},
            {"3-23", new List<FotoFestival>(new[] { T })},
            {"3-25", new List<FotoFestival>(new[] { H })},
            {"3-27", new List<FotoFestival>(new[] { new FotoFestival("七殿泰山王誕"), D })},
            {"3-28", new List<FotoFestival>(new[] { R, new FotoFestival("蒼頡至聖先師誕", XL), new FotoFestival("東岳大帝誕") })},
            {"3-29", new List<FotoFestival>(new[] { T })},
            {"3-30", new List<FotoFestival>(new[] { HH, M, T })},
            {"4-1", new List<FotoFestival>(new[] { new FotoFestival("八殿都市王誕", DJ), S })},
            {"4-3", new List<FotoFestival>(new[] { D })},
            {"4-4", new List<FotoFestival>(new[] { new FotoFestival("萬神善會", "犯者失瘼夭胎"), new FotoFestival("文殊菩薩誕") })},
            {"4-6", new List<FotoFestival>(new[] { L })},
            {"4-7", new List<FotoFestival>(new[] { new FotoFestival("南斗、北斗、西斗同降", JS), Y })},
            {"4-8", new List<FotoFestival>(new[] { new FotoFestival("釋迦牟尼佛誕", DJ), new FotoFestival("萬神善會", "犯者失瘼夭胎"), new FotoFestival("善惡童子降", "犯者血死"), new FotoFestival("九殿平等王誕"), T })},
            {"4-14", new List<FotoFestival>(new[] { new FotoFestival("純陽祖師誕", JS), T })},
            {"4-15", new List<FotoFestival>(new[] { W, new FotoFestival("鍾離祖師誕"), T })},
            {"4-16", new List<FotoFestival>(new[] { new FotoFestival("天地倉開日", SS) })},
            {"4-17", new List<FotoFestival>(new[] { new FotoFestival("十殿轉輪王誕", DJ) })},
            {"4-18", new List<FotoFestival>(new[] { new FotoFestival("天地倉開日", SS), new FotoFestival("紫徽大帝誕", SS) })},
            {"4-20", new List<FotoFestival>(new[] { new FotoFestival("眼光聖母誕") })},
            {"4-23", new List<FotoFestival>(new[] { T })},
            {"4-25", new List<FotoFestival>(new[] { H })},
            {"4-27", new List<FotoFestival>(new[] { D })},
            {"4-28", new List<FotoFestival>(new[] { R })},
            {"4-29", new List<FotoFestival>(new[] { T })},
            {"4-30", new List<FotoFestival>(new[] { HH, M, T })},
            {"5-1", new List<FotoFestival>(new[] { new FotoFestival("南極長生大帝誕", DJ), S })},
            {"5-3", new List<FotoFestival>(new[] { D })},
            {"5-5", new List<FotoFestival>(new[] { new FotoFestival("地臘", XL), new FotoFestival("五帝校定生人官爵", XL), J, Y })},
            {"5-6", new List<FotoFestival>(new[] { J, L })},
            {"5-7", new List<FotoFestival>(new[] { J })},
            {"5-8", new List<FotoFestival>(new[] { new FotoFestival("南方五道誕"), T })},
            {"5-11", new List<FotoFestival>(new[] { new FotoFestival("天地倉開日", SS), new FotoFestival("天下都城隍誕") })},
            {"5-12", new List<FotoFestival>(new[] { new FotoFestival("炳靈公誕") })},
            {"5-13", new List<FotoFestival>(new[] { new FotoFestival("關聖降", XL) })},
            {"5-14", new List<FotoFestival>(new[] { new FotoFestival("夜子時為天地交泰", JW), T })},
            {"5-15", new List<FotoFestival>(new[] { W, J, T })},
            {"5-16", new List<FotoFestival>(new[] { new FotoFestival("九毒日", JW), new FotoFestival("天地元氣造化萬物之辰", JW) })},
            {"5-17", new List<FotoFestival>(new[] { J })},
            {"5-18", new List<FotoFestival>(new[] { new FotoFestival("張天師誕") })},
            {"5-22", new List<FotoFestival>(new[] { new FotoFestival("孝娥神誕", DJ) })},
            {"5-23", new List<FotoFestival>(new[] { T })},
            {"5-25", new List<FotoFestival>(new[] { J, H })},
            {"5-26", new List<FotoFestival>(new[] { J })},
            {"5-27", new List<FotoFestival>(new[] { J, D })},
            {"5-28", new List<FotoFestival>(new[] { R })},
            {"5-29", new List<FotoFestival>(new[] { T })},
            {"5-30", new List<FotoFestival>(new[] { HH, M, T })},
            {"6-1", new List<FotoFestival>(new[] { S })},
            {"6-3", new List<FotoFestival>(new[] { new FotoFestival("韋馱菩薩聖誕"), D, Y })},
            {"6-5", new List<FotoFestival>(new[] { new FotoFestival("南贍部洲轉大輪", SS) })},
            {"6-6", new List<FotoFestival>(new[] { new FotoFestival("天地倉開日", SS), L })},
            {"6-8", new List<FotoFestival>(new[] { T })},
            {"6-10", new List<FotoFestival>(new[] { new FotoFestival("金粟如來誕") })},
            {"6-14", new List<FotoFestival>(new[] { T })},
            {"6-15", new List<FotoFestival>(new[] { W, T })},
            {"6-19", new List<FotoFestival>(new[] { new FotoFestival("觀世音菩薩成道", DJ) })},
            {"6-23", new List<FotoFestival>(new[] { new FotoFestival("南方火神誕", "犯者遭回祿"), T })},
            {"6-24", new List<FotoFestival>(new[] { new FotoFestival("雷祖誕", XL), new FotoFestival("關帝誕", XL) })},
            {"6-25", new List<FotoFestival>(new[] { H })},
            {"6-27", new List<FotoFestival>(new[] { D })},
            {"6-28", new List<FotoFestival>(new[] { R })},
            {"6-29", new List<FotoFestival>(new[] { T })},
            {"6-30", new List<FotoFestival>(new[] { HH, M, T })},
            {"7-1", new List<FotoFestival>(new[] { S, Y })},
            {"7-3", new List<FotoFestival>(new[] { D })},
            {"7-5", new List<FotoFestival>(new[] { new FotoFestival("中會日", SS, false, "一作初七") })},
            {"7-6", new List<FotoFestival>(new[] { L })},
            {"7-7", new List<FotoFestival>(new[] { new FotoFestival("道德臘", XL), new FotoFestival("五帝校生人善惡", XL), new FotoFestival("魁星誕", XL) })},
            {"7-8", new List<FotoFestival>(new[] { T })},
            {"7-10", new List<FotoFestival>(new[] { new FotoFestival("陰毒日", "", false, "大忌") })},
            {"7-12", new List<FotoFestival>(new[] { new FotoFestival("長真譚真人誕") })},
            {"7-13", new List<FotoFestival>(new[] { new FotoFestival("大勢至菩薩誕", JS) })},
            {"7-14", new List<FotoFestival>(new[] { new FotoFestival("三元降", JS), T })},
            {"7-15", new List<FotoFestival>(new[] { W, new FotoFestival("三元降", DJ), new FotoFestival("地官校籍", DJ), T })},
            {"7-16", new List<FotoFestival>(new[] { new FotoFestival("三元降", JS) })},
            {"7-18", new List<FotoFestival>(new[] { new FotoFestival("西王母誕", DJ) })},
            {"7-19", new List<FotoFestival>(new[] { new FotoFestival("太歲誕", DJ) })},
            {"7-22", new List<FotoFestival>(new[] { new FotoFestival("增福財神誕", XL) })},
            {"7-23", new List<FotoFestival>(new[] { T })},
            {"7-25", new List<FotoFestival>(new[] { H })},
            {"7-27", new List<FotoFestival>(new[] { D })},
            {"7-28", new List<FotoFestival>(new[] { R })},
            {"7-29", new List<FotoFestival>(new[] { Y, T })},
            {"7-30", new List<FotoFestival>(new[] { new FotoFestival("地藏菩薩誕", DJ), HH, M, T })},
            {"8-1", new List<FotoFestival>(new[] { S, new FotoFestival("許真君誕") })},
            {"8-3", new List<FotoFestival>(new[] { D, new FotoFestival("北斗誕", XL), new FotoFestival("司命灶君誕", "犯者遭回祿") })},
            {"8-5", new List<FotoFestival>(new[] { new FotoFestival("雷聲大帝誕", DJ) })},
            {"8-6", new List<FotoFestival>(new[] { L })},
            {"8-8", new List<FotoFestival>(new[] { T })},
            {"8-10", new List<FotoFestival>(new[] { new FotoFestival("北斗大帝誕") })},
            {"8-12", new List<FotoFestival>(new[] { new FotoFestival("西方五道誕") })},
            {"8-14", new List<FotoFestival>(new[] { T })},
            {"8-15", new List<FotoFestival>(new[] { W, new FotoFestival("太明朝元", "犯者暴亡", false, "宜焚香守夜"), T })},
            {"8-16", new List<FotoFestival>(new[] { new FotoFestival("天曹掠刷真君降", "犯者貧夭") })},
            {"8-18", new List<FotoFestival>(new[] { new FotoFestival("天人興福之辰", "", false, "宜齋戒，存想吉事") })},
            {"8-23", new List<FotoFestival>(new[] { new FotoFestival("漢恒候張顯王誕"), T })},
            {"8-24", new List<FotoFestival>(new[] { new FotoFestival("灶君夫人誕") })},
            {"8-25", new List<FotoFestival>(new[] { H })},
            {"8-27", new List<FotoFestival>(new[] { D, new FotoFestival("至聖先師孔子誕", XL), Y })},
            {"8-28", new List<FotoFestival>(new[] { R, new FotoFestival("四天會事") })},
            {"8-29", new List<FotoFestival>(new[] { T })},
            {"8-30", new List<FotoFestival>(new[] { new FotoFestival("諸神考校", "犯者奪算"), HH, M, T })},
            {"9-1", new List<FotoFestival>(new[] { S, new FotoFestival("南斗誕", XL), new FotoFestival("北斗九星降世", DJ, false, "此九日俱宜齋戒") })},
            {"9-3", new List<FotoFestival>(new[] { D, new FotoFestival("五瘟神誕") })},
            {"9-6", new List<FotoFestival>(new[] { L })},
            {"9-8", new List<FotoFestival>(new[] { T })},
            {"9-9", new List<FotoFestival>(new[] { new FotoFestival("斗母誕", XL), new FotoFestival("酆都大帝誕"), new FotoFestival("玄天上帝飛昇") })},
            {"9-10", new List<FotoFestival>(new[] { new FotoFestival("斗母降", DJ) })},
            {"9-11", new List<FotoFestival>(new[] { new FotoFestival("宜戒") })},
            {"9-13", new List<FotoFestival>(new[] { new FotoFestival("孟婆尊神誕") })},
            {"9-14", new List<FotoFestival>(new[] { T })},
            {"9-15", new List<FotoFestival>(new[] { W, T })},
            {"9-17", new List<FotoFestival>(new[] { new FotoFestival("金龍四大王誕", "犯者遭水厄") })},
            {"9-19", new List<FotoFestival>(new[] { new FotoFestival("日宮月宮會合", JS), new FotoFestival("觀世音菩薩誕", JS) })},
            {"9-23", new List<FotoFestival>(new[] { T })},
            {"9-25", new List<FotoFestival>(new[] { H, Y })},
            {"9-27", new List<FotoFestival>(new[] { D })},
            {"9-28", new List<FotoFestival>(new[] { R })},
            {"9-29", new List<FotoFestival>(new[] { T })},
            {"9-30", new List<FotoFestival>(new[] { new FotoFestival("藥師琉璃光佛誕", "犯者危疾"), HH, M, T })},
            {"10-1", new List<FotoFestival>(new[] { S, new FotoFestival("民歲臘", DJ), new FotoFestival("四天王降", "犯者一年內死") })},
            {"10-3", new List<FotoFestival>(new[] { D, new FotoFestival("三茅誕") })},
            {"10-5", new List<FotoFestival>(new[] { new FotoFestival("下會日", JS), new FotoFestival("達摩祖師誕", JS) })},
            {"10-6", new List<FotoFestival>(new[] { L, new FotoFestival("天曹考察", DJ) })},
            {"10-8", new List<FotoFestival>(new[] { new FotoFestival("佛涅槃日", "", false, "大忌色慾"), T })},
            {"10-10", new List<FotoFestival>(new[] { new FotoFestival("四天王降", "犯者一年內死") })},
            {"10-11", new List<FotoFestival>(new[] { new FotoFestival("宜戒") })},
            {"10-14", new List<FotoFestival>(new[] { new FotoFestival("三元降", JS), T })},
            {"10-15", new List<FotoFestival>(new[] { W, new FotoFestival("三元降", DJ), new FotoFestival("下元水府校籍", DJ), T })},
            {"10-16", new List<FotoFestival>(new[] { new FotoFestival("三元降", JS), T })},
            {"10-23", new List<FotoFestival>(new[] { Y, T })},
            {"10-25", new List<FotoFestival>(new[] { H })},
            {"10-27", new List<FotoFestival>(new[] { D, new FotoFestival("北極紫徽大帝降") })},
            {"10-28", new List<FotoFestival>(new[] { R })},
            {"10-29", new List<FotoFestival>(new[] { T })},
            {"10-30", new List<FotoFestival>(new[] { HH, M, T })},
            {"11-1", new List<FotoFestival>(new[] { S })},
            {"11-3", new List<FotoFestival>(new[] { D })},
            {"11-4", new List<FotoFestival>(new[] { new FotoFestival("至聖先師孔子誕", XL) })},
            {"11-6", new List<FotoFestival>(new[] { new FotoFestival("西岳大帝誕") })},
            {"11-8", new List<FotoFestival>(new[] { T })},
            {"11-11", new List<FotoFestival>(new[] { new FotoFestival("天地倉開日", DJ), new FotoFestival("太乙救苦天尊誕", DJ) })},
            {"11-14", new List<FotoFestival>(new[] { T })},
            {"11-15", new List<FotoFestival>(new[] { new FotoFestival("月望", "上半夜犯男死 下半夜犯女死"), new FotoFestival("四天王巡行", "上半夜犯男死 下半夜犯女死") })},
            {"11-17", new List<FotoFestival>(new[] { new FotoFestival("阿彌陀佛誕") })},
            {"11-19", new List<FotoFestival>(new[] { new FotoFestival("太陽日宮誕", "犯者得奇禍") })},
            {"11-21", new List<FotoFestival>(new[] { Y })},
            {"11-23", new List<FotoFestival>(new[] { new FotoFestival("張仙誕", "犯者絕嗣"), T })},
            {"11-25", new List<FotoFestival>(new[] { new FotoFestival("掠刷大夫降", "犯者遭大凶"), H })},
            {"11-26", new List<FotoFestival>(new[] { new FotoFestival("北方五道誕") })},
            {"11-27", new List<FotoFestival>(new[] { D })},
            {"11-28", new List<FotoFestival>(new[] { R })},
            {"11-29", new List<FotoFestival>(new[] { T })},
            {"11-30", new List<FotoFestival>(new[] { HH, M, T })},
            {"12-1", new List<FotoFestival>(new[] { S })},
            {"12-3", new List<FotoFestival>(new[] { D })},
            {"12-6", new List<FotoFestival>(new[] { new FotoFestival("天地倉開日", JS), L })},
            {"12-7", new List<FotoFestival>(new[] { new FotoFestival("掠刷大夫降", "犯者得惡疾") })},
            {"12-8", new List<FotoFestival>(new[] { new FotoFestival("王侯臘", DJ), new FotoFestival("釋迦如來成佛之辰"), T, new FotoFestival("初旬內戊日，亦名王侯臘", DJ) })},
            {"12-12", new List<FotoFestival>(new[] { new FotoFestival("太素三元君朝真") })},
            {"12-14", new List<FotoFestival>(new[] { T })},
            {"12-15", new List<FotoFestival>(new[] { W, T })},
            {"12-16", new List<FotoFestival>(new[] { new FotoFestival("南岳大帝誕") })},
            {"12-19", new List<FotoFestival>(new[] { Y })},
            {"12-20", new List<FotoFestival>(new[] { new FotoFestival("天地交道", "犯者促壽") })},
            {"12-21", new List<FotoFestival>(new[] { new FotoFestival("天猷上帝誕") })},
            {"12-23", new List<FotoFestival>(new[] { new FotoFestival("五岳誕降"), T })},
            {"12-24", new List<FotoFestival>(new[] { new FotoFestival("司今朝天奏人善惡", "犯者得大禍") })},
            {"12-25", new List<FotoFestival>(new[] { new FotoFestival("三清玉帝同降，考察善惡", "犯者得奇禍"), H })},
            {"12-27", new List<FotoFestival>(new[] { D })},
            {"12-28", new List<FotoFestival>(new[] { R })},
            {"12-29", new List<FotoFestival>(new[] { new FotoFestival("華嚴菩薩誕"), T })},
            {"12-30", new List<FotoFestival>(new[] { new FotoFestival("諸神下降，查訪善惡", "犯者男女俱亡") })}
        };

        /// <summary>
        /// 紀念日
        /// </summary>
        public override Dictionary<string, List<string>> FOTO_OTHER_FESTIVAL { get; } = new Dictionary<string, List<string>>
        {
            {"1-1", new List<string>(new[] { "彌勒菩薩聖誕" })},
            {"1-6", new List<string>(new[] { "定光佛聖誕" })},
            {"2-8", new List<string>(new[] { "釋迦牟尼佛出家" })},
            {"2-15", new List<string>(new[] { "釋迦牟尼佛涅槃" })},
            {"2-19", new List<string>(new[] { "觀世音菩薩聖誕" })},
            {"2-21", new List<string>(new[] { "普賢菩薩聖誕" })},
            {"3-16", new List<string>(new[] { "準提菩薩聖誕" })},
            {"4-4", new List<string>(new[] { "文殊菩薩聖誕" })},
            {"4-8", new List<string>(new[] { "釋迦牟尼佛聖誕" })},
            {"4-15", new List<string>(new[] { "佛吉祥日" })},
            {"4-28", new List<string>(new[] { "藥王菩薩聖誕" })},
            {"5-13", new List<string>(new[] { "伽藍菩薩聖誕" })},
            {"6-3", new List<string>(new[] { "韋馱菩薩聖誕" })},
            {"6-19", new List<string>(new[] { "觀音菩薩成道" })},
            {"7-13", new List<string>(new[] { "大勢至菩薩聖誕" })},
            {"7-15", new List<string>(new[] { "佛歡喜日" })},
            {"7-24", new List<string>(new[] { "龍樹菩薩聖誕" })},
            {"7-30", new List<string>(new[] { "地藏菩薩聖誕" })},
            {"8-15", new List<string>(new[] { "月光菩薩聖誕" })},
            {"8-22", new List<string>(new[] { "燃燈佛聖誕" })},
            {"9-9", new List<string>(new[] { "摩利支天菩薩聖誕" })},
            {"9-19", new List<string>(new[] { "觀世音菩薩出家" })},
            {"9-30", new List<string>(new[] { "藥師琉璃光佛聖誕" })},
            {"10-5", new List<string>(new[] { "達摩祖師聖誕" })},
            {"10-20", new List<string>(new[] { "文殊菩薩出家" })},
            {"11-17", new List<string>(new[] { "阿彌陀佛聖誕" })},
            {"11-19", new List<string>(new[] { "日光菩薩聖誕" })},
            {"12-8", new List<string>(new[] { "釋迦牟尼佛成道" })},
            {"12-23", new List<string>(new[] { "監齋菩薩聖誕" })},
            {"12-29", new List<string>(new[] { "華嚴菩薩聖誕" })}
        };

        /// <summary>
        /// 27 星宿，佛教從印度傳入中國，印度把 28 星宿改為 27 星宿，把牛宿 (牛金牛) 納入了女宿 (女土蝠)。
        /// </summary>
        public override string[] XIU_27 { get; } = { "角", "亢", "氐", "房", "心", "尾", "箕", "斗", "女", "虛", "危", "室", "壁", "奎", "婁", "胃", "昴", "畢", "觜", "參", "井", "鬼", "柳", "星", "張", "翼", "軫" };

        /// <summary>
        /// Lunar.FullString 主段格式，{0}=日期，{1}=年干支，{2}=年生肖，{3}=月干支，{4}=月生肖，{5}=日干支，{6}=日生肖，{7}=時支，{8}=時生肖，{9}=年納音，{10}=月納音，{11}=日納音，{12}=時納音，{13}=星期
        /// </summary>
        public override string FullStringTemplate1 { get; } = "{0} {1}({2})年 {3}({4})月 {5}({6})日 {7}({8})時 納音[{9} {10} {11} {12}] 星期{13}";

        /// <summary>
        /// Lunar.FullString 尾段格式，{0}=宮，{1}=獸，{2}=宿，{3}=政，{4}=動物，{5}=宿吉凶，{6}=彭祖干，{7}=彭祖支，{8}=喜神，{9}=喜神描述，{10}=陽貴，{11}=陽貴描述，{12}=陰貴，{13}=陰貴描述，{14}=福神，{15}=福神描述，{16}=財神，{17}=財神描述，{18}=沖，{19}=煞
        /// </summary>
        public override string FullStringTemplate2 { get; } = " {0}方{1} 星宿[{2}{3}{4}]({5}) 彭祖百忌[{6} {7}] 喜神方位[{8}]({9}) 陽貴神方位[{10}]({11}) 陰貴神方位[{12}]({13}) 福神方位[{14}]({15}) 財神方位[{16}]({17}) 沖[{18}] 煞[{19}]";
        /// <summary>
        /// "閏年"
        /// </summary>
        public override string LeapYear { get; } = "閏年";

    }
}