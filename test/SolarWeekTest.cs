using Lunar;
using NUnit.Framework;

namespace test
{
    /// <summary>
    /// 阳历周
    /// </summary>
    public class SolarWeekTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var week = SolarWeek.FromYmd(2022, 3, 6, 0);
            Assert.AreEqual(11, week.IndexInYear);
        }

        [Test]
        public void Test2()
        {
            var week = SolarWeek.FromYmd(2022, 3, 6, 1);
            Assert.AreEqual(10, week.IndexInYear);
        }
    }
}