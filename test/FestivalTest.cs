using Lunar;
using NUnit.Framework;

namespace test
{
    /// <summary>
    /// 节日
    /// </summary>
    public class FestivalTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var solar = Solar.FromYmdHms(2020, 11, 26);
            Assert.AreEqual("感恩节", solar.Festivals[0]);

            solar = Solar.FromYmdHms(2020, 6, 21);
            Assert.AreEqual("父亲节", solar.Festivals[0]);

            solar = Solar.FromYmdHms(2021, 5, 9);
            Assert.AreEqual("母亲节", solar.Festivals[0]);

            solar = Solar.FromYmdHms(1986, 11, 27);
            Assert.AreEqual("感恩节", solar.Festivals[0]);

            solar = Solar.FromYmdHms(1985, 6, 16);
            Assert.AreEqual("父亲节", solar.Festivals[0]);

            solar = Solar.FromYmdHms(1984, 5, 13);
            Assert.AreEqual("母亲节", solar.Festivals[0]);
        }
    }
}