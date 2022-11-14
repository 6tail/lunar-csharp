using System.Text;
// ReSharper disable IdentifierTypo
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable ClassNeverInstantiated.Global
namespace Lunar
{
    /// <summary>
    /// 佛历因果犯忌
    /// </summary>
    public class FotoFestival
    {

        /// <summary>
        /// 是日何日，如：雷斋日
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 犯之因果，如：犯者夺纪
        /// </summary>
        public string Result { get; }

        /// <summary>
        /// 是否每月同
        /// </summary>
        public bool EveryMonth { get; }

        /// <summary>
        /// 备注，如：宜先一日即戒
        /// </summary>
        public string Remark { get; }

        public FotoFestival(string name, string result = null, bool everyMonth = false, string remark = null)
        {
            Name = name;
            Result = result ?? "";
            EveryMonth = everyMonth;
            Remark = remark ?? "";
        }

        public string FullString
        {
            get
            {
                var s = new StringBuilder();
                s.Append(Name);
                if (!string.IsNullOrEmpty(Result))
                {
                    s.Append(' ');
                    s.Append(Result);
                }

                if (!string.IsNullOrEmpty(Remark))
                {
                    s.Append(' ');
                    s.Append(Remark);
                }
                return s.ToString();
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }

}
