// Declare two variables of type string and give them values "Hello" and 
// "World". Assign the value obtained by the concatenation of the two 
// variables of type string (do not miss the space in the middle) to a 
// variable of type object. Declare a third variable of type string and 
// initialize it with the value of the variable of type object (you should use 
// type casting).


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