using System;
using System.Text;

namespace Ch11Q11
{
    class RandomAdvertisingMessage
    {
        static void Main()
        {
            Console.WriteLine("Program to print random advertising messages");
            while (true)
            {
                Console.WriteLine("Press <Enter> to print random message");
                ConsoleKey keyPressed = Console.ReadKey(true).Key;
                if(keyPressed == ConsoleKey.Enter)
                {
                    Console.WriteLine($"\n{GenerateMessage()}");
                }
                else
                {
                    break;
                }
            }
        }


        static string GenerateMessage()
        {
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder();
            string[] phrases = { "The product is excellent.", "This is a great product.", "I use this product constantly.", "This is the best product from this category." };
            string[] stories = { "Now I feel better.", "I managed to change.", "It made some miracle.", "I can’t believe it, but now I am feeling great.", "You should try it, too. I am very satisfied." };
            string[] firstNames = { "Dayan", "Stella", "Hellen", "Kate" };
            string[] lastNames = { "Johnson", "Peterson", "Charls" };
            string[] cities = { "London", "Paris", "Berlin", "New York", "Madrid" };

            sb.Append(GetRandomString(rnd, phrases));
            sb.Append(" ");
            sb.Append(GetRandomString(rnd, stories));
            sb.Append(" -- ");
            sb.Append(GetRandomString(rnd, firstNames));
            sb.Append(" ");
            sb.Append(GetRandomString(rnd, lastNames));
            sb.Append(", ");
            sb.Append(GetRandomString(rnd, cities));

            return sb.ToString();
        }


        static string GetRandomString(Random rnd, string[] stringArray)
        {
            int randomIndex = rnd.Next(stringArray.Length);

            return stringArray[randomIndex];
        }
    }
}
