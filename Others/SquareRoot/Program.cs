using System;

namespace SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number to find square root:");
            int input = Convert.ToInt32(Console.ReadLine());
            SqRoot(input);

            Console.ReadKey();
        }

        static void SqRoot(int number)
        {
            int i = 1;
            bool isGotResult = false;

            while (!isGotResult)
            {
                if (i * i == number)
                {
                    Console.WriteLine("Result = " + i);
                    isGotResult = true;
                }
                else if ((i * i) > number)
                {
                    var result = Square(number, i - 1, i);

                    Console.WriteLine("Result = " + result);
                    isGotResult = true;
                }

                i++;
            }
        }

        static double Square(int number, double i, double j)
        {
            double mid = (i + j) / 2;
            double mul = mid * mid;

            if (mul == number || Math.Abs(mul - number) < 0.00001)
            {
                return mid;
            }

            else if (mul > number)
            {
                return Square(number, i, mid);
            }

            else
            {
                return Square(number, mid, j);
            }
        }
    }
}
