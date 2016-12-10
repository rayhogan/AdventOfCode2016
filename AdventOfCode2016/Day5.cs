using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AdventOfCode2016
{
    class Day5
    {
        public static void Run()
        {
            Part1();
            Part2();
        }

        private static void Part1()
        {
            //Inputs
            //string input = "abc";
            string input = "cxdnnyjw";
            StringBuilder sb = new StringBuilder();
            int count = 0;

            while (sb.ToString().Count() < 8)
            {
                char result = HashBrownsAreDelicious(input + "" + count);

                if (result != ' ')
                    sb.Append(result);

                count++;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Code: " + sb.ToString());

        }

        private static void Part2()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            //Inputs
            //string input = "abc";
            string input = "cxdnnyjw";
            StringBuilder sb = new StringBuilder();
            string[] decryptedCode = { "_", "_", "_", "_", "_", "_", "_", "_" };
            int count = 0;
            int correctMatches = 0;

            while (correctMatches < 8)
            {
                string[] match = HashMeBabyLikeAWagonWheel(input + "" + count);

                if (match[0] != "_")
                {
                    if (decryptedCode[Convert.ToInt32(match[0])] == "_")
                    {
                        decryptedCode[Convert.ToInt32(match[0])] = match[1];
                        correctMatches++;
                        Console.WriteLine(decryptedCode[0] + decryptedCode[1] + decryptedCode[2] + decryptedCode[3] + decryptedCode[4] + decryptedCode[5] + decryptedCode[6] + decryptedCode[7]);
                    }
                }
                count++;
            }

        }
        private static string[] HashMeBabyLikeAWagonWheel(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                string[] suspectedMatch = { "_", "_" };

                byte[] retVal = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(input));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }

                if (sb.ToString().StartsWith("00000"))
                {
                    int n;
                    bool isNumeric = int.TryParse(sb[5].ToString(), out n);

                    if (isNumeric && (n < 8))
                    {
                        suspectedMatch[0] = sb[5].ToString();
                        suspectedMatch[1] = sb[6].ToString();
                    }
                }

                return suspectedMatch;

            }
        }

        private static char HashBrownsAreDelicious(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] retVal = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(input));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }

                if (sb.ToString().StartsWith("00000"))
                {
                    return sb[5];
                }

                return ' ';

            }
        }
    }
}
