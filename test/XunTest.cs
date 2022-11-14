using Lunar;
using Xunit;

namespace test
{
    /// <summary>
    /// 旬
    /// </summary>
    public class XunTest
    {
        
        [Fact]
        public void TestXun()
        {
            var solar = new Solar(2020, 11, 19);
            var lunar = solar.Lunar;
            Assert.Equal("甲午", lunar.YearXun);
        }

        [Fact]
        public void TestXunKong1()
        {
            var solar = new Solar(2020, 11, 19);
            var lunar = solar.Lunar;
            Assert.Equal("辰巳", lunar.YearXunKong);
            Assert.Equal("午未", lunar.MonthXunKong);
            Assert.Equal("戌亥", lunar.DayXunKong);
        }

        [Fact]
        public void TestBaZiDayXunKong()
        {
            var solar = new Solar(1990, 12, 23, 8, 37);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;
            Assert.Equal("子丑", eightChar.DayXunKong);
        }
    }
}