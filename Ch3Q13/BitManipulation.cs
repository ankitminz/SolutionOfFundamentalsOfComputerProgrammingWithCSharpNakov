// Program to change bit at given position in a given number to a given value

namespace Ch3Q13
{
    public class BitManipulation
    {
        public static void Main()
        {
            int num;
            bool isInt;
            byte position;
            bool isByte;
            byte requiredBit;

            Console.WriteLine("Program to change bit at given position in a given number to a given value");
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

            Console.WriteLine("\nEnter the position of bit");
            do
            {
                isByte = Byte.TryParse(Console.ReadLine(),out position);
                if (!isByte)
                {
                    Console.WriteLine($"\nEnter a valid integer 'x' such that\n{Byte.MinValue} <= x <= {Byte.MaxValue}");
                }
            }
            while (!isByte);

            Console.WriteLine("\nEnter required bit");
            do
            {
                isByte = Byte.TryParse(Console.ReadLine(), out requiredBit);
                if(!isByte || !(requiredBit == 0 || requiredBit == 1))
                {
                    Console.WriteLine("\nEnter either 1 or 0");
                }
            }
            while (!isByte || !(requiredBit == 0 || requiredBit == 1));

            Console.WriteLine($"\nNew number after bit manipulation is {NewNumAfterBitManipulation(num, position, requiredBit)}");
        }


        private static int NewNumAfterBitManipulation(int oldNum, byte position, byte requiredBit)
        {
            int newNum;
            int powerOfTwo = (int)Math.Pow(2, position);

            // Logic for bit manipulation if required bit is 1
            if(requiredBit == 1)
            {
                newNum = oldNum | powerOfTwo;
                return newNum;
            }

            // Logic for bit manipulation if required bit is 0
            if((oldNum & powerOfTwo) == powerOfTwo)
            {
                newNum = oldNum ^ powerOfTwo;
                return newNum;
            }
            else
            {
                return oldNum;
            }

        }
    }
}