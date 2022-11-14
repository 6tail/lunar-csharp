using Lunar;
using Xunit;

namespace test
{
    /// <summary>
    /// 星座
    /// </summary>
    // ReSharper disable once IdentifierTypo
    public class XingZuoTest
    {
        
        [Fact]
        public void Test1()
        {
            var solar = new Solar(2020, 3, 21);
            Assert.Equal("白羊", solar.XingZuo);
            solar = new Solar(2020, 4, 19);
            Assert.Equal("白羊", solar.XingZuo);
        }

        [Fact]
        public void Test2()
        {
            var solar = new Solar(2020, 4, 20);
            Assert.Equal("金牛", solar.XingZuo);
            solar = new Solar(2020, 5, 20);
            Assert.Equal("金牛", solar.XingZuo);
        }

        [Fact]
        public void Test3()
        {
            var solar = new Solar(2020, 5, 21);
            Assert.Equal("双子", solar.XingZuo);
            solar = new Solar(2020, 6, 21);
            Assert.Equal("双子", solar.XingZuo);
        }

        [Fact]
        public void Test4()
        {
            var solar = new Solar(2020, 6, 22);
            Assert.Equal("巨蟹", solar.XingZuo);
            solar = new Solar(2020, 7, 22);
            Assert.Equal("巨蟹", solar.XingZuo);
        }

        [Fact]
        public void Test5()
        {
            var solar = new Solar(2020, 7, 23);
            Assert.Equal("狮子", solar.XingZuo);
            solar = new Solar(2020, 8, 22);
            Assert.Equal("狮子", solar.XingZuo);
        }

        [Fact]
        public void Test6()
        {
            var solar = new Solar(2020, 8, 23);
            Assert.Equal("处女", solar.XingZuo);
            solar = new Solar(2020, 9, 22);
            Assert.Equal("处女", solar.XingZuo);
        }

        [Fact]
        public void Test7()
        {
            var solar = new Solar(2020, 9, 23);
            Assert.Equal("天秤", solar.XingZuo);
            solar = new Solar(2020, 10, 23);
            Assert.Equal("天秤", solar.XingZuo);
        }

        [Fact]
        public void Test8()
        {
            var solar = new Solar(2020, 10, 24);
            Assert.Equal("天蝎", solar.XingZuo);
            solar = new Solar(2020, 11, 22);
            Assert.Equal("天蝎", solar.XingZuo);
        }

        [Fact]
        public void Test9()
        {
            var solar = new Solar(2020, 11, 23);
            Assert.Equal("射手", solar.XingZuo);
            solar = new Solar(2020, 12, 21);
            Assert.Equal("射手", solar.XingZuo);
        }

        [Fact]
        public void Test10()
        {
            var solar = new Solar(2020, 12, 22);
            Assert.Equal("摩羯", solar.XingZuo);
            solar = new Solar(2021, 1, 19);
            Assert.Equal("摩羯", solar.XingZuo);
        }

        [Fact]
        public void Test11()
        {
            var solar = new Solar(2021, 1, 20);
            Assert.Equal("水瓶", solar.XingZuo);
            solar = new Solar(2021, 2, 18);
            Assert.Equal("水瓶", solar.XingZuo);
        }

        [Fact]
        public void Test12()
        {
            var solar = new Solar(2021, 2, 19);
            Assert.Equal("双鱼", solar.XingZuo);
            solar = new Solar(2021, 3, 20);
            Assert.Equal("双鱼", solar.XingZuo);
        }
    }
}