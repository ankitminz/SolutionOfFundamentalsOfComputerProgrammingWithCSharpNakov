namespace Ch2Q8
{
    public class TypeCasting
    {
        public static void Main()
        {
            string greeting = "Hello", name = "World";

            object sentence = greeting + " " + name;
            string? strSentence = sentence.ToString();
            Console.WriteLine(strSentence);

        }
    }
}