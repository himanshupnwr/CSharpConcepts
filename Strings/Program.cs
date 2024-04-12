namespace Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public void ManipulatingStrings()
        {
            string firstName = "Bethany";
            string lastName = "Smith";

            string fullName = firstName + lastName;
            string employeeIdentification = string.Concat(firstName, lastName);

            string empId = firstName.Trim().ToLower() + "-" + lastName.Trim().ToLower();

            if(fullName.Contains("beth") || fullName.Contains("Beth"))
            {
                Console.Write(fullName);
            }

            string subString = fullName.Substring(1, 3);

            string userNameWithInterpolation = $"{firstName}-{lastName}";

            string escapedFilePath = "C:\\Documents\\readme.txt";
            string verbatimFilePath = @"C:\Documents\readme.txt";

            string displayName = $"Welcome!\n{firstName}\t{lastName}";
            Console.WriteLine(displayName);

            string filePath = "C:\\data\\employeelist.xlsx";

            string marketingTagLine = "Baking the \"best pies\" ever";
        }
    }
}
