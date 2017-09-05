using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016.Day10Stuff
{
    class Container
    {
        private int ID { get; set; }
        protected List<int> chips = new List<int>();

        public Container(int id)
        {
            ID = id;
        }
        public int AddChip(int chip)
        {
            chips.Add(chip);
            return chips.Count;
        }

        public int GetChipsCount()
        {
            return chips.Count;
        }

        public void RemoveChip(int chip)
        {
            chips.Remove(chip);
        }

        public bool CheckContents(int one, int two)
        {
            if (chips.Contains(one) && chips.Contains(two))
                return true;
            else
                return false;
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
