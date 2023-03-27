// Write a program that converts Roman digits to Arabic ones.

namespace Ch8Q11
{
    public static class RomanToArabic
    {
        private static void Main()
        {
            Console.WriteLine("Program to convert roman number to arabic");
            Console.Write("Enter roman number = ");
            string roman = Console.ReadLine();
            Console.WriteLine($"Arabic = {ConvertRomanToArabic(roman):n0}");
        }


        private static long ConvertRomanToArabic(string roman)
        {
            // Method to convert roman number to arabic

            Dictionary<char, int> rMap = new Dictionary<char, int>();
            rMap['I'] = 1;
            rMap['V'] = 5;
            rMap['X'] = 10;
            rMap['L'] = 50;
            rMap['C'] = 100;
            rMap['D'] = 500;
            rMap['M'] = 1000;

            roman = roman.ToUpper();
            long num = 0;
            int previous = 0;

            for(int i = roman.Length - 1; i >= 0; i--)
            {
                int temp = rMap[roman[i]];
                if(temp >= previous)
                {
                    num += temp;
                }
                else
                {
                    num -= temp;
                }

                previous = temp;
            }

            return num;
        }
    }
}