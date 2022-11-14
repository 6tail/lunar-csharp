using Lunar;
using Xunit;
// ReSharper disable IdentifierTypo

namespace test
{
    /// <summary>
    /// 佛历
    /// </summary>
    public class FotoTest
    {
        
        [Fact]
        public void Test1()
        {
            var foto = Foto.FromLunar(Lunar.Lunar.FromYmdHms(2021, 10, 14));
            Assert.Equal("二五六五年十月十四 (三元降) (四天王巡行)", foto.FullString);
        }

        [Fact]
        public void Test2()
        {
            var foto = Foto.FromLunar(Lunar.Lunar.FromYmdHms(2020, 4, 13));
            Assert.Equal("氐", foto.Xiu);
            Assert.Equal("土", foto.Zheng);
            Assert.Equal("貉", foto.Animal);
            Assert.Equal("东", foto.Gong);
            Assert.Equal("青龙", foto.Shou);
        }
    }
}