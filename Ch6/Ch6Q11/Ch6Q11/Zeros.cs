// Write a program that calculates with how many zeroes the factorial of 
// a given number ends. Examples:
// N = 10->N! = 3628800-> 2
// N = 20->N! = 2432902008176640000-> 4

namespace Ch6Q11
{
    public static class Zeros
    {
        public static void Main()
        {
            int n;
            bool isInt;

            Console.WriteLine("Program to find number of zeros the factorial of a given " +
                "number ends with");
            do
            {
                Console.Write("N = ");
                isInt = Int32.TryParse(Console.ReadLine(), out n);
                if (!isInt)
                {
                    Console.WriteLine($"\nEnter a valid positive integer 'N' such that" + 
                        $"\n{Int32.MinValue} <= N <= {Int32.MaxValue}");
                }
            }
            while (!isInt);

            Console.WriteLine($"\nNo. of zeros in {n}! = {FindZerosInFactorial(n)}");
        }


        private static uint FindZerosInFactorial(int n)
        {
            // Method to find out no. of zeros in factorial of given number 'n'

            uint noOfZeros = 0;
            uint noOfFives = 0;
            uint noOfEvenNums = 0;
            n = Math.Abs(n);

            while(n > 1)
            {
                if(n % 10 == 0)
                {
                    int temp = n;

                    do
                    {
                        noOfZeros++;
                        temp /= 10;
                    }
                    while(temp % 10 == 0);

                    int firstNonZeroNum = temp % 10;

                    if(firstNonZeroNum % 2 == 0)
                    {
                        noOfEvenNums++;
                    }
                    else if(firstNonZeroNum == 5)
                    {
                        noOfFives++;
                    }
                }
                else if(n % 10 == 5)
                {
                    int temp = n;

                    do
                    {
                        noOfFives++;
                        temp /= 5;
                    }
                    while (temp % 5 == 0);
                }
                else if(n % 2 == 0)
                {
                    noOfEvenNums++;
                }

                n--;
            }

            noOfZeros += (noOfFives <= noOfEvenNums ? noOfFives : noOfEvenNums);

            return noOfZeros;
        }
    }
}