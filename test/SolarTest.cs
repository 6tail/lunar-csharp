// 以下代码由 Microsoft Visual Studio 2005 生成。
// 测试所有者应该检查每个测试的有效性。
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Collections.Generic;
using com.nlf.calendar;
using com.nlf.calendar.util;
namespace test
{
    /// <summary>
    ///这是 com.nlf.calendar.Solar 的测试类，旨在
    ///包含所有 com.nlf.calendar.Solar 单元测试
    ///</summary>
    [TestClass()]
    public class SolarTest
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


        /// <summary>
        /// next 的测试
        ///</summary>
        [TestMethod()]
        public void testNext()
        {
            Solar date = new Solar(2020, 1, 23);
            Assert.AreEqual("2020-01-24", date.next(1).ToString(), "com.nlf.calendar.Solar.next 有错。");
            // 仅工作日，跨越春节假期
            Assert.AreEqual("2020-02-03", date.next(1, true).ToString(), "com.nlf.calendar.Solar.next 有错。");

            date = new Solar(2020, 2, 3);
            Assert.AreEqual("2020-01-31", date.next(-3).ToString(), "com.nlf.calendar.Solar.next 有错。");
            // 仅工作日，跨越春节假期
            Assert.AreEqual("2020-01-21", date.next(-3, true).ToString(), "com.nlf.calendar.Solar.next 有错。");

            date = new Solar(2020, 2, 9);
            Assert.AreEqual("2020-02-15", date.next(6).ToString(), "com.nlf.calendar.Solar.next 有错。");
            // 仅工作日，跨越周末
            Assert.AreEqual("2020-02-17", date.next(6, true).ToString(), "com.nlf.calendar.Solar.next 有错。");

            date = new Solar(2020, 1, 17);
            Assert.AreEqual("2020-01-18", date.next(1).ToString(), "com.nlf.calendar.Solar.next 有错。");
            // 仅工作日，周日调休按上班算
            Assert.AreEqual("2020-01-19", date.next(1, true).ToString(), "com.nlf.calendar.Solar.next 有错。");

        }

        /// <summary>
        /// 
        ///</summary>
        [TestMethod()]
        public void testConvert()
        {
            Solar solar = new Solar(2020, 1, 23);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("二〇一九年腊月廿九", lunar.ToString(), "com.nlf.calendar.Solar.getLunar 有错。");
            Assert.AreEqual("2020-01-23", lunar.getSolar().ToString(), "com.nlf.calendar.Lunar.getSolar 有错。");
        }

        /// <summary>
        /// 
        ///</summary>
        [TestMethod()]
        public void testConvert1()
        {
            Lunar lunar = new Lunar(2019, 12, 29);
            Assert.AreEqual("二〇一九年腊月廿九", lunar.ToString(), "com.nlf.calendar.Solar.getLunar 有错。");
            Assert.AreEqual("2020-01-23", lunar.getSolar().ToString(), "com.nlf.calendar.Lunar.getSolar 有错。");
        }

        [TestMethod()]
        public void testLeapYear()
        {
            Assert.AreEqual(false, SolarUtil.isLeapYear(1500));
        }


        [TestMethod()]
        public void test1()
        {
            Solar solar = Solar.fromYmdHms(2020, 5, 24, 13, 0, 0);
            Assert.AreEqual("二〇二〇年闰四月初二", solar.getLunar().ToString());
        }

        [TestMethod()]
        public void test6()
        {
            Solar solar = Solar.fromYmd(11, 1, 1);
            Assert.AreEqual("一〇年腊月初八", solar.getLunar().ToString());
        }

        [TestMethod()]
        public void test7()
        {
            Solar solar = Solar.fromYmd(11, 3, 1);
            Assert.AreEqual("一一年二月初八", solar.getLunar().ToString());
        }

        [TestMethod()]
        public void test9()
        {
            Solar solar = Solar.fromYmd(26, 4, 13);
            Assert.AreEqual("二六年三月初八", solar.getLunar().ToString());
        }
    }


}
