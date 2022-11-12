using Lunar;
using NUnit.Framework;
// ReSharper disable IdentifierTypo

namespace test
{
    /// <summary>
    /// 佛历
    /// </summary>
    public class FotoTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var foto = Foto.FromLunar(Lunar.Lunar.FromYmdHms(2021, 10, 14));
            Assert.AreEqual("二五六五年十月十四 (三元降) (四天王巡行)", foto.FullString);
        }

        [Test]
        public void Test2()
        {
            var foto = Foto.FromLunar(Lunar.Lunar.FromYmdHms(2020, 4, 13));
            Assert.AreEqual("氐", foto.Xiu);
            Assert.AreEqual("土", foto.Zheng);
            Assert.AreEqual("貉", foto.Animal);
            Assert.AreEqual("东", foto.Gong);
            Assert.AreEqual("青龙", foto.Shou);
        }
    }
}