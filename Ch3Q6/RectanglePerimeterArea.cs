namespace Ch3Q6
{
    public class RectanglePerimeterArea
    {
        public static void Main()
        {
            double a, b, perimeter, area;

            Console.WriteLine("Program to find perimeter and area of rectangle");
            a = GetPositiveDouble("Enter length of first side of rectangle");
            b = GetPositiveDouble("\nEnter length of second side of rectangle");
            perimeter = (a + b) * 2;
            area = a * b;
            Console.WriteLine($"\nPerimeter = {perimeter} unit");
            Console.WriteLine($"Area = {area} square unit");
        }


        private static double GetPositiveDouble(string userPrompt)
        {
            // Method to get user input

            double num;
            bool isDouble;

            Console.WriteLine(userPrompt);
            do
            {
                isDouble = Double.TryParse(Console.ReadLine(), out num);
                if(!isDouble || num <= 0)
                {
                    Console.WriteLine($"\nEnter a valid positive number 'x' such that\n 0 < x <= {Double.MaxValue}");
                }
            }
            while (!isDouble || num <= 0);

            return num;
        }


        private static double GetPositiveDouble()
        {
            // Method to get user input

            double num;
            bool isDouble;

            do
            {
                isDouble = Double.TryParse(Console.ReadLine(), out num);
                if (!isDouble || num <= 0)
                {
                    Console.WriteLine($"\nEnter a valid positive number 'x' such that\n 0 < x <= {Double.MaxValue}");
                }
            }
            while (!isDouble || num <= 0);

            return num;
        }
    }
}