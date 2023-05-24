using Lunar.Util;
// ReSharper disable IdentifierTypo
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Lunar.EightChar
{
    /// <summary>
    /// 流年
    /// </summary>
    public class LiuNian
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
        /// 农历
        /// </summary>
        public Lunar Lunar { get; }

        /// <summary>
        /// 创建流年
        /// </summary>
        /// <param name="daYun">大运</param>
        /// <param name="index">序数</param>
        public LiuNian(DaYun daYun, int index)
        {
            DaYun = daYun;
            Lunar = daYun.Lunar;
            Index = index;
            Year = daYun.StartYear + index;
            Age = daYun.StartAge + index;
        }

        /// <summary>
        /// 干支
        /// </summary>
        public string GanZhi
        {
            get
            {
                int offset = LunarUtil.GetJiaZiIndex(Lunar.JieQiTable["立春"].Lunar.YearInGanZhiExact) + Index;
                if (DaYun.Index > 0)
                {
                    offset += DaYun.StartAge - 1;
                }
                offset %= LunarUtil.JIA_ZI.Length;
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

        /// <summary>
        /// 获取流月
        /// </summary>
        /// <returns>流月</returns>
        public LiuYue[] GetLiuYue()
        {
            const int n = 12;
            var l = new LiuYue[n];
            for (var i = 0; i < n; i++)
            {
                l[i] = new LiuYue(this, i);
            }
            return l;
        }

    }

}
