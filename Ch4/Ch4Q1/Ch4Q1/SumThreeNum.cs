// Write a program that reads from the console three numbers of type int
// and prints their sum.

namespace Ch4Q1
{
    public class SumThreeNum
    {
        public static void Main()
        {
            int num1, num2, num3;

            Console.WriteLine("Program to sum three given integers");
            Console.WriteLine("Enter three integers");
            num1 = ReadNum("First number: ");
            num2 = ReadNum("Second number: ");
            num3 = ReadNum("Third number: ");
            Console.WriteLine($"\nSum of given numbers: {Sum(num1, num2, num3)}");
        }


        static int ReadNum(string prompt)
        {
            // Method to read user input and parse it to Int32

            int num;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if (!isInt)
                {
                    Console.WriteLine($"\nEnter a valid integer x such that\n{Int32.MinValue} <= x <= {Int32.MaxValue}");
                }
            }
            while (!isInt);

            return num;
        }


        static int? Sum(params int[] nums)
        {
            int sum = 0;

            foreach (int num in nums)
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
                    Console.WriteLine($"Error: {e.ToString()}\nSum is either too large or too small");
                    return null;
                }
            }

            return sum;
        }
    }
}