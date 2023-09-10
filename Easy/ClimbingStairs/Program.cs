using System;
using System.ComponentModel.Design;
using System.Data.SqlTypes;
using System.Net;
/* ----- Description ----- */
/*
You are climbing a staircase. It takes n steps to reach the top.
Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

Example 1:
Input: n = 2
Output: 2
Explanation: There are two ways to climb to the top.
1. 1 step + 1 step
2. 2 steps

Example 2:
Input: n = 3
Output: 3
Explanation: There are three ways to climb to the top.
1. 1 step + 1 step + 1 step
2. 1 step + 2 steps
3. 2 steps + 1 step

1 <= n <= 45
*/
namespace ClimbingStairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var output = ClimbStairs(Convert.ToInt16(input));
            Console.WriteLine(output);
            Console.ReadLine();
        }

        static int ClimbStairs(int n)
        {
            int one = 1;
            int two = 2;
            int result = 2;

            if (n == 1) { return one; }
            if (n == 2) { return two; }

            for (int i = 3; i <= n; i++) 
            {
                result = one + two;
                one = two;
                two = result;
            }

            return result;
        }
    }
}


/* Examples.
 *
 * Input - 2
 * 11
 * 2
 * 
 * Input - 3
 * 111
 * 12
 * 21
 * 
 * Input - 4
 * 1111
 * 22
 * 211
 * 121
 * 112
 * 
 * Input - 5
 * 11111
 * 221
 * 1211
 * 1121
 * 1112
 * 2111
 * 212
 * 122
 * 
 * Input - 6
 * 111111
 * 222
 * 21111
 * 12111
 * 11211
 * 11121
 * 11112
 * 2211
 * 2121
 * 2112
 * 1221
 * 1212
 * 1122
 */
