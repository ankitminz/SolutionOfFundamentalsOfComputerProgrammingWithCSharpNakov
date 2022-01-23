using System;
using Ch11Q7.CreatingAndUsingObjects;

namespace Ch11Q7.MyNamespace
{
    class MyClass
    {
        static void Main()
        {
            Cat firstCat = new Cat();
            Cat secondCat = new Cat("Tom", "Blue");

            Console.WriteLine($"Color of cat {firstCat.Name} is {firstCat.Color}");
            firstCat.SayMiau();
            Console.WriteLine($"Color of cat {secondCat.Name} is {secondCat.Color}");
            secondCat.SayMiau();
            Console.WriteLine($"Sequence[1 to 3] - {Sequence.NextValue()}, {Sequence.NextValue()} and {Sequence.NextValue()}");
        }
    }
}
