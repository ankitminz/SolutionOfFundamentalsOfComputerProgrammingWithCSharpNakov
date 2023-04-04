// Write a method that returns the English name of the last digit of a 
// given number. Example: for 512 prints "two"; for 1024 --> "four".

namespace Ch9Q3
{
    public static class EnglishName
    {
        private static void Main()
        {
            long num;

            Console.WriteLine("Program to print name of last digit of given integer");
            num = GetLong("Enter an integer = ");
            Console.WriteLine(GetLastDigitName(num));
        }


        private static long GetLong(string prompt)
        {
            // Method to take user input as long datatype

            long num;
            bool isLong;

            do
            {
                Console.Write(prompt);
                isLong = Int64.TryParse(Console.ReadLine(), out num);
                if (!isLong)
                {
                    Console.WriteLine("\nEnter a valid integer 'x' such that" + 
                        $"\n{Int64.MinValue} <= x <= {Int64.MaxValue}");
                }
            }
            while (!isLong);

            return num;
        }


        private static string GetLastDigitName(long num)
        {
            // Method to return name of last digit of given number

            Dictionary<int, string> numName = new Dictionary<int, string>
            {
                [0] = "Zero",
                [1] = "One",
                [2] = "Two",
                [3] = "Three",
                [4] = "Four",
                [5] = "Five",
                [6] = "Six",
                [7] = "Seven",
                [8] = "Eight",
                [9] = "Nine"
            };

            int onesDigit = (int)Math.Abs(num % 10);

            return numName[onesDigit];
        }
    }
}