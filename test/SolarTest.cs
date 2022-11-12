using Lunar;
using NUnit.Framework;

namespace test
{
    /// <summary>
    /// 阳历
    /// </summary>
    public class SolarTest
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// next 的测试
        ///</summary>
        [Test]
        public void TestNext()
        {
            Solar date = new Solar(2020, 1, 23);
            Assert.AreEqual("2020-01-24", date.Next(1).ToString(), "com.nlf.calendar.Solar.Next 有错。");
            // 仅工作日，跨越春节假期
            Assert.AreEqual("2020-02-03", date.Next(1, true).ToString(), "com.nlf.calendar.Solar.Next 有错。");

            date = new Solar(2020, 2, 3);
            Assert.AreEqual("2020-01-31", date.Next(-3).ToString(), "com.nlf.calendar.Solar.Next 有错。");
            // 仅工作日，跨越春节假期
            Assert.AreEqual("2020-01-21", date.Next(-3, true).ToString(), "com.nlf.calendar.Solar.Next 有错。");

            date = new Solar(2020, 2, 9);
            Assert.AreEqual("2020-02-15", date.Next(6).ToString(), "com.nlf.calendar.Solar.Next 有错。");
            // 仅工作日，跨越周末
            Assert.AreEqual("2020-02-17", date.Next(6, true).ToString(), "com.nlf.calendar.Solar.Next 有错。");

            date = new Solar(2020, 1, 17);
            Assert.AreEqual("2020-01-18", date.Next(1).ToString(), "com.nlf.calendar.Solar.Next 有错。");
            // 仅工作日，周日调休按上班算
            Assert.AreEqual("2020-01-19", date.Next(1, true).ToString(), "com.nlf.calendar.Solar.Next 有错。");

        }

        /// <summary>
        /// 
        ///</summary>
        [Test]
        public void TestConvert()
        {
            var solar = new Solar(2020, 1, 23);
            var lunar = solar.Lunar;
            Assert.AreEqual("二〇一九年腊月廿九", lunar.ToString());
            Assert.AreEqual("2020-01-23", lunar.Solar.ToString());
        }

        /// <summary>
        /// 
        ///</summary>
        [Test]
        public void TestConvert1()
        {
            var lunar = new Lunar.Lunar(2019, 12, 29);
            Assert.AreEqual("二〇一九年腊月廿九", lunar.ToString());
            Assert.AreEqual("2020-01-23", lunar.Solar.ToString());
        }

        [Test]
        public void Test1()
        {
            var solar = Solar.FromYmdHms(2020, 5, 24, 13);
            Assert.AreEqual("二〇二〇年闰四月初二", solar.Lunar.ToString());
        }

        [Test]
        public void Test6()
        {
            var solar = Solar.FromYmdHms(11, 1, 1);
            Assert.AreEqual("一〇年腊月初八", solar.Lunar.ToString());
        }

        [Test]
        public void Test7()
        {
            var solar = Solar.FromYmdHms(11, 3, 1);
            Assert.AreEqual("一一年二月初八", solar.Lunar.ToString());
        }

        [Test]
        public void Test9()
        {
            var solar = Solar.FromYmdHms(26, 4, 13);
            Assert.AreEqual("二六年三月初八", solar.Lunar.ToString());
        }

        [Test]
        public void Test10()
        {
            var solar = Solar.FromYmdHms(2022, 3, 28);
            Assert.AreEqual("全国中小学生安全教育日", solar.Festivals[0]);
        }
    }
}