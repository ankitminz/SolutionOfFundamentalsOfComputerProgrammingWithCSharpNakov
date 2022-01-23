using System;

namespace Ch11Ex1
{
    class Program
    {
        static void Main()
        {
            Cat firstCat = new Cat();
            Cat secondCat = new Cat("Tom", "blue");

            Console.WriteLine($"Cat {firstCat.Name} is {firstCat.Color}");
            firstCat.SayMiau();
            Console.WriteLine($"Cat {secondCat.Name} is {secondCat.Color}");
            secondCat.SayMiau();
        }
    }
}
