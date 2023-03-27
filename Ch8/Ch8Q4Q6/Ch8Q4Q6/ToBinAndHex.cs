// Write a program that converts a decimal number to binary one.
// Write a program that converts a decimal number to hexadecimal one.

using System.Text;

namespace Ch8Q4Q6
{
    public static class ToBinAndHex
    {
        private static void Main()
        {
            long num;

            Console.WriteLine("Program to convert decimal to binary and hexadecimal");
            num = GetNum("Enter a number = ");
            Console.WriteLine($"Binary = {DecimalToBinary(num)}");
            Console.WriteLine($"Hexadecimal = {DecimalToHex(num)}");
        }


        private static string DecimalToBinary(long num)
        {
            // Method to convert 64-bit decimal number to binary using 2's complement method
            // Don't work of minimum value of long integer

            bool isNegative = num < 0;
            StringBuilder sb = new StringBuilder();
            int count = 1;
            int noOfSpaces = 0;

            num = Math.Abs(num);
            do // Logic to convert decimal to binary
            {
                int r = (int)(num % 2);
                sb.Insert(0, r);
                num /= 2;
                if(count % 4 == 0)
                {
                    sb.Insert(0, ' ');
                    noOfSpaces++;
                }

                count++;
            }
            while (num > 0);

            if (isNegative)
            {
                while(sb.Length - noOfSpaces < 64) // Making binary 64-bit
                {
                    sb.Insert(0, 0);
                    if((sb.Length - noOfSpaces) % 4 == 0)
                    {
                        sb.Insert(0, ' ');
                        noOfSpaces++;
                    }
                }

                sb.Replace('0', '2'); // Logic to inverse bits
                sb.Replace('1', '0');
                sb.Replace('2', '1');

                for(int i = sb.Length - 1; i >= 0; i--) // Logic to add 1
                {
                    if(sb[i] == '0')
                    {
                        sb.Replace('0', '1', i, 1);
                        break;
                    }
                    else
                    {
                        sb.Replace('1', '0', i, 1);
                    }
                }
            }

            string binary = sb.ToString();
            return binary.Trim();
        }


        private static long GetNum(string prompt)
        {
            // Method to user input a number

            long num;
            bool isLong = false;

            do
            {
                Console.Write(prompt);
                isLong = Int64.TryParse(Console.ReadLine(), out num);
                if (!isLong)
                {
                    Console.WriteLine("\nEnter a valid integer 'x' such that" +
                        $"\n{Int64.MinValue} <= x <= {Int64.MaxValue}");
                }
            }
            while (!isLong);

            return num;
        }


        private static string DecimalToHex(long num)
        {
            // Method to convert decimal number to hexadecimal using 2's complement method
            // Don't work for mininmum value of long integer

            bool isNegative = num < 0;
            num = Math.Abs(num);
            int count = 1;
            int noOfSpaces = 0;
            StringBuilder sb = new StringBuilder();
            Dictionary<int, char> hexMap = new Dictionary<int, char>();
            hexMap[0] = '0';
            hexMap[1] = '1';
            hexMap[2] = '2';
            hexMap[3] = '3';
            hexMap[4] = '4';
            hexMap[5] = '5';
            hexMap[6] = '6';
            hexMap[7] = '7';
            hexMap[8] = '8';
            hexMap[9] = '9';
            hexMap[10] = 'A';
            hexMap[11] = 'B';
            hexMap[12] = 'C';
            hexMap[13] = 'D';
            hexMap[14] = 'E';
            hexMap[15] = 'F';

            Dictionary<char, int> reverseHexMap = new Dictionary<char, int>();
            foreach(KeyValuePair<int, char> kvp in hexMap)
            {
                reverseHexMap[kvp.Value] = kvp.Key;
            }

            do // Logic to convert decimal to hexadecimal
            {
                int r = (int)(num % 16);
                num /= 16;
                sb.Insert(0, hexMap[r]);
                if(count % 4 == 0)
                {
                    sb.Insert(0, ' ');
                    noOfSpaces++;
                }
                count++;
            }
            while (num > 0);

            if (isNegative)
            {
                while(sb.Length - noOfSpaces < 16) // Making hexadecimal 64-bit
                {
                    sb.Insert(0, 0);
                    if((sb.Length - noOfSpaces) % 4 == 0)
                    {
                        sb.Insert(0, ' ');
                        noOfSpaces++;
                    }
                }

                for(int i = 0; i < sb.Length; i++) // Logic to inverse bits
                {
                    if(sb[i] == ' ')
                    {
                        continue;
                    }

                    sb.Replace(sb[i], hexMap[15 - reverseHexMap[sb[i]]], i, 1);
                }

                for(int i = sb.Length - 1; i >= 0; i--) // Logic to add 1
                {
                    if(sb[i] == ' ')
                    {
                        continue;
                    }
                    else if(sb[i] != 'F')
                    {
                        sb.Replace(sb[i], hexMap[reverseHexMap[sb[i]] + 1], i, 1);
                        break;
                    }
                    else
                    {
                        sb.Replace('F', '0', i, 1);
                    }
                }
            }

            string hex = sb.ToString();
            return hex.Trim();
        }
    }
}