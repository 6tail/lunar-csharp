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
    /// 六曜测试
    ///</summary>
    [TestClass()]
    public class LiuYaoTest
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
            Solar solar = new Solar(2020, 4, 23);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("佛灭", lunar.getLiuYao(),lunar.toString());
        }

        [TestMethod()]
        public void test2()
        {
            Solar solar = new Solar(2021, 1, 15);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("友引", lunar.getLiuYao(), lunar.toString());
        }

        [TestMethod()]
        public void test3()
        {
            Solar solar = new Solar(2017, 1, 5);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("先胜", lunar.getLiuYao(), lunar.toString());
        }

        [TestMethod()]
        public void test4()
        {
            Solar solar = new Solar(2020, 4, 10);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("友引", lunar.getLiuYao(), lunar.toString());
        }

        [TestMethod()]
        public void test5()
        {
            Solar solar = new Solar(2020, 6, 11);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("大安", lunar.getLiuYao(), lunar.toString());
        }

        [TestMethod()]
        public void test6()
        {
            Solar solar = new Solar(2020, 6, 1);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("先胜", lunar.getLiuYao(), lunar.toString());
        }

        [TestMethod()]
        public void test7()
        {
            Solar solar = new Solar(2020, 12, 8);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("先负", lunar.getLiuYao(), lunar.toString());
        }

        [TestMethod()]
        public void test8()
        {
            Solar solar = new Solar(2020, 12, 11);
            Lunar lunar = solar.getLunar();
            Assert.AreEqual("赤口", lunar.getLiuYao(), lunar.toString());
        }

    }

}
