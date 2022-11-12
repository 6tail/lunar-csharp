using Lunar;
using Lunar.EightChar;
using NUnit.Framework;
// ReSharper disable IdentifierTypo

namespace test
{
    /// <summary>
    /// 八字
    /// </summary>
    public class EightCharTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestQiYun()
        {
            var solar = new Solar(1983, 2, 15, 20);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;
            var yun = eightChar.GetYun(0);
            Assert.AreEqual(6, yun.StartYear);
            Assert.AreEqual(2, yun.StartMonth);
            Assert.AreEqual(20, yun.StartDay);
            Assert.AreEqual("1989-05-05", yun.StartSolar.Ymd);

            solar = new Solar(2013, 7, 13, 16, 17);
            lunar = solar.Lunar;
            eightChar = lunar.EightChar;
            yun = eightChar.GetYun(0);
            Assert.AreEqual(8, yun.StartYear);
            Assert.AreEqual(4, yun.StartMonth);
            Assert.AreEqual(0, yun.StartDay);
            Assert.AreEqual("2021-11-13", yun.StartSolar.Ymd);

            solar = new Solar(2020, 8, 18, 10);
            lunar = solar.Lunar;
            eightChar = lunar.EightChar;
            yun = eightChar.GetYun(0);
            Assert.AreEqual(3, yun.StartYear);
            Assert.AreEqual(8, yun.StartMonth);
            Assert.AreEqual(0, yun.StartDay);
            Assert.AreEqual("2024-04-18", yun.StartSolar.Ymd);

            solar = new Solar(1972, 6, 15);
            lunar = solar.Lunar;
            eightChar = lunar.EightChar;
            yun = eightChar.GetYun(1);
            Assert.AreEqual(7, yun.StartYear);
            Assert.AreEqual(5, yun.StartMonth);
            Assert.AreEqual(10, yun.StartDay);
            Assert.AreEqual("1979-11-25", yun.StartSolar.Ymd);

            solar = new Solar(1968, 11, 22);
            lunar = solar.Lunar;
            eightChar = lunar.EightChar;
            yun = eightChar.GetYun(1);
            Assert.AreEqual(5, yun.StartYear);
            Assert.AreEqual(1, yun.StartMonth);
            Assert.AreEqual(20, yun.StartDay);
            Assert.AreEqual("1974-01-11", yun.StartSolar.Ymd);

            solar = new Solar(1968, 11, 23);
            lunar = solar.Lunar;
            eightChar = lunar.EightChar;
            yun = eightChar.GetYun(1);
            Assert.AreEqual(4, yun.StartYear);
            Assert.AreEqual(9, yun.StartMonth);
            Assert.AreEqual(20, yun.StartDay);
            Assert.AreEqual("1973-09-12", yun.StartSolar.Ymd);
        }

        /// <summary>
        ///大运
        ///</summary>
        [Test]
        public void TestDaYun()
        {
            int[] startYears = { 1983, 1989, 1999, 2009, 2019, 2029, 2039, 2049, 2059, 2069 };
            int[] endYears = { 1988, 1998, 2008, 2018, 2028, 2038, 2048, 2058, 2068, 2078 };
            int[] startAges = { 1, 7, 17, 27, 37, 47, 57, 67, 77, 87 };
            int[] endAges = { 6, 16, 26, 36, 46, 56, 66, 76, 86, 96 };
            string[] yearGanZhi = { "", "乙卯", "丙辰", "丁巳", "戊午", "己未", "庚申", "辛酉", "壬戌", "癸亥" };
            var solar = new Solar(1983, 2, 15, 20);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;
            var yun = eightChar.GetYun(0);
            DaYun[] l = yun.GetDaYun();
            for (int i = 0, j = l.Length; i < j; i++)
            {
                DaYun daYun = l[i];
                Assert.AreEqual(startYears[i], daYun.StartYear);
                Assert.AreEqual(endYears[i], daYun.EndYear);
                Assert.AreEqual(startAges[i], daYun.StartAge);
                Assert.AreEqual(endAges[i], daYun.EndAge);
                Assert.AreEqual(yearGanZhi[i], daYun.GanZhi);
            }
        }

        /// <summary>
        ///流年
        ///</summary>
        [Test]
        public void TestLiuNian()
        {
            var solar = new Solar(1983, 2, 15, 20);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;
            var yun = eightChar.GetYun(0);
            DaYun[] daYun = yun.GetDaYun();

            int[] years = { 1983, 1984, 1985, 1986, 1987, 1988 };
            int[] ages = { 1, 2, 3, 4, 5, 6 };
            string[] ganZhi = { "癸亥", "甲子", "乙丑", "丙寅", "丁卯", "戊辰" };
            LiuNian[] l = daYun[0].GetLiuNian();
            for (int i = 0, j = l.Length; i < j; i++)
            {
                LiuNian liuNian = l[i];
                Assert.AreEqual(years[i], liuNian.Year);
                Assert.AreEqual(ages[i], liuNian.Age);
                Assert.AreEqual(ganZhi[i], liuNian.GanZhi);
            }

            years = new[] { 2029, 2030, 2031, 2032, 2033, 2034, 2035, 2036, 2037, 2038 };
            ages = new[] { 47, 48, 49, 50, 51, 52, 53, 54, 55, 56 };
            ganZhi = new[] { "己酉", "庚戌", "辛亥", "壬子", "癸丑", "甲寅", "乙卯", "丙辰", "丁巳", "戊午" };
            l = daYun[5].GetLiuNian();
            for (int i = 0, j = l.Length; i < j; i++)
            {
                var liuNian = l[i];
                Assert.AreEqual(years[i], liuNian.Year);
                Assert.AreEqual(ages[i], liuNian.Age);
                Assert.AreEqual(ganZhi[i], liuNian.GanZhi, years[i] + "年");
            }
        }

        /// <summary>
        ///小运
        ///</summary>
        [Test]
        public void TestXiaoYun()
        {
            var solar = new Solar(1983, 2, 15, 20);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;
            var yun = eightChar.GetYun(0);
            DaYun[] daYun = yun.GetDaYun();

            int[] years = { 1983, 1984, 1985, 1986, 1987, 1988 };
            int[] ages = { 1, 2, 3, 4, 5, 6 };
            string[] ganZhi = { "乙亥", "丙子", "丁丑", "戊寅", "己卯", "庚辰" };
            XiaoYun[] l = daYun[0].GetXiaoYun();
            for (int i = 0, j = l.Length; i < j; i++)
            {
                var xiaoYun = l[i];
                Assert.AreEqual(years[i], xiaoYun.Year);
                Assert.AreEqual(ages[i], xiaoYun.Age);
                Assert.AreEqual(ganZhi[i], xiaoYun.GanZhi);
            }

            years = new[] { 2029, 2030, 2031, 2032, 2033, 2034, 2035, 2036, 2037, 2038 };
            ages = new[] { 47, 48, 49, 50, 51, 52, 53, 54, 55, 56 };
            ganZhi = new[] { "辛酉", "壬戌", "癸亥", "甲子", "乙丑", "丙寅", "丁卯", "戊辰", "己巳", "庚午" };
            l = daYun[5].GetXiaoYun();
            for (int i = 0, j = l.Length; i < j; i++)
            {
                var xiaoYun = l[i];
                Assert.AreEqual(years[i], xiaoYun.Year);
                Assert.AreEqual(ages[i], xiaoYun.Age);
                Assert.AreEqual(ganZhi[i], xiaoYun.GanZhi, years[i] + "年");
            }
        }

        /// <summary>
        ///流月
        ///</summary>
        [Test]
        public void TestLiuYue()
        {
            var solar = new Solar(1983, 2, 15, 20);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;
            var yun = eightChar.GetYun(0);
            var daYun = yun.GetDaYun();

            string[] ganZhi = { "甲寅", "乙卯", "丙辰", "丁巳", "戊午", "己未", "庚申", "辛酉", "壬戌", "癸亥", "甲子", "乙丑" };
            var liuNian = daYun[0].GetLiuNian();
            var l = liuNian[0].GetLiuYue();
            for (int i = 0, j = l.Length; i < j; i++)
            {
                var liuYue = l[i];
                Assert.AreEqual(ganZhi[i], liuYue.GanZhi);
            }

            ganZhi = new[] { "庚寅", "辛卯", "壬辰", "癸巳", "甲午", "乙未", "丙申", "丁酉", "戊戌", "己亥", "庚子", "辛丑" };
            liuNian = daYun[4].GetLiuNian();
            l = liuNian[2].GetLiuYue();
            for (int i = 0, j = l.Length; i < j; i++)
            {
                var liuYue = l[i];
                Assert.AreEqual(ganZhi[i], liuYue.GanZhi);
            }
        }

        [Test]
        public void TestGanZhi()
        {
            var solar = new Solar(1988, 2, 15, 23, 30);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;

            Assert.AreEqual("戊辰", eightChar.Year, "年柱");
            Assert.AreEqual("甲寅", eightChar.Month, "月柱");
            Assert.AreEqual("庚子", eightChar.Day, "日柱");
            Assert.AreEqual("戊子", eightChar.Time, "时柱");

            eightChar.Sect = 1;
            Assert.AreEqual("戊辰", eightChar.Year, "年柱");
            Assert.AreEqual("甲寅", eightChar.Month, "月柱");
            Assert.AreEqual("辛丑", eightChar.Day, "日柱");
            Assert.AreEqual("戊子", eightChar.Time, "时柱");

            solar = new Solar(1988, 2, 15, 22, 30);
            lunar = solar.Lunar;
            eightChar = lunar.EightChar;
            Assert.AreEqual("戊辰", eightChar.Year, "年柱");
            Assert.AreEqual("甲寅", eightChar.Month, "月柱");
            Assert.AreEqual("庚子", eightChar.Day, "日柱");
            Assert.AreEqual("丁亥", eightChar.Time, "时柱");

            solar = new Solar(1988, 2, 2, 22, 30);
            lunar = solar.Lunar;
            eightChar = lunar.EightChar;
            Assert.AreEqual("丁卯", eightChar.Year, "年柱");
            Assert.AreEqual("癸丑", eightChar.Month, "月柱");
            Assert.AreEqual("丁亥", eightChar.Day, "日柱");
            Assert.AreEqual("辛亥", eightChar.Time, "时柱");
        }

        [Test]
        public void TestEightChar2Solar()
        {
            var l = Solar.FromBaZi("辛丑", "丁酉", "丙寅", "戊戌");
            string[] solarList = { "2021-09-15 20:00:00 星期三 处女座", "1961-09-30 20:00:00 星期六 天秤座" };
            for (int i = 0, j = solarList.Length; i < j; i++)
            {
                Assert.AreEqual(solarList[i], l[i].FullString);
            }
        }

        [Test]
        public void Test5()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2019, 12, 12, 11, 22);
            var eightChar = lunar.EightChar;

            Assert.AreEqual("己亥", eightChar.Year, "年柱");
            Assert.AreEqual("丁丑", eightChar.Month, "月柱");
            Assert.AreEqual("戊申", eightChar.Day, "日柱");
            Assert.AreEqual("戊午", eightChar.Time, "时柱");
        }

        [Test]
        public void Test6()
        {
            var lunar = Lunar.Lunar.FromYmdHms(1985, 12, 27);
            var eightChar = lunar.EightChar;
            Assert.AreEqual("1995-11-05", eightChar.GetYun(1).StartSolar.Ymd);
        }

        [Test]
        public void TestShenGong()
        {
            var solar = new Solar(1995, 12, 18, 10, 28);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;

            Assert.AreEqual("壬午", eightChar.ShenGong);
        }

        [Test]
        public void TestShenGong1()
        {
            var solar = new Solar(1994, 12, 6, 2);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;

            Assert.AreEqual("丁丑", eightChar.ShenGong);
        }

        [Test]
        public void TestShenGong2()
        {
            var solar = new Solar(1990, 12, 11, 6);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;

            Assert.AreEqual("庚辰", eightChar.ShenGong);
        }

        [Test]
        public void TestShenGong3()
        {
            var solar = new Solar(1993, 5, 23, 4);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;

            Assert.AreEqual("庚申", eightChar.ShenGong);
        }
        
        [Test]
        public void Test10()
        {
            var lunar = Solar.FromYmdHms(1988, 2, 15, 23, 30).Lunar;
            var eightChar = lunar.EightChar;

            Assert.AreEqual("戊辰", eightChar.Year, "年柱");
            Assert.AreEqual("甲寅", eightChar.Month, "月柱");
            Assert.AreEqual("庚子", eightChar.Day, "日柱");
            Assert.AreEqual("戊子", eightChar.Time, "时柱");
        }
        
        [Test]
        public void Test11()
        {
            var lunar = Lunar.Lunar.FromYmdHms(1987, 12, 28, 23, 30);
            var eightChar = lunar.EightChar;

            Assert.AreEqual("戊辰", eightChar.Year, "年柱");
            Assert.AreEqual("甲寅", eightChar.Month, "月柱");
            Assert.AreEqual("庚子", eightChar.Day, "日柱");
            Assert.AreEqual("戊子", eightChar.Time, "时柱");
        }
    }
}