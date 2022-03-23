// Write a program that applies bonus points to given scores in the range 
// [1…9] by the following rules:
//  -If the score is between 1 and 3, the program multiplies it by 10.
//  - If the score is between 4 and 6, the program multiplies it by 100.
//  - If the score is between 7 and 9, the program multiplies it by 1000.
//  - If the score is 0 or more than 9, the program prints an error 
//  message.

namespace Ch5Q10
{
    public static class BonusPoints
    {
        public static void Main()
        {
            int currentScore, newScore = 0;
            bool isInt;

            Console.WriteLine("Program to give bonus points according to you current score");
            do
            {
                Console.Write("Current score: ");
                isInt = Int32.TryParse(Console.ReadLine(), out currentScore);
                if(!isInt || currentScore < 0)
                {
                    Console.WriteLine($"\nEnter a valid positive integer x such that\n" +
                        $"0 <= x <= {Int32.MaxValue}");
                }
            }
            while (!isInt || currentScore < 0);

            if(currentScore >= 1 && currentScore <= 3)
            {
                newScore = currentScore * 10;
            }
            else if(currentScore >= 4 && currentScore <= 6)
            {
                newScore = currentScore * 100;
            }
            else if(currentScore >= 7 && currentScore <= 9)
            {
                newScore = currentScore * 1000;
            }
            else
            {
                Console.WriteLine("\nError: Current score is not in range [1..9]");
                return;
            }

            if(newScore != 0)
            {
                Console.WriteLine($"\nNew score: {newScore}");
            }
        }
    }
}