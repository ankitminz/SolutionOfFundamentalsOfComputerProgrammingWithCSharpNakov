// Write a program that for a given integers n and x, calculates the sum:
// 1 + 1!/x + 2!/x^2 + ... + n!/x^n

namespace Ch6Q9
{
    public static class Series
    {
        public static void Main()
        {
            uint n, x;

            Console.WriteLine("Program to find sum of series:" +
                "\n1 + 1!/x + 2!/x^2 + ... + n!/x^n" +
                "\nfor given positive integers n and x");

            n = GetNum("n = ");
            x = GetNum("x = ");
            Console.WriteLine($"\nSum of series = {SumOfSeries(n, x):f2}");
        }


        private static uint GetNum(string prompt)
        {
            // Method to get user input

            uint num;
            bool isUint;

            do
            {
                Console.Write(prompt);
                isUint = UInt32.TryParse(Console.ReadLine(), out num);
                if(!isUint || num == 0)
                {
                    Console.WriteLine($"\nEnter a valid positive integer 'i' such that" +
                        $"\n1 <= i <= {UInt32.MaxValue}");
                }
            }
            while (!isUint || num == 0);

            return num;
        }


        private static ulong Factorial(uint num)
        {
            // Method to find factorial

            ulong factorial = 1;

            while(num > 1)
            {
                factorial *= num;
                num--;
            }

            return factorial;
        }


        private static Double SumOfSeries(uint n, uint x)
        {
            // Method to find sum of series
            // 1 + 1!/x + 2!/x^2 + ... + n!/x^n

            Double sum = 1.0;

            for(uint i = 1; i <= n; i++)
            {
                sum += Factorial(i) / Math.Pow(x, i);
            }

            return sum;
        }
    }
}