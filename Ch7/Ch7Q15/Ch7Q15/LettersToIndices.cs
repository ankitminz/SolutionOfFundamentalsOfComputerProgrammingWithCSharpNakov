// Write a program, which creates an array containing all Latin letters. 
// The user inputs a word from the console and as result the program 
// prints to the console the indices of the letters from the word.

using System.Text;

namespace Ch7Q15
{
    public static class LettersToIndices
    {
        private static void Main()
        {
            string word = "";
            string? temp;

            Console.WriteLine("Program to convert letters of given word to indices");
            
            do
            {
                Console.Write("Enter a word = ");
                temp = Console.ReadLine();
                if(temp == null || temp.Length == 0)
                {
                    Console.WriteLine("\nEnter something!");
                }
                else
                {
                    word = temp;
                }
            }
            while (temp == null || temp.Length == 0);

            string output = ConvertLettersToIndices(word);
            Console.WriteLine($"Output = {output}");
        }


        private static string ConvertLettersToIndices(string input)
        {
            // Method to convert letters of given string to indices

            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder sb = new StringBuilder();

            input = input.ToUpper();
            foreach(char c in input)
            {
                if (!letters.Contains(c))
                {
                    sb.Append('_');
                }
                else
                {
                    sb.Append(letters.IndexOf(c));
                }
            }

            return sb.ToString();
        }
    }
}