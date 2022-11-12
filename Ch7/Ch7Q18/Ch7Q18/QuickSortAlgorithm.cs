// Write a program, which sorts an array of integer elements using a "quick
// sort " algorithm.

namespace Ch7Q18
{
    static class QuickSortAlgorithm
    {
        private static void Main()
        {
            int len;
            bool isInt;

            Console.WriteLine("Program to sort given array using quick sort algorithm");
            do
            {
                Console.Write("Enter length of array = ");
                isInt = Int32.TryParse(Console.ReadLine(), out len);
                if(!isInt || len < 1)
                {
                    Console.WriteLine("\nEnter a valid integer 'x' such that" +
                        $"\n0 < x <= {Int32.MaxValue}");
                }
            }
            while (!isInt || len < 1);

            int[] nums = new int[len];

            Console.WriteLine("\nInitialize array");
            for(int i = 0; i < len; i++)
            {
                do
                {
                    Console.Write($"Element[{i}] = ");
                    isInt = Int32.TryParse(Console.ReadLine(), out nums[i]);
                    if (!isInt)
                    {
                        Console.WriteLine("\nEnter a valid integer 'x' such that" +
                            $"\n{Int32.MinValue} <= x <= {Int32.MaxValue}");
                    }
                }
                while (!isInt);
            }

            Console.WriteLine("\nGiven array -");
            PrintArray(nums);
            QuickSort(nums, 0, len - 1);
            Console.WriteLine("\nSorted array -");
            PrintArray(nums);
        }


        private static void PrintArray(int[] array)
        {
            // Method to print array

            for(int i = 0; i < array.Length; i++)
            {
                if(array.Length == 1)
                {
                    Console.WriteLine($"{{{array[0]}}}");
                    break;
                }

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


        private static void QuickSort(int[] array, int low, int high)
        {
            // Quick sort algorithm to sort given array recursively

            if(low >= high || low < 0)
            {
                return;
            }

            int p = Partition(array, low, high);

            QuickSort(array, low, p - 1); // quick sort left part of pivot
            QuickSort(array, p + 1, high); // quick sort right part of pivot
        }


        private static int Partition(int[] array, int low, int high)
        {
            // Method to choose last element as pivot and put it in right position 
            // with all elements smaller or equal to its left and larger elements 
            // to its right and return the index of pivot

            int pivot = array[high];
            int i = low - 1; // current pivot index
            
            for(int j = low; j < high; j++)
            {
                if(array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

            Swap(array, i + 1, high);
            return i + 1;
        }


        private static void Swap(int[] array, int i, int j)
        {
            // Method to swap elements at index i and j

            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}