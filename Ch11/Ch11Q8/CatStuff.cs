using System;
using Ch11Q7.CreatingAndUsingObjects;

namespace Ch11Q8
{
    class CatStuff
    {
        static void Main()
        {
            int len = 10;
            Cat[] cats = new Cat[len];

            for(int i = 0; i < len; i++)
            {
                cats[i] = new Cat("Cat" + Sequence.NextValue(), "blue");
            }

            for(int i = 0; i < len; i++)
            {
                cats[i].SayMiau();
            }
        }
    }
}
