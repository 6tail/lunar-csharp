using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Collections.Generic;
using com.nlf.calendar;
using com.nlf.calendar.util;
namespace test
{

    [TestClass()]
    public class YearTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        #region 附加测试属性
        // 
        //编写测试时，可使用以下附加属性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        [TestMethod()]
        public void test1()
        {
            LunarYear year = new LunarYear(2017);
            Assert.AreEqual("二龙治水", year.getZhiShui());
            Assert.AreEqual("二人分饼", year.getFenBing());
        }

        [TestMethod()]
        public void test2()
        {
            LunarYear year = new LunarYear(2018);
            Assert.AreEqual("二龙治水", year.getZhiShui());
            Assert.AreEqual("八人分饼", year.getFenBing());
        }

        [TestMethod()]
        public void test3()
        {
            LunarYear year = new LunarYear(5);
            Assert.AreEqual("三龙治水", year.getZhiShui());
            Assert.AreEqual("一人分饼", year.getFenBing());
        }

        [TestMethod()]
        public void test4()
        {
            LunarYear year = new LunarYear(2021);
            Assert.AreEqual("十一牛耕田", year.getGengTian());
        }

        [TestMethod()]
        public void test5()
        {
            LunarYear year = new LunarYear(2018);
            Assert.AreEqual("三日得金", year.getDeJin());
        }

        [TestMethod()]
        public void test6()
        {
            LunarYear year = new LunarYear(1864);
            Assert.AreEqual("上元", year.getYuan());
        }

        [TestMethod()]
        public void test7()
        {
            LunarYear year = new LunarYear(1923);
            Assert.AreEqual("上元", year.getYuan());
        }

        [TestMethod()]
        public void test8()
        {
            LunarYear year = new LunarYear(1924);
            Assert.AreEqual("中元", year.getYuan());
        }

        [TestMethod()]
        public void test9()
        {
            LunarYear year = new LunarYear(1983);
            Assert.AreEqual("中元", year.getYuan());
        }

        [TestMethod()]
        public void test10()
        {
            LunarYear year = new LunarYear(1984);
            Assert.AreEqual("下元", year.getYuan());
        }

        [TestMethod()]
        public void test11()
        {
            LunarYear year = new LunarYear(2043);
            Assert.AreEqual("下元", year.getYuan());
        }

        [TestMethod()]
        public void test12()
        {
            LunarYear year = new LunarYear(1864);
            Assert.AreEqual("一运", year.getYun());
        }

        [TestMethod()]
        public void test13()
        {
            LunarYear year = new LunarYear(1883);
            Assert.AreEqual("一运", year.getYun());
        }

        [TestMethod()]
        public void test14()
        {
            LunarYear year = new LunarYear(1884);
            Assert.AreEqual("二运", year.getYun());
        }

        [TestMethod()]
        public void test15()
        {
            LunarYear year = new LunarYear(1903);
            Assert.AreEqual("二运", year.getYun());
        }

        [TestMethod()]
        public void test16()
        {
            LunarYear year = new LunarYear(1904);
            Assert.AreEqual("三运", year.getYun());
        }

        [TestMethod()]
        public void test17()
        {
            LunarYear year = new LunarYear(1923);
            Assert.AreEqual("三运", year.getYun());
        }

        [TestMethod()]
        public void test18()
        {
            LunarYear year = new LunarYear(2004);
            Assert.AreEqual("八运", year.getYun());
        }
    }


}
