using System;
using System.Collections.Generic;
using System.Text;
using com.nlf.calendar.util;

namespace com.nlf.calendar
{
    /// <summary>
    /// 时辰
    /// </summary>
    public class LunarTime
    {
        /// <summary>
        /// 天干下标，0-9
        /// </summary>
        private int ganIndex;

        /// <summary>
        /// 地支下标，0-11
        /// </summary>
        private int zhiIndex;

        /// <summary>
        /// 阴历
        /// </summary>
        private Lunar lunar;

        /// <summary>
        /// 通过农历年月日时初始化
        /// </summary>
        /// <param name="lunarYear">年（农历）</param>
        /// <param name="lunarMonth">月（农历），1到12，闰月为负，即闰2月=-2</param>
        /// <param name="lunarDay">日（农历），1到31</param>
        /// <param name="hour">小时（阳历）</param>
        /// <param name="minute">分钟（阳历）</param>
        /// <param name="second">秒钟（阳历）</param>
        public LunarTime(int lunarYear, int lunarMonth, int lunarDay, int hour, int minute, int second)
        {
            this.lunar = Lunar.fromYmdHms(lunarYear, lunarMonth, lunarDay, hour, minute, second);
            this.zhiIndex = LunarUtil.getTimeZhiIndex((hour < 10 ? "0" : "") + hour + ":" + (minute < 10 ? "0" : "") + minute);
            this.ganIndex = (lunar.getDayGanIndexExact() % 5 * 2 + zhiIndex) % 10;
        }

        /// <summary>
        /// 通过指定农历年月日获取时辰
        /// </summary>
        /// <param name="lunarYear">年（农历）</param>
        /// <param name="lunarMonth">月（农历），1到12，闰月为负，即闰2月=-2</param>
        /// <param name="lunarDay">日（农历），1到31</param>
        /// <param name="hour">小时（阳历）</param>
        /// <param name="minute">分钟（阳历）</param>
        /// <param name="second">秒钟（阳历）</param>
        /// <returns>时辰</returns>
        public static LunarTime fromYmdHms(int lunarYear, int lunarMonth, int lunarDay, int hour, int minute, int second)
        {
            return new LunarTime(lunarYear, lunarMonth, lunarDay, hour, minute, second);
        }

        /// <summary>
        /// 获取时辰生肖
        /// </summary>
        /// <returns>时辰生肖，如虎</returns>
        public string getShengXiao()
        {
            return LunarUtil.SHENGXIAO[zhiIndex + 1];
        }

        /// <summary>
        /// 获取时辰（地支）
        /// </summary>
        /// <returns>时辰（地支）</returns>
        public string getZhi()
        {
            return LunarUtil.ZHI[zhiIndex + 1];
        }

        /// <summary>
        /// 获取时辰（天干）
        /// </summary>
        /// <returns>时辰（天干）</returns>
        public string getGan()
        {
            return LunarUtil.GAN[ganIndex + 1];
        }

        /// <summary>
        /// 获取时辰干支（时柱）
        /// </summary>
        /// <returns>时辰干支（时柱）</returns>
        public string getGanZhi()
        {
            return getGan() + getZhi();
        }

        /// <summary>
        /// 获取时辰喜神方位
        /// </summary>
        /// <returns>喜神方位，如艮</returns>
        public string getPositionXi()
        {
            return LunarUtil.POSITION_XI[ganIndex + 1];
        }

        /// <summary>
        /// 获取时辰喜神方位描述
        /// </summary>
        /// <returns>喜神方位描述，如东北</returns>
        public string getPositionXiDesc()
        {
            return LunarUtil.POSITION_DESC[getPositionXi()];
        }

        /// <summary>
        /// 获取时辰阳贵神方位
        /// </summary>
        /// <returns>阳贵神方位，如艮</returns>
        public string getPositionYangGui()
        {
            return LunarUtil.POSITION_YANG_GUI[ganIndex + 1];
        }

        /// <summary>
        /// 获取时辰阳贵神方位描述
        /// </summary>
        /// <returns>阳贵神方位描述，如东北</returns>
        public string getPositionYangGuiDesc()
        {
            return LunarUtil.POSITION_DESC[getPositionYangGui()];
        }

        /// <summary>
        /// 获取时辰阴贵神方位
        /// </summary>
        /// <returns>阴贵神方位，如艮</returns>
        public string getPositionYinGui()
        {
            return LunarUtil.POSITION_YIN_GUI[ganIndex + 1];
        }

        /// <summary>
        /// 获取时辰阴贵神方位描述
        /// </summary>
        /// <returns>阴贵神方位描述，如东北</returns>
        public string getPositionYinGuiDesc()
        {
            return LunarUtil.POSITION_DESC[getPositionYinGui()];
        }

        /// <summary>
        /// 获取时辰福神方位
        /// </summary>
        /// <returns>福神方位，如艮</returns>
        public string getPositionFu()
        {
            return LunarUtil.POSITION_FU[ganIndex + 1];
        }

        /// <summary>
        /// 获取时辰福神方位描述
        /// </summary>
        /// <returns>福神方位描述，如东北</returns>
        public string getPositionFuDesc()
        {
            return LunarUtil.POSITION_DESC[getPositionFu()];
        }

        /// <summary>
        /// 获取时辰财神方位
        /// </summary>
        /// <returns>财神方位，如艮</returns>
        public string getPositionCai()
        {
            return LunarUtil.POSITION_CAI[ganIndex + 1];
        }

        /// <summary>
        /// 获取时辰财神方位描述
        /// </summary>
        /// <returns>财神方位描述，如东北</returns>
        public string getPositionCaiDesc()
        {
            return LunarUtil.POSITION_DESC[getPositionCai()];
        }

        /// <summary>
        /// 获取时冲
        /// </summary>
        /// <returns>时冲，如申</returns>
        public string getChong()
        {
            return LunarUtil.CHONG[zhiIndex + 1];
        }

        /// <summary>
        /// 获取无情之克的时冲天干
        /// </summary>
        /// <returns>无情之克的时冲天干，如甲</returns>
        public string getChongGan()
        {
            return LunarUtil.CHONG_GAN[ganIndex + 1];
        }

        /// <summary>
        /// 获取有情之克的时冲天干
        /// </summary>
        /// <returns>有情之克的时冲天干，如甲</returns>
        public string getChongGanTie()
        {
            return LunarUtil.CHONG_GAN_TIE[ganIndex + 1];
        }

        /// <summary>
        /// 获取时冲生肖
        /// </summary>
        /// <returns>时冲生肖，如猴</returns>
        public string getChongShengXiao()
        {
            string chong = getChong();
            for (int i = 0, j = LunarUtil.ZHI.Length; i < j; i++)
            {
                if (LunarUtil.ZHI[i].Equals(chong))
                {
                    return LunarUtil.SHENGXIAO[i];
                }
            }
            return "";
        }

        /// <summary>
        /// 获取时冲描述
        /// </summary>
        /// <returns>时冲描述，如(壬申)猴</returns>
        public string getChongDesc()
        {
            return "(" + getChongGan() + getChong() + ")" + getChongShengXiao();
        }

        /// <summary>
        /// 获取时煞
        /// </summary>
        /// <returns>时煞，如北</returns>
        public string getSha()
        {
            return LunarUtil.SHA[getZhi()];
        }

        /// <summary>
        /// 获取时辰纳音
        /// </summary>
        /// <returns>时辰纳音，如剑锋金</returns>
        public string getNaYin()
        {
            return LunarUtil.NAYIN[getGanZhi()];
        }

        /// <summary>
        /// 获取值时天神
        /// </summary>
        /// <returns>值时天神</returns>
        public string getTianShen()
        {
            string dayZhi = lunar.getDayZhiExact();
            int offset = LunarUtil.ZHI_TIAN_SHEN_OFFSET[dayZhi];
            return LunarUtil.TIAN_SHEN[(zhiIndex + offset) % 12 + 1];
        }

        /// <summary>
        /// 获取值时天神类型：黄道/黑道
        /// </summary>
        /// <returns>值时天神类型：黄道/黑道</returns>
        public string getTianShenType()
        {
            return LunarUtil.TIAN_SHEN_TYPE[getTianShen()];
        }

        /// <summary>
        /// 获取值时天神吉凶
        /// </summary>
        /// <returns>吉/凶</returns>
        public string getTianShenLuck()
        {
            return LunarUtil.TIAN_SHEN_TYPE_LUCK[getTianShenType()];
        }

        /// <summary>
        /// 获取时辰宜，如果没有，返回["无"]
        /// </summary>
        /// <returns>宜</returns>
        public List<string> getYi()
        {
            return LunarUtil.getTimeYi(lunar.getDayInGanZhiExact(), getGanZhi());
        }

        /// <summary>
        /// 获取时辰忌，如果没有，返回["无"]
        /// </summary>
        /// <returns>忌</returns>
        public List<string> getJi()
        {
            return LunarUtil.getTimeJi(lunar.getDayInGanZhiExact(), getGanZhi());
        }

        /// <summary>
        /// 获取值时九星（时家紫白星歌诀：三元时白最为佳，冬至阳生顺莫差，孟日七宫仲一白，季日四绿发萌芽，每把时辰起甲子，本时星耀照光华，时星移入中宫去，顺飞八方逐细查。夏至阴生逆回首，孟归三碧季加六，仲在九宫时起甲，依然掌中逆轮跨。）
        /// </summary>
        /// <returns>值时九星</returns>
        public NineStar getNineStar()
        {
            //顺逆
            string solarYmd = lunar.getSolar().toYmd();
            Dictionary<string,Solar> jieQi = lunar.getJieQiTable();
            bool asc = false;
            if (solarYmd.CompareTo(jieQi["冬至"].toYmd()) >= 0 && solarYmd.CompareTo(jieQi["夏至"].toYmd()) < 0)
            {
                asc = true;
            }
            int start = asc ? 7 : 3;
            string dayZhi = lunar.getDayZhi();
            if ("子午卯酉".Contains(dayZhi))
            {
                start = asc ? 1 : 9;
            }
            else if ("辰戌丑未".Contains(dayZhi))
            {
                start = asc ? 4 : 6;
            }
            int index = asc ? start + zhiIndex - 1 : start - zhiIndex - 1;
            if (index > 8)
            {
                index -= 9;
            }
            if (index < 0)
            {
                index += 9;
            }
            return new NineStar(index);
        }

        public string toString()
        {
            return getGanZhi();
        }


        public override string ToString()
        {
            return toString();
        }

        public int getGanIndex()
        {
            return ganIndex;
        }

        public int getZhiIndex()
        {
            return zhiIndex;
        }

        /// <summary>
        /// 获取时辰所在旬
        /// </summary>
        /// <returns>旬</returns>
        public string getXun()
        {
            return LunarUtil.getXun(getGanZhi());
        }

        /// <summary>
        /// 获取值时空亡
        /// </summary>
        /// <returns>空亡(旬空)</returns>
        public string getXunKong()
        {
            return LunarUtil.getXunKong(getGanZhi());
        }

        /// <summary>
        /// 获取当前时辰的最早时分
        /// </summary>
        /// <returns>时分，如：21:00</returns>
        public string getMinHm()
        {
            int hour = lunar.getHour();
            if (hour < 1)
            {
                return "00:00";
            }
            else if (hour > 22)
            {
                return "23:00";
            }
            if (hour % 2 == 0)
            {
                hour -= 1;
            }
            return (hour < 10 ? "0" : "") + hour + ":00";
        }

        /// <summary>
        /// 获取当前时辰的最晚时分
        /// </summary>
        /// <returns>时分，如：22:59</returns>
        public string getMaxHm()
        {
            int hour = lunar.getHour();
            if (hour < 1)
            {
                return "00:59";
            }
            else if (hour > 22)
            {
                return "23:59";
            }
            if (hour % 2 != 0)
            {
                hour += 1;
            }
            return (hour < 10 ? "0" : "") + hour + ":59";
        }

    }
}
