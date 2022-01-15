using System;
/* ----- Description ----- */
/*
Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.
A subarray is a contiguous part of an array.

Example 1:
Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
Output: 6
Explanation: [4,-1,2,1] has the largest sum = 6.

Example 2:
Input: nums = [1]
Output: 1

Example 3:
Input: nums = [5,4,-1,7,8]
Output: 23

Constraints:
* 1 <= nums.length <= 105
* -104 <= nums[i] <= 104

Follow up: If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle. 
 */
namespace MaximumSubarray
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] nums = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            //int[] nums = new int[] { 1 };
            //int[] nums = new int[] { 5, 4, -1, 7, 8 };
            //int[] nums = new int[] { -1, 0, -2 };  
            //int[] nums = new int[] { -2,-1 };
            int[] nums = new int[] { 4, 3, 1, -2, 9 };
            //var result = NestedForLoopSolution(nums);
            var result = ForLoopSolution(nums);
            Console.WriteLine(result);
            Console.ReadKey();           
        }

        /// <summary>
        /// Big O(n) Square.
        /// </summary>       
        static int NestedForLoopSolution(int[] inputArray)
        {
            int result = inputArray[0];
            for (int i = 0; i < inputArray.Length; i++)
            {
                int sum = 0;
                int max = inputArray[i];
                for (int j = i; j < inputArray.Length; j++)
                {
                    sum = sum + inputArray[j];
                    if (sum > max)
                    {
                        max = sum;
                    }
                }

                if (max > result)
                    result = max;
            }

            return result;
        }

        static int ForLoopSolution(int[] inputArray)
        {           
            int max = inputArray[0];
            int sum = 0;

            for (int i = 0; i < inputArray.Length; i++)
            {
                sum = sum + inputArray[i];

                if (max < sum)
                    max = sum;

                if (sum < 0)
                    sum = 0;
            }

            return max;
        }       
    }
}
