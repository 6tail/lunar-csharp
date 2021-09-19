using com.nlf.calendar.util;
namespace com.nlf.calendar
{
    /// <summary>
    /// 节气
    /// </summary>
    public class JieQi
    {
        /// <summary>
        /// 名称
        /// </summary>
        private string name;

        /// <summary>
        /// 阳历日期
        /// </summary>
        private Solar solar;

        /// <summary>
        /// 是否节令
        /// </summary>
        private bool jie;

        /// <summary>
        /// 是否气令
        /// </summary>
        private bool qi;

        public JieQi()
        {
        }

        public JieQi(string name, Solar solar)
        {
            setName(name);
            this.solar = solar;

        }

        /// <summary>
        /// 获取名称
        /// </summary>
        /// <returns>名称</returns>
        public string getName()
        {
            return name;
        }

        /// <summary>
        /// 设置名称
        /// </summary>
        /// <param name="name">名称</param>
        public void setName(string name)
        {
            this.name = name;
            for (int i = 0, j = Lunar.JIE_QI.Length; i < j; i++)
            {
                if (name.Equals(Lunar.JIE_QI[i]))
                {
                    if (i % 2 == 0)
                    {
                        this.qi = true;
                    }
                    else
                    {
                        this.jie = true;
                    }
                    return;
                }
            }
        }

        /// <summary>
        /// 获取阳历日期
        /// </summary>
        /// <returns>阳历日期</returns>
        public Solar getSolar()
        {
            return solar;
        }

        /// <summary>
        /// 设置阳历日期
        /// </summary>
        /// <param name="solar">阳历日期</param>
        public void setSolar(Solar solar)
        {
            this.solar = solar;

        }

        /// <summary>
        /// 是否节令
        /// </summary>
        /// <returns>true/false</returns>
        public bool isJie()
        {
            return jie;
        }

        /// <summary>
        /// 是否气令
        /// </summary>
        /// <returns>true/false</returns>
        public bool isQi()
        {
            return qi;
        }

        public override string ToString()
        {
            return name;
        }

    }

}
