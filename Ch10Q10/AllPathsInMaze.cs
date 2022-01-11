using System;

namespace Ch10Q10
{
    class AllPathsInMaze
    {
        static void Main()
        {
            char[,] maze1 =
            {
                {' ', ' ', ' ', '*', ' ', ' ', ' ' },
                {'*', '*', ' ', '*', ' ', '*', ' ' },
                {' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                {' ', '*', '*', '*', '*', '*', ' ' },
                {' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            };

            char[,] maze2 =
            {
                {' ' },
            };

            char[,] maze3 =
            {
                {' ', ' ', ' ' },
                {' ', ' ', ' ' },
                {' ', ' ', ' ' },
            };

            char[,] maze4 =
            {
                {' ', '*', '*', ' ', ' '},
                {' ', ' ', ' ', '*', ' '},
                {'*', ' ', ' ', '*', ' '},
            };

            char[,] maze5 =
            {
                {' ','*',' ',' ',' ',' ','*',' ',' ',' ',' ','*','*',' ',' '},
                {' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ','*','*','*',' ','*',' ',' ',' ',' ',' ','*','*','*','*'},
                {' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' '},
            };

            char[,] maze6 =
            {
                {' ','*',' ',' ',' ',' ','*',' ',' ',' ',' ','*','*',' ',' '},
                {' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ','*','*','*',' ','*',' ',' ',' ',' ',' ','*','*','*','*'},
                {' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ','*','*',' ',' '},
                {' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ','*',' '},
            };

            int row, col;
            bool isInt;

            Console.WriteLine("Program to find all paths between two given cells in a given maze");
            Console.WriteLine("\nSet the size of maze");
            Console.WriteLine("Enter the number of rows");
            do
            {
                isInt = Int32.TryParse(Console.ReadLine(), out row);
                if(!isInt || row <= 0)
                {
                    Console.WriteLine("\nEnter a valid positive integer greater than 0");
                }
            }
            while (!isInt || row <= 0);

            Console.WriteLine("\nEnter number of columns");
            do
            {
                isInt = Int32.TryParse(Console.ReadLine(), out col);
                if (!isInt || col <= 0)
                {
                    Console.WriteLine("\nEnter a valid positive integer greater than 0");
                }
            }
            while (!isInt || col <= 0);

            char[,] maze = new char[row, col];

            Console.WriteLine("\nMake your maze\n' ' for passable cell\n'*' for impassable cell\nEnter without quotes");
            Init(maze);

            int[] cell = UserInputStartNDestinationCell(maze);

            FindAllPathsBetween(maze, cell[0], cell[1], cell[2], cell[3]);
        }


        static void Print(char[,] array)
        {
            // Method to print maze

            for(int row = 0; row < array.GetLength(0); row++)
            {
                for(int col = 0; col < array.GetLength(1); col++)
                {
                    Console.Write(array[row, col]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }


        static ulong FindAllPathsIn(char[,] maze, int currentRow, int currentCol, int pathLength = 0, ulong pathNo = 0)
        {
            // Method to find all paths between two cells

            if (currentRow < 0 || currentCol < 0 || currentRow >= maze.GetLength(0) || currentCol >= maze.GetLength(1) || maze[currentRow, currentCol] == '*' || maze[currentRow, currentCol] == 's')
            {
                return pathNo;
            }
            else if (maze[currentRow, currentCol] == 'd')
            {
                pathNo++;
                Console.WriteLine($"Path No. {pathNo}\nPath length = {pathLength}");
                Print(maze);
                return pathNo;
            }
            else if(maze[currentRow, currentCol] != ' ')
            {
                return pathNo;
            }

            maze[currentRow, currentCol] = 's';
            pathLength++;

            pathNo = FindAllPathsIn(maze, currentRow, currentCol + 1, pathLength, pathNo); // Search right
            pathNo = FindAllPathsIn(maze, currentRow + 1, currentCol, pathLength, pathNo); // Search down
            pathNo = FindAllPathsIn(maze, currentRow, currentCol - 1, pathLength, pathNo); // Search left
            pathNo = FindAllPathsIn(maze, currentRow - 1, currentCol, pathLength, pathNo); // Search up

            maze[currentRow, currentCol] = ' ';
            pathLength--;

            return pathNo;
        }


        static void FindAllPathsBetween(char[,] maze, int startRow, int startCol, int destinationRow, int destinationCol)
        {
            // Support method
            if(startRow < 0 || startCol < 0 || startRow >= maze.GetLength(0) || startCol >= maze.GetLength(1) || destinationRow < 0 || destinationCol < 0 || destinationRow >= maze.GetLength(0) || destinationCol >= maze.GetLength(1) || maze[startRow, startCol] != ' ' || (startRow == destinationRow && startCol == destinationCol))
            {
                Console.WriteLine("Invalid coordinates of start cell or destination cell");
                return;
            }

            maze[destinationRow, destinationCol] = 'd';
            char temp = maze[startRow, startCol];

            maze[startRow, startCol] = 's';
            Console.WriteLine("\nOriginal maze");
            Print(maze);
            maze[startRow, startCol] = temp;
            ulong totalPaths = FindAllPathsIn(maze, startRow, startCol);

            if(totalPaths == 0)
            {
                Console.WriteLine("\nNo path found");
            }
            else
            {
                Console.WriteLine($"\nTotal no. of paths found = {totalPaths}");
            }
        }


        static void Init(char[,] array)
        {
            // Method to take user input to make maze

            bool isChar;

            for(int row = 0; row < array.GetLength(0); row++)
            {
                for(int col = 0; col < array.GetLength(1); col++)
                {
                    do
                    {
                        Console.Write($"Cell ({row}, {col}) = ");
                        isChar = Char.TryParse(Console.ReadLine(), out array[row, col]);
                        if(!isChar || (array[row, col] != ' ' && array[row, col] != '*'))
                        {
                            Console.WriteLine("\nEnter\n' ' i.e. space without quotes\nOR\n'*' i.e. asterik without quotes");
                        }
                    }
                    while (!isChar || (array[row, col] != ' ' && array[row, col] != '*'));
                }
            }
        }


        static int[] UserInputStartNDestinationCell(char[,] maze)
        {
            // Method to initialize starting cell and destination cell

            int[] array = new int[4];
            bool isInt;

            do
            {
                do
                {
                    Console.WriteLine("\nEnter the coordinates of starting cell");
                    do
                    {
                        Console.Write("Row = ");
                        isInt = Int32.TryParse(Console.ReadLine(), out array[0]);
                        if (!isInt || array[0] < 0 || array[0] >= maze.GetLength(0))
                        {
                            Console.WriteLine($"\nEnter a valid positive integer x such that 0 <= x < {maze.GetLength(0)}");
                        }
                    }
                    while (!isInt || array[0] < 0 || array[0] >= maze.GetLength(0));

                    do
                    {
                        Console.Write("Column = ");
                        isInt = Int32.TryParse(Console.ReadLine(), out array[1]);
                        if (!isInt || array[1] < 0 || array[1] >= maze.GetLength(1))
                        {
                            Console.WriteLine($"\nEnter a valid positive integer x such that 0 <= x < {maze.GetLength(1)}");
                        }
                    }
                    while (!isInt || array[1] < 0 || array[1] >= maze.GetLength(1));

                    if (maze[array[0], array[1]] != ' ')
                    {
                        Console.WriteLine($"\nGiven starting cell ({array[0]}, {array[1]}) is not a passable cell. Only passable cell can be used as starting cell.");
                    }
                }
                while (maze[array[0], array[1]] != ' ');

                do
                {
                    Console.WriteLine("\nEnter the coordinates of destination cell");
                    do
                    {
                        Console.Write("Row = ");
                        isInt = Int32.TryParse(Console.ReadLine(), out array[2]);
                        if (!isInt || array[2] < 0 || array[2] >= maze.GetLength(0))
                        {
                            Console.WriteLine($"\nEnter a valid positive integer x such that 0 <= x < {maze.GetLength(0)}");
                        }
                    }
                    while (!isInt || array[2] < 0 || array[2] >= maze.GetLength(0));

                    do
                    {
                        Console.Write("Column = ");
                        isInt = Int32.TryParse(Console.ReadLine(), out array[3]);
                        if (!isInt || array[3] < 0 || array[3] >= maze.GetLength(1))
                        {
                            Console.WriteLine($"\nEnter a valid positive integer x such that 0 <= x < {maze.GetLength(1)}");
                        }
                    }
                    while (!isInt || array[3] < 0 || array[3] >= maze.GetLength(1));

                    if (maze[array[2], array[3]] != ' ')
                    {
                        Console.WriteLine($"\nGiven destination cell ({array[0]}, {array[1]}) is not a passable cell. Only passable cell can be used as destination cell.");
                    }
                }
                while (maze[array[2], array[3]] != ' ');

                if(array[0] == array[2] && array[1] == array[3])
                {
                    Console.WriteLine("\nStarting cell and destintaion cell should be different");
                }
            }
            while (array[0] == array[2] && array[1] == array[3]);

            return array;
        }
    }
}
