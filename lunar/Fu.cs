// ReSharper disable MemberCanBePrivate.Global

// TODO: 可访问性调整

namespace Lunar
{
    /// <summary>
    /// 三伏
    /// 从夏至后第3个庚日算起，初伏为10天，中伏为10天或20天，末伏为10天。当夏至与立秋之间出现4个庚日时中伏为10天，出现5个庚日则为20天。
    /// </summary>
    public sealed class Fu
    {
        /// <summary>
        /// 名称：初伏、中伏、末伏
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 当前入伏第几天，1-20
        /// </summary>
        public int Index { get; set; }
        
        /// <summary>
        /// 创建伏
        /// </summary>
        public Fu()
        {
            // TODO: 没有使用过，是否应删除
        }

        /// <summary>
        /// 创建伏
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="index">当前入伏第几天</param>
        public Fu(string name, int index)
        {
            Name = name;
            Index = index;
        }

        /// <summary>
        /// 
        /// </summary>
        public string FullString => Name + "第" + Index + "天";

        /// <inheritdoc />
        public override string ToString()
        {
            return Name;
        }
    }
}