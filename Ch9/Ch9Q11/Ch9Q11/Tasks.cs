// Write a program that solves the following tasks:
// -Put the digits from an integer number into a reversed order.
// - Calculate the average of given sequence of numbers.
// - Solve the linear equation a * x + b = 0.
// Create appropriate methods for each of the above tasks.
// Make the program show a text menu to the user. By choosing an option 
// of that menu, the user will be able to choose which task to be invoked.
// Perform validation of the input data:
// -The integer number must be a positive in the range [1…50,000,000].
// -The sequence of numbers cannot be empty.
// - The coefficient a must be non-zero.

namespace Ch9Q11
{
    public static class Tasks
    {
        private static void Main()
        {
            int choice;

            Console.WriteLine("This program solves the following tasks:" +
                "\n1. Put the digits from an integer number into a reversed order." +
                "\n2. Calculate the average of given sequence of numbers." +
                "\n3. Solve the linear equation a * x + b = 0.");
            choice = GetInt("Choose appropriate task: ", 1, 3);
            switch (choice)
            {
                case 1:
                    {
                        int num;

                        Console.WriteLine();
                        num = GetInt("Enter an integer in range [1 - 50,000,000] = ", 1, 50000000);
                        Console.WriteLine($"\nReversed number = {ReverseNum(num):n0}");
                        break;
                    }
                case 2:
                    {
                        int len;

                        Console.WriteLine();
                        len = GetInt("Enter length of array = ", 1);
                        int[] nums = new int[len];
                        Console.WriteLine("\nInitialize array");
                        for(int i = 0; i < len; i++)
                        {
                            nums[i] = GetInt($"Element[{i}] = ", 1, 50000000);
                        }

                        Console.WriteLine("\nGiven array:");
                        PrintArray(nums);
                        Console.WriteLine($"\nAverage = {GetAverage(nums):n2}");
                        break;
                    }
                case 3:
                    {
                        int a, b;

                        Console.WriteLine();
                        a = GetInt("a = ", exception: 0);
                        b = GetInt("b = ");
                        Console.WriteLine($"\nGiven equation: {a:n0}x + {b:n0} = 0");
                        Console.WriteLine($"Root of given equation = {GetRoot(a, b):n2}");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("\nError!");
                        break;
                    }
            }
        }


        private static int ReverseNum(int num)
        {
            // Method to reverse given number in range [1 - 50,000,000]

            int reverse = 0;
            int pow = 1;

            while (num / (int)Math.Pow(10, pow) != 0)
            {
                pow++;
            }

            for(int i = pow - 1; i >= 0; i--)
            {
                int r = num % 10;
                reverse += (r * (int)Math.Pow(10, i));
                num /= 10;
            }

            return reverse;
        }


        private static int GetInt(string prompt, int? min = null, int? max = null, int? exception = null)
        {
            // Method to take user input as int in range [min, max]

            int num;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if(!isInt || (min != null && num < min) || (max != null && num > max) || (exception != null && num == exception))
                {
                    Console.WriteLine($"\nEnter a valid integer 'x' such that");
                    if(min != null && max != null)
                    {
                        Console.WriteLine($"{min} <= x <= {max}");
                    }
                    else if(min != null)
                    {
                        Console.WriteLine($"{min} <= x <= {Int32.MaxValue}");
                    }
                    else if(max != null)
                    {
                        Console.WriteLine($"{Int32.MinValue} <= x <= {max}");
                    }
                    else
                    {
                        Console.WriteLine($"{Int32.MinValue} <= x <= {Int32.MaxValue}");
                    }

                    if(exception != null && num == exception)
                    {
                        Console.WriteLine($"x != {exception}");
                    }
                }
            }
            while (!isInt || (min != null && num < min) || (max != null && num > max) || (exception != null && num == exception));

            return num;
        }


        private static double GetAverage(params int[] array)
        {
            // Method to return average of given integers

            double sum = 0d;

            for(int i = 0; i < array.Length; i++)
            {
                checked
                {
                    sum += array[i];
                }
            }

            return sum / array.Length;
        }


        private static void PrintArray(int[] array)
        {
            // Method to print given int array

            if(array.Length == 1)
            {
                Console.WriteLine($"{{{array[0]}}}");
                return;
            }

            for(int i = 0; i < array.Length; i++)
            {
                if(i == 0)
                {
                    Console.Write($"{{{array[i]}, ");
                }
                else if(i > 0 && i < array.Length - 1)
                {
                    Console.Write($"{array[i]}, ");
                }
                else
                {
                    Console.WriteLine($"{array[i]}}}");
                }
            }
        }


        private static double GetRoot(int a, int b)
        {
            // Method to return root of linear equation (a * x + b = 0)
            // And a is non-zero integer

            return -((double)b / a);
        }
    }
}