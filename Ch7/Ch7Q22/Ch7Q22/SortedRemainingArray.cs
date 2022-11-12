// Write a program, which reads an array of integer numbers from the 
// console and removes a minimal number of elements in such a way 
// that the remaining array is sorted in an increasing order.
// Example: { 6, 1, 4, 3, 0, 3, 6, 4, 5} --> { 1, 3, 3, 4, 5}

namespace Ch7Q22
{
    public static class SortedRemainingArray
    {
        private static void Main()
        {
            int len;
            bool isInt;

            Console.WriteLine("Program to remove minimal number of elements from a " +
                "given array in such a way that the remaining array is sorted in " +
                "increasing order");
            Console.WriteLine();
            do
            {
                Console.Write("Enter the length of array = ");
                isInt = Int32.TryParse(Console.ReadLine(), out len);
                if(!isInt || len <= 0)
                {
                    Console.WriteLine("\nEnter a valid integer 'x' such that" +
                        $"\n0 < x <= {Int32.MaxValue}");
                }
            }
            while (!isInt || len <= 0);

            int[] nums = new int[len];

            Console.WriteLine();
            InitializeArray(nums);
            Console.WriteLine("\nGiven array - ");
            PrintArray(nums);
            Console.WriteLine("\nRemaining sorted array - ");
            FindGreatestIncreasingSubsequence(nums);
        }


        private static void InitializeArray(int[] array)
        {
            // Method to initialize given array

            bool isInt;

            Console.WriteLine("Initialize array");
            for(int i = 0; i < array.Length; i++)
            {
                do
                {
                    Console.Write($"Element[{i}] = ");
                    isInt = Int32.TryParse(Console.ReadLine(), out array[i]);
                    if (!isInt)
                    {
                        Console.WriteLine("\nEnter a valid integer 'x' such that" +
                            $"\n{Int32.MinValue} <= x <= {Int32.MaxValue}");
                    }
                }
                while (!isInt);
            }
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
                    Console.Write($"{{{array[0]}, ");
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


        private static void FindGreatestIncreasingSubsequence(int[] array)
        {
            // Method to find greatest increasing subsequence of elements from a given 
            // array

            List<int> sorted = new List<int>();
            List<int> temp = new List<int>();

            for(int i = 0; (i < array.Length) && (array.Length - i > sorted.Count); i++)
            {
                int previousIndex = i;

                temp.Clear();
                temp.Add(array[i]);
                for(int j = i + 1; j < array.Length; j++)
                {
                    int pSum = previousIndex + array[previousIndex];
                    int cSum = j + array[j];

                    if(array[j] >= array[previousIndex])
                    {
                        temp.Add(array[j]);
                        previousIndex = j;
                    }
                    else if(pSum - cSum <= j - previousIndex)
                    {
                        temp.RemoveAt(temp.LastIndexOf(array[previousIndex]));
                        temp.Add(array[j]);
                        previousIndex = j;
                    }
                }

                if(temp.Count > sorted.Count)
                {
                    sorted.Clear();
                    foreach(int num in temp)
                    {
                        sorted.Add(num);
                    }
                }
            }

            if(sorted.Count == 0)
            {
                Console.WriteLine("Some error occured");
                return;
            }

            PrintArray(sorted);
        }


        private static void PrintArray(List<int> list)
        {
            // Method to print elements of given array

            if (list.Count == 1)
            {
                Console.WriteLine($"{{{list[0]}}}");
                return;
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write($"{{{list[0]}, ");
                }
                else if (i > 0 && i < list.Count - 1)
                {
                    Console.Write($"{list[i]}, ");
                }
                else
                {
                    Console.WriteLine($"{list[i]}}}");
                }
            }
        }
    }
}