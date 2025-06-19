namespace StringInterpolation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string Greeting = "Hello";
            const string Name = "Stephen";
            string result = $"{Greeting}, {Name}!";
        }

        public static string Greet(string greeting, string name) => $"{greeting}, {name}!";
        public static string GreetConcat(string greeting, string name) => string.Concat(greeting, ", ", name);

        //Both these produces same results as c# compiler automatically uses string.Format in the first example
        public static string DescribeAsHex(int value) => $"{value} in hex is 0x{value:X}";
        public static string DescribeAsHexFormat(int value) => string.Format("{0} in hex is 0x{1:X}", value, value);



    }
}
