// 以下代码由 Microsoft Visual Studio 2005 生成。
// 测试所有者应该检查每个测试的有效性。
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Collections.Generic;
using com.nlf.calendar;
namespace test
{
    /// <summary>
    /// 数九测试
    ///</summary>
    [TestClass()]
    public class ShuJiuTest
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
            Solar solar = new Solar(2020, 12, 21);
            Lunar lunar = solar.getLunar();
            ShuJiu shuJiu = lunar.getShuJiu();
            Assert.AreEqual("一九", shuJiu.toString(), solar.toYmd());
            Assert.AreEqual("一九第1天", shuJiu.toFullString(), solar.toYmd());
        }

        [TestMethod()]
        public void test2()
        {
            Solar solar = new Solar(2020, 12, 22);
            Lunar lunar = solar.getLunar();
            ShuJiu shuJiu = lunar.getShuJiu();
            Assert.AreEqual("一九", shuJiu.toString(), solar.toYmd());
            Assert.AreEqual("一九第2天", shuJiu.toFullString(), solar.toYmd());
        }

        [TestMethod()]
        public void test3()
        {
            Solar solar = new Solar(2020, 1, 7);
            Lunar lunar = solar.getLunar();
            ShuJiu shuJiu = lunar.getShuJiu();
            Assert.AreEqual("二九", shuJiu.toString(), solar.toYmd());
            Assert.AreEqual("二九第8天", shuJiu.toFullString(), solar.toYmd());
        }

        [TestMethod()]
        public void test4()
        {
            Solar solar = new Solar(2021, 1, 6);
            Lunar lunar = solar.getLunar();
            ShuJiu shuJiu = lunar.getShuJiu();
            Assert.AreEqual("二九", shuJiu.toString(), solar.toYmd());
            Assert.AreEqual("二九第8天", shuJiu.toFullString(), solar.toYmd());
        }

        [TestMethod()]
        public void test5()
        {
            Solar solar = new Solar(2021, 1, 8);
            Lunar lunar = solar.getLunar();
            ShuJiu shuJiu = lunar.getShuJiu();
            Assert.AreEqual("三九", shuJiu.toString(), solar.toYmd());
            Assert.AreEqual("三九第1天", shuJiu.toFullString(), solar.toYmd());
        }

        [TestMethod()]
        public void test6()
        {
            Solar solar = new Solar(2021, 3, 5);
            Lunar lunar = solar.getLunar();
            ShuJiu shuJiu = lunar.getShuJiu();
            Assert.AreEqual("九九", shuJiu.toString(), solar.toYmd());
            Assert.AreEqual("九九第3天", shuJiu.toFullString(), solar.toYmd());
        }

        [TestMethod()]
        public void test7()
        {
            Solar solar = new Solar(2021, 7, 5);
            Lunar lunar = solar.getLunar();
            ShuJiu shuJiu = lunar.getShuJiu();
            Assert.IsNull(shuJiu);
        }

    }

}
