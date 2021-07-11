using System;

/* ----- Description ----- */
/*
Write a function to find the longest common prefix string amongst an array of strings.

If there is no common prefix, return an empty string "".

Example 1:
Input: strs = ["flower","flow","flight"]
Output: "fl"

Example 2:
Input: strs = ["dog","racecar","car"]
Output: ""
Explanation: There is no common prefix among the input strings.
 
Constraints:
1 <= strs.length <= 200
0 <= strs[i].length <= 200
strs[i] consists of only lower-case English letters.
 */

namespace LongestCommonPrefix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LongestCommonPrefix(new string[] { "flower", "flow", "flight" }));
            Console.ReadLine();
        }

        static string LongestCommonPrefix(string[] strs)
        {
            string previousItemPrefix = string.Empty;
            string currentItemPrefix = string.Empty;
            string result = string.Empty;

            int minLength = 0;
            foreach (var item in strs)
            {
                if (item == string.Empty)
                {
                    minLength = 0;
                    break;
                }

                if (minLength == 0) minLength = item.Length;

                if (item.Length < minLength)
                {
                    minLength = item.Length;
                }
            }

            bool isCharMatched = false;
            for (int i = 1; i <= minLength; i++)
            {
                previousItemPrefix = string.Empty;
                currentItemPrefix = string.Empty;
                foreach (var item in strs)
                {
                    if (previousItemPrefix == string.Empty)
                    {
                        previousItemPrefix = currentItemPrefix = item.Substring(0, i);
                        isCharMatched = true;
                    }
                    else
                    {
                        currentItemPrefix = item.Substring(0, i);

                        if (previousItemPrefix != currentItemPrefix)
                        {
                            isCharMatched = false;
                            break;
                        }
                        else
                        {
                            isCharMatched = true;
                        }

                        previousItemPrefix = item.Substring(0, i);
                    }
                }

                if (isCharMatched)
                {
                    result = currentItemPrefix;
                }
            }

            return result;
        }
    }
}
