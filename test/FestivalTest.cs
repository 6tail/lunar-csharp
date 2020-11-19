using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Collections.Generic;
using com.nlf.calendar;
using com.nlf.calendar.util;
namespace test
{

    [TestClass()]
    public class FestivalTest
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
        public void testNext()
        {
            Solar solar = Solar.fromYmd(2020, 11, 26);
            Assert.AreEqual("感恩节", solar.getFestivals()[0]);

            solar = Solar.fromYmd(2020, 6, 21);
            Assert.AreEqual("父亲节", solar.getFestivals()[0]);

            solar = Solar.fromYmd(2021, 5, 9);
            Assert.AreEqual("母亲节", solar.getFestivals()[0]);

            solar = Solar.fromYmd(1986, 11, 27);
            Assert.AreEqual("感恩节", solar.getFestivals()[0]);

            solar = Solar.fromYmd(1985, 6, 16);
            Assert.AreEqual("父亲节", solar.getFestivals()[0]);

            solar = Solar.fromYmd(1984, 5, 13);
            Assert.AreEqual("母亲节", solar.getFestivals()[0]);
        }

    }


}
