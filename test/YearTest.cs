using Lunar;
using NUnit.Framework;

namespace test
{
    /// <summary>
    /// 年
    /// </summary>
    public class YearTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var year = new LunarYear(2017);
            Assert.AreEqual("二龙治水", year.ZhiShui);
            Assert.AreEqual("二人分饼", year.FenBing);
        }

        [Test]
        public void Test2()
        {
            var year = new LunarYear(2018);
            Assert.AreEqual("二龙治水", year.ZhiShui);
            Assert.AreEqual("八人分饼", year.FenBing);
        }

        [Test]
        public void Test3()
        {
            var year = new LunarYear(5);
            Assert.AreEqual("三龙治水", year.ZhiShui);
            Assert.AreEqual("一人分饼", year.FenBing);
        }

        [Test]
        public void Test4()
        {
            var year = new LunarYear(2021);
            Assert.AreEqual("十一牛耕田", year.GengTian);
        }

        [Test]
        public void Test5()
        {
            var year = new LunarYear(2018);
            Assert.AreEqual("三日得金", year.DeJin);
        }

        [Test]
        public void Test6()
        {
            var year = new LunarYear(1864);
            Assert.AreEqual("上元", year.Yuan);
        }

        [Test]
        public void Test7()
        {
            var year = new LunarYear(1923);
            Assert.AreEqual("上元", year.Yuan);
        }

        [Test]
        public void Test8()
        {
            var year = new LunarYear(1924);
            Assert.AreEqual("中元", year.Yuan);
        }

        [Test]
        public void Test9()
        {
            var year = new LunarYear(1983);
            Assert.AreEqual("中元", year.Yuan);
        }

        [Test]
        public void Test10()
        {
            var year = new LunarYear(1984);
            Assert.AreEqual("下元", year.Yuan);
        }

        [Test]
        public void Test11()
        {
            var year = new LunarYear(2043);
            Assert.AreEqual("下元", year.Yuan);
        }

        [Test]
        public void Test12()
        {
            var year = new LunarYear(1864);
            Assert.AreEqual("一运", year.Yun);
        }

        [Test]
        public void Test13()
        {
            var year = new LunarYear(1883);
            Assert.AreEqual("一运", year.Yun);
        }

        [Test]
        public void Test14()
        {
            var year = new LunarYear(1884);
            Assert.AreEqual("二运", year.Yun);
        }

        [Test]
        public void Test15()
        {
            var year = new LunarYear(1903);
            Assert.AreEqual("二运", year.Yun);
        }

        [Test]
        public void Test16()
        {
            var year = new LunarYear(1904);
            Assert.AreEqual("三运", year.Yun);
        }

        [Test]
        public void Test17()
        {
            var year = new LunarYear(1923);
            Assert.AreEqual("三运", year.Yun);
        }

        [Test]
        public void Test18()
        {
            var year = new LunarYear(2004);
            Assert.AreEqual("八运", year.Yun);
        }
    }
}