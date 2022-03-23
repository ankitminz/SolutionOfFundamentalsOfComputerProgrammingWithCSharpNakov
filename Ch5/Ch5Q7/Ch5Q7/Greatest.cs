// Write a program that finds the greatest of given 5 numbers.

namespace Ch5Q7
{
    public static class Greatest
    {
        public static void Main()
        {
            int n;

            Console.WriteLine("Program to find greatest number");
            n = ReadNum("How many numbers you'll enter: ");

            double[] nums = new double[n];

            Console.WriteLine();
            for(int i = 0; i < nums.Length; i++)
            {
                nums[i] = ReadRealNum($"Number{i}: ");
            }

            Console.WriteLine($"\nGreatest num: {FindGreatestNum(nums)}");
        }


        static int ReadNum(string prompt)
        {
            int num;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if (!isInt || num < 2)
                {
                    Console.WriteLine($"\nEnter a valid positive integer x such that\n" +
                        $"2 <= x <= {Int32.MaxValue}");
                }
            }
            while (!isInt || num < 2);

            return num;
        }


        static double ReadRealNum(string prompt)
        {
            double num;
            bool isDouble;

            do
            {
                Console.Write(prompt);
                isDouble = Double.TryParse(Console.ReadLine(), out num);
                if (!isDouble)
                {
                    Console.WriteLine("\nEnter a valid real number");
                }
            }
            while (!isDouble);

            return num;
        }


        static double FindGreatestNum(params double[] nums)
        {
            double greatest = nums[0];

            for(int i = 1; i < nums.Length; i++)
            {
                if(nums[i] > greatest)
                {
                    greatest = nums[i];
                }
            }

            return greatest;
        }
    }
}