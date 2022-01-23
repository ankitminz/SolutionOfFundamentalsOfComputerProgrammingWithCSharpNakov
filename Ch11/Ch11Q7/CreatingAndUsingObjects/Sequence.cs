using System;

namespace Ch11Q7.CreatingAndUsingObjects
{
    public class Sequence
    {
        private static int currentValue = 0;

        private Sequence()
        {

        }

        public static int NextValue()
        {
            currentValue += 1;
            return currentValue;
        }
    }
}
