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
    public sealed class FotoFestival
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

        /// <summary>
        /// 创建佛历节日
        /// </summary>
        /// <param name="name">是日何日</param>
        /// <param name="result">犯之因果</param>
        /// <param name="everyMonth">是否每月同</param>
        /// <param name="remark">备注</param>
        public FotoFestival(string name, string result = null, bool everyMonth = false, string remark = null)
        {
            Name = name;
            Result = result ?? "";
            EveryMonth = everyMonth;
            Remark = remark ?? "";
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

        /// <inheritdoc />
        public override string ToString()
        {
            return Name;
        }
    }

}
