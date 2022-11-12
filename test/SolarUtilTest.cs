using Lunar.Util;
using NUnit.Framework;

namespace test
{
    /// <summary>
    /// 阳历工具
    /// </summary>
    public class SolarUtilTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetDaysOfMonthTest()
        {
            var year = 2020;
            var month = 2;
            var expected = 29;
            Assert.AreEqual(expected, SolarUtil.GetDaysOfMonth(year, month), "SolarUtil.GetDaysOfMonth 未返回所需的值。");

            year = 2019;
            month = 2;
            expected = 28;
            Assert.AreEqual(expected, SolarUtil.GetDaysOfMonth(year, month), "SolarUtil.GetDaysOfMonth 未返回所需的值。");

            year = 2020;
            month = 1;
            expected = 31;
            Assert.AreEqual(expected, SolarUtil.GetDaysOfMonth(year, month), "SolarUtil.GetDaysOfMonth 未返回所需的值。");
        }

        [Test]
        public void GetWeeksOfMonthTest()
        {
            var year = 2019;
            var month = 6;
            var start = 0;
            var expected = 6;
            Assert.AreEqual(expected, SolarUtil.GetWeeksOfMonth(year, month, start), "SolarUtil.GetWeeksOfMonth 未返回所需的值。");


            year = 2020;
            month = 4;
            start = 0;
            expected = 5;
            Assert.AreEqual(expected, SolarUtil.GetWeeksOfMonth(year, month, start), "SolarUtil.GetWeeksOfMonth 未返回所需的值。");

            year = 2019;
            month = 6;
            start = 1;
            expected = 5;
            Assert.AreEqual(expected, SolarUtil.GetWeeksOfMonth(year, month, start), "SolarUtil.GetWeeksOfMonth 未返回所需的值。");
        }

        /// <summary>
        ///isLeapYear (int) 的测试
        ///</summary>
        [Test]
        public void IsLeapYearTest()
        {
            Assert.AreEqual(true, SolarUtil.IsLeapYear(2020), "SolarUtil.IsLeapYear 未返回所需的值。");
            Assert.AreEqual(false, SolarUtil.IsLeapYear(2019), "SolarUtil.IsLeapYear 未返回所需的值。");
            Assert.AreEqual(false, SolarUtil.IsLeapYear(1500), "SolarUtil.IsLeapYear 未返回所需的值。");
        }
    }
}