using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using com.nlf.calendar.util;
using com.nlf.calendar;
using com.nlf.calendar.eightchar;

namespace test
{
    /// <summary>
    /// 八字测试
    /// </summary>
    [TestClass]
    public class BaZiTest
    {
        public BaZiTest()
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
        ///起运
        ///</summary>
        [TestMethod()]
        public void testQiYun()
        {
            Solar solar = new Solar(1983, 2, 15, 20, 0, 0);
            Lunar lunar = solar.getLunar();
            EightChar bazi = lunar.getEightChar();
            Yun yun = bazi.getYun(0);
            Assert.AreEqual(6, yun.getStartYear());
            Assert.AreEqual(2, yun.getStartMonth());
            Assert.AreEqual(20, yun.getStartDay());
            Assert.AreEqual("1989-05-05", yun.getStartSolar().toYmd());

            solar = new Solar(2013, 7, 13, 16, 17, 0);
            lunar = solar.getLunar();
            bazi = lunar.getEightChar();
            yun = bazi.getYun(0);
            Assert.AreEqual(8, yun.getStartYear());
            Assert.AreEqual(4, yun.getStartMonth());
            Assert.AreEqual(0, yun.getStartDay());
            Assert.AreEqual("2021-11-13", yun.getStartSolar().toYmd());

            solar = new Solar(2020, 8, 18, 10, 0, 0);
            lunar = solar.getLunar();
            bazi = lunar.getEightChar();
            yun = bazi.getYun(0);
            Assert.AreEqual(3, yun.getStartYear());
            Assert.AreEqual(8, yun.getStartMonth());
            Assert.AreEqual(0, yun.getStartDay());
            Assert.AreEqual("2024-04-18", yun.getStartSolar().toYmd());

            solar = new Solar(1972, 6, 15, 0, 0, 0);
            lunar = solar.getLunar();
            bazi = lunar.getEightChar();
            yun = bazi.getYun(1);
            Assert.AreEqual(7, yun.getStartYear());
            Assert.AreEqual(5, yun.getStartMonth());
            Assert.AreEqual(10, yun.getStartDay());
            Assert.AreEqual("1979-11-25", yun.getStartSolar().toYmd());

            solar = new Solar(1968, 11, 22, 0, 0, 0);
            lunar = solar.getLunar();
            bazi = lunar.getEightChar();
            yun = bazi.getYun(1);
            Assert.AreEqual(5, yun.getStartYear());
            Assert.AreEqual(1, yun.getStartMonth());
            Assert.AreEqual(20, yun.getStartDay());
            Assert.AreEqual("1974-01-11", yun.getStartSolar().toYmd());

            solar = new Solar(1968, 11, 23, 0, 0, 0);
            lunar = solar.getLunar();
            bazi = lunar.getEightChar();
            yun = bazi.getYun(1);
            Assert.AreEqual(4, yun.getStartYear());
            Assert.AreEqual(9, yun.getStartMonth());
            Assert.AreEqual(20, yun.getStartDay());
            Assert.AreEqual("1973-09-12", yun.getStartSolar().toYmd());
        }

        /// <summary>
        ///大运
        ///</summary>
        [TestMethod()]
        public void testDaYun()
        {
            int[] startYears = { 1983, 1989, 1999, 2009, 2019, 2029, 2039, 2049, 2059, 2069 };
            int[] endYears = { 1988, 1998, 2008, 2018, 2028, 2038, 2048, 2058, 2068, 2078 };
            int[] startAges = { 1, 7, 17, 27, 37, 47, 57, 67, 77, 87 };
            int[] endAges = { 6, 16, 26, 36, 46, 56, 66, 76, 86, 96 };
            String[] yearGanZhi = { "", "乙卯", "丙辰", "丁巳", "戊午", "己未", "庚申", "辛酉", "壬戌", "癸亥" };
            Solar solar = new Solar(1983, 2, 15, 20, 0, 0);
            Lunar lunar = solar.getLunar();
            EightChar bazi = lunar.getEightChar();
            Yun yun = bazi.getYun(0);
            DaYun[] l = yun.getDaYun();
            for (int i = 0, j = l.Length; i < j; i++)
            {
                DaYun daYun = l[i];
                Assert.AreEqual(startYears[i], daYun.getStartYear());
                Assert.AreEqual(endYears[i], daYun.getEndYear());
                Assert.AreEqual(startAges[i], daYun.getStartAge());
                Assert.AreEqual(endAges[i], daYun.getEndAge());
                Assert.AreEqual(yearGanZhi[i], daYun.getGanZhi());
            }
        }

        /// <summary>
        ///流年
        ///</summary>
        [TestMethod()]
        public void testLiuNian()
        {
            Solar solar = new Solar(1983, 2, 15, 20, 0, 0);
            Lunar lunar = solar.getLunar();
            EightChar bazi = lunar.getEightChar();
            Yun yun = bazi.getYun(0);
            DaYun[] daYun = yun.getDaYun();

            int[] years = { 1983, 1984, 1985, 1986, 1987, 1988 };
            int[] ages = { 1, 2, 3, 4, 5, 6 };
            String[] ganZhi = { "癸亥", "甲子", "乙丑", "丙寅", "丁卯", "戊辰" };
            LiuNian[] l = daYun[0].getLiuNian();
            for (int i = 0, j = l.Length; i < j; i++)
            {
                LiuNian liuNian = l[i];
                Assert.AreEqual(years[i], liuNian.getYear());
                Assert.AreEqual(ages[i], liuNian.getAge());
                Assert.AreEqual(ganZhi[i], liuNian.getGanZhi());
            }

            years = new int[] { 2029, 2030, 2031, 2032, 2033, 2034, 2035, 2036, 2037, 2038 };
            ages = new int[] { 47, 48, 49, 50, 51, 52, 53, 54, 55, 56 };
            ganZhi = new String[] { "己酉", "庚戌", "辛亥", "壬子", "癸丑", "甲寅", "乙卯", "丙辰", "丁巳", "戊午" };
            l = daYun[5].getLiuNian();
            for (int i = 0, j = l.Length; i < j; i++)
            {
                LiuNian liuNian = l[i];
                Assert.AreEqual(years[i], liuNian.getYear());
                Assert.AreEqual(ages[i], liuNian.getAge());
                Assert.AreEqual(ganZhi[i], liuNian.getGanZhi(),years[i] + "年");
            }
        }

        /// <summary>
        ///小运
        ///</summary>
        [TestMethod()]
        public void testXiaoYun()
        {
            Solar solar = new Solar(1983, 2, 15, 20, 0, 0);
            Lunar lunar = solar.getLunar();
            EightChar bazi = lunar.getEightChar();
            Yun yun = bazi.getYun(0);
            DaYun[] daYun = yun.getDaYun();

            int[] years = { 1983, 1984, 1985, 1986, 1987, 1988 };
            int[] ages = { 1, 2, 3, 4, 5, 6 };
            String[] ganZhi = { "乙亥", "丙子", "丁丑", "戊寅", "己卯", "庚辰" };
            XiaoYun[] l = daYun[0].getXiaoYun();
            for (int i = 0, j = l.Length; i < j; i++)
            {
                XiaoYun xiaoYun = l[i];
                Assert.AreEqual(years[i], xiaoYun.getYear());
                Assert.AreEqual(ages[i], xiaoYun.getAge());
                Assert.AreEqual(ganZhi[i], xiaoYun.getGanZhi());
            }

            years = new int[] { 2029, 2030, 2031, 2032, 2033, 2034, 2035, 2036, 2037, 2038 };
            ages = new int[] { 47, 48, 49, 50, 51, 52, 53, 54, 55, 56 };
            ganZhi = new String[] { "辛酉", "壬戌", "癸亥", "甲子", "乙丑", "丙寅", "丁卯", "戊辰", "己巳", "庚午" };
            l = daYun[5].getXiaoYun();
            for (int i = 0, j = l.Length; i < j; i++)
            {
                XiaoYun xiaoYun = l[i];
                Assert.AreEqual(years[i], xiaoYun.getYear());
                Assert.AreEqual(ages[i], xiaoYun.getAge());
                Assert.AreEqual(ganZhi[i], xiaoYun.getGanZhi(),years[i] + "年");
            }
        }

        /// <summary>
        ///流月
        ///</summary>
        [TestMethod()]
        public void testLiuYue()
        {
            Solar solar = new Solar(1983, 2, 15, 20, 0, 0);
            Lunar lunar = solar.getLunar();
            EightChar bazi = lunar.getEightChar();
            Yun yun = bazi.getYun(0);
            DaYun[] daYun = yun.getDaYun();

            String[] ganZhi = { "甲寅", "乙卯", "丙辰", "丁巳", "戊午", "己未", "庚申", "辛酉", "壬戌", "癸亥", "甲子", "乙丑" };
            LiuNian[] liuNian = daYun[0].getLiuNian();
            LiuYue[] l = liuNian[0].getLiuYue();
            for (int i = 0, j = l.Length; i < j; i++)
            {
                LiuYue liuYue = l[i];
                Assert.AreEqual(ganZhi[i], liuYue.getGanZhi());
            }

            ganZhi = new String[] { "庚寅", "辛卯", "壬辰", "癸巳", "甲午", "乙未", "丙申", "丁酉", "戊戌", "己亥", "庚子", "辛丑" };
            liuNian = daYun[4].getLiuNian();
            l = liuNian[2].getLiuYue();
            for (int i = 0, j = l.Length; i < j; i++)
            {
                LiuYue liuYue = l[i];
                Assert.AreEqual(ganZhi[i], liuYue.getGanZhi());
            }
        }

        [TestMethod()]
        public void testGanZhi()
        {
            Solar solar = new Solar(1988, 2, 15, 23, 30, 0);
            Lunar lunar = solar.getLunar();
            EightChar eightChar = lunar.getEightChar();

            Assert.AreEqual("戊辰", eightChar.getYear(),"年柱");
            Assert.AreEqual("甲寅", eightChar.getMonth(), "月柱");
            Assert.AreEqual("庚子", eightChar.getDay(), "日柱");
            Assert.AreEqual("戊子", eightChar.getTime(), "时柱");

            eightChar.setSect(1);
            Assert.AreEqual("戊辰", eightChar.getYear(), "年柱");
            Assert.AreEqual("甲寅", eightChar.getMonth(), "月柱");
            Assert.AreEqual("辛丑", eightChar.getDay(), "日柱");
            Assert.AreEqual("戊子", eightChar.getTime(), "时柱");

            solar = new Solar(1988, 2, 15, 22, 30, 0);
            lunar = solar.getLunar();
            eightChar = lunar.getEightChar();
            Assert.AreEqual("戊辰", eightChar.getYear(), "年柱");
            Assert.AreEqual("甲寅", eightChar.getMonth(), "月柱");
            Assert.AreEqual("庚子", eightChar.getDay(), "日柱");
            Assert.AreEqual("丁亥", eightChar.getTime(), "时柱");

            solar = new Solar(1988, 2, 2, 22, 30, 0);
            lunar = solar.getLunar();
            eightChar = lunar.getEightChar();
            Assert.AreEqual("丁卯", eightChar.getYear(), "年柱");
            Assert.AreEqual("癸丑", eightChar.getMonth(), "月柱");
            Assert.AreEqual("丁亥", eightChar.getDay(), "日柱");
            Assert.AreEqual("辛亥", eightChar.getTime(), "时柱");
        }
    }
}
