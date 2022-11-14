using Lunar;
using Xunit;

namespace test
{
    /// <summary>
    /// 干支
    /// </summary>
    public class GanZhiTest
    {
        
        [Fact]
        public void Test1()
        {
            const int  year = 2020;
            const int  month = 1;
            const int  day = 1;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.Equal("己亥", lunar.YearInGanZhi);
            Assert.Equal("己亥", lunar.YearInGanZhiByLiChun);
            Assert.Equal("己亥", lunar.YearInGanZhiExact);

            Assert.Equal("丙子", lunar.MonthInGanZhi);
            Assert.Equal("丙子", lunar.MonthInGanZhiExact);
        }

        [Fact]
        public void Test2()
        {
            const int  year = 2020;
            const int  month = 1;
            const int  day = 6;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.Equal("己亥", lunar.YearInGanZhi);
            Assert.Equal("己亥", lunar.YearInGanZhiByLiChun);
            Assert.Equal("己亥", lunar.YearInGanZhiExact);

            Assert.Equal("丁丑", lunar.MonthInGanZhi);
            Assert.Equal("丁丑", lunar.MonthInGanZhiExact);
        }

        [Fact]
        public void Test3()
        {
            const int  year = 2020;
            const int  month = 1;
            const int  day = 20;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.Equal("己亥", lunar.YearInGanZhi);
            Assert.Equal("己亥", lunar.YearInGanZhiByLiChun);
            Assert.Equal("己亥", lunar.YearInGanZhiExact);

            Assert.Equal("丁丑", lunar.MonthInGanZhi);
            Assert.Equal("丁丑", lunar.MonthInGanZhiExact);
        }

        [Fact]
        public void Test4()
        {
            const int  year = 2020;
            const int  month = 1;
            const int  day = 25;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.Equal("庚子", lunar.YearInGanZhi);
            Assert.Equal("己亥", lunar.YearInGanZhiByLiChun);
            Assert.Equal("己亥", lunar.YearInGanZhiExact);

            Assert.Equal("丁丑", lunar.MonthInGanZhi);
            Assert.Equal("丁丑", lunar.MonthInGanZhiExact);
        }

        [Fact]
        public void Test5()
        {
            const int  year = 2020;
            const int  month = 1;
            const int  day = 30;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.Equal("庚子", lunar.YearInGanZhi);
            Assert.Equal("己亥", lunar.YearInGanZhiByLiChun);
            Assert.Equal("己亥", lunar.YearInGanZhiExact);

            Assert.Equal("丁丑", lunar.MonthInGanZhi);
            Assert.Equal("丁丑", lunar.MonthInGanZhiExact);
        }

        [Fact]
        public void Test6()
        {
            const int  year = 2020;
            const int  month = 2;
            const int  day = 1;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.Equal("庚子", lunar.YearInGanZhi);
            Assert.Equal("己亥", lunar.YearInGanZhiByLiChun);
            Assert.Equal("己亥", lunar.YearInGanZhiExact);

            Assert.Equal("丁丑", lunar.MonthInGanZhi);
            Assert.Equal("丁丑", lunar.MonthInGanZhiExact);
        }

        [Fact]
        public void Test7()
        {
            const int  year = 2020;
            const int  month = 2;
            const int  day = 4;
            const int  hour = 13;
            const int  minute = 22;
            
            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.Equal("庚子", lunar.YearInGanZhi);
            Assert.Equal("庚子", lunar.YearInGanZhiByLiChun);
            Assert.Equal("己亥", lunar.YearInGanZhiExact);

            Assert.Equal("戊寅", lunar.MonthInGanZhi);
            Assert.Equal("丁丑", lunar.MonthInGanZhiExact);
        }

        [Fact]
        public void Test8()
        {
            const int  year = 2020;
            const int  month = 2;
            const int  day = 4;
            const int  hour = 18;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.Equal("庚子", lunar.YearInGanZhi);
            Assert.Equal("庚子", lunar.YearInGanZhiByLiChun);
            Assert.Equal("庚子", lunar.YearInGanZhiExact);

            Assert.Equal("戊寅", lunar.MonthInGanZhi);
            Assert.Equal("戊寅", lunar.MonthInGanZhiExact);
        }


        [Fact]
        public void Test9()
        {
            const int  year = 2020;
            const int  month = 2;
            const int  day = 5;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.Equal("庚子", lunar.YearInGanZhi);
            Assert.Equal("庚子", lunar.YearInGanZhiByLiChun);
            Assert.Equal("庚子", lunar.YearInGanZhiExact);

            Assert.Equal("戊寅", lunar.MonthInGanZhi);
            Assert.Equal("戊寅", lunar.MonthInGanZhiExact);
        }

        [Fact]
        public void Test10()
        {
            const int  year = 2020;
            const int  month = 5;
            const int  day = 22;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.Equal("庚子", lunar.YearInGanZhi);
            Assert.Equal("庚子", lunar.YearInGanZhiByLiChun);
            Assert.Equal("庚子", lunar.YearInGanZhiExact);

            Assert.Equal("辛巳", lunar.MonthInGanZhi);
            Assert.Equal("辛巳", lunar.MonthInGanZhiExact);
        }

        [Fact]
        public void Test11()
        {
            const int  year = 2020;
            const int  month = 5;
            const int  day = 23;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.Equal("庚子", lunar.YearInGanZhi);
            Assert.Equal("庚子", lunar.YearInGanZhiByLiChun);
            Assert.Equal("庚子", lunar.YearInGanZhiExact);

            Assert.Equal("辛巳", lunar.MonthInGanZhi);
            Assert.Equal("辛巳", lunar.MonthInGanZhiExact);
        }

        [Fact]
        public void Test12()
        {
            const int  year = 2020;
            const int  month = 5;
            const int  day = 29;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.Equal("庚子", lunar.YearInGanZhi);
            Assert.Equal("庚子", lunar.YearInGanZhiByLiChun);
            Assert.Equal("庚子", lunar.YearInGanZhiExact);

            Assert.Equal("辛巳", lunar.MonthInGanZhi);
            Assert.Equal("辛巳", lunar.MonthInGanZhiExact);
        }

        [Fact]
        public void Test13()
        {
            const int  year = 2020;
            const int  month = 6;
            const int  day = 1;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.Equal("庚子", lunar.YearInGanZhi);
            Assert.Equal("庚子", lunar.YearInGanZhiByLiChun);
            Assert.Equal("庚子", lunar.YearInGanZhiExact);

            Assert.Equal("辛巳", lunar.MonthInGanZhi);
            Assert.Equal("辛巳", lunar.MonthInGanZhiExact);
        }

        [Fact]
        public void Test14()
        {
            const int  year = 2020;
            const int  month = 6;
            const int  day = 29;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.Equal("庚子", lunar.YearInGanZhi);
            Assert.Equal("庚子", lunar.YearInGanZhiByLiChun);
            Assert.Equal("庚子", lunar.YearInGanZhiExact);

            Assert.Equal("壬午", lunar.MonthInGanZhi);
            Assert.Equal("壬午", lunar.MonthInGanZhiExact);
        }

        [Fact]
        public void Test15()
        {
            const int  year = 2019;
            const int  month = 5;
            const int  day = 1;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.Equal("己亥", lunar.YearInGanZhi);
            Assert.Equal("己亥", lunar.YearInGanZhiByLiChun);
            Assert.Equal("己亥", lunar.YearInGanZhiExact);

            Assert.Equal("戊辰", lunar.MonthInGanZhi);
            Assert.Equal("戊辰", lunar.MonthInGanZhiExact);
        }

        [Fact]
        public void Test16()
        {
            const int  year = 1986;
            const int  month = 5;
            const int  day = 29;
            const int  hour = 13;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.Equal("丙寅", lunar.YearInGanZhi);
            Assert.Equal("丙寅", lunar.YearInGanZhiByLiChun);
            Assert.Equal("丙寅", lunar.YearInGanZhiExact);

            Assert.Equal("癸巳", lunar.MonthInGanZhi);
            Assert.Equal("癸巳", lunar.MonthInGanZhiExact);
        }

        [Fact]
        public void Test17()
        {
            const int  year = 1986;
            const int  month = 5;
            const int  day = 1;
            const int  hour = 1;
            const int  minute = 22;
            
            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.Equal("丙寅", lunar.YearInGanZhi);
            Assert.Equal("丙寅", lunar.YearInGanZhiByLiChun);
            Assert.Equal("丙寅", lunar.YearInGanZhiExact);

            Assert.Equal("壬辰", lunar.MonthInGanZhi);
            Assert.Equal("壬辰", lunar.MonthInGanZhiExact);
        }

        [Fact]
        public void Test18()
        {
            const int  year = 1986;
            const int  month = 5;
            const int  day = 6;
            const int  hour = 1;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.Equal("丙寅", lunar.YearInGanZhi);
            Assert.Equal("丙寅", lunar.YearInGanZhiByLiChun);
            Assert.Equal("丙寅", lunar.YearInGanZhiExact);

            Assert.Equal("癸巳", lunar.MonthInGanZhi);
            Assert.Equal("壬辰", lunar.MonthInGanZhiExact);
        }

        [Fact]
        public void Test19()
        {
            const int  year = 1986;
            const int  month = 5;
            const int  day = 6;
            const int  hour = 23;
            const int  minute = 22;

            var solar = new Solar(year, month, day, hour, minute);
            var lunar = solar.Lunar;

            Assert.Equal("丙寅", lunar.YearInGanZhi);
            Assert.Equal("丙寅", lunar.YearInGanZhiByLiChun);
            Assert.Equal("丙寅", lunar.YearInGanZhiExact);

            Assert.Equal("癸巳", lunar.MonthInGanZhi);
            Assert.Equal("癸巳", lunar.MonthInGanZhiExact);
        }
    }
}