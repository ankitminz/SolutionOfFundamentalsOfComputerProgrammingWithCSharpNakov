// Write a program that asks for a digit (0-9), and depending on the input,
// shows the digit as a word (in English). Use a switch statement.

namespace Ch5Q5
{
    public static class DigitInWord
    {
        public static void Main()
        {
            byte num;
            bool isByte;

            Console.WriteLine("Program to print given digit(0 to 9) in word");
            do
            {
                Console.Write("Enter digit(0 or 9): ");
                isByte = Byte.TryParse(Console.ReadLine(), out num);
                if (!isByte || num < 0 || num > 9)
                {
                    Console.WriteLine("\nEnter a valid digit x such that\n" +
                        $"0 <= x <= 9");
                }
            }
            while (!isByte || num < 0 || num > 9);

            switch (num)
            {
                case 0:
                    {
                        Console.WriteLine("Zero");
                        break;
                    }

                case 1:
                    {
                        Console.WriteLine("One");
                        break;
                    }

                case 2:
                    {
                        Console.WriteLine("Two");
                        break;
                    }

                case 3:
                    {
                        Console.WriteLine("Three");
                        break;
                    }

                case 4:
                    {
                        Console.WriteLine("Four");
                        break;
                    }

                case 5:
                    {
                        Console.WriteLine("Five");
                        break;
                    }

                case 6:
                    {
                        Console.WriteLine("Six");
                        break;
                    }

                case 7:
                    {
                        Console.WriteLine("Seven");
                        break;
                    }

                case 8:
                    {
                        Console.WriteLine("Eight");
                        break;
                    }

                case 9:
                    {
                        Console.WriteLine("Nine");
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Oops! some error occured");
                        break;
                    }
            }
        }
    }
}