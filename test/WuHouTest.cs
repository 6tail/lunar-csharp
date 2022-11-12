using Lunar;
using NUnit.Framework;

namespace test
{
    /// <summary>
    /// 物候
    /// </summary>
    public class WuHouTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var solar = new Solar(2020, 4, 23);
            var lunar = solar.Lunar;
            Assert.AreEqual("萍始生", lunar.WuHou, solar.ToString());
        }

        [Test]
        public void Test2()
        {
            var solar = new Solar(2021, 1, 15);
            var lunar = solar.Lunar;
            Assert.AreEqual("雉始雊", lunar.WuHou, solar.ToString());
        }

        [Test]
        public void Test3()
        {
            var solar = new Solar(2017, 1, 5);
            var lunar = solar.Lunar;
            Assert.AreEqual("雁北乡", lunar.WuHou, solar.ToString());
        }

        [Test]
        public void Test4()
        {
            var solar = new Solar(2020, 4, 10);
            var lunar = solar.Lunar;
            Assert.AreEqual("田鼠化为鴽", lunar.WuHou, solar.ToString());
        }

        [Test]
        public void Test5()
        {
            var solar = new Solar(2020, 6, 11);
            var lunar = solar.Lunar;
            Assert.AreEqual("鵙始鸣", lunar.WuHou, solar.ToString());
        }

        [Test]
        public void Test6()
        {
            var solar = new Solar(2020, 6, 1);
            var lunar = solar.Lunar;
            Assert.AreEqual("麦秋至", lunar.WuHou, solar.ToString());
        }

        [Test]
        public void Test7()
        {
            var solar = new Solar(2020, 12, 8);
            var lunar = solar.Lunar;
            Assert.AreEqual("鹖鴠不鸣", lunar.WuHou, solar.ToString());
        }

        [Test]
        public void Test8()
        {
            var solar = new Solar(2020, 12, 11);
            var lunar = solar.Lunar;
            Assert.AreEqual("鹖鴠不鸣", lunar.WuHou, solar.ToString());
        }

        [Test]
        public void Test10()
        {
            var solar = new Solar(1982, 12, 22);
            var lunar = solar.Lunar;
            Assert.AreEqual("蚯蚓结", lunar.WuHou, solar.ToString());
        }

        [Test]
        public void Test11()
        {
            var solar = new Solar(2021, 12, 21);
            var lunar = solar.Lunar;
            Assert.AreEqual("冬至 初候", lunar.Hou, solar.ToString());
        }

        [Test]
        public void Test12()
        {
            var solar = new Solar(2021, 12, 26);
            var lunar = solar.Lunar;
            Assert.AreEqual("冬至 二候", lunar.Hou, solar.ToString());
        }

        [Test]
        public void Test13()
        {
            var solar = new Solar(2021, 12, 31);
            var lunar = solar.Lunar;
            Assert.AreEqual("冬至 三候", lunar.Hou, solar.ToString());
        }

        [Test]
        public void Test14()
        {
            var solar = new Solar(2022, 1, 5);
            var lunar = solar.Lunar;
            Assert.AreEqual("小寒 初候", lunar.Hou, solar.ToString());
        }
        
        [Test]
        public void Test15()
        {
            var solar = new Solar(2022, 8, 22);
            var lunar = solar.Lunar;
            Assert.AreEqual("寒蝉鸣", lunar.WuHou, solar.ToString());
        }
        
        [Test]
        public void Test16()
        {
            var solar = new Solar(2022, 8, 23);
            var lunar = solar.Lunar;
            Assert.AreEqual("鹰乃祭鸟", lunar.WuHou, solar.ToString());
        }
    }
}