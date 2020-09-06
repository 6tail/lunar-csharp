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

        public JieQi()
        {
        }

        public JieQi(string name, Solar solar)
        {
            this.name = name;
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

    }

}
