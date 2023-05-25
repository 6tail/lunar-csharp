using Lunar;
using System.Linq;
using Xunit;

namespace test
{
    /// <summary>
    /// 节日
    /// </summary>
    public class FestivalTest
    {
        
        [Fact]
        public void Test1()
        {
            var solar = Solar.FromYmdHms(2020, 11, 26);
            Assert.Equal("感恩节", solar.Festivals.First());

            solar = Solar.FromYmdHms(2020, 6, 21);
            Assert.Equal("父亲节", solar.Festivals.First());

            solar = Solar.FromYmdHms(2021, 5, 9);
            Assert.Equal("母亲节", solar.Festivals.First());

            solar = Solar.FromYmdHms(1986, 11, 27);
            Assert.Equal("感恩节", solar.Festivals.First());

            solar = Solar.FromYmdHms(1985, 6, 16);
            Assert.Equal("父亲节", solar.Festivals.First());

            solar = Solar.FromYmdHms(1984, 5, 13);
            Assert.Equal("母亲节", solar.Festivals.First());
        }
    }
}