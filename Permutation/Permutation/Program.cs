using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Permutation.Program;

namespace Permutation
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] array = { "foo", "bar" };
            string word = "barfoothefoobarman";

            /*var res = GetPermutations(array);
            int count = 0;
            foreach(var arr in res)
            {
                foreach (var x in arr)
                {
                    Console.Write($"{x},");                    
                }
                Console.WriteLine();
                count++;
            }
            Console.WriteLine(count);
            Console.WriteLine();

            var indexesArr = FindSubstringWithHelper(word, array);
            foreach (var index in indexesArr)
            {
                Console.Write($"{index}, ");
            }
            Console.ReadLine();*/
            //PermutationGenerator<string>.FindSubstring(word, array);
        }
        /*public static IList<int> FindSubstringWithHelper(string s, string[] words)
        {
            var permutatedWords = GetPermutations(words);
            List<int> indexesOfWords = new List<int>();
            for(int i = 0; i < permutatedWords.Count; i++)
            {
                string permutation = "";
                foreach(string word in permutatedWords[i])
                {
                    permutation += word; 
                }
                int index = -1, deletedCount = 0;
                string temp = s;
                while((index = temp.IndexOf(permutation)) != -1)
                {
                    if(!indexesOfWords.Contains(index + deletedCount)) indexesOfWords.Add(index + deletedCount);
                    temp = temp.Remove(0, 1);
                    deletedCount++;
                }
            }
            return indexesOfWords;
        }


        public static List<List<T>> GetPermutations<T>(T[] array)
        {
           var permutations = new List<List<T>>();

            PermutationsHelper(array, 0, array.Length - 1, permutations);
            return permutations;
            
        }

        public static void PermutationsHelper<T>(T[] array, int currendDepth, int maxDepth, List<List<T>> resultLst)
        {
            if (currendDepth == maxDepth) resultLst.Add(new List<T>(array));
            else
            {
                for(int i = currendDepth; i <= maxDepth; i++)
                {
                    if (i != currendDepth) Swap(ref array[i], ref array[currendDepth]);
                    PermutationsHelper(array, currendDepth + 1, maxDepth, resultLst);
                    if (i != currendDepth) Swap(ref array[i], ref array[currendDepth]);
                }
            }
        }
        public static void Swap<T>(ref T a, ref T b)
        {
            (a, b) = (b, a);
        }
        */

        /*public class PermutationGenerator<T> where T : IComparable<T>
        {
            // Generates the next permutation in-place, returns false if there is no next permutation.
            public static bool NextPermutation<T>(T[] array) where T : IComparable<T>
            {
                // Find non-increasing suffix
                int i = array.Length - 1;
                while (i > 0 && array[i - 1].CompareTo(array[i]) >= 0)
                    i--;
                if (i <= 0)
                {
                    Array.Reverse(array); // This is the new line to reverse the array when it's the last permutation.
                    return false;
                }

                // Find successor to pivot
                int j = array.Length - 1;
                while (array[j].CompareTo(array[i - 1]) <= 0)
                    j--;
                Swap(ref array[i - 1], ref array[j]);

                // Reverse suffix
                j = array.Length - 1;
                while (i < j)
                {
                    Swap(ref array[i], ref array[j]);
                    i++;
                    j--;
                }
                return true;
            }
            public static void Swap<T>(ref T a, ref T b)
            {
                T tmp = a;
                a = b;
                b = tmp;
            }
            public static IList<int> FindIndexes(string s, string[] words, ref List<int> indexesOfWords)
            {
                do
                {
                    string permutation = "";
                    foreach (string word in words)
                    {
                        permutation += word;
                    }
                    int index = -1, deletedCount = 0;
                    string temp = s;
                    while ((index = temp.IndexOf(permutation)) != -1)
                    {
                        if (!indexesOfWords.Contains(index + deletedCount)) indexesOfWords.Add(index + deletedCount);
                        temp = temp.Remove(0, 1);
                        deletedCount++;
                    }
                }
                while (NextPermutation(words));
                return indexesOfWords;
            }
            public static void FindSubstring(string s, string[] words)
            {
                Array.Sort(words);
                List<int> indexesOfWords = new List<int>();

                FindIndexes(s, words, ref indexesOfWords);

                foreach (var index in indexesOfWords)
                {
                    Console.Write($"{index}, ");
                }
                Console.ReadLine();
            }
        }*/
        public class PermutationGenerator<T> where T : IComparable<T>
        {
            public static bool NextPermutation<T>(T[] array) where T : IComparable<T>
            {
                // Find non-increasing suffix
                int i = array.Length - 1;
                while (i > 0 && array[i - 1].CompareTo(array[i]) >= 0)
                    i--;
                if (i <= 0)
                {
                    Array.Reverse(array); // This is the new line to reverse the array when it's the last permutation.
                    return false;
                }

                // Find successor to pivot
                int j = array.Length - 1;
                while (array[j].CompareTo(array[i - 1]) <= 0)
                    j--;
                Swap(ref array[i - 1], ref array[j]);

                // Reverse suffix
                j = array.Length - 1;
                while (i < j)
                {
                    Swap(ref array[i], ref array[j]);
                    i++;
                    j--;
                }
                return true;
            }
            public static void Swap<T>(ref T a, ref T b)
            {
                T tmp = a;
                a = b;
                b = tmp;
            }
            public static IList<int> FindIndexes(string s, string[] words, ref List<int> indexesOfWords)
            {
                do
                {
                    string permutation = "";
                    foreach (string word in words)
                    {
                        permutation += word;
                    }
                    int index = -1, deletedCount = 0;
                    string temp = s;
                    while ((index = temp.IndexOf(permutation)) != -1)
                    {
                        if (!indexesOfWords.Contains(index + deletedCount)) indexesOfWords.Add(index + deletedCount);
                        temp = temp.Remove(0, 1);
                        deletedCount++;
                    }
                }
                while (NextPermutation(words));
                return indexesOfWords;
            }
            public IList<int> FindSubstring(string s, string[] words)
            {
                Array.Sort(words);
                List<int> indexesOfWords = new List<int>();

                FindIndexes(s, words, ref indexesOfWords);

                return indexesOfWords;
            }
        }
    }
}
