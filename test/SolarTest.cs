using Lunar;
using Xunit;

namespace test
{
    /// <summary>
    /// 阳历
    /// </summary>
    public class SolarTest
    {
        
        /// <summary>
        /// next 的测试
        ///</summary>
        [Fact]
        public void TestNext()
        {
            var date = new Solar(2020, 1, 23);
            Assert.Equal("2020-01-24", date.Next(1).ToString());
            // 仅工作日，跨越春节假期
            Assert.Equal("2020-02-03", date.Next(1, true).ToString());

            date = new Solar(2020, 2, 3);
            Assert.Equal("2020-01-31", date.Next(-3).ToString());
            // 仅工作日，跨越春节假期
            Assert.Equal("2020-01-21", date.Next(-3, true).ToString());

            date = new Solar(2020, 2, 9);
            Assert.Equal("2020-02-15", date.Next(6).ToString());
            // 仅工作日，跨越周末
            Assert.Equal("2020-02-17", date.Next(6, true).ToString());

            date = new Solar(2020, 1, 17);
            Assert.Equal("2020-01-18", date.Next(1).ToString());
            // 仅工作日，周日调休按上班算
            Assert.Equal("2020-01-19", date.Next(1, true).ToString());

        }

        /// <summary>
        /// 
        ///</summary>
        [Fact]
        public void TestConvert()
        {
            var solar = new Solar(2020, 1, 23);
            var lunar = solar.Lunar;
            Assert.Equal("二〇一九年腊月廿九", lunar.ToString());
            Assert.Equal("2020-01-23", lunar.Solar.ToString());
        }

        /// <summary>
        /// 
        ///</summary>
        [Fact]
        public void TestConvert1()
        {
            var lunar = new Lunar.Lunar(2019, 12, 29);
            Assert.Equal("二〇一九年腊月廿九", lunar.ToString());
            Assert.Equal("2020-01-23", lunar.Solar.ToString());
        }

        [Fact]
        public void Test1()
        {
            var solar = Solar.FromYmdHms(2020, 5, 24, 13);
            Assert.Equal("二〇二〇年闰四月初二", solar.Lunar.ToString());
        }

        [Fact]
        public void Test6()
        {
            var solar = Solar.FromYmdHms(11, 1, 1);
            Assert.Equal("一〇年腊月初八", solar.Lunar.ToString());
        }

        [Fact]
        public void Test7()
        {
            var solar = Solar.FromYmdHms(11, 3, 1);
            Assert.Equal("一一年二月初八", solar.Lunar.ToString());
        }

        [Fact]
        public void Test9()
        {
            var solar = Solar.FromYmdHms(26, 4, 13);
            Assert.Equal("二六年三月初八", solar.Lunar.ToString());
        }

        [Fact]
        public void Test10()
        {
            var solar = Solar.FromYmdHms(2022, 3, 28);
            Assert.Equal("全国中小学生安全教育日", solar.Festivals[0]);
        }
    }
}