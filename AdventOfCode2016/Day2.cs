using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AdventOfCode2016
{
    class Day2
    {
        public static void Run()
        {
            Keypad1();
            Keypad2();
        }
        private static void Keypad1()
        {
            //Input
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Inputs\\Day2.txt");

            //List of code integers
            List<int> code = new List<int>();
            //Current keypad position
            int currentPosition = 5;


            Console.Write("Part I Code: ");

            //Loop through the instructions
            foreach (String line in lines)
            {

                foreach (char a in line.ToCharArray())
                {
                    if (a.Equals('U'))
                    {
                        if ((currentPosition - 3) >= 1)
                            currentPosition -= 3;
                    }
                    else if (a.Equals('D'))
                    {
                        if ((currentPosition + 3) <= 9)
                            currentPosition += 3;
                    }
                    else if (a.Equals('R'))
                    {
                        if ((currentPosition % 3) != 0)
                            currentPosition += 1;
                    }
                    else if (a.Equals('L'))
                    {
                        if ((currentPosition % 3) != 1)
                            currentPosition -= 1;
                    }
                }
                code.Add(currentPosition);
                Console.Write(currentPosition);
            }
            Console.WriteLine("");
        }


        private static void Keypad2()
        {
            //Keypad in grid format
            var keyPad = new[,]
            {
              {'x', 'x', '1', 'x', 'x'},
              {'x', '2', '3', '4', 'x'},
              {'5', '6', '7', '8', '9'},
              {'x', 'A', 'B', 'C', 'x'},
              {'x', 'x', 'D', 'x', 'x'},
          };

            //Point containing current position
            Point currentPosition = new Point(2, 0);

            //Input
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Inputs\\Day2.txt");

            //Loop through the instructions
            foreach (String line in lines)
            {

                foreach (char a in line.ToCharArray())
                {
                    if (a.Equals('U'))
                    {
                        if ((currentPosition.X - 1) >= 0) //Check if move puts us off the grid...
                        {
                            if ((keyPad[currentPosition.X - 1, currentPosition.Y]) != 'x')
                            {
                                currentPosition.X--;
                            }
                        }
                    }
                    else if (a.Equals('D'))
                    {
                        if ((currentPosition.X + 1) <= 4) //Check if move puts us off the grid...
                        {
                            if ((keyPad[currentPosition.X + 1, currentPosition.Y]) != 'x')
                            {
                                currentPosition.X++;
                            }
                        }
                    }
                    else if (a.Equals('R'))
                    {
                        if ((currentPosition.Y + 1) <= 4) //Check if move puts us off the grid...
                        {
                            if ((keyPad[currentPosition.X, currentPosition.Y + 1]) != 'x')
                            {
                                currentPosition.Y++;
                            }
                        }
                    }
                    else if (a.Equals('L'))
                    {
                        if ((currentPosition.Y - 1) >= 0) //Check if move puts us off the grid...
                        {
                            if ((keyPad[currentPosition.X, currentPosition.Y - 1]) != 'x')
                            {
                                currentPosition.Y--;
                            }
                        }
                    }
                }
                Console.Write(keyPad[currentPosition.X, currentPosition.Y]);
            }

        }
    }

}
