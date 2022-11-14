using Lunar.Util;
// ReSharper disable IdentifierTypo
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Lunar.EightChar
{
    /// <summary>
    /// 大运
    /// </summary>
    public class DaYun
    {
        /// <summary>
        /// 开始年(含)
        /// </summary>
        public int StartYear { get; }

        /// <summary>
        /// 结束年(含)
        /// </summary>
        public int EndYear { get; }

        /// <summary>
        /// 开始年龄(含)
        /// </summary>
        public int StartAge { get; }

        /// <summary>
        /// 结束年龄(含)
        /// </summary>
        public int EndAge { get; }

        /// <summary>
        /// 序数，0-9
        /// </summary>
        public int Index { get; }

        /// <summary>
        /// 运
        /// </summary>
        public Yun Yun { get; }

        public Lunar Lunar { get; }

        public DaYun(Yun yun, int index)
        {
            Yun = yun;
            Lunar = yun.Lunar;
            Index = index;
            var birthYear = Lunar.Solar.Year;
            var year = yun.StartSolar.Year;
            if (index < 1)
            {
                StartYear = birthYear;
                StartAge = 1;
                EndYear = year - 1;
                EndAge = year - birthYear;
            }
            else
            {
                var add = (index - 1) * 10;
                StartYear = year + add;
                StartAge = StartYear - birthYear + 1;
                EndYear = StartYear + 9;
                EndAge = StartAge + 9;
            }
        }

        /// <summary>
        /// 获取干支
        /// </summary>
        /// <returns>干支</returns>
        public string GanZhi
        {
            get
            {
                if (Index < 1)
                {
                    return "";
                }
                var offset = LunarUtil.GetJiaZiIndex(Lunar.MonthInGanZhiExact);
                offset += Yun.Forward ? Index : -Index;
                var size = LunarUtil.JIA_ZI.Length;
                if (offset >= size)
                {
                    offset -= size;
                }
                if (offset < 0)
                {
                    offset += size;
                }
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
        /// 获取流年
        /// </summary>
        /// <param name="n">轮数</param>
        /// <returns>流年</returns>
        public LiuNian[] GetLiuNian(int n = 10)
        {
            if (Index < 1)
            {
                n = EndYear - StartYear + 1;
            }
            var l = new LiuNian[n];
            for (var i = 0; i < n; ++i)
            {
                l[i] = new LiuNian(this, i);
            }
            return l;
        }

        /// <summary>
        /// 获取小运
        /// </summary>
        /// <param name="n">轮数</param>
        /// <returns>小运</returns>
        public XiaoYun[] GetXiaoYun(int n = 10)
        {
            if (Index < 1)
            {
                n = EndYear - StartYear + 1;
            }
            var l = new XiaoYun[n];
            for (var i = 0; i < n; ++i)
            {
                l[i] = new XiaoYun(this, i, Yun.Forward);
            }
            return l;
        }

    }

}
