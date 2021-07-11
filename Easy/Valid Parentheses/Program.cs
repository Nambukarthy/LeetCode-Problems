using System;
using System.Collections.Generic;
using System.Linq;

/* ----- Description ----- */
/*
Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:

Open brackets must be closed by the same type of brackets.
Open brackets must be closed in the correct order.
 
Example 1:
Input: s = "()"
Output: true

Example 2:
Input: s = "()[]{}"
Output: true

Example 3:
Input: s = "(]"
Output: false

Example 4:
Input: s = "([)]"
Output: false

Example 5:
Input: s = "{[]}"
Output: true 

Constraints:
1 <= s.length <= 104
s consists of parentheses only '()[]{}'.
*/

namespace ValidParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsValid("()"));
            Console.ReadLine();
        }

        static bool IsValid(string s)
        {
            Dictionary<char, char> bracketTypes = new Dictionary<char, char>();
            bracketTypes.Add('(', ')');
            bracketTypes.Add('[', ']');
            bracketTypes.Add('{', '}');

            if (s.Length % 2 != 0) { return false; }

            Stack<char> openBrackets = new Stack<char>();

            foreach (var ch in s)
            {
                //Open bracket
                if (bracketTypes.ContainsKey(ch))
                {
                    openBrackets.Push(bracketTypes[ch]);
                }

                //Close bracket
                else if (bracketTypes.ContainsValue(ch))
                {
                    if (!openBrackets.Any()) return false;

                    if (ch != openBrackets.Pop())
                    {
                        return false;
                    }
                }
            }

            return (openBrackets.Count == 0);
        }
    }
}
