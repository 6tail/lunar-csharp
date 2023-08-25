using System.Text;
namespace Lunar
{
    /// <summary>
    /// 道历节日
    /// </summary>
    public class TaoFestival
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
        /// 初始化
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
        /// 完整字符串输出
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
