// ReSharper disable MemberCanBePrivate.Global

// TODO: 可访问性调整

namespace Lunar
{
    /// <summary>
    /// 数九
    /// </summary>
    public sealed class ShuJiu
    {
        /// <summary>
        /// 名称，如一九、二九
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 当前数九第几天，1-9
        /// </summary>
        public int Index { get; }

        /// <summary>
        /// 创建数九
        /// </summary>
        public ShuJiu()
        {
        }

        /// <summary>
        /// 创建数九
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="index">序号</param>
        public ShuJiu(string name, int index)
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
