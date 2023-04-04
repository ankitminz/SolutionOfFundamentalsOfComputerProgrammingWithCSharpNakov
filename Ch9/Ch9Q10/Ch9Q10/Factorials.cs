// Write a program that calculates and prints the n! for any n in the range
// [1…100].

using System.Numerics;

namespace Ch9Q10
{
    public static class Factorials
    {
        private static void Main()
        {
            int n;

            Console.WriteLine("Program to calculate factorial of a number in range [1, 100]");
            n = GetInt("Enter an integer = ");
            Console.WriteLine($"\n{n}! = {Factorial(n):n0}");
        }


        private static int GetInt(string prompt, int min = 1, int max = 100)
        {
            // Method to user input an integer in range [1, 100]

            int num;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if(!isInt || num < min || num > max)
                {
                    Console.WriteLine("\nEnter a valid integer 'x' such that" +
                        $"\n{min} <= x <= {max}");
                }
            }
            while(!isInt || num < min || num > max);

            return num;
        }


        private static BigInteger Factorial(int n)
        {
            // Method to find factorial of given number

            BigInteger f = new BigInteger(1);

            for(int i = n; i >= 2; i--)
            {
                f *= i;
            }

            return f;
        }
    }
}