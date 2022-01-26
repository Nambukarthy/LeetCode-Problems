using System;
/* ----- Description ----- */
/*
Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.

The overall run time complexity should be O(log (m+n)).

Example 1:
Input: nums1 = [1,3], nums2 = [2]
Output: 2.00000
Explanation: merged array = [1,2,3] and median is 2.

Example 2:
Input: nums1 = [1,2], nums2 = [3,4]
Output: 2.50000
Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.

Constraints:
nums1.length == m
nums2.length == n
0 <= m <= 1000
0 <= n <= 1000
1 <= m + n <= 2000
-106 <= nums1[i], nums2[i] <= 106
 */

namespace MedianOfTwoSortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[] { 1, 3 };
            int[] array2 = new int[] { 2 };

            Console.WriteLine(MergeSort(array1, array2));
            Console.ReadKey();
        }

        static double MergeSort(int[] nums1, int[] nums2)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            int[] mergeArray = new int[nums1.Length + nums2.Length];

            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] < nums2[j])
                {
                    mergeArray[k] = nums1[i];
                    i++;
                }
                else
                {
                    mergeArray[k] = nums2[j];
                    j++;
                }
                k++;
            }

            while (i < nums1.Length)
            {
                mergeArray[k] = nums1[i];
                i++;
                k++;
            }

            while (j < nums2.Length)
            {
                mergeArray[k] = nums2[j];
                j++;
                k++;
            }

            if (mergeArray.Length % 2 != 0)
            {
                var medianIndex = mergeArray.Length / 2;
                return Convert.ToDouble(mergeArray[medianIndex]);
            }
            else
            {
                var medianIndex = mergeArray.Length / 2;
                return (Convert.ToDouble(mergeArray[medianIndex]) + Convert.ToDouble(mergeArray[medianIndex - 1])) / 2;               
            }
        }
    }
}
