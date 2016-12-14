using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day7
    {
        public static void Run()
        {
            Part1();
            Part2();
        }

        private static void Part1()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            //Read input file
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Inputs\Day7.txt");

            //Counter
            int count = 0;

            foreach (string line in lines)
            {
                List<string> potential = new List<string>();
                List<string> hypernets = new List<string>();

                string[] split = line.Split('[');

                potential.Add(split[0]);


                    for(int i=0;i< (split.Count()-1);i++)
                    {
                        hypernets.Add(split[i+1].Split(']')[0]);
                        potential.Add(split[i + 1].Split(']')[1]);
                    }
    
     

                bool invalid = false;
                foreach(string s in hypernets)
                {
                    if(CheckAbba(s))
                    {
                        invalid = true;
                        break;
                    }
                    
                }

                if(!invalid)
                {
                    foreach(string s in potential)
                    {
                        if (CheckAbba(s))
                        {
                            count++;
                            break;
                        }
                    }
                }               

            }

            Console.WriteLine("Count: " + count);
        }

        private static void Part2()
        {

        }

        private static bool CheckAbba(string input)
        {
            char[] splitString = input.ToCharArray();


            for (int i = 0; i < (splitString.Count() - 3); i++)
            {
                if ((splitString[i] != splitString[i + 1]))
                {
                    if ((splitString[i] + "" + splitString[i + 1] == splitString[i + 3] + "" + splitString[i + 2]))
                    {
                        return true;
                    }
                }
            }
            return false;

        }
    }
}
