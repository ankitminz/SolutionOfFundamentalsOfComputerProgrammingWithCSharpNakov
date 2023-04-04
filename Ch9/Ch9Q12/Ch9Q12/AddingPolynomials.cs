// Write a method that calculates the sum of two polynomials with integer 
// coefficients, for example (3x^2 + x - 3) +(x - 1) = (3x^2 + 2x - 4).

namespace Ch9Q12
{
    public static class AddingPolynomials
    {
        private static void Main()
        {
            int degree1, degree2;

            Console.WriteLine("Program to add two given polynomials");
            degree1 = GetInt("Enter degree of first polynomial = ", 0);
            int[] p1 = new int[degree1 + 1];
            InitializePolynomial("Enter coefficients of following powers of 'x'", p1);
            Console.WriteLine();
            degree2 = GetInt("Enter degree of second polynomial = ", 0);
            int[] p2 = new int[degree2 + 1];
            InitializePolynomial("Enter coefficients of following powers of 'x'", p2);
            Console.WriteLine();
            PrintPolynomial(p1);
            Console.Write(" + ");
            PrintPolynomial(p2);
            Console.WriteLine();
            int[] sum = AddPoly(p1, p2);
            PrintPolynomial(sum);
        }


        private static int GetInt(string prompt, int? min = null)
        {
            // Method to take user input as int greater than or equal to min

            int num;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if(!isInt || (min != null && num < min))
                {
                    Console.WriteLine("\nEnter a valid integer 'x' such that");
                    if(min != null)
                    {
                        Console.WriteLine($"{min} <= x <= {Int32.MinValue}");
                    }
                    else
                    {
                        Console.WriteLine($"{Int32.MinValue} <= x <= {Int32.MaxValue}");
                    }
                }
            }
            while (!isInt || (min != null && num < min));

            return num;
        }


        private static void InitializePolynomial(string prompt, int[] array)
        {
            // Method to initialize polynomial

            Console.WriteLine(prompt);
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = GetInt($"x^{i} = ");
            }
        }


        private static void PrintPolynomial(int[] array)
        {
            // Method to print polynomial

            Console.Write("(");
            for(int i = array.Length - 1; i >= 0; i--)
            {
                Console.Write(array[i]);
                if(i > 0)
                {
                    Console.Write("x");
                }

                if(i > 1)
                {
                    Console.Write($"^{i}");
                }

                if(i > 0)
                {
                    Console.Write(" + ");
                }
            }

            Console.Write(")");
        }


        private static int[] AddPoly(int[] p1, int[] p2)
        {
            // Method to add two polynomials

            int lenP1 = p1.Length;
            int lenP2 = p2.Length;
            int len = lenP1 > lenP2 ? lenP1 : lenP2;
            int[] sum = new int[len];

            for(int i = 0; i < len; i++)
            {
                if(i < lenP1 && i < lenP2)
                {
                    sum[i] = p1[i] + p2[i];
                }
                else if(i < lenP1)
                {
                    sum[i] = p1[i];
                }
                else
                {
                    sum[i] = p2[i];
                }
            }

            return sum;
        }
    }
}