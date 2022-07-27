// Write a program that converts a given number from decimal to 
// hexadecimal notation.

using System.Text;

namespace Ch6Q14
{
    public static class DecimalToHex
    {
        public static void Main()
        {
            long num;
            bool isLong;

            Console.WriteLine("Program to covert decimal number to hexadecimal");
            do
            {
                Console.Write("Decimal representation = ");
                isLong = Int64.TryParse(Console.ReadLine(), out num);
                if (!isLong || num == Int64.MinValue)
                {
                    Console.WriteLine("\nEnter a valid integer 'x' such that" + 
                        $"\n{Int64.MinValue} < x <= {Int64.MaxValue}");
                }
            }
            while(!isLong || num == Int64.MinValue);

            Console.WriteLine($"\nHexadecimal representation: {ConvertDecimalToHex(num)}");
        }


        private static string ConvertDecimalToHex(long num)
        {
            char[] hex = new char[16];
            Init(hex);
            Dictionary<int, char> hexMap = new Dictionary<int, char>();
            InitDictionary(hexMap);
            Dictionary<char, int> invertHexMap = Invert(hexMap);
            int maxPow = 0;
            bool isNegative = false;

            if(num < 0)
            {
                isNegative = true;
                num = Math.Abs(num);
            }

            // START - Logic to find max power of 16
            for(int i = 0; i < 16; i++)
            {
                long temp = (long)Math.Pow(16, i);

                if(temp == num)
                {
                    maxPow = i;
                    break;
                }
                else if(temp > num)
                {
                    maxPow = i - 1;
                    break;
                }
                else if(i == 15)
                {
                    maxPow = 15;
                    break;
                }
            }
            // END

            // START - Logic to convert decimal to hexadecimal
            for (int pow = maxPow; pow >= 0; pow--)
            {
                long temp = (long)Math.Pow(16, pow);

                if (temp <= num)
                {
                    for (int key = 1; key <= 16; key++)
                    {
                        ulong temp2 = (ulong)(temp * key);

                        if (temp2 == (ulong)num)
                        {
                            hex[15 - pow] = hexMap[key];
                            num -= (long)temp2;
                            break;
                        }
                        else if (temp2 > (ulong)num)
                        {
                            temp2 = (ulong)(temp * (key - 1));
                            num -= (long)temp2;
                            hex[15 - pow] = hexMap[key - 1];
                            break;
                        }
                    }
                }
                else
                {
                    hex[15 - pow] = hexMap[0];
                }
            }
            // END

            // START - Logic to deal with negative numbers
            if (isNegative)
            {
                // START - Logic to invert hexadecimal number
                for (int i = 0; i < hex.Length; i++)
                {
                    hex[i] = hexMap[15 - invertHexMap[hex[i]]];
                }
                // END

                // START - Logic to add 1 to hexadecimal number
                for(int i = hex.Length - 1; i >= 0; i--)
                {
                    int key = invertHexMap[hex[i]];

                    if(key == hexMap.Count - 1)
                    {
                        hex[i] = hexMap[0];
                        continue;
                    }
                    else
                    {
                        hex[i] = hexMap[key + 1];
                        break;
                    }
                }
                // END
            }
            // END
            
            // START - Formatting logic. Logic to add space after every 4 characters
            StringBuilder sb = new StringBuilder(19);
            int count = 1;
            for(int i = 0; i < hex.Length; i++)
            {
                sb.Append(hex[i]);
                count++;
                if(count == 5)
                {
                    sb.Append(' ');
                    count = 1;
                }
            }
            // END

            // START - Logic to exclude unnecessary zeros
            int startIndex = 0;

            for(int i = 0; i < sb.Length; i++)
            {
                if(sb[i] != '0' && sb[i] != ' ')
                {
                    startIndex = i;
                    break;
                }
                else if(i == sb.Length - 1)
                {
                    startIndex = sb.Length - 2;
                }
            }

            return sb.ToString(startIndex, sb.Length - startIndex);
            // END
        }


        private static void Init(char[] array)
        {
            // Method to initialize array having hexadecimal representation

            for(int i = 0; i < array.Length; i++)
            {
                array[i] = '0';
            }
        }


        private static void InitDictionary(Dictionary<int, char> myDictionary)
        {
            // Method to map hexadecimal characters with decimal characters

            myDictionary.Clear();
            myDictionary.Add(0, '0');
            myDictionary.Add(1, '1');
            myDictionary.Add(2, '2');
            myDictionary.Add(3, '3');
            myDictionary.Add(4, '4');
            myDictionary.Add(5, '5');
            myDictionary.Add(6, '6');
            myDictionary.Add(7, '7');
            myDictionary.Add(8, '8');
            myDictionary.Add(9, '9');
            myDictionary.Add(10, 'A');
            myDictionary.Add(11, 'B');
            myDictionary.Add(12, 'C');
            myDictionary.Add(13, 'D');
            myDictionary.Add(14, 'E');
            myDictionary.Add(15, 'F');
        }


        private static Dictionary<char, int> Invert(Dictionary<int, char> myDictionary)
        {
            // Method to invert dictionary

            Dictionary<char, int> result = new Dictionary<char, int>();

            foreach(KeyValuePair<int, char> pair in myDictionary)
            {
                result.Add(pair.Value, pair.Key);
            }

            return result;
        }
    }
}