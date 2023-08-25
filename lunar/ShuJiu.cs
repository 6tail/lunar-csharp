// ReSharper disable MemberCanBePrivate.Global
namespace Lunar
{
    /// <summary>
    /// 数九
    /// </summary>
    public class ShuJiu
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
        /// 初始化
        /// </summary>
        public ShuJiu()
        {
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="index">当前数九第几天，1-9</param>
        public ShuJiu(string name, int index)
        {
            Name = name;
            Index = index;
        }

        /// <summary>
        /// 完整字符串输出
        /// </summary>
        public string FullString => Name + "第" + Index + "天";

        /// <inheritdoc />
        public override string ToString()
        {
            return Name;
        }
    }

}
