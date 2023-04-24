using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* ----- Description ----- */
/*
Given a string s, return the longest palindromic substring in s.

Example 1:
Input: s = "babad"
Output: "bab"
Explanation: "aba" is also a valid answer.

Example 2:
Input: s = "cbbd"
Output: "bb"
 
Constraints:
1 <= s.length <= 1000
s consist of only digits and English letters.
*/

namespace LongestPalindromicSubstring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(longestPalindrome("bacabab"));
            Console.ReadKey();
        }

        static string longestPalindrome(string input)
        {
            if (IsPalindrome(input)) return input;

            //List<Palindrome> pal = new List<Palindrome>();
           
            int maxPalLength = 0;
            string pal = string.Empty;
            int inputLength = input.Length;
           
            for (int i = 1; i < inputLength; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    var str = input.Substring(j, (i-j)+1);

                    if (IsPalindrome(str))
                    {
                        if (str.Length > maxPalLength)
                        {
                            maxPalLength = str.Length;
                            pal = str;
                        }
                    }
                    //pal.Add(new Palindrome() { PalindromeLength = str.Length, PalindromeString = str });

                    if ((inputLength / 2) <= maxPalLength)
                        goto LoopEnd;
                }
            }

            LoopEnd:

            //var result = pal.OrderByDescending(x => x.PalindromeLength).FirstOrDefault();
            //if (result == null) return input[0].ToString();
            //return result.PalindromeString;

            if (string.IsNullOrEmpty(pal)) return input.Substring(0, 1);
            return pal;
        }

        static bool IsPalindrome(string input)
        {
            input = input.ToLower();
            string reversedInput = string.Empty;
            for (int i = input.Length; i > 0; i--)
            {
                reversedInput += input[i-1];
            }
            return reversedInput == input;
        }
    }

    public class Palindrome
    {
        public int PalindromeLength  { get; set; }
        public string PalindromeString { get; set; }
    }
}
