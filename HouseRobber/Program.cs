using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRobber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 1 };
            Console.WriteLine(FindMaxSum(nums).ToString());
            Console.ReadLine();
        }
        public static int Rob(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            if (nums.Length == 2) return nums[0] >= nums[1] ? nums[0] : nums[1];

            int[] sum = new int[3];
            for(int i = 0; i + 1 <= nums.Length - 1; i++) // ідеологія sum[1] >= sum[2] >= sum[0]
            {
                sum[2] = sum[1];
                sum[1] = nums[i];
                for (int n = 0; n < nums.Length - 2; n++)
                {
                    sum[0] = sum[1];
                    sum[1] = nums[i];
                    for (int j = i + 2 + n; j < nums.Length; j += 2)
                    {
                        sum[1] += nums[j];
                    }
                    if (sum[1] < sum[0]) sum[1] = sum[0]; // sum[1] завжди більше навіть на виході з n-ого циклу
                }
                if (sum[2] > sum[1]) sum[1] = sum[2];
            }

            return sum[1];
        }

        public static int FindMaxSum(int[] arr)
        {
            int incl = arr[0]; // Sum including the previous element
            int excl = 0;      // Sum excluding the previous element
            int excl_new;      // Temporary variable to store new excl

            for (int i = 1; i < arr.Length; i++)
            {
                // Current max excluding i
                excl_new = (incl > excl) ? incl : excl;

                // Current max including i
                incl = excl + arr[i];
                excl = excl_new;
            }

            // Return max of incl and excl
            return ((incl > excl) ? incl : excl);
        }
        
    }
}
