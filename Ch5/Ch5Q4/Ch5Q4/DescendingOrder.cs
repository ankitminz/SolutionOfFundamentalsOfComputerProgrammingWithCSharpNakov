// Sort 3 real numbers in descending order. Use nested if statements.

namespace Ch5Q4
{
    public static class DescendingOrder
    {
        public static void Main()
        {
            double num1, num2, num3;
            double[] nums = new double[3];

            Console.WriteLine("Program to sort three given real numbers in descending order");
            num1 = ReadNum("First num: ");
            num2 = ReadNum("Second num: ");
            num3 = ReadNum("Third num: ");

            if(num1 > num2 && num1 > num3)
            {
                nums[0] = num1;
                if(num2 > num3)
                {
                    nums[1] = num2;
                    nums[2] = num3;
                }
                else
                {
                    nums[1] = num3;
                    nums[2] = num2;
                }
            }
            else if(num2 > num1 && num2 > num3)
            {
                nums[0] = num2;
                if(num1 > num3)
                {
                    nums[1] = num1;
                    nums[2] = num3;
                }
                else
                {
                    nums[1] = num3;
                    nums[2] = num1;
                }
            }
            else if(num3 > num1 && num3 > num2)
            {
                nums[0] = num3;
                if(num2 > num1)
                {
                    nums[1] = num2;
                    nums[2] = num1;
                }
                else
                {
                    nums[1] = num1;
                    nums[2] = num2;
                }
            }
            else
            {
                for(int i = 0; i < nums.Length; i++)
                {
                    nums[i] = num1;
                }
            }

            Console.Write($"\nDescending order: ");
            for(int i = 0; i < nums.Length; i++)
            {
                if(i < nums.Length - 1)
                {
                    Console.Write($"{nums[i]}, ");
                }
                else
                {
                    Console.WriteLine(nums[i]);
                }
            }
        }


        static double ReadNum(string prompt)
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
    }
}