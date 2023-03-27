// Write a program that prints the value of the mantissa, the sign of the 
// mantissa and exponent in float numbers (32-bit numbers with a 
// floating-point according to the IEEE 754 standard). Example: for the
// number - 27.25 should be printed: sign = 1, exponent = 10000011,
// mantissa = 10110100000000000000000.

using System.Text;

namespace Ch8Q15
{
    public static class FloatRepresentation
    {
        private static void Main()
        {
            float num;

            Console.WriteLine("Program to represent float");
            num = GetFloat("Enter floating-point number = ");
            RepresentFloat(num);
        }


        private static float GetFloat(string prompt)
        {
            // Method to take user input as float

            float num;
            bool isFloat;

            do
            {
                Console.Write(prompt);
                isFloat = float.TryParse(Console.ReadLine(), out num);
                if (!isFloat)
                {
                    Console.WriteLine("\nEnter a valid floating-point value 'x' such that" +
                        $"\n{float.MinValue} <= x <= {float.MaxValue}");
                }
            }
            while (!isFloat);

            return num;
        }


        private static void RepresentFloat(float num)
        {
            // Method to represent float as sign, exponent and mantissa as per IEEE 754 standard

            byte[] bytes = System.BitConverter.GetBytes(num);
            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < bytes.Length; i++)
            {
                int n = bytes[i];

                for(int count = 1; count <= 8; count++)
                {
                    if(n > 0)
                    {
                        int r = n % 2;
                        sb.Insert(0, r);
                        n /= 2;
                    }
                    else
                    {
                        sb.Insert(0, 0);
                    }
                }
            }

            string sign = sb[0].ToString();
            string exponent = "";
            string mantissa = "";

            for(int i = 1; i <= 8; i++)
            {
                exponent += sb[i];
            }

            for(int i = 9; i <= 31; i++)
            {
                mantissa += sb[i];
            }

            Console.WriteLine($"Sign = {sign}" +
                $"\nExponent = {exponent}" +
                $"\nMantissa = {mantissa}");
        }
    }
}