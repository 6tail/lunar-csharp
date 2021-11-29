using System.Collections.Generic;
using System.Text;
namespace com.nlf.calendar
{
    /// <summary>
    /// 道历节日
    /// </summary>
    public class TaoFestival
    {

        /// <summary>
        /// 名称
        /// </summary>
        private string name;

        /// <summary>
        /// 备注
        /// </summary>
        private string remark;

        public TaoFestival(string name, string remark)
        {
            this.name = name;
            this.remark = null == remark ? "" : remark;
        }

        public TaoFestival(string name)
            : this(name, null)
        {
        }

        public string getName()
        {
            return name;
        }

        public string getRemark()
        {
            return remark;
        }

        public string toString()
        {
            return name;
        }

        public override string ToString()
        {
            return toString();
        }

        public string toFullString()
        {
            StringBuilder s = new StringBuilder();
            s.Append(name);
            if (null != remark && remark.Length > 0)
            {
                s.Append("[");
                s.Append(remark);
                s.Append("]");
            }
            return s.ToString();
        }
    }

}
