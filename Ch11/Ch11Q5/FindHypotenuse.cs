using System;

namespace Ch11Q5
{
    class FindHypotenuse
    {
        static void Main()
        {
            double firstSide;
            double secondSide;
            double hypotenuse;
            bool isDouble;

            Console.WriteLine("Program to find hypotenuse of a right angle triangle");
            Console.WriteLine("Enter first side");
            do
            {
                isDouble = Double.TryParse(Console.ReadLine(), out firstSide);
                if(!isDouble || firstSide <= 0)
                {
                    Console.WriteLine($"\nEnter a valid positive integer x such that 0 < x");
                }
            }
            while (!isDouble || firstSide <= 0);

            Console.WriteLine("\nEnter second side");
            do
            {
                isDouble = Double.TryParse(Console.ReadLine(), out secondSide);
                if(!isDouble || secondSide <= 0)
                {
                    Console.WriteLine($"\nEnter a valid positive integer x such that 0 < x");
                }
            }
            while (!isDouble || secondSide <= 0);

            hypotenuse = Math.Sqrt(Math.Pow(firstSide, 2) + Math.Pow(secondSide, 2));
            Console.WriteLine($"\nHypotenuse = {hypotenuse:f2}");
        }
    }
}
