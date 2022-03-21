// Write a program that prints three numbers in three virtual columns
// on the console. Each column should have a width of 10 characters and 
// the numbers should be left aligned. The first number should be an 
// integer in hexadecimal; the second should be fractional positive; and
// the third – a negative fraction. The last two numbers have to be 
// rounded to the second decimal place.

namespace Ch4Q4
{
    public static class NumFormatting
    {
        public static void Main()
        {
            int num1 = 123;
            double num2 = 123.456789;
            double num3 = -987.654321;

            Console.WriteLine($"{num1,-10:X} | {num2,-10:F2} | {num3,-10:F2}");
        }
    }
}