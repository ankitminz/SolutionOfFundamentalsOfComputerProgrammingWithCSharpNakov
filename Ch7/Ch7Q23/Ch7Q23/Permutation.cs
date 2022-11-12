// Write a program, which reads the integer numbers N and K from the 
// console and prints all variations of K elements of the numbers in the 
// interval [1…N]. Example: N = 3, K = 2 --> { 1, 1}, { 1, 2}, { 1, 3}, { 2, 1}, 
// { 2, 2}, { 2, 3}, { 3, 1}, { 3, 2}, { 3, 3}.

namespace Ch7Q23
{
    public static class Permutation
    {
        private static void Main()
        {
            int n, k;

            Console.WriteLine("Program to find all variations of K elements of the numbers in" +
                " the interval [1…N]");
            Console.WriteLine();
            n = GetInt("Enter N = ");
            Console.WriteLine();
            k = GetInt("Enter K = ", n);
            Console.WriteLine();
            PrintPermutation(n, k);
        }


        private static int GetInt(string prompt, int max = Int32.MaxValue)
        {
            // Method to take user input of integer numbers

            int num;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if (!isInt || num < 1 || num > max)
                {
                    Console.WriteLine("\nEnter a valid integer 'x' such that" +
                        $"\n1 <= x <= {max}");
                }
            }
            while (!isInt || num < 1 || num > max);

            return num;
        }


        private static void PrintPermutation(int n, int k)
        {
            // Method to print permutation of K elements out of N elements in [1...N]

            int[] nums = new int[n];
            int[] temp = new int[k];

            InitializeArray(nums);
            FindPermutation(nums, temp, k);
        }


        private static void InitializeArray(int[] array)
        {
            // Method to initialize given array

            for(int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }
        }


        private static void FindPermutation(int[] array, int[] temp, int k)
        {
            // Method to find permuations of K elements out of N elements 
            // where N is length of given array and K is length of temp

            for(int i = 0; i < array.Length; i++)
            {
                temp[temp.Length - k] = array[i];
                if(k > 1)
                {
                    FindPermutation(array, temp, k - 1);
                }
                else if(k == 1)
                {
                    PrintArray(temp);
                }
            }
        }


        private static void PrintArray(int[] array)
        {
            // Method to print elements of given array

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
    }
}