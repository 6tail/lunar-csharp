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
    /// 星座测试
    ///</summary>
    [TestClass()]
    public class XingZuoTest
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
            Solar solar = new Solar(2020, 3, 21);
            Assert.AreEqual("白羊", solar.getXingZuo(), solar.toYmd());
            solar = new Solar(2020, 4, 19);
            Assert.AreEqual("白羊", solar.getXingZuo(), solar.toYmd());
        }

        [TestMethod()]
        public void test2()
        {
            Solar solar = new Solar(2020, 4, 20);
            Assert.AreEqual("金牛", solar.getXingZuo(), solar.toYmd());
            solar = new Solar(2020, 5, 20);
            Assert.AreEqual("金牛", solar.getXingZuo(), solar.toYmd());
        }

        [TestMethod()]
        public void test3()
        {
            Solar solar = new Solar(2020, 5, 21);
            Assert.AreEqual("双子", solar.getXingZuo(), solar.toYmd());
            solar = new Solar(2020, 6, 21);
            Assert.AreEqual("双子", solar.getXingZuo(), solar.toYmd());
        }

        [TestMethod()]
        public void test4()
        {
            Solar solar = new Solar(2020, 6, 22);
            Assert.AreEqual("巨蟹", solar.getXingZuo(), solar.toYmd());
            solar = new Solar(2020, 7, 22);
            Assert.AreEqual("巨蟹", solar.getXingZuo(), solar.toYmd());
        }

        [TestMethod()]
        public void test5()
        {
            Solar solar = new Solar(2020, 7, 23);
            Assert.AreEqual("狮子", solar.getXingZuo(), solar.toYmd());
            solar = new Solar(2020, 8, 22);
            Assert.AreEqual("狮子", solar.getXingZuo(), solar.toYmd());
        }

        [TestMethod()]
        public void test6()
        {
            Solar solar = new Solar(2020, 8, 23);
            Assert.AreEqual("处女", solar.getXingZuo(), solar.toYmd());
            solar = new Solar(2020, 9, 22);
            Assert.AreEqual("处女", solar.getXingZuo(), solar.toYmd());
        }

        [TestMethod()]
        public void test7()
        {
            Solar solar = new Solar(2020, 9, 23);
            Assert.AreEqual("天秤", solar.getXingZuo(), solar.toYmd());
            solar = new Solar(2020, 10, 23);
            Assert.AreEqual("天秤", solar.getXingZuo(), solar.toYmd());
        }

        [TestMethod()]
        public void test8()
        {
            Solar solar = new Solar(2020, 10, 24);
            Assert.AreEqual("天蝎", solar.getXingZuo(), solar.toYmd());
            solar = new Solar(2020, 11, 22);
            Assert.AreEqual("天蝎", solar.getXingZuo(), solar.toYmd());
        }

        [TestMethod()]
        public void test9()
        {
            Solar solar = new Solar(2020, 11, 23);
            Assert.AreEqual("射手", solar.getXingZuo(), solar.toYmd());
            solar = new Solar(2020, 12, 21);
            Assert.AreEqual("射手", solar.getXingZuo(), solar.toYmd());
        }

        [TestMethod()]
        public void test10()
        {
            Solar solar = new Solar(2020, 12, 22);
            Assert.AreEqual("摩羯", solar.getXingZuo(), solar.toYmd());
            solar = new Solar(2021, 1, 19);
            Assert.AreEqual("摩羯", solar.getXingZuo(), solar.toYmd());
        }

        [TestMethod()]
        public void test11()
        {
            Solar solar = new Solar(2021, 1, 20);
            Assert.AreEqual("水瓶", solar.getXingZuo(), solar.toYmd());
            solar = new Solar(2021, 2, 18);
            Assert.AreEqual("水瓶", solar.getXingZuo(), solar.toYmd());
        }

        [TestMethod()]
        public void test12()
        {
            Solar solar = new Solar(2021, 2, 19);
            Assert.AreEqual("双鱼", solar.getXingZuo(), solar.toYmd());
            solar = new Solar(2021, 3, 20);
            Assert.AreEqual("双鱼", solar.getXingZuo(), solar.toYmd());
        }

    }


}
