// Write a program, which finds in a given matrix the largest area of 
// equal numbers. We define an area in the matrix as a set of neighbor 
// cells (by row and column).

namespace Ch7Q25
{
    public struct TwoDPoint
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public TwoDPoint(int x, int y)
            : this()
        {
            if(x < 0 || y < 0)
            {
                throw new ArgumentOutOfRangeException($"Coordinates must be in range [0...{Int32.MaxValue}]");
            }

            X = x;
            Y = y;
        }

        public override bool Equals(object? obj) => obj is TwoDPoint other && this.Equals(other);

        public bool Equals(TwoDPoint p) => X == p.X && Y == p.Y;

        public override int GetHashCode() => (X, Y).GetHashCode();

        public static bool operator ==(TwoDPoint lhs, TwoDPoint rhs) => lhs.Equals(rhs);

        public static bool operator !=(TwoDPoint lhs, TwoDPoint rhs) => !(lhs == rhs);

    }


    public static class LargestArea
    {
        private static void Main()
        {
            // Examples used for testing purposes
            int[,] mat4 =
            {
                {1, 3, 1, 2, 2, 4 },
                {3, 3, 3, 2, 4, 4 },
                {4, 3, 1, 2, 3, 3 },
                {4, 3, 1, 3, 3, 1 },
                {4, 3, 3, 3, 1, 1 }
            };

            int[,] mat1 =
            {
                {3, 3, 3, 4, 2, 1, 4, 2, 4, 1},
                {2, 1, 1, 2, 4, 4, 4, 1, 4, 1},
                {4, 1, 4, 4, 4, 1, 4, 3, 1, 4},
                {4, 1, 1, 3, 4, 1, 2, 2, 2, 2},
                {2, 3, 4, 3, 4, 1, 2, 2, 1, 4},
                {3, 1, 1, 1, 4, 4, 4, 2, 1, 3},
                {1, 1, 4, 1, 1, 2, 4, 3, 4, 2},
                {4, 4, 1, 1, 2, 3, 2, 4, 1, 2},
                {4, 2, 3, 4, 2, 4, 1, 1, 1, 3},
                {1 ,2 ,2 ,2 ,2 ,4 ,1 ,1 ,4 ,2},

            };

            int[,] mat2 =
            {
                {2, 2, 2, 1, 1},
                {1, 2, 1, 1, 2},
                {1, 1, 2, 1, 1},
                {2, 2, 2, 2, 2},
                {1, 2, 2, 1, 2},
            };

            int[,] mat3 =
            {
                {1, 1, 1, 2, 2, 1, 2, 2, 2, 1},
                {1, 2, 1, 2, 2, 1, 1, 1, 1, 2},
                {2, 2, 1, 2, 2, 1, 1, 2, 1, 1},
                {2, 2, 2, 1, 2, 1, 1, 2, 1, 1},
                {2, 2, 1, 1, 1, 1, 2, 2, 1, 1},
                {2, 2, 2, 2, 2, 2, 1, 2, 2, 1},
                {1, 2, 2, 1, 2, 2, 2, 1, 1, 2},
                {2, 2, 2, 1, 1, 2, 2, 2, 2, 1},
                {2, 2, 2, 1, 2, 2, 1, 1, 1, 1},
                {1, 2, 2, 1, 1, 1, 2, 1, 2, 1},
            };

            int rows, cols;

            Console.WriteLine("Program to find largest area of equal numbers in a " +
                "given matrix");
            Console.WriteLine();
            rows = GetInt("Enter number of rows = ");
            Console.WriteLine();
            cols = GetInt("Enter number of columns = ");
            
            int[,] matrix = new int[rows, cols];
            
            Console.WriteLine();
            InitializeMatrix(matrix);
            Console.WriteLine("\nGiven matrix - ");
            PrintMatrix(matrix);
            Console.WriteLine();
            FindLargestArea(matrix);
        }


        private static int GetInt(string prompt, int min = 1)
        {
            // Method to take user input of an integer

            int num;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if(!isInt || num < min)
                {
                    Console.WriteLine("\nEnter a valid integer 'x' such that" +
                        $"\n{min} <= x  <= {Int32.MaxValue}");
                }
            }
            while (!isInt || num < min);

            return num;
        }


        private static void InitializeMatrix(int[,] matrix)
        {
            // Method to initialize given matrix

            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = GetInt($"Matrix[{row}, {col}] = ");
                }
            }
        }


        private static void PrintMatrix(int[,] matrix)
        {
            // Method to print elements of given matrix

            int gNum = matrix[0, 0];
            int padding = 1;

            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(Math.Abs(matrix[row, col]) >= Math.Abs(gNum))
                    {
                        gNum = matrix[row, col];
                    }
                }
            }

            if(gNum < 0)
            {
                padding++;
            }

            while(Math.Abs(gNum) > 0)
            {
                padding++;
                gNum /= 10;
            }

            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col< matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}".PadLeft(padding));
                }

                Console.WriteLine();
            }
        }


        private static void FindLargestArea(int[,] matrix)
        {
            // Method to find largest area of neighbouring cells with same value
            // Helper method

            List<TwoDPoint> usedPoints = new List<TwoDPoint>(0);
            int[,] bestArea = new int[matrix.GetLength(0), matrix.GetLength(1)];
            int[,] currentArea = new int[matrix.GetLength(0), matrix.GetLength(1)];

            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col< matrix.GetLength(1); col++)
                {
                    DFS(matrix, currentArea, usedPoints, row, col);
                    if(NonZeroValues(currentArea) > NonZeroValues(bestArea))
                    {
                        CopyValues(currentArea, bestArea);
                    }

                    ReinitializeMatrix(currentArea);
                }
            }

            PrintMatrix(bestArea);
            Console.WriteLine($"\nGreatest area = {NonZeroValues(bestArea)}");
        }


        private static void DFS(int[,] matrix, int[,] currentArea, List<TwoDPoint> usedPoints, int row = 0, int col = 0, int? num = null)
        {
            // Method to find largets area of neighbouring cells with same value
            // using DFS (Depth first search) algorithm

            if(row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            TwoDPoint cPoint = new TwoDPoint(row, col);

            if(num == null)
            {
                num = matrix[row, col];
            }

            if(usedPoints.Contains(cPoint) || num != matrix[row, col])
            {
                return;
            }

            usedPoints.Add(cPoint);
            currentArea[row, col] = matrix[row, col];
            DFS(matrix, currentArea, usedPoints, row, col + 1, num); // Go Right
            DFS(matrix, currentArea, usedPoints, row + 1, col, num); // Go Down
            DFS(matrix, currentArea, usedPoints, row, col - 1, num); // Go Left
            DFS(matrix, currentArea, usedPoints, row - 1, col, num); // Go Up
        }


        private static int NonZeroValues(int[,] matrix)
        {
            // Method to return number of non-zero values of a given matrix

            int count = 0;

            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(matrix[row, col] != 0)
                    {
                        count++;
                    }
                }
            }

            return count;
        }


        private static void CopyValues(int[,] matrix1, int[,] matrix2)
        {
            // Method to copy values of matrix1 to matrix2

            for(int row = 0; row < matrix1.GetLength(0); row++)
            {
                for(int col = 0; col < matrix1.GetLength(1); col++)
                {
                    matrix2[row, col] = matrix1[row, col];
                }
            }
        }


        private static void ReinitializeMatrix(int[,] matrix)
        {
            // Method to reinitialize all elements of given matrix to zero

            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }
        }
    }
}