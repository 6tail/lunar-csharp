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
        
        [Fact]
        public void Test5()
        {
            Assert.Equal(0, Solar.FromYmdHms(1129, 11, 17).Week);
        }
        
        [Fact]
        public void Test6()
        {
            Assert.Equal(5, Solar.FromYmdHms(1129, 11, 1).Week);
        }
        
        [Fact]
        public void Test7()
        {
            Assert.Equal(4, Solar.FromYmdHms(8, 11, 1).Week);
        }
        
        [Fact]
        public void Test8()
        {
            Assert.Equal(0, Solar.FromYmdHms(1582, 9, 30).Week);
        }
        
        [Fact]
        public void Test9()
        {
            Assert.Equal(1, Solar.FromYmdHms(1582, 1, 1).Week);
        }
        
        [Fact]
        public void Test10()
        {
            Assert.Equal(6, Solar.FromYmdHms(1500, 2, 29).Week);
            Assert.Equal(6, Solar.FromYmdHms(1500, 2, 29, 23, 59, 59).Week);
        }
        
        [Fact]
        public void Test11()
        {
            Assert.Equal(3, Solar.FromYmdHms(9865, 7, 26).Week);
            Assert.Equal(3, Solar.FromYmdHms(9865, 7, 26, 23, 59, 59).Week);
        }
    }
}