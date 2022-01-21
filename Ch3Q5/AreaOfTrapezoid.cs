namespace Ch3Q5
{
    public class AreaOfTrapezoid
    {
        public static void Main()
        {
            // a and b are parallel sides, h is height between them
            double a, b, h, area;

            Console.WriteLine("Program to find area of trapezoid");
            a = GetPositiveDouble("Enter length of first parallel side");
            b = GetPositiveDouble("\nEnter length of second parallel side");
            h = GetPositiveDouble("\nEnter heigth between parallel sides");
            area = ((a + b) / 2) * h;
            Console.WriteLine($"\nArea of trapezoid with sides {a}, {b} and height {h} is {area} square unit");
        }


        private static double GetPositiveDouble(string userInput)
        {
            // Method to get user input

            double num;
            bool isDouble;

            Console.WriteLine(userInput);
            do
            {
                isDouble = Double.TryParse(Console.ReadLine(), out num);
                if(!isDouble || num <= 0)
                {
                    Console.WriteLine($"\nEnter a positive number 'x' such that\n 0 < x <= {Double.MaxValue}");
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
                    Console.WriteLine($"\nEnter a positive number 'x' such that\n 0 < x <= {Double.MaxValue}");
                }
            }
            while (!isDouble || num <= 0);

            return num;
        }
    }
}