// Write a program, which checks whether there is a subset of given 
// array of N elements, which has a sum S. The numbers N, S and the array 
// values are read from the console. Same number can be used many times.
// Example: { 2, 1, 2, 4, 3, 5, 2, 6}, S = 14 --> yes(1 + 2 + 5 + 6 = 14)

namespace Ch7Q20
{
    public static class SubsetWithSum
    {
        private static void Main()
        {
            int N, S;
            bool isInt;

            Console.WriteLine("Program to find subset of given array with a certain sum, " +
                "repetition is allowed");
            do
            {
                Console.Write("Enter length of array = ");
                isInt = Int32.TryParse(Console.ReadLine(), out N);
                if(!isInt || N <= 0)
                {
                    Console.WriteLine("\nEnter a valid integer 'x' such that" +
                        $"\n0 < x <= {Int32.MaxValue}");
                }
            }
            while (!isInt || N <= 0);

            int[] nums = new int[N];

            Console.WriteLine("\nInitialize array");
            for(int i = 0; i < N; i++)
            {
                do
                {
                    Console.Write($"Element[{i}] = ");
                    isInt = Int32.TryParse(Console.ReadLine(), out nums[i]);
                    if (!isInt || nums[i] < 0)
                    {
                        Console.WriteLine("\nEnter a valid positive integer 'x' such that" +
                            $"\n0 <= x <= {Int32.MaxValue}");
                    }
                }
                while (!isInt || nums[i] < 0);
            }

            Console.WriteLine("\nGiven array -");
            PrintArray(nums);
            Console.WriteLine();
            do
            {
                Console.Write("Enter required sum = ");
                isInt = Int32.TryParse(Console.ReadLine(), out S);
                if (!isInt)
                {
                    Console.WriteLine("\nEnter a valid integer 'x' such that" +
                        $"\n{Int32.MinValue} <= x <= {Int32.MaxValue}");
                }
            }
            while (!isInt);

            Console.WriteLine();
            FindSubsetWithSum(nums, S);
        }


        private static void PrintArray(int[] array)
        {
            // Method to print elements of array

            if (array.Length == 1)
            {
                Console.WriteLine($"{{{array[0]}}}");
                return;
            }

            for (int i = 0; i < array.Length; i++)
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


        private static void FindSubsetWithSum(int[] array, int requiredSum)
        {
            // Method to find subset of given array with required sum

            bool[] possible = new bool[requiredSum + 1];
            bool isFound = false;

            foreach(int i in array)
            {
                if(i < requiredSum + 1)
                {
                    possible[i] = true;
                    if(i == requiredSum)
                    {
                        isFound = true;
                        break;
                    }
                }
            }

            if (!isFound)
            {
                for (int i = 0; i < requiredSum + 1; i++)
                {
                    if(possible[i] == true)
                    {
                        foreach(int j in array)
                        {
                            int sum = i + j;
                            if(sum <= requiredSum)
                            {
                                possible[sum] = true;
                                if(sum == requiredSum)
                                {
                                    isFound = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine($"No subset found with sum = {requiredSum}");
            }
            else
            {
                List<int> subset = new List<int>();
                int temp = requiredSum;

                while(temp != 0)
                {
                    foreach(int i in array)
                    {
                        int num = temp - i;

                        if((num >= 0 && possible[num] == true) || num == 0)
                        {
                            subset.Add(i);
                            temp = num;
                            break;
                        }
                    }
                }

                int[] subsetArray = new int[subset.Count];

                subsetArray = subset.ToArray();
                Console.WriteLine($"Subset with sum {requiredSum} = ");
                PrintArray(subsetArray);
            }
            
        }
    }
}