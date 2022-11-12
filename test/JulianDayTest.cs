using Lunar;
using NUnit.Framework;

namespace test
{
    /// <summary>
    /// 儒略日
    /// </summary>
    public class JulianDayTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(2459045.5, Solar.FromYmdHms(2020, 7, 15).JulianDay);
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual("2020-07-15 00:00:00", Solar.FromJulianDay(2459045.5).YmdHms);
        }

        [Test]
        public void Test7()
        {
            Assert.AreEqual("2012-09-07 13:29:00", Lunar.Lunar.FromYmdHms(2012, 9, 1).JieQiTable["白露"].YmdHms);
        }

        [Test]
        public void Test8()
        {
            Assert.AreEqual("2050-12-07 06:41:00", Lunar.Lunar.FromYmdHms(2050, 12, 1).JieQiTable["DA_XUE"].YmdHms);
        }
    }
}