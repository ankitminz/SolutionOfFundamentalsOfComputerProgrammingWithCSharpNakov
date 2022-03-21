// Write an expression that checks whether the third bit in a given integer 
// is 1 or 0.


namespace Ch3Q4
{
    public class ThirdBit
    {
        public static void Main()
        {
            int num;
            bool isInt;

            Console.WriteLine("Program to check whether third bit of a given integer is 1 or 0");
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

            if((num & 4) == 4)
            {
                Console.WriteLine($"\nThird bit of {num} is 1");
            }
            else
            {
                Console.WriteLine($"\nThird bit of {num} is 0");
            }
        }
    }
}