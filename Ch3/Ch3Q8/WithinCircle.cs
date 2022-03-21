// Write an expression that checks for a given point {x, y} if it is within
// the circle K({ 0, 0}, R = 5). Explanation: the point { 0, 0} is the center of
// the circle and 5 is the radius.

namespace Ch3Q8
{
    public class WithinCircle
    {
        public static void Main()
        {
            // Center of circle
            double x1 = 0, y1 = 0;

            // Radius of circle
            double r = 5;

            // Coordinates of given point
            double x2, y2;

            Console.WriteLine("Program to check whether given point in within circle(centre-(0, 0), radius-5)");
            x2 = GetDouble("Enter x coordinate of the point");
            y2 = GetDouble("\nEnter y coordinate of the point");
            double distanceFromCenter = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            if(distanceFromCenter <= r)
            {
                Console.WriteLine($"\nThe given point ({x2}, {y2}) lies in the circle(centre-({x1}, {y1}), radius-{r})");
            }
            else
            {
                Console.WriteLine($"\nThe given point ({x2}, {y2}) lies outside the circle(centre-({x1}, {y1}), radius-{r})");
            }
        }


        private static double GetDouble(string prompt)
        {
            double num;
            bool isDouble;

            Console.WriteLine(prompt);
            do
            {
                isDouble = Double.TryParse(Console.ReadLine(), out num);
                if (!isDouble)
                {
                    Console.WriteLine($"\nEnter a valid real number 'x' such that\n{Double.MinValue} <= x <= {Double.MaxValue}");
                }
            }
            while (!isDouble);

            return num;
        }
    }
}