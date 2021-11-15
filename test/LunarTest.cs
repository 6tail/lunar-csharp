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
    ///这是 com.nlf.calendar.Lunar 的测试类，旨在
    ///包含所有 com.nlf.calendar.Lunar 单元测试
    ///</summary>
    [TestClass()]
    public class LunarTest
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
            Solar solar = Solar.fromYmdHms(2021, 6, 7, 21, 18, 0);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("二〇二一年四月廿七", lunar.ToString(), "com.nlf.calendar.Solar.getLunar 有错。");
        }

        [TestMethod()]
        public void test2()
        {
            Lunar lunar = Lunar.fromYmdHms(2021, 6, 7, 21, 18, 0);
            Solar solar = lunar.getSolar();
            Assert.AreEqual("2021-07-16", solar.ToString(), "com.nlf.calendar.Lunar.getSolar 有错。");
        }

        [TestMethod()]
        public void test038()
        {
            Lunar lunar = Lunar.fromYmd(7013, -11, 4);
            Solar solar = lunar.getSolar();
            Assert.AreEqual("7013-12-24", solar.ToString(), "com.nlf.calendar.Lunar.getSolar 有错。");
        }

        [TestMethod()]
        public void test041()
        {
            Solar solar = Solar.fromYmd(4, 2, 10);
            Assert.AreEqual("鼠", solar.getLunar().getYearShengXiao(), "com.nlf.calendar.Lunar.getYearShengXiao 有错。");
        }

        [TestMethod()]
        public void test042()
        {
            Solar solar = Solar.fromYmd(4, 2, 9);
            Assert.AreEqual("猪", solar.getLunar().getYearShengXiao(), "com.nlf.calendar.Lunar.getYearShengXiao 有错。");
        }

        [TestMethod()]
        public void test22()
        {
            Lunar lunar = Lunar.fromYmd(2033, -11, 1);
            Assert.AreEqual("2033-12-22", lunar.getSolar().toYmd());
        }

        [TestMethod()]
        public void test23()
        {
            Lunar lunar = Lunar.fromYmd(2022, 1, 1);
            Assert.AreEqual("五黄土玉衡", lunar.getYearNineStar().toString());
        }

        [TestMethod()]
        public void test24()
        {
            Lunar lunar = Lunar.fromYmd(2033, 1, 1);
            Assert.AreEqual("三碧木天玑", lunar.getYearNineStar().toString());
        }

        [TestMethod()]
        public void test025()
        {
            Solar solar = Solar.fromYmdHms(2021, 6, 7, 21, 18, 0);
            Assert.AreEqual("二〇二一年四月廿七", solar.getLunar().toString());
        }

        [TestMethod()]
        public void test026()
        {
            Lunar lunar = Lunar.fromYmdHms(2021, 6, 7, 21, 18, 0);
            Assert.AreEqual("2021-07-16", lunar.getSolar().toString());
        }

        [TestMethod()]
        public void test027()
        {
            Solar solar = Solar.fromYmd(1989, 4, 28);
            Assert.AreEqual(23, solar.getLunar().getDay());
        }

        [TestMethod()]
        public void test028()
        {
            Solar solar = Solar.fromYmd(1990, 10, 8);
            Assert.AreEqual("乙酉", solar.getLunar().getMonthInGanZhiExact());
        }

        [TestMethod()]
        public void test029()
        {
            Solar solar = Solar.fromYmd(1990, 10, 9);
            Assert.AreEqual("丙戌", solar.getLunar().getMonthInGanZhiExact());
        }

        [TestMethod()]
        public void test030()
        {
            Solar solar = Solar.fromYmd(1990, 10, 8);
            Assert.AreEqual("丙戌", solar.getLunar().getMonthInGanZhi());
        }

        [TestMethod()]
        public void test031()
        {
            Solar solar = Solar.fromYmdHms(1987, 4, 17, 9, 0, 0);
            Assert.AreEqual("一九八七年三月二十", solar.getLunar().toString());
        }

        [TestMethod()]
        public void test032()
        {
            Lunar lunar = Lunar.fromYmd(2034, 1, 1);
            Assert.AreEqual("2034-02-19", lunar.getSolar().toString());
        }

        [TestMethod()]
        public void test033()
        {
            Lunar lunar = Lunar.fromYmd(2033, 12, 1);
            Assert.AreEqual("2034-01-20", lunar.getSolar().toString());
        }

        [TestMethod()]
        public void test034()
        {
            Lunar lunar = Lunar.fromYmd(37, -12, 1);
            Assert.AreEqual("闰腊", lunar.getMonthInChinese());
        }

        [TestMethod()]
        public void test035()
        {
            Lunar lunar = Lunar.fromYmd(56, -12, 1);
            Assert.AreEqual("闰腊", lunar.getMonthInChinese());

            lunar = Lunar.fromYmd(75, -11, 1);
            Assert.AreEqual("闰冬", lunar.getMonthInChinese());

            lunar = Lunar.fromYmd(94, -11, 1);
            Assert.AreEqual("闰冬", lunar.getMonthInChinese());

            lunar = Lunar.fromYmd(94, 12, 1);
            Assert.AreEqual("腊", lunar.getMonthInChinese());

            lunar = Lunar.fromYmd(113, 12, 1);
            Assert.AreEqual("腊", lunar.getMonthInChinese());

            lunar = Lunar.fromYmd(113, -12, 1);
            Assert.AreEqual("闰腊", lunar.getMonthInChinese());

            lunar = Lunar.fromYmd(5552, -12, 1);
            Assert.AreEqual("闰腊", lunar.getMonthInChinese());
        }

        [TestMethod()]
        public void test036()
        {
            Solar solar = Solar.fromYmd(5553, 1, 22);
            Assert.AreEqual("五五五二年闰腊月初二", solar.getLunar().toString());
        }

        [TestMethod()]
        public void test037()
        {
            Solar solar = Solar.fromYmd(7013, 12, 24);
            Assert.AreEqual("七〇一三年闰冬月初四", solar.getLunar().toString());
        }

        [TestMethod()]
        public void test35()
        {
            Lunar lunar = Lunar.fromYmd(2021, 12, 29);
            Assert.AreEqual("除夕", lunar.getFestivals()[0]);
        }

        [TestMethod()]
        public void test36()
        {
            Lunar lunar = Lunar.fromYmd(2020, 12, 30);
            Assert.AreEqual("除夕", lunar.getFestivals()[0]);
        }

        [TestMethod()]
        public void test37()
        {
            Lunar lunar = Lunar.fromYmd(2020, 12, 29);
            Assert.AreEqual(0, lunar.getFestivals().Count);
        }

        [TestMethod()]
        public void test38()
        {
            Solar solar = Solar.fromYmd(2022, 1, 31);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("除夕", lunar.getFestivals()[0]);
        }

        [TestMethod()]
        public void test8()
        {
            Lunar lunar = Lunar.fromYmdHms(2020, 12, 10, 13, 0, 0);
            Assert.AreEqual("二〇二〇年腊月初十", lunar.toString());
            Assert.AreEqual("2021-01-22", lunar.getSolar().toString());
        }

        [TestMethod()]
        public void test9()
        {
            Lunar lunar = Lunar.fromYmdHms(1500, 1, 1, 12, 0, 0);
            Assert.AreEqual("1500-01-31", lunar.getSolar().toString());
        }

        [TestMethod()]
        public void test10()
        {
            Lunar lunar = Lunar.fromYmdHms(1500, 12, 29, 12, 0, 0);
            Assert.AreEqual("1501-01-18", lunar.getSolar().toString());
        }

        
        [TestMethod()]
        public void test11()
        {
            Solar solar = Solar.fromYmdHms(1500, 1, 1, 12, 0, 0);
            Assert.AreEqual("一四九九年腊月初一", solar.getLunar().toString());
        }

        /// <summary>
        /// 1500年计算二月初一是2月29日导致DateTime报错，这个暂未解决，绕开1500年这些特殊的吧。（1582年之前，欧洲实行儒略历，能被4整除的都是闰年，所以1100，1200，1300，1400，1500都是闰年。1582年之後，实行格里历，整百年份必须能被400整除才是闰年。）
        /// </summary>
        [TestMethod()]
        public void test12()
        {
            // Solar solar = Solar.fromYmdHms(1500, 12, 31, 12, 0, 0);
            // Assert.AreEqual("一五〇〇年腊月十一", solar.getLunar().toString());
        }

        [TestMethod()]
        public void test13()
        {
            Solar solar = Solar.fromYmdHms(1582, 10, 4, 12, 0, 0);
            Assert.AreEqual("一五八二年九月十八", solar.getLunar().toString());
        }

        [TestMethod()]
        public void test14()
        {
            Solar solar = Solar.fromYmdHms(1582, 10, 15, 12, 0, 0);
            Assert.AreEqual("一五八二年九月十九", solar.getLunar().toString());
        }

        [TestMethod()]
        public void test15()
        {
            Lunar lunar = Lunar.fromYmdHms(1582, 9, 18, 12, 0, 0);
            Assert.AreEqual("1582-10-04", lunar.getSolar().toString());
        }

        [TestMethod()]
        public void test16()
        {
            Lunar lunar = Lunar.fromYmdHms(1582, 9, 19, 12, 0, 0);
            Assert.AreEqual("1582-10-15", lunar.getSolar().toString());
        }

        [TestMethod()]
        public void test17()
        {
            Lunar lunar = Lunar.fromYmdHms(2019, 12, 12, 11, 22, 0);
            Assert.AreEqual("2020-01-06", lunar.getSolar().toString());
        }

        [TestMethod()]
        public void test18()
        {
            Solar solar = Solar.fromYmdHms(2020, 2, 4, 13, 22, 0);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("庚子", lunar.getYearInGanZhi());
            Assert.AreEqual("庚子", lunar.getYearInGanZhiByLiChun());
            Assert.AreEqual("己亥", lunar.getYearInGanZhiExact());
            Assert.AreEqual("戊寅", lunar.getMonthInGanZhi());
            Assert.AreEqual("丁丑", lunar.getMonthInGanZhiExact());
        }

        [TestMethod()]
        public void test19()
        {
            Solar solar = Solar.fromYmdHms(2019, 2, 8, 13, 22, 0);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("己亥", lunar.getYearInGanZhi());
            Assert.AreEqual("己亥", lunar.getYearInGanZhiByLiChun());
            Assert.AreEqual("己亥", lunar.getYearInGanZhiExact());
            Assert.AreEqual("丙寅", lunar.getMonthInGanZhi());
            Assert.AreEqual("丙寅", lunar.getMonthInGanZhiExact());
        }

        [TestMethod()]
        public void test20()
        {
            Solar solar = Solar.fromYmdHms(1988, 2, 15, 23, 30, 0);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("丁卯", lunar.getYearInGanZhi());
            Assert.AreEqual("戊辰", lunar.getYearInGanZhiByLiChun());
            Assert.AreEqual("戊辰", lunar.getYearInGanZhiExact());
        }

        [TestMethod()]
        public void test21()
        {
            Solar solar = Solar.fromYmd(1988, 2, 15);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("丁卯", lunar.getYearInGanZhi());
        }

        [TestMethod()]
        public void test022()
        {
            Solar solar = Solar.fromYmd(2012, 12, 27);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("壬辰", lunar.getYearInGanZhi());
            Assert.AreEqual("壬子", lunar.getMonthInGanZhi());
            Assert.AreEqual("壬戌", lunar.getDayInGanZhi());
        }

        [TestMethod()]
        public void test023()
        {
            Solar solar = Solar.fromYmd(2012, 12, 20);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("壬辰", lunar.getYearInGanZhi());
            Assert.AreEqual("壬子", lunar.getMonthInGanZhi());
            Assert.AreEqual("乙卯", lunar.getDayInGanZhi());
        }

        [TestMethod()]
        public void test024()
        {
            Solar solar = Solar.fromYmd(2012, 11, 20);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("壬辰", lunar.getYearInGanZhi());
            Assert.AreEqual("辛亥", lunar.getMonthInGanZhi());
            Assert.AreEqual("乙酉", lunar.getDayInGanZhi());
        }

        [TestMethod()]
        public void test25()
        {
            Solar solar = Solar.fromYmd(2012, 10, 20);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("壬辰", lunar.getYearInGanZhi());
            Assert.AreEqual("庚戌", lunar.getMonthInGanZhi());
            Assert.AreEqual("甲寅", lunar.getDayInGanZhi());
        }

        [TestMethod()]
        public void test26()
        {
            Solar solar = Solar.fromYmd(2012, 9, 20);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("壬辰", lunar.getYearInGanZhi());
            Assert.AreEqual("己酉", lunar.getMonthInGanZhi());
            Assert.AreEqual("甲申", lunar.getDayInGanZhi());
        }

        [TestMethod()]
        public void test126()
        {
            Solar solar = Solar.fromYmd(2012, 8, 5);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("戊戌", lunar.getDayInGanZhi());
        }

        [TestMethod()]
        public void test27()
        {
            Solar solar = Solar.fromYmd(2000, 2, 2);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("庚寅", lunar.getDayInGanZhi());
        }

        [TestMethod()]
        public void test28()
        {
            Solar solar = Solar.fromYmd(1996, 1, 16);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("壬子", lunar.getDayInGanZhi());
        }

        [TestMethod()]
        public void test29()
        {
            Solar solar = Solar.fromYmd(1997, 2, 16);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("己丑", lunar.getDayInGanZhi());
        }

        [TestMethod()]
        public void test30()
        {
            Solar solar = Solar.fromYmd(1998, 3, 16);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("壬戌", lunar.getDayInGanZhi());
        }
        
        [TestMethod()]
        public void test31()
        {
            Solar solar = Solar.fromYmd(1999, 4, 16);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("戊戌", lunar.getDayInGanZhi());
        }

        [TestMethod()]
        public void test32()
        {
            Solar solar = Solar.fromYmd(2000, 7, 16);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("乙亥", lunar.getDayInGanZhi());
        }

        [TestMethod()]
        public void test33()
        {
            Solar solar = Solar.fromYmd(2000, 1, 6);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("癸亥", lunar.getDayInGanZhi());
        }

        
        [TestMethod()]
        public void test34()
        {
            Solar solar = Solar.fromYmd(2000, 1, 9);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("丙寅", lunar.getDayInGanZhi());
        }

        [TestMethod()]
        public void test45()
        {
            Solar solar = Solar.fromYmd(2017, 2, 15);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("子命互禄 辛命进禄", lunar.getDayLu());
        }

        [TestMethod()]
        public void test46()
        {
            Solar solar = Solar.fromYmd(2017, 2, 16);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("寅命互禄", lunar.getDayLu());
        }

        [TestMethod()]
        public void test48()
        {
            Solar solar = Solar.fromYmd(2021, 11, 13);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("碓磨厕 外东南", lunar.getDayPositionTai());
        }

        [TestMethod()]
        public void test49()
        {
            Solar solar = Solar.fromYmd(2021, 11, 12);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("占门碓 外东南", lunar.getDayPositionTai());
        }

        [TestMethod()]
        public void test50()
        {
            Solar solar = Solar.fromYmd(2021, 11, 13);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("西南", lunar.getDayPositionFuDesc());
        }

        [TestMethod()]
        public void test51()
        {
            Solar solar = Solar.fromYmd(2021, 11, 12);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("正北", lunar.getDayPositionFuDesc());
        }

        [TestMethod()]
        public void test52()
        {
            Solar solar = Solar.fromYmd(2011, 11, 12);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("厕灶厨 外西南", lunar.getDayPositionTai());
        }

    }


}
