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


            //Loop through the input
            foreach (string line in lines)
            {
                //String lists to hold the split strings
                List<string> potential = new List<string>();
                List<string> hypernets = new List<string>();

                //Split and add the first
                string[] split = line.Split('[');
                potential.Add(split[0]);


                //Loop through the rest of the string and add them to
                //their respective string lists
                for (int i = 0; i < (split.Count() - 1); i++)
                {
                    hypernets.Add(split[i + 1].Split(']')[0]);
                    potential.Add(split[i + 1].Split(']')[1]);
                }

                //Check if the hypernets are invalid
                bool invalid = false;
                foreach (string s in hypernets)
                {
                    if (CheckAbba(s))
                    {
                        invalid = true;
                        break;
                    }

                }

                //If hypernets contain an ABBA then it is invalid,
                //don't process further
                if (!invalid)
                {
                    //If hypernets valid, then process the supernets to check for ABBAs
                    foreach (string s in potential)
                    {
                        if (CheckAbba(s))
                        {
                            count++; //Found one!
                            break;
                        }
                    }
                }

            }


            //Spit out the answer
            Console.WriteLine("Count: " + count);
        }

        private static void Part2()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            //Read input file
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Inputs\Day7.txt");

            //Counter
            int count = 0;

            foreach (string line in lines)
            {
                //String lists to hold the split strings
                List<string> potential = new List<string>();
                List<string> hypernets = new List<string>();

                //Split and add the first
                string[] split = line.Split('[');
                potential.Add(split[0]);

                //Loop through the rest of the string and add them to
                //their respective string lists
                for (int i = 0; i < (split.Count() - 1); i++)
                {
                    hypernets.Add(split[i + 1].Split(']')[0]);
                    potential.Add(split[i + 1].Split(']')[1]);
                }

                //Listt to store all potential ABAs
                List<string> abaCount = new List<string>();

                //Look through the supernets and check for ABAs
                foreach (string s in potential)
                {
                    abaCount.AddRange(CheckAba(s)); //Store any abas found
                }

                //If we found no ABAs then don't proceed.
                if (abaCount.Count() > 0)
                {
                    //If wr found ABAs then lets check the hypernets for the reverse
                    foreach (string s in hypernets)
                    {
                        foreach (string a in abaCount)
                        {
                            if (CheckSSL(a, s))
                            {
                                count++; //Found one!
                                break;
                            }
                        }
                    }

                }

            }

            //Spit out the answer
            Console.WriteLine("Count: " + count);
        }

        private static bool CheckAbba(string input)
        {
            char[] splitString = input.ToCharArray(); // Split the input into a char array

            for (int i = 0; i < (splitString.Count() - 3); i++) //Loop through the array checking for ABBAs
            {
                if ((splitString[i] != splitString[i + 1])) //Check for invalid ABBAs e.g. 'aaa'
                {
                    if ((splitString[i] + "" + splitString[i + 1] == splitString[i + 3] + "" + splitString[i + 2]))
                    {
                        return true; // Found an abba! Return true and exit the method
                    }
                }
            }
            return false; // No ABBAs found
        }

        private static List<string> CheckAba(string input)
        {
            char[] splitString = input.ToCharArray(); // Split into char array
            List<string> abas = new List<string>(); // list to store all potential abas

            for (int i = 0; i < (splitString.Count() - 2); i++) //Loop through the input characters
            {
                if ((splitString[i] != splitString[i + 1])) //Checking for invalid aba e.g. 'aaa'
                {
                    if ((splitString[i] == splitString[i + 2])) // Found an aba!
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(splitString[i + 1]);
                        sb.Append(splitString[i]);
                        sb.Append(splitString[i + 1]);

                        abas.Add(sb.ToString()); // Store the reverse as a string so we can check it later
                    }
                }
            }
            return abas; //Return our findings
        }

        private static bool CheckSSL(string bab, string input)
        {
            if (input.Contains(bab)) // Does the hypernet contain our BAB?
            {
                return true; //YES!
            }
            else
            {
                return false; //NO :(
            }
        }
    }
}
