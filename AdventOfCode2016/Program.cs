﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DAY 1");
            Console.ForegroundColor = ConsoleColor.White;
            Day1.Run();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DAY 2");
            Console.ForegroundColor = ConsoleColor.White;
            Day2.Run();
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DAY 3");
            Console.ForegroundColor = ConsoleColor.White;
            Day3.Run();
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DAY 4");
            Console.ForegroundColor = ConsoleColor.White;
            Day4.Run();
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DAY 5 (May take a while!)");
            Console.ForegroundColor = ConsoleColor.White;
            Day5.Run();
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DAY 6");
            Console.ForegroundColor = ConsoleColor.White;
            Day6.Run();
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DAY 7");
            Console.ForegroundColor = ConsoleColor.White;
            Day7.Run();
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DAY 8");
            Console.ForegroundColor = ConsoleColor.White;
            Day8 day8 = new Day8();
            day8.Run();
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DAY 9");
            Console.ForegroundColor = ConsoleColor.White;
            Day9 day9 = new Day9();
            day9.Run();
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DAY 10");
            Console.ForegroundColor = ConsoleColor.White;
            Day10.Run();

        }
    }
}
