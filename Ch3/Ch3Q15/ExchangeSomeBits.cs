namespace Ch3Q15
{
    public class ExchangeSomeBits
    {
        public static void Main()
        {
            uint num;
            bool isUInt;

            Console.WriteLine("Program to exchange 3rd, 4th and 5th bit with 24th, 25th and 26th bit in given number");
            Console.WriteLine("Enter a positive integer");
            do
            {
                isUInt = UInt32.TryParse(Console.ReadLine(), out num);
                if (!isUInt)
                {
                    Console.WriteLine($"\nEnter a valid positive integer 'x' such that\n{UInt32.MinValue} <= x <= {UInt32.MaxValue}");
                }
            }
            while(!isUInt);

            num = ExchangeBit(num, 3, 24);
            num = ExchangeBit(num, 4, 25);
            num = ExchangeBit(num, 5, 26);
            Console.WriteLine($"\nResultant after exchanging bits\n{num}");
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
            if(isBitOneInPosition1 != isBitOneInPosition2)
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
            if((num & powerOfTwo) == powerOfTwo)
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