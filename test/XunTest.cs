using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Collections.Generic;
using com.nlf.calendar;
using com.nlf.calendar.util;
namespace test
{

    [TestClass()]
    public class XunTest
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
        public void testXun()
        {
            Solar solar = new Solar(2020, 11, 19, 0, 0, 0);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("甲午", lunar.getYearXun());
        }

        [TestMethod()]
        public void testXunKong1()
        {
            Solar solar = new Solar(2020, 11, 19, 0, 0, 0);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("辰巳", lunar.getYearXunKong());
            Assert.AreEqual("午未", lunar.getMonthXunKong());
            Assert.AreEqual("戌亥", lunar.getDayXunKong());
        }

        [TestMethod()]
        public void testBaZiDayXunKong()
        {
            Solar solar = new Solar(1990, 12, 23, 8, 37, 0);
            Lunar lunar = solar.getLunar();
            EightChar eightChar = lunar.getEightChar();
            Assert.AreEqual("子丑", eightChar.getDayXunKong());
        }

    }


}
