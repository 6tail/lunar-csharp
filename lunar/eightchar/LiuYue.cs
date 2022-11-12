using Lunar.Util;
// ReSharper disable IdentifierTypo
// ReSharper disable MemberCanBePrivate.Global

namespace Lunar.EightChar
{
    /// <summary>
    /// 流月
    /// </summary>
    public class LiuYue
    {
        /// <summary>
        /// 序数，0-9
        /// </summary>
        public int Index { get; }

        /// <summary>
        /// 流年
        /// </summary>
        public LiuNian LiuNian { get; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="liuNian">流年</param>
        /// <param name="index">序数，0-9</param>
        public LiuYue(LiuNian liuNian, int index)
        {
            LiuNian = liuNian;
            Index = index;
        }

        /// <summary>
        /// 中文月，如正
        /// </summary>
        public string MonthInChinese => LunarUtil.MONTH[Index + 1];

        /// <summary>
        /// 干支
        /// <p>
        /// 《五虎遁》
        /// 甲己之年丙作首，
        /// 乙庚之年戊为头，
        /// 丙辛之年寻庚上，
        /// 丁壬壬寅顺水流，
        /// 若问戊癸何处走，
        /// 甲寅之上好追求。
        /// </p>
        /// </summary>
        public string GanZhi
        {
            get
            {
                var offset = 0;
                var yearGan = LiuNian.GanZhi[..1];
                switch (yearGan)
                {
                    case "甲":
                    case "己":
                        offset = 2;
                        break;
                    case "乙":
                    case "庚":
                        offset = 4;
                        break;
                    case "丙":
                    case "辛":
                        offset = 6;
                        break;
                    case "丁":
                    case "壬":
                        offset = 8;
                        break;
                }
                var gan = LunarUtil.GAN[(Index + offset) % 10 + 1];
                var zhi = LunarUtil.ZHI[(Index + LunarUtil.BASE_MONTH_ZHI_INDEX) % 12 + 1];
                return gan + zhi;
            }
        }

        /// <summary>
        /// 旬
        /// </summary>
        public string Xun => LunarUtil.GetXun(GanZhi);

        /// <summary>
        /// 旬空(空亡)
        /// </summary>
        public string XunKong => LunarUtil.GetXunKong(GanZhi);

    }

}
