using System.Collections.Generic;
using System.Linq;
using Lunar;
// ReSharper disable InconsistentNaming

namespace Lunar.Util
{
    /// <summary>
    /// 道历工具
    /// </summary>
    public static class TaoUtil
    {
        #region Fields -> TextResource

        /// <summary>
        /// 三会日
        /// </summary>
        public static string[] SAN_HUI => TextResource.Instance.SAN_HUI;

        /// <summary>
        /// 三元日
        /// </summary>
        public static string[] SAN_YUAN => TextResource.Instance.SAN_YUAN;

        /// <summary>
        /// 五腊日
        /// </summary>
        public static string[] WU_LA => TextResource.Instance.WU_LA;

        /// <summary>
        /// 暗戊
        /// </summary>
        public static string[] AN_WU => TextResource.Instance.AN_WU;

        /// <summary>
        /// 八会日
        /// </summary>
        public static Dictionary<string, string> BA_HUI => TextResource.Instance.BA_HUI;

        /// <summary>
        /// 八节日
        /// </summary>
        public static Dictionary<string, string> BA_JIE => TextResource.Instance.BA_JIE;

        #endregion

        /// <summary>
        /// 道历节日数据
        /// </summary>
        public static Dictionary<string, string[]> TAO_FESTIVAL_DATA => TextResource.Instance.TAO_FESTIVAL_DATA;

        /// <summary>
        /// 节日
        /// </summary>
        public static Dictionary<string, List<TaoFestival>> FESTIVAL =>
            TAO_FESTIVAL_DATA.ToDictionary(kv => kv.Key, kv => kv.Value.Select(v => new TaoFestival(v)).ToList());
    }
}
