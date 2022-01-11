namespace Ch1Q10
{
    public class Sequence
    {
        public static void Main()
        {
            int firstElement = 2;
            int members = 100;

            for(int i = firstElement, count = 1; count <= members; i++, count++ )
            {
                if(count % 2 != 0)
                {
                    Console.WriteLine($"{i}");
                }
                else
                {
                    Console.WriteLine($"{i * -1}");
                }
            }
        }
    }
}