using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Collections.Generic;
using com.nlf.calendar;
using com.nlf.calendar.util;
namespace test
{

    [TestClass()]
    public class TaoTest
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
        public void test()
        {
            Tao tao = Tao.fromLunar(Lunar.fromYmdHms(2021, 10, 17, 18, 0, 0));
            Assert.AreEqual("四七一八年十月十七", tao.toString());
            Assert.AreEqual("道歷四七一八年，天運辛丑年，己亥月，癸酉日。十月十七日，酉時。", tao.toFullString());
        }

        [TestMethod()]
        public void test1()
        {
            Tao tao = Tao.fromYmd(4718, 10, 18);
            Assert.AreEqual(2, tao.getFestivals().Count);

            tao = Lunar.fromYmd(2021, 10, 18).getTao();
            Assert.AreEqual(2, tao.getFestivals().Count);
        }

    }


}
