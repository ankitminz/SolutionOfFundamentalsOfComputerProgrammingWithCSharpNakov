namespace Ch1Q11
{
    public class Ch1Q11
    {
        public static void Main()
        {
            int age;
            bool isInt;

            Console.WriteLine("Program to print your age after 10 years");
            Console.WriteLine("Enter your age");
            do
            {
                isInt = Int32.TryParse(Console.ReadLine(), out age);
                if(isInt == false || age <= 0 || age > Int32.MaxValue - 10)
                {
                    Console.WriteLine($"\nEnter a valid positive integer greater than 0 and less than or equal to {Int32.MaxValue - 10}");
                }
            }
            while(isInt == false || age <= 0 || age > Int32.MaxValue - 10);

            Console.WriteLine($"\nYour age after 10 years will be {age + 10} years");
        }
    }
}