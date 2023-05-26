using System;
using System.Linq;
using Lunar;
using Lunar.Util;

namespace demo
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        private static void Main()
        {
            // 阳历
            var solar = new Solar(2020, 5, 26, 23, 42);
            Console.WriteLine(solar);
            Console.WriteLine(solar.FullString);

            // 阴历
            var lunar = solar.Lunar;
            Console.WriteLine(lunar);
            Console.WriteLine(lunar.FullString);

            // 八字
            var baZi = lunar.EightChar;
            Console.WriteLine($"{baZi.Year} {baZi.Month} {baZi.Day} {baZi.Time}");

            // 八字纳音
            Console.WriteLine($"{baZi.YearNaYin} {baZi.MonthNaYin} {baZi.DayNaYin} {baZi.TimeNaYin}");

            // 八字五行
            Console.WriteLine($"{baZi.YearWuXing} {baZi.MonthWuXing} {baZi.DayWuXing} {baZi.TimeWuXing}");

            // 八字天干十神
            Console.WriteLine($"{baZi.YearShiShenGan} {baZi.MonthShiShenGan} {baZi.DayShiShenGan} {baZi.TimeShiShenGan}");

            // 八字地支十神
            Console.WriteLine($"{baZi.YearShiShenZhi.First()} {baZi.MonthShiShenZhi.First()} {baZi.DayShiShenZhi.First()} {baZi.TimeShiShenZhi.First()}");

            // 八字年支十神
            foreach (var s in baZi.YearShiShenZhi)
            {
                Console.Write(s);
                Console.Write(" ");
            }
            Console.WriteLine();

            // 八字月支十神
            foreach (var s in baZi.MonthShiShenZhi)
            {
                Console.Write(s);
                Console.Write(" ");
            }
            Console.WriteLine();

            // 八字日支十神
            foreach (var s in baZi.DayShiShenZhi)
            {
                Console.Write(s);
                Console.Write(" ");
            }
            Console.WriteLine();

            // 八字时支十神
            foreach (var s in baZi.TimeShiShenZhi)
            {
                Console.Write(s);
                Console.Write(" ");
            }
            Console.WriteLine();

            // 八字胎元
            Console.WriteLine(baZi.TaiYuan);

            // 八字命宫
            Console.WriteLine(baZi.MingGong);

            // 八字身宫
            Console.WriteLine(baZi.ShenGong);

            Console.WriteLine();
            solar = new Solar(1988, 3, 20, 18);
            lunar = solar.Lunar;
            baZi = lunar.EightChar;

            // 男运
            var yun = baZi.GetYun(1);
            Console.WriteLine($"阳历{solar.YmdHms}出生");
            Console.WriteLine($"出生{yun.StartYear}年{yun.StartMonth}个月{yun.StartDay}天后起运");
            Console.WriteLine($"阳历{yun.StartSolar.Ymd}后起运");
            Console.WriteLine();

            // 节假日
            var holidays = HolidayUtil.GetHolidays(2012);
            foreach (var holiday in holidays)
            {
                Console.WriteLine(holiday);
            }
            Console.WriteLine();

            // 八字转阳历
            var solarList = Solar.FromBaZi("庚子", "戊子", "己卯", "庚午");
            foreach (var d in solarList)
            {
                Console.WriteLine(d.FullString);
            }
            Console.WriteLine();
        }
    }
}