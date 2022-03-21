// Write a Boolean expression that checks if the bit on position p in the 
// integer v has the value 1. Example v=5, p = 1-> false.


namespace Ch3Q12
{
    public class BitChecker
    {
        public static void Main()
        {
            int num;
            bool isInt;
            byte position;
            bool isByte;

            Console.WriteLine("Program to check whether bit on given position in given number is 1 or 0");
            Console.WriteLine("Enter an integer");
            do
            {
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if (!isInt)
                {
                    Console.WriteLine($"\nEnter a valid integer 'x' such that\n{Int32.MinValue} <= x <= {Int32.MaxValue}");
                }
            }
            while(!isInt);

            Console.WriteLine("\nEnter position of bit");
            do
            {
                isByte = Byte.TryParse(Console.ReadLine(),out position);
                if (!isByte)
                {
                    Console.WriteLine($"\nEnter a valid positive integer 'x' such that\n{Byte.MinValue} <= x <= {Byte.MaxValue}");
                }
            }
            while (!isByte);

            Console.WriteLine($"\nIs bit on position {position} of number {num} is 1");
            Console.WriteLine(IsBitOne(num, position));
        }


        private static bool IsBitOne(int num, byte position)
        {
            // Method to check whether bit on given position of given number is 1

            int powerOfTwo = (int)Math.Pow(2, position);

            if((num & powerOfTwo) == powerOfTwo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}