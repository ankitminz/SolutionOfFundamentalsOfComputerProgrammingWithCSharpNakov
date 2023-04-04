// Write a method that calculates the sum of two very long positive 
// integer numbers. The numbers are represented as array digits and
// the last digit (the ones) is stored in the array at index 0. Make the 
// method work for all numbers with length up to 10,000 digits.

using System.Text;

namespace Ch9Q8
{
    public static class AddingBigNums
    {
        private static void Main()
        {
            int[] n1, n2;

            Console.WriteLine("Program to add very long positive integer numbers " +
                "given by user");
            n1 = GetNum("Enter first number = ");
            Console.WriteLine();
            n2 = GetNum("Enter second number = ");
            Console.WriteLine($"\nSum = {Add(n1, n2)}");
        }


        private static int[] GetNum(string prompt)
        {
            // Method to take user input positive integer number

            int[] n;
            string num;
            bool isInt = false;

            do
            {
                Console.Write(prompt);
                num = Console.ReadLine();
                n = new int[num.Length];
                for(int i = 0; i < num.Length; i++)
                {
                    isInt = Int32.TryParse(num[i].ToString(), out n[n.Length - 1 - i]);
                    if (!isInt || num.Length > 10000)
                    {
                        Console.WriteLine("\nEnter a valid positive integer upto 10,000 " +
                            "digits");
                        break;
                    }
                }
            }
            while (!isInt || num.Length > 10000);

            return n;
        }


        private static string Add(int[] n1, int[] n2)
        {
            // Method to add two very long positive integers upto 10,000 digits

            int[] sum = new int[10005];
            int carry = 0;
            int s = 0;
            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < sum.Length; i++)
            {
                if(i < n1.Length && i < n2.Length)
                {
                    s = n1[i] + n2[i] + carry;
                }
                else if(i < n1.Length)
                {
                    s = n1[i] + carry;
                }
                else if(i < n2.Length)
                {
                    s = n2[i] + carry;
                }
                else if (carry != 0)
                {
                    s = carry;
                }
                else
                {
                    break;
                }

                sum[i] = s % 10;
                carry = s / 10;
            }

            for(int i = sum.Length - 1; i >= 0; i--)
            {
                if(sum[i] != 0)
                {
                    for(int j = i; j >= 0; j--)
                    {
                        sb.Append(sum[j]);
                    }

                    break;
                }
            }

            int chunkLength = 3;
            for(int i = sb.Length - 1, count = 1; i >= 0; --i, count++)
            {
                if(count % chunkLength == 0 && i != 0)
                {
                    sb.Insert(i, ',');
                }
            }

            return sb.ToString();
        }
    }
}