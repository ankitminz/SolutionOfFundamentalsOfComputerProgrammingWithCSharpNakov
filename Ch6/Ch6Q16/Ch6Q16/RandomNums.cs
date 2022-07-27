// Write a program that by a given integer N prints the numbers from 1 to N 
// in random order.

namespace Ch6Q16
{
    public static class RandomNums
    {
        public static void Main()
        {
            int n;
            bool isInt;
            Random rnd = new Random();

            Console.WriteLine("Program to print numbers from 1 to 'n' in random order");
            do
            {
                Console.Write("n = ");
                isInt = Int32.TryParse(Console.ReadLine(), out n);
                if(!isInt || n < 1)
                {
                    Console.WriteLine($"\nEnter a valid positive integer 'n'" +
                        $"\nsuch that 0 < n <= {Int32.MaxValue}");
                }
            }
            while (!isInt || n < 1);

            int[] nums = new int[n];

            for(int i = 0; i < n; i++)
            {
                nums[i] = i + 1;
            }

            for(int i = 0; i < n / 2; i++)
            {
                int index1 = rnd.Next(0, n);
                int index2 = rnd.Next(0, n);
                int temp = nums[index1];
                nums[index1] = nums[index2];
                nums[index2] = temp;
            }

            Console.WriteLine();
            foreach(int num in nums)
            {
                Console.WriteLine(num);
            }
        }
    }
}