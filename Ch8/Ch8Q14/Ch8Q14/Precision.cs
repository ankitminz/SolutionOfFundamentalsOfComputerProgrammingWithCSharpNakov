// Try adding up 50,000,000 times the number 0.000001. Use a loop 
// and addition (not direct multiplication). Try it with float and double and 
// after that with decimal. Do you notice the huge difference in the 
// results and speed of calculation? Explain what happens.

namespace Ch8Q14
{
    public static class Precision
    {
        private static void Main()
        {
            float n1 = 0.000001f, resultF = 0f;
            double n2 = 0.000001d, resultD = 0d;
            decimal n3 = 0.000001m, resultM = 0m;

            Console.WriteLine("Program to test precision of float, double and " +
                "decimal datatype by adding 0.000001 to itself 50,000,000 times. " +
                "Correct answer is 50");
            for(long i = 1; i <= 50000000; i++)
            {
                resultF += n1;
                resultD += n2;
                resultM += n3;
            }

            Console.WriteLine($"Float result = {resultF}" +
                $"\nDouble result = {resultD}" +
                $"\nDecimal result = {resultM}");
        }
    }
}