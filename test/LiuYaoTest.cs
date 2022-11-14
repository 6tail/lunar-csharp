using Lunar;
using Xunit;

namespace test
{
    /// <summary>
    /// 六曜
    /// </summary>
    public class LiuYaoTest
    {
        
        [Fact]
        public void Test1()
        {
            var solar = new Solar(2020, 4, 23);
            var lunar = solar.Lunar;
            Assert.Equal("佛灭", lunar.LiuYao);
        }

        [Fact]
        public void Test2()
        {
            var solar = new Solar(2021, 1, 15);
            var lunar = solar.Lunar;
            Assert.Equal("友引", lunar.LiuYao);
        }

        [Fact]
        public void Test3()
        {
            var solar = new Solar(2017, 1, 5);
            var lunar = solar.Lunar;
            Assert.Equal("先胜", lunar.LiuYao);
        }

        [Fact]
        public void Test4()
        {
            var solar = new Solar(2020, 4, 10);
            var lunar = solar.Lunar;
            Assert.Equal("友引", lunar.LiuYao);
        }

        [Fact]
        public void Test5()
        {
            var solar = new Solar(2020, 6, 11);
            var lunar = solar.Lunar;
            Assert.Equal("大安", lunar.LiuYao);
        }

        [Fact]
        public void Test6()
        {
            var solar = new Solar(2020, 6, 1);
            var lunar = solar.Lunar;
            Assert.Equal("先胜", lunar.LiuYao);
        }

        [Fact]
        public void Test7()
        {
            var solar = new Solar(2020, 12, 8);
            var lunar = solar.Lunar;
            Assert.Equal("先负", lunar.LiuYao);
        }

        [Fact]
        public void Test8()
        {
            var solar = new Solar(2020, 12, 11);
            var lunar = solar.Lunar;
            Assert.Equal("赤口", lunar.LiuYao);
        }
    }
}