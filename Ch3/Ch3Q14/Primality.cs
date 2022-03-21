// Write a program that checks if a given number n (1 < n < 100) is a
// prime number(i.e.it is divisible without remainder only to itself and 1).


namespace Ch3Q14
{
    public class Primality
    {
        public static void Main()
        {
            int num;
            bool isInt;

            Console.WriteLine("Program to check whether given number is prime or not");
            Console.WriteLine("Enter an integer");
            do
            {
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if (!isInt)
                {
                    Console.WriteLine($"\nEnter a valid integer 'x' such that\n{Int32.MinValue} <= x <= {Int32.MinValue}");
                }
            }
            while(!isInt);

            Console.WriteLine($"\nIs {num} prime\n{IsPrime(num)}");
        }


        private static bool IsPrime(int num)
        {
            // Method to check primality of given integer

            bool isPrime = true;
            num = Math.Abs(num);
            if(num == 0 || num == 1)
            {
                return false;
            }

            for(int min = 2, max = (int)Math.Sqrt(num); min <= max; min++)
            {
                if(num % min == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            return isPrime;
        }
    }
}