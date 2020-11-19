using com.nlf.calendar.util;

namespace com.nlf.calendar.eightchar
{
    /// <summary>
    /// 小运
    /// </summary>
    public class XiaoYun
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

        /// <summary>
        /// 是否顺推
        /// </summary>
        private bool forward;

        private Lunar lunar;

        public XiaoYun(DaYun daYun, int index, bool forward)
        {
            this.daYun = daYun;
            this.lunar = daYun.getLunar();
            this.index = index;
            this.year = daYun.getStartYear() + index;
            this.age = daYun.getStartAge() + index;
            this.forward = forward;
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
            int offset = LunarUtil.getJiaZiIndex(lunar.getTimeInGanZhi());
            int add = this.index + 1;
            if (daYun.getIndex() > 0)
            {
                add += daYun.getStartAge() - 1;
            }
            offset += forward ? add : -add;
            int size = LunarUtil.JIA_ZI.Length;
            while (offset < 0)
            {
                offset += size;
            }
            offset %= size;
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

    }

}
