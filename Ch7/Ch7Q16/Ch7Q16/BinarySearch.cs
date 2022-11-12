// Write a program, which uses a binary search in a sorted array of 
// integer numbers to find a certain element.

namespace Ch7Q16
{
    public static class BinarySearch
    {
        private static void Main()
        {
            int len, requiredNum;
            bool isInt;

            Console.WriteLine("Program to find whether a certain number is present in a given " +
                "array using binary search");
            Console.WriteLine();
            do
            {
                Console.Write("Enter length of array = ");
                isInt = Int32.TryParse(Console.ReadLine(), out len);
                if(!isInt || len <= 0)
                {
                    Console.WriteLine($"\nEnter a valid integer 'x' such that" +
                        $"\n0 < x <= {Int32.MaxValue}");
                }
            }
            while (!isInt || len <= 0);

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

            Console.WriteLine();
            do
            {
                Console.Write("Enter a number = ");
                isInt = Int32.TryParse(Console.ReadLine(), out requiredNum);
                if (!isInt)
                {
                    Console.WriteLine($"\nEnter a valid integer 'x' such that" +
                        $"\n{Int32.MinValue} <= x <= {Int32.MaxValue}");
                }
            }
            while (!isInt);

            Console.Write("\nGiven array = ");
            for(int i = 0; i < len; i++)
            {
                if(len == 1)
                {
                    Console.WriteLine($"{{{nums[i]}}}");
                    break;
                }

                if(i == 0)
                {
                    Console.Write($"{{{nums[i]}, ");
                }
                else if(i > 0 && i < len - 1)
                {
                    Console.Write($"{nums[i]}, ");
                }
                else
                {
                    Console.WriteLine($"{nums[i]}}}");
                }
            }

            Console.WriteLine();
            DoBinarySearch(nums, requiredNum);
        }


        private static void DoBinarySearch(int[] array, int requiredNum)
        {
            // Method to find whether given element is present in the given array

            int[] temp = new int[array.Length];

            for(int i = 0; i < array.Length; i++)
            {
                temp[i] = array[i];
            }

            Array.Sort(temp);
            int index = array.Length / 2;
            int lowerLimit = 0;
            int upperLimit = array.Length;
            bool isFound = false;

            while(index >= lowerLimit && index < upperLimit)
            {
                if(temp[index] == requiredNum)
                {
                    Console.WriteLine($"{requiredNum} is present in the given array");
                    isFound = true;
                    break;
                }

                int temp2 = index;
                if(temp[index] > requiredNum)
                {
                    index -= (upperLimit - lowerLimit) / 2;
                    if((upperLimit - lowerLimit) / 2 == 0)
                    {
                        index--;
                    }

                    upperLimit = temp2;
                }
                else
                {
                    lowerLimit = temp2;
                    index += (upperLimit - lowerLimit) / 2;
                    if((upperLimit - lowerLimit) / 2 == 0)
                    {
                        break;
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine($"{requiredNum} is absent in the given array");
            }
        }
    }
}