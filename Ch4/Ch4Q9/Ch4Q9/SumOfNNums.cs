// Write a program that reads an integer number n from the console. After 
// that reads n numbers from the console and prints their sum.


namespace Ch4Q9
{
    public static class SumOfNNums
    {
        public static void Main()
        {
            int n;

            Console.WriteLine("Program to find sum of n integers");
            do
            {
                n = ReadNum("Enter n: ");
                if(n <= 0)
                {
                    Console.WriteLine("\nEnter a valid positive integer greater than 0");
                }
            }
            while (n <= 0);

            int[] nums = new int[n];

            for(int i = 0; i < nums.Length; i++)
            {
                nums[i] = ReadNum($"Enter num{i + 1}: ");
            }

            Console.WriteLine($"\nSum = {Sum(nums)}");
        }


        static int ReadNum(string prompt)
        {
            int num;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if(!isInt)
                {
                    Console.WriteLine($"\nEnter a valid integer x such that\n" +
                        $"{Int32.MinValue} <= x <= {Int32.MaxValue}");
                }
            }
            while (!isInt);

            return num;
        }


        static int? Sum(params int[] nums)
        {
            int? sum = 0;

            foreach(int num in nums)
            {
                try
                {
                    checked
                    {
                        sum += num;
                    }
                }
                catch(System.OverflowException e)
                {
                    Console.WriteLine($"\nError: {e.Message}");
                    sum = null;
                }
            }

            return sum;
        }
    }
}