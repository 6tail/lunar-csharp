using System;
using System.Collections.Generic;
using System.Text;
using com.nlf.calendar;
using com.nlf.calendar.util;

namespace ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // 阳历
            Solar solar = new Solar(2020, 5, 26, 23, 42, 0);
            Console.WriteLine(solar);
            Console.WriteLine(solar.toFullString());

            // 阴历
            Lunar lunar = solar.getLunar();
            Console.WriteLine(lunar);
            Console.WriteLine(lunar.toFullString());

            // 八字
            EightChar baZi = lunar.getEightChar();
            Console.WriteLine(baZi.getYear() + " " + baZi.getMonth() + " " + baZi.getDay() + " " + baZi.getTime());

            // 八字纳音
            Console.WriteLine(baZi.getYearNaYin() + " " + baZi.getMonthNaYin() + " " + baZi.getDayNaYin() + " " + baZi.getTimeNaYin());

            // 八字五行
            Console.WriteLine(baZi.getYearWuXing() + " " + baZi.getMonthWuXing() + " " + baZi.getDayWuXing() + " " + baZi.getTimeWuXing());

            // 八字天干十神
            Console.WriteLine(baZi.getYearShiShenGan() + " " + baZi.getMonthShiShenGan() + " " + baZi.getDayShiShenGan() + " " + baZi.getTimeShiShenGan());

            // 八字地支十神
            Console.WriteLine(baZi.getYearShiShenZhi()[0] + " " + baZi.getMonthShiShenZhi()[0] + " " + baZi.getDayShiShenZhi()[0] + " " + baZi.getTimeShiShenZhi()[0]);

            // 八字年支十神
            foreach (string s in baZi.getYearShiShenZhi())
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            // 八字月支十神
            foreach (string s in baZi.getMonthShiShenZhi())
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            // 八字日支十神
            foreach (string s in baZi.getDayShiShenZhi())
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            // 八字时支十神
            foreach (string s in baZi.getTimeShiShenZhi())
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            // 八字胎元
            Console.WriteLine(baZi.getTaiYuan());

            // 八字命宫
            Console.WriteLine(baZi.getMingGong());

            // 八字身宫
            Console.WriteLine(baZi.getShenGong());

            // 节假日
            List<Holiday> holidays = HolidayUtil.getHolidays(2012);
            foreach (Holiday holiday in holidays)
            {
                Console.WriteLine(holiday);
            }
            Console.WriteLine();

            // 八字转阳历
            List<Solar> solars = Solar.fromBaZi("庚子", "戊子", "己卯", "庚午");
            foreach (Solar d in solars)
            {
                Console.WriteLine(d.toFullString());
            }
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
