using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016.Day10Stuff
{
    class Bot_old
    {
        private int ID { get; set; }
        private List<int> chips = new List<int>();
        private string highTo = "";
        private string lowTo = "";

        public Bot_old(int id)
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

        public bool BotContains(int one, int two)
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
