namespace com.nlf.calendar
{
    /// <summary>
    /// 三伏
    /// </summary>
    /// <summary>
    /// <p>从夏至后第3个庚日算起，初伏为10天，中伏为10天或20天，末伏为10天。当夏至与立秋之间出现4个庚日时中伏为10天，出现5个庚日则为20天。</p>
    /// </summary>
    public class Fu
    {
        /// <summary>
        /// 名称：初伏、中伏、末伏
        /// </summary>
        private string name;

        /// <summary>
        /// 当前入伏第几天，1-20
        /// </summary>
        private int index;

        public Fu()
        {
        }

        public Fu(string name, int index)
        {
            this.name = name;
            this.index = index;

        }

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;

        }

        public int getIndex()
        {
            return index;
        }

        public void setIndex(int index)
        {
            this.index = index;

        }

        public string toString()
        {
            return name;
        }

        public string toFullString()
        {
            return name + "第" + index + "天";
        }

        public override string ToString()
        {
            return toString();
        }
    }

}
