using Lunar;
using Xunit;

namespace test
{
    /// <summary>
    /// 九星
    /// </summary>
    public class NineStarTest
    {
        [Fact]
        public void Test1()
        {
            var lunar = Solar.FromYmdHms(1985, 2, 19).Lunar;
            Assert.Equal("六", lunar.YearNineStar.Number);
        }
        
        [Fact]
        public void Test23()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2022, 1, 1);
            Assert.Equal("六白金开阳", lunar.YearNineStar.ToString());
        }

        [Fact]
        public void Test24()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2033, 1, 1);
            Assert.Equal("四绿木天权", lunar.YearNineStar.ToString());
        }
    }
}