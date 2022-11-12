// Write a program, which creates an array of 20 elements of type 
// integer and initializes each of the elements with a value equals to the 
// index of the element multiplied by 5. Print the elements to the console.

namespace Ch7Q1
{
    public static class InitAndPrintArray
    {
        public static void Main()
        {
            int[] array = new int[20];

            Console.WriteLine("Program to initialize and print array of 20 elements");
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = i * 5;
            }

            for(int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"array[{i}] = {array[i]}");
            }
        }
    }
}