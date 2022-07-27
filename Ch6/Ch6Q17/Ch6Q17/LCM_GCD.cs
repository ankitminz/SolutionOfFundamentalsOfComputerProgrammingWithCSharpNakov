// Write a program that given two numbers finds their greatest common 
// divisor (GCD) and their least common multiple (LCM). You may use 
// the formula LCM(a, b) = | a * b | / GCD(a, b).

namespace Ch6Q17
{
    public static class LCM_GCD
    {
        public static void Main()
        {
            int x, y, gcd = 1, lcm;

            Console.WriteLine("Program to find greatest common divisor and least common " +
                "multiple");
            x = GetNum("Enter first number");
            y = GetNum("Enter second number");

            for(int i = x > y ? Math.Abs(x) : Math.Abs(y); i > 0; i--)
            {
                if(x % i == 0 && y % i == 0)
                {
                    gcd = i;
                    break;
                }
            }

            lcm = Math.Abs(x * y) / gcd;
            Console.WriteLine($"\nGreatest common divisor = {gcd}\n" +
                $"Least common multiple = {lcm}");
        }


        private static int GetNum(string prompt)
        {
            int num;
            bool isInt;

            do
            {
                Console.Write($"{prompt}: ");
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if (!isInt)
                {
                    Console.WriteLine("Enter a valid interger 'x' such that" + 
                        $"\n{Int32.MinValue} <= x <= {Int32.MaxValue}");
                }
            }
            while(!isInt);

            return num;
        }
    }
}