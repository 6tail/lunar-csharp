using System.Text;
using Lunar.Util;
// ReSharper disable InconsistentNaming
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable IdentifierTypo

namespace Lunar
{
    /// <summary>
    /// 九星
    /// </summary>
    public class NineStar
    {

        /// <summary>
        /// 九数
        /// </summary>
        public static readonly string[] NUMBER = { "一", "二", "三", "四", "五", "六", "七", "八", "九" };

        /// <summary>
        /// 七色
        /// </summary>
        public static readonly string[] COLOR = { "白", "黒", "碧", "绿", "黄", "白", "赤", "白", "紫" };

        /// <summary>
        /// 五行
        /// </summary>
        public static readonly string[] WU_XING = { "水", "土", "木", "木", "土", "金", "金", "土", "火" };

        /// <summary>
        /// 后天八卦方位
        /// </summary>
        public static readonly string[] POSITION = { "坎", "坤", "震", "巽", "中", "乾", "兑", "艮", "离" };

        /// <summary>
        /// 北斗九星
        /// </summary>
        public static readonly string[] NAME_BEI_DOU = { "天枢", "天璇", "天玑", "天权", "玉衡", "开阳", "摇光", "洞明", "隐元" };

        /// <summary>
        /// 玄空九星（玄空风水）
        /// </summary>
        public static readonly string[] NAME_XUAN_KONG = { "贪狼", "巨门", "禄存", "文曲", "廉贞", "武曲", "破军", "左辅", "右弼" };

        /// <summary>
        /// 奇门九星（奇门遁甲，也称天盘九星）
        /// </summary>
        public static readonly string[] NAME_QI_MEN = { "天蓬", "天芮", "天冲", "天辅", "天禽", "天心", "天柱", "天任", "天英" };

        /// <summary>
        /// 八门（奇门遁甲）
        /// </summary>
        public static readonly string[] BA_MEN_QI_MEN = { "休", "死", "伤", "杜", "", "开", "惊", "生", "景" };

        /// <summary>
        /// 太乙九神（太乙神数）
        /// </summary>
        public static readonly string[] NAME_TAI_YI = { "太乙", "摄提", "轩辕", "招摇", "天符", "青龙", "咸池", "太阴", "天乙" };

        /// <summary>
        /// 太乙九神对应类型
        /// </summary>
        public static readonly string[] TYPE_TAI_YI = { "吉神", "凶神", "安神", "安神", "凶神", "吉神", "凶神", "吉神", "吉神" };

        /// <summary>
        /// 太乙九神歌诀（太乙神数）
        /// </summary>
        public static readonly string[] SONG_TAI_YI = { "门中太乙明，星官号贪狼，赌彩财喜旺，婚姻大吉昌，出入无阻挡，参谒见贤良，此行三五里，黑衣别阴阳。", "门前见摄提，百事必忧疑，相生犹自可，相克祸必临，死门并相会，老妇哭悲啼，求谋并吉事，尽皆不相宜，只可藏隐遁，若动伤身疾。", "出入会轩辕，凡事必缠牵，相生全不美，相克更忧煎，远行多不利，博彩尽输钱，九天玄女法，句句不虚言。", "招摇号木星，当之事莫行，相克行人阻，阴人口舌迎，梦寐多惊惧，屋响斧自鸣，阴阳消息理，万法弗违情。", "五鬼为天符，当门阴女谋，相克无好事，行路阻中途，走失难寻觅，道逢有尼姑，此星当门值，万事有灾除。", "神光跃青龙，财气喜重重，投入有酒食，赌彩最兴隆，更逢相生旺，休言克破凶，见贵安营寨，万事总吉同。", "吾将为咸池，当之尽不宜，出入多不利，相克有灾情，赌彩全输尽，求财空手回，仙人真妙语，愚人莫与知，动用虚惊退，反复逆风吹。", "坐临太阴星，百祸不相侵，求谋悉成就，知交有觅寻，回风归来路，恐有殃伏起，密语中记取，慎乎莫轻行。", "迎来天乙星，相逢百事兴，运用和合庆，茶酒喜相迎，求谋并嫁娶，好合有天成，祸福如神验，吉凶甚分明。" };

        /// <summary>
        /// 吉凶（玄空风水）
        /// </summary>
        public static readonly string[] LUCK_XUAN_KONG = { "吉", "凶", "凶", "吉", "凶", "吉", "凶", "吉", "吉" };

        /// <summary>
        /// 吉凶（奇门遁甲）
        /// </summary>
        public static readonly string[] LUCK_QI_MEN = { "大凶", "大凶", "小吉", "大吉", "大吉", "大吉", "小凶", "小吉", "小凶" };

        /// <summary>
        /// 阴阳（奇门遁甲）
        /// </summary>
        public static readonly string[] YIN_YANG_QI_MEN = { "阳", "阴", "阳", "阳", "阳", "阴", "阴", "阳", "阴" };

        /// <summary>
        /// 序号
        /// </summary>
        public int Index { get; }

        /// <summary>
        /// 从序号创建九星
        /// </summary>
        /// <param name="index">序号</param>
        public NineStar(int index)
        {
            Index = index;
        }

        /// <summary>
        /// 从序号创建九星
        /// </summary>
        /// <param name="index">序号</param>
        /// <returns>九星</returns>
        public static NineStar FromIndex(int index)
        {
            return new NineStar(index);
        }

        /// <summary>
        /// 九数
        /// </summary>
        public string Number => NUMBER[Index];

        /// <summary>
        /// 七色
        /// </summary>
        public string Color => COLOR[Index];

        /// <summary>
        /// 五行
        /// </summary>
        public string WuXing => WU_XING[Index];

        /// <summary>
        /// 方位
        /// </summary>
        public string Position => POSITION[Index];

        /// <summary>
        /// 方位描述
        /// </summary>
        public string PositionDesc => LunarUtil.POSITION_DESC[Position];

        /// <summary>
        /// 玄空九星名称
        /// </summary>
        public string NameInXuanKong => NAME_XUAN_KONG[Index];

        /// <summary>
        /// 北斗九星名称
        /// </summary>
        public string NameInBeiDou => NAME_BEI_DOU[Index];

        /// <summary>
        /// 奇门九星名称
        /// </summary>
        public string NameInQiMen => NAME_QI_MEN[Index];

        /// <summary>
        /// 太乙九神名称
        /// </summary>
        public string NameInTaiYi => NAME_TAI_YI[Index];

        /// <summary>
        /// 奇门九星吉凶
        /// </summary>
        public string LuckInQiMen => LUCK_QI_MEN[Index];

        /// <summary>
        /// 玄空九星吉凶
        /// </summary>
        public string LuckInXuanKong => LUCK_XUAN_KONG[Index];

        /// <summary>
        /// 奇门九星阴阳
        /// </summary>
        public string YinYangInQiMen => YIN_YANG_QI_MEN[Index];

        /// <summary>
        /// 太乙九神类型
        /// </summary>
        public string TypeInTaiYi => TYPE_TAI_YI[Index];

        /// <summary>
        /// 八门（奇门遁甲）
        /// </summary>
        public string BaMenInQiMen => BA_MEN_QI_MEN[Index];

        /// <summary>
        /// 太乙九神歌诀
        /// </summary>
        public string SongInTaiYi => SONG_TAI_YI[Index];
    
        /// <inheritdoc />
        public override string ToString()
        {
            return Number + Color + WuXing + NameInBeiDou;
        }

        /// <summary>
        /// 
        /// </summary>
        public string FullString
        {
            get
            {
                var s = new StringBuilder();
                s.Append(Number);
                s.Append(Color);
                s.Append(WuXing);
                s.Append(' ');
                s.Append(Position);
                s.Append('(');
                s.Append(PositionDesc);
                s.Append(") ");
                s.Append(NameInBeiDou);
                s.Append(" 玄空[");
                s.Append(NameInXuanKong);
                s.Append(' ');
                s.Append(LuckInXuanKong);
                s.Append("] 奇门[");
                s.Append(NameInQiMen);
                s.Append(' ');
                s.Append(LuckInQiMen);
                if (BaMenInQiMen.Length > 0)
                {
                    s.Append(' ');
                    s.Append(BaMenInQiMen);
                    s.Append('门');
                }

                s.Append(' ');
                s.Append(YinYangInQiMen);
                s.Append("] 太乙[");
                s.Append(NameInTaiYi);
                s.Append(' ');
                s.Append(TypeInTaiYi);
                s.Append(']');
                return s.ToString();
            }
        }
    }
}