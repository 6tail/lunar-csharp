using Lunar;
using Xunit;

namespace test
{
    /// <summary>
    /// 节气
    /// </summary>
    public class JieQiTest
    {
        
        [Fact]
        public void Test1()
        {
            var solar = Solar.FromYmdHms(2021, 12, 21);
            var lunar = solar.Lunar;
            Assert.Equal("冬至", lunar.JieQi);
            Assert.Equal("", lunar.Jie);
            Assert.Equal("冬至", lunar.Qi);
        }
        
        [Fact]
        public void Test2()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2012, 9, 1);
            Assert.Equal("2012-09-07 13:29:01", lunar.JieQiTable["白露"].YmdHms);
        }
        
        [Fact]
        public void Test3()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2050, 12, 1);
            Assert.Equal("2050-12-07 06:41:13", lunar.JieQiTable["DA_XUE"].YmdHms);
        }
        
        [Fact]
        public void Test4()
        {
            var lunar = Solar.FromYmdHms(2023, 6, 1).Lunar;
            Assert.Equal("2022-12-22 05:48:11", lunar.JieQiTable["冬至"].YmdHms);
        }
    }
}