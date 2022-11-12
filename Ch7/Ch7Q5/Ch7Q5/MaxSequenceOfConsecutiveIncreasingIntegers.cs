// Write a program, which finds the maximal sequence of consecutively 
// placed increasing integers. Example: { 3, 2, 3, 4, 2, 2, 4} -> { 2, 3, 4}.

namespace Ch7Q5
{
    public static class MaxSequenceOfConsecutiveIncreasingIntegers
    {
        public static void Main()
        {
            int len;
            bool isInt;

            Console.WriteLine("Program to print maximal sequence of consecutively " +
                "placed increasing integers in the given array");
            do
            {
                Console.Write("Enter length of array = ");
                isInt = Int32.TryParse(Console.ReadLine(), out len);
                if (!isInt || len <= 0)
                {
                    Console.WriteLine($"\nEnter a valid positive integer 'x' such that" +
                        $"\n0 < x <= {Int32.MaxValue}");
                }
            }
            while (!isInt || len <= 0);

            int[] array = new int[len];

            for(int i = 0; i < len; i++)
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

            PrintMaxSequenceOfConsecutivelyIncreasingIntegers(array);
        }


        private static void PrintMaxSequenceOfConsecutivelyIncreasingIntegers(int[] array)
        {
            // Method to print maximal sequence of consecutively placed increasing integers
            // in a given array

            int startIndex = 0, bestStartIndex = 0;
            int currentCount = 1, bestCount = 1;

            while(startIndex < array.Length - 1)
            {
                int temp = startIndex;
                currentCount = 1;

                for(int i = startIndex + 1, increment = 1; i < array.Length; i++, increment++)
                {
                    temp = i;
                    if(array[i] == array[startIndex] + increment)
                    {
                        currentCount++;
                        if(currentCount > bestCount)
                        {
                            bestCount = currentCount;
                            bestStartIndex = startIndex;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                startIndex = temp;
            }

            Console.Write("\nMaximal sequence of consecutively placed increasing integers = ");
            if(bestCount == 1)
            {
                Console.WriteLine($"{{{array[bestStartIndex]}}}");
            }
            else
            {
                for(int i = bestStartIndex; i < bestStartIndex + bestCount; i++)
                {
                    if(i == bestStartIndex)
                    {
                        Console.Write($"{{{array[i]}, ");
                    }
                    else if(i > bestStartIndex && i < bestStartIndex + bestCount - 1)
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
}