using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            //Console.WriteLine(IterativeBinarySearch(inputArray, 100));
            Console.WriteLine(RecursiveBinarySearch(inputArray, 100, 0, inputArray.Length));            
            Console.ReadKey();
        }

        /// <summary>
        /// Iterative solution.
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="searchItem"></param>
        /// <returns></returns>
        static int IterativeBinarySearch(int[] inputArray, int searchItem)
        {
            int midIndex = inputArray.Length / 2;
            int low = 0;
            int heigh = inputArray.Length;

            while (low < heigh)
            {
                if (inputArray[midIndex] > searchItem)
                {
                    heigh = midIndex;
                }
                else if (inputArray[midIndex] < searchItem)
                {
                    low = midIndex;
                }
                else
                {
                    return midIndex;
                }
                midIndex = (low + heigh) / 2;
            }

            return -1;
        }

        /// <summary>
        /// Recursive solution.
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="searchItem"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        static int RecursiveBinarySearch(int[] inputArray, int searchItem, int low, int high)
        {
            if (low > high) return -1;

            int midIndex;

            midIndex = (low + high) / 2;

            if (searchItem == inputArray[midIndex])
                return midIndex;

            else if (searchItem > inputArray[midIndex])
                return RecursiveBinarySearch(inputArray, searchItem, midIndex, high);

            else 
                return RecursiveBinarySearch(inputArray, searchItem, low, midIndex);           
        }
    }
}
