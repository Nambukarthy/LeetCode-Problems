using System;
/* ----- Description ----- */
/*
Given a non-negative integer x, return the square root of x rounded down to the nearest integer. The returned integer should be non-negative as well.
You must not use any built-in exponent function or operator.
For example, do not use pow(x, 0.5) in c++ or x ** 0.5 in python.
 
Example 1:
Input: x = 4
Output: 2
Explanation: The square root of 4 is 2, so we return 2.

Example 2:
Input: x = 8
Output: 2
Explanation: The square root of 8 is 2.82842..., and since we round it down to the nearest integer, 2 is returned.

Constraints:
0 <= x <= 231 - 1
*/
namespace Sqrt_x_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var givenValue = Console.ReadLine();
            if (!int.TryParse(givenValue, out var input)) { Console.WriteLine("Enter only integer value"); Console.ReadLine(); return; }
            Console.WriteLine(string.Format("Square root of {0} = ", input) + MySqrt(input));

            Console.ReadLine();          
        }


        //TODO: Need to give a better solution. Should use binary search technique. 
        static int MySqrt(int x)
        {
            if (x == 0) return 0;
            if (x <= 3) return 1;

            for (long i = 2; i < x; i++)
            {
                if ((i * i) < x) continue;
                else if ((i * i) == x) return Convert.ToInt32(i);
                else
                    return Convert.ToInt32(i - 1);
            }
            return 0;
        }    
    }
}
