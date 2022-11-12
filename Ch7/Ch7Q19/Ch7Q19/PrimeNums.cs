// Write a program, which finds all prime numbers in the range 
// [1…10,000,000].

namespace Ch7Q19
{
    public static class PrimeNums
    {
        private static void Main()
        {
            int low, high;

            Console.WriteLine("Program to find all prime numbers in a given range");
            low = GetInt("Enter lower limit = ");
            high = GetInt("Enter higher limit = ");
            Console.WriteLine();
            PrintPrimeNumsInRange(low, high);
        }


        private static int GetInt(string prompt)
        {
            // Method to take user input an integer

            int num;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if (!isInt)
                {
                    Console.WriteLine("\nEnter a valid integer 'x' such that" +
                        $"\n{Int32.MinValue} <= x <= {Int32.MaxValue}");
                }
            }
            while (!isInt);

            return num;
        }


        private static void PrintPrimeNumsInRange(int low, int high)
        {
            // Method to print prime nums in given range inclusively

            low = Math.Abs(low);
            high = Math.Abs(high);
            if(low > high)
            {
                int temp = low;
                low = high;
                high = temp;
            }

            int[] nums = new int[high - 1];
            InitializeArray(nums);
            int greatestNum = nums[high - 2];
            for (int i = 0; i < high - 1; i++)
            {
                if(Math.Pow(nums[i], 2) > greatestNum)
                {
                    break;
                }
                else if (nums[i] == 0)
                {
                    continue;
                }

                for (int j = i + nums[i]; j < high - 1; j += nums[i])
                {
                    nums[j] = 0;
                }
            }

            int startIndex = 0;
            int count = 0;

            if(low >= 2)
            {
                startIndex = low - 2;
            }

            for(int i = startIndex; i < high - 1; i++)
            {
                if(nums[i] != 0)
                {
                    count++;
                }
            }

            int[] primeNums = new int[count];
            for(int i = startIndex, j = 0; i < high - 1; i++)
            {
                if(nums[i] != 0)
                {
                    primeNums[j] = nums[i];
                    j++;
                }
            }

            Console.WriteLine($"Prime numbers in range[{low}, {high}] are -");
            PrintArray(primeNums);
        }


        private static void InitializeArray(int[] array)
        {
            // Method to initialize array

            for(int i = 0, num = 2; i < array.Length; i++, num++)
            {
                array[i] = num;
            }
        }


        private static void PrintArray(int[] array)
        {
            // Method to print elements of array

            for(int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}