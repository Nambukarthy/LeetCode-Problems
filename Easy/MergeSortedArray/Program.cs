using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* ----- Description ----- */
/*
   You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, representing the number of elements in nums1 and nums2 respectively.
   
   Merge nums1 and nums2 into a single array sorted in non-decreasing order.
   
   The final sorted array should not be returned by the function, but instead be stored inside the array nums1. To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged, and the last n elements are set to 0 and should be ignored. nums2 has a length of n.
          
   Example 1:   
   Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
   Output: [1,2,2,3,5,6]
   Explanation: The arrays we are merging are [1,2,3] and [2,5,6].
   The result of the merge is [1,2,2,3,5,6] with the underlined elements coming from nums1.

   Example 2:   
   Input: nums1 = [1], m = 1, nums2 = [], n = 0
   Output: [1]
   Explanation: The arrays we are merging are [1] and [].
   The result of the merge is [1].

   Example 3:   
   Input: nums1 = [0], m = 0, nums2 = [1], n = 1
   Output: [1]

   Explanation: The arrays we are merging are [] and [1].
   The result of the merge is [1].
   Note that because m = 0, there are no elements in nums1. The 0 is only there to ensure the merge result can fit in nums1.
       
   Constraints:   
   nums1.length == m + n
   nums2.length == n
   0 <= m, n <= 200
   1 <= m + n <= 200
   -109 <= nums1[i], nums2[j] <= 109
*/


namespace MergeSortedArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Example 1
            //int[] nums1 = new int[6] { 1, 2, 3, 0, 0, 0 };
            //int[] nums2 = new int[3] { 2, 5, 6 };

            //Example 2
            //int[] nums1 = new int[1] { 1 };
            //int[] nums2 = new int[0] {  };

            //Example 3
            //int[] nums1 = new int[1] { 0 };
            //int[] nums2 = new int[1] { 1 };

            //Example 4
            //int[] nums1 = new int[2] { 2,0 };
            //int[] nums2 = new int[1] { 1 };

            //Example 5
            //int[] nums1 = new int[9] {-1,0,0,3,3,3,0,0,0 };
            //int[] nums2 = new int[3] { 1,2,2 };

            //Example 6
            int[] nums1 = new int[100]{-50,-48,-47,-47,-46,-44,-43,-43,-41,-39,-38,-37,-37,-37,-33,-33,-32,-31,-29,-29,-27,-26,-26,-26,-25,-25,-24,-24,-23,-22,-22,-22,-18,-17,-17,-14,-14,-11,-11,-11,-6,-5,-5,-5,-5,-4,-1,0,2,2,2,2,5,6,7,7,9,10,13,13,14,14,18,21,21,21,22,24,24,24,25,26,26,29,29,29,30,30,31,31,32,33,34,34,34,35,38,40,41,42,43,44,44,46,46,47,47,48,49,49};
            int[] nums2 = new int[0] { };

            Merge(nums1, (nums1.Length - nums2.Length), nums2 , nums2.Length);
            Console.ReadLine();
        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {

            #region  Solution with Selection-Sort Algorithm
            /*
               //-- Performance of this solution.
               //Runtime: 108 ms, faster than 26.40% of C# online submissions for Merge Sorted Array.
               //Memory Usage: 46.2 MB, less than 12.11% of C# online submissions for Merge Sorted Array.
             
                int count = 0;

                for (int i = 0; i < nums1.Length; i++)
                {
                    ++count;

                    if (count > m)
                    {
                        for (int j = 0; j < nums2.Length; j++)
                        {
                            nums1[i + j] = nums2[j];
                        }

                        break;
                    }
                }

                PrintArray("Input", nums1);

                //Selection sort algorithm 
                for (int i = 0; i < nums1.Length; i++)
                {
                    for (int j = i; j < nums1.Length; j++)
                    {
                        if (nums1[j] < nums1[i])
                        {
                            var temp = nums1[j];
                            nums1[j] = nums1[i];
                            nums1[i] = temp;
                        }
                    }
                }
              
             PrintArray("Output", nums1);*/

            #endregion

            #region Solution with Merge-Sort Algorithm

           /*
              Runtime: 102 ms, faster than 55.32% of C# online submissions for Merge Sorted Array.
              Memory Usage: 46.3 MB, less than 10.09% of C# online submissions for Merge Sorted Array.
            */

            var num3 =MergeSort(nums1, nums2);
            nums1 = num3;

            for (int i = 0; i < num3.Length; i++)
            {
                nums1[i] = num3[i];
            }

            PrintArray("Output", nums1);

            #endregion
        }


        private static int[] MergeSort(int[] num1, int[] num2)
        {
            int[] num3 = new int[num1.Length];
            int i = 0;
            int j = 0;
            int k = 0;

            while (k < num1.Length && j < num2.Length)
            {
                if (i >= (num1.Length - num2.Length)  || num1.Length ==0 || num2.Length ==0) break;

                if (num1[i] <= num2[j])
                {
                    num3[k] = num1[i];
                    i++;
                    k++;
                }
                else if (num1[i] > num2[j])
                {
                    num3[k] = num2[j];
                    j++;
                    k++;
                }
            }

            while (i < (num1.Length - num2.Length))
            {
                if (i >= (num1.Length - num2.Length) || num1.Length == 0) break;

                num3[k] = num1[i];
                i++;
                k++;
            }

            while (j < num2.Length)
            {
                if (num2.Length == 0) break;

                num3[k] = num2[j];
                j++;
                k++;
            }

            return num3;
        }

        private static void PrintArray(string title, int[] array)
        {
            Console.WriteLine(title);

            foreach (var item in array)
                Console.WriteLine(item);
        }
    }
}
