using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AdventOfCode2016
{
    class Day4
    {
        public static void Run()
        {
            List<string> doors = Part1();

            Part2(doors);
        }

        private static List<string> Part1()
        {
            //Read input file
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Inputs\\Day4.txt");

            //Sum of sector IDs of valid doors
            int count = 0;

            //List of all valid doors for use in Part II
            List<string> validDoors = new List<string>();


            //Loop through the input
            foreach (string line in lines)
            {
                //Split to get the room name
                string[] split = line.Split('[');

                //Process the room name (sort, remove sector ID, count letters)
                string result = ProcessRoomName(split[0].Replace("-", ""));

                //If the start of the string is the start of the checksum then we have a winner!
                if (result.StartsWith(split[1].Trim(']')))
                {
                    count += Convert.ToInt32(split[0].Split('-').Last());
                    validDoors.Add(split[0]);
                }

            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Valid Doors: " + count);

            return validDoors;
        }

        private static void Part2(List<string> validDoors)
        {

            //Loop through list of doors
            foreach (string line in validDoors)
            {
                //Section id of the room (needed for the rotation)
                int SectorID = Convert.ToInt32(line.Split('-').Last());
                //SB for building up the room name
                StringBuilder RoomName = new StringBuilder();
                //Start processing the room names
                foreach(char a in line.Replace(SectorID.ToString(), "").ToCharArray())
                    RoomName.Append(ShiftCharacters(a, SectorID));

                //If the room contains "north" in it
                if (RoomName.ToString().Contains("north"))
                {
                    //Print out answer and break out early
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Part II");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Room: "+RoomName.ToString()+"Sector ID: "+SectorID);
                    break;
                }
            }      
        }

        private static string ProcessRoomName(string input)
        {
            StringBuilder output = new StringBuilder();
            //Remove the sector ID from the string
            string removeSectorID = new String(input.Where(c => c != '-' && (c < '0' || c > '9')).ToArray());
            //Sort the string alphabetically
            String sortedString = String.Concat(removeSectorID.OrderBy(c => c));
            //Count and sort letters
            var charGroups = (from c in sortedString
                              group c by c into g
                              select new
                              {
                                  c = g.Key,
                                  count = g.Count(),
                              }).OrderByDescending(c => c.count);

            //Build up my processed roomname
            foreach (var group in charGroups)
            {
                output.Append(group.c);
            }

            return output.ToString();
        }

        private static char ShiftCharacters(char letter,int count)
        {
            if (letter != '-') // If char is not a dash
            {
                while (count > 0) // Shift letters the count of their sector ID
                {
                    if (letter == 'z')
                        letter = 'a';
                    else
                        letter = (char)(((int)letter) + 1);

                    count--;
                }
            }
            else
            {
                // Replace with space and return
                letter = ' ';
            }

            return letter;
        }

    }
}
