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
            Solar solar = new Solar(2020,5,26,23,42,0);
            Console.WriteLine(solar);
            Console.WriteLine(solar.toFullString());

            // 阴历
            Lunar lunar = solar.getLunar();
            Console.WriteLine(lunar);
            Console.WriteLine(lunar.toFullString());

            // 八字
            foreach(string s in lunar.getBaZi()){
                Console.Write(s+" ");
            }
            Console.WriteLine();

            // 八字纳音
            foreach (string s in lunar.getBaZiNaYin())
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            // 八字天干十神
            foreach (string s in lunar.getBaZiShiShenGan())
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            // 八字地支十神
            foreach (string s in lunar.getBaZiShiShenZhi())
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            // 八字年支十神
            foreach (string s in lunar.getBaZiShiShenYearZhi())
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            // 八字月支十神
            foreach (string s in lunar.getBaZiShiShenMonthZhi())
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            // 八字日支十神
            foreach (string s in lunar.getBaZiShiShenDayZhi())
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            // 八字时支十神
            foreach (string s in lunar.getBaZiShiShenTimeZhi())
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            // 八字五行
            foreach (string s in lunar.getBaZiWuXing())
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

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
