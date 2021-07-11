using System;

/* ----- Description ----- */
/*
Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.

Assume the environment does not allow you to store 64-bit integers (signed or unsigned).

Example 1:
Input: x = 123
Output: 321

Example 2:
Input: x = -123
Output: -321

Example 3:
Input: x = 120
Output: 21

Example 4:
Input: x = 0
Output: 0
 
Constraints:
-231 <= x <= 231 - 1
*/

namespace ReverseInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Reverse(123));
            Console.ReadLine();
        }

        static int Reverse(int x)
        {

            int y = 0;
            bool isNegativeValue = false;

            if (x < 0)
            {
                isNegativeValue = true;
                x = x * -1;
            }

            string strOutput = "";
            var strInput = Convert.ToString(x);

            var arrInput = strInput.ToCharArray();

            for (int i = arrInput.Length - 1; i >= 0; i--)
            {
                strOutput = strOutput + arrInput[i];
            }


            Int32.TryParse(strOutput, out y);

            if (isNegativeValue)
            {
                y = y * -1;
            }

            return y;
        }
    }
}
