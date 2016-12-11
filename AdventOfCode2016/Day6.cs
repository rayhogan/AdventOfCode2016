using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day6
    {
        public static void Run()
        {
            Part1(); //Parts 1 & 2 in the one method as it's a short one
        }

        private static void Part1()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            //Read input file
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Inputs\Day6.txt");

            List<StringBuilder> sbList = new List<StringBuilder>();

            //Figure out how many letters in each and create
            //the stringbuilders (makes it more dynamic)
            foreach(char a in lines[0].ToCharArray())
            {
                sbList.Add(new StringBuilder());
            }

            //Loop through the input
            foreach (string line in lines)
            {
                char[] split = line.ToCharArray();

                for(int i=0;i<line.Count();i++)
                {
                    sbList[i].Append(split[i]);
                }
            }

            //Most common
            foreach(StringBuilder sb in sbList)
            {
                Console.Write(DetermineCommonLetter(sb.ToString(), true));
            }
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            //Leat common
            foreach (StringBuilder sb in sbList)
            {
                Console.Write(DetermineCommonLetter(sb.ToString(), false));
            }
        }

        private static char DetermineCommonLetter(string input, bool mostCommon)
        {
            if (mostCommon)
            {
                var output = input.GroupBy(x => x).OrderByDescending(x => x.Count()).First();
                return output.Key;
            }
            else
            {
                var output = input.GroupBy(x => x).OrderByDescending(x => x.Count()).Last();
                return output.Key;
            }
        }
    }
}
