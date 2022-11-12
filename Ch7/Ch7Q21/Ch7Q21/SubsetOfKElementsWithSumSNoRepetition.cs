// Write a program which by given N numbers, K and S, finds K elements out 
// of the N numbers, the sum of which is exactly S or says it is not possible.
// Example: { 3, 1, 2, 4, 9, 6}, S = 14, K = 3 --> yes(1 + 2 + 4 = 14)

namespace Ch7Q21
{
    public static class SubsetOfKElementsWithSumSNoRepetition
    {
        private static void Main()
        {
            int N, K, S;

            Console.WriteLine("Program to find subset of certain number of elements " +
                "from a given array with a ceratain sum without repetition");
            N = GetLen("Enter length of array = ");

            int[] nums = new int[N];

            Console.WriteLine("\nInitialize array");
            InitializeArray(nums);
            Console.WriteLine();
            K = GetLen("Enter length of subset = ", N);
            Console.WriteLine();
            S = GetLen("Enter required sum = ");
            Console.WriteLine("\nGiven array - ");
            PrintArray(nums);
            Console.WriteLine();
            FindSubset(nums, S, K);
        }


        private static int GetInt(string prompt)
        {
            // Method to take user input of an integer

            int num;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if (!isInt)
                {
                    Console.WriteLine("\nEnter a valid integer 'x' such that" +
                        $"\n{Int32.MinValue} <= x <= {Int32.MaxValue}");
                }
            }
            while (!isInt);

            return num;
        }


        private static void InitializeArray(int[] array)
        {
            // Method to initialize given array

            for(int i = 0; i < array.Length; i++)
            {
                array[i] = GetInt($"Element[{i}] = ");
            }
        }


        private static int GetLen(string prompt, int max = Int32.MaxValue)
        {
            // Method to take user input for length of an array

            int len;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out len);
                if (!isInt || len <= 0 || len > max)
                {
                    Console.WriteLine("\nEnter a valid integer 'x' such that" +
                        $"\n0 < x <= {max}");
                }
            }
            while (!isInt || len <= 0 || len > max);

            return len;
        }


        private static void PrintArray(int[] array)
        {
            // Method to print elements of given array

            if(array.Length == 1)
            {
                Console.WriteLine($"{{{array[0]}}}");
                return;
            }

            for(int i = 0; i < array.Length; i++)
            {
                if(i == 0)
                {
                    Console.Write($"{{{array[i]}, ");
                }
                else if(i > 0 && i < array.Length - 1)
                {
                    Console.Write($"{array[i]}, ");
                }
                else
                {
                    Console.WriteLine($"{array[i]}}}");
                }
            }
        }


        private static void FindSubset(int[] array, int requiredSum, int K)
        {
            // Method to find subset of length K with given sum from given array
            // Helper method

            int?[] subset = new int?[K];

            Find(array, subset, requiredSum, K);
            if (NothingNull(subset))
            {
                Console.WriteLine($"Subset with sum {requiredSum} is - ");
                PrintArray(subset);
            }
            else
            {
                Console.WriteLine("No subset found");
            }
        }


        private static void Find(int[] array, int?[] subset, int requiredSum, int K, int startIndex = 0, int currentSum = 0)
        {
            // Method to find subset of length K with given sum from given array recursively

            for(int i = startIndex; i < array.Length; i++)
            {
                currentSum += array[i];
                if(K > 1)
                {
                    Find(array, subset, requiredSum, K - 1, i + 1, currentSum);
                }

                if((K == 1 && currentSum == requiredSum) || NotAllNull(subset))
                {
                    subset[K - 1] = array[i];
                    return;
                }

                currentSum -= array[i];
            }
        }


        private static bool NotAllNull(int?[] array)
        {
            // Method to find whether all values of given array are null or not

            for(int i = 0; i < array.Length; i++)
            {
                if(array[i] != null)
                {
                    return true;
                }
            }

            return false;
        }


        private static bool NothingNull(int?[] array)
        {
            // Method to check whether any element is null or not in a given array

            for(int i = 0; i < array.Length; i++)
            {
                if(array[i] == null)
                {
                    return false;
                }
            }

            return true;
        }


        private static void PrintArray(int?[] array)
        {
            // Method to print elements of given array

            if (array.Length == 1)
            {
                Console.WriteLine($"{{{array[0]}}}");
                return;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (i == 0)
                {
                    Console.Write($"{{{array[i]}, ");
                }
                else if (i > 0 && i < array.Length - 1)
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