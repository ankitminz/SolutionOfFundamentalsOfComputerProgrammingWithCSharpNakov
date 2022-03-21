// We are given a number n and a position p. Write a sequence of 
// operations that prints the value of the bit on the position p in the 
// number (0 or 1). Example: n = 35, p = 5-> 1.Another example: n = 35, 
// p = 6-> 0.


namespace Ch3Q11
{
    public class BitOnPositionP
    {
        public static void Main()
        {
            int num;
            byte position;
            bool isInt;
            bool isByte;

            Console.WriteLine("Program to find bit on a given position in the given number");
            Console.WriteLine("Enter an integer");
            do
            {
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if (!isInt)
                {
                    Console.WriteLine($"\nEnter a valid integer 'x' such that\n{Int32.MinValue} <= x <= {Int32.MaxValue}");
                }
            }
            while (!isInt);

            Console.WriteLine("\nEnter the position of bit(right to left, 0 based)");
            do
            {
                isByte = Byte.TryParse(Console.ReadLine(), out position);
                if(!isByte || position < 0)
                {
                    Console.WriteLine($"\nEnter a valid positive integer 'x' such that\n{Byte.MinValue} <= x <= {Byte.MaxValue}");
                }
            }
            while (!isByte || position < 0);

            Console.WriteLine($"\nBit on position {position} of number {num} = {GetBit(num, position)}");
        }


        private static byte GetBit(int num, byte position)
        {
            int powerOfTwo = (int)Math.Pow(2, position);

            if((num & powerOfTwo) == powerOfTwo)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        
    }
}