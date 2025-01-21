// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Globalization;

Console.WriteLine("Hello, World!");
Console.WriteLine(Solution.RemoveElement(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2).ToString());
Console.ReadKey();
public class Solution
{
    /*https://leetcode.com/problems/remove-element/submissions/1516137523/?envType=study-plan-v2&envId=top-interview-150*/
    public static int RemoveElement(int[] nums, int val)
    {
        int k = 0;
        for (int i = 0; i < nums.Length - k; i++)
        {
            if (nums[i] == val)
            {
                if (i == nums.Length - 1 - k)
                {
                    k++;
                    break;
                }
                k += RemoveByIndexAndGetAddToSkip(i, nums, val, nums.Length - k);
            }
        }

        return nums.Length - k;
    }
    public static int RemoveByIndexAndGetAddToSkip(int indToDelete, int[] array, int valToFind, int realArrayLength)
    {
        int amountToSkip = 1;

        while (indToDelete + amountToSkip < realArrayLength)
        {
            if (array[indToDelete + amountToSkip] == valToFind)
                amountToSkip++;

            else
            break;
        }

        for (int i = indToDelete; i < realArrayLength - amountToSkip; i++)
        {
            array[i] = array[i + amountToSkip];
        }

        return amountToSkip;
    }
}