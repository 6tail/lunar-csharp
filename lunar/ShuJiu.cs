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

        public ShuJiu()
        {
        }

        public ShuJiu(string name, int index)
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
