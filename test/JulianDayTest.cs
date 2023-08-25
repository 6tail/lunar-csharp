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
    }
}