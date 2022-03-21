// Write a program that prints on the console isosceles triangle which 
// sides consist of the copyright character "©".


namespace Ch2Q11
{
    public class IsoscelesTriangle
    {
        public static void Main()
        {
            char c = '\u00A9';
            string isoscelesTriangle = $@"
          {c}
         {c} {c}
        {c}   {c}
       {c}     {c}
      {c} {c} {c} {c} {c}";

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine(isoscelesTriangle);
        }
    }
}