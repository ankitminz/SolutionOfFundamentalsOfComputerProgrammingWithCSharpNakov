// Write a program, which finds the longest sequence of equal string
// elements in a matrix. A sequence in a matrix we define as a set of 
// neighbor elements on the same row, column or diagonal.

namespace Ch7Q14
{
    public static class LongestSequence
    {
        private static void Main()
        {
            int rows, cols;
            
            Console.WriteLine("Program to find longest sequence of equal string " +
                "elements in a matrix on the same row, column or diagonal");
            rows = GetMatrixDimension("Enter no. of rows = ");
            cols = GetMatrixDimension("Enter no. of columns = ");
            
            string[,] matrix = new string[rows, cols];
            
            Console.WriteLine("\nInitialize matrix");
            for(int row = 0; row < rows; row++)
            {
                for(int col = 0; col < cols; col++)
                {
                    string? temp;
            
                    do
                    {
                        Console.Write($"Matrix[{row}, {col}] = ");
                        temp = Console.ReadLine();
                        if(temp == null)
                        {
                            Console.WriteLine("\nEnter some value");
                        }
                        else
                        {
                            matrix[row, col] = temp;
                        }
                    }
                    while (temp == null);
                }
            }
            
            Console.WriteLine();
            PrintMatrix(matrix);
            Console.WriteLine();
            FindLongestSequenceOfEqualElements(matrix);
        }


        private static int GetMatrixDimension(string prompt)
        {
            // Method to get order of matrix

            int length;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out length);
                if(!isInt || length <= 0)
                {
                    Console.WriteLine("\nEnter a valid integer 'x' such that" +
                        $"\n0 < x <= {Int32.MaxValue}");
                }
            }
            while (!isInt || length <= 0);

            return length;
        }


        private static void PrintMatrix(string[,] matrix)
        {
            // Method to print matrix

            int padding = 1;
            int maxLength = 0;

            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(matrix[row, col].Length > maxLength)
                    {
                        maxLength = matrix[row, col].Length;
                    }
                }
            }

            padding += maxLength;
            Console.WriteLine("Given matrix is");
            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col].PadLeft(padding));
                }

                Console.WriteLine();
            }
        }


        private static void FindLongestSequenceOfEqualElements(string[,] matrix)
        {
            // Method to find longest sequence of equal elements of a given matrix 
            // on the same row, column or diagonal

            int maxLength = 0;
            int bestRow = 0, bestCol = 0;
            int type = 0;

            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    int count = CheckRow(matrix, row, col);
                    if(count > maxLength)
                    {
                        maxLength = count;
                        bestRow = row;
                        bestCol = col;
                        type = 1;
                    }

                    count = CheckCol(matrix, row, col);
                    if(count > maxLength)
                    {
                        maxLength = count;
                        bestRow = row;
                        bestCol = col;
                        type = 2;
                    }

                    count = CheckDiagonal(matrix, row, col);
                    if(count > maxLength)
                    {
                        maxLength = count;
                        bestRow = row;
                        bestCol = col;
                        type = 3;
                    }
                }
            }

            Console.Write("Longest sequence = ");
            switch (type)
            {
                case 1:
                    {
                        for(int row = bestRow; row < matrix.GetLength(0) && row < bestRow + maxLength; row++)
                        {
                            if(maxLength == 1)
                            {
                                Console.WriteLine(matrix[bestRow, bestCol]);
                                break;
                            }

                            if(row < bestRow + maxLength - 1)
                            {
                                Console.Write($"{matrix[row, bestCol]}, ");
                            }
                            else
                            {
                                Console.WriteLine(matrix[row, bestCol]);
                            }
                        }

                        break;
                    }

                case 2:
                    {
                        for(int col = bestCol; col < matrix.GetLength(1) && col < bestCol + maxLength; col++)
                        {
                            if(maxLength == 1)
                            {
                                Console.WriteLine(matrix[bestRow, bestCol]);
                                break;
                            }

                            if(col < bestCol + maxLength - 1)
                            {
                                Console.Write($"{matrix[bestRow, col]}, ");
                            }
                            else
                            {
                                Console.WriteLine(matrix[bestRow, col]);
                            }
                        }

                        break;
                    }

                case 3:
                    {
                        for(int row = bestRow, col = bestCol; row < bestRow + maxLength; row++, col++)
                        {
                            if(maxLength == 1)
                            {
                                Console.WriteLine(matrix[bestRow, bestCol]);
                                break;
                            }

                            if(row < bestRow + maxLength - 1)
                            {
                                Console.Write($"{matrix[row, col]}, ");
                            }
                            else
                            {
                                Console.WriteLine(matrix[row, col]);
                            }
                        }

                        break;
                    }

                default:
                    {
                        Console.WriteLine("Oops! some error occured");
                        break;
                    }
            }
        }


        private static int CheckRow(string[,] matrix, int startRow, int startCol)
        {
            // Method to check along same column

            int count = 1;

            for(int row = startRow + 1; row < matrix.GetLength(0); row++)
            {
                if(matrix[row, startCol] == matrix[startRow, startCol])
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            return count;
        }


        private static int CheckCol(string[,] matrix, int startRow, int startCol)
        {
            // Method to check along same row

            int count = 1;

            for(int col = startCol + 1; col < matrix.GetLength(1); col++)
            {
                if(matrix[startRow, col] == matrix[startRow, startCol])
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            return count;
        }


        private static int CheckDiagonal(string[,] matrix, int startRow, int startCol)
        {
            // Method to check along diagonal

            int count = 1;

            for(int row = startRow + 1, col = startCol + 1; row < matrix.GetLength(0) && col < matrix.GetLength(1); row++, col++)
            {
                if(matrix[row, col] == matrix[startRow, startCol])
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            return count;
        }
    }
}