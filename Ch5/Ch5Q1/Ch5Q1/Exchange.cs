// Write an if-statement that takes two integer variables and exchanges
// their values if the first one is greater than the second one.

namespace Ch5Q1
{
    public static class Exchange
    {
        public static void Main()
        {
            int num1, num2;

            Console.WriteLine("Program to swap given integers if first one is greater");
            num1 = ReadNum("First num: ");
            num2 = ReadNum("Second num: ");
            if(num1 > num2)
            {
                num1 += num2;
                num2 = num1 - num2;
                num1 -= num2;
            }

            Console.WriteLine($"\nFirst num: {num1}\n" +
                $"Second num: {num2}");
        }


        static int ReadNum(string prompt)
        {
            int num;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if (!isInt)
                {
                    Console.WriteLine($"\nEnter a valid integer x such that\n" +
                        $"{Int32.MinValue} <= x <= {Int32.MaxValue}");
                }
            }
            while (!isInt);

            return num;
        }
    }
}