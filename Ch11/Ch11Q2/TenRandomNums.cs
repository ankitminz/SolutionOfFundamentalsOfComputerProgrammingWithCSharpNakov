using System;

namespace Ch11Q2
{
    class TenRandomNums
    {
        static void Main()
        {
            Random rnd = new Random();

            Console.WriteLine("Program to print 10 random numbers between 100 and 200 inclusively");
            for(int i = 1; i <= 10; i++)
            {
                Console.WriteLine(rnd.Next(100, 201));
            }
        }
    }
}
