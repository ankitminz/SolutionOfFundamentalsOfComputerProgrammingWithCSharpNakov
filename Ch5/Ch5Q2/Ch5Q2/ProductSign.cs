// Write a program that shows the sign (+ or -) of the product of three real 
// numbers, without calculating it. Use a sequence of if operators.

namespace Ch5Q2
{
    public static class ProductSign
    {
        public static void Main()
        {
            int num1, num2, num3;

            Console.WriteLine("Program to find sign of product of three given integers");
            num1 = ReadNum("First num: ");
            num2 = ReadNum("Second num: ");
            num3 = ReadNum("Third num: ");

            if(num1 == 0 || num2 == 0 || num3 == 0)
            {
                Console.WriteLine("Product is Zero");
            }
            else if((num1 > 0 && num2 > 0 && num3 > 0) || (num1 < 0 && num2 < 0 && num3 > 0) || (num1 < 0 && num2 > 0 && num3 < 0) || (num1 > 0 && num2 < 0 && num3 < 0))
            {
                Console.WriteLine("Product is +ve");
            }
            else
            {
                Console.WriteLine("Product is -ve");
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