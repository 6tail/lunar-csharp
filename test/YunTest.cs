// 以下代码由 Microsoft Visual Studio 2005 生成。
// 测试所有者应该检查每个测试的有效性。
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Collections.Generic;
using com.nlf.calendar;
using com.nlf.calendar.eightchar;
namespace test
{
    /// <summary>
    /// 运测试
    ///</summary>
    [TestClass()]
    public class YunTest
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
            Solar solar = Solar.fromYmdHms(1981, 1, 29, 23, 37, 0);
            Lunar lunar = solar.getLunar();
            EightChar eightChar = lunar.getEightChar();
            Yun yun = eightChar.getYun(0);
            Assert.AreEqual(8, yun.getStartYear(), "起运年数");
            Assert.AreEqual(0, yun.getStartMonth(), "起运月数");
            Assert.AreEqual(20, yun.getStartDay(), "起运天数");
            Assert.AreEqual("1989-02-18", yun.getStartSolar().toYmd(), "起运阳历");
        }

        [TestMethod()]
        public void test2()
        {
            Lunar lunar = Lunar.fromYmdHms(2019, 12, 12, 11, 22, 0);
            EightChar eightChar = lunar.getEightChar();
            Yun yun = eightChar.getYun(1);
            Assert.AreEqual(0, yun.getStartYear(), "起运年数");
            Assert.AreEqual(1, yun.getStartMonth(), "起运月数");
            Assert.AreEqual(0, yun.getStartDay(), "起运天数");
            Assert.AreEqual("2020-02-06", yun.getStartSolar().toYmd(), "起运阳历");
        }

        [TestMethod()]
        public void test3()
        {
            Solar solar = Solar.fromYmdHms(2020, 1, 6, 11, 22, 0);
            Lunar lunar = solar.getLunar();
            EightChar eightChar = lunar.getEightChar();
            Yun yun = eightChar.getYun(1);
            Assert.AreEqual(0, yun.getStartYear(), "起运年数");
            Assert.AreEqual(1, yun.getStartMonth(), "起运月数");
            Assert.AreEqual(0, yun.getStartDay(), "起运天数");
            Assert.AreEqual("2020-02-06", yun.getStartSolar().toYmd(), "起运阳历");
        }

    }

}
