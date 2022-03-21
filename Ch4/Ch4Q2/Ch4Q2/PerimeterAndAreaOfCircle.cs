// Write a program that reads from the console the radius "r" of a circle 
// and prints its perimeter and area.


namespace Ch4Q2
{
    public static class PerimeterAndAreaOfCircle
    {
        public static void Main()
        {
            double radius;
            bool isDouble;

            Console.WriteLine("Program to find perimeter and area of circle of given " +
                "radius");
            do
            {
                Console.Write("Enter radius: ");
                isDouble = Double.TryParse(Console.ReadLine(), out radius);
                if(!isDouble || radius < 0d)
                {
                    Console.WriteLine("\nEnter a valid positive real number greater than 0");
                }
            }
            while (!isDouble || radius < 0d);

            double perimeter = 2 * Math.PI * radius;
            double area = Math.PI * Math.Pow(radius, 2);
            Console.WriteLine($"\nPerimeter of circle: {perimeter:F2}\n" +
                $"Area of circle: {area:F2}");
        }
    }
}