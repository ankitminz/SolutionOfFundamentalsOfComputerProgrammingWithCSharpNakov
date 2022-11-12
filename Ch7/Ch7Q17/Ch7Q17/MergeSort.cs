// Write a program, which sorts an array of integer elements using a "merge
// sort" algorithm.

namespace Ch7Q17
{
    public static class MergeSort
    {
        private static void Main()
        {
            int len;
            bool isInt;

            Console.WriteLine("Program to sort given array using merge sort algorithm");
            Console.WriteLine();
            do
            {
                Console.Write("Enter length of array = ");
                isInt = Int32.TryParse(Console.ReadLine(), out len);
                if(!isInt || len <= 0)
                {
                    Console.WriteLine("\nEnter a valid integer 'x' such that" +
                        $"\n0 < x <= {Int32.MaxValue}");
                }
            }
            while (!isInt || len <= 0);

            int[] nums = new int[len];
            
            Initialize(nums);
            Console.WriteLine("\nGiven array -");
            PrintArray(nums);
            BottomUpMerge(nums);
            Console.WriteLine("\nSorted array -");
            PrintArray(nums);
        }


        private static void Initialize(int[] array)
        {
            // Method to initialize array

            bool isInt;

            for(int i = 0; i < array.Length; i++)
            {
                do
                {
                    Console.Write($"Element[{i}] = ");
                    isInt = Int32.TryParse(Console.ReadLine(),out array[i]);
                    if (!isInt)
                    {
                        Console.WriteLine("\nEnter a valid integer 'x' such that" +
                            $"\n{Int32.MinValue} <= x <= {Int32.MaxValue}");
                    }
                }
                while (!isInt);
            }
        }


        private static void PrintArray(int[] array)
        {
            // Method to print array

            int len = array.Length;

            for(int i = 0; i < len; i++)
            {
                if(len == 1)
                {
                    Console.WriteLine($"{{{array[i]}}}");
                    break;
                }

                if(i == 0)
                {
                    Console.Write($"{{{array[i]}, ");
                }
                else if(i > 0 && i < len - 1)
                {
                    Console.Write($"{array[i]}, ");
                }
                else
                {
                    Console.WriteLine($"{array[i]}}}");
                }
            }
        }


        private static void BottomUpMerge(int[] A)
        {
            // Method to sort array using merge sort algorithm

            int len = A.Length;
            int[] B = new int[len];

            CopyArray(A, B, len);
            for(int w = 1; w < len; w *= 2) // width of runs - 1, 2, 4, 8, ...
            {
                for(int i = 0; i < len; i += w * 2) // start index of every two runs
                {
                    SortInAscendingOrder(A, B, i, Math.Min(i + w, len), Math.Min(i + w * 2, len), w); // sort runs of width w
                }

                CopyArray(B, A, len);
            }
        }


        private static void CopyArray(int[] A, int[] B, int len)
        {
            // Method to copy elements of first array into second array

            for(int i = 0; i < len; i++)
            {
                B[i] = A[i];
            }
        }


        private static void SortInAscendingOrder(int[] A, int[] B, int left, int right, int end, int width)
        {
            // Method to sort and merge left and right runs if right run exist
            // If i = leftStartIndex, j = rightStartIndex, w = width
            // Left run [i : j - 1]
            // Right run [j : w - 1]

            int i = left;
            int j = right;
            int mid = j;

            for(int k = left; k < end; k++)
            {
                if(i < mid && (j >= end || A[i] <= A[j]))
                {
                    B[k] = A[i];
                    i++;
                }
                else
                {
                    B[k] = A[j];
                    j++;
                }
            }
        }
    }
}