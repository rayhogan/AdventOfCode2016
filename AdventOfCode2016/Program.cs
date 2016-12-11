using System;
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
            Console.WriteLine("FIN");
        }
    }
}
