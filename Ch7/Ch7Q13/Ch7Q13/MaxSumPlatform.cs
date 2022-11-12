// Write a program, which creates a rectangular array with size of n by m 
// elements. The dimensions and the elements should be read from the 
// console. Find a platform with size of (3, 3) with a maximal sum.

namespace Ch7Q13
{
    public static class MaxSumPlatform
    {
        private static void Main()
        {
            int rows, cols;

            Console.WriteLine("Program to find platform of given size with max " +
                "sum from given rectangular array");
            rows = GetDimensionLength("Enter no. of rows = ");
            cols = GetDimensionLength("Enter no. of cols = ");
            int[,] matrix = new int[rows, cols];
            Console.WriteLine();
            InitMatrix(matrix);
            Console.WriteLine();
            PrintMatrix(matrix);
            Console.WriteLine();
            FindMaxSumPlatform(matrix);
        }


        private static int GetDimensionLength(string prompt)
        {
            // Method to get no. of rows and cols

            int length;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out length);
                if(!isInt || length <= 0)
                {
                    Console.WriteLine($"\nEnter a valid integer 'x' such that" +
                        $"\n0 < x <= {Int32.MaxValue}");
                }
            }
            while (!isInt || length <= 0);

            return length;
        }


        private static void InitMatrix(int[,] matrix)
        {
            // Method to initialize matrix

            bool isInt;

            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    do
                    {
                        Console.Write($"Matrix[{row},{col}] = ");
                        isInt = Int32.TryParse(Console.ReadLine(), out matrix[row, col]);
                        if (!isInt)
                        {
                            Console.WriteLine("\nEnter a valid integer 'x' such that" +
                                $"\n{Int32.MinValue} <= x <= {Int32.MaxValue}");
                        }
                    }
                    while (!isInt);
                }
            }
        }


        private static void PrintMatrix(int[,] matrix)
        {
            // Method to print matrix

            int maxInt = 0;
            int padding = 1;

            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(Math.Abs(matrix[row, col]) > Math.Abs(maxInt) || (matrix[row, col] < 0 && Math.Abs(matrix[row, col]) >= Math.Abs(maxInt)))
                    {
                        maxInt = matrix[row, col];
                    }
                }
            }

            if(maxInt < 0)
            {
                padding++;
            }

            maxInt = Math.Abs(maxInt);
            while(maxInt != 0)
            {
                maxInt /= 10;
                padding++;
            }

            Console.WriteLine("Given matrix is");
            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}".PadLeft(padding));
                }

                Console.WriteLine();
            }
        }


        private static void FindMaxSumPlatform(int[,] matrix)
        {
            // Method to find max sum platform of given size

            int platformRows, platformCols;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int bestStartRow = 0, bestStartCol = 0;

            platformRows = GetPlatformDimension("Enter no. of rows of platform = ", rows);
            platformCols = GetPlatformDimension("Enter no. of cols of platform = ", cols);

            long maxSum = Int64.MinValue;

            for(int row = 0; row <= rows - platformRows; row++)
            {
                for(int col = 0; col <= cols - platformCols; col++)
                {
                    long currentSum = PlatformSum(matrix, row, col, platformRows, platformCols);

                    if(currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        bestStartRow = row;
                        bestStartCol = col;
                    }
                }
            }

            Console.WriteLine("Platform with max sum is");
            PrintPlatform(matrix, bestStartRow, bestStartCol, platformRows, platformCols);
            Console.WriteLine($"\nMax sum = {maxSum}");
        }


        private static int GetPlatformDimension(string prompt, int maxLength)
        {
            int length;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out length);
                if(!isInt || length > maxLength)
                {
                    Console.WriteLine("\nEnter a valid integer 'x' such that" +
                        $"\n0 < x <= {maxLength}");
                }
            }
            while (!isInt || length > maxLength);

            return length;
        }


        private static long PlatformSum(int[,] matrix, int startRow, int startCol, int maxRow, int maxCol)
        {
            // Method to find sum of platform of given size from given matrix starting from 
            // certain cell

            long sum = 0;

            for(int row = startRow; (row < startRow + maxRow) && (row < matrix.GetLength(0)); row++)
            {
                for(int col = startCol; (col < startCol + maxCol) && (col < matrix.GetLength(1)); col++)
                {
                    sum += matrix[row, col];
                }
            }

            return sum;
        }


        private static void PrintPlatform(int[,] matrix, int startRow, int startCol, int maxRow, int maxCol)
        {
            // Method to print platform of given size from a given matrix

            int padding = 1;
            int maxInt = 0;

            for(int row = startRow; (row < startRow + maxRow) && (row < matrix.GetLength(0)); row++)
            {
                for(int col = startCol; (col < startCol + maxCol) && (col < matrix.GetLength(1)); col++)
                {
                    if(Math.Abs(matrix[row, col]) > Math.Abs(maxInt) || (matrix[row, col] < 0 && Math.Abs(matrix[row, col]) >= Math.Abs(maxInt)))
                    {
                        maxInt = matrix[row, col];
                    }
                }
            }

            if(maxInt < 0)
            {
                padding++;
            }

            maxInt = Math.Abs(maxInt);
            while(maxInt != 0)
            {
                maxInt /= 10;
                padding++;
            }

            for(int row = startRow; (row < startRow + maxRow) && (row < matrix.GetLength(0)); row++)
            {
                for(int col = startCol; (col < startCol + maxCol) && (col < matrix.GetLength(1)); col++)
                {
                    Console.Write($"{matrix[row, col]}".PadLeft(padding));
                }

                Console.WriteLine();
            }
        }
    }
}