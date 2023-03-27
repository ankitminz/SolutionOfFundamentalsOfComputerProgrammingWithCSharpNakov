// Write a program that by given N, S, D (2 ≤ S, D ≤ 16) converts the number 
// N from an S-based numeral system to a D based numeral system.

//              MaxValue
// Base 10      9,223,372,036,854,775,807
// Base 2       111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111
// Base 3       2021 1100 1102 2210 0121 0201 0021 2201 0122 0221
// Base 4       1333 3333 3333 3333 3333 3333 3333 3333
// Base 5       1104 3324 0130 4422 4343 1031 1212
// Base 6       1 5402 4100 3031 0302 2212 2211
// Base 7       223 4101 0611 2450 5205 2300
// Base 8       777 777 777 777 777 777 777
// Base 9       6740 4283 1721 0781 1827
// Base 11      172 8002 6352 1459 0697
// Base 12      41 A792 6785 1512 0367
// Base 13      10 B269 5490 7543 3C37
// Base 14      4 3407 24C6 C71D C7A7
// Base 15      1 60E2 AD32 4636 6807
// Base 16      7FFF FFFF FFFF FFFF

//              Greatest -ve number
// Base 10      -1
// Base 2       1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111
// Base 3       2 2222 2222 2222 2222 2222 2222 2222 2222 2222 2222
// Base 4       3333 3333 3333 3333 3333 3333 3333 3333
// Base 5       4444 4444 4444 4444 4444 4444 4444
// Base 6       5 5555 5555 5555 5555 5555 5555
// Base 7       666 6666 6666 6666 6666 6666
// Base 8       7 777 777 777 777 777 777 777
// Base 9       8 8888 8888 8888 8888 8888
// Base 11      AAA AAAA AAAA AAAA AAAA
// Base 12      BB BBBB BBBB BBBB BBBB
// Base 13      CC CCCC CCCC CCCC CCCC
// Base 14      D DDDD DDDD DDDD DDDD
// Base 15      E EEEE EEEE EEEE EEEE
// Base 16      FFFF FFFF FFFF FFFF

//              MinValue
// Base 10      -9,223,372,036,854,775,808
// Base 2       1000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000
// Base 3       2 0201 1122 1120 0012 2101 2021 2201 0021 2100 2001
// Base 4       2000 0000 0000 0000 0000 0000 0000 0000
// Base 5       3340 1120 4314 0022 0101 3413 3232
// Base 6       4 0153 1455 2524 5253 3343 3344
// Base 7       443 2565 6055 4216 1461 4366
// Base 8       7 000 000 000 000 000 000 000
// Base 9       8 2148 4605 7167 8107 7061
// Base 11      938 2AA8 4758 9651 A413
// Base 12      7A 1429 5436 A6A9 B854
// Base 13      BC 1A63 783C 5789 9095
// Base 14      9 A9D6 B917 16C0 1636
// Base 15      D 8E0C 41BC A8B8 86E7
// Base 16      8000 0000 0000 0000

using System.Text;

namespace Ch8Q13
{
    public static class BaseConverter
    {
        private static void Main()
        {
            int s, d;
            string n;

            Console.WriteLine("Program to convert the number N from S-based numeral " +
                "system to D-based numeral system, where 2 <= S, D <= 16");
            s = GetBase("Enter S = ");
            n = GetNum($"Enter number of base-{s} = ", s);
            d = GetBase("Enter D = ", s);
            Console.WriteLine($"Base-{d} = {ConvertBase(n, s, d)}");
            
        }


        private static int GetBase(string prompt, int? x = null)
        {
            // Method to take user input base of numeral system

            int lowerLimit = 2, upperLimit = 16;
            int b;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out b);
                if (!isInt || b < lowerLimit || b > upperLimit || b == x)
                {
                    Console.WriteLine("\nEnter a valid integer 'x' such that");
                    Console.Write($"{lowerLimit} <= x <= {upperLimit} ");
                    if(x != null)
                    {
                        Console.WriteLine($"And x != {x}");
                    }
                }
            }
            while (!isInt || b < lowerLimit || b > upperLimit || b == x);

            return b;
        }


        private static string GetNum(string prompt, int b)
        {
            // Method to user input number of certain base

            string n;

            do
            {
                Console.Write(prompt);
                n = Console.ReadLine();
                if (String.IsNullOrEmpty(n))
                {
                    Console.WriteLine($"\nEnter number of base {b}");
                }
            }
            while (String.IsNullOrEmpty(n));

            return n;
        }


        private static long ToDecimal(string numB, int b)
        {
            // Method to convert number from base b to decimal (base 10)

            numB = numB.Trim(); // Remove all string formatting
            numB = numB.TrimStart('0');
            numB = numB.ToUpper();
            char[] temp = numB.ToCharArray();
            numB = "";
            for(int i = 0; i < temp.Length; i++)
            {
                if (temp[i] != ' ' && temp[i] != ',')
                {
                    numB += temp[i];
                }
            }

            Dictionary<char, int> map = new Dictionary<char, int>();
            map['0'] = 0;
            map['1'] = 1;
            map['2'] = 2;
            map['3'] = 3;
            map['4'] = 4;
            map['5'] = 5;
            map['6'] = 6;
            map['7'] = 7;
            map['8'] = 8;
            map['9'] = 9;
            map['A'] = 10;
            map['B'] = 11;
            map['C'] = 12;
            map['D'] = 13;
            map['E'] = 14;
            map['F'] = 15;

            Dictionary<int, char> inverseMap = new Dictionary<int, char>();
            foreach(KeyValuePair<char, int> kvp in map)
            {
                inverseMap[kvp.Value] = kvp.Key;
            }

            bool isNegative = (b == 2 && numB.Length == 64 && numB[0] == '0') || (b == 3 && numB.Length == 41) || (b == 4 && numB.Length == 32 && map[numB[0]] >= 2) || (b == 5 && numB.Length == 28 && map[numB[0]] >= 3) || (b == 6 && numB.Length == 25 && map[numB[0]] >= 4) || (b == 7 && numB.Length == 23 && map[numB[0]] >= 4) || (b == 8 && numB.Length == 22) || (b == 9 && numB.Length == 21) || (b == 11 && numB.Length == 19 && map[numB[0]] >= 9) || (b == 12 && numB.Length == 18 && map[numB[0]] >= 7) || (b == 13 && numB.Length == 18 && map[numB[0]] >= 11) || (b == 14 && numB.Length == 17 && map[numB[0]] >= 9) || (b == 15 && numB.Length == 17 && map[numB[0]] >= 13) || (b == 16 && numB.Length == 16 && map[numB[0]] >= 8);

            if (isNegative)
            {
                char[] array = numB.ToCharArray();

                for(int i = array.Length - 1; i >= 0; i--) // Logic to subtract 1
                {
                    if(array[i] != '0')
                    {
                        array[i] = inverseMap[map[array[i]] - 1];
                        break;
                    }
                    else
                    {
                        array[i] = inverseMap[b - 1];
                    }
                }

                for(int i = 0; i < array.Length; i++) // Logic to inverse bits
                {
                    array[i] = inverseMap[b - 1 - map[array[i]]];
                }

                numB = "";
                for(int i = 0; i < array.Length; i++)
                {
                    numB += array[i];
                }
            }

            long num = map[numB[0]] * b;

            for(int i = 1; i < numB.Length; i++) // Logic to convert number in base b to decimal using horner scheme
            {
                if(i < numB.Length - 1)
                {
                    num = (num + map[numB[i]]) * b;
                }
                else
                {
                    num += map[numB[i]];
                }
                
            }

            if (isNegative)
            {
                num *= -1;
            }

            return num;
        }


        private static string ToBase(long num, int b)
        {
            // Method to convert number from decimal (base 10) to certain base b
            // Can't convert minimum Int64 value

            bool isNegative = num < 0;
            num = Math.Abs(num);
            StringBuilder sb = new StringBuilder();
            Dictionary<int, char> map = new Dictionary<int, char>();
            map[0] = '0';
            map[1] = '1';
            map[2] = '2';
            map[3] = '3';
            map[4] = '4';
            map[5] = '5';
            map[6] = '6';
            map[7] = '7';
            map[8] = '8';
            map[9] = '9';
            map[10] = 'A';
            map[11] = 'B';
            map[12] = 'C';
            map[13] = 'D';
            map[14] = 'E';
            map[15] = 'F';

            Dictionary<char, int> inverseMap = new Dictionary<char, int>();
            foreach(KeyValuePair<int, char> kvp in map)
            {
                inverseMap[kvp.Value] = kvp.Key;
            }

            do // Logic to convert number in base 10 to base b
            {
                int r = (int)(num % b);
                sb.Insert(0, map[r]);
                num /= b;
            }
            while (num > 0);

            if (isNegative)
            {
                int maxLength;

                switch (b)
                {
                    case 2:
                        {
                            maxLength = 64;
                            break;
                        }
                    case 3:
                        {
                            maxLength = 41;
                            break;
                        }
                    case 4:
                        {
                            maxLength = 32;
                            break;
                        }
                    case 5:
                        {
                            maxLength = 28;
                            break;
                        }
                    case 6:
                        {
                            maxLength = 25;
                            break;
                        }
                    case 7:
                        {
                            maxLength = 23;
                            break;
                        }
                    case 8:
                        {
                            maxLength = 22;
                            break;
                        }
                    case 9:
                        {
                            maxLength = 21;
                            break;
                        }
                    case 11:
                        {
                            maxLength = 19;
                            break;
                        }
                    case 12:
                    case 13:
                        {
                            maxLength = 18;
                            break;
                        }
                    case 14:
                    case 15:
                        {
                            maxLength = 17;
                            break;
                        }
                    case 16:
                        {
                            maxLength = 16;
                            break;
                        }
                    default:
                        {
                            maxLength = 64;
                            break;
                        }
                }

                while(sb.Length < maxLength) // Making number 64-bit according to base b
                {
                    sb.Insert(0, 0);
                }

                for(int i = 0; i < sb.Length; i++) // Logic to inverse bits
                {
                    sb.Replace(sb[i], map[b - 1 - inverseMap[sb[i]]], i, 1);
                }

                for(int i = sb.Length - 1; i >= 0; i--) // Logic to add 1
                {
                    int n = inverseMap[sb[i]] + 1;

                    if(n < b)
                    {
                        sb.Replace(sb[i], map[n], i, 1);
                        break;
                    }
                    else
                    {
                        sb.Replace(sb[i], '0', i, 1);
                    }
                }
            }

            int count = 1;
            int chunckLength = (b == 8 ? 3 : 4);
            for(int i = sb.Length - 1; i >= 0; i--, count++) // Formatting
            {
                if(count % chunckLength == 0)
                {
                    sb.Insert(i, ' ');
                }
            }

            string numB = sb.ToString();
            return numB.Trim();
        }


        private static string ConvertBase(string num, int s, int d)
        {
            // Method to convert given number from base s to base d

            if(s == 10)
            {
                return ToBase(Int64.Parse(num), d);
            }
            else if(d == 10)
            {
                string result = $"{ToDecimal(num, s):n0}";
                return result;
            }
            else
            {
                return ToBase(ToDecimal(num, s), d);
            }
        }
    }
}