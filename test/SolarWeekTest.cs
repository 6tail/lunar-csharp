using Lunar;
using Xunit;

namespace test
{
    /// <summary>
    /// 阳历周
    /// </summary>
    public class SolarWeekTest
    {
        
        [Fact]
        public void Test1()
        {
            var week = SolarWeek.FromYmd(2022, 3, 6, 0);
            Assert.Equal(11, week.IndexInYear);
        }

        [Fact]
        public void Test2()
        {
            var week = SolarWeek.FromYmd(2022, 3, 6, 1);
            Assert.Equal(10, week.IndexInYear);
        }
    }
}