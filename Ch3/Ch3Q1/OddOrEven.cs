// Write an expression that checks whether an integer is odd or even.

namespace Ch3Q1
{
    public class OddOrEven
    {
        public static void Main()
        {
            int num;
            bool isInt;

            Console.WriteLine("Program to check whether given number in odd or even");
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

            if(num % 2 == 0)
            {
                Console.WriteLine($"\n{num} is even");
            }
            else
            {
                Console.WriteLine($"\n{num} is odd");
            }
        }
    }
}