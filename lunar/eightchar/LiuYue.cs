using com.nlf.calendar.util;

namespace com.nlf.calendar.eightchar
{
    /// <summary>
    /// 流月
    /// </summary>
    public class LiuYue
    {
        /// <summary>
        /// 序数，0-9
        /// </summary>
        private int index;

        private LiuNian liuNian;

        public LiuYue(LiuNian liuNian, int index)
        {
            this.liuNian = liuNian;
            this.index = index;
        }

        public int getIndex()
        {
            return index;
        }

        /// <summary>
        /// 获取中文的月
        /// </summary>
        /// <returns>中文月，如正</returns>
        public string getMonthInChinese()
        {
            return LunarUtil.MONTH[index + 1];
        }

        /// <summary>
        /// 获取干支
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
        /// <returns>干支</returns>
        public string getGanZhi()
        {
            int offset = 0;
            string yearGan = liuNian.getGanZhi().Substring(0, 1);
            if ("甲".Equals(yearGan) || "己".Equals(yearGan))
            {
                offset = 2;
            }
            else if ("乙".Equals(yearGan) || "庚".Equals(yearGan))
            {
                offset = 4;
            }
            else if ("丙".Equals(yearGan) || "辛".Equals(yearGan))
            {
                offset = 6;
            }
            else if ("丁".Equals(yearGan) || "壬".Equals(yearGan))
            {
                offset = 8;
            }
            string gan = LunarUtil.GAN[(index + offset) % 10 + 1];
            string zhi = LunarUtil.ZHI[(index + LunarUtil.BASE_MONTH_ZHI_INDEX) % 12 + 1];
            return gan + zhi;
        }

        /// <summary>
        /// 获取所在旬
        /// </summary>
        /// <returns>旬</returns>
        public string getXun()
        {
            return LunarUtil.getXun(getGanZhi());
        }

        /// <summary>
        /// 获取旬空(空亡)
        /// </summary>
        /// <returns>旬空(空亡)</returns>
        public string getXunKong()
        {
            return LunarUtil.getXunKong(getGanZhi());
        }

    }

}
