using Lunar;
using NUnit.Framework;

namespace test
{
    /// <summary>
    /// 数九
    /// </summary>
    public class ShuJiuTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var solar = new Solar(2020, 12, 21);
            var lunar = solar.Lunar;
            var shuJiu = lunar.ShuJiu;
            Assert.AreEqual("一九", shuJiu.ToString(), solar.Ymd);
            Assert.AreEqual("一九第1天", shuJiu.FullString, solar.Ymd);
        }

        [Test]
        public void Test2()
        {
            var solar = new Solar(2020, 12, 22);
            var lunar = solar.Lunar;
            var shuJiu = lunar.ShuJiu;
            Assert.AreEqual("一九", shuJiu.ToString(), solar.Ymd);
            Assert.AreEqual("一九第2天", shuJiu.FullString, solar.Ymd);
        }

        [Test]
        public void Test3()
        {
            var solar = new Solar(2020, 1, 7);
            var lunar = solar.Lunar;
            var shuJiu = lunar.ShuJiu;
            Assert.AreEqual("二九", shuJiu.ToString(), solar.Ymd);
            Assert.AreEqual("二九第8天", shuJiu.FullString, solar.Ymd);
        }

        [Test]
        public void Test4()
        {
            var solar = new Solar(2021, 1, 6);
            var lunar = solar.Lunar;
            var shuJiu = lunar.ShuJiu;
            Assert.AreEqual("二九", shuJiu.ToString(), solar.Ymd);
            Assert.AreEqual("二九第8天", shuJiu.FullString, solar.Ymd);
        }

        [Test]
        public void Test5()
        {
            var solar = new Solar(2021, 1, 8);
            var lunar = solar.Lunar;
            var shuJiu = lunar.ShuJiu;
            Assert.AreEqual("三九", shuJiu.ToString(), solar.Ymd);
            Assert.AreEqual("三九第1天", shuJiu.FullString, solar.Ymd);
        }

        [Test]
        public void Test6()
        {
            var solar = new Solar(2021, 3, 5);
            var lunar = solar.Lunar;
            var shuJiu = lunar.ShuJiu;
            Assert.AreEqual("九九", shuJiu.ToString(), solar.Ymd);
            Assert.AreEqual("九九第3天", shuJiu.FullString, solar.Ymd);
        }

        [Test]
        public void Test7()
        {
            var solar = new Solar(2021, 7, 5);
            var lunar = solar.Lunar;
            var shuJiu = lunar.ShuJiu;
            Assert.IsNull(shuJiu);
        }
    }
}