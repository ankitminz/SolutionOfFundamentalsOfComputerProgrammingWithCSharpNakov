// Write an expression that checks for given point {x, y} if it is within the
// circle K({ 0, 0}, R = 5) and out of the rectangle [{-1, 1}, { 5, 5}]. 
// Clarification: for the rectangle the lower left and the upper right corners
// are given.


namespace Ch3Q9
{
    public class WithinCircleOutsideRectangle
    {
        public static void Main()
        {
            // Center of circle
            double c1 = 0, c2 = 0;

            // Radius of circle
            double r = 5;

            // Lower left corner of rectangle
            double x1 = -1, y1 = 1;

            // Upper right corner of rectangle
            double x2 = 5, y2 = 5;

            // Coordinates of given point
            double x, y;

            Console.WriteLine("Program to check whether given point is within circle(centre-(0, 0), radius-5) and outside rectangle((-1, 1), (5, 5))");
            x = GetDouble("Enter x coordinate of the point");
            y = GetDouble("\nEnter y coordinate of the point");
            double distanceFromCenter = Math.Sqrt(Math.Pow(x - c1, 2) + Math.Pow(y - c2, 2));
            bool isWithinCircle = distanceFromCenter <= r;
            bool isOutsideRectangle = (x < x1 || x > x2 || y < y1 || y > y2);

            if(isWithinCircle && isOutsideRectangle)
            {
                Console.WriteLine($"\nThe point ({x}, {y}) is within circle(center({c1}, {c2}), radius-{r}) and outside rectangle(({x1}, {y1}), ({x2}, {y2}))");
            }
            else if(isWithinCircle && !isOutsideRectangle)
            {
                Console.WriteLine($"\nThe point ({x}, {y}) is within circle(center({c1}, {c2}), radius-{r}) and within rectangle(({x1}, {y1}), ({x2}, {y2}))");
            }
            else if(!isWithinCircle && isOutsideRectangle)
            {
                Console.WriteLine($"\nThe point ({x}, {y}) is outside circle(center({c1}, {c2}), radius-{r}) and outside rectangle(({x1}, {y1}), ({x2}, {y2}))");
            }
            else
            {
                Console.WriteLine($"\nThe point ({x}, {y}) is outside circle(center({c1}, {c2}), radius-{r}) and within rectangle(({x1}, {y1}), ({x2}, {y2}))");
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