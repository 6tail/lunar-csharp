using Lunar;
using Xunit;

namespace test
{
    /// <summary>
    /// 运
    /// </summary>
    public class YunTest
    {
        
        [Fact]
        public void Test1()
        {
            var solar = Solar.FromYmdHms(1981, 1, 29, 23, 37);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;
            var yun = eightChar.GetYun(0);
            Assert.Equal(8, yun.StartYear);
            Assert.Equal(0, yun.StartMonth);
            Assert.Equal(20, yun.StartDay);
            Assert.Equal("1989-02-18", yun.StartSolar.Ymd);
        }
        
        [Fact]
        public void Test2()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2019, 12, 12, 11, 22);
            var eightChar = lunar.EightChar;
            var yun = eightChar.GetYun(1);
            Assert.Equal(0, yun.StartYear);
            Assert.Equal(1, yun.StartMonth);
            Assert.Equal(0, yun.StartDay);
            Assert.Equal("2020-02-06", yun.StartSolar.Ymd);
        }
        
        [Fact]
        public void Test3()
        {
            var solar = Solar.FromYmdHms(2020, 1, 6, 11, 22);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;
            var yun = eightChar.GetYun(1);
            Assert.Equal(0, yun.StartYear);
            Assert.Equal(1, yun.StartMonth);
            Assert.Equal(0, yun.StartDay);
            Assert.Equal("2020-02-06", yun.StartSolar.Ymd);
        }
        
        [Fact]
        public void Test4()
        {
            var solar = Solar.FromYmdHms(2022, 3, 9, 20, 51);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;
            var yun = eightChar.GetYun(1);
            Assert.Equal("2030-12-19", yun.StartSolar.Ymd);
        }
        
        [Fact]
        public void Test5()
        {
            var solar = Solar.FromYmdHms(2022, 3, 9, 20, 51);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;
            var yun = eightChar.GetYun(1, 2);
            Assert.Equal(8, yun.StartYear);
            Assert.Equal(9, yun.StartMonth);
            Assert.Equal(2, yun.StartDay);
            Assert.Equal("2030-12-12", yun.StartSolar.Ymd);
        }
        
        [Fact]
        public void Test6()
        {
            var solar = Solar.FromYmdHms(2018, 6, 11, 9, 30);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;
            var yun = eightChar.GetYun(0, 2);
            Assert.Equal("2020-03-21", yun.StartSolar.Ymd);
        }
    }
}