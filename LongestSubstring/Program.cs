using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LongestSubstring
{
    internal class Program
    {
        /// <summary>
        /// https://leetcode.com/problems/longest-substring-without-repeating-characters/description/
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            Console.WriteLine(LengthOfLongestSubstring(s).ToString());
            Console.ReadKey();           
        }
        
        public static int LengthOfLongestSubstring(string s)
        {
            int sequenceInd = 0; // index of the sequence in the string s
            int maxCount = 0, tempInd, uniqueSeqCount = 0;

            if(s.Length == 0) return 0;

            for (int i = 0; i < s.Length; i++)
            {
                string sequence = s.Substring(sequenceInd, i - sequenceInd);

                tempInd = FindRepeatedIndex(sequence, s[i]);
                if (tempInd != -1) // s[i] is not unique
                {
                    uniqueSeqCount = sequence.Length;
                    sequenceInd += tempInd + 1;

                }
                else //tempInd == -1; s[i] is unique
                {
                    uniqueSeqCount = sequence.Length + 1; // to encounter unique s[i]
                }
                if (uniqueSeqCount > maxCount) 
                    maxCount = uniqueSeqCount;
            }
            return maxCount;
        }

        /// <summary>
        /// find whether if current symbol is repeated
        /// </summary>
        /// <param name="s"> s is a substring of the main word, last unique sequence before the symbol </param>
        /// <param name="symb"></param>
        /// <returns> index of the repeated symbol in s, -1 if not found</returns>
        public static int FindRepeatedIndex(string s, char symb) 
        {
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == symb) 
                    return s.IndexOf(symb);
            }
            return -1;
        }
    }
}
