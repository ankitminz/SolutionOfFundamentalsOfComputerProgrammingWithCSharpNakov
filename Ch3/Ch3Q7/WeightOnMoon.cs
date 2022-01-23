namespace Ch3Q7
{
    public class WeightOnMoon
    {
        public static void Main()
        {
            double weightOnEarth;
            bool isDouble;

            Console.WriteLine("Program to find weight on moon by given weight on earth");
            Console.WriteLine("Enter your mass on earth");
            do
            {
                isDouble = Double.TryParse(Console.ReadLine(), out weightOnEarth);
                if(!isDouble || weightOnEarth <= 0)
                {
                    Console.WriteLine($"\nEnter a valid mass 'x' such that\n 0 < x <= {Double.MaxValue}");
                }
            }
            while (!isDouble || weightOnEarth <= 0);

            double weightOnMoon = weightOnEarth * 0.17;
            Console.WriteLine($"\nYour mass on moon = {weightOnMoon:F2}");
        }
    }
}