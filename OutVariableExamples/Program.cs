// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

static void Method(out int i)
{
    i = 44;
}

static void Main(string[] args)
{
    //old way of declaring out variables
    int value;
    Method(out value);
    //value is now 44
    System.Console.WriteLine(value);

    //new out statement
    Method(out int valueTwo);
    //not using explicit variable type
    System.Console.WriteLine(valueTwo);


    string str = "1234";
    if(!int.TryParse(str, out int result))
    {
        Console.WriteLine("TryParse Failed");
    }
}