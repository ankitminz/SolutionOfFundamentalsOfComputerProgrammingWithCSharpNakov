// Write a program that converts Arabic digits to Roman ones.

using System.Text;

namespace Ch8Q12
{
    public static class ArabicToRoman
    {
        private static void Main()
        {
            int num;

            Console.WriteLine("Program to convert arabic number to roman");
            num = GetNum("Enter arabic number = ");
            Console.WriteLine($"Roman = {ConvertArabicToRoman(num)}");
        }


        private static string ConvertArabicToRoman(int num)
        {
            // Method to convert positive arabic number to roman

            num = Math.Abs(num);
            Dictionary<int, string> ones = new Dictionary<int, string>();
            ones[1] = "I";
            ones[2] = "II";
            ones[3] = "III";
            ones[4] = "IV";
            ones[5] = "V";
            ones[6] = "VI";
            ones[7] = "VII";
            ones[8] = "VIII";
            ones[9] = "IX";

            Dictionary<int, string> tens = new Dictionary<int, string>();
            tens[1] = "X";
            tens[2] = "XX";
            tens[3] = "XXX";
            tens[4] = "XL";
            tens[5] = "L";
            tens[6] = "LX";
            tens[7] = "LXX";
            tens[8] = "LXXX";
            tens[9] = "XC";

            Dictionary<int, string> hundreds = new Dictionary<int, string>();
            hundreds[1] = "C";
            hundreds[2] = "CC";
            hundreds[3] = "CCC";
            hundreds[4] = "CD";
            hundreds[5] = "D";
            hundreds[6] = "DC";
            hundreds[7] = "DCC";
            hundreds[8] = "DCCC";
            hundreds[9] = "CM";

            Dictionary<int, string> thousands = new Dictionary<int, string>();
            thousands[1] = "M";
            thousands[2] = "MM";
            thousands[3] = "MMM";

            StringBuilder sb = new StringBuilder();

            if (num >= 1000)
            {
                sb.Append(thousands[num / 1000]);
                num %= 1000;
            }

            if (num >= 100)
            {
                sb.Append(hundreds[num / 100]);
                num %= 100;
            }

            if(num >= 10)
            {
                sb.Append(tens[num / 10]);
                num %= 10;
            }

            if(num >= 1)
            {
                sb.Append(ones[num]);
            }

            return sb.ToString();
        }


        private static int GetNum(string prompt)
        {
            // Method to take user input

            int num;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if(!isInt || num <= 0 || num >= 4000)
                {
                    Console.WriteLine("\nEnter a valid positive integer 'x' such that" +
                        "\n0 < x <= 4000");
                }
            }
            while (!isInt || num <= 0 || num >= 4000);

            return num;
        }
    }
}