// Declare two variables of type string and assign them a value “The 
// "use" of quotations causes difficulties.” (without the outer quotes). 
// In one of the variables use quoted string and in the other do not use it.

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