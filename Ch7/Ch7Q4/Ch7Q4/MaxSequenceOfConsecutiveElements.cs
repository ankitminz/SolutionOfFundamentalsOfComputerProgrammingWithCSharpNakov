// Write a program, which finds the maximal sequence of consecutive 
// equal elements in an array. E.g.: { 1, 1, 2, 3, 2, 2, 2, 1} -> { 2, 2, 2}.

namespace Ch7Q4
{
    public static class MaxSequenceOfConsecutiveElements
    {
        public static void Main()
        {
            int len;
            bool isInt;

            Console.WriteLine("Program to find maximal sequence of consecutive elements " +
                "in the given array");
            do
            {
                Console.Write("Enter length of array = ");
                isInt = Int32.TryParse(Console.ReadLine(), out len);
                if(!isInt || len <= 0)
                {
                    Console.WriteLine($"\nEnter a valid positive integer 'x' such that" +
                        $"\n0 < x <= {Int32.MaxValue}");
                }
            }
            while (!isInt || len <= 0);

            int[] array = new int[len];

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

            PrintMaximalSequenceOfConsecutiveElements(array);
        }


        private static void PrintMaximalSequenceOfConsecutiveElements(int[] array)
        {
            // Method to find maximal sequence of consecutive elements in a given array

            int startIndex = 0, bestStartIndex = 0;
            int currentCount = 1, bestCount = 1;

            while(startIndex < array.Length - 1)
            {
                int temp = startIndex;
                currentCount = 1;

                for(int i = startIndex + 1; i < array.Length; i++)
                {
                    temp = i;
                    if(array[i] == array[startIndex])
                    {
                        currentCount++;
                        if(currentCount > bestCount)
                        {
                            bestStartIndex = startIndex;
                            bestCount = currentCount;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                startIndex = temp;
            }

            Console.Write("\nMaximal sequence of consecutive elements = ");
            if (bestCount == 1)
            {
                Console.Write($"{{{array[bestStartIndex]}}}");
            }
            else
            {
                for (int i = bestStartIndex; i < bestStartIndex + bestCount; i++)
                {


                    if (i == bestStartIndex)
                    {
                        Console.Write($"{{{array[i]}, ");
                    }
                    else if (i > bestStartIndex && i < bestStartIndex + bestCount - 1)
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