using AdventOfCode2016.Day8Stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day8
    {
        public void Run()
        {
            Part1();
            //Part2();
        }

        public void Part1()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            //Grid
            bool[,] array = new bool[6, 50];
            //bool[,] array = new bool[6, 50];

            int pixels = 0;
   

            //Read input file
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Inputs\Day8.txt");

            foreach (string s in lines)
            {
                Command command = CommandFactory.ProcessCommand(s, array);
                command.ExecuteAction();
                

            }


            //Spit out the answer
            pixels = PrintGrid(array);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Pixels Lit: " + pixels);


        }

        private static void Part2()
        {

        }

        private int PrintGrid(bool[,] array)
        {
            int count = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    bool s = array[i, j];
                    if (s)
                    {
                        Console.Write("#");
                        count++;
                    }
                    else
                        Console.Write(".");
                }
                Console.WriteLine();
            }
            return count;
        }
    }
}
