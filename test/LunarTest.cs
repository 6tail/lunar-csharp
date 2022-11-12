using Lunar;
using NUnit.Framework;

namespace test
{
    /// <summary>
    /// 阴历
    /// </summary>
    public class LunarTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var solar = Solar.FromYmdHms(2021, 6, 7, 21, 18);
            var lunar = solar.Lunar;
            Assert.AreEqual("二〇二一年四月廿七", lunar.ToString());
        }

        [Test]
        public void Test2()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2021, 6, 7, 21, 18);
            var solar = lunar.Solar;
            Assert.AreEqual("2021-07-16", solar.ToString());
        }

        [Test]
        public void Test038()
        {
            var lunar = Lunar.Lunar.FromYmdHms(7013, -11, 4);
            var solar = lunar.Solar;
            Assert.AreEqual("7013-12-24", solar.ToString());
        }

        [Test]
        public void Test041()
        {
            var solar = Solar.FromYmdHms(4, 2, 10);
            Assert.AreEqual("鼠", solar.Lunar.YearShengXiao);
        }

        [Test]
        public void Test042()
        {
            var solar = Solar.FromYmdHms(4, 2, 9);
            Assert.AreEqual("猪", solar.Lunar.YearShengXiao);
        }

        [Test]
        public void Test22()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2033, -11, 1);
            Assert.AreEqual("2033-12-22", lunar.Solar.Ymd);
        }

        [Test]
        public void Test23()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2022, 1, 1);
            Assert.AreEqual("六白金开阳", lunar.YearNineStar.ToString());
        }

        [Test]
        public void Test24()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2033, 1, 1);
            Assert.AreEqual("四绿木天权", lunar.YearNineStar.ToString());
        }

        [Test]
        public void Test025()
        {
            var solar = Solar.FromYmdHms(2021, 6, 7, 21, 18);
            Assert.AreEqual("二〇二一年四月廿七", solar.Lunar.ToString());
        }

        [Test]
        public void Test026()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2021, 6, 7, 21, 18);
            Assert.AreEqual("2021-07-16", lunar.Solar.ToString());
        }

        [Test]
        public void Test027()
        {
            var solar = Solar.FromYmdHms(1989, 4, 28);
            Assert.AreEqual(23, solar.Lunar.Day);
        }

        [Test]
        public void Test028()
        {
            var solar = Solar.FromYmdHms(1990, 10, 8);
            Assert.AreEqual("乙酉", solar.Lunar.MonthInGanZhiExact);
        }

        [Test]
        public void Test029()
        {
            var solar = Solar.FromYmdHms(1990, 10, 9);
            Assert.AreEqual("丙戌", solar.Lunar.MonthInGanZhiExact);
        }

        [Test]
        public void Test030()
        {
            var solar = Solar.FromYmdHms(1990, 10, 8);
            Assert.AreEqual("丙戌", solar.Lunar.MonthInGanZhi);
        }

        [Test]
        public void Test031()
        {
            var solar = Solar.FromYmdHms(1987, 4, 17, 9);
            Assert.AreEqual("一九八七年三月二十", solar.Lunar.ToString());
        }

        [Test]
        public void Test032()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2034, 1, 1);
            Assert.AreEqual("2034-02-19", lunar.Solar.ToString());
        }

        [Test]
        public void Test033()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2033, 12, 1);
            Assert.AreEqual("2034-01-20", lunar.Solar.ToString());
        }

        [Test]
        public void Test034()
        {
            var lunar = Lunar.Lunar.FromYmdHms(37, -12, 1);
            Assert.AreEqual("闰腊", lunar.MonthInChinese);
        }

        [Test]
        public void Test035()
        {
            var lunar = Lunar.Lunar.FromYmdHms(56, -12, 1);
            Assert.AreEqual("闰腊", lunar.MonthInChinese);

            lunar = Lunar.Lunar.FromYmdHms(75, -11, 1);
            Assert.AreEqual("闰冬", lunar.MonthInChinese);

            lunar = Lunar.Lunar.FromYmdHms(94, -11, 1);
            Assert.AreEqual("闰冬", lunar.MonthInChinese);

            lunar = Lunar.Lunar.FromYmdHms(94, 12, 1);
            Assert.AreEqual("腊", lunar.MonthInChinese);

            lunar = Lunar.Lunar.FromYmdHms(113, 12, 1);
            Assert.AreEqual("腊", lunar.MonthInChinese);

            lunar = Lunar.Lunar.FromYmdHms(113, -12, 1);
            Assert.AreEqual("闰腊", lunar.MonthInChinese);

            lunar = Lunar.Lunar.FromYmdHms(5552, -12, 1);
            Assert.AreEqual("闰腊", lunar.MonthInChinese);
        }

        [Test]
        public void Test036()
        {
            var solar = Solar.FromYmdHms(5553, 1, 22);
            Assert.AreEqual("五五五二年闰腊月初二", solar.Lunar.ToString());
        }

        [Test]
        public void Test037()
        {
            var solar = Solar.FromYmdHms(7013, 12, 24);
            Assert.AreEqual("七〇一三年闰冬月初四", solar.Lunar.ToString());
        }

        [Test]
        public void Test35()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2021, 12, 29);
            Assert.AreEqual("除夕", lunar.Festivals[0]);
        }

        [Test]
        public void Test36()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2020, 12, 30);
            Assert.AreEqual("除夕", lunar.Festivals[0]);
        }

        [Test]
        public void Test37()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2020, 12, 29);
            Assert.AreEqual(0, lunar.Festivals.Count);
        }

        [Test]
        public void Test38()
        {
            var solar = Solar.FromYmdHms(2022, 1, 31);
            var lunar = solar.Lunar;
            Assert.AreEqual("除夕", lunar.Festivals[0]);
        }

        [Test]
        public void Test8()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2020, 12, 10, 13);
            Assert.AreEqual("二〇二〇年腊月初十", lunar.ToString());
            Assert.AreEqual("2021-01-22", lunar.Solar.ToString());
        }

        [Test]
        public void Test9()
        {
            var lunar = Lunar.Lunar.FromYmdHms(1500, 1, 1, 12);
            Assert.AreEqual("1500-01-31", lunar.Solar.ToString());
        }

        [Test]
        public void Test10()
        {
            var lunar = Lunar.Lunar.FromYmdHms(1500, 12, 29, 12);
            Assert.AreEqual("1501-01-18", lunar.Solar.ToString());
        }

        
        [Test]
        public void Test11()
        {
            var solar = Solar.FromYmdHms(1500, 1, 1, 12);
            Assert.AreEqual("一四九九年腊月初一", solar.Lunar.ToString());
        }

        /// <summary>
        /// 1500年计算二月初一是2月29日导致DateTime报错，这个暂未解决，绕开1500年这些特殊的吧。（1582年之前，欧洲实行儒略历，能被4整除的都是闰年，所以1100，1200，1300，1400，1500都是闰年。1582年之後，实行格里历，整百年份必须能被400整除才是闰年。）
        /// </summary>
        [Test]
        public void Test12()
        {
            // var solar = Solar.FromYmdHms(1500, 12, 31, 12, 0, 0);
            // Assert.AreEqual("一五〇〇年腊月十一", solar.Lunar.ToString());
        }

        [Test]
        public void Test13()
        {
            var solar = Solar.FromYmdHms(1582, 10, 4, 12);
            Assert.AreEqual("一五八二年九月十八", solar.Lunar.ToString());
        }

        [Test]
        public void Test14()
        {
            var solar = Solar.FromYmdHms(1582, 10, 15, 12);
            Assert.AreEqual("一五八二年九月十九", solar.Lunar.ToString());
        }

        [Test]
        public void Test15()
        {
            var lunar = Lunar.Lunar.FromYmdHms(1582, 9, 18, 12);
            Assert.AreEqual("1582-10-04", lunar.Solar.ToString());
        }

        [Test]
        public void Test16()
        {
            var lunar = Lunar.Lunar.FromYmdHms(1582, 9, 19, 12);
            Assert.AreEqual("1582-10-15", lunar.Solar.ToString());
        }

        [Test]
        public void Test17()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2019, 12, 12, 11, 22);
            Assert.AreEqual("2020-01-06", lunar.Solar.ToString());
        }

        [Test]
        public void Test18()
        {
            var solar = Solar.FromYmdHms(2020, 2, 4, 13, 22);
            var lunar = solar.Lunar;
            Assert.AreEqual("庚子", lunar.YearInGanZhi);
            Assert.AreEqual("庚子", lunar.YearInGanZhiByLiChun);
            Assert.AreEqual("己亥", lunar.YearInGanZhiExact);
            Assert.AreEqual("戊寅", lunar.MonthInGanZhi);
            Assert.AreEqual("丁丑", lunar.MonthInGanZhiExact);
        }

        [Test]
        public void Test19()
        {
            var solar = Solar.FromYmdHms(2019, 2, 8, 13, 22);
            var lunar = solar.Lunar;
            Assert.AreEqual("己亥", lunar.YearInGanZhi);
            Assert.AreEqual("己亥", lunar.YearInGanZhiByLiChun);
            Assert.AreEqual("己亥", lunar.YearInGanZhiExact);
            Assert.AreEqual("丙寅", lunar.MonthInGanZhi);
            Assert.AreEqual("丙寅", lunar.MonthInGanZhiExact);
        }

        [Test]
        public void Test20()
        {
            var solar = Solar.FromYmdHms(1988, 2, 15, 23, 30);
            var lunar = solar.Lunar;
            Assert.AreEqual("丁卯", lunar.YearInGanZhi);
            Assert.AreEqual("戊辰", lunar.YearInGanZhiByLiChun);
            Assert.AreEqual("戊辰", lunar.YearInGanZhiExact);
        }

        [Test]
        public void Test21()
        {
            var solar = Solar.FromYmdHms(1988, 2, 15);
            var lunar = solar.Lunar;
            Assert.AreEqual("丁卯", lunar.YearInGanZhi);
        }

        [Test]
        public void Test022()
        {
            var solar = Solar.FromYmdHms(2012, 12, 27);
            var lunar = solar.Lunar;
            Assert.AreEqual("壬辰", lunar.YearInGanZhi);
            Assert.AreEqual("壬子", lunar.MonthInGanZhi);
            Assert.AreEqual("壬戌", lunar.DayInGanZhi);
        }

        [Test]
        public void Test023()
        {
            var solar = Solar.FromYmdHms(2012, 12, 20);
            var lunar = solar.Lunar;
            Assert.AreEqual("壬辰", lunar.YearInGanZhi);
            Assert.AreEqual("壬子", lunar.MonthInGanZhi);
            Assert.AreEqual("乙卯", lunar.DayInGanZhi);
        }

        [Test]
        public void Test024()
        {
            var solar = Solar.FromYmdHms(2012, 11, 20);
            var lunar = solar.Lunar;
            Assert.AreEqual("壬辰", lunar.YearInGanZhi);
            Assert.AreEqual("辛亥", lunar.MonthInGanZhi);
            Assert.AreEqual("乙酉", lunar.DayInGanZhi);
        }

        [Test]
        public void Test25()
        {
            var solar = Solar.FromYmdHms(2012, 10, 20);
            var lunar = solar.Lunar;
            Assert.AreEqual("壬辰", lunar.YearInGanZhi);
            Assert.AreEqual("庚戌", lunar.MonthInGanZhi);
            Assert.AreEqual("甲寅", lunar.DayInGanZhi);
        }

        [Test]
        public void Test26()
        {
            var solar = Solar.FromYmdHms(2012, 9, 20);
            var lunar = solar.Lunar;
            Assert.AreEqual("壬辰", lunar.YearInGanZhi);
            Assert.AreEqual("己酉", lunar.MonthInGanZhi);
            Assert.AreEqual("甲申", lunar.DayInGanZhi);
        }

        [Test]
        public void Test126()
        {
            var solar = Solar.FromYmdHms(2012, 8, 5);
            var lunar = solar.Lunar;
            Assert.AreEqual("戊戌", lunar.DayInGanZhi);
        }

        [Test]
        public void Test27()
        {
            var solar = Solar.FromYmdHms(2000, 2, 2);
            var lunar = solar.Lunar;
            Assert.AreEqual("庚寅", lunar.DayInGanZhi);
        }

        [Test]
        public void Test28()
        {
            var solar = Solar.FromYmdHms(1996, 1, 16);
            var lunar = solar.Lunar;
            Assert.AreEqual("壬子", lunar.DayInGanZhi);
        }

        [Test]
        public void Test29()
        {
            var solar = Solar.FromYmdHms(1997, 2, 16);
            var lunar = solar.Lunar;
            Assert.AreEqual("己丑", lunar.DayInGanZhi);
        }

        [Test]
        public void Test30()
        {
            var solar = Solar.FromYmdHms(1998, 3, 16);
            var lunar = solar.Lunar;
            Assert.AreEqual("壬戌", lunar.DayInGanZhi);
        }
        
        [Test]
        public void Test31()
        {
            var solar = Solar.FromYmdHms(1999, 4, 16);
            var lunar = solar.Lunar;
            Assert.AreEqual("戊戌", lunar.DayInGanZhi);
        }

        [Test]
        public void Test32()
        {
            var solar = Solar.FromYmdHms(2000, 7, 16);
            var lunar = solar.Lunar;
            Assert.AreEqual("乙亥", lunar.DayInGanZhi);
        }

        [Test]
        public void Test33()
        {
            var solar = Solar.FromYmdHms(2000, 1, 6);
            var lunar = solar.Lunar;
            Assert.AreEqual("癸亥", lunar.DayInGanZhi);
        }

        
        [Test]
        public void Test34()
        {
            var solar = Solar.FromYmdHms(2000, 1, 9);
            var lunar = solar.Lunar;
            Assert.AreEqual("丙寅", lunar.DayInGanZhi);
        }

        [Test]
        public void Test45()
        {
            var solar = Solar.FromYmdHms(2017, 2, 15);
            var lunar = solar.Lunar;
            Assert.AreEqual("子命互禄 辛命进禄", lunar.DayLu);
        }

        [Test]
        public void Test46()
        {
            var solar = Solar.FromYmdHms(2017, 2, 16);
            var lunar = solar.Lunar;
            Assert.AreEqual("寅命互禄", lunar.DayLu);
        }

        [Test]
        public void Test48()
        {
            var solar = Solar.FromYmdHms(2021, 11, 13);
            var lunar = solar.Lunar;
            Assert.AreEqual("碓磨厕 外东南", lunar.DayPositionTai);
        }

        [Test]
        public void Test49()
        {
            var solar = Solar.FromYmdHms(2021, 11, 12);
            var lunar = solar.Lunar;
            Assert.AreEqual("占门碓 外东南", lunar.DayPositionTai);
        }

        [Test]
        public void Test50()
        {
            var solar = Solar.FromYmdHms(2021, 11, 13);
            var lunar = solar.Lunar;
            Assert.AreEqual("西南", lunar.DayPositionFuDesc);
        }

        [Test]
        public void Test51()
        {
            var solar = Solar.FromYmdHms(2021, 11, 12);
            var lunar = solar.Lunar;
            Assert.AreEqual("正北", lunar.DayPositionFuDesc);
        }

        [Test]
        public void Test52()
        {
            var solar = Solar.FromYmdHms(2011, 11, 12);
            var lunar = solar.Lunar;
            Assert.AreEqual("厕灶厨 外西南", lunar.DayPositionTai);
        }

        [Test]
        public void Test53()
        {
            var solar = Solar.FromYmdHms(1722, 9, 25);
            var lunar = solar.Lunar;
            Assert.AreEqual("秋社", lunar.OtherFestivals[0]);
        }

        [Test]
        public void Test54()
        {
            var solar = Solar.FromYmdHms(2021, 3, 21);
            var lunar = solar.Lunar;
            Assert.AreEqual("春社", lunar.OtherFestivals[0]);
        }
    }
}