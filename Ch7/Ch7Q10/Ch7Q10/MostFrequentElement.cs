// Write a program, which finds the most frequently occurring element in 
// an array. Example: { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} --> 4(5 times).

namespace Ch7Q10
{
    public static class MostFrequentElement
    {
        private static void Main()
        {
            int len;
            bool isInt;

            Console.WriteLine("Program to find most frequently occuring element in " +
                "a given array");
            Console.WriteLine();
            do
            {
                Console.Write("Enter length of array = ");
                isInt = Int32.TryParse(Console.ReadLine(), out len);
                if(!isInt || len <= 0)
                {
                    Console.WriteLine("\nEnter a valid integer 'x'" +
                        $"\nsuch that 0 < x <= {Int32.MaxValue}");
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
                        Console.WriteLine("\nEnter a valid integer 'x'" +
                            $"\nsuch that {Int32.MinValue} <= x <= {Int32.MaxValue}");
                    }
                }
                while (!isInt);
            }

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

            FindMostFrequentElement(nums);
        }


        private static void FindMostFrequentElement(int[] array)
        {
            // Method to find most frequent element in the given array

            List<int> usedNums = new List<int>(array.Length / 2 + 1);
            int maxCount = 0;
            int bestNum = array[0];

            for(int i = 0; i < array.Length; i++)
            {
                int count = 1;
                if (usedNums.Contains(array[i]))
                {
                    continue;
                }

                usedNums.Add(array[i]);

                for(int j = i + 1; j < array.Length; j++)
                {
                    if(array[i] == array[j])
                    {
                        count++;
                    }
                }

                if(count > maxCount)
                {
                    maxCount = count;
                    bestNum = array[i];
                }
            }

            Console.Write($"\nMost frequent element = {bestNum} " +
                $"({maxCount} ");
            if(maxCount == 1)
            {
                Console.WriteLine("time)");
            }
            else
            {
                Console.WriteLine("times)");
            }
        }
    }
}