// Program to find maximum area of neighbouring passable cells in a maze
// Various cells of maze -
// ' ' - Passable cell
// '*' - Impassable cell
// 'p' - Pending cell (Enqueued but not searched)
// 's' - Searched cell
// 'a' - Maximum area cell

using System;
using System.Collections.Generic;

namespace Ch10Q13
{
    class LargestAreaOfNeighbouringPassableCells
    {
        static void Main()
        {
            char[,] maze1 =
            {
                {'*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
                {'*', ' ', ' ', ' ', ' ', ' ', '*', ' ', '*', ' ', ' ', '*' },
                {'*', ' ', ' ', ' ', ' ', ' ', '*', ' ', '*', ' ', ' ', '*' },
                {'*', ' ', ' ', ' ', ' ', ' ', '*', ' ', '*', ' ', ' ', '*' },
                {'*', ' ', ' ', ' ', ' ', ' ', '*', ' ', '*', '*', '*', '*' },
                {'*', ' ', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' ', ' ', '*' },
                {'*', ' ', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' ', ' ', '*' },
                {'*', '*', '*', '*', '*', '*', ' ', ' ', ' ', ' ', ' ', '*' },
                {'*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*' },
                {'*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*' },
                {'*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*' },
                {'*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            };

            char[,] maze2 =
            {
                {'*', '*', '*' },
                {'*', '*', '*' },
                {'*', '*', '*' },
            };

            FindLargestAreaOfPassableCellsIn(maze1);
        }


        static int[,] BFS(char[,] maze, int currentRow, int currentCol)
        {
            // Method to search for neighbouring passable cells

            Queue<int> qRows = new Queue<int>();
            Queue<int> qCols = new Queue<int>();

            Queue<int> rQRow = new Queue<int>();
            Queue<int> rQCol = new Queue<int>();

            qRows.Enqueue(currentRow);
            qCols.Enqueue(currentCol);
            while(qRows.Count != 0)
            {
                currentRow = qRows.Dequeue();
                currentCol = qCols.Dequeue();
                maze[currentRow, currentCol] = 's';
                rQRow.Enqueue(currentRow);
                rQCol.Enqueue(currentCol);
                if(IsPassable(maze, currentRow, currentCol + 1)) // Search right
                {
                    qRows.Enqueue(currentRow);
                    qCols.Enqueue(currentCol + 1);
                    maze[currentRow, currentCol + 1] = 'p';
                }

                if(IsPassable(maze, currentRow + 1, currentCol)) // Search down
                {
                    qRows.Enqueue(currentRow + 1);
                    qCols.Enqueue(currentCol);
                    maze[currentRow + 1, currentCol] = 'p';
                }

                if(IsPassable(maze, currentRow, currentCol - 1)) // Search left
                {
                    qRows.Enqueue(currentRow);
                    qCols.Enqueue(currentCol - 1);
                    maze[currentRow, currentCol - 1] = 'p';
                }

                if(IsPassable(maze, currentRow - 1, currentCol)) // Search up
                {
                    qRows.Enqueue(currentRow - 1);
                    qCols.Enqueue(currentCol);
                    maze[currentRow - 1, currentCol] = 'p';
                }
            }

            int[,] cell = new int[rQRow.Count, 2];

            for(int row = 0; row < cell.GetLength(0); row++)
            {
                for(int col = 0; col < 2; col++)
                {
                    if(col == 0)
                    {
                        cell[row, col] = rQRow.Dequeue();
                    }
                    else
                    {
                        cell[row, col] = rQCol.Dequeue();
                    }
                }
            }

            return cell;
        }


        static bool IsPassable(char[,] maze, int nextRow, int nextCol)
        {
            // Method to check whether given cell is passable or not

            if(nextRow >= 0 && nextRow < maze.GetLength(0) && nextCol >= 0 && nextCol < maze.GetLength(1) && maze[nextRow, nextCol] == ' ')
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        static void FindLargestAreaOfPassableCellsIn(char[,] maze)
        {
            // Method to find largest area of passable cells

            Queue<int> qRow = new Queue<int>();
            Queue<int> qCol = new Queue<int>();

            Console.WriteLine("Original maze -");
            PrintOriginalMaze(maze);

            for(int row = 0; row < maze.GetLength(0); row++)
            {
                for(int col = 0; col < maze.GetLength(1); col++)
                {
                    if(maze[row, col] == ' ')
                    {
                        int[,] cell = BFS(maze, row, col);

                        if(cell.GetLength(0) > qRow.Count)
                        {
                            qRow.Clear();
                            qCol.Clear();
                            for(int tempRow = 0; tempRow < cell.GetLength(0); tempRow++)
                            {
                                for(int tempCol = 0; tempCol < cell.GetLength(1); tempCol++)
                                {
                                    if(tempCol == 0)
                                    {
                                        qRow.Enqueue(cell[tempRow, tempCol]);
                                    }
                                    else
                                    {
                                        qCol.Enqueue(cell[tempRow, tempCol]);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if(qRow.Count != 0)
            {
                int maxArea = qRow.Count;

                Console.WriteLine($"\nMaximum area = {maxArea}");
                PrintMaxArea(maze, qRow, qCol);
            }
            else
            {
                Console.WriteLine("\nNo passable cell found\nMaximum area = 0");
            }
            
        }


        static void PrintMaxArea(char[,] maze, Queue<int> qRow, Queue<int> qCol)
        {
            // Method to print max area

            while(qRow.Count != 0)
            {
                maze[qRow.Dequeue(), qCol.Dequeue()] = 'a';
            }

            for(int row = 0; row < maze.GetLength(0); row++)
            {
                for(int col = 0; col < maze.GetLength(1); col++)
                {
                    if(maze[row, col] == 's')
                    {
                        maze[row, col] = ' ';
                    }

                    Console.Write(maze[row, col]);
                }

                Console.WriteLine();
            }
        }


        static void PrintOriginalMaze(char[,] maze)
        {
            // Method to print original maze

            for(int row = 0; row < maze.GetLength(0); row++)
            {
                for(int col = 0; col < maze.GetLength(1); col++)
                {
                    Console.Write(maze[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
