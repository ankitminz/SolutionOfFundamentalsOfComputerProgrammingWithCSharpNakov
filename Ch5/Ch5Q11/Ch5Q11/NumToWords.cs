// *Write a program that converts a number in the range [0…999] to
// words, corresponding to the English pronunciation. Examples:
//  -0-- > "Zero"
//  - 12-- > "Twelve"
//  - 98-- > "Ninety eight"
//  - 273-- > "Two hundred seventy three"
//  - 400-- > "Four hundred"
//  - 501-- > "Five hundred and one"
//  - 711-- > "Seven hundred and eleven"

namespace Ch5Q11
{
    public static class NumToWords
    {
        public static void Main()
        {
            int num;

            Console.WriteLine("Program to convert given integers in range[0..999] to words");
            num = ReadNum("Enter integer: ");
            Console.WriteLine($"\nNum in words: {ConvertNumToWords(num)}");
        }


        static int ReadNum(string prompt)
        {
            int num;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if(!isInt || num < 0 || num > 999)
                {
                    Console.WriteLine("\nEnter a valid positive integer x such that\n" +
                        "0 <= x <= 999");
                }
            }
            while (!isInt || num < 0 || num > 999);

            return num;
        }


        static string ConvertNumToWords(int num)
        {
            string numInWords = "";
            bool isOnlyOnes = true;
            bool isFirstEntry = true;

            if(num < 0 || num > 999)
            {
                return "Error: Integer not in range[0..999]";
            }

            if(num / 100 != 0)
            {
                numInWords = GetHundredthPlace(num / 100, isFirstEntry);
                num %= 100;
                isOnlyOnes = false;
                isFirstEntry = false;
            }

            int tens = num / 10;
            if(tens >= 2 && tens <= 9)
            {
                numInWords += " " + GetTensPlace(tens, isFirstEntry);
                num %= 10;
                isOnlyOnes = false;
                isFirstEntry = false;
            }
            else if(num >= 11 && num <= 19)
            {
                numInWords += " " + GetElevenToTwenty(num, isFirstEntry);
                isFirstEntry = false;
            }

            if(num >= 0 && num <= 9)
            {
                numInWords += " " + GetOnesPlace(num, isOnlyOnes, isFirstEntry);
                isFirstEntry = false;
            }

            return numInWords;
        }


        static string GetHundredthPlace(int num, bool isFirstEntry)
        {
            string word = "";

            switch (num)
            {
                case 1:
                    {
                        word = "one hundred";
                        break;
                    }

                case 2:
                    {
                        word = "two hundred";
                        break;
                    }

                case 3:
                    {
                        word = "three hundred";
                        break;
                    }

                case 4:
                    {
                        word = "four hundred";
                        break;
                    }

                case 5:
                    {
                        word = "five hundred";
                        break;
                    }

                case 6:
                    {
                        word = "six hundred";
                        break;
                    }

                case 7:
                    {
                        word = "seven hundred";
                        break;
                    }

                case 8:
                    {
                        word = "eight hundred";
                        break;
                    }

                case 9:
                    {
                        word = "nine hundred";
                        break;
                    }
            }

            if (isFirstEntry)
            {
                word = TitleCase(word);
            }

            return word;
        }


        static string GetTensPlace(int num, bool isFirstEntry)
        {
            string word = "";

            switch (num)
            {
                case 2:
                    {
                        word = "twenty";
                        break;
                    }

                case 3:
                    {
                        word = "thirty";
                        break;
                    }

                case 4:
                    {
                        word = "fourty";
                        break;
                    }

                case 5:
                    {
                        word = "fifty";
                        break;
                    }

                case 6:
                    {
                        word = "sixty";
                        break;
                    }

                case 7:
                    {
                        word = "seventy";
                        break;
                    }

                case 8:
                    {
                        word = "eighty";
                        break;
                    }

                case 9:
                    {
                        word = "ninety";
                        break;
                    }
            }

            if (isFirstEntry)
            {
                word = TitleCase(word);
            }

            return word;
        }


        static string GetElevenToTwenty(int num, bool isFirstEntry)
        {
            string word = "";

            switch (num)
            {
                case 11:
                    {
                        word = "eleven";
                        break;
                    }

                case 12:
                    {
                        word = "twelve";
                        break;
                    }

                case 13:
                    {
                        word = "thirteen";
                        break;
                    }

                case 14:
                    {
                        word = "fourteen";
                        break;
                    }

                case 15:
                    {
                        word = "fifteen";
                        break;
                    }

                case 16:
                    {
                        word = "sixteen";
                        break;
                    }

                case 17:
                    {
                        word = "seventeen";
                        break;
                    }

                case 18:
                    {
                        word = "eighteen";
                        break;
                    }

                case 19:
                    {
                        word = "nineteen";
                        break;
                    }
            }

            if (isFirstEntry)
            {
                word = TitleCase(word);
            }

            return word;
        }


        static string GetOnesPlace(int num, bool isOnlyOnes, bool isFirstEntry)
        {
            string word = "";

            if(isOnlyOnes && num == 0)
            {
                return "Zero";
            }

            switch (num)
            {
                case 1:
                    {
                        word = "one";
                        break;
                    }

                case 2:
                    {
                        word = "two";
                        break;
                    }

                case 3:
                    {
                        word = "three";
                        break;
                    }

                case 4:
                    {
                        word = "four";
                        break;
                    }

                case 5:
                    {
                        word = "five";
                        break;
                    }

                case 6:
                    {
                        word = "six";
                        break;
                    }

                case 7:
                    {
                        word = "seven";
                        break;
                    }

                case 8:
                    {
                        word = "eight";
                        break;
                    }

                case 9:
                    {
                        word = "nine";
                        break;
                    }
            }

            if (isFirstEntry)
            {
                word = TitleCase(word);
            }

            return word;
        }


        static string TitleCase(string myString)
        {
            if(myString.Length != 0)
            {
                return myString.Substring(0, 1).ToUpper() + myString.Remove(0, 1);
            }
            
            return myString;
        }
    }
}