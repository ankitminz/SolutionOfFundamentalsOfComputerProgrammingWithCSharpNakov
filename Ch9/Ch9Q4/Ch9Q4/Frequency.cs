// Write a method that finds how many times certain number can be 
// found in a given array. Write a program to test that the method works 
// correctly.

namespace Ch9Q4
{
    public static class Frequency
    {
        private static void Main()
        {
            int len, num;

            Console.WriteLine("Program to find frequency of a given number in given " +
                "array of integers");
            len = GetInt("Enter length of array = ", 1);
            int[] array = new int[len];
            Console.WriteLine("Initialize array");
            for(int i = 0; i < len; i++)
            {
                array[i] = GetInt($"Element[{i}] = ");
            }

            Console.WriteLine();
            num = GetInt("Enter an integer = ");
            Console.WriteLine();
            Console.WriteLine($"Frequency of {num} in given array = {GetFrequencyOfNum(num, array)}");
            Console.WriteLine("Given array:");
            PrintArray(array);
        }


        private static ulong GetFrequencyOfNum(int num, params int[] array)
        {
            // Method to find frequency of given number in given array of integers

            ulong count = 0UL;

            foreach(int n in array)
            {
                if(n == num)
                {
                    count++;
                }
            }

            return count;
        }


        private static int GetInt(string prompt, int? min = null)
        {
            // Method to take user input as int greater than min value

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


        private static void PrintArray(params int[] array)
        {
            // Method to print array of integers

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