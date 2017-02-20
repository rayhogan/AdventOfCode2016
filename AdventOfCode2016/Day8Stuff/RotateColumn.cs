using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016.Day8Stuff
{
    class RotateColumn : Command
    {
        private string _instructions;
        private bool[,] _grid;

        public RotateColumn(string instructions, bool[,] grid)
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

            int gridHeight = _grid.GetLength(0);

            bool[] buffer = new bool[gridHeight];



            for (int i = 0; i < gridHeight; i++)
            {
                int pos = 0;
                if ((i + moveBy) >= gridHeight)
                    pos = (i + moveBy) - gridHeight;
                else
                    pos = i+ moveBy;

                buffer[pos] = _grid[i, position];
            }

            for (int i = 0; i < gridHeight; i++)
            {

                _grid[i, position] = buffer[i];
            }
        }
    }
}
