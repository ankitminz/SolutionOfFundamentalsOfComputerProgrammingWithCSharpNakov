// *Write a program that exchanges bits {p, p+1, …, p+k-1} with bits
// {q, q+1, …, q+k-1}
// of a given 32-bit unsigned integer.


namespace Ch3Q16
{
    public class ExchangeBitsExpression
    {
        public static void Main()
        {
            uint num;
            bool isUInt;
            byte p, q, k;
            bool isByte;

            Console.WriteLine("Program to exchange bits {p, p + 1, ... , p + k - 1} with bits {q, q + 1, .... , q + k - 1} of given number");
            Console.WriteLine("Enter a positive integer");
            do
            {
                isUInt = UInt32.TryParse(Console.ReadLine(), out num);
                if (!isUInt)
                {
                    Console.WriteLine($"\nEnter a valid positive integer 'x' such that\n{UInt32.MinValue} <= x <= {UInt32.MaxValue}");
                }
            }
            while (!isUInt);

            Console.WriteLine();
            do
            {
                Console.WriteLine("Enter value of p");
                isByte = Byte.TryParse(Console.ReadLine(),out p);
                if (!isByte)
                {
                    Console.WriteLine($"\nEnter a valid positive integer 'p' such that\n{Byte.MinValue} <= p <= {Byte.MaxValue}");
                }
            }
            while (!isByte);

            Console.WriteLine();
            do
            {
                Console.WriteLine("Enter value of q");
                isByte = Byte.TryParse(Console.ReadLine(), out q);
                if(!isByte || q == p)
                {
                    Console.WriteLine($"\nEnter a valid positive integer 'q' such that\n{Byte.MinValue} <= q <= {Byte.MaxValue} and q not eqaul to {p}");
                }
            }
            while(!isByte || q == p);

            Console.WriteLine();
            do
            {
                Console.WriteLine("Enter value of k");
                isByte = Byte.TryParse(Console.ReadLine(), out k);
                if(!isByte || k < 2)
                {
                    Console.WriteLine($"\nEnter a valid positive integer 'k' such that\n{Byte.MinValue} <= k <= {Byte.MaxValue} and k >= 2");
                }
            }
            while (!isByte || k < 2);

            Console.WriteLine($"\nResultant after exchanging bits\n{ExchangeBits(num, p, q, k)}");
        }


        private static uint ExchangeBits(uint num, byte _p, byte _q, byte _k)
        {
            // Method to exchange bits {p, p + 1, ... , p + k - 1} with bits {q, q + 1, .... , q + k - 1} of given number

            byte maxP = (byte)(_p + _k - 1);
            byte maxQ = (byte)(_q + _k - 1);

            for (byte p = _p, q = _q, k = _k; p != q && p <= Byte.MaxValue && q <= Byte.MaxValue && p <= maxP && q <= maxQ; p++, q++)
            {
                num = ExchangeBit(num, p, q);
            }

            return num;
        }


        private static uint ExchangeBit(uint num, byte position1, byte position2)
        {
            // Method to determine bit value at position1 and position2 and call method to
            // change bits if they are different

            // (START) Logic to determine the value of bit at position1 and position2
            uint powerOfTwo1 = (uint)Math.Pow(2, position1);
            uint powerOfTwo2 = (uint)Math.Pow(2, position2);
            bool isBitOneInPosition1 = (num & powerOfTwo1) == powerOfTwo1;
            bool isBitOneInPosition2 = (num & powerOfTwo2) == powerOfTwo2;
            // (END)

            // Calling method to change bits when they are different
            if (isBitOneInPosition1 != isBitOneInPosition2)
            {
                num = NotCertainBit(num, position1);
                num = NotCertainBit(num, position2);
            }

            return num;
        }


        private static uint NotCertainBit(uint num, byte position)
        {
            // Method to change bit at given position of given number

            uint powerOfTwo = (uint)Math.Pow(2, position);

            // (START) Logic to determine and change bit at given position in the given number
            if ((num & powerOfTwo) == powerOfTwo)
            {
                num ^= powerOfTwo;
            }
            else
            {
                num |= powerOfTwo;
            }
            // (END)

            return num;
        }
    }
}