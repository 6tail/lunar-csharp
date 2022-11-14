using Lunar;
using Xunit;

namespace test
{
    /// <summary>
    /// 数九
    /// </summary>
    public class ShuJiuTest
    {
        
        [Fact]
        public void Test1()
        {
            var solar = new Solar(2020, 12, 21);
            var lunar = solar.Lunar;
            var shuJiu = lunar.ShuJiu;
            Assert.Equal("一九", shuJiu.ToString());
            Assert.Equal("一九第1天", shuJiu.FullString);
        }

        [Fact]
        public void Test2()
        {
            var solar = new Solar(2020, 12, 22);
            var lunar = solar.Lunar;
            var shuJiu = lunar.ShuJiu;
            Assert.Equal("一九", shuJiu.ToString());
            Assert.Equal("一九第2天", shuJiu.FullString);
        }

        [Fact]
        public void Test3()
        {
            var solar = new Solar(2020, 1, 7);
            var lunar = solar.Lunar;
            var shuJiu = lunar.ShuJiu;
            Assert.Equal("二九", shuJiu.ToString());
            Assert.Equal("二九第8天", shuJiu.FullString);
        }

        [Fact]
        public void Test4()
        {
            var solar = new Solar(2021, 1, 6);
            var lunar = solar.Lunar;
            var shuJiu = lunar.ShuJiu;
            Assert.Equal("二九", shuJiu.ToString());
            Assert.Equal("二九第8天", shuJiu.FullString);
        }

        [Fact]
        public void Test5()
        {
            var solar = new Solar(2021, 1, 8);
            var lunar = solar.Lunar;
            var shuJiu = lunar.ShuJiu;
            Assert.Equal("三九", shuJiu.ToString());
            Assert.Equal("三九第1天", shuJiu.FullString);
        }

        [Fact]
        public void Test6()
        {
            var solar = new Solar(2021, 3, 5);
            var lunar = solar.Lunar;
            var shuJiu = lunar.ShuJiu;
            Assert.Equal("九九", shuJiu.ToString());
            Assert.Equal("九九第3天", shuJiu.FullString);
        }

        [Fact]
        public void Test7()
        {
            var solar = new Solar(2021, 7, 5);
            var lunar = solar.Lunar;
            var shuJiu = lunar.ShuJiu;
            Assert.Null(shuJiu);
        }
    }
}