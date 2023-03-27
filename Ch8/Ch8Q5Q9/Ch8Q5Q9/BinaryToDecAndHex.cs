// Write a program that converts a binary number to decimal one.
// Write a program that converts a binary number to hexadecimal one.

using System.Text;

namespace Ch8Q5Q9
{
    public static class BinaryToDecAndHex
    {
        private static void Main()
        {
            Console.WriteLine("Program to convert 64-bit binary to decimal and " +
                "hexadecimal using 2's complement method");
            Console.Write("Enter binary = ");
            string bin = Console.ReadLine();
            Console.WriteLine($"Decimal = {BinaryToDecimal(bin):n0}");
            Console.WriteLine($"Hexadecimal = {BinaryToHex(bin)}");
        }


        private static long BinaryToDecimal(string binary)
        {
            // Method to convert 64-bit binary to decimal using 2's complement method

            bool isNegative = binary.Length == 64 && binary[0] == '1';
            char[] bin = binary.ToCharArray();
            long num = 0;

            if (isNegative)
            {
                for(int i = bin.Length - 1; i >= 0; i--) // Logic to subtract 1
                {
                    if(bin[i] == '1')
                    {
                        bin[i] = '0';
                        break;
                    }
                    else
                    {
                        bin[i] = '1';
                    }
                }

                for(int i = 0; i < bin.Length; i++) // Logic to inverse bits
                {
                    if(bin[i] == '0')
                    {
                        bin[i] = '1';
                    }
                    else
                    {
                        bin[i] = '0';
                    }
                }

                bool foundStart = false;
                binary = "";
                for(int i = 0; i < bin.Length; i++) // Logic to remove starting 0's
                {
                    if (!foundStart && bin[i] == '1')
                    {
                        foundStart = true;
                    }

                    if (foundStart)
                    {
                        binary = binary + bin[i];
                    }
                }
            }

            int pow = binary.Length - 1;
            for (int i = 0; i < binary.Length; i++, pow--) // Logic to convert binary to decimal
            {
                num += Int32.Parse(binary[i].ToString()) * (long)Math.Pow(2, pow);
            }

            if (isNegative)
            {
                num *= -1;
            }

            return num;
        }


        private static string BinaryToHex(string binary)
        {
            // Method to convert 64-bit binary to hexadecimal using 2's complement method

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

            StringBuilder sb = new StringBuilder();
            int num = 0;
            int pow = 0;
            int count = 0;

            for(int i = binary.Length - 1; i >= 0; i--) // Logic to convert binary to hex
            {
                num += Int32.Parse(binary[i].ToString()) * (int)Math.Pow(2, pow);
                pow++;
                count++;
                if(pow == 4 || i == 0)
                {
                    sb.Insert(0, hexMap[num]);
                    if (count % 16 == 0)
                    {
                        sb.Insert(0, ' ');
                    }

                    num = 0;
                    pow = 0;
                }
            }

            string hex = sb.ToString();
            return hex;
        }
    }
}