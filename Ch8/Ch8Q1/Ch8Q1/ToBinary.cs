// Convert the numbers 151, 35, 43, 251, 1023 and 1024 to the binary 
// numeral system.

using System.Text;

namespace Ch8Q1
{
    public static class ToBinary
    {
        private static void Main()
        {
            int pad1 = 8, pad2 = 15;

            Console.WriteLine("Program to convert positive decimal numbers to binary");
            Console.Write("Decimal".PadLeft(pad1));
            Console.Write("Binary".PadLeft(pad2) + "\n");
            Console.Write("151".PadLeft(pad1));
            Console.Write(ConvertToBinary(151).PadLeft(pad2) + "\n");
            Console.Write("35".PadLeft(pad1));
            Console.Write(ConvertToBinary(35).PadLeft(pad2) + "\n");
            Console.Write("43".PadLeft(pad1));
            Console.Write(ConvertToBinary(43).PadLeft(pad2) + "\n");
            Console.Write("251".PadLeft(pad1));
            Console.Write(ConvertToBinary(251).PadLeft(pad2) + "\n");
            Console.Write("1023".PadLeft(pad1));
            Console.Write(ConvertToBinary(1023).PadLeft(pad2) + "\n");
            Console.Write("1024".PadLeft(pad1));
            Console.WriteLine(ConvertToBinary(1024).PadLeft(pad2) + "\n");
        }


        private static string ConvertToBinary(int num)
        {
            // Method to convert given positive decimal integer to binary

            StringBuilder sb = new StringBuilder();
            int count = 0;

            do
            {
                if(count != 0 && count % 4 == 0)
                {
                    sb.Insert(0, ' ');
                }

                int r = num % 2;
                sb.Insert(0, r);
                num /= 2;
                count++;
            }
            while (num > 0);

            string binary = sb.ToString();
            return binary;
        }
    }
}