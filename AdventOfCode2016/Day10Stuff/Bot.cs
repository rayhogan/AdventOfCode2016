using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016.Day10Stuff
{
    class Bot : Container
    {
        private string highTo = "";
        private string lowTo = "";

        public Bot(int id) : base(id)
        {

        }

        public int GetHighLowValue(bool high)
        {
            if (high)
                return chips.Max();
            else
                return chips.Min();
        }

        public string GetHighLowTo(bool high)
        {
            if (high)
                return highTo;
            else
                return lowTo;
        }

        public void SetHighLowTo(bool high, string value)
        {
            if (high)
                highTo = value;
            else
                lowTo = value;
        }


    }
}
