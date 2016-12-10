using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day3
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
            //Input
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Inputs\\Day3.txt");
            //Counter for sum of impossible triangles
            int count = 0;

            //Loop through the input
            foreach (string line in lines)
            {
                //Split the lines by space
                string[] split = line.Split(' ');
                //Remove empty entries
                var numQuery = split.Where(num => num != string.Empty);

                //Store results as array
                string[] numbs = numQuery.ToArray();

                //Check for impossible triangles
                if (!IsTriangle((Convert.ToInt32(numbs[0])), (Convert.ToInt32(numbs[1])), (Convert.ToInt32(numbs[2]))))
                    count++;
            }

            //Spit out the results
            Console.WriteLine("Total: " + lines.Count());
            Console.WriteLine("Not Possible: " + count);
            Console.WriteLine("Possible: " + (lines.Count() - count));
        }
        private static void Part2()
        {
            //Input
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Inputs\\Day3.txt");
            //Counter for sum of impossible triangles
            int count = 0;

            //All the lists. ALL OF THREM!
            List<int> Column = new List<int>();
            List<int> Left = new List<int>();
            List<int> Middle = new List<int>();
            List<int> Right = new List<int>();

            //Loop through the input
            foreach (string line in lines)
            {
                //Split the lines by space
                string[] split = line.Split(' ');
                //Remove empty entries
                var numQuery = split.Where(num => num != string.Empty);

                //Store results as array
                string[] numbs = numQuery.ToArray();

                Left.Add((Convert.ToInt32(numbs[0])));
                Middle.Add((Convert.ToInt32(numbs[1])));
                Right.Add((Convert.ToInt32(numbs[2])));

            }

            //Join my lists into one big super list
            Column.AddRange(Left);
            Column.AddRange(Middle);
            Column.AddRange(Right);

            //Start iterating through the lists to check if they are a triangle or not
            for (int i=0;i< Column.Count;i+=3)
            {
                if (!IsTriangle(Column[i], Column[i+1], Column[i+2]))
                    count++;
            }

            //Spit out the results
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Total: " + (Column.Count()/3));
            Console.WriteLine("Not Possible: " + count);
            Console.WriteLine("Possible: " + ((Column.Count()/3) - count));
        }

        private static bool IsTriangle(int a, int b, int c)
        {
            if ((a + b) <= c)
                return false;
            else if ((a + c) <= b)
                return false;
            else if ((b + c) <= a)
                return false;
            else
                return true;
        }
    }
}
