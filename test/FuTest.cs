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
    /// 三伏测试
    ///</summary>
    [TestClass()]
    public class FuTest
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
            Solar solar = new Solar(2011, 7, 14);
            Lunar lunar = solar.getLunar();
            Fu fu = lunar.getFu();
            Assert.AreEqual("初伏", fu.toString(), solar.toYmd());
            Assert.AreEqual("初伏第1天", fu.toFullString(), solar.toYmd());
        }

        [TestMethod()]
        public void test2()
        {
            Solar solar = new Solar(2011, 7, 23);
            Lunar lunar = solar.getLunar();
            Fu fu = lunar.getFu();
            Assert.AreEqual("初伏", fu.toString(), solar.toYmd());
            Assert.AreEqual("初伏第10天", fu.toFullString(), solar.toYmd());
        }

        [TestMethod()]
        public void test3()
        {
            Solar solar = new Solar(2011, 7, 24);
            Lunar lunar = solar.getLunar();
            Fu fu = lunar.getFu();
            Assert.AreEqual("中伏", fu.toString(), solar.toYmd());
            Assert.AreEqual("中伏第1天", fu.toFullString(), solar.toYmd());
        }

        [TestMethod()]
        public void test4()
        {
            Solar solar = new Solar(2011, 8, 12);
            Lunar lunar = solar.getLunar();
            Fu fu = lunar.getFu();
            Assert.AreEqual("中伏", fu.toString(), solar.toYmd());
            Assert.AreEqual("中伏第20天", fu.toFullString(), solar.toYmd());
        }

        [TestMethod()]
        public void test5()
        {
            Solar solar = new Solar(2011, 8, 13);
            Lunar lunar = solar.getLunar();
            Fu fu = lunar.getFu();
            Assert.AreEqual("末伏", fu.toString(), solar.toYmd());
            Assert.AreEqual("末伏第1天", fu.toFullString(), solar.toYmd());
        }

        [TestMethod()]
        public void test6()
        {
            Solar solar = new Solar(2011, 8, 22);
            Lunar lunar = solar.getLunar();
            Fu fu = lunar.getFu();
            Assert.AreEqual("末伏", fu.toString(), solar.toYmd());
            Assert.AreEqual("末伏第10天", fu.toFullString(), solar.toYmd());
        }
        [TestMethod()]
        public void test7()
        {
            Solar solar = new Solar(2011, 7, 13);
            Lunar lunar = solar.getLunar();
            Fu fu = lunar.getFu();
            Assert.IsNull(fu);
        }

        [TestMethod()]
        public void test8()
        {
            Solar solar = new Solar(2011, 8, 23);
            Lunar lunar = solar.getLunar();
            Fu fu = lunar.getFu();
            Assert.IsNull(fu);
        }

        [TestMethod()]
        public void test9()
        {
            Solar solar = new Solar(2012, 7, 18);
            Lunar lunar = solar.getLunar();
            Fu fu = lunar.getFu();
            Assert.AreEqual("初伏", fu.toString(), solar.toYmd());
            Assert.AreEqual("初伏第1天", fu.toFullString(), solar.toYmd());
        }

        [TestMethod()]
        public void test10()
        {
            Solar solar = new Solar(2012, 8, 5);
            Lunar lunar = solar.getLunar();
            Fu fu = lunar.getFu();
            Assert.AreEqual("中伏", fu.toString(), solar.toYmd());
            Assert.AreEqual("中伏第9天", fu.toFullString(), solar.toYmd());
        }

        [TestMethod()]
        public void test11()
        {
            Solar solar = new Solar(2012, 8, 8);
            Lunar lunar = solar.getLunar();
            Fu fu = lunar.getFu();
            Assert.AreEqual("末伏", fu.toString(), solar.toYmd());
            Assert.AreEqual("末伏第2天", fu.toFullString(), solar.toYmd());
        }

        [TestMethod()]
        public void test12()
        {
            Solar solar = new Solar(2020, 7, 17);
            Lunar lunar = solar.getLunar();
            Fu fu = lunar.getFu();
            Assert.AreEqual("初伏", fu.toString(), solar.toYmd());
            Assert.AreEqual("初伏第2天", fu.toFullString(), solar.toYmd());
        }

        [TestMethod()]
        public void test13()
        {
            Solar solar = new Solar(2020, 7, 26);
            Lunar lunar = solar.getLunar();
            Fu fu = lunar.getFu();
            Assert.AreEqual("中伏", fu.toString(), solar.toYmd());
            Assert.AreEqual("中伏第1天", fu.toFullString(), solar.toYmd());
        }

        [TestMethod()]
        public void test14()
        {
            Solar solar = new Solar(2020, 8, 24);
            Lunar lunar = solar.getLunar();
            Fu fu = lunar.getFu();
            Assert.AreEqual("末伏", fu.toString(), solar.toYmd());
            Assert.AreEqual("末伏第10天", fu.toFullString(), solar.toYmd());
        }

    }

}
