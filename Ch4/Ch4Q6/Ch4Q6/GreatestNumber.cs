// Write a program that reads two numbers from the console and prints the 
// greater of them. Solve the problem without using conditional
// statements.

namespace Ch4Q6
{
    public static class GreatestNumber
    {
        public static void Main()
        {
            int num1, num2;

            Console.WriteLine("Program to find greatest integer from two given integers");
            num1 = ReadNum("Enter first integer: ");
            num2 = ReadNum("Enter second integer: ");
            Console.WriteLine($"\nGreatest integer: {Math.Max(num1, num2)}");
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
                        $"{Int32.MinValue} <= x <= {int.MaxValue}");
                }
            }
            while (!isInt);

            return num;
        }
    }
}