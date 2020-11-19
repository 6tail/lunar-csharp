using com.nlf.calendar.util;

namespace com.nlf.calendar.eightchar
{
    /// <summary>
    /// 流年
    /// </summary>
    public class LiuNian
    {
        /// <summary>
        /// 序数，0-9
        /// </summary>
        private int index;

        /// <summary>
        /// 大运
        /// </summary>
        private DaYun daYun;

        /// <summary>
        /// 年
        /// </summary>
        private int year;

        /// <summary>
        /// 年龄
        /// </summary>
        private int age;

        private Lunar lunar;

        public LiuNian(DaYun daYun, int index)
        {
            this.daYun = daYun;
            this.lunar = daYun.getLunar();
            this.index = index;
            this.year = daYun.getStartYear() + index;
            this.age = daYun.getStartAge() + index;
        }

        public int getIndex()
        {
            return index;
        }

        public int getYear()
        {
            return year;
        }

        public int getAge()
        {
            return age;
        }

        /// <summary>
        /// 获取干支
        /// </summary>
        /// <returns>干支</returns>
        public string getGanZhi()
        {
            int offset = LunarUtil.getJiaZiIndex(lunar.getYearInGanZhiExact()) + this.index;
            if (daYun.getIndex() > 0)
            {
                offset += daYun.getStartAge() - 1;
            }
            offset %= LunarUtil.JIA_ZI.Length;
            return LunarUtil.JIA_ZI[offset];
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

        /// <summary>
        /// 获取流月
        /// </summary>
        /// <returns>流月</returns>
        public LiuYue[] getLiuYue()
        {
            int n = 12;
            LiuYue[] l = new LiuYue[n];
            for (int i = 0; i < n; i++)
            {
                l[i] = new LiuYue(this, i);
            }
            return l;
        }

    }

}
