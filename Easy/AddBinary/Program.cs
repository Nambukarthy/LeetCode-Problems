using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* ----- Description ----- */
/*
Given two binary strings a and b, return their sum as a binary string.

Example 1:
Input: a = "11", b = "1"
Output: "100"

Example 2:
Input: a = "1010", b = "1011"
Output: "10101"

Constraints:
1 <= a.length, b.length <= 104
a and b consist only of '0' or '1' characters.
Each string does not contain leading zeros except for the zero itself.
*/

namespace AddBinary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(addBinary("1", "111"));
            Console.ReadKey();
        }


        //Worst Possible Solution.
        /// <summary>
        /// Solution One
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /*
        static string addBinary(string a, string b)
        {
           var aArray =  a.ToCharArray().Reverse().ToList();
           var bArray = b.ToCharArray().Reverse().ToList();

           int count = 0;
        
           string result = string.Empty;
           bool isCarryForward = false;

           while (count < aArray.Count || count < bArray.Count)
           {
               if (count < aArray.Count && count < bArray.Count)
               {
                   if (aArray[count] == '0' && bArray[count] == '0')
                   {
                       if (isCarryForward)
                       {
                           result = "1" + result;
                           isCarryForward = false;
                       }
                       else
                           result = "0" + result;
                   }
                   else if (aArray[count] == '1' && bArray[count] == '0')
                   {
                       if (isCarryForward)
                       {
                           result = "0" + result;
                           isCarryForward = true;
                       }
                       else
                         result = "1" + result;
                   }
                   else if (aArray[count] == '0' && bArray[count] == '1')
                   {
                       if (isCarryForward)
                       {
                           result = "0" + result;
                           isCarryForward = true;
                       }
                       else
                           result = "1" + result;
                   }
                   else if (aArray[count] == '1' && bArray[count] == '1')
                   {
                       if (isCarryForward)
                       {
                           result = "1" + result;
                       }
                       else
                       {
                           result = "0" + result;
                       }
                       
                       isCarryForward = true;
                   }
               }

               if (count < aArray.Count && count >= bArray.Count)
               {
                   if (aArray[count] == '1' && isCarryForward)
                   {
                       result = "0" + result;
                   }
                   else if (aArray[count] == '0' && isCarryForward)
                   {
                       result = "1" + result;
                       isCarryForward = false;
                   }
                   else
                   {
                       result = aArray[count] + result;
                   }
               }

               if (count >= aArray.Count && count < bArray.Count)
               {
                   if (bArray[count] == '1' && isCarryForward)
                   {
                       result = "0" + result;
                   }
                   else if (bArray[count] == '0' && isCarryForward)
                   {
                       result = "1" + result;
                       isCarryForward = false;
                   }
                   else
                   {
                       result = bArray[count] + result;
                   }
               }

               count++;
           }

           if (isCarryForward)
           {
               result = "1" + result;
           }

           return result;
        }
        */


        //Little better but still not good solution, have plenty of room to optimize. 
        //TODO: Need to come up with better logic. 
        /// <summary>
        /// Solution Two
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static string addBinary(string a, string b)
        {
            string result = string.Empty;
            bool isCarryForward = false;

            int count = (a.Length >= b.Length ? a.Length : b.Length) - 1;
            int aCount = a.Length - 1;
            int bCount = b.Length - 1;

            for (int i = count; i >= 0; i--)
            {
                if (aCount >= 0 && bCount >= 0)
                {
                    if (a[aCount] == b[bCount])
                    {
                        if (isCarryForward)
                        {
                            result = "1" + result;
                            isCarryForward = false;
                        }
                        else
                        {
                            result = "0" + result;
                        }

                        isCarryForward = a[aCount] == '1';
                    }

                    else if (a[aCount] != b[bCount])
                    {
                        if (isCarryForward)
                        {
                            result = "0" + result;
                            isCarryForward = true;
                        }
                        else
                            result = "1" + result;
                    }
                }

                if (aCount >= 0 && bCount < 0)
                {
                    if (a[aCount] == '1' && isCarryForward)
                    {
                        result = "0" + result;
                    }
                    else if (a[aCount] == '0' && isCarryForward)
                    {
                        result = "1" + result;
                        isCarryForward = false;
                    }
                    else
                    {
                        result = a[aCount] + result;
                    }
                }

                else if (bCount >= 0 && aCount < 0)
                {
                    if (b[bCount] == '1' && isCarryForward)
                    {
                        result = "0" + result;
                    }
                    else if (b[bCount] == '0' && isCarryForward)
                    {
                        result = "1" + result;
                        isCarryForward = false;
                    }
                    else
                    {
                        result = b[bCount] + result;
                    }
                }

                count--;
                aCount--;
                bCount--;
            }

            if (isCarryForward)
            {
                result = "1" + result;
            }

            return result;
        }
    }
}
