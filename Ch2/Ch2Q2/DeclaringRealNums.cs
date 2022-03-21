// Which of the following values can be assigned to variables of type float,
// double and decimal: 5, -5.01, 34.567839023; 12.345; 8923.1234857;
// 3456.091124875956542151256683467 ?


namespace Ch2Q2
{
    public class DeclaringRealNums
    {
        public static void Main()
        {
            float num1 = 5f, num2 = -5.01f, num3 = 12.345f;
            double num5 = 34.567839023, num4 = 8923.1234567;
            decimal num6 = 3456.091124875956542151256683467m;

            Console.WriteLine($"float -\n{num1}\n{num2}\n{num3}\n");
            Console.WriteLine($"double -\n{num5}\n{num4}\n");
            Console.WriteLine($"decimal -\n{num6}");
        }
    }
}