// Write a program, which reads two arrays from the console and checks 
// whether they are equal (two arrays are equal when they are of equal 
// length and all of their elements, which have the same index, are equal).

namespace Ch7Q2
{
    public static class ArrayChecker
    {
        public static void Main()
        {
            Console.WriteLine("Program to check whether two given arrays are equal or not");
            int[] array1 = Init("first array");
            Console.WriteLine();
            int[] array2 = Init("second array");
            if(IsEqual(array1, array2))
            {
                Console.WriteLine("\nBoth arrays are equal");
            }
            else
            {
                Console.WriteLine("\nBoth arrays are not equal");
            }
        }


        private static int GetNum(string prompt)
        {
            // Method to get a positive integer input

            int num;
            bool isInt;

            do
            {
                Console.Write($"{prompt} = ");
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if(!isInt || num <= 0)
                {
                    Console.WriteLine($"\nEnter a valid positive integer 'x' such that" +
                        $"\n0 < x <= {Int32.MaxValue}");
                }
            }
            while (!isInt || num <= 0);

            return num;
        }


        private static int[] Init(string prompt)
        {
            // Method to initialize array

            int[] array = new int[GetNum($"Enter length of {prompt}")];
            bool isInt;

            Console.WriteLine($"Populate {prompt}");
            for(int i = 0; i < array.Length; i++)
            {
                do
                {
                    Console.Write($"array[{i}] = ");
                    isInt = Int32.TryParse(Console.ReadLine(), out array[i]);
                    if (!isInt)
                    {
                        Console.WriteLine($"\nEnter a valid integer 'x' such that" +
                            $"\n{Int32.MinValue} <= x <= {Int32.MaxValue}");
                    }
                }
                while (!isInt);
            }

            return array;
        }


        private static bool IsEqual(int[] array1, int[] array2)
        {
            // Method to compare two given arrays

            if(array1.Length != array2.Length)
            {
                return false;
            }

            for(int i = 0; i < array1.Length; i++)
            {
                if(array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}