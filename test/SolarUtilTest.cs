using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using com.nlf.calendar.util;

namespace test
{
    /// <summary>
    /// SolarUtil测试
    /// </summary>
    [TestClass]
    public class SolarUtilTest
    {
        public SolarUtilTest()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 其他测试属性
        //
        // 您可以在编写测试时使用下列其他属性:
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前使用 TestInitialize 运行代码 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在运行每个测试之后使用 TestCleanup 运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion


        /// <summary>
        ///getDaysOfMonth (int, int) 的测试
        ///</summary>
        [TestMethod()]
        public void getDaysOfMonthTest()
        {
            int year = 2020;

            int month = 2;

            int expected = 29;
            int actual;

            actual = com.nlf.calendar.util.SolarUtil.getDaysOfMonth(year, month);

            Assert.AreEqual(expected, actual, "com.nlf.calendar.util.SolarUtil.getDaysOfMonth 未返回所需的值。");

            year = 2019;
            month = 2;
            expected = 28;
            actual = com.nlf.calendar.util.SolarUtil.getDaysOfMonth(year, month);
            Assert.AreEqual(expected, actual, "com.nlf.calendar.util.SolarUtil.getDaysOfMonth 未返回所需的值。");

            year = 2020;
            month = 1;
            expected = 31;
            actual = com.nlf.calendar.util.SolarUtil.getDaysOfMonth(year, month);
            Assert.AreEqual(expected, actual, "com.nlf.calendar.util.SolarUtil.getDaysOfMonth 未返回所需的值。");
        }

        /// <summary>
        ///getWeeksOfMonth (int, int, int) 的测试
        ///</summary>
        [TestMethod()]
        public void getWeeksOfMonthTest()
        {
            int year = 2019;

            int month = 6;

            int start = 0;

            int expected = 6;
            int actual;

            actual = com.nlf.calendar.util.SolarUtil.getWeeksOfMonth(year, month, start);

            Assert.AreEqual(expected, actual, "com.nlf.calendar.util.SolarUtil.getWeeksOfMonth 未返回所需的值。");


            year = 2020;
            month = 4;
            start = 0;
            expected = 5;
            actual = com.nlf.calendar.util.SolarUtil.getWeeksOfMonth(year, month, start);
            Assert.AreEqual(expected, actual, "com.nlf.calendar.util.SolarUtil.getWeeksOfMonth 未返回所需的值。");

            year = 2019;
            month = 6;
            start = 1;
            expected = 5;
            actual = com.nlf.calendar.util.SolarUtil.getWeeksOfMonth(year, month, start);
            Assert.AreEqual(expected, actual, "com.nlf.calendar.util.SolarUtil.getWeeksOfMonth 未返回所需的值。");
        }

        /// <summary>
        ///isLeapYear (int) 的测试
        ///</summary>
        [TestMethod()]
        public void isLeapYearTest()
        {
            int year = 2020;

            bool expected = true;
            bool actual;

            actual = com.nlf.calendar.util.SolarUtil.isLeapYear(year);

            Assert.AreEqual(expected, actual, "com.nlf.calendar.util.SolarUtil.isLeapYear 未返回所需的值。");


            year = 2019;
            expected = false;
            actual = com.nlf.calendar.util.SolarUtil.isLeapYear(year);
            Assert.AreEqual(expected, actual, "com.nlf.calendar.util.SolarUtil.isLeapYear 未返回所需的值。");
        }
    }
}
