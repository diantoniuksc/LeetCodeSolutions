Console.WriteLine("hello");
Console.ReadLine();
//int[] array = Solution.Merge(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3);
int[] array = Solution.Merge(new int[] { 1, 2, 9 }, 3, new int[] { 5, 6, 7 }, 3);

Solution.PrintEachElInArr(array);
Console.ReadLine();

public class Solution
{
    /*https://leetcode.com/problems/merge-sorted-array/description/?envType=study-plan-v2&envId=top-interview-150*/
    public static int[] Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int[] resultArr = new int[m + n];

        int counter = 0, i = 0, j = 0;
        while(i < m && j < n)
        {
            if (nums1[i] >= nums2[j])
            {
                resultArr[counter++] = nums2[j++];
            }
            else
            {
                resultArr[(counter++)] = nums1[i++];
            }
        }

        if (i < m)
            MitigateLengthDifference(m - i, n + m, i, nums1, resultArr);
        else if (j < n)
            MitigateLengthDifference(n - j, n + m, j, nums2, resultArr);

        nums1 = new int[m + n];
        Array.Copy(resultArr, nums1, resultArr.Length);
        return nums1;
    }

    public static void MitigateLengthDifference(int difference, int finArrayLength, int smallerLength, int[] biggerArray, int[] finalArray)
    {
        for (; difference != 0 ; difference--)
        {
            finalArray[finArrayLength - difference] = biggerArray[smallerLength++];
        }
    }
    
    public static void PrintEachElInArr(int[] arr)
    {
        foreach (int i in arr)
            Console.Write(i.ToString() + "; ");
    }
    
}
