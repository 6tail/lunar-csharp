using System.Collections.Generic;
using System.Text;
namespace com.nlf.calendar
{
    /// <summary>
    /// 佛历因果犯忌
    /// </summary>
    public class FotoFestival
    {

        /// <summary>
        /// 是日何日，如：雷斋日
        /// </summary>
        private string name;

        /// <summary>
        /// 犯之因果，如：犯者夺纪
        /// </summary>
        private string result;

        /// <summary>
        /// 是否每月同
        /// </summary>
        private bool everyMonth;

        /// <summary>
        /// 备注，如：宜先一日即戒
        /// </summary>
        private string remark;

        public FotoFestival(string name, string result, bool everyMonth, string remark)
        {
            this.name = name;
            this.result = null == result ? "" : result;
            this.everyMonth = everyMonth;
            this.remark = null == remark ? "" : remark;
        }

        public FotoFestival(string name)
            : this(name, null)
        {
        }

        public FotoFestival(string name, string result)
            : this(name, result, false)
        {
        }

        public FotoFestival(string name, string result, bool everyMonth)
            : this(name, result, everyMonth, null)
        {
        }

        public string getName()
        {
            return name;
        }

        public string getResult()
        {
            return result;
        }

        public bool isEveryMonth()
        {
            return everyMonth;
        }

        public string getRemark()
        {
            return remark;
        }

        public string toFullString()
        {
            StringBuilder s = new StringBuilder();
            s.Append(name);
            if (null != result && result.Length > 0)
            {
                s.Append(" ");
                s.Append(result);
            }
            if (null != remark && remark.Length > 0)
            {
                s.Append(" ");
                s.Append(remark);
            }
            return s.ToString();
        }

        public string toString()
        {
           return name;
        }

        public override string ToString()
        {
            return toString();
        }
    }

}
