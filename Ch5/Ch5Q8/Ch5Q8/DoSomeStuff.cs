// Write a program that, depending on the user’s choice, inputs int, double
// or string variable. If the variable is int or double, the program 
// increases it by 1. If the variable is a string, the program appends "*" at 
// the end. Print the result at the console. Use switch statement.

namespace Ch5Q8
{
    public static class DoSomeStuff
    {
        public static void Main()
        {
            double someNum;
            string someString;
            bool isDouble;

            Console.WriteLine("Program to add 1 if user enters a real number and appends 'x' " +
                "if user enters a string");
            Console.Write("Enter a number or string: ");
            someString = Console.ReadLine();
            isDouble = Double.TryParse(someString, out someNum);
            switch (isDouble)
            {
                case true:
                    {
                        Console.WriteLine($"New num: {someNum + 1}");
                        break;
                    }

                case false:
                    {
                        Console.WriteLine($"New string: {someString + "*"}");
                        break;
                    }
            }
        }
    }
}