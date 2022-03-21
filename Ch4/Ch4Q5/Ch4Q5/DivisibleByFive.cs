// Write a program that reads from the console two integer numbers (int)
// and prints how many numbers between them exist, such that the 
// remainder of their division by 5 is 0. Example: in the range(14, 25)
// there are 3 such numbers: 15, 20 and 25.


namespace Ch4Q5
{
    public static class DivisibleByFive
    {
        public static void Main()
        {
            int min, max;

            Console.WriteLine("Program to find integers divisible by five in a given range");
            min = ReadNum("Enter lower range: ");
            max = ReadNum("Enter upper range: ");

            List<int> numsDivisibleByFive = FindNumsDivisibleByFiveInRange(min, max);

            Console.Write($"{numsDivisibleByFive.Count} integers are divisible by five: ");
            for(int i = 0; i < numsDivisibleByFive.Count; i++)
            {
                if(i < numsDivisibleByFive.Count - 1)
                {
                    Console.Write($"{numsDivisibleByFive[i]}, ");
                }
                else
                {
                    Console.Write(numsDivisibleByFive[i]);
                }
            }

        }


        static int ReadNum(string prompt)
        {
            // Method to read and parse minimum and maximum value of range

            int num;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if(!isInt)
                {
                    Console.WriteLine($"\nEnter a valid integer x such that\n" +
                        $"{Int32.MinValue} <= x <= {Int32.MaxValue}");
                }
            }
            while (!isInt);

            return num;
        }


        static List<int> FindNumsDivisibleByFiveInRange(int min, int max)
        {
            // Method to find all integers divisible by five in the given range

            List<int> nums = new List<int>();

            for(int i = min; i <= max; i++)
            {
                if(i % 5 == 0)
                {
                    nums.Add(i);
                }
            }

            return nums;
        }
    }
}