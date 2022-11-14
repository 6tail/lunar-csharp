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
    }
}