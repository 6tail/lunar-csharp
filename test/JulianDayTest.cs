using Lunar;
using Xunit;

namespace test
{
    /// <summary>
    /// 儒略日
    /// </summary>
    public class JulianDayTest
    {
        
        [Fact]
        public void Test1()
        {
            Assert.Equal(2459045.5, Solar.FromYmdHms(2020, 7, 15).JulianDay);
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal("2020-07-15 00:00:00", Solar.FromJulianDay(2459045.5).YmdHms);
        }

        [Fact]
        public void Test7()
        {
            Assert.Equal("2012-09-07 13:29:00", Lunar.Lunar.FromYmdHms(2012, 9, 1).JieQiTable["白露"].YmdHms);
        }

        [Fact]
        public void Test8()
        {
            Assert.Equal("2050-12-07 06:41:00", Lunar.Lunar.FromYmdHms(2050, 12, 1).JieQiTable["DA_XUE"].YmdHms);
        }
    }
}