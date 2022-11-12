using Lunar;
using NUnit.Framework;

namespace test
{
    /// <summary>
    /// 节气
    /// </summary>
    public class JieQiTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var solar = Solar.FromYmdHms(2021, 12, 21);
            var lunar = solar.Lunar;
            Assert.AreEqual("冬至", lunar.JieQi);
            Assert.AreEqual("", lunar.Jie);
            Assert.AreEqual("冬至", lunar.Qi);
        }
    }
}