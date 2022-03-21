// Write a program that calculates the sum (with precision of 0.001) of
// the following sequence: 1 + 1 / 2 - 1 / 3 + 1 / 4 - 1 / 5 + …


namespace Ch4Q12
{
    public static class SumOfSequence
    {
        public static void Main()
        {
            Console.WriteLine("Program to find sum of sequence 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...");
            Console.WriteLine($"Sum: {Sum():F3}");
        }


        static double Sum(uint max = UInt32.MaxValue - 1)
        {
            double sum = 1.0;

            for (uint i = 2U; i <= max; i++)
            {
                double oldSum = sum;

                if(i % 2 == 0)
                {
                    sum += Divide(i);
                }
                else
                {
                    sum -= Divide(i);
                }

                if(Math.Abs(sum - oldSum) < 0.001)
                {
                    break;
                }
            }

            return sum;
        }


        static double Divide(uint num)
        {
            try
            {
                return 1.0 / num;
            }
            catch(System.DivideByZeroException e)
            {
                Console.WriteLine($"\nError: {e}");
                return double.NaN;
            }
        }
    }
}