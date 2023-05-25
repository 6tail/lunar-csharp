using Lunar;
using System.Linq;
using Xunit;

namespace test
{
    /// <summary>
    /// 道历
    /// </summary>
    public class TaoTest
    {
        
        [Fact]
        public void Test()
        {
            var tao = Tao.FromLunar(Lunar.Lunar.FromYmdHms(2021, 10, 17, 18));
            Assert.Equal("四七一八年十月十七", tao.ToString());
            Assert.Equal("道歷四七一八年，天運辛丑年，己亥月，癸酉日。十月十七日，酉時。", tao.FullString);
        }

        [Fact]
        public void Test1()
        {
            var tao = Tao.FromYmdHms(4718, 10, 18);
            Assert.Equal(2, tao.Festivals.Count());

            tao = Lunar.Lunar.FromYmdHms(2021, 10, 18).Tao;
            Assert.Equal(2, tao.Festivals.Count());
        }
    }
}