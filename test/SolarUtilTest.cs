using Lunar.Util;
using Xunit;

namespace test
{
    /// <summary>
    /// 阳历工具
    /// </summary>
    public class SolarUtilTest
    {
        
        [Fact]
        public void GetDaysOfMonthTest()
        {
            var year = 2020;
            var month = 2;
            var expected = 29;
            Assert.Equal(expected, SolarUtil.GetDaysOfMonth(year, month));

            year = 2019;
            month = 2;
            expected = 28;
            Assert.Equal(expected, SolarUtil.GetDaysOfMonth(year, month));

            year = 2020;
            month = 1;
            expected = 31;
            Assert.Equal(expected, SolarUtil.GetDaysOfMonth(year, month));
        }

        [Fact]
        public void GetWeeksOfMonthTest()
        {
            var year = 2019;
            var month = 6;
            var start = 0;
            var expected = 6;
            Assert.Equal(expected, SolarUtil.GetWeeksOfMonth(year, month, start));


            year = 2020;
            month = 4;
            start = 0;
            expected = 5;
            Assert.Equal(expected, SolarUtil.GetWeeksOfMonth(year, month, start));

            year = 2019;
            month = 6;
            start = 1;
            expected = 5;
            Assert.Equal(expected, SolarUtil.GetWeeksOfMonth(year, month, start));
        }

        /// <summary>
        ///isLeapYear (int) 的测试
        ///</summary>
        [Fact]
        public void IsLeapYearTest()
        {
            Assert.Equal(true, SolarUtil.IsLeapYear(2020));
            Assert.Equal(false, SolarUtil.IsLeapYear(2019));
            Assert.Equal(false, SolarUtil.IsLeapYear(1500));
        }
    }
}