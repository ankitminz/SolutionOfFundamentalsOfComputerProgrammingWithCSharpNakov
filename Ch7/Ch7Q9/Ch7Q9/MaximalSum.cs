// Write a program, which finds a subsequence of numbers with 
// maximal sum. E.g.: { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8} --> 11

namespace Ch7Q9
{
    public static class MaximalSum
    {
        private static void Main()
        {
            int len;
            bool isInt;

            Console.WriteLine("Program to find subsequence of numbers with maximal " +
                "sum from a given array of integers");
            Console.WriteLine();
            do
            {
                Console.Write("Enter length of array = ");
                isInt = Int32.TryParse(Console.ReadLine(), out len);
                if(!isInt || len <= 0)
                {
                    Console.WriteLine("\nEnter a valid integer 'x'" +
                        $"\nsuch that 0 < x <= {Int32.MaxValue}");
                }
            }
            while (!isInt || len <= 0);

            int[] nums = new int[len];

            Console.WriteLine("\nInitialize array");
            for(int i = 0; i < nums.Length; i++)
            {
                do
                {
                    Console.Write($"Element[{i}] = ");
                    isInt = Int32.TryParse(Console.ReadLine(), out nums[i]);
                    if (!isInt)
                    {
                        Console.WriteLine("\nEnter a valid integer 'x'" + 
                            $"\nsuch that {Int32.MinValue} <= x <= {Int32.MaxValue}");
                    }
                }
                while (!isInt);
            }

            Console.Write("\nGiven array = ");
            for(int i = 0; i < nums.Length; i++)
            {
                if(nums.Length == 1)
                {
                    Console.WriteLine($"{{{nums[i]}}}");
                    break;
                }

                if(i == 0)
                {
                    Console.Write($"{{{nums[i]}, ");
                }
                else if(i > 0 && i < nums.Length - 1)
                {
                    Console.Write($"{nums[i]}, ");
                }
                else
                {
                    Console.WriteLine($"{nums[i]}}}");
                }
            }

            FindSubSequenceWithMaxSum(nums);
        }


        private static void FindSubSequenceWithMaxSum(int[] array)
        {
            // Method to find subsequence with max sum in the given array

            int bestStartIndex = 0, bestEndIndex = 0;
            long bestSum = Int64.MinValue;

            for(int i = 0; i < array.Length; i++)
            {
                long currentSum = 0;

                for(int j = i; j < array.Length; j++)
                {
                    currentSum += array[j];
                    if(currentSum > bestSum)
                    {
                        bestSum = currentSum;
                        bestStartIndex = i;
                        bestEndIndex = j;
                    }
                }
            }

            Console.Write("\nSubsequence with max sum = ");
            if(bestStartIndex == bestEndIndex)
            {
                Console.WriteLine($"{{{array[bestStartIndex]}}}");
            }
            else
            {
                for(int i = bestStartIndex; i <= bestEndIndex; i++)
                {
                    if(i == bestStartIndex)
                    {
                        Console.Write($"{{{array[i]}, ");
                    }
                    else if(i > bestStartIndex && i < bestEndIndex)
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
}