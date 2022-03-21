// Write a program that reads an integer number n from the console and 
// prints all numbers in the range [1…n], each on a separate line.


namespace Ch4Q10
{
    public static class OneToN
    {
        public static void Main()
        {
            int n;
            bool isInt;

            Console.WriteLine("Program to print all integers from onr to n");
            do
            {
                Console.Write("Enter n: ");
                isInt = Int32.TryParse(Console.ReadLine(), out n);
                if(!isInt || n < 1)
                {
                    Console.WriteLine("\nEnter a valid positive integer x such that\n" +
                        $"1 <= x <= {Int32.MaxValue}");
                }
            }
            while (!isInt || n < 1);

            Console.WriteLine();
            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}