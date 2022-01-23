using System;
using System.Text;

namespace Ch11Ex2
{
    class RandomPasswordGenerater
    {
        private static Random rnd = new Random();
        private const string CapitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string SmallLetters = "abcdefghijklmnopqrstuvwxyz";
        private const string Nums = "0123456789";
        private const string SpecialChars = ",./;'[]\\`-=<>?:\"{}|~!@#$%^&*()_+ ";
        private const string AllChars = CapitalLetters + SmallLetters + Nums + SpecialChars;



        static void Main()
        {
            StringBuilder password = new StringBuilder();
            char tempChar;

            for(int i = 1; i <= 2; i++) // Insert 2 capital letters at random position
            {
                tempChar = GetRandomChar(rnd, CapitalLetters);
                InsertAtRandomIndex(password, rnd, tempChar);
            }

            for(int i = 1; i <= 2; i++) // Insert 2 small letters at random position
            {
                tempChar = GetRandomChar(rnd, SmallLetters);
                InsertAtRandomIndex(password, rnd, tempChar);
            }

            for(int i = 1; i <= 2; i++) // Insert 2 random nums at random position
            {
                tempChar = GetRandomChar(rnd, Nums);
                InsertAtRandomIndex(password, rnd, tempChar);
            }

            for(int i = 1; i <= 3; i++) // Insert 3 random special characters at random position
            {
                tempChar = GetRandomChar(rnd, SpecialChars);
                InsertAtRandomIndex(password, rnd, tempChar);
            }

            int randomCount = rnd.Next(6);

            for(int i = 1; i <= randomCount; i++) // Insert random characters at random position
            {
                tempChar = GetRandomChar(rnd, AllChars);
                InsertAtRandomIndex(password, rnd, tempChar);
            }

            Console.WriteLine($"Generated password = {password.ToString()}\nLength = {password.Length}");
        }


        static char GetRandomChar(Random rnd, string Chars)
        {
            int randomIndex = rnd.Next(Chars.Length);

            return Chars[randomIndex];
        }


        static void InsertAtRandomIndex(StringBuilder password, Random rnd , char randomChar)
        {
            password.Insert(rnd.Next(password.Length + 1), randomChar);
        }
    }
}
