using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;

namespace CombinationSum2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] candidates = { 14, 6, 25, 9, 30, 20, 33, 34, 28, 30, 16, 12, 31, 9, 9, 12, 34, 16, 25, 32, 8, 7, 30, 12, 33, 20, 21, 29, 24, 17, 27, 34, 11, 17, 30, 6, 32, 21, 27, 17, 16, 8, 24 };
            int target = 27;

             IList<IList<int>> result = CombinationSum2(candidates, target);
            //PrintListOfLists(result);
            Console.WriteLine(result.Count);
            Console.ReadLine();
        }

        public static void PrintListOfLists(IList<IList<int>> lists)
        {
            foreach (List<int> list in lists)
            {
                Console.WriteLine();
                foreach (int value in list)
                {
                    Console.Write(value + " ");
                }
            }
        }

        public static Int64 CalculateAmountOfCombinaions(int[] array)
        {
            Int64 amount = 0;
            for(int i = 0; i < array.Length; i++)
            {
                amount += Factorial(array.Length) / (Factorial(array.Length - i) * Factorial(i));
            }
            return amount;
        }
        static long Factorial(int number)
        {
            Int64 factorial = 1;
            for(int i = 2; i <= number; i++)
            {
                factorial *= i;
            }
            return factorial;
        }

        /// <summary>
        /// https://leetcode.com/problems/combination-sum-ii/description/
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
           /* IList<IList<int>> result = new List<IList<int>>();
            candidates = FilterArray(candidates, target, result);

            for (int i = 2; i <= candidates.Length; i++)
            {
                IList<IList<int>> combinations = CombinationGenerator.GetCombinations<int>(candidates, i);

                for (int k = 0; k < combinations.Count; k++)
                {
                    int sum = 0;
                    for (int m = 0; m < combinations[k].Count; m++)
                    {
                        sum += combinations[k][m];
                    }
                    if (sum == target)
                        result.Add(combinations[k]);
                }

            }
            result = FilterCombinations(result);
            return result;*/

            List<IList<int>> result = new List<IList<int>>(candidates.Length);
            candidates = FilterArray(candidates, target, result);

            for (int i = 2; i <= candidates.Length; i++)
            {
                IList<IList<int>> combinations = CombinationGeneratorOptimised.GetCombinations(candidates, i, target);

                /*
                for (int k = 0; k < combinations.Count; k++)
                {
                    result.Add(combinations[k]);
                }
                */
                result.AddRange(combinations);
                
            }
            return result;
        }

        /// <summary>
        /// initial clanup of the candidates' array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="target"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static int[] FilterArray(int[] array, int target, IList<IList<int>> result)
        {
            var filteredArr = array.Where(x => x < target).ToArray<int>();

            if (array.Contains(target))
            {
                List<int> combination = new List<int>
                {
                    target
                };
                result.Add(combination);
            }

            return (int[])filteredArr;
        } 
    }


    public class CombinationGeneratorOptimised
    {
        public static IList<IList<int>> GetCombinations(int[] array, int m, int target)
        {
            var allCombinations = new List<IList<int>>();
            CombineOptimised(array, new int[m], allCombinations, 0, 0, m, target);
            return allCombinations;
        }

        public static void CombineOptimised(int[] array, int[] currentCombination, IList<IList<int>> combinations, int start, int index, int m, int target)
        {
            if (index == m)
            {
                int sum = 0;
                foreach (int value in currentCombination)
                {
                    sum += value;
                }
                if (sum != target)
                    return;
                List<int> combinationList = new List<int>(currentCombination);
                if (!CompareIListOfIListsAndList(combinations, combinationList))
                {
                    combinations.Add(combinationList);
                }
                return;
            }


            for (int i = start; i < array.Length + index - m + 1; i++)
            {
                currentCombination[index] = array[i];
                CombineOptimised(array, currentCombination, combinations, i + 1, index + 1, m, target);
            }
        }
        public static bool CompareTwoListsHashes(IList<int> list1, IList<int> list2)
        {
            HashSet<int> hashSet1 = new HashSet<int>(list1.Count);
            HashSet<int> hashSet2 = new HashSet<int>(list2.Count);

            foreach (int value in list1)
            {
                hashSet1.Add(value);
            }
            foreach(int value in list2)
            {
                hashSet2.Add(value);
            }
           
            return hashSet1.SetEquals(hashSet2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listOflists"></param>
        /// <param name="list"></param>
        /// <returns>true if contains, false otherwise</returns>
        static bool CompareIListOfIListsAndList(IList<IList<int>> listOflists, List<int> list)
        {
            bool containsCurrentList = false;
            for (int i = 0; i < listOflists.Count; i++)
            {
                if (list.Count == listOflists[i].Count)
                {
                    if (CompareTwoListsHashes(list, listOflists[i]))
                    {
                        containsCurrentList = true;
                        break;
                    }                    
                }
            }

            return containsCurrentList;
        }
    }









    public class CombinationGenerator
    {
        /// <summary>
        /// Get all possible combinations from array by m items
        /// </summary>
        /// <param name="array">Array to work in</param>
        /// <param name="m">To group by m items in array</param>
        /// <returns>All possible combinations by m items</returns>
        public static IList<IList<T>> GetCombinations<T>(T[] array, int m)
        {
            var allCombinations = new List<IList<T>>();
            Combine(array, new T[m], allCombinations, 0, 0, m);
            return allCombinations;
        }

        //  universal function for combinations
        private static void Combine<T>(T[] array, T[] currentCombination, IList<IList<T>> allCombinations, int start, int index, int m)
        {
            if (index == m)
            {
                allCombinations.Add(new List<T>(currentCombination));
                return;
            }

            for (int i = start; i < array.Length + index - m + 1; i++)
            {
                currentCombination[index] = array[i];
                Combine(array, currentCombination, allCombinations, i + 1, index + 1, m);
            }
        }
    }
}
