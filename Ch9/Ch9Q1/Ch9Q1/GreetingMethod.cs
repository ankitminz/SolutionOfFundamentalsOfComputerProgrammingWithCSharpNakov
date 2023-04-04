// Write a code that by given name prints on the console "Hello, <name>!"
// (for example: "Hello, Peter!"). 

namespace Ch9Q1
{
    public static class GreetingMethod
    {
        private static void Main()
        {
            Console.WriteLine("Program to greet people");
            Console.Write("Enter a name: ");
            string name = Console.ReadLine();
            Greet(name);
        }


        private static void Greet(string name)
        {
            // Method to greet people

            Console.WriteLine($"Hello, {name}!");
        }
    }
}