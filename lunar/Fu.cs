namespace Lunar
{
    /// <summary>
    /// 三伏
    /// 从夏至后第3个庚日算起，初伏为10天，中伏为10天或20天，末伏为10天。当夏至与立秋之间出现4个庚日时中伏为10天，出现5个庚日则为20天。
    /// </summary>
    public class Fu
    {
        /// <summary>
        /// 名称：初伏、中伏、末伏
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 当前入伏第几天，1-20
        /// </summary>
        public int Index { get; set; }
        
        public Fu()
        {
        }

        public Fu(string name, int index)
        {
            Name = name;
            Index = index;
        }

        public string FullString => Name + "第" + Index + "天";

        public override string ToString()
        {
            return Name;
        }
    }
}