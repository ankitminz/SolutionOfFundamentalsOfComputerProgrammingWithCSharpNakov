// Write a method that prints the digits of a given decimal number in a 
// reversed order. For example 256, must be printed as 652.

namespace Ch9Q7
{
    public static class ReverseDigits
    {
        private static void Main()
        {
            int num;

            Console.WriteLine("Program to print the digits of a given number in reverse " +
                "order");
            num = GetInt("Enter a number = ");
            Console.WriteLine();
            PrintNumInReverse(num);
        }


        private static int GetInt(string prompt)
        {
            // Method to take user input as int

            int num;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if (!isInt)
                {
                    Console.WriteLine("\nEnter a valid integer 'x' such that" +
                        $"\n{Int32.MinValue} <= x <= {Int32.MaxValue}");
                }
            }
            while (!isInt);

            return num;
        }


        private static void PrintNumInReverse(int num)
        {
            // Method to print given number in reverse

            char[] s = num.ToString().ToCharArray();

            for(int i = s.Length - 1; i >= 0; i--)
            {
                if(i > 0)
                {
                    Console.Write(s[i]);
                }
                else
                {
                    Console.WriteLine(s[i]);
                }
            }
        }
    }
}