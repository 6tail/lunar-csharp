﻿// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

// TODO: 可访问性调整

namespace Lunar
{
    /// <summary>
    /// 节气
    /// </summary>
    public sealed class JieQi
    {
        private string _name;
        
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                for (int i = 0, j = Lunar.JIE_QI.Length; i < j; i++)
                {
                    if (!value.Equals(Lunar.JIE_QI[i])) continue;
                    if (i % 2 == 0)
                    {
                        Qi = true;
                    }
                    else
                    {
                        Jie = true;
                    }
                    return;
                }
            }
        }

        /// <summary>
        /// 阳历日期
        /// </summary>
        public Solar Solar { get; set; }

        /// <summary>
        /// 是否节令
        /// </summary>
        public bool Jie { get; set; }

        /// <summary>
        /// 是否气令
        /// </summary>
        public bool Qi { get; set; }
        
        /// <summary>
        /// 创建节气
        /// </summary>
        public JieQi()
        {
            // TODO: 没用过，是否应删除？
        }

        /// <summary>
        /// 创建节气
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="solar">阳历日期</param>
        public JieQi(string name, Solar solar)
        {
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