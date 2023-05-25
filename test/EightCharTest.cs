using System.Collections.Generic;
using System.Linq;
using Lunar;
using Lunar.EightChar;
using Xunit;
// ReSharper disable IdentifierTypo

namespace test
{
    /// <summary>
    /// 八字
    /// </summary>
    public class EightCharTest
    {
        
        [Fact]
        public void TestQiYun()
        {
            var solar = new Solar(1983, 2, 15, 20);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;
            var yun = eightChar.GetYun(0);
            Assert.Equal(6, yun.StartYear);
            Assert.Equal(2, yun.StartMonth);
            Assert.Equal(20, yun.StartDay);
            Assert.Equal("1989-05-05", yun.StartSolar.Ymd);

            solar = new Solar(2013, 7, 13, 16, 17);
            lunar = solar.Lunar;
            eightChar = lunar.EightChar;
            yun = eightChar.GetYun(0);
            Assert.Equal(8, yun.StartYear);
            Assert.Equal(4, yun.StartMonth);
            Assert.Equal(0, yun.StartDay);
            Assert.Equal("2021-11-13", yun.StartSolar.Ymd);

            solar = new Solar(2020, 8, 18, 10);
            lunar = solar.Lunar;
            eightChar = lunar.EightChar;
            yun = eightChar.GetYun(0);
            Assert.Equal(3, yun.StartYear);
            Assert.Equal(8, yun.StartMonth);
            Assert.Equal(0, yun.StartDay);
            Assert.Equal("2024-04-18", yun.StartSolar.Ymd);

            solar = new Solar(1972, 6, 15);
            lunar = solar.Lunar;
            eightChar = lunar.EightChar;
            yun = eightChar.GetYun(1);
            Assert.Equal(7, yun.StartYear);
            Assert.Equal(5, yun.StartMonth);
            Assert.Equal(10, yun.StartDay);
            Assert.Equal("1979-11-25", yun.StartSolar.Ymd);

            solar = new Solar(1968, 11, 22);
            lunar = solar.Lunar;
            eightChar = lunar.EightChar;
            yun = eightChar.GetYun(1);
            Assert.Equal(5, yun.StartYear);
            Assert.Equal(1, yun.StartMonth);
            Assert.Equal(20, yun.StartDay);
            Assert.Equal("1974-01-11", yun.StartSolar.Ymd);

            solar = new Solar(1968, 11, 23);
            lunar = solar.Lunar;
            eightChar = lunar.EightChar;
            yun = eightChar.GetYun(1);
            Assert.Equal(4, yun.StartYear);
            Assert.Equal(9, yun.StartMonth);
            Assert.Equal(20, yun.StartDay);
            Assert.Equal("1973-09-12", yun.StartSolar.Ymd);
        }

        /// <summary>
        ///大运
        ///</summary>
        [Fact]
        public void TestDaYun()
        {
            int[] startYears = { 1983, 1989, 1999, 2009, 2019, 2029, 2039, 2049, 2059, 2069 };
            int[] endYears = { 1988, 1998, 2008, 2018, 2028, 2038, 2048, 2058, 2068, 2078 };
            int[] startAges = { 1, 7, 17, 27, 37, 47, 57, 67, 77, 87 };
            int[] endAges = { 6, 16, 26, 36, 46, 56, 66, 76, 86, 96 };
            string[] yearGanZhi = { "", "乙卯", "丙辰", "丁巳", "戊午", "己未", "庚申", "辛酉", "壬戌", "癸亥" };
            var solar = new Solar(1983, 2, 15, 20);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;
            var yun = eightChar.GetYun(0);
            DaYun[] l = yun.GetDaYun().ToArray();
            for (int i = 0, j = l.Length; i < j; i++)
            {
                DaYun daYun = l[i];
                Assert.Equal(startYears[i], daYun.StartYear);
                Assert.Equal(endYears[i], daYun.EndYear);
                Assert.Equal(startAges[i], daYun.StartAge);
                Assert.Equal(endAges[i], daYun.EndAge);
                Assert.Equal(yearGanZhi[i], daYun.GanZhi);
            }
        }

        /// <summary>
        ///流年
        ///</summary>
        [Fact]
        public void TestLiuNian()
        {
            var solar = new Solar(1983, 2, 15, 20);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;
            var yun = eightChar.GetYun(0);
            DaYun[] daYun = yun.GetDaYun().ToArray();

            int[] years = { 1983, 1984, 1985, 1986, 1987, 1988 };
            int[] ages = { 1, 2, 3, 4, 5, 6 };
            string[] ganZhi = { "癸亥", "甲子", "乙丑", "丙寅", "丁卯", "戊辰" };
            LiuNian[] l = daYun[0].GetLiuNian().ToArray();
            for (int i = 0, j = l.Length; i < j; i++)
            {
                LiuNian liuNian = l[i];
                Assert.Equal(years[i], liuNian.Year);
                Assert.Equal(ages[i], liuNian.Age);
                Assert.Equal(ganZhi[i], liuNian.GanZhi);
            }

            years = new[] { 2029, 2030, 2031, 2032, 2033, 2034, 2035, 2036, 2037, 2038 };
            ages = new[] { 47, 48, 49, 50, 51, 52, 53, 54, 55, 56 };
            ganZhi = new[] { "己酉", "庚戌", "辛亥", "壬子", "癸丑", "甲寅", "乙卯", "丙辰", "丁巳", "戊午" };
            l = daYun[5].GetLiuNian().ToArray();
            for (int i = 0, j = l.Length; i < j; i++)
            {
                var liuNian = l[i];
                Assert.Equal(years[i], liuNian.Year);
                Assert.Equal(ages[i], liuNian.Age);
                Assert.Equal(ganZhi[i], liuNian.GanZhi);
            }
        }

        /// <summary>
        ///小运
        ///</summary>
        [Fact]
        public void TestXiaoYun()
        {
            var solar = new Solar(1983, 2, 15, 20);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;
            var yun = eightChar.GetYun(0);
            DaYun[] daYun = yun.GetDaYun().ToArray();

            int[] years = { 1983, 1984, 1985, 1986, 1987, 1988 };
            int[] ages = { 1, 2, 3, 4, 5, 6 };
            string[] ganZhi = { "乙亥", "丙子", "丁丑", "戊寅", "己卯", "庚辰" };
            XiaoYun[] l = daYun[0].GetXiaoYun().ToArray();
            for (int i = 0, j = l.Length; i < j; i++)
            {
                var xiaoYun = l[i];
                Assert.Equal(years[i], xiaoYun.Year);
                Assert.Equal(ages[i], xiaoYun.Age);
                Assert.Equal(ganZhi[i], xiaoYun.GanZhi);
            }

            years = new[] { 2029, 2030, 2031, 2032, 2033, 2034, 2035, 2036, 2037, 2038 };
            ages = new[] { 47, 48, 49, 50, 51, 52, 53, 54, 55, 56 };
            ganZhi = new[] { "辛酉", "壬戌", "癸亥", "甲子", "乙丑", "丙寅", "丁卯", "戊辰", "己巳", "庚午" };
            l = daYun[5].GetXiaoYun().ToArray();
            for (int i = 0, j = l.Length; i < j; i++)
            {
                var xiaoYun = l[i];
                Assert.Equal(years[i], xiaoYun.Year);
                Assert.Equal(ages[i], xiaoYun.Age);
                Assert.Equal(ganZhi[i], xiaoYun.GanZhi);
            }
        }

        /// <summary>
        ///流月
        ///</summary>
        [Fact]
        public void TestLiuYue()
        {
            var solar = new Solar(1983, 2, 15, 20);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;
            var yun = eightChar.GetYun(0);
            var daYun = yun.GetDaYun().ToArray();

            string[] ganZhi = { "甲寅", "乙卯", "丙辰", "丁巳", "戊午", "己未", "庚申", "辛酉", "壬戌", "癸亥", "甲子", "乙丑" };
            var liuNian = daYun[0].GetLiuNian().ToArray();
            var l = liuNian[0].GetLiuYue().ToArray();
            for (int i = 0, j = l.Length; i < j; i++)
            {
                var liuYue = l[i];
                Assert.Equal(ganZhi[i], liuYue.GanZhi);
            }

            ganZhi = new[] { "庚寅", "辛卯", "壬辰", "癸巳", "甲午", "乙未", "丙申", "丁酉", "戊戌", "己亥", "庚子", "辛丑" };
            liuNian = daYun[4].GetLiuNian().ToArray();
            l = liuNian[2].GetLiuYue().ToArray();
            for (int i = 0, j = l.Length; i < j; i++)
            {
                var liuYue = l[i];
                Assert.Equal(ganZhi[i], liuYue.GanZhi);
            }
        }

        [Fact]
        public void TestGanZhi()
        {
            var solar = new Solar(1988, 2, 15, 23, 30);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;

            Assert.Equal("戊辰", eightChar.Year);
            Assert.Equal("甲寅", eightChar.Month);
            Assert.Equal("庚子", eightChar.Day);
            Assert.Equal("戊子", eightChar.Time);

            eightChar.Sect = 1;
            Assert.Equal("戊辰", eightChar.Year);
            Assert.Equal("甲寅", eightChar.Month);
            Assert.Equal("辛丑", eightChar.Day);
            Assert.Equal("戊子", eightChar.Time);

            solar = new Solar(1988, 2, 15, 22, 30);
            lunar = solar.Lunar;
            eightChar = lunar.EightChar;
            Assert.Equal("戊辰", eightChar.Year);
            Assert.Equal("甲寅", eightChar.Month);
            Assert.Equal("庚子", eightChar.Day);
            Assert.Equal("丁亥", eightChar.Time);

            solar = new Solar(1988, 2, 2, 22, 30);
            lunar = solar.Lunar;
            eightChar = lunar.EightChar;
            Assert.Equal("丁卯", eightChar.Year);
            Assert.Equal("癸丑", eightChar.Month);
            Assert.Equal("丁亥", eightChar.Day);
            Assert.Equal("辛亥", eightChar.Time);
        }

        [Fact]
        public void TestEightChar2Solar()
        {
            var l = Solar.FromBaZi("辛丑", "丁酉", "丙寅", "戊戌").ToArray();
            string[] solarList = { "2021-09-15 20:00:00 星期三 处女座", "1961-09-30 20:00:00 星期六 天秤座" };
            for (int i = 0, j = solarList.Length; i < j; i++)
            {
                Assert.Equal(solarList[i], l[i].FullString);
            }
        }

        [Fact]
        public void Test5()
        {
            var lunar = Lunar.Lunar.FromYmdHms(2019, 12, 12, 11, 22);
            var eightChar = lunar.EightChar;

            Assert.Equal("己亥", eightChar.Year);
            Assert.Equal("丁丑", eightChar.Month);
            Assert.Equal("戊申", eightChar.Day);
            Assert.Equal("戊午", eightChar.Time);
        }

        [Fact]
        public void Test6()
        {
            var lunar = Lunar.Lunar.FromYmdHms(1985, 12, 27);
            var eightChar = lunar.EightChar;
            Assert.Equal("1995-11-05", eightChar.GetYun(1).StartSolar.Ymd);
        }

        [Fact]
        public void TestShenGong()
        {
            var solar = new Solar(1995, 12, 18, 10, 28);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;

            Assert.Equal("壬午", eightChar.ShenGong);
        }

        [Fact]
        public void TestShenGong1()
        {
            var solar = new Solar(1994, 12, 6, 2);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;

            Assert.Equal("丁丑", eightChar.ShenGong);
        }

        [Fact]
        public void TestShenGong2()
        {
            var solar = new Solar(1990, 12, 11, 6);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;

            Assert.Equal("庚辰", eightChar.ShenGong);
        }

        [Fact]
        public void TestShenGong3()
        {
            var solar = new Solar(1993, 5, 23, 4);
            var lunar = solar.Lunar;
            var eightChar = lunar.EightChar;

            Assert.Equal("庚申", eightChar.ShenGong);
        }
        
        [Fact]
        public void Test10()
        {
            var lunar = Solar.FromYmdHms(1988, 2, 15, 23, 30).Lunar;
            var eightChar = lunar.EightChar;

            Assert.Equal("戊辰", eightChar.Year);
            Assert.Equal("甲寅", eightChar.Month);
            Assert.Equal("庚子", eightChar.Day);
            Assert.Equal("戊子", eightChar.Time);
        }
        
        [Fact]
        public void Test11()
        {
            var lunar = Lunar.Lunar.FromYmdHms(1987, 12, 28, 23, 30);
            var eightChar = lunar.EightChar;

            Assert.Equal("戊辰", eightChar.Year);
            Assert.Equal("甲寅", eightChar.Month);
            Assert.Equal("庚子", eightChar.Day);
            Assert.Equal("戊子", eightChar.Time);
        }
        
        [Fact]
        public void Test12()
        {
            var solars = Solar.FromBaZi("丙辰","丁酉","丙子","甲午");
            var actual = solars.Select(solar => solar.YmdHms).ToList();

            var expected = new List<string>
            {
                "1976-09-21 12:00:00",
                "1916-10-06 12:00:00"
            };

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Test13()
        {
            var solars = Solar.FromBaZi("壬寅","庚戌","己未","乙亥");
            var actual = solars.Select(solar => solar.YmdHms).ToList();

            var expected = new List<string>
            {
                "2022-11-02 22:00:00"
            };

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Test14()
        {
            var solars = Solar.FromBaZi("己卯","辛未","甲戌","壬申");
            var actual = solars.Select(solar => solar.YmdHms).ToList();

            var expected = new List<string>
            {
                "1999-07-21 16:00:00",
                "1939-08-05 16:00:00"
            };

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Test15()
        {
            var solars = Solar.FromBaZi("庚子","戊子","己卯","庚午");
            var actual = solars.Select(solar => solar.YmdHms).ToList();

            var expected = new List<string>
            {
                "1960-12-17 12:00:00",
                "1901-01-01 12:00:00"
            };

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Test16()
        {
            var solars = Solar.FromBaZi("庚子","癸未","乙丑","丁亥");
            var actual = solars.Select(solar => solar.YmdHms).ToList();

            var expected = new List<string>
            {
                "2020-07-21 22:00:00",
                "1960-08-05 22:00:00"
            };

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Test17()
        {
            var solars = Solar.FromBaZi("癸卯","甲寅","癸丑","甲子", 2, 1843);
            var actual = solars.Select(solar => solar.YmdHms).ToList();

            var expected = new List<string>
            {
                "2023-02-24 23:00:00",
                "1843-02-08 23:00:00"
            };

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Test18()
        {
            var solars = Solar.FromBaZi("己亥","丁丑","壬寅","戊申");
            var actual = solars.Select(solar => solar.YmdHms).ToList();

            var expected = new List<string>
            {
                "1960-01-15 16:00:00",
                "1900-01-29 16:00:00"
            };

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Test19()
        {
            var solars = Solar.FromBaZi("己亥","丙子","癸酉","庚申");
            var actual = solars.Select(solar => solar.YmdHms).ToList();

            var expected = new List<string>
            {
                "1959-12-17 16:00:00"
            };

            Assert.Equal(expected, actual);
        }
    }
}