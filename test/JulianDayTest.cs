using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using com.nlf.calendar.util;
using com.nlf.calendar;

namespace test
{
    /// <summary>
    /// JulianDay测试
    /// </summary>
    [TestClass]
    public class JulianDayTest
    {
        public JulianDayTest()
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
        ///getJulianDay () 的测试
        ///</summary>
        [TestMethod()]
        public void testSolar2JD()
        {
            double expected = 2459045.5;
            double actual;

            actual = Solar.fromYmd(2020, 7, 15).getJulianDay();

            Assert.AreEqual(expected, actual, "com.nlf.calendar.Solar.getJulianDay 未返回所需的值。");
        }

        /// <summary>
        ///fromJulianDay (julianDay) 的测试
        ///</summary>
        [TestMethod()]
        public void testJD2Solar()
        {
            string expected = "2020-07-15 00:00:00";
            string actual;

            actual = Solar.fromJulianDay(2459045.5).toYmdhms();

            Assert.AreEqual(expected, actual, "com.nlf.calendar.Solar.fromJulianDay 未返回所需的值。");
        }
    }
}
