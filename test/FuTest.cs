using Lunar;
using Xunit;

namespace test
{
    /// <summary>
    /// 三伏
    /// </summary>
    public class FuTest
    {
        
        [Fact]
        public void Test1()
        {
            var solar = new Solar(2011, 7, 14);
            var lunar = solar.Lunar;
            var fu = lunar.Fu;
            Assert.Equal("初伏", fu.ToString());
            Assert.Equal("初伏第1天", fu.FullString);
        }

        [Fact]
        public void Test2()
        {
            var solar = new Solar(2011, 7, 23);
            var lunar = solar.Lunar;
            var fu = lunar.Fu;
            Assert.Equal("初伏", fu.ToString());
            Assert.Equal("初伏第10天", fu.FullString);
        }

        [Fact]
        public void Test3()
        {
            var solar = new Solar(2011, 7, 24);
            var lunar = solar.Lunar;
            var fu = lunar.Fu;
            Assert.Equal("中伏", fu.ToString());
            Assert.Equal("中伏第1天", fu.FullString);
        }

        [Fact]
        public void Test4()
        {
            var solar = new Solar(2011, 8, 12);
            var lunar = solar.Lunar;
            var fu = lunar.Fu;
            Assert.Equal("中伏", fu.ToString());
            Assert.Equal("中伏第20天", fu.FullString);
        }

        [Fact]
        public void Test5()
        {
            var solar = new Solar(2011, 8, 13);
            var lunar = solar.Lunar;
            var fu = lunar.Fu;
            Assert.Equal("末伏", fu.ToString());
            Assert.Equal("末伏第1天", fu.FullString);
        }

        [Fact]
        public void Test6()
        {
            var solar = new Solar(2011, 8, 22);
            var lunar = solar.Lunar;
            var fu = lunar.Fu;
            Assert.Equal("末伏", fu.ToString());
            Assert.Equal("末伏第10天", fu.FullString);
        }
        [Fact]
        public void Test7()
        {
            var solar = new Solar(2011, 7, 13);
            var lunar = solar.Lunar;
            var fu = lunar.Fu;
            Assert.Null(fu);
        }

        [Fact]
        public void Test8()
        {
            var solar = new Solar(2011, 8, 23);
            var lunar = solar.Lunar;
            var fu = lunar.Fu;
            Assert.Null(fu);
        }

        [Fact]
        public void Test9()
        {
            var solar = new Solar(2012, 7, 18);
            var lunar = solar.Lunar;
            var fu = lunar.Fu;
            Assert.Equal("初伏", fu.ToString());
            Assert.Equal("初伏第1天", fu.FullString);
        }

        [Fact]
        public void Test10()
        {
            var solar = new Solar(2012, 8, 5);
            var lunar = solar.Lunar;
            var fu = lunar.Fu;
            Assert.Equal("中伏", fu.ToString());
            Assert.Equal("中伏第9天", fu.FullString);
        }

        [Fact]
        public void Test11()
        {
            var solar = new Solar(2012, 8, 8);
            var lunar = solar.Lunar;
            var fu = lunar.Fu;
            Assert.Equal("末伏", fu.ToString());
            Assert.Equal("末伏第2天", fu.FullString);
        }

        [Fact]
        public void Test12()
        {
            var solar = new Solar(2020, 7, 17);
            var lunar = solar.Lunar;
            var fu = lunar.Fu;
            Assert.Equal("初伏", fu.ToString());
            Assert.Equal("初伏第2天", fu.FullString);
        }

        [Fact]
        public void Test13()
        {
            var solar = new Solar(2020, 7, 26);
            var lunar = solar.Lunar;
            var fu = lunar.Fu;
            Assert.Equal("中伏", fu.ToString());
            Assert.Equal("中伏第1天", fu.FullString);
        }

        [Fact]
        public void Test14()
        {
            var solar = new Solar(2020, 8, 24);
            var lunar = solar.Lunar;
            var fu = lunar.Fu;
            Assert.Equal("末伏", fu.ToString());
            Assert.Equal("末伏第10天", fu.FullString);
        }
    }
}