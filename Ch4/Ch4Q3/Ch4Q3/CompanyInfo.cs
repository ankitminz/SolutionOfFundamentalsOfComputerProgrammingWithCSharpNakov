// A given company has name, address, phone number, fax number, web 
// site and manager. The manager has name, surname and phone number.
// Write a program that reads information about the company and its 
// manager and then prints it on the console.

namespace Ch4Q3
{
    public static class CompanyInfo
    {
        public static void Main()
        {
            string companyName, companyAddress, companyWebsite, managerFirstname, managerSurname;
            long companyPhone, companyFax, managerPhone;

            companyName = ReadText("Enter company name: ");
            companyAddress = ReadText("Enter company address: ");
            companyPhone = ReadNum("Enter company phone number: ");
            companyFax = ReadNum("Enter company fax number: ");
            companyWebsite = ReadText("Enter company website: ");
            managerFirstname = ReadText("Enter manager first name: ");
            managerSurname = ReadText("Enter manager surname: ");
            managerPhone = ReadNum("Enter manager phone number: ");
            Console.WriteLine($"\nCompany name: {companyName}\n" +
                $"Company address: {companyAddress}\n" +
                $"Company phone: {companyPhone:#### ### ###}\n" +
                $"Company fax: {companyFax:###-###-####}\n" +
                $"Company website: {companyWebsite}\n" +
                $"Manager firstname: {managerFirstname}\n" +
                $"Manager surname: {managerSurname}\n" +
                $"Manager phone: {managerPhone:#### ### ###}");
        }


        static long ReadNum(string prompt)
        {
            long num;
            bool isLong;

            do
            {
                Console.Write(prompt);
                isLong = Int64.TryParse(Console.ReadLine(), out num);
                if(!isLong || num <= 0)
                {
                    Console.WriteLine("\nEnter a valid positive integer");
                }
            }
            while (!isLong || num <= 0);

            return num;
        }


        static string ReadText(string prompt)
        {
            string? text;

            Console.Write(prompt);
            text = Console.ReadLine();
            if(text != null)
            {
                return text;
            }
            else
            {
                return "unknown";
            }
        }
    }
}