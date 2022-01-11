using System;

namespace Ch11Q3
{
    class WhichDayOfTheWeekIsToday
    {
        static void Main()
        {
            DateTime today = DateTime.Now;

            Console.WriteLine("Program to find which day of the week is today");
            Console.WriteLine(today.DayOfWeek);
        }
    }
}
