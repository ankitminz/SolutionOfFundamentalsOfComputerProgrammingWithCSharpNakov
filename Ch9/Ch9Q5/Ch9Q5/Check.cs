// Write a method that checks whether an element, from a certain position 
// in an array is greater than its two neighbors. Test whether the 
// method works correctly.

namespace Ch9Q5
{
    public static class Check
    {
        private static void Main()
        {
            int len, index;

            Console.WriteLine("Program to check whether element at certain position " +
                "in a given array is greater than its neighbours.");
            len = GetInt("Enter length of array = ", min: 1);
            int[] array = new int[len];
            Console.WriteLine("Initialize array");
            for(int i = 0; i < len; i++)
            {
                array[i] = GetInt($"Element[{i}] = ");
            }

            Console.WriteLine();
            index = GetInt("Enter index of an element in given array = ", 0, array.Length - 1);
            Console.WriteLine($"\nIs {array[index]} at index {index} greater than " +
                $"its neighbours = {isGreaterThanNeighbours(index, array)}");
            Console.WriteLine();
            Console.WriteLine("Given array:");
            PrintArray(array);
        }


        private static int GetInt(string prompt, int? min = null, int? max = null)
        {
            // Method to take user input as integer greater than or equal to min value

            int num;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if(!isInt || (min != null && num < min) || (max != null && num > max))
                {
                    Console.WriteLine("\nEnter a valid integer 'x' such that");
                    if(min != null && max != null)
                    {
                        Console.WriteLine($"{min} <= x <= {max}");
                    }
                    else if(min != null)
                    {
                        Console.WriteLine($"{min} <= x <= {Int32.MaxValue}");
                    }
                    else if(max != null)
                    {
                        Console.WriteLine($"{Int32.MinValue} <= x <= {max}");
                    }
                    else
                    {
                        Console.WriteLine($"{Int32.MinValue} <= x <= {Int32.MaxValue}");
                    }
                }
            }
            while (!isInt || (min != null && num < min) || (max != null && num > max));

            return num;
        }


        private static bool isGreaterThanNeighbours(int index, int[] array)
        {
            // Method to check whether element at given index in given array is greater
            // than its neighbours

            bool isGreaterThanSuccessor = true, isGreaterThanPrevious = true;

            if(index + 1 < array.Length)
            {
                isGreaterThanSuccessor = array[index] > array[index + 1];
            }

            if(index - 1 >= 0)
            {
                isGreaterThanPrevious = array[index] > array[index - 1];
            }

            return isGreaterThanSuccessor && isGreaterThanPrevious;
        }


        private static void PrintArray(int[] array)
        {
            // Method to print integer array

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
    }
}