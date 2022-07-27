// Write a program that converts a given number from binary to decimal 
// notation.

using System.Text;

namespace Ch6Q13
{
    public static class BinaryToDecimal
    {
        public static void Main()
        {
            string ?binary;

            Console.WriteLine("Program to convert given binary number into decimal");
            Console.Write("Binary representation = ");
            binary = Console.ReadLine();
            Console.WriteLine($"\nDecimal representation: {ConvertBinaryToDecimal(binary):n0}");
        }


        private static long ConvertBinaryToDecimal(string ?binary)
        {
            if(binary != null)
            {
                binary = binary.Replace(" ", "");
            }

            if(binary == null || binary == "")
            {
                return 0;
            }

            long decimalNum = 0;
            int startIndex = 0;
            bool isNegative = false;

            for(int i = 0; i < binary.Length; i++)
            {
                if(binary[i] == '1')
                {
                    startIndex = i;
                    break;
                }
            }

            if(startIndex != 0)
            {
                binary = binary.Substring(startIndex);
            }

            if(binary.Length == 64)
            {
                isNegative = true;
            }

            // START - Logic to deal with negative numbers represented by 2's complement
            // method
            if (isNegative)
            {
                int binaryLength = binary.Length;
                int[] binaryArray = new int[binaryLength];

                for(int i = 0; i < binaryLength; i++)
                {
                    binaryArray[i] = Int32.Parse(binary[i].ToString());
                }

                // START - Logic to subtract 1
                for(int i = binaryLength - 1; i >= 0; i--)
                {
                    if(binaryArray[i] == 1)
                    {
                        binaryArray[i] = 0;
                        break;
                    }
                    else
                    {
                        binaryArray[i] = 1;
                    }
                }
                // END

                // START - Logic to inverse
                for(int i = 0; i < binaryLength; i++)
                {
                    if(binaryArray[i] == 0)
                    {
                        binaryArray[i] = 1;
                    }
                    else
                    {
                        binaryArray[i] = 0;
                    }
                }
                // END

                StringBuilder sb = new StringBuilder(binaryLength);

                for(int i = 0; i < binaryLength; i++)
                {
                    sb.Append(binaryArray[i]);
                }

                binary = sb.ToString();
            }
            // END

            for(int i = binary.Length - 1, pow = 0; i >= 0; i--, pow++)
            {
                decimalNum += Int64.Parse(binary[i].ToString()) * (long)Math.Pow(2, pow);
            }

            if (isNegative)
            {
                decimalNum *= -1;
            }

            return decimalNum;
        }
    }
}