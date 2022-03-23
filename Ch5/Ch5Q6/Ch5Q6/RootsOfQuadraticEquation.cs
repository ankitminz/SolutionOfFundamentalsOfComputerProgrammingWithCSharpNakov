// Write a program that gets the coefficients a, b and c of a quadratic 
// equation: ax^2 + bx + c, calculates and prints its real roots (if they exist). 
// Quadratic equations may have 0, 1 or 2 real roots.

namespace Ch5Q6
{
    public static class RootsOfQuadraticEquation
    {
        public static void Main()
        {
            double a, b, c, root1 = 0, root2 = 0;
            bool isReal = false;

            Console.WriteLine("Program to find roots of given quadratic equation(ax^2 + bx + c)");
            a = ReadNum("a: ");
            b = ReadNum("b: ");
            c = ReadNum("c: ");

            double d = Math.Pow(b, 2) - (4 * a * c);

            if(d > 0)
            {
                root1 = (-b + Math.Sqrt(d)) / (2 * a);
                root2 = (-b - Math.Sqrt(d)) / (2 * a);
                isReal = true;
            }
            else if(d == 0)
            {
                root1 = root2 = -b / (2 * a);
                isReal = true;
            }
            else
            {
                Console.WriteLine("\nNo real roots exist");
            }

            if (isReal)
            {
                Console.WriteLine($"\nRoot1: {root1:F2}\n" +
                    $"Root2: {root2:F2}");
            }
        }


        static double ReadNum(string prompt)
        {
            double num;
            bool isDouble;

            do
            {
                Console.Write(prompt);
                isDouble = Double.TryParse(Console.ReadLine(), out num);
                if (!isDouble)
                {
                    Console.WriteLine("\nEnter a valid real number");
                }
            }
            while (!isDouble);

            return num;
        }
    }
}