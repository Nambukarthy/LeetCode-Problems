using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* ----- Description ----- */
/*
Given a string s, find the length of the longest substring without repeating characters.

Example 1:
Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.

Example 2:
Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.

Example 3:
Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.

Example 4:
Input: s = ""
Output: 0 

Constraints:
0 <= s.length <= 5 * 104
s consists of English letters, digits, symbols and spaces.
 */

namespace LongestSubstringWithoutRepeatingCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LengthOfLongestSubstring("abcabcbb"));          
            Console.ReadLine();
        }

        static int LengthOfLongestSubstring(string s)
        {
            Stack<char> stk = new Stack<char>();
            int output = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (output >= (s.Length - i)) break;

                for (int j = i; j < s.Length; j++)
                {
                    if (stk.Contains(s[j]))
                    {
                        output = output < stk.Count() ? stk.Count : output;
                        stk.Clear();
                        break;
                    }
                    stk.Push(s[j]);
                }
            }

            return output < stk.Count() ? stk.Count : output;

        }
    }
}
