namespace Ch2Q13
{
    public class SwapValues
    {
        public static void Main()
        {
            int num1 = 5, num2 = 10;

            Console.WriteLine($"Before swapping -\nNum1 = {num1}\nNum2 = {num2}\n");
            num1 += num2;
            num2 = num1 - num2;
            num1 -= num2;
            Console.WriteLine($"After swapping -\nNum1 = {num1}\nNum2 = {num2}");

        }
    }
}