// Write a Boolean expression that checks whether a given integer is 
// divisible by both 5 and 7, without a remainder.


namespace Ch3Q2
{
    public class DivisibleByBothFiveAndSeven
    {
        public static void Main()
        {
            int num;
            bool isInt;

            Console.WriteLine("Program to check whether given number is divisible by both 5 and 7");
            Console.WriteLine("Enter an integer");
            do
            {
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if (!isInt)
                {
                    Console.WriteLine($"\nEnter an integer 'x' such that\n{Int32.MinValue} <= x <= {Int32.MaxValue}");
                }
            }
            while(!isInt);

            if((num % 5 == 0) && (num % 7 == 0))
            {
                Console.WriteLine($"\n{num} is divisible by both 5 and 7");
            }
            else if(num % 5 == 0)
            {
                Console.WriteLine($"\n{num} is only divisible by 5");
            }
            else if(num % 7 == 0)
            {
                Console.WriteLine($"\n{num} is only divisible by 7");
            }
            else
            {
                Console.WriteLine($"\n{num} is neither divisible by 5 nor 7");
            }
        }
    }
}