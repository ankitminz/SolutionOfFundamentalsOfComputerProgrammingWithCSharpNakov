// Write a program, which reads an integer number N from the console and 
// prints all combinations of K elements of numbers in range [1 … N].
// Example: N = 5, K = 2 --> { 1, 2}, { 1, 3}, { 1, 4}, { 1, 5}, { 2, 3}, { 2, 4}, 
// { 2, 5}, { 3, 4}, { 3, 5}, { 4, 5}.

namespace Ch7Q24
{
    public static class Combination
    {
        private static void Main()
        {
            int n, k;

            Console.WriteLine("Program to print all combinations of K elements of " +
                "numbers in range [1 … N].");
            Console.WriteLine();
            n = GetInt("Enter N = ");
            Console.WriteLine();
            k = GetInt("Enter K = ", n);
            Console.WriteLine();
            PrintCombination(n, k);
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
                if(!isInt || num < 1 || num > max)
                {
                    Console.WriteLine("\nEnter a valid integer 'x' such that" +
                        $"\n1 <= x <= {max}");
                }
            }
            while (!isInt || num < 1 || num > max);

            return num;
        }


        private static void PrintCombination(int n, int k)
        {
            // Method to print combination of K elements in range [1...N]

            int[] nums = new int[n];
            int[] temp = new int[k];

            InitializeArray(nums);
            FindCombination(nums, temp, k);
        }


        private static void InitializeArray(int[] array)
        {
            // Method to initialize given array

            for(int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }
        }


        private static void FindCombination(int[] array, int[] temp, int k, int startIndex = 0)
        {
            // Method to find combination of K elements in range [1...N]
            // where N is length of array and K is length of temp array

            for(int i = startIndex; i < array.Length; i++)
            {
                temp[temp.Length - k] = array[i];
                if(k > 1)
                {
                    FindCombination(array, temp, k - 1, i + 1);
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