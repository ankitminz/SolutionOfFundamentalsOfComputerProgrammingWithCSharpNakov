using System;

namespace Ch11Q1
{
    class CheckIfItIsLeapYear
    {
        static void Main()
        {
            int year;
            bool isInt;

            Console.WriteLine("Program to find whether given year is a leap year or not");
            Console.WriteLine("Enter a year");
            do
            {
                isInt = Int32.TryParse(Console.ReadLine(), out year);
                if (!isInt || year < 1 || year > 9999)
                {
                    Console.WriteLine("\nEnter a valid positive integer x such that 1 <= x <= 9999");
                }
            }
            while (!isInt || year < 1 || year > 9999);

            if (DateTime.IsLeapYear(year))
            {
                Console.WriteLine($"\n{year} is a leap year");
            }
            else
            {
                Console.WriteLine($"\n{year} is not a leap year");
            }

            // Another way to check whether given year is a leap year
            /*
            if(year % 4 == 0)
            {
                Console.WriteLine($"\n{year} is a leap year");
            }
            else
            {
                Console.WriteLine($"\n{year} is not a leap year");
            }
            */
        }
    }
}
