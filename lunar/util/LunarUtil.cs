using System;
using System.Collections.Generic;
using System.Text;

namespace com.nlf.calendar.util
{
    /// <summary>
    /// 农历工具，基准日期为1900年十一月十一，对应阳历1901年1月1日，最远仅支持到2099年
    /// </summary>
    public class LunarUtil
    {
        /// <summary>
        /// 农历基准年
        /// </summary>
        public const int BASE_YEAR = 1900;

        /// <summary>
        /// 农历基准月
        /// </summary>
        public const int BASE_MONTH = 11;

        /// <summary>
        /// 农历基准日
        /// </summary>
        public const int BASE_DAY = 11;

        /// <summary>
        /// 农历与阳历年偏移量
        /// </summary>
        public const int BASE_INDEX = 0;

        /// <summary>
        /// 基准对应的干支偏移量
        /// </summary>
        public const int BASE_DAY_GANZHI_INDEX = 15;

        /// <summary>
        /// 月份地支偏移量，因正月起寅
        /// </summary>
        public const int BASE_MONTH_ZHI_INDEX = 2;

        /// <summary>
        /// 星期偏移量
        /// </summary>
        public const int BASE_WEEK_INDEX = 2;

        /// <summary>
        /// 闰年表
        /// </summary>
        public static readonly int[] LEAP_MONTH_YEAR = { 6, 14, 19, 25, 33, 36, 38, 41, 44, 52, 55, 79, 117, 136, 147, 150, 155, 158, 185, 193 };

        /// <summary>
        /// 闰月表
        /// </summary>
        public static readonly int[] LUNAR_MONTH = { 0x00, 0x04, 0xad, 0x08, 0x5a, 0x01, 0xd5, 0x54, 0xb4, 0x09, 0x64, 0x05, 0x59, 0x45, 0x95, 0x0a, 0xa6, 0x04, 0x55, 0x24, 0xad, 0x08, 0x5a, 0x62, 0xda, 0x04, 0xb4, 0x05, 0xb4, 0x55, 0x52, 0x0d, 0x94, 0x0a, 0x4a, 0x2a, 0x56, 0x02, 0x6d, 0x71, 0x6d, 0x01, 0xda, 0x02, 0xd2, 0x52, 0xa9, 0x05, 0x49, 0x0d, 0x2a, 0x45, 0x2b, 0x09, 0x56, 0x01, 0xb5, 0x20, 0x6d, 0x01, 0x59, 0x69, 0xd4, 0x0a, 0xa8, 0x05, 0xa9, 0x56, 0xa5, 0x04, 0x2b, 0x09, 0x9e, 0x38, 0xb6, 0x08, 0xec, 0x74, 0x6c, 0x05, 0xd4, 0x0a, 0xe4, 0x6a, 0x52, 0x05, 0x95, 0x0a, 0x5a, 0x42, 0x5b, 0x04, 0xb6, 0x04, 0xb4, 0x22, 0x6a, 0x05, 0x52, 0x75, 0xc9, 0x0a, 0x52, 0x05, 0x35, 0x55, 0x4d, 0x0a, 0x5a, 0x02, 0x5d, 0x31, 0xb5, 0x02, 0x6a, 0x8a, 0x68, 0x05, 0xa9, 0x0a, 0x8a, 0x6a, 0x2a, 0x05, 0x2d, 0x09, 0xaa, 0x48, 0x5a, 0x01, 0xb5, 0x09, 0xb0, 0x39, 0x64, 0x05, 0x25, 0x75, 0x95, 0x0a, 0x96, 0x04, 0x4d, 0x54, 0xad, 0x04, 0xda, 0x04, 0xd4, 0x44, 0xb4, 0x05, 0x54, 0x85, 0x52, 0x0d, 0x92, 0x0a, 0x56, 0x6a, 0x56, 0x02, 0x6d, 0x02, 0x6a, 0x41, 0xda, 0x02, 0xb2, 0xa1, 0xa9, 0x05, 0x49, 0x0d, 0x0a, 0x6d, 0x2a, 0x09, 0x56, 0x01, 0xad, 0x50, 0x6d, 0x01, 0xd9, 0x02, 0xd1, 0x3a, 0xa8, 0x05, 0x29, 0x85, 0xa5, 0x0c, 0x2a, 0x09, 0x96, 0x54, 0xb6, 0x08, 0x6c, 0x09, 0x64, 0x45, 0xd4, 0x0a, 0xa4, 0x05, 0x51, 0x25, 0x95, 0x0a, 0x2a, 0x72, 0x5b, 0x04, 0xb6, 0x04, 0xac, 0x52, 0x6a, 0x05, 0xd2, 0x0a, 0xa2, 0x4a, 0x4a, 0x05, 0x55, 0x94, 0x2d, 0x0a, 0x5a, 0x02, 0x75, 0x61, 0xb5, 0x02, 0x6a, 0x03, 0x61, 0x45, 0xa9, 0x0a, 0x4a, 0x05, 0x25, 0x25, 0x2d, 0x09, 0x9a, 0x68, 0xda, 0x08, 0xb4, 0x09, 0xa8, 0x59, 0x54, 0x03, 0xa5, 0x0a, 0x91, 0x3a, 0x96, 0x04, 0xad, 0xb0, 0xad, 0x04, 0xda, 0x04, 0xf4, 0x62, 0xb4, 0x05, 0x54, 0x0b, 0x44, 0x5d, 0x52, 0x0a, 0x95, 0x04, 0x55, 0x22, 0x6d, 0x02, 0x5a, 0x71, 0xda, 0x02, 0xaa, 0x05, 0xb2, 0x55, 0x49, 0x0b, 0x4a, 0x0a, 0x2d, 0x39, 0x36, 0x01, 0x6d, 0x80, 0x6d, 0x01, 0xd9, 0x02, 0xe9, 0x6a, 0xa8, 0x05, 0x29, 0x0b, 0x9a, 0x4c, 0xaa, 0x08, 0xb6, 0x08, 0xb4, 0x38, 0x6c, 0x09, 0x54, 0x75, 0xd4, 0x0a, 0xa4, 0x05, 0x45, 0x55, 0x95, 0x0a, 0x9a, 0x04, 0x55, 0x44, 0xb5, 0x04, 0x6a, 0x82, 0x6a, 0x05, 0xd2, 0x0a, 0x92, 0x6a, 0x4a, 0x05, 0x55, 0x0a, 0x2a, 0x4a, 0x5a, 0x02, 0xb5, 0x02, 0xb2, 0x31, 0x69, 0x03, 0x31, 0x73, 0xa9, 0x0a, 0x4a, 0x05, 0x2d, 0x55, 0x2d, 0x09, 0x5a, 0x01, 0xd5, 0x48, 0xb4, 0x09, 0x68, 0x89, 0x54, 0x0b, 0xa4, 0x0a, 0xa5, 0x6a, 0x95, 0x04, 0xad, 0x08, 0x6a, 0x44, 0xda, 0x04, 0x74, 0x05, 0xb0, 0x25, 0x54, 0x03 };

        /// <summary>
        /// 天干
        /// </summary>
        public static readonly string[] GAN = { "", "甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸" };

        /// <summary>
        /// 喜神方位，《喜神方位歌》：甲己在艮乙庚乾，丙辛坤位喜神安.  丁壬只在离宫坐，戊癸原在在巽间。
        /// </summary>
        public static readonly string[] POSITION_XI = { "", "艮", "乾", "坤", "离", "巽", "艮", "乾", "坤", "离", "巽" };

        /// <summary>
        /// 阳贵方位，《阳贵神歌》：甲戊坤艮位，乙己是坤坎，庚辛居离艮，丙丁兑与乾，震巽属何日，壬癸贵神安。
        /// </summary>
        public static readonly string[] POSITION_YANG_GUI = { "", "坤", "坤", "兑", "乾", "艮", "坎", "离", "艮", "震", "巽" };

        /// <summary>
        /// 阴贵方位，《阴贵神歌》：甲戊见牛羊，乙己鼠猴乡，丙丁猪鸡位，壬癸蛇兔藏，庚辛逢虎马，此是贵神方。
        /// </summary>
        public static readonly string[] POSITION_YIN_GUI = { "", "艮", "坎", "乾", "兑", "坤", "坤", "艮", "离", "巽", "震" };

        /// <summary>
        /// 福神方位，参考多个黄历而决定采用的《福神方位歌》：甲乙东南是福神，丙丁正东是堪宜，戊北己南庚辛坤，壬在乾方癸在西。
        /// </summary>
        public static readonly string[] POSITION_FU = { "", "巽", "巽", "震", "震", "坎", "离", "坤", "坤", "乾", "兑" };

        //未采用的《福神方位歌》：甲己正北是福神，丙辛西北乾宫存，乙庚坤位戊癸艮，丁壬巽上好追寻。
        //public static readonly string[] POSITION_FU = {"","坎","坤","乾","巽","艮","坎","坤","乾","巽","艮"};

        /// <summary>
        /// 财神方位，《财神方位歌》：甲乙东北是财神，丙丁向在西南寻，戊己正北坐方位， 庚辛正东去安身，壬癸原来正南坐，便是财神方位真。
        /// </summary>
        public static readonly string[] POSITION_CAI = { "", "艮", "艮", "坤", "坤", "坎", "坎", "震", "震", "离", "离" };

        /// <summary>
        /// 逐日胎神方位
        /// </summary>
        public static readonly string[] POSITION_TAI_DAY = { "占门碓外东南", "碓磨厕外东南", "厨灶炉外正南", "仓库门外正南", "房床厕外正南", "占门床外正南", "占碓磨外正南", "厨灶厕外西南", "仓库炉外西南", "房床门外西南", "门鸡栖外西南", "碓磨床外西南", "厨灶碓外西南", "仓库厕外西南", "房床厕外正南", "房床炉外正西", "碓磨栖外正西", "厨灶床外正西", "仓库碓外西北", "房床厕外西北", "占门炉外西北", "碓磨门外西北", "厨灶栖外西北", "仓库床外西北", "房床碓外正北", "占门厕外正北", "碓磨炉外正北", "厨灶门外正北", "仓库栖外正北", "占房床房内北", "占门碓房内北", "碓磨厕房内北", "厨灶炉房内北", "仓库门房内北", "门鸡栖外西南", "占门床房内南", "占碓磨房内南", "厨灶厕房内南", "仓库炉房内南", "房床门房内南", "门鸡栖房内东", "碓磨床房内东", "厨灶碓房内东", "仓库厕房内东", "房床炉房内东", "占大门外东北", "碓磨栖外东北", "厨灶床外东北", "仓库碓外东北", "房床厕外东北", "占门炉外东北", "碓磨门外正东", "厨灶栖外正东", "仓库床外正东", "房床碓外正东", "占门厕外正东", "碓磨炉外东南", "仓库栖外东南", "占房床外东南", "占门碓外东南" };

        /// <summary>
        /// 逐月胎神方位
        /// </summary>
        public static readonly string[] POSITION_TAI_MONTH = { "占房床", "占户窗", "占门堂", "占厨灶", "占身床", "占床仓", "占碓磨", "占厕户", "占门房", "占房床", "占炉灶", "占房床" };

        /// <summary>
        /// 地支
        /// </summary>
        public static readonly string[] ZHI = { "", "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥" };

        /// <summary>
        /// 十二值星
        /// </summary>
        public static readonly string[] ZHI_XING = { "", "建", "除", "满", "平", "定", "执", "破", "危", "成", "收", "开", "闭" };

        /// <summary>
        /// 十二天神
        /// </summary>
        public static readonly string[] TIAN_SHEN = { "", "青龙", "明堂", "天刑", "朱雀", "金匮", "天德", "白虎", "玉堂", "天牢", "玄武", "司命", "勾陈" };

        /// <summary>
        /// 彭祖百忌.天干
        /// </summary>
        public static readonly string[] PENGZU_GAN = { "", "甲不开仓财物耗散", "乙不栽植千株不长", "丙不修灶必见灾殃", "丁不剃头头必生疮", "戊不受田田主不祥", "己不破券二比并亡", "庚不经络织机虚张", "辛不合酱主人不尝", "壬不泱水更难提防", "癸不词讼理弱敌强" };

        /// <summary>
        /// 彭祖百忌.地支
        /// </summary>
        public static readonly string[] PENGZU_ZHI = { "", "子不问卜自惹祸殃", "丑不冠带主不还乡", "寅不祭祀神鬼不尝", "卯不穿井水泉不香", "辰不哭泣必主重丧", "巳不远行财物伏藏", "午不苫盖屋主更张", "未不服药毒气入肠", "申不安床鬼祟入房", "酉不会客醉坐颠狂", "戌不吃犬作怪上床", "亥不嫁娶不利新郎" };
        
        /// <summary>
        /// 数字
        /// </summary>
        public static readonly string[] NUMBER = { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
        
        /// <summary>
        /// 月
        /// </summary>
        public static readonly string[] MONTH = { "", "正", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖", "拾", "冬", "腊" };
        
        /// <summary>
        /// 季节
        /// </summary>
        public static readonly string[] SEASON = { "", "孟春", "仲春", "季春", "孟夏", "仲夏", "季夏", "孟秋", "仲秋", "季秋", "孟冬", "仲冬", "季冬" };
        
        /// <summary>
        /// 生效
        /// </summary>
        public static readonly string[] SHENGXIAO = { "", "鼠", "牛", "虎", "兔", "龙", "蛇", "马", "羊", "猴", "鸡", "狗", "猪" };
        
        /// <summary>
        /// 气
        /// </summary>
        public static readonly string[] QI = { "大寒", "雨水", "春分", "谷雨", "夏满", "夏至", "大暑", "处暑", "秋分", "霜降", "小雪", "冬至" };
       
        /// <summary>
        /// 节
        /// </summary>
        public static readonly string[] JIE = { "小寒", "立春", "惊蛰", "清明", "立夏", "芒种", "小暑", "立秋", "白露", "寒露", "立冬", "大雪" };
        
        /// <summary>
        /// 日
        /// </summary>
        public static readonly string[] DAY = { "", "初一", "初二", "初三", "初四", "初五", "初六", "初七", "初八", "初九", "初十", "十一", "十二", "十三", "十四", "十五", "十六", "十七", "十八", "十九", "二十", "廿一", "廿二", "廿三", "廿四", "廿五", "廿六", "廿七", "廿八", "廿九", "三十" };

        /// <summary>
        /// 地支相冲（子午相冲，丑未相冲，寅申相冲，辰戌相冲，卯酉相冲，巳亥相冲），由于地支对应十二生肖，也就对应了生肖相冲
        /// </summary>
        public static readonly string[] CHONG = { "", "午", "未", "申", "酉", "戌", "亥", "子", "丑", "寅", "卯", "辰", "巳" };

        /// <summary>
        /// 天干相冲之无情之克（阳克阳，阴克阴）
        /// </summary>
        public static readonly string[] CHONG_GAN = { "", "戊", "己", "庚", "辛", "壬", "癸", "甲", "乙", "丙", "丁" };

        /// <summary>
        /// 天干相冲之有情之克（阳克阴，阴克阳）
        /// </summary>
        public static readonly string[] CHONG_GAN_TIE = { "", "己", "戊", "辛", "庚", "癸", "壬", "乙", "甲", "丁", "丙" };

        public static readonly List<int[]> JIE_YEAR = new List<int[]>();
        public static readonly List<int[]> JIE_MAP = new List<int[]>();
        public static readonly List<int[]> QI_YEAR = new List<int[]>();
        public static readonly List<int[]> QI_MAP = new List<int[]>();


        /// <summary>
        /// 月份地支对应天神偏移下标
        /// </summary>
        public static readonly Dictionary<string, int> MONTH_ZHI_TIAN_SHEN_OFFSET = new Dictionary<string, int>();

        /// <summary>
        /// 天神类型：黄道，黑道
        /// </summary>
        public static readonly Dictionary<string, string> TIAN_SHEN_TYPE = new Dictionary<string, string>();

        /// <summary>
        /// 天神类型吉凶
        /// </summary>
        public static readonly Dictionary<string, string> TIAN_SHEN_TYPE_LUCK = new Dictionary<string, string>();

        public static readonly Dictionary<string, string> FESTIVAL = new Dictionary<string, string>();
        public static readonly Dictionary<string, List<string>> OTHER_FESTIVAL = new Dictionary<string, List<string>>();

        /// <summary>
        /// 28星宿对照表，地支+星期
        /// </summary>
        public static readonly Dictionary<string, string> XIU = new Dictionary<string, string>();

        /// <summary>
        /// 星宿对应吉凶
        /// </summary>
        public static readonly Dictionary<string, string> XIU_LUCK = new Dictionary<string, string>();

        /// <summary>
        /// 星宿歌
        /// </summary>
        public static readonly Dictionary<string, string> XIU_SONG = new Dictionary<string, string>();

        /// <summary>
        /// 兽
        /// </summary>
        public static readonly Dictionary<string, string> SHOU = new Dictionary<string, string>();

        /// <summary>
        /// 天干四冲（无情之克中克得最严重的4个）
        /// </summary>
        public static readonly Dictionary<string, string> CHONG_GAN_BAD = new Dictionary<string, string>();

        /// <summary>
        /// 天干五合（有情之克中最有情的5个）
        /// </summary>
        public static readonly Dictionary<string, string> CHONG_GAN_TIE_GOOD = new Dictionary<string, string>();

        /// <summary>
        /// 煞
        /// </summary>
        public static readonly Dictionary<string, string> SHA = new Dictionary<string, string>();

        /// <summary>
        /// 方位描述
        /// </summary>
        public static readonly Dictionary<string, string> POSITION_DESC = new Dictionary<string, string>();

        /// <summary>
        /// 宫
        /// </summary>
        public static readonly Dictionary<string, string> GONG = new Dictionary<string, string>();

        /// <summary>
        /// 政
        /// </summary>
        public static readonly Dictionary<string, string> ZHENG = new Dictionary<string, string>();

        /// <summary>
        /// 动物
        /// </summary>
        public static readonly Dictionary<string, string> ANIMAL = new Dictionary<string, string>();

        /// <summary>
        /// 天干五行
        /// </summary>
        public static readonly Dictionary<string, string> WU_XING_GAN = new Dictionary<string, string>();

        /// <summary>
        /// 地支五行
        /// </summary>
        public static readonly Dictionary<string, string> WU_XING_ZHI = new Dictionary<string, string>();

        /// <summary>
        /// 纳音
        /// </summary>
        public static readonly Dictionary<string, string> NAYIN = new Dictionary<string, string>();

        /// <summary>
        /// 天干十神，日主+天干为键
        /// </summary>
        public static readonly Dictionary<string, string> SHI_SHEN_GAN = new Dictionary<string, string>();

        /// <summary>
        /// 地支十神，日主+地支藏干主气为键
        /// </summary>
        public static readonly Dictionary<string, string> SHI_SHEN_ZHI = new Dictionary<string, string>();

        /// <summary>
        /// 地支藏干表，分别为主气、余气、杂气
        /// </summary>
        public static readonly Dictionary<string, List<string>> ZHI_HIDE_GAN = new Dictionary<string, List<string>>();

        static LunarUtil()
        {
            JIE_YEAR.Add(new int[] { 13, 49, 85, 117, 149, 185, 201, 250, 250 });
            JIE_YEAR.Add(new int[] { 13, 45, 81, 117, 149, 185, 201, 250, 250 });
            JIE_YEAR.Add(new int[] { 13, 48, 84, 112, 148, 184, 200, 201, 250 });
            JIE_YEAR.Add(new int[] { 13, 45, 76, 108, 140, 172, 200, 201, 250 });
            JIE_YEAR.Add(new int[] { 13, 44, 72, 104, 132, 168, 200, 201, 250 });
            JIE_YEAR.Add(new int[] { 5, 33, 68, 96, 124, 152, 188, 200, 201 });
            JIE_YEAR.Add(new int[] { 29, 57, 85, 120, 148, 176, 200, 201, 250 });
            JIE_YEAR.Add(new int[] { 13, 48, 76, 104, 132, 168, 196, 200, 201 });
            JIE_YEAR.Add(new int[] { 25, 60, 88, 120, 148, 184, 200, 201, 250 });
            JIE_YEAR.Add(new int[] { 16, 44, 76, 108, 144, 172, 200, 201, 250 });
            JIE_YEAR.Add(new int[] { 28, 60, 92, 124, 160, 192, 200, 201, 250 });
            JIE_YEAR.Add(new int[] { 17, 53, 85, 124, 156, 188, 200, 201, 250 });

            JIE_MAP.Add(new int[] { 7, 6, 6, 6, 6, 6, 6, 6, 6, 5, 6, 6, 6, 5, 5, 6, 6, 5, 5, 5, 5, 5, 5, 5, 5, 4, 5, 5 });
            JIE_MAP.Add(new int[] { 5, 4, 5, 5, 5, 4, 4, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4, 3, 4, 4, 4, 3, 3, 4, 4, 3, 3, 3 });
            JIE_MAP.Add(new int[] { 6, 6, 6, 7, 6, 6, 6, 6, 5, 6, 6, 6, 5, 5, 6, 6, 5, 5, 5, 6, 5, 5, 5, 5, 4, 5, 5, 5, 5 });
            JIE_MAP.Add(new int[] { 5, 5, 6, 6, 5, 5, 5, 6, 5, 5, 5, 5, 4, 5, 5, 5, 4, 4, 5, 5, 4, 4, 4, 5, 4, 4, 4, 4, 5 });
            JIE_MAP.Add(new int[] { 6, 6, 6, 7, 6, 6, 6, 6, 5, 6, 6, 6, 5, 5, 6, 6, 5, 5, 5, 6, 5, 5, 5, 5, 4, 5, 5, 5, 5 });
            JIE_MAP.Add(new int[] { 6, 6, 7, 7, 6, 6, 6, 7, 6, 6, 6, 6, 5, 6, 6, 6, 5, 5, 6, 6, 5, 5, 5, 6, 5, 5, 5, 5, 4, 5, 5, 5, 5 });
            JIE_MAP.Add(new int[] { 7, 8, 8, 8, 7, 7, 8, 8, 7, 7, 7, 8, 7, 7, 7, 7, 6, 7, 7, 7, 6, 6, 7, 7, 6, 6, 6, 7, 7 });
            JIE_MAP.Add(new int[] { 8, 8, 8, 9, 8, 8, 8, 8, 7, 8, 8, 8, 7, 7, 8, 8, 7, 7, 7, 8, 7, 7, 7, 7, 6, 7, 7, 7, 6, 6, 7, 7, 7 });
            JIE_MAP.Add(new int[] { 8, 8, 8, 9, 8, 8, 8, 8, 7, 8, 8, 8, 7, 7, 8, 8, 7, 7, 7, 8, 7, 7, 7, 7, 6, 7, 7, 7, 7 });
            JIE_MAP.Add(new int[] { 9, 9, 9, 9, 8, 9, 9, 9, 8, 8, 9, 9, 8, 8, 8, 9, 8, 8, 8, 8, 7, 8, 8, 8, 7, 7, 8, 8, 8 });
            JIE_MAP.Add(new int[] { 8, 8, 8, 8, 7, 8, 8, 8, 7, 7, 8, 8, 7, 7, 7, 8, 7, 7, 7, 7, 6, 7, 7, 7, 6, 6, 7, 7, 7 });
            JIE_MAP.Add(new int[] { 7, 8, 8, 8, 7, 7, 8, 8, 7, 7, 7, 8, 7, 7, 7, 7, 6, 7, 7, 7, 6, 6, 7, 7, 6, 6, 6, 7, 7 });

            QI_YEAR.Add(new int[] { 13, 45, 81, 113, 149, 185, 201 });
            QI_YEAR.Add(new int[] { 21, 57, 93, 125, 161, 193, 201 });
            QI_YEAR.Add(new int[] { 21, 56, 88, 120, 152, 188, 200, 201 });
            QI_YEAR.Add(new int[] { 21, 49, 81, 116, 144, 176, 200, 201 });
            QI_YEAR.Add(new int[] { 17, 49, 77, 112, 140, 168, 200, 201 });
            QI_YEAR.Add(new int[] { 28, 60, 88, 116, 148, 180, 200, 201 });
            QI_YEAR.Add(new int[] { 25, 53, 84, 112, 144, 172, 200, 201 });
            QI_YEAR.Add(new int[] { 29, 57, 89, 120, 148, 180, 200, 201 });
            QI_YEAR.Add(new int[] { 17, 45, 73, 108, 140, 168, 200, 201 });
            QI_YEAR.Add(new int[] { 28, 60, 92, 124, 160, 192, 200, 201 });
            QI_YEAR.Add(new int[] { 16, 44, 80, 112, 148, 180, 200, 201 });
            QI_YEAR.Add(new int[] { 17, 53, 88, 120, 156, 188, 200, 201 });

            QI_MAP.Add(new int[] { 21, 21, 21, 21, 21, 20, 21, 21, 21, 20, 20, 21, 21, 20, 20, 20, 20, 20, 20, 20, 20, 19, 20, 20, 20, 19, 19, 20 });
            QI_MAP.Add(new int[] { 20, 19, 19, 20, 20, 19, 19, 19, 19, 19, 19, 19, 19, 18, 19, 19, 19, 18, 18, 19, 19, 18, 18, 18, 18, 18, 18, 18 });
            QI_MAP.Add(new int[] { 21, 21, 21, 22, 21, 21, 21, 21, 20, 21, 21, 21, 20, 20, 21, 21, 20, 20, 20, 21, 20, 20, 20, 20, 19, 20, 20, 20, 20 });
            QI_MAP.Add(new int[] { 20, 21, 21, 21, 20, 20, 21, 21, 20, 20, 20, 21, 20, 20, 20, 20, 19, 20, 20, 20, 19, 19, 20, 20, 19, 19, 19, 20, 20 });
            QI_MAP.Add(new int[] { 21, 22, 22, 22, 21, 21, 22, 22, 21, 21, 21, 22, 21, 21, 21, 21, 20, 21, 21, 21, 20, 20, 21, 21, 20, 20, 20, 21, 21 });
            QI_MAP.Add(new int[] { 22, 22, 22, 22, 21, 22, 22, 22, 21, 21, 22, 22, 21, 21, 21, 22, 21, 21, 21, 21, 20, 21, 21, 21, 20, 20, 21, 21, 21 });
            QI_MAP.Add(new int[] { 23, 23, 24, 24, 23, 23, 23, 24, 23, 23, 23, 23, 22, 23, 23, 23, 22, 22, 23, 23, 22, 22, 22, 23, 22, 22, 22, 22, 23 });
            QI_MAP.Add(new int[] { 23, 24, 24, 24, 23, 23, 24, 24, 23, 23, 23, 24, 23, 23, 23, 23, 22, 23, 23, 23, 22, 22, 23, 23, 22, 22, 22, 23, 23 });
            QI_MAP.Add(new int[] { 23, 24, 24, 24, 23, 23, 24, 24, 23, 23, 23, 24, 23, 23, 23, 23, 22, 23, 23, 23, 22, 22, 23, 23, 22, 22, 22, 23, 23 });
            QI_MAP.Add(new int[] { 24, 24, 24, 24, 23, 24, 24, 24, 23, 23, 24, 24, 23, 23, 23, 24, 23, 23, 23, 23, 22, 23, 23, 23, 22, 22, 23, 23, 23 });
            QI_MAP.Add(new int[] { 23, 23, 23, 23, 22, 23, 23, 23, 22, 22, 23, 23, 22, 22, 22, 23, 22, 22, 22, 22, 21, 22, 22, 22, 21, 21, 22, 22, 22 });
            QI_MAP.Add(new int[] { 22, 22, 23, 23, 22, 22, 22, 23, 22, 22, 22, 22, 21, 22, 22, 22, 21, 21, 22, 22, 21, 21, 21, 22, 21, 21, 21, 21, 22 });

            MONTH_ZHI_TIAN_SHEN_OFFSET.Add("子", 4);
            MONTH_ZHI_TIAN_SHEN_OFFSET.Add("丑", 2);
            MONTH_ZHI_TIAN_SHEN_OFFSET.Add("寅", 0);
            MONTH_ZHI_TIAN_SHEN_OFFSET.Add("卯", 10);
            MONTH_ZHI_TIAN_SHEN_OFFSET.Add("辰", 8);
            MONTH_ZHI_TIAN_SHEN_OFFSET.Add("巳", 6);
            MONTH_ZHI_TIAN_SHEN_OFFSET.Add("午", 4);
            MONTH_ZHI_TIAN_SHEN_OFFSET.Add("未", 2);
            MONTH_ZHI_TIAN_SHEN_OFFSET.Add("申", 0);
            MONTH_ZHI_TIAN_SHEN_OFFSET.Add("酉", 10);
            MONTH_ZHI_TIAN_SHEN_OFFSET.Add("戌", 8);
            MONTH_ZHI_TIAN_SHEN_OFFSET.Add("亥", 6);

            TIAN_SHEN_TYPE.Add("青龙", "黄道");
            TIAN_SHEN_TYPE.Add("明堂", "黄道");
            TIAN_SHEN_TYPE.Add("金匮", "黄道");
            TIAN_SHEN_TYPE.Add("天德", "黄道");
            TIAN_SHEN_TYPE.Add("玉堂", "黄道");
            TIAN_SHEN_TYPE.Add("司命", "黄道");

            TIAN_SHEN_TYPE.Add("天刑", "黑道");
            TIAN_SHEN_TYPE.Add("朱雀", "黄道");
            TIAN_SHEN_TYPE.Add("白虎", "黄道");
            TIAN_SHEN_TYPE.Add("天牢", "黄道");
            TIAN_SHEN_TYPE.Add("玄武", "黄道");
            TIAN_SHEN_TYPE.Add("勾陈", "黄道");

            TIAN_SHEN_TYPE_LUCK.Add("黄道", "吉");
            TIAN_SHEN_TYPE_LUCK.Add("黑道", "凶");

            FESTIVAL.Add("1-1", "春节");
            FESTIVAL.Add("1-15", "元宵节");
            FESTIVAL.Add("2-2", "龙头节");
            FESTIVAL.Add("5-5", "端午节");
            FESTIVAL.Add("7-7", "七夕节");
            FESTIVAL.Add("8-15", "中秋节");
            FESTIVAL.Add("9-9", "重阳节");
            FESTIVAL.Add("12-8", "腊八节");
            FESTIVAL.Add("12-30", "除夕");

            OTHER_FESTIVAL.Add("1-1", new List<string>(new string[] { "弥勒佛圣诞" }));
            OTHER_FESTIVAL.Add("1-8", new List<string>(new string[] { "五殿阎罗天子诞" }));
            OTHER_FESTIVAL.Add("1-9", new List<string>(new string[] { "玉皇上帝诞" }));
            OTHER_FESTIVAL.Add("2-1", new List<string>(new string[] { "一殿秦广王诞" }));
            OTHER_FESTIVAL.Add("2-2", new List<string>(new string[] { "福德土地正神诞" }));
            OTHER_FESTIVAL.Add("2-3", new List<string>(new string[] { "文昌帝君诞" }));
            OTHER_FESTIVAL.Add("2-6", new List<string>(new string[] { "东华帝君诞" }));
            OTHER_FESTIVAL.Add("2-8", new List<string>(new string[] { "释迦牟尼佛出家" }));
            OTHER_FESTIVAL.Add("2-15", new List<string>(new string[] { "释迦牟尼佛般涅槃" }));
            OTHER_FESTIVAL.Add("2-17", new List<string>(new string[] { "东方杜将军诞" }));
            OTHER_FESTIVAL.Add("2-18", new List<string>(new string[] { "至圣先师孔子讳辰" }));
            OTHER_FESTIVAL.Add("2-19", new List<string>(new string[] { "观音大士诞" }));
            OTHER_FESTIVAL.Add("2-21", new List<string>(new string[] { "普贤菩萨诞" }));
            OTHER_FESTIVAL.Add("3-1", new List<string>(new string[] { "二殿楚江王诞" }));
            OTHER_FESTIVAL.Add("3-3", new List<string>(new string[] { "玄天上帝诞" }));
            OTHER_FESTIVAL.Add("3-8", new List<string>(new string[] { "六殿卞城王诞" }));
            OTHER_FESTIVAL.Add("3-15", new List<string>(new string[] { "昊天上帝诞" }));
            OTHER_FESTIVAL.Add("3-16", new List<string>(new string[] { "准提菩萨诞" }));
            OTHER_FESTIVAL.Add("3-19", new List<string>(new string[] { "中岳大帝诞" }));
            OTHER_FESTIVAL.Add("3-20", new List<string>(new string[] { "子孙娘娘诞" }));
            OTHER_FESTIVAL.Add("3-27", new List<string>(new string[] { "七殿泰山王诞" }));
            OTHER_FESTIVAL.Add("3-28", new List<string>(new string[] { "苍颉至圣先师诞" }));
            OTHER_FESTIVAL.Add("4-1", new List<string>(new string[] { "八殿都市王诞" }));
            OTHER_FESTIVAL.Add("4-4", new List<string>(new string[] { "文殊菩萨诞" }));
            OTHER_FESTIVAL.Add("4-8", new List<string>(new string[] { "释迦牟尼佛诞" }));
            OTHER_FESTIVAL.Add("4-14", new List<string>(new string[] { "纯阳祖师诞" }));
            OTHER_FESTIVAL.Add("4-15", new List<string>(new string[] { "钟离祖师诞" }));
            OTHER_FESTIVAL.Add("4-17", new List<string>(new string[] { "十殿转轮王诞" }));
            OTHER_FESTIVAL.Add("4-18", new List<string>(new string[] { "紫徽大帝诞" }));
            OTHER_FESTIVAL.Add("4-20", new List<string>(new string[] { "眼光圣母诞" }));
            OTHER_FESTIVAL.Add("5-1", new List<string>(new string[] { "南极长生大帝诞" }));
            OTHER_FESTIVAL.Add("5-8", new List<string>(new string[] { "南方五道诞" }));
            OTHER_FESTIVAL.Add("5-11", new List<string>(new string[] { "天下都城隍诞" }));
            OTHER_FESTIVAL.Add("5-12", new List<string>(new string[] { "炳灵公诞" }));
            OTHER_FESTIVAL.Add("5-13", new List<string>(new string[] { "关圣降" }));
            OTHER_FESTIVAL.Add("5-16", new List<string>(new string[] { "天地元气造化万物之辰" }));
            OTHER_FESTIVAL.Add("5-18", new List<string>(new string[] { "张天师诞" }));
            OTHER_FESTIVAL.Add("5-22", new List<string>(new string[] { "孝娥神诞" }));
            OTHER_FESTIVAL.Add("6-19", new List<string>(new string[] { "观世音菩萨成道日" }));
            OTHER_FESTIVAL.Add("6-24", new List<string>(new string[] { "关帝诞" }));
            OTHER_FESTIVAL.Add("7-7", new List<string>(new string[] { "魁星诞" }));
            OTHER_FESTIVAL.Add("7-13", new List<string>(new string[] { "长真谭真人诞", "大势至菩萨诞" }));
            OTHER_FESTIVAL.Add("7-15", new List<string>(new string[] { "中元节" }));
            OTHER_FESTIVAL.Add("7-18", new List<string>(new string[] { "西王母诞" }));
            OTHER_FESTIVAL.Add("7-19", new List<string>(new string[] { "太岁诞" }));
            OTHER_FESTIVAL.Add("7-22", new List<string>(new string[] { "增福财神诞" }));
            OTHER_FESTIVAL.Add("7-29", new List<string>(new string[] { "杨公忌" }));
            OTHER_FESTIVAL.Add("7-30", new List<string>(new string[] { "地藏菩萨诞" }));
            OTHER_FESTIVAL.Add("8-1", new List<string>(new string[] { "许真君诞" }));
            OTHER_FESTIVAL.Add("8-3", new List<string>(new string[] { "司命灶君诞" }));
            OTHER_FESTIVAL.Add("8-5", new List<string>(new string[] { "雷声大帝诞" }));
            OTHER_FESTIVAL.Add("8-10", new List<string>(new string[] { "北斗大帝诞" }));
            OTHER_FESTIVAL.Add("8-12", new List<string>(new string[] { "西方五道诞" }));
            OTHER_FESTIVAL.Add("8-16", new List<string>(new string[] { "天曹掠刷真君降" }));
            OTHER_FESTIVAL.Add("8-18", new List<string>(new string[] { "天人兴福之辰" }));
            OTHER_FESTIVAL.Add("8-23", new List<string>(new string[] { "汉恒候张显王诞" }));
            OTHER_FESTIVAL.Add("8-24", new List<string>(new string[] { "灶君夫人诞" }));
            OTHER_FESTIVAL.Add("8-29", new List<string>(new string[] { "至圣先师孔子诞" }));
            OTHER_FESTIVAL.Add("9-1", new List<string>(new string[] { "北斗九星降世" }));
            OTHER_FESTIVAL.Add("9-3", new List<string>(new string[] { "五瘟神诞" }));
            OTHER_FESTIVAL.Add("9-9", new List<string>(new string[] { "酆都大帝诞" }));
            OTHER_FESTIVAL.Add("9-13", new List<string>(new string[] { "孟婆尊神诞" }));
            OTHER_FESTIVAL.Add("9-17", new List<string>(new string[] { "金龙四大王诞" }));
            OTHER_FESTIVAL.Add("9-19", new List<string>(new string[] { "观世音菩萨出家" }));
            OTHER_FESTIVAL.Add("9-30", new List<string>(new string[] { "药师琉璃光佛诞" }));
            OTHER_FESTIVAL.Add("10-1", new List<string>(new string[] { "寒衣节" }));
            OTHER_FESTIVAL.Add("10-3", new List<string>(new string[] { "三茅诞" }));
            OTHER_FESTIVAL.Add("10-5", new List<string>(new string[] { "达摩祖师诞" }));
            OTHER_FESTIVAL.Add("10-8", new List<string>(new string[] { "佛涅槃日" }));
            OTHER_FESTIVAL.Add("10-15", new List<string>(new string[] { "下元节" }));
            OTHER_FESTIVAL.Add("11-4", new List<string>(new string[] { "至圣先师孔子诞" }));
            OTHER_FESTIVAL.Add("11-6", new List<string>(new string[] { "西岳大帝诞" }));
            OTHER_FESTIVAL.Add("11-11", new List<string>(new string[] { "太乙救苦天尊诞" }));
            OTHER_FESTIVAL.Add("11-17", new List<string>(new string[] { "阿弥陀佛诞" }));
            OTHER_FESTIVAL.Add("11-19", new List<string>(new string[] { "太阳日宫诞" }));
            OTHER_FESTIVAL.Add("11-23", new List<string>(new string[] { "张仙诞" }));
            OTHER_FESTIVAL.Add("11-26", new List<string>(new string[] { "北方五道诞" }));
            OTHER_FESTIVAL.Add("12-8", new List<string>(new string[] { "释迦如来成佛之辰" }));
            OTHER_FESTIVAL.Add("12-16", new List<string>(new string[] { "南岳大帝诞" }));
            OTHER_FESTIVAL.Add("12-21", new List<string>(new string[] { "天猷上帝诞" }));
            OTHER_FESTIVAL.Add("12-23", new List<string>(new string[] { "小年" }));
            OTHER_FESTIVAL.Add("12-24", new List<string>(new string[] { "子时灶君上天朝玉帝" }));
            OTHER_FESTIVAL.Add("12-29", new List<string>(new string[] { "华严菩萨诞" }));

            XIU.Add("申1", "毕");
            XIU.Add("申2", "翼");
            XIU.Add("申3", "箕");
            XIU.Add("申4", "奎");
            XIU.Add("申5", "鬼");
            XIU.Add("申6", "氐");
            XIU.Add("申0", "虚");

            XIU.Add("子1", "毕");
            XIU.Add("子2", "翼");
            XIU.Add("子3", "箕");
            XIU.Add("子4", "奎");
            XIU.Add("子5", "鬼");
            XIU.Add("子6", "氐");
            XIU.Add("子0", "虚");

            XIU.Add("辰1", "毕");
            XIU.Add("辰2", "翼");
            XIU.Add("辰3", "箕");
            XIU.Add("辰4", "奎");
            XIU.Add("辰5", "鬼");
            XIU.Add("辰6", "氐");
            XIU.Add("辰0", "虚");

            XIU.Add("巳1", "危");
            XIU.Add("巳2", "觜");
            XIU.Add("巳3", "轸");
            XIU.Add("巳4", "斗");
            XIU.Add("巳5", "娄");
            XIU.Add("巳6", "柳");
            XIU.Add("巳0", "房");

            XIU.Add("酉1", "危");
            XIU.Add("酉2", "觜");
            XIU.Add("酉3", "轸");
            XIU.Add("酉4", "斗");
            XIU.Add("酉5", "娄");
            XIU.Add("酉6", "柳");
            XIU.Add("酉0", "房");

            XIU.Add("丑1", "危");
            XIU.Add("丑2", "觜");
            XIU.Add("丑3", "轸");
            XIU.Add("丑4", "斗");
            XIU.Add("丑5", "娄");
            XIU.Add("丑6", "柳");
            XIU.Add("丑0", "房");

            XIU.Add("寅1", "心");
            XIU.Add("寅2", "室");
            XIU.Add("寅3", "参");
            XIU.Add("寅4", "角");
            XIU.Add("寅5", "牛");
            XIU.Add("寅6", "胃");
            XIU.Add("寅0", "星");

            XIU.Add("午1", "心");
            XIU.Add("午2", "室");
            XIU.Add("午3", "参");
            XIU.Add("午4", "角");
            XIU.Add("午5", "牛");
            XIU.Add("午6", "胃");
            XIU.Add("午0", "星");

            XIU.Add("戌1", "心");
            XIU.Add("戌2", "室");
            XIU.Add("戌3", "参");
            XIU.Add("戌4", "角");
            XIU.Add("戌5", "牛");
            XIU.Add("戌6", "胃");
            XIU.Add("戌0", "星");

            XIU.Add("亥1", "张");
            XIU.Add("亥2", "尾");
            XIU.Add("亥3", "壁");
            XIU.Add("亥4", "井");
            XIU.Add("亥5", "亢");
            XIU.Add("亥6", "女");
            XIU.Add("亥0", "昴");

            XIU.Add("卯1", "张");
            XIU.Add("卯2", "尾");
            XIU.Add("卯3", "壁");
            XIU.Add("卯4", "井");
            XIU.Add("卯5", "亢");
            XIU.Add("卯6", "女");
            XIU.Add("卯0", "昴");

            XIU.Add("未1", "张");
            XIU.Add("未2", "尾");
            XIU.Add("未3", "壁");
            XIU.Add("未4", "井");
            XIU.Add("未5", "亢");
            XIU.Add("未6", "女");
            XIU.Add("未0", "昴");

            XIU_LUCK.Add("角", "吉");
            XIU_LUCK.Add("亢", "凶");
            XIU_LUCK.Add("氐", "凶");
            XIU_LUCK.Add("房", "吉");
            XIU_LUCK.Add("心", "凶");
            XIU_LUCK.Add("尾", "吉");
            XIU_LUCK.Add("箕", "吉");
            XIU_LUCK.Add("斗", "吉");
            XIU_LUCK.Add("牛", "凶");
            XIU_LUCK.Add("女", "凶");
            XIU_LUCK.Add("虚", "凶");
            XIU_LUCK.Add("危", "凶");
            XIU_LUCK.Add("室", "吉");
            XIU_LUCK.Add("壁", "吉");
            XIU_LUCK.Add("奎", "凶");
            XIU_LUCK.Add("娄", "吉");
            XIU_LUCK.Add("胃", "吉");
            XIU_LUCK.Add("昴", "凶");
            XIU_LUCK.Add("毕", "吉");
            XIU_LUCK.Add("觜", "凶");
            XIU_LUCK.Add("参", "吉");
            XIU_LUCK.Add("井", "吉");
            XIU_LUCK.Add("鬼", "凶");
            XIU_LUCK.Add("柳", "凶");
            XIU_LUCK.Add("星", "凶");
            XIU_LUCK.Add("张", "吉");
            XIU_LUCK.Add("翼", "凶");
            XIU_LUCK.Add("轸", "吉");

            XIU_SONG.Add("角", "角星造作主荣昌，外进田财及女郎，嫁娶婚姻出贵子，文人及第见君王，惟有埋葬不可用，三年之后主瘟疫，起工修筑坟基地，堂前立见主人凶。");
            XIU_SONG.Add("亢", "亢星造作长房当，十日之中主有殃，田地消磨官失职，接运定是虎狼伤，嫁娶婚姻用此日，儿孙新妇守空房，埋葬若还用此日，当时害祸主重伤。");
            XIU_SONG.Add("氐", "氐星造作主灾凶，费尽田园仓库空，埋葬不可用此日，悬绳吊颈祸重重，若是婚姻离别散，夜招浪子入房中，行船必定遭沉没，更生聋哑子孙穷。");
            XIU_SONG.Add("房", "房星造作田园进，钱财牛马遍山岗，更招外处田庄宅，荣华富贵福禄康，埋葬若然用此日，高官进职拜君王，嫁娶嫦娥至月殿，三年抱子至朝堂。");
            XIU_SONG.Add("心", "心星造作大为凶，更遭刑讼狱囚中，忤逆官非宅产退，埋葬卒暴死相从，婚姻若是用此日，子死儿亡泪满胸，三年之内连遭祸，事事教君没始终。");
            XIU_SONG.Add("尾", "尾星造作主天恩，富贵荣华福禄增，招财进宝兴家宅，和合婚姻贵子孙，埋葬若能依此日，男清女正子孙兴，开门放水招田宅，代代公侯远播名。");
            XIU_SONG.Add("箕", "箕星造作主高强，岁岁年年大吉昌，埋葬修坟大吉利，田蚕牛马遍山岗，开门放水招田宅，箧满金银谷满仓，福荫高官加禄位，六亲丰禄乐安康。");
            XIU_SONG.Add("斗", "斗星造作主招财，文武官员位鼎台，田宅家财千万进，坟堂修筑贵富来，开门放水招牛马，旺蚕男女主和谐，遇此吉宿来照护，时支福庆永无灾。");
            XIU_SONG.Add("牛", "牛星造作主灾危，九横三灾不可推，家宅不安人口退，田蚕不利主人衰，嫁娶婚姻皆自损，金银财谷渐无之，若是开门并放水，牛猪羊马亦伤悲。");
            XIU_SONG.Add("女", "女星造作损婆娘，兄弟相嫌似虎狼，埋葬生灾逢鬼怪，颠邪疾病主瘟惶，为事遭官财失散，泻利留连不可当，开门放水用此日，全家财散主离乡。");
            XIU_SONG.Add("虚", "虚星造作主灾殃，男女孤眠不一双，内乱风声无礼节，儿孙媳妇伴人床，开门放水遭灾祸，虎咬蛇伤又卒亡，三三五五连年病，家破人亡不可当。");
            XIU_SONG.Add("危", "危星不可造高楼，自遭刑吊见血光，三年孩子遭水厄，后生出外永不还，埋葬若还逢此日，周年百日取高堂，三年两载一悲伤，开门放水到官堂。");
            XIU_SONG.Add("室", "室星修造进田牛，儿孙代代近王侯，家贵荣华天上至，寿如彭祖八千秋，开门放水招财帛，和合婚姻生贵儿，埋葬若能依此日，门庭兴旺福无休。");
            XIU_SONG.Add("壁", "壁星造作主增财，丝蚕大熟福滔天，奴婢自来人口进，开门放水出英贤，埋葬招财官品进，家中诸事乐陶然，婚姻吉利主贵子，早播名誉著祖鞭。");
            XIU_SONG.Add("奎", "奎星造作得祯祥，家内荣和大吉昌，若是埋葬阴卒死，当年定主两三伤，看看军令刑伤到，重重官事主瘟惶，开门放水遭灾祸，三年两次损儿郎。");
            XIU_SONG.Add("娄", "娄星修造起门庭，财旺家和事事兴，外进钱财百日进，一家兄弟播高名，婚姻进益生贵子，玉帛金银箱满盈，放水开门皆吉利，男荣女贵寿康宁。");
            XIU_SONG.Add("胃", "胃星造作事如何，家贵荣华喜气多，埋葬贵临官禄位，夫妇齐眉永保康，婚姻遇此家富贵，三灾九祸不逢他，从此门前多吉庆，儿孙代代拜金阶。");
            XIU_SONG.Add("昴", "昴星造作进田牛，埋葬官灾不得休，重丧二日三人死，尽卖田园不记增，开门放水招灾祸，三岁孩儿白了头，婚姻不可逢此日，死别生离是可愁。");
            XIU_SONG.Add("毕", "毕星造作主光前，买得田园有余钱，埋葬此日添官职，田蚕大熟永丰年，开门放水多吉庆，合家人口得安然，婚姻若得逢此日，生得孩儿福寿全。");
            XIU_SONG.Add("觜", "觜星造作有徒刑，三年必定主伶丁，埋葬卒死多因此，取定寅年使杀人，三丧不止皆由此，一人药毒二人身，家门田地皆退败，仓库金银化作尘。");
            XIU_SONG.Add("参", "参星造作旺人家，文星照耀大光华，只因造作田财旺，埋葬招疾哭黄沙，开门放水加官职，房房子孙见田加，婚姻许遁遭刑克，男女朝开幕落花。");
            XIU_SONG.Add("井", "井星造作旺蚕田，金榜题名第一光，埋葬须防惊卒死，狂颠风疾入黄泉，开门放水招财帛，牛马猪羊旺莫言，贵人田塘来入宅，儿孙兴旺有余钱。");
            XIU_SONG.Add("鬼", "鬼星起造卒人亡，堂前不见主人郎，埋葬此日官禄至，儿孙代代近君王，开门放水须伤死，嫁娶夫妻不久长，修土筑墙伤产女，手扶双女泪汪汪。");
            XIU_SONG.Add("柳", "柳星造作主遭官，昼夜偷闭不暂安，埋葬瘟惶多疾病，田园退尽守冬寒，开门放水遭聋瞎，腰驼背曲似弓弯，更有棒刑宜谨慎，妇人随客走盘桓。");
            XIU_SONG.Add("星", "星宿日好造新房，进职加官近帝王，不可埋葬并放水，凶星临位女人亡，生离死别无心恋，要自归休别嫁郎，孔子九曲殊难度，放水开门天命伤。");
            XIU_SONG.Add("张", "张星日好造龙轩，年年并见进庄田，埋葬不久升官职，代代为官近帝前，开门放水招财帛，婚姻和合福绵绵，田蚕人满仓库满，百般顺意自安然。");
            XIU_SONG.Add("翼", "翼星不利架高堂，三年二载见瘟惶，埋葬若还逢此日，子孙必定走他乡，婚姻此日不宜利，归家定是不相当，开门放水家须破，少女恋花贪外郎。");
            XIU_SONG.Add("轸", "轸星临水造龙宫，代代为官受皇封，富贵荣华增寿禄，库满仓盈自昌隆，埋葬文昌来照助，宅舍安宁不见凶，更有为官沾帝宠，婚姻龙子入龙宫。");

            SHOU.Add("东", "青龙");
            SHOU.Add("南", "朱雀");
            SHOU.Add("西", "白虎");
            SHOU.Add("北", "玄武");

            CHONG_GAN_BAD.Add("庚", "甲");
            CHONG_GAN_BAD.Add("辛", "乙");
            CHONG_GAN_BAD.Add("壬", "丙");
            CHONG_GAN_BAD.Add("癸", "丁");

            CHONG_GAN_TIE_GOOD.Add("甲", "己");
            CHONG_GAN_TIE_GOOD.Add("丙", "辛");
            CHONG_GAN_TIE_GOOD.Add("戊", "癸");
            CHONG_GAN_TIE_GOOD.Add("庚", "乙");
            CHONG_GAN_TIE_GOOD.Add("壬", "丁");

            SHA.Add("子", "南");
            SHA.Add("丑", "东");
            SHA.Add("寅", "北");
            SHA.Add("卯", "西");
            SHA.Add("辰", "南");
            SHA.Add("巳", "东");
            SHA.Add("午", "北");
            SHA.Add("未", "西");
            SHA.Add("申", "南");
            SHA.Add("酉", "东");
            SHA.Add("戌", "北");
            SHA.Add("亥", "西");

            POSITION_DESC.Add("坎", "正北");
            POSITION_DESC.Add("艮", "东北");
            POSITION_DESC.Add("震", "正东");
            POSITION_DESC.Add("巽", "东南");
            POSITION_DESC.Add("离", "正南");
            POSITION_DESC.Add("坤", "西南");
            POSITION_DESC.Add("兑", "正西");
            POSITION_DESC.Add("乾", "西北");

            GONG.Add("角", "东");
            GONG.Add("井", "南");
            GONG.Add("奎", "西");
            GONG.Add("斗", "北");
            GONG.Add("亢", "东");
            GONG.Add("鬼", "南");
            GONG.Add("娄", "西");
            GONG.Add("牛", "北");
            GONG.Add("氐", "南");
            GONG.Add("柳", "南");
            GONG.Add("胃", "西");
            GONG.Add("女", "北");
            GONG.Add("房", "东");
            GONG.Add("星", "南");
            GONG.Add("昴", "西");
            GONG.Add("虚", "北");
            GONG.Add("心", "东");
            GONG.Add("张", "南");
            GONG.Add("毕", "西");
            GONG.Add("危", "北");
            GONG.Add("尾", "东");
            GONG.Add("翼", "南");
            GONG.Add("觜", "西");
            GONG.Add("室", "北");
            GONG.Add("箕", "东");
            GONG.Add("轸", "南");
            GONG.Add("参", "西");
            GONG.Add("壁", "北");

            ZHENG.Add("角", "木");
            ZHENG.Add("井", "木");
            ZHENG.Add("奎", "木");
            ZHENG.Add("斗", "木");
            ZHENG.Add("亢", "金");
            ZHENG.Add("鬼", "金");
            ZHENG.Add("娄", "金");
            ZHENG.Add("牛", "金");
            ZHENG.Add("氐", "土");
            ZHENG.Add("柳", "土");
            ZHENG.Add("胃", "土");
            ZHENG.Add("女", "土");
            ZHENG.Add("房", "日");
            ZHENG.Add("星", "日");
            ZHENG.Add("昴", "日");
            ZHENG.Add("虚", "日");
            ZHENG.Add("心", "月");
            ZHENG.Add("张", "月");
            ZHENG.Add("毕", "月");
            ZHENG.Add("危", "月");
            ZHENG.Add("尾", "火");
            ZHENG.Add("翼", "火");
            ZHENG.Add("觜", "火");
            ZHENG.Add("室", "火");
            ZHENG.Add("箕", "水");
            ZHENG.Add("轸", "水");
            ZHENG.Add("参", "水");
            ZHENG.Add("壁", "水");

            ANIMAL.Add("角", "蛟");
            ANIMAL.Add("斗", "獬");
            ANIMAL.Add("奎", "狼");
            ANIMAL.Add("井", "犴");
            ANIMAL.Add("亢", "龙");
            ANIMAL.Add("牛", "牛");
            ANIMAL.Add("娄", "狗");
            ANIMAL.Add("鬼", "羊");
            ANIMAL.Add("女", "蝠");
            ANIMAL.Add("氐", "貉");
            ANIMAL.Add("胃", "彘");
            ANIMAL.Add("柳", "獐");
            ANIMAL.Add("房", "兔");
            ANIMAL.Add("虚", "鼠");
            ANIMAL.Add("昴", "鸡");
            ANIMAL.Add("星", "马");
            ANIMAL.Add("心", "狐");
            ANIMAL.Add("危", "燕");
            ANIMAL.Add("毕", "乌");
            ANIMAL.Add("张", "鹿");
            ANIMAL.Add("尾", "虎");
            ANIMAL.Add("室", "猪");
            ANIMAL.Add("觜", "猴");
            ANIMAL.Add("翼", "蛇");
            ANIMAL.Add("箕", "豹");
            ANIMAL.Add("壁", "獝");
            ANIMAL.Add("参", "猿");
            ANIMAL.Add("轸", "蚓");

            WU_XING_GAN.Add("甲", "木");
            WU_XING_GAN.Add("乙", "木");
            WU_XING_GAN.Add("丙", "火");
            WU_XING_GAN.Add("丁", "火");
            WU_XING_GAN.Add("戊", "土");
            WU_XING_GAN.Add("己", "土");
            WU_XING_GAN.Add("庚", "金");
            WU_XING_GAN.Add("辛", "金");
            WU_XING_GAN.Add("壬", "水");
            WU_XING_GAN.Add("癸", "水");

            WU_XING_ZHI.Add("寅", "木");
            WU_XING_ZHI.Add("卯", "木");
            WU_XING_ZHI.Add("巳", "火");
            WU_XING_ZHI.Add("午", "火");
            WU_XING_ZHI.Add("辰", "土");
            WU_XING_ZHI.Add("丑", "土");
            WU_XING_ZHI.Add("戌", "土");
            WU_XING_ZHI.Add("未", "土");
            WU_XING_ZHI.Add("申", "金");
            WU_XING_ZHI.Add("酉", "金");
            WU_XING_ZHI.Add("亥", "水");
            WU_XING_ZHI.Add("子", "水");

            NAYIN.Add("甲子", "海中金");
            NAYIN.Add("甲午", "沙中金");
            NAYIN.Add("丙寅", "炉中火");
            NAYIN.Add("丙申", "山下火");
            NAYIN.Add("戊辰", "大林木");
            NAYIN.Add("戊戌", "平地木");
            NAYIN.Add("庚午", "路旁土");
            NAYIN.Add("庚子", "壁上土");
            NAYIN.Add("壬申", "剑锋金");
            NAYIN.Add("壬寅", "金箔金");
            NAYIN.Add("甲戌", "山头火");
            NAYIN.Add("甲辰", "覆灯火");
            NAYIN.Add("丙子", "涧下水");
            NAYIN.Add("丙午", "天河水");
            NAYIN.Add("戊寅", "城头土");
            NAYIN.Add("戊申", "大驿土");
            NAYIN.Add("庚辰", "白蜡金");
            NAYIN.Add("庚戌", "钗钏金");
            NAYIN.Add("壬午", "杨柳木");
            NAYIN.Add("壬子", "桑柘木");
            NAYIN.Add("甲申", "泉中水");
            NAYIN.Add("甲寅", "大溪水");
            NAYIN.Add("丙戌", "屋上土");
            NAYIN.Add("丙辰", "沙中土");
            NAYIN.Add("戊子", "霹雳火");
            NAYIN.Add("戊午", "天上火");
            NAYIN.Add("庚寅", "松柏木");
            NAYIN.Add("庚申", "石榴木");
            NAYIN.Add("壬辰", "长流水");
            NAYIN.Add("壬戌", "大海水");
            NAYIN.Add("乙丑", "海中金");
            NAYIN.Add("乙未", "沙中金");
            NAYIN.Add("丁卯", "炉中火");
            NAYIN.Add("丁酉", "山下火");
            NAYIN.Add("己巳", "大林木");
            NAYIN.Add("己亥", "平地木");
            NAYIN.Add("辛未", "路旁土");
            NAYIN.Add("辛丑", "壁上土");
            NAYIN.Add("癸酉", "剑锋金");
            NAYIN.Add("癸卯", "金箔金");
            NAYIN.Add("乙亥", "山头火");
            NAYIN.Add("乙巳", "覆灯火");
            NAYIN.Add("丁丑", "涧下水");
            NAYIN.Add("丁未", "天河水");
            NAYIN.Add("己卯", "城头土");
            NAYIN.Add("己酉", "大驿土");
            NAYIN.Add("辛巳", "白蜡金");
            NAYIN.Add("辛亥", "钗钏金");
            NAYIN.Add("癸未", "杨柳木");
            NAYIN.Add("癸丑", "桑柘木");
            NAYIN.Add("乙酉", "泉中水");
            NAYIN.Add("乙卯", "大溪水");
            NAYIN.Add("丁亥", "屋上土");
            NAYIN.Add("丁巳", "沙中土");
            NAYIN.Add("己丑", "霹雳火");
            NAYIN.Add("己未", "天上火");
            NAYIN.Add("辛卯", "松柏木");
            NAYIN.Add("辛酉", "石榴木");
            NAYIN.Add("癸巳", "长流水");
            NAYIN.Add("癸亥", "大海水");

            SHI_SHEN_GAN.Add("甲甲", "比肩");
            SHI_SHEN_GAN.Add("甲乙", "劫财");
            SHI_SHEN_GAN.Add("甲丙", "食神");
            SHI_SHEN_GAN.Add("甲丁", "伤官");
            SHI_SHEN_GAN.Add("甲戊", "偏财");
            SHI_SHEN_GAN.Add("甲己", "正财");
            SHI_SHEN_GAN.Add("甲庚", "七杀");
            SHI_SHEN_GAN.Add("甲辛", "正官");
            SHI_SHEN_GAN.Add("甲壬", "偏印");
            SHI_SHEN_GAN.Add("甲癸", "正印");
            SHI_SHEN_GAN.Add("乙乙", "比肩");
            SHI_SHEN_GAN.Add("乙甲", "劫财");
            SHI_SHEN_GAN.Add("乙丁", "食神");
            SHI_SHEN_GAN.Add("乙丙", "伤官");
            SHI_SHEN_GAN.Add("乙己", "偏财");
            SHI_SHEN_GAN.Add("乙戊", "正财");
            SHI_SHEN_GAN.Add("乙辛", "七杀");
            SHI_SHEN_GAN.Add("乙庚", "正官");
            SHI_SHEN_GAN.Add("乙癸", "偏印");
            SHI_SHEN_GAN.Add("乙壬", "正印");
            SHI_SHEN_GAN.Add("丙丙", "比肩");
            SHI_SHEN_GAN.Add("丙丁", "劫财");
            SHI_SHEN_GAN.Add("丙戊", "食神");
            SHI_SHEN_GAN.Add("丙己", "伤官");
            SHI_SHEN_GAN.Add("丙庚", "偏财");
            SHI_SHEN_GAN.Add("丙辛", "正财");
            SHI_SHEN_GAN.Add("丙壬", "七杀");
            SHI_SHEN_GAN.Add("丙癸", "正官");
            SHI_SHEN_GAN.Add("丙甲", "偏印");
            SHI_SHEN_GAN.Add("丙乙", "正印");
            SHI_SHEN_GAN.Add("丁丁", "比肩");
            SHI_SHEN_GAN.Add("丁丙", "劫财");
            SHI_SHEN_GAN.Add("丁己", "食神");
            SHI_SHEN_GAN.Add("丁戊", "伤官");
            SHI_SHEN_GAN.Add("丁辛", "偏财");
            SHI_SHEN_GAN.Add("丁庚", "正财");
            SHI_SHEN_GAN.Add("丁癸", "七杀");
            SHI_SHEN_GAN.Add("丁壬", "正官");
            SHI_SHEN_GAN.Add("丁乙", "偏印");
            SHI_SHEN_GAN.Add("丁甲", "正印");
            SHI_SHEN_GAN.Add("戊戊", "比肩");
            SHI_SHEN_GAN.Add("戊己", "劫财");
            SHI_SHEN_GAN.Add("戊庚", "食神");
            SHI_SHEN_GAN.Add("戊辛", "伤官");
            SHI_SHEN_GAN.Add("戊壬", "偏财");
            SHI_SHEN_GAN.Add("戊癸", "正财");
            SHI_SHEN_GAN.Add("戊甲", "七杀");
            SHI_SHEN_GAN.Add("戊乙", "正官");
            SHI_SHEN_GAN.Add("戊丙", "偏印");
            SHI_SHEN_GAN.Add("戊丁", "正印");
            SHI_SHEN_GAN.Add("己己", "比肩");
            SHI_SHEN_GAN.Add("己戊", "劫财");
            SHI_SHEN_GAN.Add("己辛", "食神");
            SHI_SHEN_GAN.Add("己庚", "伤官");
            SHI_SHEN_GAN.Add("己癸", "偏财");
            SHI_SHEN_GAN.Add("己壬", "正财");
            SHI_SHEN_GAN.Add("己乙", "七杀");
            SHI_SHEN_GAN.Add("己甲", "正官");
            SHI_SHEN_GAN.Add("己丁", "偏印");
            SHI_SHEN_GAN.Add("己丙", "正印");
            SHI_SHEN_GAN.Add("庚庚", "比肩");
            SHI_SHEN_GAN.Add("庚辛", "劫财");
            SHI_SHEN_GAN.Add("庚壬", "食神");
            SHI_SHEN_GAN.Add("庚癸", "伤官");
            SHI_SHEN_GAN.Add("庚甲", "偏财");
            SHI_SHEN_GAN.Add("庚乙", "正财");
            SHI_SHEN_GAN.Add("庚丙", "七杀");
            SHI_SHEN_GAN.Add("庚丁", "正官");
            SHI_SHEN_GAN.Add("庚戊", "偏印");
            SHI_SHEN_GAN.Add("庚己", "正印");
            SHI_SHEN_GAN.Add("辛辛", "比肩");
            SHI_SHEN_GAN.Add("辛庚", "劫财");
            SHI_SHEN_GAN.Add("辛癸", "食神");
            SHI_SHEN_GAN.Add("辛壬", "伤官");
            SHI_SHEN_GAN.Add("辛乙", "偏财");
            SHI_SHEN_GAN.Add("辛甲", "正财");
            SHI_SHEN_GAN.Add("辛丁", "七杀");
            SHI_SHEN_GAN.Add("辛丙", "正官");
            SHI_SHEN_GAN.Add("辛己", "偏印");
            SHI_SHEN_GAN.Add("辛戊", "正印");
            SHI_SHEN_GAN.Add("壬壬", "比肩");
            SHI_SHEN_GAN.Add("壬癸", "劫财");
            SHI_SHEN_GAN.Add("壬甲", "食神");
            SHI_SHEN_GAN.Add("壬乙", "伤官");
            SHI_SHEN_GAN.Add("壬丙", "偏财");
            SHI_SHEN_GAN.Add("壬丁", "正财");
            SHI_SHEN_GAN.Add("壬戊", "七杀");
            SHI_SHEN_GAN.Add("壬己", "正官");
            SHI_SHEN_GAN.Add("壬庚", "偏印");
            SHI_SHEN_GAN.Add("壬辛", "正印");
            SHI_SHEN_GAN.Add("癸癸", "比肩");
            SHI_SHEN_GAN.Add("癸壬", "劫财");
            SHI_SHEN_GAN.Add("癸乙", "食神");
            SHI_SHEN_GAN.Add("癸甲", "伤官");
            SHI_SHEN_GAN.Add("癸丁", "偏财");
            SHI_SHEN_GAN.Add("癸丙", "正财");
            SHI_SHEN_GAN.Add("癸己", "七杀");
            SHI_SHEN_GAN.Add("癸戊", "正官");
            SHI_SHEN_GAN.Add("癸辛", "偏印");
            SHI_SHEN_GAN.Add("癸庚", "正印");

            SHI_SHEN_ZHI.Add("甲子癸", "正印");
            SHI_SHEN_ZHI.Add("甲丑癸", "正印");
            SHI_SHEN_ZHI.Add("甲丑己", "正财");
            SHI_SHEN_ZHI.Add("甲丑辛", "正官");
            SHI_SHEN_ZHI.Add("甲寅丙", "食神");
            SHI_SHEN_ZHI.Add("甲寅甲", "比肩");
            SHI_SHEN_ZHI.Add("甲寅戊", "偏财");
            SHI_SHEN_ZHI.Add("甲卯乙", "劫财");
            SHI_SHEN_ZHI.Add("甲辰乙", "劫财");
            SHI_SHEN_ZHI.Add("甲辰戊", "偏财");
            SHI_SHEN_ZHI.Add("甲辰癸", "正印");
            SHI_SHEN_ZHI.Add("甲巳戊", "偏财");
            SHI_SHEN_ZHI.Add("甲巳丙", "食神");
            SHI_SHEN_ZHI.Add("甲巳庚", "七杀");
            SHI_SHEN_ZHI.Add("甲午丁", "伤官");
            SHI_SHEN_ZHI.Add("甲午己", "正财");
            SHI_SHEN_ZHI.Add("甲未乙", "劫财");
            SHI_SHEN_ZHI.Add("甲未己", "正财");
            SHI_SHEN_ZHI.Add("甲未丁", "伤官");
            SHI_SHEN_ZHI.Add("甲申戊", "偏财");
            SHI_SHEN_ZHI.Add("甲申庚", "七杀");
            SHI_SHEN_ZHI.Add("甲申壬", "偏印");
            SHI_SHEN_ZHI.Add("甲酉辛", "正官");
            SHI_SHEN_ZHI.Add("甲戌辛", "正官");
            SHI_SHEN_ZHI.Add("甲戌戊", "偏财");
            SHI_SHEN_ZHI.Add("甲戌丁", "伤官");
            SHI_SHEN_ZHI.Add("甲亥壬", "偏印");
            SHI_SHEN_ZHI.Add("甲亥甲", "比肩");
            SHI_SHEN_ZHI.Add("乙子癸", "偏印");
            SHI_SHEN_ZHI.Add("乙丑癸", "偏印");
            SHI_SHEN_ZHI.Add("乙丑己", "偏财");
            SHI_SHEN_ZHI.Add("乙丑辛", "七杀");
            SHI_SHEN_ZHI.Add("乙寅丙", "伤官");
            SHI_SHEN_ZHI.Add("乙寅甲", "劫财");
            SHI_SHEN_ZHI.Add("乙寅戊", "正财");
            SHI_SHEN_ZHI.Add("乙卯乙", "比肩");
            SHI_SHEN_ZHI.Add("乙辰乙", "比肩");
            SHI_SHEN_ZHI.Add("乙辰戊", "正财");
            SHI_SHEN_ZHI.Add("乙辰癸", "偏印");
            SHI_SHEN_ZHI.Add("乙巳戊", "正财");
            SHI_SHEN_ZHI.Add("乙巳丙", "伤官");
            SHI_SHEN_ZHI.Add("乙巳庚", "正官");
            SHI_SHEN_ZHI.Add("乙午丁", "食神");
            SHI_SHEN_ZHI.Add("乙午己", "偏财");
            SHI_SHEN_ZHI.Add("乙未乙", "比肩");
            SHI_SHEN_ZHI.Add("乙未己", "偏财");
            SHI_SHEN_ZHI.Add("乙未丁", "食神");
            SHI_SHEN_ZHI.Add("乙申戊", "正财");
            SHI_SHEN_ZHI.Add("乙申庚", "正官");
            SHI_SHEN_ZHI.Add("乙申壬", "正印");
            SHI_SHEN_ZHI.Add("乙酉辛", "七杀");
            SHI_SHEN_ZHI.Add("乙戌辛", "七杀");
            SHI_SHEN_ZHI.Add("乙戌戊", "正财");
            SHI_SHEN_ZHI.Add("乙戌丁", "食神");
            SHI_SHEN_ZHI.Add("乙亥壬", "正印");
            SHI_SHEN_ZHI.Add("乙亥甲", "劫财");
            SHI_SHEN_ZHI.Add("丙子癸", "正官");
            SHI_SHEN_ZHI.Add("丙丑癸", "正官");
            SHI_SHEN_ZHI.Add("丙丑己", "伤官");
            SHI_SHEN_ZHI.Add("丙丑辛", "正财");
            SHI_SHEN_ZHI.Add("丙寅丙", "比肩");
            SHI_SHEN_ZHI.Add("丙寅甲", "偏印");
            SHI_SHEN_ZHI.Add("丙寅戊", "食神");
            SHI_SHEN_ZHI.Add("丙卯乙", "正印");
            SHI_SHEN_ZHI.Add("丙辰乙", "正印");
            SHI_SHEN_ZHI.Add("丙辰戊", "食神");
            SHI_SHEN_ZHI.Add("丙辰癸", "正官");
            SHI_SHEN_ZHI.Add("丙巳戊", "食神");
            SHI_SHEN_ZHI.Add("丙巳丙", "比肩");
            SHI_SHEN_ZHI.Add("丙巳庚", "偏财");
            SHI_SHEN_ZHI.Add("丙午丁", "劫财");
            SHI_SHEN_ZHI.Add("丙午己", "伤官");
            SHI_SHEN_ZHI.Add("丙未乙", "正印");
            SHI_SHEN_ZHI.Add("丙未己", "伤官");
            SHI_SHEN_ZHI.Add("丙未丁", "劫财");
            SHI_SHEN_ZHI.Add("丙申戊", "食神");
            SHI_SHEN_ZHI.Add("丙申庚", "偏财");
            SHI_SHEN_ZHI.Add("丙申壬", "七杀");
            SHI_SHEN_ZHI.Add("丙酉辛", "正财");
            SHI_SHEN_ZHI.Add("丙戌辛", "正财");
            SHI_SHEN_ZHI.Add("丙戌戊", "食神");
            SHI_SHEN_ZHI.Add("丙戌丁", "劫财");
            SHI_SHEN_ZHI.Add("丙亥壬", "七杀");
            SHI_SHEN_ZHI.Add("丙亥甲", "偏印");
            SHI_SHEN_ZHI.Add("丁子癸", "七杀");
            SHI_SHEN_ZHI.Add("丁丑癸", "七杀");
            SHI_SHEN_ZHI.Add("丁丑己", "食神");
            SHI_SHEN_ZHI.Add("丁丑辛", "偏财");
            SHI_SHEN_ZHI.Add("丁寅丙", "劫财");
            SHI_SHEN_ZHI.Add("丁寅甲", "正印");
            SHI_SHEN_ZHI.Add("丁寅戊", "伤官");
            SHI_SHEN_ZHI.Add("丁卯乙", "偏印");
            SHI_SHEN_ZHI.Add("丁辰乙", "偏印");
            SHI_SHEN_ZHI.Add("丁辰戊", "伤官");
            SHI_SHEN_ZHI.Add("丁辰癸", "七杀");
            SHI_SHEN_ZHI.Add("丁巳戊", "伤官");
            SHI_SHEN_ZHI.Add("丁巳丙", "劫财");
            SHI_SHEN_ZHI.Add("丁巳庚", "正财");
            SHI_SHEN_ZHI.Add("丁午丁", "比肩");
            SHI_SHEN_ZHI.Add("丁午己", "食神");
            SHI_SHEN_ZHI.Add("丁未乙", "偏印");
            SHI_SHEN_ZHI.Add("丁未己", "食神");
            SHI_SHEN_ZHI.Add("丁未丁", "比肩");
            SHI_SHEN_ZHI.Add("丁申戊", "伤官");
            SHI_SHEN_ZHI.Add("丁申庚", "正财");
            SHI_SHEN_ZHI.Add("丁申壬", "正官");
            SHI_SHEN_ZHI.Add("丁酉辛", "偏财");
            SHI_SHEN_ZHI.Add("丁戌辛", "偏财");
            SHI_SHEN_ZHI.Add("丁戌戊", "伤官");
            SHI_SHEN_ZHI.Add("丁戌丁", "比肩");
            SHI_SHEN_ZHI.Add("丁亥壬", "正官");
            SHI_SHEN_ZHI.Add("丁亥甲", "正印");
            SHI_SHEN_ZHI.Add("戊子癸", "正财");
            SHI_SHEN_ZHI.Add("戊丑癸", "正财");
            SHI_SHEN_ZHI.Add("戊丑己", "劫财");
            SHI_SHEN_ZHI.Add("戊丑辛", "伤官");
            SHI_SHEN_ZHI.Add("戊寅丙", "偏印");
            SHI_SHEN_ZHI.Add("戊寅甲", "七杀");
            SHI_SHEN_ZHI.Add("戊寅戊", "比肩");
            SHI_SHEN_ZHI.Add("戊卯乙", "正官");
            SHI_SHEN_ZHI.Add("戊辰乙", "正官");
            SHI_SHEN_ZHI.Add("戊辰戊", "比肩");
            SHI_SHEN_ZHI.Add("戊辰癸", "正财");
            SHI_SHEN_ZHI.Add("戊巳戊", "比肩");
            SHI_SHEN_ZHI.Add("戊巳丙", "偏印");
            SHI_SHEN_ZHI.Add("戊巳庚", "食神");
            SHI_SHEN_ZHI.Add("戊午丁", "正印");
            SHI_SHEN_ZHI.Add("戊午己", "劫财");
            SHI_SHEN_ZHI.Add("戊未乙", "正官");
            SHI_SHEN_ZHI.Add("戊未己", "劫财");
            SHI_SHEN_ZHI.Add("戊未丁", "正印");
            SHI_SHEN_ZHI.Add("戊申戊", "比肩");
            SHI_SHEN_ZHI.Add("戊申庚", "食神");
            SHI_SHEN_ZHI.Add("戊申壬", "偏财");
            SHI_SHEN_ZHI.Add("戊酉辛", "伤官");
            SHI_SHEN_ZHI.Add("戊戌辛", "伤官");
            SHI_SHEN_ZHI.Add("戊戌戊", "比肩");
            SHI_SHEN_ZHI.Add("戊戌丁", "正印");
            SHI_SHEN_ZHI.Add("戊亥壬", "偏财");
            SHI_SHEN_ZHI.Add("戊亥甲", "七杀");
            SHI_SHEN_ZHI.Add("己子癸", "偏财");
            SHI_SHEN_ZHI.Add("己丑癸", "偏财");
            SHI_SHEN_ZHI.Add("己丑己", "比肩");
            SHI_SHEN_ZHI.Add("己丑辛", "食神");
            SHI_SHEN_ZHI.Add("己寅丙", "正印");
            SHI_SHEN_ZHI.Add("己寅甲", "正官");
            SHI_SHEN_ZHI.Add("己寅戊", "劫财");
            SHI_SHEN_ZHI.Add("己卯乙", "七杀");
            SHI_SHEN_ZHI.Add("己辰乙", "七杀");
            SHI_SHEN_ZHI.Add("己辰戊", "劫财");
            SHI_SHEN_ZHI.Add("己辰癸", "偏财");
            SHI_SHEN_ZHI.Add("己巳戊", "劫财");
            SHI_SHEN_ZHI.Add("己巳丙", "正印");
            SHI_SHEN_ZHI.Add("己巳庚", "伤官");
            SHI_SHEN_ZHI.Add("己午丁", "偏印");
            SHI_SHEN_ZHI.Add("己午己", "比肩");
            SHI_SHEN_ZHI.Add("己未乙", "七杀");
            SHI_SHEN_ZHI.Add("己未己", "比肩");
            SHI_SHEN_ZHI.Add("己未丁", "偏印");
            SHI_SHEN_ZHI.Add("己申戊", "劫财");
            SHI_SHEN_ZHI.Add("己申庚", "伤官");
            SHI_SHEN_ZHI.Add("己申壬", "正财");
            SHI_SHEN_ZHI.Add("己酉辛", "食神");
            SHI_SHEN_ZHI.Add("己戌辛", "食神");
            SHI_SHEN_ZHI.Add("己戌戊", "劫财");
            SHI_SHEN_ZHI.Add("己戌丁", "偏印");
            SHI_SHEN_ZHI.Add("己亥壬", "正财");
            SHI_SHEN_ZHI.Add("己亥甲", "正官");
            SHI_SHEN_ZHI.Add("庚子癸", "伤官");
            SHI_SHEN_ZHI.Add("庚丑癸", "伤官");
            SHI_SHEN_ZHI.Add("庚丑己", "正印");
            SHI_SHEN_ZHI.Add("庚丑辛", "劫财");
            SHI_SHEN_ZHI.Add("庚寅丙", "七杀");
            SHI_SHEN_ZHI.Add("庚寅甲", "偏财");
            SHI_SHEN_ZHI.Add("庚寅戊", "偏印");
            SHI_SHEN_ZHI.Add("庚卯乙", "正财");
            SHI_SHEN_ZHI.Add("庚辰乙", "正财");
            SHI_SHEN_ZHI.Add("庚辰戊", "偏印");
            SHI_SHEN_ZHI.Add("庚辰癸", "伤官");
            SHI_SHEN_ZHI.Add("庚巳戊", "偏印");
            SHI_SHEN_ZHI.Add("庚巳丙", "七杀");
            SHI_SHEN_ZHI.Add("庚巳庚", "比肩");
            SHI_SHEN_ZHI.Add("庚午丁", "正官");
            SHI_SHEN_ZHI.Add("庚午己", "正印");
            SHI_SHEN_ZHI.Add("庚未乙", "正财");
            SHI_SHEN_ZHI.Add("庚未己", "正印");
            SHI_SHEN_ZHI.Add("庚未丁", "正官");
            SHI_SHEN_ZHI.Add("庚申戊", "偏印");
            SHI_SHEN_ZHI.Add("庚申庚", "比肩");
            SHI_SHEN_ZHI.Add("庚申壬", "食神");
            SHI_SHEN_ZHI.Add("庚酉辛", "劫财");
            SHI_SHEN_ZHI.Add("庚戌辛", "劫财");
            SHI_SHEN_ZHI.Add("庚戌戊", "偏印");
            SHI_SHEN_ZHI.Add("庚戌丁", "正官");
            SHI_SHEN_ZHI.Add("庚亥壬", "食神");
            SHI_SHEN_ZHI.Add("庚亥甲", "偏财");
            SHI_SHEN_ZHI.Add("辛子癸", "食神");
            SHI_SHEN_ZHI.Add("辛丑癸", "食神");
            SHI_SHEN_ZHI.Add("辛丑己", "偏印");
            SHI_SHEN_ZHI.Add("辛丑辛", "比肩");
            SHI_SHEN_ZHI.Add("辛寅丙", "正官");
            SHI_SHEN_ZHI.Add("辛寅甲", "正财");
            SHI_SHEN_ZHI.Add("辛寅戊", "正印");
            SHI_SHEN_ZHI.Add("辛卯乙", "偏财");
            SHI_SHEN_ZHI.Add("辛辰乙", "偏财");
            SHI_SHEN_ZHI.Add("辛辰戊", "正印");
            SHI_SHEN_ZHI.Add("辛辰癸", "食神");
            SHI_SHEN_ZHI.Add("辛巳戊", "正印");
            SHI_SHEN_ZHI.Add("辛巳丙", "正官");
            SHI_SHEN_ZHI.Add("辛巳庚", "劫财");
            SHI_SHEN_ZHI.Add("辛午丁", "七杀");
            SHI_SHEN_ZHI.Add("辛午己", "偏印");
            SHI_SHEN_ZHI.Add("辛未乙", "偏财");
            SHI_SHEN_ZHI.Add("辛未己", "偏印");
            SHI_SHEN_ZHI.Add("辛未丁", "七杀");
            SHI_SHEN_ZHI.Add("辛申戊", "正印");
            SHI_SHEN_ZHI.Add("辛申庚", "劫财");
            SHI_SHEN_ZHI.Add("辛申壬", "伤官");
            SHI_SHEN_ZHI.Add("辛酉辛", "比肩");
            SHI_SHEN_ZHI.Add("辛戌辛", "比肩");
            SHI_SHEN_ZHI.Add("辛戌戊", "正印");
            SHI_SHEN_ZHI.Add("辛戌丁", "七杀");
            SHI_SHEN_ZHI.Add("辛亥壬", "伤官");
            SHI_SHEN_ZHI.Add("辛亥甲", "正财");
            SHI_SHEN_ZHI.Add("壬子癸", "劫财");
            SHI_SHEN_ZHI.Add("壬丑癸", "劫财");
            SHI_SHEN_ZHI.Add("壬丑己", "正官");
            SHI_SHEN_ZHI.Add("壬丑辛", "正印");
            SHI_SHEN_ZHI.Add("壬寅丙", "偏财");
            SHI_SHEN_ZHI.Add("壬寅甲", "食神");
            SHI_SHEN_ZHI.Add("壬寅戊", "七杀");
            SHI_SHEN_ZHI.Add("壬卯乙", "伤官");
            SHI_SHEN_ZHI.Add("壬辰乙", "伤官");
            SHI_SHEN_ZHI.Add("壬辰戊", "七杀");
            SHI_SHEN_ZHI.Add("壬辰癸", "劫财");
            SHI_SHEN_ZHI.Add("壬巳戊", "七杀");
            SHI_SHEN_ZHI.Add("壬巳丙", "偏财");
            SHI_SHEN_ZHI.Add("壬巳庚", "偏印");
            SHI_SHEN_ZHI.Add("壬午丁", "正财");
            SHI_SHEN_ZHI.Add("壬午己", "正官");
            SHI_SHEN_ZHI.Add("壬未乙", "伤官");
            SHI_SHEN_ZHI.Add("壬未己", "正官");
            SHI_SHEN_ZHI.Add("壬未丁", "正财");
            SHI_SHEN_ZHI.Add("壬申戊", "七杀");
            SHI_SHEN_ZHI.Add("壬申庚", "偏印");
            SHI_SHEN_ZHI.Add("壬申壬", "比肩");
            SHI_SHEN_ZHI.Add("壬酉辛", "正印");
            SHI_SHEN_ZHI.Add("壬戌辛", "正印");
            SHI_SHEN_ZHI.Add("壬戌戊", "七杀");
            SHI_SHEN_ZHI.Add("壬戌丁", "正财");
            SHI_SHEN_ZHI.Add("壬亥壬", "比肩");
            SHI_SHEN_ZHI.Add("壬亥甲", "食神");
            SHI_SHEN_ZHI.Add("癸子癸", "比肩");
            SHI_SHEN_ZHI.Add("癸丑癸", "比肩");
            SHI_SHEN_ZHI.Add("癸丑己", "七杀");
            SHI_SHEN_ZHI.Add("癸丑辛", "偏印");
            SHI_SHEN_ZHI.Add("癸寅丙", "正财");
            SHI_SHEN_ZHI.Add("癸寅甲", "伤官");
            SHI_SHEN_ZHI.Add("癸寅戊", "正官");
            SHI_SHEN_ZHI.Add("癸卯乙", "食神");
            SHI_SHEN_ZHI.Add("癸辰乙", "食神");
            SHI_SHEN_ZHI.Add("癸辰戊", "正官");
            SHI_SHEN_ZHI.Add("癸辰癸", "比肩");
            SHI_SHEN_ZHI.Add("癸巳戊", "正官");
            SHI_SHEN_ZHI.Add("癸巳丙", "正财");
            SHI_SHEN_ZHI.Add("癸巳庚", "正印");
            SHI_SHEN_ZHI.Add("癸午丁", "偏财");
            SHI_SHEN_ZHI.Add("癸午己", "七杀");
            SHI_SHEN_ZHI.Add("癸未乙", "食神");
            SHI_SHEN_ZHI.Add("癸未己", "七杀");
            SHI_SHEN_ZHI.Add("癸未丁", "偏财");
            SHI_SHEN_ZHI.Add("癸申戊", "正官");
            SHI_SHEN_ZHI.Add("癸申庚", "正印");
            SHI_SHEN_ZHI.Add("癸申壬", "劫财");
            SHI_SHEN_ZHI.Add("癸酉辛", "偏印");
            SHI_SHEN_ZHI.Add("癸戌辛", "偏印");
            SHI_SHEN_ZHI.Add("癸戌戊", "正官");
            SHI_SHEN_ZHI.Add("癸戌丁", "偏财");
            SHI_SHEN_ZHI.Add("癸亥壬", "劫财");
            SHI_SHEN_ZHI.Add("癸亥甲", "伤官");

            ZHI_HIDE_GAN.Add("子", new List<string>(new string[] { "癸" }));
            ZHI_HIDE_GAN.Add("丑", new List<string>(new string[] { "己", "癸", "辛" }));
            ZHI_HIDE_GAN.Add("寅", new List<string>(new string[] { "甲", "丙", "戊" }));
            ZHI_HIDE_GAN.Add("卯", new List<string>(new string[] { "乙" }));
            ZHI_HIDE_GAN.Add("辰", new List<string>(new string[] { "戊", "乙", "癸" }));
            ZHI_HIDE_GAN.Add("巳", new List<string>(new string[] { "丙", "庚", "戊" }));
            ZHI_HIDE_GAN.Add("午", new List<string>(new string[] { "丁", "己" }));
            ZHI_HIDE_GAN.Add("未", new List<string>(new string[] { "己", "丁", "乙" }));
            ZHI_HIDE_GAN.Add("申", new List<string>(new string[] { "庚", "壬", "戊" }));
            ZHI_HIDE_GAN.Add("酉", new List<string>(new string[] { "辛" }));
            ZHI_HIDE_GAN.Add("戌", new List<string>(new string[] { "戊", "辛", "丁" }));
            ZHI_HIDE_GAN.Add("亥", new List<string>(new string[] { "壬", "甲" }));
        }

        /// <summary>
        /// 计算指定日期距离基准日期的天数
        /// </summary>
        /// <param name="year">农历年</param>
        /// <param name="month">农历月</param>
        /// <param name="day">农历日</param>
        /// <returns>距离天数</returns>
        public static int computeAddDays(int year, int month, int day)
        {
            int y = BASE_YEAR;
            int m = BASE_MONTH;
            int diff = getDaysOfMonth(y, m) - BASE_DAY;
            m = nextMonth(y, m);
            while (true)
            {
                diff += getDaysOfMonth(y, m);
                m = nextMonth(y, m);
                if (m == 1)
                {
                    y++;
                }
                if (y == year && m == month)
                {
                    diff += day;
                    break;
                }
            }
            return diff;
        }

        /// <summary>
        /// 获取指定年份的闰月
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns>闰月数字，1代表闰1月，0代表无闰月</returns>
        public static int getLeapMonth(int year)
        {
            int index = year - BASE_YEAR + BASE_INDEX;
            int v = LUNAR_MONTH[2 * index + 1];
            v = (v >> 4) & 0x0F;
            return v;
        }

        /// <summary>
        /// 获取指定年月的下一个月是第几月
        /// </summary>
        /// <param name="y">农历年</param>
        /// <param name="m">农历月，闰月为负数</param>
        /// <returns>1到12，闰月为负数</returns>
        public static int nextMonth(int y, int m)
        {
            int n = Math.Abs(m) + 1;
            if (m > 0)
            {
                int index = y - BASE_YEAR + BASE_INDEX;
                int v = LUNAR_MONTH[2 * index + 1];
                v = (v >> 4) & 0x0F;
                if (v == m)
                {
                    n = -m;
                }
            }
            if (n == 13)
            {
                n = 1;
            }
            return n;
        }

        /// <summary>
        /// 获取某年某月有多少天
        /// </summary>
        /// <param name="year">农历年</param>
        /// <param name="month">农历月，闰月为负数</param>
        /// <returns>天数</returns>
        public static int getDaysOfMonth(int year, int month)
        {
            int index = year - BASE_YEAR + BASE_INDEX;
            int v, l, d = 30;
            if (1 <= month && month <= 8)
            {
                v = LUNAR_MONTH[2 * index];
                l = month - 1;
                if (((v >> l) & 0x01) == 1)
                {
                    d = 29;
                }
            }
            else if (9 <= month && month <= 12)
            {
                v = LUNAR_MONTH[2 * index + 1];
                l = month - 9;
                if (((v >> l) & 0x01) == 1)
                {
                    d = 29;
                }
            }
            else
            {
                v = LUNAR_MONTH[2 * index + 1];
                v = (v >> 4) & 0x0F;
                if (v != Math.Abs(month))
                {
                    d = 0;
                }
                else
                {
                    d = 29;
                    foreach (int i in LEAP_MONTH_YEAR)
                    {
                        if (i == index)
                        {
                            d = 30;
                            break;
                        }
                    }
                }
            }
            return d;
        }

        /// <summary>
        /// 获取HH:mm时刻的地支序号，非法的时刻返回0
        /// </summary>
        /// <param name="hm">HH:mm时刻</param>
        /// <returns>地支序号，0到11</returns>
        public static int getTimeZhiIndex(string hm)
        {
            if (null == hm)
            {
                return 0;
            }
            if (hm.Length > 5)
            {
                hm = hm.Substring(0, 5);
            }
            int x = 1;
            for (int i = 1; i < 22; i += 2)
            {
                if (hm.CompareTo((i < 10 ? "0" : "") + i + ":00") >= 0 && hm.CompareTo((i + 1 < 10 ? "0" : "") + (i + 1) + ":59") <= 0)
                {
                    return x;
                }
                x++;
            }
            return 0;
        }

        /// <summary>
        /// 将HH:mm时刻转换为时辰（地支），非法的时刻返回子
        /// </summary>
        /// <param name="hm">HH:mm时刻</param>
        /// <returns>时辰(地支)，如子</returns>
        public static string convertTime(string hm)
        {
            return ZHI[getTimeZhiIndex(hm) + 1];
        }
    }
}
