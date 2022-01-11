using System;
using System.Collections.Generic;

namespace Ch11Q10
{
    class SequenceOfPositiveIntegerNums
    {
        static void Main()
        {
            string nums;

            Console.WriteLine("Program to calculate sum of positive integers given as string of numbers seperated by commas");
            Console.WriteLine("Enter string of integers separated by commas");
            nums = Console.ReadLine();
            Console.WriteLine($"\nSum = {GetSum(nums)}");
        }


        static int GetSum(string stringOfNums)
        {
            string[] array = stringOfNums.Replace(" ", "").Split(',', StringSplitOptions.RemoveEmptyEntries);
            int[] nums = new int[array.Length];
            int sum = 0;

            for(int i = 0; i < array.Length; i++)
            {
                Int32.TryParse(array[i], out nums[i]);
            }

            for(int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }

            return sum;
        }
    }
}
