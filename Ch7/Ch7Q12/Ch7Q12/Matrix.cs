// Write a program, which creates square matrices like those in the 
// figures below and prints them formatted to the console. The size of the 
// matrices will be read from the console. See the examples for matrices 
// with size of 4 x 4 and make the other sizes in a similar fashion:
// 1  5  9 13                          1  8  9 16
// 2  6 10 14                          2  7 10 15
// 3  7 11 15                          3  6 11 14
// 4  8 12 16                          4  5 12 13
// 
// 7 11 14 16                          1 12 11 10
// 4  8 12 15                          2 13 16  9
// 2  5  9 13                          3 14 15  8
// 1  3  6 10                          4  5  6  7

namespace Ch7Q12
{
    public static class Matrix
    {
        private static void Main()
        {
            int order;
            bool isInt;

            Console.WriteLine("Program to make square matrices of given order " +
                "in the following manner:" +
                "\n1  5  9 13                          1  8  9 16" +
                "\n2  6 10 14                          2  7 10 15" +
                "\n3  7 11 15                          3  6 11 14" +
                "\n4  8 12 16                          4  5 12 13" +
                "\n\n7 11 14 16                          1 12 11 10" +
                "\n4  8 12 15                          2 13 16  9" +
                "\n2  5  9 13                          3 14 15  8" +
                "\n1  3  6 10                          4  5  6  7");
            Console.WriteLine();
            do
            {
                Console.Write("Enter order of square matrix = ");
                isInt = Int32.TryParse(Console.ReadLine(), out order);
                if (!isInt || order < 2)
                {
                    Console.WriteLine("\nEnter a valid integer 'x'" +
                        $"\nsuch that 2 <= x <= {Int32.MaxValue}");
                }
            }
            while (!isInt || order < 2);

            CreateMatrixType1(order);
            Console.WriteLine();
            CreateMatrixType2(order);
            Console.WriteLine();
            CreateMatrixType3(order);
            Console.WriteLine();
            CreateMatrixType4(order);
        }


        private static void CreateMatrixType1(int order)
        {
            // Method to make matrix from given order
            // For example if order = 4
            // 1  5  9 13
            // 2  6 10 14
            // 3  7 11 15
            // 4  8 12 16

            int[,] matrix = new int[order, order];
            int count = 1;

            for(int col = 0; col < order; col++)
            {
                for(int row = 0; row < order; row++)
                {
                    matrix[row, col] = count;
                    count++;
                }
            }

            PrintMatrix(matrix);
        }


        private static void PrintMatrix(int[,] matrix)
        {
            // Method to print matrix

            int maxNum = matrix.GetLength(0) * matrix.GetLength(1);
            int padding = 1;

            while(maxNum != 0)
            {
                maxNum /= 10;
                padding++;
            }

            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}".PadLeft(padding));
                }

                Console.WriteLine();
            }
        }


        private static void CreateMatrixType2(int order)
        {
            // Method to make matrix from given order
            // For example if order = 4
            // 1  8  9 16
            // 2  7 10 15
            // 3  6 11 14
            // 4  5 12 13

            int[,] matrix = new int[order, order];
            int count = 1;

            for(int col = 0; col < order; col++)
            {
                if(col % 2 == 0)
                {
                    for(int row = 0; row < order; row++)
                    {
                        matrix[row, col] = count;
                        count++;
                    }
                }
                else
                {
                    for(int row = order - 1; row >= 0; row--)
                    {
                        matrix[row,col] = count;
                        count++;
                    }
                }
            }

            PrintMatrix(matrix);
        }


        private static void CreateMatrixType3(int order)
        {
            // Method to make matrix from given order
            // For example if order = 4
            // 7 11 14 16
            // 4  8 12 15
            // 2  5  9 13
            // 1  3  6 10

            int[,] matrix = new int[order, order];
            int count = 1;
            int startRow = order - 1;
            int startCol = 0;

            while (startCol < order)
            {
                int tempCol = 0;

                for(int row = startRow, col = startCol; row < order && col < order; row++, col++)
                {
                    matrix[row, col] = count;
                    count++;
                    tempCol = col;
                }

                if(tempCol == order - 1)
                {
                    startCol++;
                }
                else
                {
                    startRow--;
                }
            }

            PrintMatrix(matrix);
        }


        private static void CreateMatrixType4(int order)
        {
            // Method to make matrix from given order
            // For example if order = 4
            // 1 12 11 10
            // 2 13 16  9
            // 3 14 15  8
            // 4  5  6  7

            int[,] matrix = new int[order, order];
            int count = 1;
            int startRow = 0, startCol = 0;
            int minRow = 0, maxRow = order - 1;
            int minCol = 0, maxCol = order - 1;

            while (minRow < maxRow && minCol < maxCol)
            {
                int tempRow = 0, tempCol = 0;

                for(int row = startRow, col = startCol; row <= maxRow; row++)
                {
                    matrix[row, col] = count;
                    count++;
                    tempRow = row;
                }

                if(startCol != 0)
                {
                    maxCol--;
                }
                startRow = tempRow;
                startCol++;

                for(int row = startRow, col = startCol; col <= maxCol; col++)
                {
                    matrix[row, col] = count;
                    count++;
                    tempCol = col;
                }

                if(startRow != order - 1)
                {
                    minRow++;
                }
                startRow--;
                startCol = tempCol;

                for(int row = startRow, col = startCol; row >= minRow; row--)
                {
                    matrix[row, col] = count;
                    count++;
                    tempRow = row;
                }

                startRow = tempRow;
                startCol--;
                minCol++;

                for(int row = startRow, col = startCol; col >= minCol; col--)
                {
                    matrix[row, col] = count;
                    count++;
                    tempCol = col;
                }

                startRow++;
                startCol = tempCol;
                maxRow--;
            }

            PrintMatrix(matrix);
        }
    }
}