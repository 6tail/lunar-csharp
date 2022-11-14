using Lunar.Util;
// ReSharper disable IdentifierTypo
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Lunar.EightChar
{
    /// <summary>
    /// 小运
    /// </summary>
    public class XiaoYun
    {
        /// <summary>
        /// 序数，0-9
        /// </summary>
        public int Index { get; }

        /// <summary>
        /// 大运
        /// </summary>
        public DaYun DaYun { get; }

        /// <summary>
        /// 年
        /// </summary>
        public int Year { get; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; }

        /// <summary>
        /// 是否顺推
        /// </summary>
        public bool Forward { get; }

        public Lunar Lunar { get; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="daYun">大运</param>
        /// <param name="index">序数，0-9</param>
        /// <param name="forward">是否顺推</param>
        public XiaoYun(DaYun daYun, int index, bool forward)
        {
            DaYun = daYun;
            Lunar = daYun.Lunar;
            Index = index;
            Year = daYun.StartYear + index;
            Age = daYun.StartAge + index;
            Forward = forward;
        }

        /// <summary>
        /// 干支
        /// </summary>
        public string GanZhi
        {
            get
            {
                var offset = LunarUtil.GetJiaZiIndex(Lunar.TimeInGanZhi);
                var add = Index + 1;
                if (DaYun.Index > 0)
                {
                    add += DaYun.StartAge - 1;
                }
                offset += Forward ? add : -add;
                var size = LunarUtil.JIA_ZI.Length;
                while (offset < 0)
                {
                    offset += size;
                }
                offset %= size;
                return LunarUtil.JIA_ZI[offset];
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
