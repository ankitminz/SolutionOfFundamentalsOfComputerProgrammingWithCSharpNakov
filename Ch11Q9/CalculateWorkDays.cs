using System;

namespace Ch11Q9
{
    class CalculateWorkDays
    {
        static void Main()
        {
            DateTime[] holidays =
            {
                new DateTime(2021, 1, 1),
                new DateTime(2021, 1, 13),
                new DateTime(2021, 1, 14),
                new DateTime(2021, 1, 20),
                new DateTime(2021, 1, 26),
                new DateTime(2021, 2, 16),
                new DateTime(2021, 2, 19),
                new DateTime(2021, 2, 27),
                new DateTime(2021, 3, 8),
                new DateTime(2021, 3, 11),
                new DateTime(2021, 3, 28),
                new DateTime(2021, 3, 29),
                new DateTime(2021, 4, 2),
                new DateTime(2021, 4, 4),
                new DateTime(2021, 4, 13),
                new DateTime(2021, 4, 14),
                new DateTime(2021, 4, 15),
                new DateTime(2021, 4, 21),
                new DateTime(2021, 4, 25),
                new DateTime(2021, 5, 7),
                new DateTime(2021, 5, 9),
                new DateTime(2021, 5, 14),
                new DateTime(2021, 5, 26),
                new DateTime(2021, 7, 12),
                new DateTime(2021, 7, 21),
                new DateTime(2021, 8, 15),
                new DateTime(2021, 8, 16),
                new DateTime(2021, 8, 20),
                new DateTime(2021, 8, 21),
                new DateTime(2021, 8, 22),
                new DateTime(2021, 8, 30),
                new DateTime(2021, 9, 12),
                new DateTime(2021, 10, 2),
                new DateTime(2021, 10, 7),
                new DateTime(2021, 10, 11),
                new DateTime(2021, 10, 12),
                new DateTime(2021, 10, 13),
                new DateTime(2021, 10, 14),
                new DateTime(2021, 10, 15),
                new DateTime(2021, 10, 19),
                new DateTime(2021, 10, 20),
                new DateTime(2021, 10, 24),
                new DateTime(2021, 10, 25),
                new DateTime(2021, 11, 4),
                new DateTime(2021, 11, 5),
                new DateTime(2021, 11, 6),
                new DateTime(2021, 11, 10),
                new DateTime(2021, 11, 19),
                new DateTime(2021, 11, 24),
                new DateTime(2021, 12, 24),
                new DateTime(2021, 12, 25),
            };

            DateTime[] workingSat =
            {
                new DateTime(2021, 6, 5),
                new DateTime(2021, 6, 12),
                new DateTime(2021, 6, 19),
                new DateTime(2021, 6, 26),
                new DateTime(2021, 9, 4),
                new DateTime(2021, 9, 11),
                new DateTime(2021, 9, 18),
                new DateTime(2021, 9, 25),
            };

            DateTime tillDate;
            DateTime smallest = new DateTime(2021, 1, 1);
            DateTime biggest = new DateTime(2021, 12, 31);
            bool isDateTime;
            
            Console.WriteLine("Program to calculate number of working days between current date and given date inclusively");
            do
            {
                Console.Write("Enter date(dd/mm/yyyy) - ");
                isDateTime = DateTime.TryParse(Console.ReadLine(), out tillDate);
                if(!isDateTime || tillDate < smallest || tillDate > biggest)
                {
                    Console.WriteLine($"\nEnter a valid date between {smallest} and {biggest} inclusively in dd/mm/yyyy format");
                }
            }
            while (!isDateTime || tillDate < smallest || tillDate > biggest);

            Console.WriteLine(GetWorkDays(tillDate, holidays, workingSat));
        }


        static int GetWorkDays(DateTime tillDate, DateTime[] holidays, DateTime[] workingSat)
        {
            DateTime startDate = DateTime.Today;
            int workingDays = 0;
            bool isHoliday;

            for(DateTime currentDate = startDate; currentDate <= tillDate; currentDate = currentDate.AddDays(1))
            {
                isHoliday = false;

                if(currentDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue;
                }

                for(int i = 0; i < holidays.Length; i++)
                {
                    isHoliday = currentDate == holidays[i];
                    if (isHoliday)
                    {
                        break;
                    }
                }

                if (isHoliday)
                {
                    continue;
                }

                if(currentDate.DayOfWeek != DayOfWeek.Saturday)
                {
                    workingDays++;
                    continue;
                }

                for(int i = 0; i < workingSat.Length; i++)
                {
                    if(currentDate == workingSat[i])
                    {
                        workingDays++;
                        break;
                    }
                }
            }

            return workingDays;
        }
    }
}
