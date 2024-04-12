using System.Net;

namespace UsingSystem.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        static void UsingSystemDotNet_withFileRequest()
        {
            Console.WriteLine(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            string computer_name = Environment.MachineName;

            var fileRequest = WebRequest.Create(@"file://" + computer_name + "/folder/path.txt");
            fileRequest.Method = "POST";
        }
    }
}
