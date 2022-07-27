// Write a program that for a given number n, outputs a matrix in the 
// form of a spiral:
//     Example for n = 4:
//         1  2  3  4
//         12 13 14 5
//         11 16 15 6
//         10 9  8  7

namespace Ch6Q18
{
    public static class SpiralMatrix
    {
        public static void Main()
        {
            int n;
            bool isInt;

            Console.WriteLine("Program to print a spiral matrix for a given number 'n'");
            do
            {
                Console.Write("n = ");
                isInt = Int32.TryParse(Console.ReadLine(), out n);
                if (!isInt || n <= 0)
                {
                    Console.WriteLine($"\nEnter a positive integer 'n' such that\n" +
                        $"0 < n <= {Int32.MaxValue}");
                }
            }
            while (!isInt || n <= 0);

            int[,] matrix = new int[n, n];
            int row = 0, col = 0;
            int minRow = 0, minCol = 0;
            int maxRow = n - 1, maxCol = n - 1;
            int count = 1;

            matrix[0, 0] = count;
            while(row <= maxRow && row >= minRow && col <= maxCol && col >= minCol)
            {
                bool matrixFinished = true;
                ++minRow;
                if(count > 1)
                {
                    --col;
                }

                // START - Logic to move right i.e. col + 1
                while(col + 1 <= maxCol)
                {
                    ++count;
                    matrix[row, col + 1] = count;
                    if(col + 1 <= maxCol)
                    {
                        ++col;
                    }
                    matrixFinished = false;
                }
                --maxCol;
                // END

                // START - Logic to move down i.e. row + 1
                while(row + 1 <= maxRow)
                {
                    ++count;
                    matrix[row + 1, col] = count;
                    if(row + 1 <= maxRow)
                    {
                        ++row;
                    }
                    matrixFinished = false;
                }
                --maxRow;
                // END

                // START - Logic to move left i.e. col - 1
                while(col - 1 >= minCol)
                {
                    ++count;
                    matrix[row, col - 1] = count;
                    if(col - 1 >= minCol)
                    {
                        --col;
                    }
                    matrixFinished = false;
                }
                ++minCol;
                // END

                // START - Logic to move up i.e. row - 1
                while(row - 1 >= minRow)
                {
                    ++count;
                    matrix[row - 1, col] = count;
                    if(row - 1 >= minRow)
                    {
                        --row;
                    }
                    matrixFinished = false;
                }
                // END

                if (matrixFinished)
                {
                    break;
                }

                ++col;
            }

            Console.WriteLine();
            for(int myRow = 0; myRow < n; myRow++)
            {
                for(int myCol = 0; myCol < n; myCol++)
                {
                    Console.Write($"{matrix[myRow, myCol],3}");
                }

                Console.WriteLine();
            }
        }
    }
}