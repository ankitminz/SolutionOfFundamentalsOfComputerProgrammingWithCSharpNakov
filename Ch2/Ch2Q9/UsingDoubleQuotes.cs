namespace Ch2Q9
{
    public class UsingDoubleQuotes
    {
        public static void Main()
        {
            string sentence1 = @"The ""use"" of quotations cause difficulties";
            string sentence2 = "The \"use\" of quotations cause difficulties";

            Console.WriteLine($"{sentence1}\n{sentence2}");
        }
    }
}