using com.nlf.calendar.util;

namespace com.nlf.calendar.eightchar
{
    /// <summary>
    /// 大运
    /// </summary>
    public class DaYun
    {
        /// <summary>
        /// 开始年(含)
        /// </summary>
        private int startYear;

        /// <summary>
        /// 结束年(含)
        /// </summary>
        private int endYear;

        /// <summary>
        /// 开始年龄(含)
        /// </summary>
        private int startAge;

        /// <summary>
        /// 结束年龄(含)
        /// </summary>
        private int endAge;

        /// <summary>
        /// 序数，0-9
        /// </summary>
        private int index;

        /// <summary>
        /// 运
        /// </summary>
        private Yun yun;

        private Lunar lunar;

        public DaYun(Yun yun, int index)
        {
            this.yun = yun;
            this.lunar = yun.getLunar();
            this.index = index;
            int year = yun.getStartSolar().getYear();
            if (index < 1)
            {
                this.startYear = lunar.getSolar().getYear();
                this.startAge = 1;
                this.endYear = year - 1;
                this.endAge = yun.getStartYear();
            }
            else
            {
                int add = (index - 1) * 10;
                this.startYear = year + add;
                this.startAge = yun.getStartYear() + add + 1;
                this.endYear = this.startYear + 9;
                this.endAge = this.startAge + 9;
            }
        }

        public int getStartYear()
        {
            return startYear;
        }

        public int getEndYear()
        {
            return endYear;
        }

        public int getStartAge()
        {
            return startAge;
        }

        public int getEndAge()
        {
            return endAge;
        }

        public int getIndex()
        {
            return index;
        }

        public Lunar getLunar()
        {
            return lunar;
        }

        /// <summary>
        /// 获取干支
        /// </summary>
        /// <returns>干支</returns>
        public string getGanZhi()
        {
            if (index < 1)
            {
                return "";
            }
            int offset = LunarUtil.getJiaZiIndex(lunar.getMonthInGanZhiExact());
            offset += yun.isForward() ? index : -index;
            int size = LunarUtil.JIA_ZI.Length;
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

        /// <summary>
        /// 获取流年
        /// </summary>
        /// <returns>流年</returns>
        public LiuNian[] getLiuNian()
        {
            int n = 10;
            if (index < 1)
            {
                n = endYear - startYear + 1;
            }
            LiuNian[] l = new LiuNian[n];
            for (int i = 0; i < n; ++i)
            {
                l[i] = new LiuNian(this, i);
            }
            return l;
        }

        /// <summary>
        /// 获取小运
        /// </summary>
        /// <returns>小运</returns>
        public XiaoYun[] getXiaoYun()
        {
            int n = 10;
            if (index < 1)
            {
                n = endYear - startYear + 1;
            }
            XiaoYun[] l = new XiaoYun[n];
            for (int i = 0; i < n; ++i)
            {
                l[i] = new XiaoYun(this, i, yun.isForward());
            }
            return l;
        }

    }

}
