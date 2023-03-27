// Convert the hexadecimal numbers FA, 2A3E, FFFF, 5A0E9 to binary and 
// decimal numeral systems.

using System.Text;

namespace Ch8Q3
{
    public static class ToBinAndDec
    {
        private static void Main()
        {
            int pad1 = 11, pad2 = 30, pad3 = 15;

            Console.WriteLine("Program to convert positive 64-bit hexadecimal numbers " +
                "to binary and decimal numeral systems");
            Console.WriteLine();
            Console.Write("Hexadecimal".PadLeft(pad1));
            Console.Write("Binary".PadLeft(pad2));
            Console.WriteLine("Decimal".PadLeft(pad3));
            Console.Write("FA".PadLeft(pad1));
            Console.Write(ConvertToBinary("FA").PadLeft(pad2));
            Console.WriteLine($"{ConvertToDecimal("FA"):n0}".PadLeft(pad3));
            Console.Write("2A3E".PadLeft(pad1));
            Console.Write(ConvertToBinary("2A3E").PadLeft(pad2));
            Console.WriteLine($"{ConvertToDecimal("2A3E"):n0}".PadLeft(pad3));
            Console.Write("FFFF".PadLeft(pad1));
            Console.Write(ConvertToBinary("FFFF").PadLeft(pad2));
            Console.WriteLine($"{ConvertToDecimal("FFFF"):n0}".PadLeft(pad3));
            Console.Write("5A0E9".PadLeft(pad1));
            Console.Write(ConvertToBinary("5A0E9").PadLeft(pad2));
            Console.WriteLine($"{ConvertToDecimal("5A0E9"):n0}".PadLeft(pad3));
        }


        private static string ConvertToBinary(string hex)
        {
            // Method to convert positive 64-bit hexadecimal numbers to binary

            hex = hex.ToUpper();
            Dictionary<char, int> hexMap = new Dictionary<char, int>();
            hexMap.Add('0', 0);
            hexMap.Add('1', 1);
            hexMap.Add('2', 2);
            hexMap.Add('3', 3);
            hexMap.Add('4', 4);
            hexMap.Add('5', 5);
            hexMap.Add('6', 6);
            hexMap.Add('7', 7);
            hexMap.Add('8', 8);
            hexMap.Add ('9', 9);
            hexMap.Add('A', 10);
            hexMap.Add('B', 11);
            hexMap.Add('C', 12);
            hexMap.Add('D', 13);
            hexMap.Add('E', 14);
            hexMap.Add('F', 15);

            StringBuilder sb = new StringBuilder();

            for(int i = hex.Length - 1; i >= 0; i--)
            {
                int num = hexMap[hex[i]];

                for(int j = 1; j <= 4; j++)
                {
                    if(num > 0)
                    {
                        int r = num % 2;
                        sb.Insert(0, r);
                        num /= 2;
                    }
                    else
                    {
                        sb.Insert(0, 0);
                    }
                }

                sb.Insert(0, ' ');
            }

            string binary = sb.ToString();
            binary = binary.Trim();
            
            return binary.TrimStart('0');
        }


        private static long ConvertToDecimal(string hex)
        {
            // Method to convert positive 64-bit hexadecimal number to decimal

            hex = hex.ToUpper();
            Dictionary<char, int> hexMap = new Dictionary<char, int>();
            hexMap.Add('0', 0);
            hexMap.Add('1', 1);
            hexMap.Add('2', 2);
            hexMap.Add('3', 3);
            hexMap.Add('4', 4);
            hexMap.Add('5', 5);
            hexMap.Add('6', 6);
            hexMap.Add('7', 7);
            hexMap.Add('8', 8);
            hexMap.Add('9', 9);
            hexMap.Add('A', 10);
            hexMap.Add('B', 11);
            hexMap.Add('C', 12);
            hexMap.Add('D', 13);
            hexMap.Add('E', 14);
            hexMap.Add('F', 15);

            int pow = hex.Length - 1;
            long num = 0L;

            for(int i = 0; i < hex.Length; i++, pow--)
            {
                num += hexMap[hex[i]] * (long)Math.Pow(16, pow);
            }

            return num;
        }
    }
}