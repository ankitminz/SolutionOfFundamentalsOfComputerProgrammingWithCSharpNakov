// In combinatorics, the Catalan numbers are calculated by the following 
// formula: 
// (2n)!/((n+1)!n!), for n ≥ 0. Write a program that 
// calculates the nth Catalan number by given n.

using System.Numerics;

namespace Ch6Q8
{
    public static class CatalanNumbers
    {
        public static void Main()
        {
            uint n;
            bool isUInt;

            Console.WriteLine("Program to find nth catalan number starting from 0");
            do
            {
                Console.Write("n = ");
                isUInt = UInt32.TryParse(Console.ReadLine(), out n);
                if (!isUInt)
                {
                    Console.WriteLine($"\nEnter a valid positive integer 'n' such that" + 
                        $"\n{UInt32.MinValue} <= n <= {UInt32.MaxValue}");
                }
            }
            while(!isUInt);

            Console.WriteLine($"\n{n}th catalan number = {Factorial(2 * n) / (Factorial(n + 1) * Factorial(n))}");
        }


        private static BigInteger Factorial(uint num)
        {
            // Method to find factorial

            BigInteger factorial = 1;

            while(num > 1)
            {
                factorial *= num;
                num--;
            }

            return factorial;
        }
    }
}