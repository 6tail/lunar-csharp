// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Lunar
{
    /// <summary>
    /// 节气
    /// </summary>
    public sealed class JieQi
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 阳历日期
        /// </summary>
        public Solar Solar { get; }

        /// <summary>
        /// 是否节令
        /// </summary>
        public bool Jie { get; }

        /// <summary>
        /// 是否气令
        /// </summary>
        public bool Qi { get; }
        
        /// <summary>
        /// 创建节气
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="solar">阳历日期</param>
        internal JieQi(string name, Solar solar)
        {
            for (int i = 0, j = Lunar.JIE_QI.Count; i < j; i++)
            {
                if (!name.Equals(Lunar.JIE_QI[i]))
                    continue;
                if (i % 2 == 0)
                {
                    Qi = true;
                }
                else
                {
                    Jie = true;
                }
                break;
            }

            Name = name;
            Solar = solar;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Name;
        }
    }
}