using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using com.nlf.calendar;

namespace test
{
    /// <summary>
    /// SolarUtil测试
    /// </summary>
    [TestClass]
    public class GanZhiTest
    {
        public GanZhiTest()
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


        [TestMethod()]
        public void test1()
        {
            int year = 2020;
            int month = 1;
            int day = 1;
            int hour = 13;
            int minute = 22;
            int second = 0;

            Solar solar = new Solar(year, month, day, hour, minute, second);
            Lunar lunar = solar.getLunar();

            Assert.AreEqual("己亥", lunar.getYearInGanZhi(), "getYearInGanZhi 未返回所需的值。");
            Assert.AreEqual("己亥", lunar.getYearInGanZhiByLiChun(), "getYearInGanZhiByLiChun 未返回所需的值。");
            Assert.AreEqual("己亥", lunar.getYearInGanZhiExact(), "getYearInGanZhiExact 未返回所需的值。");

            Assert.AreEqual("丙子", lunar.getMonthInGanZhi(), "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("丙子", lunar.getMonthInGanZhiExact(), "getMonthInGanZhiExact 未返回所需的值。");
        }

        [TestMethod()]
        public void test2()
        {
            int year = 2020;
            int month = 1;
            int day = 6;
            int hour = 13;
            int minute = 22;
            int second = 0;

            Solar solar = new Solar(year, month, day, hour, minute, second);
            Lunar lunar = solar.getLunar();

            Assert.AreEqual("己亥", lunar.getYearInGanZhi(), "getYearInGanZhi 未返回所需的值。");
            Assert.AreEqual("己亥", lunar.getYearInGanZhiByLiChun(), "getYearInGanZhiByLiChun 未返回所需的值。");
            Assert.AreEqual("己亥", lunar.getYearInGanZhiExact(), "getYearInGanZhiExact 未返回所需的值。");

            Assert.AreEqual("丁丑", lunar.getMonthInGanZhi(), "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("丁丑", lunar.getMonthInGanZhiExact(), "getMonthInGanZhiExact 未返回所需的值。");
        }

        [TestMethod()]
        public void test3()
        {
            int year = 2020;
            int month = 1;
            int day = 20;
            int hour = 13;
            int minute = 22;
            int second = 0;

            Solar solar = new Solar(year, month, day, hour, minute, second);
            Lunar lunar = solar.getLunar();

            Assert.AreEqual("己亥", lunar.getYearInGanZhi(), "getYearInGanZhi 未返回所需的值。");
            Assert.AreEqual("己亥", lunar.getYearInGanZhiByLiChun(), "getYearInGanZhiByLiChun 未返回所需的值。");
            Assert.AreEqual("己亥", lunar.getYearInGanZhiExact(), "getYearInGanZhiExact 未返回所需的值。");

            Assert.AreEqual("丁丑", lunar.getMonthInGanZhi(), "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("丁丑", lunar.getMonthInGanZhiExact(), "getMonthInGanZhiExact 未返回所需的值。");
        }

        [TestMethod()]
        public void test4()
        {
            int year = 2020;
            int month = 1;
            int day = 25;
            int hour = 13;
            int minute = 22;
            int second = 0;

            Solar solar = new Solar(year, month, day, hour, minute, second);
            Lunar lunar = solar.getLunar();

            Assert.AreEqual("庚子", lunar.getYearInGanZhi(), "getYearInGanZhi 未返回所需的值。");
            Assert.AreEqual("己亥", lunar.getYearInGanZhiByLiChun(), "getYearInGanZhiByLiChun 未返回所需的值。");
            Assert.AreEqual("己亥", lunar.getYearInGanZhiExact(), "getYearInGanZhiExact 未返回所需的值。");

            Assert.AreEqual("丁丑", lunar.getMonthInGanZhi(), "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("丁丑", lunar.getMonthInGanZhiExact(), "getMonthInGanZhiExact 未返回所需的值。");
        }

        [TestMethod()]
        public void test5()
        {
            int year = 2020;
            int month = 1;
            int day = 30;
            int hour = 13;
            int minute = 22;
            int second = 0;

            Solar solar = new Solar(year, month, day, hour, minute, second);
            Lunar lunar = solar.getLunar();

            Assert.AreEqual("庚子", lunar.getYearInGanZhi(), "getYearInGanZhi 未返回所需的值。");
            Assert.AreEqual("己亥", lunar.getYearInGanZhiByLiChun(), "getYearInGanZhiByLiChun 未返回所需的值。");
            Assert.AreEqual("己亥", lunar.getYearInGanZhiExact(), "getYearInGanZhiExact 未返回所需的值。");

            Assert.AreEqual("丁丑", lunar.getMonthInGanZhi(), "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("丁丑", lunar.getMonthInGanZhiExact(), "getMonthInGanZhiExact 未返回所需的值。");
        }

        [TestMethod()]
        public void test6()
        {
            int year = 2020;
            int month = 2;
            int day = 1;
            int hour = 13;
            int minute = 22;
            int second = 0;

            Solar solar = new Solar(year, month, day, hour, minute, second);
            Lunar lunar = solar.getLunar();

            Assert.AreEqual("庚子", lunar.getYearInGanZhi(), "getYearInGanZhi 未返回所需的值。");
            Assert.AreEqual("己亥", lunar.getYearInGanZhiByLiChun(), "getYearInGanZhiByLiChun 未返回所需的值。");
            Assert.AreEqual("己亥", lunar.getYearInGanZhiExact(), "getYearInGanZhiExact 未返回所需的值。");

            Assert.AreEqual("丁丑", lunar.getMonthInGanZhi(), "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("丁丑", lunar.getMonthInGanZhiExact(), "getMonthInGanZhiExact 未返回所需的值。");
        }

        [TestMethod()]
        public void test7()
        {
            int year = 2020;
            int month = 2;
            int day = 4;
            int hour = 13;
            int minute = 22;
            int second = 0;

            Solar solar = new Solar(year, month, day, hour, minute, second);
            Lunar lunar = solar.getLunar();

            Assert.AreEqual("庚子", lunar.getYearInGanZhi(), "getYearInGanZhi 未返回所需的值。");
            Assert.AreEqual("庚子", lunar.getYearInGanZhiByLiChun(), "getYearInGanZhiByLiChun 未返回所需的值。");
            Assert.AreEqual("己亥", lunar.getYearInGanZhiExact(), "getYearInGanZhiExact 未返回所需的值。");

            Assert.AreEqual("戊寅", lunar.getMonthInGanZhi(), "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("丁丑", lunar.getMonthInGanZhiExact(), "getMonthInGanZhiExact 未返回所需的值。");
        }

        [TestMethod()]
        public void test8()
        {
            int year = 2020;
            int month = 2;
            int day = 4;
            int hour = 18;
            int minute = 22;
            int second = 0;

            Solar solar = new Solar(year, month, day, hour, minute, second);
            Lunar lunar = solar.getLunar();

            Assert.AreEqual("庚子", lunar.getYearInGanZhi(), "getYearInGanZhi 未返回所需的值。");
            Assert.AreEqual("庚子", lunar.getYearInGanZhiByLiChun(), "getYearInGanZhiByLiChun 未返回所需的值。");
            Assert.AreEqual("庚子", lunar.getYearInGanZhiExact(), "getYearInGanZhiExact 未返回所需的值。");

            Assert.AreEqual("戊寅", lunar.getMonthInGanZhi(), "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("戊寅", lunar.getMonthInGanZhiExact(), "getMonthInGanZhiExact 未返回所需的值。");
        }


        [TestMethod()]
        public void test9()
        {
            int year = 2020;
            int month = 2;
            int day = 5;
            int hour = 13;
            int minute = 22;
            int second = 0;

            Solar solar = new Solar(year, month, day, hour, minute, second);
            Lunar lunar = solar.getLunar();

            Assert.AreEqual("庚子", lunar.getYearInGanZhi(), "getYearInGanZhi 未返回所需的值。");
            Assert.AreEqual("庚子", lunar.getYearInGanZhiByLiChun(), "getYearInGanZhiByLiChun 未返回所需的值。");
            Assert.AreEqual("庚子", lunar.getYearInGanZhiExact(), "getYearInGanZhiExact 未返回所需的值。");

            Assert.AreEqual("戊寅", lunar.getMonthInGanZhi(), "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("戊寅", lunar.getMonthInGanZhiExact(), "getMonthInGanZhiExact 未返回所需的值。");
        }

        [TestMethod()]
        public void test10()
        {
            int year = 2020;
            int month = 5;
            int day = 22;
            int hour = 13;
            int minute = 22;
            int second = 0;

            Solar solar = new Solar(year, month, day, hour, minute, second);
            Lunar lunar = solar.getLunar();

            Assert.AreEqual("庚子", lunar.getYearInGanZhi(), "getYearInGanZhi 未返回所需的值。");
            Assert.AreEqual("庚子", lunar.getYearInGanZhiByLiChun(), "getYearInGanZhiByLiChun 未返回所需的值。");
            Assert.AreEqual("庚子", lunar.getYearInGanZhiExact(), "getYearInGanZhiExact 未返回所需的值。");

            Assert.AreEqual("辛巳", lunar.getMonthInGanZhi(), "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("辛巳", lunar.getMonthInGanZhiExact(), "getMonthInGanZhiExact 未返回所需的值。");
        }

        [TestMethod()]
        public void test11()
        {
            int year = 2020;
            int month = 5;
            int day = 23;
            int hour = 13;
            int minute = 22;
            int second = 0;

            Solar solar = new Solar(year, month, day, hour, minute, second);
            Lunar lunar = solar.getLunar();

            Assert.AreEqual("庚子", lunar.getYearInGanZhi(), "getYearInGanZhi 未返回所需的值。");
            Assert.AreEqual("庚子", lunar.getYearInGanZhiByLiChun(), "getYearInGanZhiByLiChun 未返回所需的值。");
            Assert.AreEqual("庚子", lunar.getYearInGanZhiExact(), "getYearInGanZhiExact 未返回所需的值。");

            Assert.AreEqual("辛巳", lunar.getMonthInGanZhi(), "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("辛巳", lunar.getMonthInGanZhiExact(), "getMonthInGanZhiExact 未返回所需的值。");
        }

        [TestMethod()]
        public void test12()
        {
            int year = 2020;
            int month = 5;
            int day = 29;
            int hour = 13;
            int minute = 22;
            int second = 0;

            Solar solar = new Solar(year, month, day, hour, minute, second);
            Lunar lunar = solar.getLunar();

            Assert.AreEqual("庚子", lunar.getYearInGanZhi(), "getYearInGanZhi 未返回所需的值。");
            Assert.AreEqual("庚子", lunar.getYearInGanZhiByLiChun(), "getYearInGanZhiByLiChun 未返回所需的值。");
            Assert.AreEqual("庚子", lunar.getYearInGanZhiExact(), "getYearInGanZhiExact 未返回所需的值。");

            Assert.AreEqual("辛巳", lunar.getMonthInGanZhi(), "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("辛巳", lunar.getMonthInGanZhiExact(), "getMonthInGanZhiExact 未返回所需的值。");
        }

        [TestMethod()]
        public void test13()
        {
            int year = 2020;
            int month = 6;
            int day = 1;
            int hour = 13;
            int minute = 22;
            int second = 0;

            Solar solar = new Solar(year, month, day, hour, minute, second);
            Lunar lunar = solar.getLunar();

            Assert.AreEqual("庚子", lunar.getYearInGanZhi(), "getYearInGanZhi 未返回所需的值。");
            Assert.AreEqual("庚子", lunar.getYearInGanZhiByLiChun(), "getYearInGanZhiByLiChun 未返回所需的值。");
            Assert.AreEqual("庚子", lunar.getYearInGanZhiExact(), "getYearInGanZhiExact 未返回所需的值。");

            Assert.AreEqual("辛巳", lunar.getMonthInGanZhi(), "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("辛巳", lunar.getMonthInGanZhiExact(), "getMonthInGanZhiExact 未返回所需的值。");
        }

        [TestMethod()]
        public void test14()
        {
            int year = 2020;
            int month = 6;
            int day = 29;
            int hour = 13;
            int minute = 22;
            int second = 0;

            Solar solar = new Solar(year, month, day, hour, minute, second);
            Lunar lunar = solar.getLunar();

            Assert.AreEqual("庚子", lunar.getYearInGanZhi(), "getYearInGanZhi 未返回所需的值。");
            Assert.AreEqual("庚子", lunar.getYearInGanZhiByLiChun(), "getYearInGanZhiByLiChun 未返回所需的值。");
            Assert.AreEqual("庚子", lunar.getYearInGanZhiExact(), "getYearInGanZhiExact 未返回所需的值。");

            Assert.AreEqual("壬午", lunar.getMonthInGanZhi(), "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("壬午", lunar.getMonthInGanZhiExact(), "getMonthInGanZhiExact 未返回所需的值。");
        }

        [TestMethod()]
        public void test15()
        {
            int year = 2019;
            int month = 5;
            int day = 1;
            int hour = 13;
            int minute = 22;
            int second = 0;

            Solar solar = new Solar(year, month, day, hour, minute, second);
            Lunar lunar = solar.getLunar();

            Assert.AreEqual("己亥", lunar.getYearInGanZhi(), "getYearInGanZhi 未返回所需的值。");
            Assert.AreEqual("己亥", lunar.getYearInGanZhiByLiChun(), "getYearInGanZhiByLiChun 未返回所需的值。");
            Assert.AreEqual("己亥", lunar.getYearInGanZhiExact(), "getYearInGanZhiExact 未返回所需的值。");

            Assert.AreEqual("戊辰", lunar.getMonthInGanZhi(), "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("戊辰", lunar.getMonthInGanZhiExact(), "getMonthInGanZhiExact 未返回所需的值。");
        }

        [TestMethod()]
        public void test16()
        {
            int year = 1986;
            int month = 5;
            int day = 29;
            int hour = 13;
            int minute = 22;
            int second = 0;

            Solar solar = new Solar(year, month, day, hour, minute, second);
            Lunar lunar = solar.getLunar();

            Assert.AreEqual("丙寅", lunar.getYearInGanZhi(), "getYearInGanZhi 未返回所需的值。");
            Assert.AreEqual("丙寅", lunar.getYearInGanZhiByLiChun(), "getYearInGanZhiByLiChun 未返回所需的值。");
            Assert.AreEqual("丙寅", lunar.getYearInGanZhiExact(), "getYearInGanZhiExact 未返回所需的值。");

            Assert.AreEqual("癸巳", lunar.getMonthInGanZhi(), "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("癸巳", lunar.getMonthInGanZhiExact(), "getMonthInGanZhiExact 未返回所需的值。");
        }

        [TestMethod()]
        public void test17()
        {
            int year = 1986;
            int month = 5;
            int day = 1;
            int hour = 1;
            int minute = 22;
            int second = 0;

            Solar solar = new Solar(year, month, day, hour, minute, second);
            Lunar lunar = solar.getLunar();

            Assert.AreEqual("丙寅", lunar.getYearInGanZhi(), "getYearInGanZhi 未返回所需的值。");
            Assert.AreEqual("丙寅", lunar.getYearInGanZhiByLiChun(), "getYearInGanZhiByLiChun 未返回所需的值。");
            Assert.AreEqual("丙寅", lunar.getYearInGanZhiExact(), "getYearInGanZhiExact 未返回所需的值。");

            Assert.AreEqual("壬辰", lunar.getMonthInGanZhi(), "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("壬辰", lunar.getMonthInGanZhiExact(), "getMonthInGanZhiExact 未返回所需的值。");
        }

        [TestMethod()]
        public void test18()
        {
            int year = 1986;
            int month = 5;
            int day = 6;
            int hour = 1;
            int minute = 22;
            int second = 0;

            Solar solar = new Solar(year, month, day, hour, minute, second);
            Lunar lunar = solar.getLunar();

            Assert.AreEqual("丙寅", lunar.getYearInGanZhi(), "getYearInGanZhi 未返回所需的值。");
            Assert.AreEqual("丙寅", lunar.getYearInGanZhiByLiChun(), "getYearInGanZhiByLiChun 未返回所需的值。");
            Assert.AreEqual("丙寅", lunar.getYearInGanZhiExact(), "getYearInGanZhiExact 未返回所需的值。");

            Assert.AreEqual("癸巳", lunar.getMonthInGanZhi(), "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("壬辰", lunar.getMonthInGanZhiExact(), "getMonthInGanZhiExact 未返回所需的值。");
        }

        [TestMethod()]
        public void test19()
        {
            int year = 1986;
            int month = 5;
            int day = 6;
            int hour = 23;
            int minute = 22;
            int second = 0;

            Solar solar = new Solar(year, month, day, hour, minute, second);
            Lunar lunar = solar.getLunar();

            Assert.AreEqual("丙寅", lunar.getYearInGanZhi(), "getYearInGanZhi 未返回所需的值。");
            Assert.AreEqual("丙寅", lunar.getYearInGanZhiByLiChun(), "getYearInGanZhiByLiChun 未返回所需的值。");
            Assert.AreEqual("丙寅", lunar.getYearInGanZhiExact(), "getYearInGanZhiExact 未返回所需的值。");

            Assert.AreEqual("癸巳", lunar.getMonthInGanZhi(), "getMonthInGanZhi 未返回所需的值。");
            Assert.AreEqual("癸巳", lunar.getMonthInGanZhiExact(), "getMonthInGanZhiExact 未返回所需的值。");
        }
    }
}
