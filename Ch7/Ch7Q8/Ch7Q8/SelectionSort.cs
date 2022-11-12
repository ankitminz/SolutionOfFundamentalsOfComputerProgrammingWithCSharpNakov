// Sorting an array means to arrange its elements in an increasing (or 
// decreasing) order.Write a program, which sorts an array using the
// algorithm "selection sort".

namespace Ch7Q8
{
    public class SelectionSort
    {
        private static void Main()
        {
            int len, option;
            bool isInt;

            Console.WriteLine("Program to sort given array in increasing or decreasing " +
                "order using selection sort");
            Console.WriteLine();
            do
            {
                Console.Write("Enter length of array = ");
                isInt = Int32.TryParse(Console.ReadLine(), out len);
                if(!isInt || len <= 0)
                {
                    Console.WriteLine($"\nEnter a valid integer 'x'" +
                        $"\nsuch that 0 < x <= {Int32.MaxValue}");
                }
            }
            while (!isInt || len <= 0);

            int[] nums = new int[len];

            Console.WriteLine("\nInitialize the array");
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

            PrintArray(nums, "Given array");

            Console.WriteLine();
            do
            {
                Console.WriteLine("Sort array in -" +
                "\n1. Increasing order" +
                "\n2. Decreasing order");
                Console.Write("Enter option = ");
                isInt = Int32.TryParse(Console.ReadLine(), out option);
                if(!isInt || option < 1 || option > 2)
                {
                    Console.WriteLine("\nEnter either 1 or 2");
                }
            }
            while (!isInt || option < 1 || option > 2);

            Sort(nums, option);
            PrintArray(nums, "Sorted array");
        }


        private static void Sort(int[] array, int order)
        {
            // Method to sort given array using selection sort

            switch (order)
            {
                case 1:
                    {
                        for (int i = 0; i < array.Length; i++)
                        {
                            int minNumIndex = i;

                            for (int j = i; j < array.Length - 1; j++)
                            {
                                if (array[j + 1] < array[minNumIndex])
                                {
                                    minNumIndex = j + 1;
                                }
                            }

                            if (i != minNumIndex)
                            {
                                int temp = array[i];
                                array[i] = array[minNumIndex];
                                array[minNumIndex] = temp;
                            }
                        }

                        break;
                    }

                case 2:
                    {
                        for (int i = 0; i < array.Length; i++)
                        {
                            int maxNumIndex = i;

                            for (int j = i; j < array.Length - 1; j++)
                            {
                                if (array[j + 1] > array[maxNumIndex])
                                {
                                    maxNumIndex = j + 1;
                                }
                            }

                            if (i != maxNumIndex)
                            {
                                int temp = array[i];
                                array[i] = array[maxNumIndex];
                                array[maxNumIndex] = temp;
                            }
                        }

                        break;
                    }

                default:
                    {
                        Console.WriteLine("\nOops! some error occured");
                        break;
                    }
            }
        }


        private static void PrintArray(int[] array, string prompt)
        {
            // Method to print array

            Console.Write($"\n{prompt} = ");
            for (int i = 0; i < array.Length; i++)
            {
                if (array.Length == 1)
                {
                    Console.WriteLine($"{{{array[i]}}}");
                    break;
                }

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