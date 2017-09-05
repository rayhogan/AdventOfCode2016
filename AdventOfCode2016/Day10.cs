using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2016.Day10Stuff;

namespace AdventOfCode2016
{
    class Day10
    {

        static Dictionary<int, Bot> botCollection = new Dictionary<int, Bot>();
        static Dictionary<int, Bin> binCollection = new Dictionary<int, Bin>();
        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Inputs\Day10.txt");
            Part1(lines);
            Part2(lines);
        }

        private static void Part1(string[] lines)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            // List to store the 'Value X..." instructions
            List<string> valueInstructions = new List<string>();


            //Loop through the input
            foreach (string s in lines)
            {
                // If we find a reference to a bot
                if (s.StartsWith("bot"))
                {
                    string[] split = s.Split(' ');

                    // If the bot doesn't exist, add it!
                    if (!botCollection.Keys.Contains(Int32.Parse(split[1])))
                    {
                        botCollection.Add(Int32.Parse(split[1]), new Bot(Int32.Parse(split[1])));
                    }

                    // Who does the bot hand low to?
                    if (split[5].Equals("output")) // Does it put it in an output bin?
                    {
                        // If we aren't already aware of the output bin then add it to our collection
                        if (!binCollection.Keys.Contains(Int32.Parse(split[6])))
                        {
                            binCollection.Add(Int32.Parse(split[6]), new Bin(Int32.Parse(split[6])));
                        }

                        // Add a refernece to the bot class noting what bin to give the low chip to
                        botCollection[Int32.Parse(split[1])].SetHighLowTo(false, "Bin" + split[6]);
                    }
                    else if (split[5].Equals("bot")) // Does it give it to another bot?
                    {
                        // If we aren't already aware of the bot then add it to our collection
                        if (!botCollection.Keys.Contains(Int32.Parse(split[6])))
                        {
                            botCollection.Add(Int32.Parse(split[6]), new Bot(Int32.Parse(split[6])));
                        }

                        // Add a reference to the bot class noting what bot to give the low chip to
                        botCollection[Int32.Parse(split[1])].SetHighLowTo(false, "Bot" + split[6]);
                    }
                    else
                    {
                        throw new Exception("Something went wrong determing who to give the low chip to");
                    }

                    // Who does the bot hand high to?
                    if (split[10].Equals("output")) // Does it put it in an output bin?
                    {
                        // If we aren't already aware of the output bin then add it to our collection
                        if (!binCollection.Keys.Contains(Int32.Parse(split[11])))
                        {
                            binCollection.Add(Int32.Parse(split[11]), new Bin(Int32.Parse(split[11])));
                        }
                        // Add a reference to the bot class noting what output bin to give the low chip to
                        botCollection[Int32.Parse(split[1])].SetHighLowTo(true, "Bin" + split[11]);
                    }
                    else if (split[10].Equals("bot")) // Does it give it to another bot?
                    {
                        // If we aren't already aware of the bot then add it to our collection
                        if (!botCollection.Keys.Contains(Int32.Parse(split[11])))
                        {
                            botCollection.Add(Int32.Parse(split[11]), new Bot(Int32.Parse(split[11])));
                        }
                        // Add a reference to the bot class noting what bot to give the low chip to
                        botCollection[Int32.Parse(split[1])].SetHighLowTo(true, "Bot" + split[11]);
                    }
                    else
                    {
                        throw new Exception("Something went wrong determing who to give the high chip to");
                    }

                }
                else if (s.StartsWith("value")) // If find an 'Value x..." instruction
                {
                    // Add it to the collection of instructions
                    valueInstructions.Add(s);
                }
                else
                {
                    throw new Exception("Something went wrong parsing initial instructions");
                }
            }


            // Now that we've built up a collection of bins and bots, let's tackle the Value instructions!
            // Loop through the collections...
            foreach (string s in valueInstructions)
            {
                string[] split = s.Split(' ');

                int value = Int32.Parse(split[1]); // Value of the chip in question
                int botNo = Int32.Parse(split[5]); // The ID of the bot in question

                if (split[4].Equals("bot")) // If we are passing the chip to a bot...
                {
                    int count = botCollection[botNo].AddChip(value); // Add chip to the bot

                    if (count > 1) // If adding the chip as exceeded it's 2 chip threshold
                    {
                        //Quick check to see if we found the winning
                        if (botCollection[botNo].CheckContents(61, 17))
                        {
                            Console.WriteLine("Bot " + botNo + " is responsible for checking " + 61 + " and " + 17 + "!!!!!");
                        }
                        MoveChips(botCollection[botNo], botCollection[botNo].GetHighLowTo(true), botCollection[botNo].GetHighLowValue(true));
                        MoveChips(botCollection[botNo], botCollection[botNo].GetHighLowTo(false), botCollection[botNo].GetHighLowValue(false));
                    }

                }
                else // Else add the chip to a bin
                {
                    binCollection[botNo].AddChip(value);
                }

            }

        }

        private static void Part2(string[] lines)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            int calc = 1;
            Console.WriteLine("Bin 0");
            foreach (int i in binCollection[0].GetAllChips())
            {
                Console.WriteLine(i);
                calc = calc * i;
            }
            Console.WriteLine("Bin 1");
            foreach (int i in binCollection[1].GetAllChips())
            {
                Console.WriteLine(i);
                calc = calc * i;
            }
            Console.WriteLine("Bin 2");
            foreach (int i in binCollection[2].GetAllChips())
            {
                Console.WriteLine(i);
                calc = calc * i;
            }

            Console.WriteLine("Calc: " + calc);
        }


        private static void MoveChips(Bot botFrom, String to, int value)
        {
            if (to.StartsWith("Bot"))
            {
                int toValue = Int32.Parse(to.TrimStart("Bot".ToCharArray()).ToString());
                botFrom.RemoveChip(value);
                int count = botCollection[toValue].AddChip(value);

                if (count > 1)
                {
                    if (botCollection[toValue].CheckContents(61, 17))
                    {
                        Console.WriteLine("Bot " + toValue + " is responsible for checking " + 61 + " and " + 17 + "!!!!!");
                    }

                    MoveChips(botCollection[toValue], botCollection[toValue].GetHighLowTo(true), botCollection[toValue].GetHighLowValue(true));
                    MoveChips(botCollection[toValue], botCollection[toValue].GetHighLowTo(false), botCollection[toValue].GetHighLowValue(false));
                }
            }
            else if (to.StartsWith("Bin"))
            {
                int toValue = Int32.Parse(to.TrimStart("Bin".ToCharArray()).ToString());
                botFrom.RemoveChip(value);
                binCollection[toValue].AddChip(value);
            }
            else
            {
                Console.WriteLine("No where to pass it to");
            }
        }
    }
}
