// Write a program, which reads from the console two integer numbers N
// and K (K<N) and array of N integers. Find those K consecutive 
// elements in the array, which have maximal sum.

namespace Ch7Q7
{
    public class MaximalSum
    {
        private static void Main()
        {
            int n, k;
            bool isInt;

            Console.WriteLine("Program to find 'k' consecutive elements in the array of " +
                "'n' integers which have maximal sum");
            do
            {
                Console.Write("\nn = ");
                isInt = Int32.TryParse(Console.ReadLine(), out n);
                if(!isInt || n < 2)
                {
                    Console.WriteLine($"\nEnter a valid positive integer 'n'" + 
                        $"\nsuch that 2 <= n <= {Int32.MaxValue}");
                }
            }
            while (!isInt || n < 2);

            do
            {
                Console.Write("\nk = ");
                isInt = Int32.TryParse(Console.ReadLine(), out k);
                if(!isInt || k >= n || k < 1)
                {
                    Console.WriteLine($"\nEnter a valid positive integer 'k'" +
                        $"\nsuch that 0 < k < {n}");
                }
            }
            while (!isInt || k >= n || k < 1);

            int[] nums = new int[n];

            Console.WriteLine("\nInitialize the array of integers");
            for(int i = 0; i < n; i++)
            {
                do
                {
                    Console.Write($"Element {i} = ");
                    isInt = Int32.TryParse(Console.ReadLine(), out nums[i]);
                    if (!isInt)
                    {
                        Console.WriteLine("\nEnter a valid integer 'x'" +
                            $"\nsuch that {Int32.MinValue} <= x <= {Int32.MaxValue}");
                    }
                }
                while (!isInt);
            }

            FindConsecutiveSequenceWithMaxSum(nums, k);
        }


        private static void FindConsecutiveSequenceWithMaxSum(int[] array, int k)
        {
            // Method to find sequence of 'k' integers with max sum

            long bestSum = Int64.MinValue;
            int bestStartIndex = 0;

            for(int i = 0; i <= array.Length - k; i++)
            {
                long currentSum = 0L;
                for(int j = i; j < i + k; j++)
                {
                    currentSum += array[j];
                }

                if(currentSum > bestSum)
                {
                    bestSum = currentSum;
                    bestStartIndex = i;
                }
            }

            Console.WriteLine("\nConsecutive sequence with max sum is -");
            if(k == 1)
            {
                Console.WriteLine($"{{{array[bestStartIndex]}}}");
                return;
            }

            for(int i = bestStartIndex; i < bestStartIndex + k; i++)
            {
                if(i == bestStartIndex)
                {
                    Console.Write($"{{{array[i]}, ");
                }
                else if(i > 0 && i < bestStartIndex + k - 1)
                {
                    Console.Write($"{array[i]}, ");
                }
                else
                {
                    Console.WriteLine($"{array[i]}}}");
                }
            }
        }
    }
}