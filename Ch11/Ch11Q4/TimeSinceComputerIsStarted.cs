using System;

namespace Ch11Q4
{
    class TimeSinceComputerIsStarted
    {
        static void Main()
        {
            long milliseconds = Environment.TickCount64;

            Console.WriteLine("Progrm to find the time elapsed since computer is started");
            Console.WriteLine($"Elapsed time = {GetElapsedTime(milliseconds)}");
        }


        static string GetElapsedTime(long milliseconds)
        {
            long days = 0;
            long hours = 0;
            long minutes = 0;
            long seconds = 0;

            if(milliseconds >= 86400000)
            {
                days = milliseconds / 86400000;
                milliseconds %= 86400000;
            }

            if(milliseconds >= 3600000)
            {
                hours = milliseconds / 3600000;
                milliseconds %= 3600000;
            }

            if(milliseconds >= 60000)
            {
                minutes = milliseconds / 60000;
                milliseconds %= 60000;
            }

            if(milliseconds >= 1000)
            {
                seconds = milliseconds / 1000;
                milliseconds %= 1000;
            }

            if(days == 0 && hours == 0 && minutes == 0 && seconds == 0)
            {
                return $"Milliseconds = {milliseconds}";
            }
            else if(days == 0 && hours == 0 && minutes == 0 && seconds != 0)
            {
                return $"Seconds = {seconds} and milliseconds = {milliseconds}";
            }
            else if(days == 0 && hours == 0 && minutes != 0 && seconds == 0)
            {
                return $"Minutes = {minutes} and milliseconds = {milliseconds}";
            }
            else if(days == 0 && hours == 0 && minutes != 0 && seconds != 0)
            {
                return $"Minutes = {minutes}, seconds = {seconds} and milliseconds = {milliseconds}";
            }
            else if(days == 0 && hours != 0 && minutes == 0 && seconds == 0)
            {
                return $"Hours = {hours} and milliseconds = {milliseconds}";
            }
            else if(days == 0 && hours != 0 && minutes == 0 && seconds != 0)
            {
                return $"Hours = {hours}, seconds = {seconds} and milliseconds = {milliseconds}";
            }
            else if(days == 0 && hours != 0 && minutes != 0 && seconds == 0)
            {
                return $"Hours = {hours}, minutes = {minutes} and milliseconds = {milliseconds}";
            }
            else if(days == 0 && hours != 0 && minutes != 0 && seconds != 0)
            {
                return $"Hours = {hours}, minutes = {minutes}, seconds = {seconds} and milliseconds = {milliseconds}";
            }
            else if(days != 0 && hours == 0 && minutes == 0 && seconds == 0)
            {
                return $"Days = {days} and milliseconds = {milliseconds}";
            }
            else if(days != 0 && hours == 0 && minutes == 0 && seconds != 0)
            {
                return $"Days = {days}, seconds = {seconds} and milliseconds = {milliseconds}";
            }
            else if(days != 0 && hours == 0 && minutes != 0 && seconds == 0)
            {
                return $"Days = {days}, minutes = {minutes} and milliseconds = {milliseconds}";
            }
            else if(days != 0 && hours == 0 && minutes != 0 && seconds != 0)
            {
                return $"Days = {days}, minutes = {minutes}, seconds = {seconds} and milliseconds = {milliseconds}";
            }
            else if(days != 0 && hours != 0 && minutes == 0 && seconds == 0)
            {
                return $"Days = {days}, hours = {hours} and milliseconds = {milliseconds}";
            }
            else if(days != 0 && hours != 0 && minutes == 0 && seconds != 0)
            {
                return $"Days = {days}, hours = {hours}, seconds = {seconds} and milliseconds = {milliseconds}";
            }
            else if(days != 0 && hours != 0 && minutes != 0 && seconds == 0)
            {
                return $"Days = {days}, hours = {hours}, minutes = {minutes} and milliseconds = {milliseconds}";
            }
            else
            {
                return $"Days = {days}, hours = {hours}, minutes = {minutes}, seconds = {seconds} and milliseconds = {milliseconds}";
            }
        }
    }
}
