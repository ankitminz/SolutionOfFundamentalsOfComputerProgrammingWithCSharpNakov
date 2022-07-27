// Write a program that prints on the console the numbers from 1 to N. 
// The number N should be read from the standard input.

namespace Ch6Q1
{
    public static class OneToN
    {
        public static void Main()
        {
            uint n;
            bool isUInt;

            Console.WriteLine("Program to print numbers from 1 to N");
            do
            {
                Console.Write("N = ");
                isUInt = UInt32.TryParse(Console.ReadLine(), out n);
                if (!isUInt || n == 0)
                {
                    Console.WriteLine("\nEnter a valid positive integer 'N' such that\n" +
                        $"{UInt32.MinValue} < N <= {UInt32.MaxValue}");
                }
            }
            while (!isUInt || n == 0);

            for(uint i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}