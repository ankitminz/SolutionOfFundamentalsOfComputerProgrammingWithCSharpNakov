// Write a program that reads from the console a series of integers and 
// prints the smallest and largest of them.

namespace Ch6Q3
{
    public static class SmallestLargest
    {
        public static void Main()
        {
            List<int> nums = new List<int>();
            bool isInt;

            Console.WriteLine("Program to find smallest and greatest number from "
                + "given numbers");
            do
            {
                int x;
                Console.Write("Enter integer: ");
                isInt = Int32.TryParse(Console.ReadLine(), out x);
                if (isInt)
                {
                    nums.Add(x);
                }
            }
            while (isInt || nums.Count == 0);

            Console.WriteLine($"\nSmallest num = {GetMin(nums)}" +
                $"\nGreatest num = {GetMax(nums)}");
        }


        private static int GetMin(List<int> nums)
        {
            // Method to find smallest number
            // Can use 'Sort' method instead

            int min = nums[0];

            foreach(int num in nums)
            {
                if(num < min)
                {
                    min = num;
                }
            }

            return min;
        }


        private static int GetMax(List<int> nums)
        {
            // Method to find greatest number
            // Can use 'Sort' method instead

            int max = nums[0];

            foreach(int num in nums)
            {
                if(num > max)
                {
                    max = num;
                }
            }

            return max;
        }
    }
}