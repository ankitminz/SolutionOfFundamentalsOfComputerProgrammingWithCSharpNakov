// Convert the number 1111010110011110(2) to hexadecimal and decimal
// numeral systems.

using System.Text;

namespace Ch8Q2
{
    public static class ToHexAndDec
    {
        private static void Main()
        {
            Console.WriteLine("Program to convert 1111010110011110(2) to hexadecimal" +
                " and decimal numeral systems");
            Console.WriteLine($"Decimal = {ConvertToDecimal("1111010110011110"):n0}");
            Console.WriteLine($"Hexadecimal = {ConvertToHex("1111010110011110")}");
        }


        private static long ConvertToDecimal(string binary)
        {
            // Method to convert positive 64-bit binary number to decimal

            int pow = binary.Length - 1;
            long num = 0L;

            for(int i = 0; i < binary.Length; i++, pow--)
            {
                num += Int32.Parse(binary[i].ToString()) * (long)Math.Pow(2, pow);
            }

            return num;
        }


        private static string ConvertToHex(string binary)
        {
            // Method to convert positive 64-bit binary number to hexadecimal

            StringBuilder sb = new StringBuilder();
            int count = 0, num = 0;
            Dictionary<int, char> hexPairs = new Dictionary<int, char>();
            hexPairs.Add(0, '0');
            hexPairs.Add(1, '1');
            hexPairs.Add(2, '2');
            hexPairs.Add(3, '3');
            hexPairs.Add(4, '4');
            hexPairs.Add(5, '5');
            hexPairs.Add(6, '6');
            hexPairs.Add(7, '7');
            hexPairs.Add(8, '8');
            hexPairs.Add(9, '9');
            hexPairs.Add(10, 'A');
            hexPairs.Add(11, 'B');
            hexPairs.Add(12, 'C');
            hexPairs.Add(13, 'D');
            hexPairs.Add(14, 'E');
            hexPairs.Add(15, 'F');

            for(int i = binary.Length - 1; i >= 0; i--, count++)
            {
                if(count == 4)
                {
                    count = 0;
                }

                num += Int32.Parse(binary[i].ToString()) * (int)Math.Pow(2, count);
                if(count >= 3 || i == 0)
                {
                    sb.Insert(0, hexPairs[num]);
                    num = 0;
                }
            }

            count = 1;
            for(int i = sb.Length - 1; i >= 0; i--)
            {
                if(count == 4)
                {
                    sb.Insert(i, ' ');
                    count = 1;
                }
                else
                {
                    count++;
                }
            }

            string hex = sb.ToString();

            return hex.Trim();
        }
    }
}