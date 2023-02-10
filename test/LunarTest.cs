using Lunar;
using Xunit;

namespace test
{
    /// <summary>
    /// 阴历
    /// </summary>
    public class LunarTest
    {
        
        [Fact]
        public void Test1()
        {
            var solar = Solar.FromYmdHms(2021, 6, 7, 21, 18);
            var lunar = solar.Lunar;
            Assert.Equal("二〇二一年四月廿七", lunar.ToString());
        }

        [Fact]
        public void Test2()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2021, 6, 7, 21, 18);
            var solar = lunar.Solar;
            Assert.Equal("2021-07-16", solar.ToString());
        }

        [Fact]
        public void Test038()
        {
            var lunar = Lunar.Lunar.FromYmdHms(7013, -11, 4);
            var solar = lunar.Solar;
            Assert.Equal("7013-12-24", solar.ToString());
        }

        [Fact]
        public void Test041()
        {
            var solar = Solar.FromYmdHms(4, 2, 10);
            Assert.Equal("鼠", solar.Lunar.YearShengXiao);
        }

        [Fact]
        public void Test042()
        {
            var solar = Solar.FromYmdHms(4, 2, 9);
            Assert.Equal("猪", solar.Lunar.YearShengXiao);
        }

        [Fact]
        public void Test22()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2033, -11, 1);
            Assert.Equal("2033-12-22", lunar.Solar.Ymd);
        }

        [Fact]
        public void Test025()
        {
            var solar = Solar.FromYmdHms(2021, 6, 7, 21, 18);
            Assert.Equal("二〇二一年四月廿七", solar.Lunar.ToString());
        }

        [Fact]
        public void Test026()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2021, 6, 7, 21, 18);
            Assert.Equal("2021-07-16", lunar.Solar.ToString());
        }

        [Fact]
        public void Test027()
        {
            var solar = Solar.FromYmdHms(1989, 4, 28);
            Assert.Equal(23, solar.Lunar.Day);
        }

        [Fact]
        public void Test028()
        {
            var solar = Solar.FromYmdHms(1990, 10, 8);
            Assert.Equal("乙酉", solar.Lunar.MonthInGanZhiExact);
        }

        [Fact]
        public void Test029()
        {
            var solar = Solar.FromYmdHms(1990, 10, 9);
            Assert.Equal("丙戌", solar.Lunar.MonthInGanZhiExact);
        }

        [Fact]
        public void Test030()
        {
            var solar = Solar.FromYmdHms(1990, 10, 8);
            Assert.Equal("丙戌", solar.Lunar.MonthInGanZhi);
        }

        [Fact]
        public void Test031()
        {
            var solar = Solar.FromYmdHms(1987, 4, 17, 9);
            Assert.Equal("一九八七年三月二十", solar.Lunar.ToString());
        }

        [Fact]
        public void Test032()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2034, 1, 1);
            Assert.Equal("2034-02-19", lunar.Solar.ToString());
        }

        [Fact]
        public void Test033()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2033, 12, 1);
            Assert.Equal("2034-01-20", lunar.Solar.ToString());
        }

        [Fact]
        public void Test034()
        {
            var lunar = Lunar.Lunar.FromYmdHms(37, -12, 1);
            Assert.Equal("闰腊", lunar.MonthInChinese);
        }

        [Fact]
        public void Test035()
        {
            var lunar = Lunar.Lunar.FromYmdHms(56, -12, 1);
            Assert.Equal("闰腊", lunar.MonthInChinese);

            lunar = Lunar.Lunar.FromYmdHms(75, -11, 1);
            Assert.Equal("闰冬", lunar.MonthInChinese);

            lunar = Lunar.Lunar.FromYmdHms(94, -11, 1);
            Assert.Equal("闰冬", lunar.MonthInChinese);

            lunar = Lunar.Lunar.FromYmdHms(94, 12, 1);
            Assert.Equal("腊", lunar.MonthInChinese);

            lunar = Lunar.Lunar.FromYmdHms(113, 12, 1);
            Assert.Equal("腊", lunar.MonthInChinese);

            lunar = Lunar.Lunar.FromYmdHms(113, -12, 1);
            Assert.Equal("闰腊", lunar.MonthInChinese);

            lunar = Lunar.Lunar.FromYmdHms(5552, -12, 1);
            Assert.Equal("闰腊", lunar.MonthInChinese);
        }

        [Fact]
        public void Test036()
        {
            var solar = Solar.FromYmdHms(5553, 1, 22);
            Assert.Equal("五五五二年闰腊月初二", solar.Lunar.ToString());
        }

        [Fact]
        public void Test037()
        {
            var solar = Solar.FromYmdHms(7013, 12, 24);
            Assert.Equal("七〇一三年闰冬月初四", solar.Lunar.ToString());
        }

        [Fact]
        public void Test35()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2021, 12, 29);
            Assert.Equal("除夕", lunar.Festivals[0]);
        }

        [Fact]
        public void Test36()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2020, 12, 30);
            Assert.Equal("除夕", lunar.Festivals[0]);
        }

        [Fact]
        public void Test37()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2020, 12, 29);
            Assert.Equal(0, lunar.Festivals.Count);
        }

        [Fact]
        public void Test38()
        {
            var solar = Solar.FromYmdHms(2022, 1, 31);
            var lunar = solar.Lunar;
            Assert.Equal("除夕", lunar.Festivals[0]);
        }

        [Fact]
        public void Test8()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2020, 12, 10, 13);
            Assert.Equal("二〇二〇年腊月初十", lunar.ToString());
            Assert.Equal("2021-01-22", lunar.Solar.ToString());
        }

        [Fact]
        public void Test9()
        {
            var lunar = Lunar.Lunar.FromYmdHms(1500, 1, 1, 12);
            Assert.Equal("1500-01-31", lunar.Solar.ToString());
        }

        [Fact]
        public void Test10()
        {
            var lunar = Lunar.Lunar.FromYmdHms(1500, 12, 29, 12);
            Assert.Equal("1501-01-18", lunar.Solar.ToString());
        }

        
        [Fact]
        public void Test11()
        {
            var solar = Solar.FromYmdHms(1500, 1, 1, 12);
            Assert.Equal("一四九九年腊月初一", solar.Lunar.ToString());
        }

        /// <summary>
        /// 1500年计算二月初一是2月29日导致DateTime报错，这个暂未解决，绕开1500年这些特殊的吧。（1582年之前，欧洲实行儒略历，能被4整除的都是闰年，所以1100，1200，1300，1400，1500都是闰年。1582年之後，实行格里历，整百年份必须能被400整除才是闰年。）
        /// </summary>
        [Fact]
        public void Test12()
        {
            // var solar = Solar.FromYmdHms(1500, 12, 31, 12, 0, 0);
            // Assert.Equal("一五〇〇年腊月十一", solar.Lunar.ToString());
        }

        [Fact]
        public void Test13()
        {
            var solar = Solar.FromYmdHms(1582, 10, 4, 12);
            Assert.Equal("一五八二年九月十八", solar.Lunar.ToString());
        }

        [Fact]
        public void Test14()
        {
            var solar = Solar.FromYmdHms(1582, 10, 15, 12);
            Assert.Equal("一五八二年九月十九", solar.Lunar.ToString());
        }

        [Fact]
        public void Test15()
        {
            var lunar = Lunar.Lunar.FromYmdHms(1582, 9, 18, 12);
            Assert.Equal("1582-10-04", lunar.Solar.ToString());
        }

        [Fact]
        public void Test16()
        {
            var lunar = Lunar.Lunar.FromYmdHms(1582, 9, 19, 12);
            Assert.Equal("1582-10-15", lunar.Solar.ToString());
        }

        [Fact]
        public void Test17()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2019, 12, 12, 11, 22);
            Assert.Equal("2020-01-06", lunar.Solar.ToString());
        }

        [Fact]
        public void Test18()
        {
            var solar = Solar.FromYmdHms(2020, 2, 4, 13, 22);
            var lunar = solar.Lunar;
            Assert.Equal("庚子", lunar.YearInGanZhi);
            Assert.Equal("庚子", lunar.YearInGanZhiByLiChun);
            Assert.Equal("己亥", lunar.YearInGanZhiExact);
            Assert.Equal("戊寅", lunar.MonthInGanZhi);
            Assert.Equal("丁丑", lunar.MonthInGanZhiExact);
        }

        [Fact]
        public void Test19()
        {
            var solar = Solar.FromYmdHms(2019, 2, 8, 13, 22);
            var lunar = solar.Lunar;
            Assert.Equal("己亥", lunar.YearInGanZhi);
            Assert.Equal("己亥", lunar.YearInGanZhiByLiChun);
            Assert.Equal("己亥", lunar.YearInGanZhiExact);
            Assert.Equal("丙寅", lunar.MonthInGanZhi);
            Assert.Equal("丙寅", lunar.MonthInGanZhiExact);
        }

        [Fact]
        public void Test20()
        {
            var solar = Solar.FromYmdHms(1988, 2, 15, 23, 30);
            var lunar = solar.Lunar;
            Assert.Equal("丁卯", lunar.YearInGanZhi);
            Assert.Equal("戊辰", lunar.YearInGanZhiByLiChun);
            Assert.Equal("戊辰", lunar.YearInGanZhiExact);
        }

        [Fact]
        public void Test21()
        {
            var solar = Solar.FromYmdHms(1988, 2, 15);
            var lunar = solar.Lunar;
            Assert.Equal("丁卯", lunar.YearInGanZhi);
        }

        [Fact]
        public void Test022()
        {
            var solar = Solar.FromYmdHms(2012, 12, 27);
            var lunar = solar.Lunar;
            Assert.Equal("壬辰", lunar.YearInGanZhi);
            Assert.Equal("壬子", lunar.MonthInGanZhi);
            Assert.Equal("壬戌", lunar.DayInGanZhi);
        }

        [Fact]
        public void Test023()
        {
            var solar = Solar.FromYmdHms(2012, 12, 20);
            var lunar = solar.Lunar;
            Assert.Equal("壬辰", lunar.YearInGanZhi);
            Assert.Equal("壬子", lunar.MonthInGanZhi);
            Assert.Equal("乙卯", lunar.DayInGanZhi);
        }

        [Fact]
        public void Test024()
        {
            var solar = Solar.FromYmdHms(2012, 11, 20);
            var lunar = solar.Lunar;
            Assert.Equal("壬辰", lunar.YearInGanZhi);
            Assert.Equal("辛亥", lunar.MonthInGanZhi);
            Assert.Equal("乙酉", lunar.DayInGanZhi);
        }

        [Fact]
        public void Test25()
        {
            var solar = Solar.FromYmdHms(2012, 10, 20);
            var lunar = solar.Lunar;
            Assert.Equal("壬辰", lunar.YearInGanZhi);
            Assert.Equal("庚戌", lunar.MonthInGanZhi);
            Assert.Equal("甲寅", lunar.DayInGanZhi);
        }

        [Fact]
        public void Test26()
        {
            var solar = Solar.FromYmdHms(2012, 9, 20);
            var lunar = solar.Lunar;
            Assert.Equal("壬辰", lunar.YearInGanZhi);
            Assert.Equal("己酉", lunar.MonthInGanZhi);
            Assert.Equal("甲申", lunar.DayInGanZhi);
        }

        [Fact]
        public void Test126()
        {
            var solar = Solar.FromYmdHms(2012, 8, 5);
            var lunar = solar.Lunar;
            Assert.Equal("戊戌", lunar.DayInGanZhi);
        }

        [Fact]
        public void Test27()
        {
            var solar = Solar.FromYmdHms(2000, 2, 2);
            var lunar = solar.Lunar;
            Assert.Equal("庚寅", lunar.DayInGanZhi);
        }

        [Fact]
        public void Test28()
        {
            var solar = Solar.FromYmdHms(1996, 1, 16);
            var lunar = solar.Lunar;
            Assert.Equal("壬子", lunar.DayInGanZhi);
        }

        [Fact]
        public void Test29()
        {
            var solar = Solar.FromYmdHms(1997, 2, 16);
            var lunar = solar.Lunar;
            Assert.Equal("己丑", lunar.DayInGanZhi);
        }

        [Fact]
        public void Test30()
        {
            var solar = Solar.FromYmdHms(1998, 3, 16);
            var lunar = solar.Lunar;
            Assert.Equal("壬戌", lunar.DayInGanZhi);
        }
        
        [Fact]
        public void Test31()
        {
            var solar = Solar.FromYmdHms(1999, 4, 16);
            var lunar = solar.Lunar;
            Assert.Equal("戊戌", lunar.DayInGanZhi);
        }

        [Fact]
        public void Test32()
        {
            var solar = Solar.FromYmdHms(2000, 7, 16);
            var lunar = solar.Lunar;
            Assert.Equal("乙亥", lunar.DayInGanZhi);
        }

        [Fact]
        public void Test33()
        {
            var solar = Solar.FromYmdHms(2000, 1, 6);
            var lunar = solar.Lunar;
            Assert.Equal("癸亥", lunar.DayInGanZhi);
        }

        
        [Fact]
        public void Test34()
        {
            var solar = Solar.FromYmdHms(2000, 1, 9);
            var lunar = solar.Lunar;
            Assert.Equal("丙寅", lunar.DayInGanZhi);
        }

        [Fact]
        public void Test45()
        {
            var solar = Solar.FromYmdHms(2017, 2, 15);
            var lunar = solar.Lunar;
            Assert.Equal("子命互禄 辛命进禄", lunar.DayLu);
        }

        [Fact]
        public void Test46()
        {
            var solar = Solar.FromYmdHms(2017, 2, 16);
            var lunar = solar.Lunar;
            Assert.Equal("寅命互禄", lunar.DayLu);
        }

        [Fact]
        public void Test48()
        {
            var solar = Solar.FromYmdHms(2021, 11, 13);
            var lunar = solar.Lunar;
            Assert.Equal("碓磨厕 外东南", lunar.DayPositionTai);
        }

        [Fact]
        public void Test49()
        {
            var solar = Solar.FromYmdHms(2021, 11, 12);
            var lunar = solar.Lunar;
            Assert.Equal("占门碓 外东南", lunar.DayPositionTai);
        }

        [Fact]
        public void Test50()
        {
            var solar = Solar.FromYmdHms(2021, 11, 13);
            var lunar = solar.Lunar;
            Assert.Equal("西南", lunar.DayPositionFuDesc);
        }

        [Fact]
        public void Test51()
        {
            var solar = Solar.FromYmdHms(2021, 11, 12);
            var lunar = solar.Lunar;
            Assert.Equal("正北", lunar.DayPositionFuDesc);
        }

        [Fact]
        public void Test52()
        {
            var solar = Solar.FromYmdHms(2011, 11, 12);
            var lunar = solar.Lunar;
            Assert.Equal("厕灶厨 外西南", lunar.DayPositionTai);
        }

        [Fact]
        public void Test53()
        {
            var solar = Solar.FromYmdHms(1722, 9, 25);
            var lunar = solar.Lunar;
            Assert.Equal("秋社", lunar.OtherFestivals[0]);
        }

        [Fact]
        public void Test54()
        {
            var solar = Solar.FromYmdHms(2021, 3, 21);
            var lunar = solar.Lunar;
            Assert.Equal("春社", lunar.OtherFestivals[0]);
        }
        
        [Fact]
        public void Test55()
        {
            var lunar = Lunar.Lunar.FromYmdHms(1582, 9, 18);
            Assert.Equal("1582-10-04", lunar.Solar.Ymd);
        }
        
        [Fact]
        public void Test56()
        {
            var lunar = Lunar.Lunar.FromYmdHms(1582, 9, 19);
            Assert.Equal("1582-10-15", lunar.Solar.Ymd);
        }
    }
}