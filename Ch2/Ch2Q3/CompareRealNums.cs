// Write a program, which compares correctly two real numbers with 
// accuracy at least 0.000001.

namespace Ch2Q3
{
    public class CompareRealNums
    {
        public static void Main()
        {
            double num1 = 1.234567, num2 = 1.234568;
            double result = num2 - num1;

            Console.WriteLine(result);
        }
    }
}