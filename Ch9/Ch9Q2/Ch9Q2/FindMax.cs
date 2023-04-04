// Create a method GetMax() with two integer (int) parameters, that
// returns maximal of the two numbers. Write a program that reads three 
// numbers from the console and prints the biggest of them. Use the 
// GetMax() method you just created. Write a test program that validates 
// that the methods works correctly.

namespace Ch9Q2
{
    public static class FindMax
    {
        private static void Main()
        {
            int a, b, c;

            Console.WriteLine("Program to find maximum of three given integers");
            a = GetInt("Enter first number = ");
            b = GetInt("Enter second number = ");
            c = GetInt("Enter third number = ");

            Console.WriteLine($"Biggest number = {GetMax(GetMax(a, b), c)}");
        }


        private static int GetInt(string prompt)
        {
            // Method to take user input integer value

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


        private static int GetMax(int num1, int num2)
        {
            // Method to return maximum of two given integer values

            return num1 > num2 ? num1 : num2;
        }
    }
}