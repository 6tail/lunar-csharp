namespace com.nlf.calendar
{
    /// <summary>
    /// 数九
    /// </summary>
    public class ShuJiu
    {
        /// <summary>
        /// 名称，如一九、二九
        /// </summary>
        private string name;

        /// <summary>
        /// 当前数九第几天，1-9
        /// </summary>
        private int index;

        public ShuJiu()
        {
        }

        public ShuJiu(string name, int index)
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
