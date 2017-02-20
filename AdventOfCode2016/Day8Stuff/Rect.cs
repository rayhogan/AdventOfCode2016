using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016.Day8Stuff
{
    class Rect : Command
    {
        private string _instructions;
        private bool[,] _grid;

        public Rect(string instructions, bool[,] grid)
        {
            _instructions = instructions;
            _grid = grid;
        }

        public override void ExecuteAction()
        {

            string[] split = _instructions.Split(' ')[1].Split('x');

            for (int i = 0; i < Convert.ToInt32(split[1]); i++)
            {
                for (int j = 0; j < Convert.ToInt32(split[0]); j++)
                {
                    _grid[i, j] = true;
                }

            }
        }

    }
}
