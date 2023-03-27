// Write a program that converts a hexadecimal number to decimal one.
// Write a program that converts a hexadecimal number to binary one.

using System.Text;

namespace Ch8Q7Q8
{
    public static class HexToBinAndDec
    {
        private static void Main()
        {
            Console.WriteLine("Program to convert hexadecimal to decimal and binary " +
                "using 2's complement method");
            Console.Write("Enter hexadecimal number = ");
            string hex = Console.ReadLine();
            Console.WriteLine($"Decimal = {HexToDecimal(hex):n0}");
            Console.WriteLine($"Binary = {HexToBinary(hex)}");
        }


        private static long HexToDecimal(string hex)
        {
            // Method to convert 64-bit hexadecimal to decimal using 2's complement method

            Dictionary<char, int> hexMap = new Dictionary<char, int>();
            hexMap['0'] = 0;
            hexMap['1'] = 1;
            hexMap['2'] = 2;
            hexMap['3'] = 3;
            hexMap['4'] = 4;
            hexMap['5'] = 5;
            hexMap['6'] = 6;
            hexMap['7'] = 7;
            hexMap['8'] = 8;
            hexMap['9'] = 9;
            hexMap['A'] = 10;
            hexMap['B'] = 11;
            hexMap['C'] = 12;
            hexMap['D'] = 13;
            hexMap['E'] = 14;
            hexMap['F'] = 15;

            Dictionary<int, char> inverseHexMap = new Dictionary<int, char>();
            foreach(KeyValuePair<char, int> kvp in hexMap)
            {
                inverseHexMap[kvp.Value] = kvp.Key;
            }

            hex = hex.ToUpper();
            bool isNegative = hex.Length == 16 && hexMap[hex[0]] > 7;

            if (isNegative)
            {
                char[] hexArray = hex.ToCharArray();
                for(int i = hexArray.Length - 1; i >= 0; i--) // Logic to subtract 1
                {
                    if(hexArray[i] != '0')
                    {
                        hexArray[i] = inverseHexMap[hexMap[hexArray[i]] - 1];
                        break;
                    }
                    else
                    {
                        hexArray[i] = 'F';
                    }
                }

                for(int i = 0; i < hexArray.Length; i++) // Logic to inverse bits
                {
                    hexArray[i] = inverseHexMap[15 - hexMap[hexArray[i]]];
                }

                bool startValueNotZero = false;
                hex = "";
                for(int i = 0; i < hexArray.Length; i++) // Logic to remove starting 0's
                {
                    if(hexArray[i] != '0')
                    {
                        startValueNotZero = true;
                    }

                    if (startValueNotZero)
                    {
                        hex += hexArray[i];
                    }
                }
            }

            int pow = hex.Length - 1;
            long num = 0L;
            for(int i = 0; i < hex.Length; i++, pow--) // Logic to convert hexadecimal to decimal
            {
                num += hexMap[hex[i]] * (long)Math.Pow(16, pow);
            }

            if (isNegative)
            {
                num *= -1;
            }

            return num;
        }


        private static string HexToBinary(string hex)
        {
            // Method to convert hexadecimal to binary using 2's complement method

            hex = hex.ToUpper();
            StringBuilder sb = new StringBuilder();
            Dictionary<char, int> hexMap = new Dictionary<char, int>();
            hexMap['0'] = 0;
            hexMap['1'] = 1;
            hexMap['2'] = 2;
            hexMap['3'] = 3;
            hexMap['4'] = 4;
            hexMap['5'] = 5;
            hexMap['6'] = 6;
            hexMap['7'] = 7;
            hexMap['8'] = 8;
            hexMap['9'] = 9;
            hexMap['A'] = 10;
            hexMap['B'] = 11;
            hexMap['C'] = 12;
            hexMap['D'] = 13;
            hexMap['E'] = 14;
            hexMap['F'] = 15;

            for(int i = hex.Length - 1; i >= 0; i--) // Logic to convert hexadecimal to binary
            {
                int num = hexMap[hex[i]];

                for(int count = 1; count <= 4; count++)
                {
                    if(num > 0)
                    {
                        int r = num % 2;
                        sb.Insert(0, r);
                        num /= 2;
                    }
                    else if(i != 0 || (hex.Length == 1 && count == 1))
                    {
                        sb.Insert(0, 0);
                    }
                    else
                    {
                        break;
                    }

                    if(count == 4)
                    {
                        sb.Insert(0, ' ');
                    }
                }
            }

            string binary = sb.ToString();
            return binary.Trim();
        }
    }
}