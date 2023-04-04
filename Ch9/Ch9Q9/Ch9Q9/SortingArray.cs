// Write a method that finds the biggest element of an array. Use that 
// method to implement sorting in descending order.

namespace Ch9Q9
{
    public static class SortingArray
    {
        private static void Main()
        {
            int len;

            Console.WriteLine("Program to sort given array in descending order");
            len = GetInt("Enter length of array = ", 1);
            int[] array = new int[len];
            Console.WriteLine("\nInitialize array");
            for(int i = 0; i < len; i++)
            {
                array[i] = GetInt($"Element[{i}] = ");
            }

            Console.WriteLine("\nGiven array:");
            PrintArray(array);
            SortArray(array);
            Console.WriteLine("\nSorted array in descending order:");
            PrintArray(array);
        }


        private static int GetInt(string prompt, int? min = null)
        {
            // Method to take user input as int greater than or equal to min

            int num;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if(!isInt || (min != null && num < min))
                {
                    Console.WriteLine("\nEnter a valid integer 'x' such that");
                    if(min != null)
                    {
                        Console.WriteLine($"{min} <= x <= {Int32.MaxValue}");
                    }
                    else
                    {
                        Console.WriteLine($"{Int32.MinValue} <= x <= {Int32.MaxValue}");
                    }
                }
            }
            while (!isInt || (min != null && num < min));

            return num;
        }


        private static void PrintArray(int[] array)
        {
            // Method to print given int array

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


        private static void SortArray(int[] array)
        {
            // Method to sort given int array in descending order

            for(int i = 0; i < array.Length; i++)
            {
                int temp = array[i];
                int biggestElementIndex = GetIndexOfBiggestElement(array, i);
                array[i] = array[biggestElementIndex];
                array[biggestElementIndex] = temp;
            }
        }


        private static int GetIndexOfBiggestElement(int[] array, int startIndex = 0)
        {
            // Method to return index of biggest element from startIndex to last element

            int biggest = startIndex;

            for(int i = startIndex + 1; i < array.Length; i++)
            {
                if(array[i] > array[biggest])
                {
                    biggest = i;
                }
            }

            return biggest;
        }
    }
}