// Write a program that prints on the console the first 100 numbers in the 
// Fibonacci sequence: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, …


using System.Numerics;

namespace Ch4Q11
{
    public static class FibonacciSequence
    {
        public static void Main()
        {
            int n = 100;

            Console.WriteLine($"Program to print {n} fibonacci numbers");
            List<BigInteger> fibonacciSequence = GenerateFibonacciSequence(n);
            foreach(BigInteger num in fibonacciSequence)
            {
                Console.WriteLine(num);
            }
        }


        static List<BigInteger> GenerateFibonacciSequence(int n = 1)
        {
            List<BigInteger> nums = new List<BigInteger>();
            BigInteger x = new BigInteger(0);
            BigInteger y = new BigInteger(1);

            nums.Add(x);

            if(n >= 2)
            {
                nums.Add(y);
            }

            if(n >= 3)
            {
                for (int i = 3; i <= n; i++)
                {
                    BigInteger temp = y;
                    try
                    {
                        checked
                        {
                            y += x;
                        }
                    }
                    catch(System.OverflowException e)
                    {
                        Console.WriteLine($"\nError: {e.Message}\n" +
                            $"Only {i - 1} fibonacci numbers are printed\n");
                        break;
                    }
                    catch(System.OutOfMemoryException e)
                    {
                        Console.WriteLine($"\nError: {e.Message}\n" +
                            $"Only {i - 1} fibonacci numbers are printed\n");
                    }

                    nums.Add(y);
                    x = temp;
                }
            }
            
            return nums;
        }
    }
}