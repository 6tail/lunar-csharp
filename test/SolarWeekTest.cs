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
        
        [Fact]
        public void Test3()
        {
            var solar = Solar.FromYmdHms(1582, 10, 1);
            Assert.Equal(1, solar.Week);
        }
        
        [Fact]
        public void Test4()
        {
            var solar = Solar.FromYmdHms(1582, 10, 15);
            Assert.Equal(5, solar.Week);
        }
    }
}