// Write a program that finds the biggest of three integers, using nested if statements.

namespace Ch5Q3
{
    public static class Greatest
    {
        public static void Main()
        {
            int num1, num2, num3;

            Console.WriteLine("Program to find greatest of three given integers");
            num1 = ReadNum("First num: ");
            num2 = ReadNum("Second num: ");
            num3 = ReadNum("Third num: ");
            Console.Write("Grestest num: ");
            if(num1 > num2)
            {
                if(num1 > num3)
                {
                    Console.WriteLine(num1);
                }
                else
                {
                    Console.WriteLine(num3);
                }
            }
            else if(num2 > num1)
            {
                if(num2 > num3)
                {
                    Console.WriteLine(num2);
                }
                else
                {
                    Console.WriteLine(num3);
                }
            }
            else if(num3 > num1)
            {
                Console.WriteLine(num3);
            }
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