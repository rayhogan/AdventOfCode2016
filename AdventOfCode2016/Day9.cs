using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{

    class Day9
    {
        public void Run()
        {
            //Read input file
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Inputs\Day9.txt");
            Part1(lines);
            Part2(lines);
        }

        private void Part1(string[] lines)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            StringBuilder CompletedString = new StringBuilder();

            char[] chars = lines[0].ToCharArray();

            //Loop through the input
            for (int i = 0; i < chars.Length; i++)
            {
                //Check if we find a (0x0) indicator
                if (chars[i].Equals('('))
                {
                    bool fin = false;
                    StringBuilder indicator = new StringBuilder();
                    int count = 1;
                    do
                    {
                        if (!chars[i + count].Equals(')'))
                        {
                            indicator.Append(chars[i + count]);

                        }
                        else
                        {
                            fin = true;
                        }
                        count++;
                    }
                    while (!fin);

                    string[] splitIndicator = indicator.ToString().Split('x');

                    string valueToAppend = lines[0].Substring(i + indicator.Length + 2, Int32.Parse(splitIndicator[0]));

                    for (int j = 0; j < Int32.Parse(splitIndicator[1]); j++)
                    {
                        CompletedString.Append(valueToAppend);
                    }

                    i = i + (indicator.Length + 1) + Int32.Parse(splitIndicator[0]);

                }
                else
                {
                    CompletedString.Append(chars[i]);

                }
            }

            //Console.WriteLine("Completed: " + CompletedString.ToString());
            Console.WriteLine("Value: " + CompletedString.Length);

        }

        private void Part2(string[] lines)
        {
            // Using algorithm found here: http://bit.ly/2w80L2L 

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            char[] chars = lines[0].ToCharArray();

            //Create weighted array with 1 as their starting values
            int[] weightedArray = new int[chars.Length];

            for (int i = 0; i < weightedArray.Length; i++)
            {
                weightedArray[i] = 1;
            }


            //Long to calculate the total length
            long totalLength = 0;

            //Loop through the input
            for (int i = 0; i < chars.Length; i++)
            {
                //We have found a compression indicator
                if (chars[i].Equals('(')) 
                {
                    bool fin = false;
                    StringBuilder indicator = new StringBuilder();
                    int count = 1;
                    do
                    {
                        if (!chars[i + count].Equals(')'))
                        {
                            indicator.Append(chars[i + count]);

                        }
                        else
                        {
                            fin = true;
                        }
                        count++;
                    }
                    while (!fin);

                    //We have extracted the indicator so lets split it to get the values
                    string[] splitIndicator = indicator.ToString().Split('x');

                    //Locate the values affected in the weight array
                    for(int j=0;j<Int32.Parse(splitIndicator[0]);j++)
                    {
                        //Update array value to the sum of the current value * the count value of the indicator
                        weightedArray[i + indicator.Length + j+2] *= Int32.Parse(splitIndicator[1]);
                    }

                    //Shift the position of the loop to continue from the end of the indicator location
                    i += indicator.Length+1;

                }
                else
                {
                    //If it's not an indicator then add the value of it's position in the weighted array
                    //to the final sum
                    totalLength += weightedArray[i];
                   
                }
            }

            //Print final result
            Console.WriteLine("Value: " + totalLength);

        }

    }

}
