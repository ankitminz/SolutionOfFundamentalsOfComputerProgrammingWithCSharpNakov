// Write a program that calculates N!/K! for given N and K (1<K<N).

using System.Numerics;

namespace Ch6Q6
{
    public static class NByKFactorial
    {
        public static void Main()
        {
            uint n, k;
            bool isUInt;

            Console.WriteLine("Program to find N!/K! for given N and K (1<K<N)");
            do
            {
                Console.Write("N = ");
                isUInt = UInt32.TryParse(Console.ReadLine(), out n);
                if(!isUInt || n < 3)
                {
                    Console.WriteLine($"\nEnter a valid positive integer 'N' such that" +
                        $"\n3 <= N <= {UInt32.MaxValue}");
                }
            }
            while (!isUInt || n < 3);

            do
            {
                Console.Write("K = ");
                isUInt = UInt32.TryParse(Console.ReadLine(), out k);
                if(!isUInt || k >= n || k <= 1)
                {
                    Console.WriteLine($"\nEnter a valid positive integer 'K' such that" +
                        $"\n1 < K < {n}");
                }
            }
            while (!isUInt || k >= n || k <= 1);

            Console.WriteLine($"\n{n}!/{k}! = {Factorial(n)/Factorial(k)}");
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