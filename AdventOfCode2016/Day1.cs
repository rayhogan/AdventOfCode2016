﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Drawing;

namespace AdventOfCode2016
{
    class Day1
    {
       
        // Global var location
        private static Point currentPos = new Point(0, 0);

        public static void Run()
        {
            //Challenge Input
            String input = "R4, R3, R5, L3, L5, R2, L2, R5, L2, R5, R5, R5, R1, R3, L2, L2, L1, R5, L3, R1, L2, R1, L3, L5, L1, R3, L4, R2, R4, L3, L1, R4, L4, R3, L5, L3, R188, R4, L1, R48, L5, R4, R71, R3, L2, R188, L3, R2, L3, R3, L5, L1, R1, L2, L4, L2, R5, L3, R3, R3, R4, L3, L4, R5, L4, L4, R3, R4, L4, R1, L3, L1, L1, R4, R1, L4, R1, L1, L3, R2, L2, R2, L1, R5, R3, R4, L5, R2, R5, L5, R1, R2, L1, L3, R3, R1, R3, L4, R4, L4, L1, R1, L2, L2, L4, R1, L3, R4, L2, R3, L1, L5, R4, R5, R2, R5, R1, R5, R1, R3, L3, L2, L2, L5, R2, L2, R5, R5, L2, R3, L5, R5, L2, R4, R2, L1, R3, L5, R3, R2, R5, L1, R3, L2, R2, R1";
            String[] split = input.Split(',');

            //Starting orientation
            char orientation = 'n';
            //List of points traversed
            List<Point> points = new List<Point>();

            //Start looping through the instructions
            foreach (String entry in split)
            {
                // Determine new orientation
                orientation = entry.TrimStart().StartsWith("R") ? TurnRight(orientation) : TurnLeft(orientation);

                //Log my travels
                TrackLocation(orientation, points, entry);
            }

            //Spit out the block number for challenge 1
            Console.WriteLine("Part I: " + CalculateBlocks(points.Last()));

            //Spit out the repeating node and block number for challenge 2
            Point FirstDup = FindFirstRepeatingNode(points);
            Console.WriteLine("Part II: First Repeat @ Co-Ords"+FirstDup+" which is "+CalculateBlocks(FirstDup)+" blocks away");

        }


        private static void TrackLocation(char orientation, List<Point> points, string step)
        {
            int stepCount = Convert.ToInt32(Regex.Match(step, @"\d+").Value);

            if (orientation == 'n')
            {
                while (stepCount > 0)
                {
                    currentPos.X += 1;
                    points.Add(currentPos);
                    stepCount--;
                }
            }
            else if (orientation == 's')
            {
                while (stepCount > 0)
                {
                    currentPos.X -= 1;
                    points.Add(currentPos);
                    stepCount--;
                }
            }
            else if (orientation == 'e')
            {
                while (stepCount > 0)
                {
                    currentPos.Y += 1;
                    points.Add(currentPos);
                    stepCount--;
                }
            }
            else if (orientation == 'w')
            {
                while (stepCount > 0)
                {
                    currentPos.Y -= 1;
                    points.Add(currentPos);
                    stepCount--;
                }
            }
            
        }

        private static int CalculateBlocks(Point a)
        {
            return (Math.Abs(a.X) + Math.Abs(a.Y));
        }

        private static Point FindFirstRepeatingNode(List<Point> points)
        {
            Point output = new Point();
            foreach (Point cord in points)
            {
                var numQuery = points.Where(num => num == cord);

                if (numQuery.Count() > 1)
                {
                    output = cord;
                    break;
                }
            }

            return output;
        }

        private static char TurnRight(char orientation)
        {
            if (orientation == 'n')
            {
                return 'e';
            }
            else if (orientation == 's')
            {
                return 'w';
            }
            else if (orientation == 'e')
            {
                return 's';
            }
            else if (orientation == 'w')
            {
                return 'n';
            }
            else
            {
                return new char();
            }

        }

        private static char TurnLeft(char orientation)
        {
            if (orientation == 'n')
            {
                return 'w';
            }
            else if (orientation == 's')
            {
                return 'e';
            }
            else if (orientation == 'e')
            {
                return 'n';
            }
            else if (orientation == 'w')
            {
                return 's';
            }
            else
            {
                return new char();
            }
        }

    }
}