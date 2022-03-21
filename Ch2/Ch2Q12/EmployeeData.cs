// A company dealing with marketing wants to keep a data record of its 
// employees. Each record should have the following characteristic – first 
// name, last name, age, gender (‘m’ or ‘f’) and unique employee number 
// (27560000 to 27569999). Declare appropriate variables needed to 
// maintain the information for an employee by using the appropriate data
// types and attribute names.

namespace Ch2Q12
{
    public class EmployeeData
    {
        public static void Main()
        {
            string? firstName = null, lastName = null;
            byte? age = null;
            char gender = 'm';
            uint? uie = null;

            Console.WriteLine($"UIN - {uie}, Name - {firstName} {lastName}, Age - {age}, Gender - {gender}");
        }
    }
}