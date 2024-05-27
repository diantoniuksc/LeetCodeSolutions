using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordBreakTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "aaaaaaa";

            List<string> wordDict = new List<string>
            {
                "aaaa", "aaa"
            };

            int[] hashDict = GetHashDictionaryArr(wordDict);
            IList<string> list = WordBreak(s, wordDict);
           // Console.WriteLine(CreateListOfWords(s, hashDict, 0, "", wordDict, ref varList, 0).ToString());
            PrintAllLexemesFromList(list);
            Console.ReadLine();
        }

        static void PrintAllLexemesFromList(IList<string> varList)
        {
            foreach(string variation in varList)
            {
                Console.WriteLine(variation);
            }
        }

        /// <summary>
        /// https://leetcode.com/problems/word-break-ii/?envType=daily-question&envId=2024-05-25
        /// </summary>
        /// <param name="sentance"></param>
        /// <param name="hashDictionary"></param>
        /// <param name="indexOfLexemeInSentance">index of element from with the analysis of a new lexeme is started</param>
        /// <param name="lexemes"></param>
        /// <param name="wordDict"></param>
        /// <param name="varList"></param>
        /// <returns>false if there are no alternative lexemes</returns>
        public static bool CreateListOfWords(string sentance, int[] hashDictionary, int indexOfLexemeInSentance, string lexemes,
            IList<string> wordDict, ref List<string> varList)
        {
            int[] alternativeLexemesIndArr = CreateArrayOfAlternativeLexemeInd(indexOfLexemeInSentance, sentance, wordDict, hashDictionary);
            if (alternativeLexemesIndArr == null && indexOfLexemeInSentance < sentance.Length) //rest of the sentance is not a valid lexeme in the dictionary       
                return false;
            if (alternativeLexemesIndArr == null && lexemes.Length != 0 && indexOfLexemeInSentance == sentance.Length)
            {
                varList.Add(lexemes);
                return true;
            }

            int count = 0;
            foreach (int lexemeInd in alternativeLexemesIndArr)
            {
                if (alternativeLexemesIndArr.Length > 1 && lexemes.Length != 0 && count != 0)
                {
                    if (lexemes.Contains(" "))
                        lexemes = lexemes.Remove(lexemes.LastIndexOf(" "));
                    else
                        lexemes = lexemes.Remove(0);
                }

                if (lexemes.Length != 0)
                    lexemes = lexemes + " ";
                lexemes += wordDict[lexemeInd];
                bool result = CreateListOfWords(sentance, hashDictionary, indexOfLexemeInSentance + wordDict[lexemeInd].Length, lexemes,
                    wordDict, ref varList);
                count++;
            }

            if (varList.Count != 0)
                return true;
            else
                return false;
        }
        public static IList<string> WordBreak(string s, IList<string> wordDict)
        {
            List<string> varList = new List<string>();
            int[] hashDict = GetHashDictionaryArr(wordDict);

            CreateListOfWords(s, hashDict, 0, "", wordDict, ref varList);
            return varList;
        }
        public static int[] CreateArrayOfAlternativeLexemeInd(int indOfNewLexeme, string sentance, IList<string> wordDict, int[] hashDictionary)
        {
            int[] lexmeIndArr = new int[wordDict.Count];
            int counter = 0;
            /*for (int i = indOfNewLexeme; i < hashDictionary.Length; i++)
                if (sentance.Substring(indOfNewLexeme, wordDict[i].Length).GetHashCode() == hashDictionary[i])
                {
                    lexmeIndArr[counter++] = hashDictionary[i];
                }*/

            for (int i = 0; i < hashDictionary.Length; i++)
            {
                if (sentance.Length - wordDict[i].Length - indOfNewLexeme >= 0)
                    if (sentance.Substring(indOfNewLexeme, wordDict[i].Length).GetHashCode() == hashDictionary[i])
                    {
                        lexmeIndArr[counter++] = i;
                    }
            }

            if (counter == 0) 
                return null;

            int[] result = new int[counter];
            Array.Copy(lexmeIndArr, result, counter);
            return result;
        }
        public static int[] GetHashDictionaryArr(IList<string> wordDict)
        {
            int[] hashArr = new int[wordDict.Count];

            for(int i = 0; i < wordDict.Count; i++)
            {
                hashArr[i] = wordDict[i].GetHashCode();
            }
            return hashArr;
        }
    }
}
