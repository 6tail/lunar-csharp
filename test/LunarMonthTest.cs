using Lunar;
using Xunit;
// ReSharper disable IdentifierTypo

namespace test
{
    /// <summary>
    /// 佛历
    /// </summary>
    public class LunarMonthTest
    {
        
        [Fact]
        public void Test1()
        {
            var month = LunarMonth.FromYm(2023, 1);
            Assert.Equal(1, month.Index);
            Assert.Equal("甲寅", month.GanZhi);
        }

        [Fact]
        public void Test2()
        {
            var month = LunarMonth.FromYm(2023, -2);
            Assert.Equal(3, month.Index);
            Assert.Equal("乙卯", month.GanZhi);
        }
        
        [Fact]
        public void Test3()
        {
            var month = LunarMonth.FromYm(2023, 3);
            Assert.Equal(4, month.Index);
            Assert.Equal("丙辰", month.GanZhi);
        }
        
        [Fact]
        public void Test4()
        {
            var month = LunarMonth.FromYm(2024, 1);
            Assert.Equal(1, month.Index);
            Assert.Equal("丙寅", month.GanZhi);
        }
        
        [Fact]
        public void Test5()
        {
            var month = LunarMonth.FromYm(2023, 12);
            Assert.Equal(13, month.Index);
            Assert.Equal("乙丑", month.GanZhi);
        }
        
        [Fact]
        public void Test6()
        {
            var month = LunarMonth.FromYm(2022, 1);
            Assert.Equal(1, month.Index);
            Assert.Equal("壬寅", month.GanZhi);
        }
    }
}