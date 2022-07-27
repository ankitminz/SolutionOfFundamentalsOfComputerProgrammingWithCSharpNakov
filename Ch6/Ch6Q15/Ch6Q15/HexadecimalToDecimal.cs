// Write a program that converts a given number from hexadecimal to 
// decimal notation.

namespace Ch6Q15
{
    public static class HexadecimalToDecimal
    {
        public static void Main()
        {
            string ?hex = "";

            Console.WriteLine("Program to convert hexadecimal represetation to decimal " +
                "representation");
            Console.Write("Hexadecimal number = ");
            hex = Console.ReadLine();
            Console.WriteLine($"Decimal representation: {ConvertHexToDecimal(hex):n0}");
        }


        private static long ConvertHexToDecimal(string ?hex)
        {
            long num = 0;
            if(hex == null)
            {
                return num;
            }

            Dictionary<char, int> hexMap = new Dictionary<char, int>();
            InitHexMap(hexMap);
            Dictionary<int, char> reverseHexMap = Reverse(hexMap);

            hex = hex.Replace(" ", "");
            hex = hex.ToUpper();
            char[] hexArray = hex.ToCharArray();

            int len = hexArray.Length;
            bool isNegative = (len == 16 && hexMap[hexArray[0]] > 7);

            // START - Logic to deal with negative hexadecimal numbers
            if (isNegative)
            {
                // START - Logic to subtract 1 from hexadecimal number
                for(int i = len - 1; i >= 0; i--)
                {
                    int index = hexMap[hexArray[i]];

                    if(index > 0)
                    {
                        hexArray[i] = reverseHexMap[hexMap[hexArray[i]] - 1];
                        break;
                    }
                    else
                    {
                        hexArray[i] = reverseHexMap[reverseHexMap.Count - 1];
                    }
                }
                // END

                // START - Logic to inverse hexadecimal number
                for(int i = 0; i < len; i++)
                {
                    hexArray[i] = reverseHexMap[15 - hexMap[hexArray[i]]];
                }
                // END

                // START - Logic to convert negative hexadecimal to decimal
                for (int i = len - 1, pow = 0; i >= 0; i--, pow++)
                {
                    num -= hexMap[hexArray[i]] * (long)Math.Pow(16, pow);
                }
                // END
            }
            else
            {
                // START - Logic to convert positive hexadecimal to decimal
                for (int i = len - 1, pow = 0; i >= 0; i--, pow++)
                {
                    num += hexMap[hexArray[i]] * (long)Math.Pow(16, pow);
                }
                // END
            }

            return num;
        }


        private static void InitHexMap(Dictionary<char, int> hexMap)
        {
            // Method to initialize mapping of decimal and hexadecimal dictionary

            hexMap.Clear();
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
        }


        private static Dictionary<int, char> Reverse(Dictionary<char, int> myDictionary)
        {
            // Method to reverse key value pairs of a dictionary

            Dictionary<int, char> result = new Dictionary<int, char>();

            foreach(KeyValuePair<char, int> pair in myDictionary)
            {
                result.Add(pair.Value, pair.Key);
            }

            return result;
        }
    }
}