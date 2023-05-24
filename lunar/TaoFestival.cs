using System.Text;

// TODO: 可访问性调整

namespace Lunar
{
    /// <summary>
    /// 道历节日
    /// </summary>
    public sealed class TaoFestival
    {

        /// <summary>
        /// 名称
        /// </summary>
        private string Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        private string Remark { get; set; }

        /// <summary>
        /// 创建道历节日
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="remark">备注</param>
        public TaoFestival(string name, string remark = null)
        {
            Name = name;
            Remark = remark ?? "";
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Name;
        }
        /// <summary>
        /// 
        /// </summary>
        public string FullString
        {
            get
            {
                var s = new StringBuilder();
                s.Append(Name);
                if (!string.IsNullOrEmpty(Remark))
                {
                    s.Append('[');
                    s.Append(Remark);
                    s.Append(']');
                }
                return s.ToString();
            }
        }
    }

}
