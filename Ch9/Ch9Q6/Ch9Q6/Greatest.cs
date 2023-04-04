// Write a method that returns the position of the first occurrence of an 
// element from an array, such that it is greater than its two neighbors 
// simultaneously. Otherwise the result must be -1.

namespace Ch9Q6
{
    public static class Greatest
    {
        private static void Main()
        {
            int len;

            Console.WriteLine("Program to return the index of the first occurrence " +
                "of an element from given array such that it is greater than its two " +
                "neighbours simultaneously");
            len = GetInt("Enter length of array = ", 1);
            int[] array = new int[len];
            Console.WriteLine("\nInitialize array");
            for(int i = 0; i < len; i++)
            {
                array[i] = GetInt($"Element[{i}] = ");
            }

            Console.WriteLine();
            PrintArray(array);
            Console.WriteLine();
            Console.WriteLine(GetIndexOfFirstElementGreaterThanItsNeighbours(array));
        }


        private static int GetInt(string prompt, int? min = null)
        {
            // Method to take user input as int value greater than or equal to min value

            int num;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if(!isInt || (min != null && num < min))
                {
                    Console.WriteLine("\nEnter a valid integer 'x' such that");
                    if(min != null)
                    {
                        Console.WriteLine($"{min} <= x <= {Int32.MaxValue}");
                    }
                    else
                    {
                        Console.WriteLine($"{Int32.MinValue} <= x <= {Int32.MaxValue}");
                    }
                }
            }
            while (!isInt || (min != null && num < min));

            return num;
        }


        private static void PrintArray(int[] array)
        {
            // Method to print int array

            if(array.Length == 1)
            {
                Console.WriteLine($"{{{array[0]}}}");
                return;
            }

            for(int i = 0; i < array.Length; i++)
            {
                if(i == 0)
                {
                    Console.Write($"{{{array[i]}, ");
                }
                else if(i > 0 && i < array.Length - 1)
                {
                    Console.Write($"{array[i]}, ");
                }
                else
                {
                    Console.WriteLine($"{array[i]}}}");
                }
            }
        }


        private static int GetIndexOfFirstElementGreaterThanItsNeighbours(int[] array)
        {
            // Method to return index of first element which is greater than its
            // neighbours otherwise return -1

            for(int i = 0; i < array.Length; i++)
            {
                bool isGreaterThanPrevious = true;
                bool isGreaterThanSuccessor = true;

                if(i - 1 >= 0)
                {
                    isGreaterThanPrevious = array[i] > array[i - 1];
                }

                if(i + 1 < array.Length)
                {
                    isGreaterThanSuccessor = array[i] > array[i + 1];
                }

                if(isGreaterThanPrevious && isGreaterThanSuccessor)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}