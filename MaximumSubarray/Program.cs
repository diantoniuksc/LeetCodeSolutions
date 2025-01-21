using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumSubarray
{
    internal class Program
    {
        /// <summary>
        /// https://leetcode.com/problems/maximum-subarray/description/
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] nums = { -1, -5, -8, -9 };
            Console.WriteLine(MaxSubArraySum(nums));
            Console.ReadLine();
        }

        //Brute-force
        public static int MaxSubArray(int[] nums)
        {
            int curSum, maxSum = nums[0];

            for(int i = 0; i < nums.Length; i++)
            {
                curSum = nums[i];
                if (curSum > maxSum)
                    maxSum = curSum;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    curSum += nums[j];
                    if (curSum > maxSum)
                        maxSum = curSum;
                }                
            }
            return maxSum;
        }

        //Kadane’s Algorithm
        public static int MaxSubArraySum(int[] nums)
        {
            int size = nums.Length;
            int max_so_far = int.MinValue, max_ending_here = 0;

            for (int i = 0; i < size; i++)
            {
                max_ending_here = max_ending_here + nums[i];

                if (max_so_far < max_ending_here)
                    max_so_far = max_ending_here;

                if (max_ending_here < 0)
                    max_ending_here = 0;
            }

            return max_so_far;
        }
    }
}
