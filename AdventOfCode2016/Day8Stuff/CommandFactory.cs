using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016.Day8Stuff
{
    public static class CommandFactory
    {
        public static Command ProcessCommand(string instructions, bool[,] grid)
        {
            Command output = null;

            if (instructions.StartsWith("rect"))
                output = new Rect(instructions, grid);
            else if (instructions.StartsWith("rotate row"))
                output = new RotateRow(instructions, grid);
            else if (instructions.StartsWith("rotate column"))
                output = new RotateColumn(instructions, grid);
            else
                Console.WriteLine("EERRRRRRRRROR");

            return output;

        }
    }
}
