// Program to check whether third digit (from right to left) of a given number is 7 or not
namespace Ch3Q3
{
    public class ThirdDigit
    {
        public static void Main()
        {
            int num;
            bool isInt;

            Console.WriteLine("Program to find whether third digit of given number is 7");
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

            sbyte thirdDigit = (sbyte)Math.Abs((num / 100) % 10);
            if (thirdDigit == 7)
            {
                Console.WriteLine($"\nThird digit of {num} is {thirdDigit}");
            }
            else
            {
                Console.WriteLine($"\nThird digit of {num} is {thirdDigit}, which is not 7");
            }
        }
    }
}