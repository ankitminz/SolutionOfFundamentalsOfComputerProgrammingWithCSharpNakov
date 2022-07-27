// Write a program that reads from the console number N and print the sum 
// of the first N members of the Fibonacci sequence: 0, 1, 1, 2, 3, 5, 8, 
// 13, 21, 34, 55, 89, 144, 233, 377, …

using System.Numerics;

namespace Ch6Q5
{
    public static class SumOfFibonacciSeries
    {
        public static void Main()
        {
            uint n;
            bool isUInt;

            Console.WriteLine("Program to find sum of first 'N' members of the fibonacci" +
                " sequence");
            do
            {
                Console.Write("Enter N = ");
                isUInt = UInt32.TryParse(Console.ReadLine(), out n);
                if (!isUInt || n == 0)
                {
                    Console.WriteLine($"\nEnter a valid positive integer 'N' such that" +
                        $"\n1 <= N <= {UInt32.MaxValue}");
                }
            }
            while (!isUInt || n == 0);

            Console.WriteLine($"\nSum of first {n} fibonacci numbers = {SumOfFirstNFibonacciSeries(n)}");
        }


        private static BigInteger GetFibonacciNum(uint index)
        {
            // Method to get the fibonacci number at 'index' position starting from 1

            BigInteger previous = 0;
            BigInteger num = 1;

            switch (index)
            {
                case 1:return 0;
                case 2:return 1;
                default:
                    for (uint i = 3; i <= index; i++)
                    {
                        BigInteger temp = num;
                        num += previous;
                        previous = temp;
                    }

                    return num;
            }
        }


        private static BigInteger SumOfFirstNFibonacciSeries(uint n)
        {
            // Method to find sum of first 'N' fibonacci numbers starting from 1

            BigInteger sum = 0;

            for(uint i = n; i >= 1; i--)
            {
                sum += GetFibonacciNum(i);
            }

            return sum;
        }
    }
}