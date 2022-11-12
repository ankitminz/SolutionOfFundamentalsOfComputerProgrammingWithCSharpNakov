// Write a program to find a sequence of neighbor numbers in an array,
// which has a sum of certain number S. Example: { 4, 3, 1, 4, 2, 5, 8},
// S = 11 --> { 4, 2, 5}.

namespace Ch7Q11
{
    public static class CertainSum
    {
        private static void Main()
        {
            int s, len;
            bool isInt;

            Console.WriteLine("Program to find subsequence in a given array which has " +
                "a certain sum 'S'");
            Console.WriteLine();
            s = GetInt("S = ");
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
            for(int i = 0; i < len; i++)
            {
                nums[i] = GetInt($"Element[{i}] = ");
            }

            Console.Write("\nGiven array = ");
            for(int i = 0; i < len; i++)
            {
                if(len == 1)
                {
                    Console.WriteLine($"{{{nums[i]}}}");
                    break;
                }

                if(i == 0)
                {
                    Console.Write($"{{{nums[i]}, ");
                }
                else if(i > 0 && i < len - 1)
                {
                    Console.Write($"{nums[i]}, ");
                }
                else
                {
                    Console.WriteLine($"{nums[i]}}}");
                }
            }

            FindSubsequenceWithCertainSum(nums, s);
        }


        private static int GetInt(string prompt)
        {
            // Method to parse integer values

            int num;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if (!isInt)
                {
                    Console.WriteLine("\nEnter a valid integer 'x'" +
                        $"\nsuch that {Int32.MinValue} <= x <= {Int32.MaxValue}");
                }
            }
            while (!isInt);

            return num;
        }


        private static void FindSubsequenceWithCertainSum(int[] array, int requiredSum)
        {
            // Method to find subsequence with certain sum in the given array

            int bestStartIndex = 0, bestEndIndex = 0;
            bool isSubsequenceFound = false;

            for(int i = 0; i < array.Length; i++)
            {
                int currentSum = array[i];

                if(currentSum == requiredSum)
                {
                    bestStartIndex = i;
                    bestEndIndex = i;
                    isSubsequenceFound = true;
                    break;
                }
                for(int j = i + 1; j < array.Length; j++)
                {
                    currentSum += array[j];
                    if(currentSum == requiredSum)
                    {
                        bestStartIndex = i;
                        bestEndIndex = j;
                        isSubsequenceFound = true;
                        break;
                    }
                }

                if (isSubsequenceFound)
                {
                    break;
                }
            }

            if (isSubsequenceFound)
            {
                Console.Write("\nSubsequence = ");
                if(bestStartIndex == bestEndIndex)
                {
                    Console.WriteLine($"{{{array[bestStartIndex]}}} --> {requiredSum}");
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
                            Console.WriteLine($"{array[i]}}} --> {requiredSum}");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"\nNo subsequence found with sum {requiredSum}");
            }
        }
    }
}