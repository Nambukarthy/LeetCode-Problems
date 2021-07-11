using System;

/* ----- Description ----- */
/*
Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

Symbol       Value
I             1
V             5
X             10
L             50
C             100
D             500
M             1000
For example, 2 is written as II in Roman numeral, just two one's added together. 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.

Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:

I can be placed before V (5) and X (10) to make 4 and 9. 
X can be placed before L (50) and C (100) to make 40 and 90. 
C can be placed before D (500) and M (1000) to make 400 and 900.
Given a roman numeral, convert it to an integer.

Example 1:
Input: s = "III"
Output: 3

Example 2:
Input: s = "IV"
Output: 4

Example 3:
Input: s = "IX"
Output: 9

Example 4:
Input: s = "LVIII"
Output: 58
Explanation: L = 50, V= 5, III = 3.

Example 5:
Input: s = "MCMXCIV"
Output: 1994
Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.

Constraints:
1 <= s.length <= 15
s contains only the characters ('I', 'V', 'X', 'L', 'C', 'D', 'M').
It is guaranteed that s is a valid roman numeral in the range [1, 3999].
 */
namespace Roman_To_Integer
{
    class Program
    {
        static int currentValue = 0;
        static int previous = 0;
        static int result = 0;
        static bool isSubtract = false;

        static void Main(string[] args)
        {
            Console.WriteLine(ConvertRomanToInt("MMMDCCCXLVII"));
            Console.ReadLine();
        }

        static int ConvertRomanToInt(string s)
        {
            var inputArray = s.ToCharArray();

            foreach (var item in inputArray)
            {                
                switch (item)
                {
                    case 'I':
                        {
                            CalculateResult(1);
                            break;
                        }
                    case 'V':
                        {
                            CalculateResult(5);
                            break;
                        }
                    case 'X':
                        {
                            CalculateResult(10);
                            break;
                        }
                    case 'L':
                        {
                            CalculateResult(50);
                            break;
                        }
                    case 'C':
                        {
                            CalculateResult(100);
                            break;
                        }
                    case 'D':
                        {
                            CalculateResult(500);
                            break;
                        }
                    case 'M':
                        {
                            CalculateResult(1000);
                            break;
                        }
                }
            }

            return result;
        }

        static void CalculateResult(int CurrentItemValue)
        {
            currentValue = CurrentItemValue;
            isSubtract = previous < currentValue;

            result += currentValue;

            if (isSubtract)
            {                              
                result = result - (previous + previous);
            }            

            previous = CurrentItemValue;
        }

    }
}
