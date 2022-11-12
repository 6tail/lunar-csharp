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

        public TaoFestival(string name, string remark = null)
        {
            Name = name;
            Remark = remark ?? "";
        }

        public override string ToString()
        {
            return Name;
        }

        public string FullString
        {
            get
            {
                var s = new StringBuilder();
                s.Append(Name);
                if (Remark is not {Length: > 0}) return s.ToString();
                s.Append('[');
                s.Append(Remark);
                s.Append(']');
                return s.ToString();
            }
        }
    }

}
