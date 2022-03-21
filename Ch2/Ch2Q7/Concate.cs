// Declare two variables of type string with values "Hello" and "World". 
// Declare a variable of type object. Assign the value obtained of 
// concatenation of the two string variables (add space if necessary) to this
// variable.Print the variable of type object.


namespace Ch2Q7
{
    public class Concate
    {
        public static void Main()
        {
            string greeting = "Hello", name = "World";
            object sentence = greeting + " " + name;

            Console.WriteLine(sentence);
        }
    }
}