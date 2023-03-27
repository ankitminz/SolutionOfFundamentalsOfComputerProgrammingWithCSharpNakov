// Write a program that converts a binary number to decimal using the
// Horner scheme.

namespace Ch8Q10
{
    public static class BinToDec
    {
        private static void Main()
        {
            Console.WriteLine("Program to convert binary to decimal using horner scheme");
            Console.Write("Enter binary = ");
            string bin = Console.ReadLine();
            Console.WriteLine($"Decimal = {BinaryToDecimal(bin):n0}");
        }


        private static long BinaryToDecimal(string binary)
        {
            // Method to convert 64-bit(2's complement) binary to decimal using horner scheme

            bool isNegative = binary.Length == 64 && binary[0] == '1';

            if (isNegative)
            {
                char[] bin = binary.ToCharArray();

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
                    if(bin[i] == '1')
                    {
                        bin[i] = '0';
                    }
                    else
                    {
                        bin[i] = '1';
                    }
                }

                binary = "";
                for(int i = 0; i < bin.Length; i++)
                {
                    binary += bin[i];
                }
            }

            long num = Int64.Parse(binary[0].ToString());

            for(int i = 1; i < binary.Length; i++) // Logic to convert binary to decimal using horner scheme
            {
                num = num * 2 + Int64.Parse(binary[i].ToString());
            }

            if (isNegative)
            {
                num *= -1;
            }

            return num;
        }
    }
}