namespace Lunar
{
    /// <summary>
    /// 节假日
    /// </summary>
    public class Holiday
    {
        /// <summary>
        /// 日期，YYYY-MM-DD
        /// </summary>
        public string Day { get; set; }

        /// <summary>
        /// 名称，如：国庆节
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否调休，即是否要上班
        /// </summary>
        public bool Work { get; set; }

        /// <summary>
        /// 关联的节日，YYYY-MM-DD格式
        /// </summary>
        public string Target { get; set; }

        public Holiday() { }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="day">日期</param>
        /// <param name="name">名称</param>
        /// <param name="work">是否调休</param>
        /// <param name="target">关联的节日</param>
        public Holiday(string day, string name, bool work, string target)
        {
            if (!day.Contains("-"))
            {
                Day = day[..4] + "-" + day.Substring(4, 2) + "-" + day[6..];
            }
            else
            {
                Day = day;
            }
            Name = name;
            Work = work;
            if (!target.Contains("-"))
            {
                Target = target[..4] + "-" + target.Substring(4, 2) + "-" + target[6..];
            }
            else
            {
                Target = target;
            }
        }

        public override string ToString()
        {
            return Day + " " + Name + (Work ? "调休" : "") + " " + Target;
        }
    }
}