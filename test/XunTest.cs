using Lunar;
using NUnit.Framework;

namespace test
{
    /// <summary>
    /// 旬
    /// </summary>
    public class XunTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestXun()
        {
            var solar = new Solar(2020, 11, 19);
            var lunar = solar.Lunar;
            Assert.AreEqual("甲午", lunar.YearXun);
        }

        [Test]
        public void TestXunKong1()
        {
            var solar = new Solar(2020, 11, 19);
            var lunar = solar.Lunar;
            Assert.AreEqual("辰巳", lunar.YearXunKong);
            Assert.AreEqual("午未", lunar.MonthXunKong);
            Assert.AreEqual("戌亥", lunar.DayXunKong);
        }

        [Test]
        public void TestBaZiDayXunKong()
        {
            var solar = new Solar(1990, 12, 23, 8, 37);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;
            Assert.AreEqual("子丑", eightChar.DayXunKong);
        }
    }
}