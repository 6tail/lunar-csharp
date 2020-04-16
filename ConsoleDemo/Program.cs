using System;
using System.Collections.Generic;
using System.Text;
using com.nlf.calendar;

namespace ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Solar solar = new Solar();
            Console.WriteLine(solar);
            Console.WriteLine(solar.toFullString());
            Lunar lunar = new Lunar();
            Console.WriteLine(lunar);
            Console.WriteLine(lunar.toFullString());

            foreach(string s in lunar.getBaZi()){
                Console.Write(s+" ");
            }
            Console.WriteLine();
            foreach (string s in lunar.getBaZiNaYin())
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            foreach (string s in lunar.getBaZiShiShenGan())
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            foreach (string s in lunar.getBaZiShiShenZhi())
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            foreach (string s in lunar.getBaZiWuXing())
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
