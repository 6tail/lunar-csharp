using System;
using System.Collections.Generic;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable MemberCanBePrivate.Global

namespace Lunar.Util
{
    /// <summary>
    /// 佛历工具
    /// </summary>
    public static class FotoUtil
    {

        /// <summary>
        /// 观音斋日期
        /// </summary>
        public static readonly string[] DAY_ZHAI_GUAN_YIN = { "1-8", "2-7", "2-9", "2-19", "3-3", "3-6", "3-13", "4-22", "5-3", "5-17", "6-16", "6-18", "6-19", "6-23", "7-13", "8-16", "9-19", "9-23", "10-2", "11-19", "11-24", "12-25" };


        /// <summary>
        /// 因果犯忌
        /// </summary>
        public static Dictionary<string, List<FotoFestival>> FESTIVAL => TextResource.Instance.FOTO_FESTIVAL;

        /// <summary>
        /// 纪念日
        /// </summary>
        public static Dictionary<string, List<string>> OTHER_FESTIVAL => TextResource.Instance.FOTO_OTHER_FESTIVAL;

        /// <summary>
        /// 27星宿，佛教从印度传入中国，印度把28星宿改为27星宿，把牛宿(牛金牛)纳入了女宿(女土蝠)。
        /// </summary>
        public static string[] XIU_27 => TextResource.Instance.XIU_27;

        /// <summary>
        /// 每月初一的27星宿偏移
        /// </summary>
        private static readonly int[] XIU_OFFSET = { 11, 13, 15, 17, 19, 21, 24, 0, 2, 4, 7, 9 };

        /// <summary>
        /// 获取27星宿
        /// </summary>
        /// <param name="month">佛历月</param>
        /// <param name="day">佛历日</param>
        /// <returns>星宿</returns>
        public static string GetXiu(int month, int day)
        {
            return XIU_27[(XIU_OFFSET[Math.Abs(month) - 1] + day - 1) % XIU_27.Length];
        }
    }
}
