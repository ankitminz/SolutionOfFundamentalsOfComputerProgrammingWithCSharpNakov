// We are given 5 integer numbers. Write a program that finds those 
// subsets whose sum is 0. Examples:
//  -If we are given the numbers {3, -2, 1, 1, 8}, the sum of -2, 1 and 1 
//  is 0.
//  - If we are given the numbers {3, 1, -7, 35, 22}, there are no subsets 
//  with sum 0.

namespace Ch5Q9
{
    public static class SubsetsWithSumZero
    {
        static bool isAnySumZero = false;
        static bool error = false;

        public static void Main()
        {
            int n;

            Console.WriteLine("Program to find all the subsets from a given set of integers " +
                "whose sum is 0");
            n = ReadLengthOfArray("How many integers you want to enter: ");

            int[] nums = new int[n];

            for(int i = 0; i < nums.Length; i++)
            {
                nums[i] = ReadNum($"Number{i}: ");
            }

            Console.WriteLine("\nSubsets with sum 0 are");
            FindAllCombinations(nums);
        }


        static int ReadNum(string prompt)
        {
            // Method to take and handle integer type user inputs

            int num;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if (!isInt)
                {
                    Console.WriteLine($"\nEnter a valid integer x such that\n" +
                        $"{Int32.MinValue} <= x <= {Int32.MaxValue}");
                }
            }
            while (!isInt);

            return num;
        }


        static int ReadLengthOfArray(string prompt)
        {
            // Method to take and handle only positive integer type user inputs

            int len;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out len);
                if(!isInt || len <= 0)
                {
                    Console.WriteLine("Enter a valid positive integer x such that\n" +
                        $"0 < x <= {Int32.MaxValue}");
                }
            }
            while (!isInt || len <= 0);

            return len;
        }


        static void FindAllCombinations(params int[] nums)
        {
            // Method to find all combinations of n elements without repetition

            for(int i = 0; i < nums.Length; i++)
            {
                int[] combination = new int[i + 1];
                R_ElementCombination(nums, combination, i);
                if(error == true)
                {
                    break;
                }
            }

            if (!isAnySumZero)
            {
                Console.WriteLine("No subsets with sum 0");
            }
        }


        static void R_ElementCombination(int[] nums, int[] combination, int r, int startIndex = 0, int level = 0)
        {
            // Method to find combination of n elements taking r at a time without repetition

            for(int i = startIndex; i < nums.Length; i++)
            {
                combination[level] = nums[i];
                if(level + 1 <= r)
                {
                    R_ElementCombination(nums, combination, r, i + 1, level + 1);
                }
                else
                {

                    if(IsSumZero(combination) == -1)
                    {
                        error = true;
                        break;
                    }
                }
            }
        }


        static sbyte IsSumZero(int[] nums)
        {
            // Method to check whether sum of given array is zero or not

            int sum = 0;

            foreach(int num in nums)
            {
                try
                {
                    checked
                    {
                        sum += num;
                    }
                }
                catch(System.OverflowException e)
                {
                    Console.WriteLine($"\nError: {e.Message}");
                    return -1;
                }
            }

            if(sum == 0)
            {
                isAnySumZero = true;
                PrintArray(nums);
            }

            return 0;
        }


        static void PrintArray(int[] array)
        {
            // Method to print array

            for(int i = 0; i < array.Length; i++)
            {
                if(array.Length == 1)
                {
                    Console.WriteLine($"{{{array[i]}}}");
                }
                else if(i == 0)
                {
                    Console.Write($"{{{array[i]}, ");
                }
                else if(i == array.Length - 1)
                {
                    Console.WriteLine($"{array[i]}}}");
                }
                else
                {
                    Console.Write($"{array[i]}, ");
                }
            }
        }
    }
}