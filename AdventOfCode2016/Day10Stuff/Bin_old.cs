using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016.Day10Stuff
{
    class Bin_old
    {
        public int ID { get; set; }

        public List<int> chips = new List<int>();

        public Bin_old(int id)
        {
            ID = id;
        }

        public void AddChip(int chip)
        {
            chips.Add(chip);
        }

        public void RemoveChip(int chip)
        {
            chips.Remove(chip);
        }

        public bool BinContains(int one, int two)
        {
            if (chips.Contains(one) && chips.Contains(two))
                return true;
            else
                return false;
        }

        public int GetHighLowValue(bool high)
        {
            if (high)
                return chips.Max();
            else
                return chips.Min();
        }

        public int GetId()
        {
            return ID;
        }

        public List<int> GetAllChips()
        {
            return chips;
        }
    }
}
