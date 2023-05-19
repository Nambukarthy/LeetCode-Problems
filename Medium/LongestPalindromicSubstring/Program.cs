using System;

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
            //Console.WriteLine(AddEvenApproach("civilwartestingwhetherthatnaptionoranynartionsoconceivedandsodedicatedcanlongendureWeareqmetonagreatbattlefiemldoftzhatwarWehavecometodedicpateaportionofthatfieldasafinalrestingplaceforthosewhoheregavetheirlivesthatthatnationmightliveItisaltogetherfangandproperthatweshoulddothisButinalargersensewecannotdedicatewecannotconsecratewecannothallowthisgroundThebravelmenlivinganddeadwhostruggledherehaveconsecrateditfaraboveourpoorponwertoaddordetractTgheworldadswfilllittlenotlenorlongrememberwhatwesayherebutitcanneverforgetwhattheydidhereItisforusthelivingrathertobededicatedheretotheulnfinishedworkwhichtheywhofoughtherehavethusfarsonoblyadvancedItisratherforustobeherededicatedtothegreattdafskremainingbeforeusthatfromthesehonoreddeadwetakeincreaseddevotiontothatcauseforwhichtheygavethelastpfullmeasureofdevotionthatweherehighlyresolvethatthesedeadshallnothavediedinvainthatthisnationunsderGodshallhaveanewbirthoffreedomandthatgovernmentofthepeoplebythepeopleforthepeopleshallnotperishfromtheearth"));
            Console.WriteLine(AddEvenApproach("nythiknambukarthyraveendran"));
            Console.ReadKey();
        }

        //Add Even approach. 
        static string AddEvenApproach(string s)
        {
            int length = s.Length;
            int longest = 0;
            string result = string.Empty;

            for (int i = 0; i < length; i++)
            {
                int oddGap = 1;
                int evenGap = 1;

                while ((i + oddGap) < length && (i - oddGap) >= 0 && (s[i + oddGap] == s[i - oddGap]))
                {
                    oddGap++;
                }
                oddGap--;

                while ((i + evenGap) < length && (i - (evenGap - 1)) >= 0 && (s[i + evenGap] == s[i - (evenGap - 1)]))
                {
                    evenGap++;
                }
                evenGap--;

                if (longest < ((oddGap * 2) + 1) || longest < (evenGap * 2))
                {
                    if (oddGap >= evenGap)
                    {
                        longest = (oddGap * 2) + 1;
                        result = s.Substring(i - oddGap, longest);
                    }
                    else
                    {
                        longest = evenGap * 2;
                        result = s.Substring((i + 1) - evenGap, longest);
                    }
                }
            }

            if (string.IsNullOrEmpty(result)) result = s[0].ToString();
            return result;
        }

        //Nestedloop - Solutions. 
        static string longestPalindrome(string input)
        {
            if (IsPalindrome(input)) return input;

            int maxPalLength = 0;
            string pal = string.Empty;
            int inputLength = input.Length;

            //Nested loop solution - 1 
            /*for (int i = 0; i < inputLength; i++)
            {
                for (int j = i + 1; j <= inputLength; j++)
                {
                    var str = input.Substring(i, j - i);

                    if (IsPalindrome(str))
                    {
                        if (str.Length > maxPalLength)
                        {
                            maxPalLength = str.Length;
                            pal = str;
                        }
                    }
                }
            }*/

            // Nested loop solution  2 
            for (int i = 1; i < inputLength; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    var str = input.Substring(j, (i - j) + 1);

                    if (IsPalindrome(str))
                    {
                        if (str.Length > maxPalLength)
                        {
                            maxPalLength = str.Length;
                            pal = str;
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(pal)) return input.Substring(0, 1);
            return pal;
        }       
        static bool IsPalindrome(string input)
        {
            input = input.ToLower();
            string reversedInput = string.Empty;
            for (int i = input.Length; i > 0; i--)
            {
                reversedInput += input[i - 1];
            }
            return reversedInput == input;
        }
    }
}
