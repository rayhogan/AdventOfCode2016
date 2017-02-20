using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016.Day8Stuff
{
    class RotateRow : Command
    {
        private string _instructions;
        private bool[,] _grid;

        public RotateRow(string instructions, bool[,] grid)
        {
            _instructions = instructions;
            _grid = grid;
        }
        public override void ExecuteAction()
        {
            string[] split = _instructions.Split(' ');
            char axis = split[2].ToCharArray()[0];
            int position = Convert.ToInt32(split[2].Split('=')[1]);
            int moveBy = Convert.ToInt32(split[4]);

            int gridLength = _grid.GetLength(1);
            bool[] buffer = new bool[gridLength];



            for (int i = 0; i < gridLength; i++)
            {
                int pos = 0;
                if ((i + moveBy) >= gridLength)
                    pos = (i + moveBy) - gridLength;
                else
                    pos = i + moveBy;

                buffer[pos] = _grid[position, i];
            }

            for (int i = 0; i < gridLength; i++)
            {

                _grid[position, i] = buffer[i];
            }
        }
    }
}
