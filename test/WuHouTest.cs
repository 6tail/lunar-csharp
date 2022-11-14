using Lunar;
using Xunit;

namespace test
{
    /// <summary>
    /// 物候
    /// </summary>
    public class WuHouTest
    {
        
        [Fact]
        public void Test1()
        {
            var solar = new Solar(2020, 4, 23);
            var lunar = solar.Lunar;
            Assert.Equal("萍始生", lunar.WuHou);
        }

        [Fact]
        public void Test2()
        {
            var solar = new Solar(2021, 1, 15);
            var lunar = solar.Lunar;
            Assert.Equal("雉始雊", lunar.WuHou);
        }

        [Fact]
        public void Test3()
        {
            var solar = new Solar(2017, 1, 5);
            var lunar = solar.Lunar;
            Assert.Equal("雁北乡", lunar.WuHou);
        }

        [Fact]
        public void Test4()
        {
            var solar = new Solar(2020, 4, 10);
            var lunar = solar.Lunar;
            Assert.Equal("田鼠化为鴽", lunar.WuHou);
        }

        [Fact]
        public void Test5()
        {
            var solar = new Solar(2020, 6, 11);
            var lunar = solar.Lunar;
            Assert.Equal("鵙始鸣", lunar.WuHou);
        }

        [Fact]
        public void Test6()
        {
            var solar = new Solar(2020, 6, 1);
            var lunar = solar.Lunar;
            Assert.Equal("麦秋至", lunar.WuHou);
        }

        [Fact]
        public void Test7()
        {
            var solar = new Solar(2020, 12, 8);
            var lunar = solar.Lunar;
            Assert.Equal("鹖鴠不鸣", lunar.WuHou);
        }

        [Fact]
        public void Test8()
        {
            var solar = new Solar(2020, 12, 11);
            var lunar = solar.Lunar;
            Assert.Equal("鹖鴠不鸣", lunar.WuHou);
        }

        [Fact]
        public void Test10()
        {
            var solar = new Solar(1982, 12, 22);
            var lunar = solar.Lunar;
            Assert.Equal("蚯蚓结", lunar.WuHou);
        }

        [Fact]
        public void Test11()
        {
            var solar = new Solar(2021, 12, 21);
            var lunar = solar.Lunar;
            Assert.Equal("冬至 初候", lunar.Hou);
        }

        [Fact]
        public void Test12()
        {
            var solar = new Solar(2021, 12, 26);
            var lunar = solar.Lunar;
            Assert.Equal("冬至 二候", lunar.Hou);
        }

        [Fact]
        public void Test13()
        {
            var solar = new Solar(2021, 12, 31);
            var lunar = solar.Lunar;
            Assert.Equal("冬至 三候", lunar.Hou);
        }

        [Fact]
        public void Test14()
        {
            var solar = new Solar(2022, 1, 5);
            var lunar = solar.Lunar;
            Assert.Equal("小寒 初候", lunar.Hou);
        }
        
        [Fact]
        public void Test15()
        {
            var solar = new Solar(2022, 8, 22);
            var lunar = solar.Lunar;
            Assert.Equal("寒蝉鸣", lunar.WuHou);
        }
        
        [Fact]
        public void Test16()
        {
            var solar = new Solar(2022, 8, 23);
            var lunar = solar.Lunar;
            Assert.Equal("鹰乃祭鸟", lunar.WuHou);
        }
    }
}