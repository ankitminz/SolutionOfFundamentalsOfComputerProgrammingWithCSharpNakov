// Write a program that takes as input a four-digit number in format abcd
// (e.g. 2011) and performs the following actions:
// -Calculates the sum of the digits (in our example 2+0+1+1 = 4).
// -Prints on the console the number in reversed order: dcba(in our
// example 1102).
// - Puts the last digit in the first position: dabc(in our example 1201).
// - Exchanges the second and the third digits: acbd(in our example
// 2101).


namespace Ch3Q10
{
    public class Ch3Q10
    {
        public static void Main()
        {
            short num;
            bool isShort;

            Console.WriteLine("Enter a 4 digit positive integer");
            do
            {
                isShort = short.TryParse(Console.ReadLine(), out num);
                if(!isShort || num < 1000 || num > 9999)
                {
                    Console.WriteLine($"\nEnter a valid positive integer 'x' such that\n1000 <= x <= 9999");
                }
            }
            while (!isShort || num < 1000 || num > 9999);

            Console.WriteLine($"\nSum of digits\n{SumOfDigits(num)}");
            Console.WriteLine($"\nReversed number\n{ReversedNum(num)}");
            Console.WriteLine($"\nNew number after putting last digit in first place\n{PutLastDigitInFirstPlace(num)}");
            Console.WriteLine($"\nNew number after exchanging second and third digit\n{ExchangeSecondAndThirdDigit(num)}");
        }


        private static int SumOfDigits(short num)
        {
            // Method to find sum of digits of the given number

            int sum = 0;

            do
            {
                sum += num % 10;
                num /= 10;
            }
            while (num > 0);

            return sum;
        }


        private static short ReversedNum(short num)
        {
            // Method to reverse the given number

            short reversedNum = 0;
            short power = 3;

            do
            {
                reversedNum += (short)((num % 10) * Math.Pow(10, power));
                num /= 10;
                power--;
            }
            while(num > 0);

            return reversedNum;
        }


        private static short PutLastDigitInFirstPlace(short num)
        {
            // Method to put last digit in first place

            short newNum = 0;
            const byte MAX_POWER = 3;
            byte power = 0;

            do
            {
                if(num >= 1000)
                {
                    newNum = (short)((num % 10) * Math.Pow(10, MAX_POWER));
                }
                else
                {
                    newNum += (short)((num % 10) * Math.Pow(10, power));
                    power++;
                }

                num /= 10;
            }
            while (num > 0);

            return newNum;
        }


        private static short ExchangeSecondAndThirdDigit(short num)
        {
            // Method to exchange second and third digit of the given number

            short newNum = 0;
            const byte POWER_ONE = 1, POWER_TWO = 2;
            byte power = 0;

            do
            {
                if(num < 100 && num > 9)
                {
                    newNum += (short)((num % 10) * Math.Pow(10, POWER_ONE));
                }
                else if(num < 1000 && num > 99)
                {
                    newNum += (short)((num % 10) * Math.Pow(10, POWER_TWO));
                }
                else
                {
                    newNum += (short)((num % 10) * Math.Pow(10, power));
                }

                num /= 10;
                power++;
            }
            while (num > 0);

            return newNum;
        }
    }
}