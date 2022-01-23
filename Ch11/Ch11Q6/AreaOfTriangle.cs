using System;

namespace Ch11Q6
{
    class AreaOfTriangle
    {
        static void Main()
        {
            double area;
            int choice;
            bool isInt;

            Console.WriteLine("Program to find area of triangle when -\n1. Three sides are given\n2. Base and height are given\n3. Two sides and angle between them is given in degrees");
            do
            {
                isInt = Int32.TryParse(Console.ReadLine(), out choice);
                if(!isInt || choice < 1 || choice > 3)
                {
                    Console.WriteLine("\nEnter 1, 2 or 3 depending on what is given");
                }
            }
            while (!isInt || choice < 1 || choice > 3);

            Console.WriteLine();
            switch (choice)
            {
                case 1:
                    double a, b, c;

                    a = GetValidSide("Enter first side - ");
                    b = GetValidSide("Enter second side - ");
                    c = GetValidSide("Enter third side - ");
                    area = ThreeSidesGiven(a, b, c);
                    Console.WriteLine($"\nArea of triangle with sides {a}, {b} and {c} is {area:f2}");
                    break;

                case 2:
                    double side, height;

                    side = GetValidSide("Enter base of triangle - ");
                    height = GetValidSide("Enter height of triangle - ");
                    area = SideAndHeightGiven(side, height);
                    Console.WriteLine($"\nArea of triangle with base {side} and height {height} is {area:f2}");
                    break;

                case 3:
                    double side1, side2, angle;
                    bool isDouble;

                    side1 = GetValidSide("Enter first side - ");
                    side2 = GetValidSide("Enter second side - ");
                    do
                    {
                        Console.Write("Enter angle between given sides in degrees - ");
                        isDouble = Double.TryParse(Console.ReadLine(), out angle);
                        if(!isDouble || angle <= 0 || angle >= 360)
                        {
                            Console.WriteLine("\nEnter angle theta(in degrees) such that\n0 < theta < 360");
                        }
                    }
                    while (!isDouble || angle <= 0 || angle >= 360);

                    area = TwoSidesAndAngleGiven(side1, side2, angle);
                    Console.WriteLine($"\nArea of triangle with sides {side1} and {side2} making angle {angle} degree is {area:f2}");
                    break;

                default:
                    Console.WriteLine("Oops! Some error occured");
                    break;
            }
        }


        static double ThreeSidesGiven(double a, double b, double c)
        {
            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }


        static double SideAndHeightGiven(double b, double h)
        {
            return 0.5 * b * h;
        }


        static double TwoSidesAndAngleGiven(double a, double b, double angle)
        {
            double radian = (angle * Math.PI) / 180;
            return 0.5 * a * b * Math.Sin(radian);
        }


        static double GetValidSide(string prompt = "")
        {
            double temp;
            bool isDouble;

            do
            {
                Console.Write(prompt);
                isDouble = Double.TryParse(Console.ReadLine(), out temp);
                if(!isDouble || temp <= 0)
                {
                    Console.WriteLine("\nLength should be a positive real number");
                }
            }
            while (!isDouble || temp <= 0);

            return temp;
        }
    }
}
