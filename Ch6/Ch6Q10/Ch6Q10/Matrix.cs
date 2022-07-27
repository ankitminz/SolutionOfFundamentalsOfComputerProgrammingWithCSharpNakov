// Write a program that reads from the console a positive integer number 
// N (N < 20) and prints a matrix of numbers as on the figures below:
// For N=3
// 123
// 234
// 345

namespace Ch6Q10
{
    public static class Matrix
    {
        public static void Main()
        {
            byte n;
            bool isByte;

            Console.WriteLine("Program to print matrix of numbers for given positive " +
                "integer N (N < 20)");
            do
            {
                Console.Write("N = ");
                isByte = Byte.TryParse(Console.ReadLine(), out n);
                if(!isByte || n < 1 || n >= 20)
                {
                    Console.WriteLine($"\nEnter a valid positive integer 'N' such that" +
                        $"\n1 <= N < 20");
                }
            }
            while (!isByte || n < 1 || n >= 20);

            Console.WriteLine();
            BuildMatrix(n);
        }


        private static void BuildMatrix(byte n)
        {
            // Method to build matrix for given positive integer n
            // For example: n = 3
            // 123
            // 234
            // 345

            for(byte row = 1; row <= n; row++)
            {
                for(byte col = row; col < row + n; col++)
                {
                    Console.Write($"{col,3}");
                }

                Console.WriteLine();
            }
        }
    }
}