using Lunar;
using Xunit;

namespace test
{
    /// <summary>
    /// 年
    /// </summary>
    public class YearTest
    {
        
        [Fact]
        public void Test1()
        {
            var year = new LunarYear(2017);
            Assert.Equal("二龙治水", year.ZhiShui);
            Assert.Equal("二人分饼", year.FenBing);
        }

        [Fact]
        public void Test2()
        {
            var year = new LunarYear(2018);
            Assert.Equal("二龙治水", year.ZhiShui);
            Assert.Equal("八人分饼", year.FenBing);
        }

        [Fact]
        public void Test3()
        {
            var year = new LunarYear(5);
            Assert.Equal("三龙治水", year.ZhiShui);
            Assert.Equal("一人分饼", year.FenBing);
        }

        [Fact]
        public void Test4()
        {
            var year = new LunarYear(2021);
            Assert.Equal("十一牛耕田", year.GengTian);
        }

        [Fact]
        public void Test5()
        {
            var year = new LunarYear(2018);
            Assert.Equal("三日得金", year.DeJin);
        }

        [Fact]
        public void Test6()
        {
            var year = new LunarYear(1864);
            Assert.Equal("上元", year.Yuan);
        }

        [Fact]
        public void Test7()
        {
            var year = new LunarYear(1923);
            Assert.Equal("上元", year.Yuan);
        }

        [Fact]
        public void Test8()
        {
            var year = new LunarYear(1924);
            Assert.Equal("中元", year.Yuan);
        }

        [Fact]
        public void Test9()
        {
            var year = new LunarYear(1983);
            Assert.Equal("中元", year.Yuan);
        }

        [Fact]
        public void Test10()
        {
            var year = new LunarYear(1984);
            Assert.Equal("下元", year.Yuan);
        }

        [Fact]
        public void Test11()
        {
            var year = new LunarYear(2043);
            Assert.Equal("下元", year.Yuan);
        }

        [Fact]
        public void Test12()
        {
            var year = new LunarYear(1864);
            Assert.Equal("一运", year.Yun);
        }

        [Fact]
        public void Test13()
        {
            var year = new LunarYear(1883);
            Assert.Equal("一运", year.Yun);
        }

        [Fact]
        public void Test14()
        {
            var year = new LunarYear(1884);
            Assert.Equal("二运", year.Yun);
        }

        [Fact]
        public void Test15()
        {
            var year = new LunarYear(1903);
            Assert.Equal("二运", year.Yun);
        }

        [Fact]
        public void Test16()
        {
            var year = new LunarYear(1904);
            Assert.Equal("三运", year.Yun);
        }

        [Fact]
        public void Test17()
        {
            var year = new LunarYear(1923);
            Assert.Equal("三运", year.Yun);
        }

        [Fact]
        public void Test18()
        {
            var year = new LunarYear(2004);
            Assert.Equal("八运", year.Yun);
        }
        
        [Fact]
        public void Test19()
        {
            var year = new LunarYear(2023);
            Assert.Equal(384, year.DayCount);
        }
        
        [Fact]
        public void Test20()
        {
            var year = new LunarYear(2021);
            Assert.Equal(354, year.DayCount);
        }
        
        [Fact]
        public void Test21()
        {
            var year = new LunarYear(2022);
            Assert.Equal(355, year.DayCount);
        }
    }
}