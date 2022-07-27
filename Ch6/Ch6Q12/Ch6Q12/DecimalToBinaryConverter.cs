// Write a program that converts a given number from decimal to binary 
// notation (numeral system).

using System.Text;

namespace Ch6Q12
{
    public static class DecimalToBinaryConverter
    {
        public static void Main()
        {
            long decimalNum;
            bool isLong;

            Console.WriteLine("Program to convert given number from decimal to binary");
            do
            {
                Console.Write("Decimal representation = ");
                isLong = Int64.TryParse(Console.ReadLine(), out decimalNum);
                if (!isLong || decimalNum == Int64.MinValue)
                {
                    Console.WriteLine($"\nEnter a valid integer 'x' such that" + 
                        $"\n{Int64.MinValue} < x <= {Int64.MaxValue}");
                }
            }
            while (!isLong || decimalNum == Int64.MinValue);

            Console.WriteLine($"\nBinary representation: {ConvertDecimalToBinary(decimalNum)}");
        }


        private static string ConvertDecimalToBinary(long num)
        {
            byte[] binary = new byte[64];
            byte maxPow = 0;
            bool isNegative = num < 0;

            // START - Logic to find max power of 2 which is equal to or less than given
            // number
            num = Math.Abs(num);
            for(byte i = 0; i < 64; i++)
            {
                ulong temp = (ulong)Math.Pow(2, i);
                if(temp == (ulong)num)
                {
                    maxPow = i;
                    break;
                }
                else if(temp > (ulong)num)
                {
                    maxPow = (byte)(i - 1);
                    break;
                }
            }
            // END

            // START - Logic to represent given decimal number in binary
            while(num > 0)
            {
                long temp = (long)Math.Pow(2, maxPow);
                if(temp <= num)
                {
                    binary[63 - maxPow] = 1;
                    num -= temp;
                    maxPow--;
                }
                else
                {
                    binary[63 - maxPow] = 0;
                    maxPow--;
                }
            }
            // END

            // START - Logic to represent negative numbers in binary. 2's complement method
            if (isNegative)
            {
                // START - Logic to inverse
                for(int i = 0; i < binary.Length; i++)
                {
                    if(binary[i] == 0)
                    {
                        binary[i] = 1;
                    }
                    else
                    {
                        binary[i] = 0;
                    }
                }
                // END

                // START - Logic to add 1
                for(int i = binary.Length - 1; i >= 0; i--)
                {
                    if(binary[i] == 0)
                    {
                        binary[i] = 1;
                        break;
                    }
                    else
                    {
                        binary[i] = 0;
                    }
                }
                // END
            }
            // END

            // START - Formatting logic. Logic to add space after every 4 bits
            StringBuilder sb = new StringBuilder(64 + 14);
            int count = 1;

            for(int i = 0; i < binary.Length; i++)
            {
                if(count % 5 == 0)
                {
                    sb.Append(" ");
                    count = 1;
                }
                
                sb.Append(binary[i]);
                count++;
            }
            // END

            // START - Logic to exclude unecessary zeros
            string binaryString = sb.ToString();
            int startIndex = 0;

            for(int i = 0; i < binaryString.Length; i++)
            {
                if(binaryString[i] == '1')
                {
                    startIndex = i;
                    break;
                }
            }
            // END

            return binaryString.Substring(startIndex);
        }
    }
}