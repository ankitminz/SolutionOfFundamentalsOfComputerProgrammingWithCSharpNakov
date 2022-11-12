// Write a program, which compares two arrays of type char
// lexicographically (character by character) and checks, which one is first 
// in the lexicographical order.

namespace Ch7Q3
{
    public static class CompareCharArraysAscendingOrder
    {
        public static void Main()
        {
            Console.WriteLine("Program to compare two given char arrays lexicographically " +
                " and checks, which one is first in the lexicographical order.");

            char[] array1 = Init("array1");
            char[] array2 = Init("array2");
            CompareCharArrays(array1, array2);
        }


        private static char[] Init(string prompt)
        {
            // Method to initialize char array

            int len;
            bool isInt;

            Console.WriteLine();
            do
            {
                Console.Write($"Enter length of {prompt} = ");
                isInt = Int32.TryParse(Console.ReadLine(), out len);
                if(!isInt || len <= 0)
                {
                    Console.WriteLine($"\nEnter a valid positive integer 'x' such that" +
                        $"\n0 < x <= {Int32.MaxValue}");
                }
            }
            while (!isInt || len <= 0);

            char[] array = new char[len];
            bool isChar;

            for(int i = 0; i < len; i++)
            {
                do
                {
                    Console.Write($"{prompt}[{i}] = ");
                    isChar = Char.TryParse(Console.ReadLine(), out array[i]);
                    if (!isChar)
                    {
                        Console.WriteLine("\nEnter a valid character");
                    }
                }
                while (!isChar);
            }

            return array;
        }


        private static void CompareCharArrays(char[] array1, char[] array2)
        {
            // Method to compare two arrays and find which comes first in lexicographical
            // order

            for(int i = 0; i < (array1.Length <= array2.Length ? array1.Length : array2.Length); i++)
            {
                if(array1[i] > array2[i])
                {
                    Console.WriteLine("\nArray2 comes first");
                    PrintCharArray(array2);
                    return;
                }
                else if(array1[i] < array2[i])
                {
                    Console.WriteLine("\nArray1 comes first");
                    PrintCharArray(array1);
                    return;
                }
            }

            if(array1.Length > array2.Length)
            {
                Console.WriteLine("\nArray2 comes first");
                PrintCharArray(array2);
            }
            else if(array1.Length < array2.Length)
            {
                Console.WriteLine("\nArray1 comes first");
                PrintCharArray(array1);
            }
            else
            {
                Console.WriteLine("\nArray1 and array2 are equal");
                PrintCharArray(array1);
            }
        }


        private static void PrintCharArray(char[] array)
        {
            // Method to print char array

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