﻿namespace Ch2Q1
{
    public class DeclaringVariables
    {
        public static void Main()
        {
            sbyte num1 = 52, num2 = -115, num3 = 97, num4 = 112, num5 = -44;
            byte num6 = 130, num7 = 224;
            short num8 = -10_000, num9 = 20_000, num10 = 1_990;
            int num11 = 4_825_932, num12 = 970_700_000, num13 = -1_000_000;
            long num14 = 123_456_789_123_456_789L;

            Console.WriteLine($"sbyte -\n{num1}\n{num2}\n{num3}\n{num4}\n{num5}\n");
            Console.WriteLine($"byte -\n{num6}\n{num7}\n");
            Console.WriteLine($"short -\n{num8}\n{num9}\n{num10}\n");
            Console.WriteLine($"int -\n{num11}\n{num12}\n{num13}\n");
            Console.WriteLine($"long -\n{num14}");
        }
    }
}