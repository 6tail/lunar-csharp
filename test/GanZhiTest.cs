using Lunar;
using NUnit.Framework;

namespace test
{
    /// <summary>
    /// 干支
    /// </summary>
    public class GanZhiTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            const int  year = 2020;
            const int  month = 1;
            const int  day = 1;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.AreEqual("己亥", lunar.YearInGanZhi);
            Assert.AreEqual("己亥", lunar.YearInGanZhiByLiChun);
            Assert.AreEqual("己亥", lunar.YearInGanZhiExact);

            Assert.AreEqual("丙子", lunar.MonthInGanZhi, "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("丙子", lunar.MonthInGanZhiExact);
        }

        [Test]
        public void Test2()
        {
            const int  year = 2020;
            const int  month = 1;
            const int  day = 6;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.AreEqual("己亥", lunar.YearInGanZhi);
            Assert.AreEqual("己亥", lunar.YearInGanZhiByLiChun);
            Assert.AreEqual("己亥", lunar.YearInGanZhiExact);

            Assert.AreEqual("丁丑", lunar.MonthInGanZhi, "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("丁丑", lunar.MonthInGanZhiExact);
        }

        [Test]
        public void Test3()
        {
            const int  year = 2020;
            const int  month = 1;
            const int  day = 20;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.AreEqual("己亥", lunar.YearInGanZhi);
            Assert.AreEqual("己亥", lunar.YearInGanZhiByLiChun);
            Assert.AreEqual("己亥", lunar.YearInGanZhiExact);

            Assert.AreEqual("丁丑", lunar.MonthInGanZhi, "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("丁丑", lunar.MonthInGanZhiExact);
        }

        [Test]
        public void Test4()
        {
            const int  year = 2020;
            const int  month = 1;
            const int  day = 25;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.AreEqual("庚子", lunar.YearInGanZhi);
            Assert.AreEqual("己亥", lunar.YearInGanZhiByLiChun);
            Assert.AreEqual("己亥", lunar.YearInGanZhiExact);

            Assert.AreEqual("丁丑", lunar.MonthInGanZhi, "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("丁丑", lunar.MonthInGanZhiExact);
        }

        [Test]
        public void Test5()
        {
            const int  year = 2020;
            const int  month = 1;
            const int  day = 30;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.AreEqual("庚子", lunar.YearInGanZhi);
            Assert.AreEqual("己亥", lunar.YearInGanZhiByLiChun);
            Assert.AreEqual("己亥", lunar.YearInGanZhiExact);

            Assert.AreEqual("丁丑", lunar.MonthInGanZhi, "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("丁丑", lunar.MonthInGanZhiExact);
        }

        [Test]
        public void Test6()
        {
            const int  year = 2020;
            const int  month = 2;
            const int  day = 1;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.AreEqual("庚子", lunar.YearInGanZhi);
            Assert.AreEqual("己亥", lunar.YearInGanZhiByLiChun);
            Assert.AreEqual("己亥", lunar.YearInGanZhiExact);

            Assert.AreEqual("丁丑", lunar.MonthInGanZhi, "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("丁丑", lunar.MonthInGanZhiExact);
        }

        [Test]
        public void Test7()
        {
            const int  year = 2020;
            const int  month = 2;
            const int  day = 4;
            const int  hour = 13;
            const int  minute = 22;
            
            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.AreEqual("庚子", lunar.YearInGanZhi);
            Assert.AreEqual("庚子", lunar.YearInGanZhiByLiChun);
            Assert.AreEqual("己亥", lunar.YearInGanZhiExact);

            Assert.AreEqual("戊寅", lunar.MonthInGanZhi, "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("丁丑", lunar.MonthInGanZhiExact);
        }

        [Test]
        public void Test8()
        {
            const int  year = 2020;
            const int  month = 2;
            const int  day = 4;
            const int  hour = 18;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.AreEqual("庚子", lunar.YearInGanZhi);
            Assert.AreEqual("庚子", lunar.YearInGanZhiByLiChun);
            Assert.AreEqual("庚子", lunar.YearInGanZhiExact);

            Assert.AreEqual("戊寅", lunar.MonthInGanZhi, "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("戊寅", lunar.MonthInGanZhiExact);
        }


        [Test]
        public void Test9()
        {
            const int  year = 2020;
            const int  month = 2;
            const int  day = 5;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.AreEqual("庚子", lunar.YearInGanZhi);
            Assert.AreEqual("庚子", lunar.YearInGanZhiByLiChun);
            Assert.AreEqual("庚子", lunar.YearInGanZhiExact);

            Assert.AreEqual("戊寅", lunar.MonthInGanZhi, "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("戊寅", lunar.MonthInGanZhiExact);
        }

        [Test]
        public void Test10()
        {
            const int  year = 2020;
            const int  month = 5;
            const int  day = 22;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.AreEqual("庚子", lunar.YearInGanZhi);
            Assert.AreEqual("庚子", lunar.YearInGanZhiByLiChun);
            Assert.AreEqual("庚子", lunar.YearInGanZhiExact);

            Assert.AreEqual("辛巳", lunar.MonthInGanZhi, "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("辛巳", lunar.MonthInGanZhiExact);
        }

        [Test]
        public void Test11()
        {
            const int  year = 2020;
            const int  month = 5;
            const int  day = 23;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.AreEqual("庚子", lunar.YearInGanZhi);
            Assert.AreEqual("庚子", lunar.YearInGanZhiByLiChun);
            Assert.AreEqual("庚子", lunar.YearInGanZhiExact);

            Assert.AreEqual("辛巳", lunar.MonthInGanZhi, "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("辛巳", lunar.MonthInGanZhiExact);
        }

        [Test]
        public void Test12()
        {
            const int  year = 2020;
            const int  month = 5;
            const int  day = 29;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.AreEqual("庚子", lunar.YearInGanZhi);
            Assert.AreEqual("庚子", lunar.YearInGanZhiByLiChun);
            Assert.AreEqual("庚子", lunar.YearInGanZhiExact);

            Assert.AreEqual("辛巳", lunar.MonthInGanZhi, "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("辛巳", lunar.MonthInGanZhiExact);
        }

        [Test]
        public void Test13()
        {
            const int  year = 2020;
            const int  month = 6;
            const int  day = 1;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.AreEqual("庚子", lunar.YearInGanZhi);
            Assert.AreEqual("庚子", lunar.YearInGanZhiByLiChun);
            Assert.AreEqual("庚子", lunar.YearInGanZhiExact);

            Assert.AreEqual("辛巳", lunar.MonthInGanZhi, "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("辛巳", lunar.MonthInGanZhiExact);
        }

        [Test]
        public void Test14()
        {
            const int  year = 2020;
            const int  month = 6;
            const int  day = 29;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.AreEqual("庚子", lunar.YearInGanZhi);
            Assert.AreEqual("庚子", lunar.YearInGanZhiByLiChun);
            Assert.AreEqual("庚子", lunar.YearInGanZhiExact);

            Assert.AreEqual("壬午", lunar.MonthInGanZhi, "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("壬午", lunar.MonthInGanZhiExact);
        }

        [Test]
        public void Test15()
        {
            const int  year = 2019;
            const int  month = 5;
            const int  day = 1;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.AreEqual("己亥", lunar.YearInGanZhi);
            Assert.AreEqual("己亥", lunar.YearInGanZhiByLiChun);
            Assert.AreEqual("己亥", lunar.YearInGanZhiExact);

            Assert.AreEqual("戊辰", lunar.MonthInGanZhi, "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("戊辰", lunar.MonthInGanZhiExact);
        }

        [Test]
        public void Test16()
        {
            const int  year = 1986;
            const int  month = 5;
            const int  day = 29;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.AreEqual("丙寅", lunar.YearInGanZhi);
            Assert.AreEqual("丙寅", lunar.YearInGanZhiByLiChun);
            Assert.AreEqual("丙寅", lunar.YearInGanZhiExact);

            Assert.AreEqual("癸巳", lunar.MonthInGanZhi, "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("癸巳", lunar.MonthInGanZhiExact);
        }

        [Test]
        public void Test17()
        {
            const int  year = 1986;
            const int  month = 5;
            const int  day = 1;
            const int  hour = 1;
            const int  minute = 22;
            
            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.AreEqual("丙寅", lunar.YearInGanZhi);
            Assert.AreEqual("丙寅", lunar.YearInGanZhiByLiChun);
            Assert.AreEqual("丙寅", lunar.YearInGanZhiExact);

            Assert.AreEqual("壬辰", lunar.MonthInGanZhi, "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("壬辰", lunar.MonthInGanZhiExact);
        }

        [Test]
        public void Test18()
        {
            const int  year = 1986;
            const int  month = 5;
            const int  day = 6;
            const int  hour = 1;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.AreEqual("丙寅", lunar.YearInGanZhi);
            Assert.AreEqual("丙寅", lunar.YearInGanZhiByLiChun);
            Assert.AreEqual("丙寅", lunar.YearInGanZhiExact);

            Assert.AreEqual("癸巳", lunar.MonthInGanZhi, "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("壬辰", lunar.MonthInGanZhiExact);
        }

        [Test]
        public void Test19()
        {
            const int  year = 1986;
            const int  month = 5;
            const int  day = 6;
            const int  hour = 23;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.AreEqual("丙寅", lunar.YearInGanZhi);
            Assert.AreEqual("丙寅", lunar.YearInGanZhiByLiChun);
            Assert.AreEqual("丙寅", lunar.YearInGanZhiExact);

            Assert.AreEqual("癸巳", lunar.MonthInGanZhi, "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("癸巳", lunar.MonthInGanZhiExact);
        }
    }
}