// Write a program that reads five integer numbers and prints their 
// sum. If an invalid number is entered the program should prompt the user 
// to enter another number.


namespace Ch4Q7
{
    public static class SumFiveNums
    {
        public static void Main()
        {
            int num1, num2, num3, num4, num5;

            Console.WriteLine("Program to find sum of five given integers");
            num1 = ReadNum("Enter first integer: ");
            num2 = ReadNum("Enter second integer: ");
            num3 = ReadNum("Enter third integer: ");
            num4 = ReadNum("Enter fourth integer: ");
            num5 = ReadNum("Enter fiveth integer: ");

            Console.WriteLine($"\nSum: {num1 + num2 + num3 + num4 + num5}");
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
    }
}