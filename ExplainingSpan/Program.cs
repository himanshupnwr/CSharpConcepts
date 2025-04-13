// See https://aka.ms/new-console-template for more information

using System.Data;

partial class Program
{
    private static readonly string _dateAsTest = "08 07 2021";
    private static void Main(string[] args)
    {
        var date = DateWithStringAndSubString();
        Console.WriteLine(date);
    }

    //without span
    public static (int day, int month, int year) DateWithStringAndSubString()
    {
        var dayAsText = _dateAsTest.Substring(0, 2);
        var monthAsText = _dateAsTest.Substring(3, 2);
        var yearAsText = _dateAsTest.Substring(6);

        var day = int.Parse(dayAsText);
        var month = int.Parse(monthAsText);
        var year = int.Parse(yearAsText);

        return (day, month, year);
    }

    //withspan
    //spans are ref struct and are allocated on stack instead of heap
    public static (int day, int month, int year) DateWithStringAndSubStringWithSpan()
    {
        ReadOnlySpan<char> dateAsSpan = _dateAsTest;
        var dayAsText = dateAsSpan.Slice(0, 2);
        var monthAsText = dateAsSpan.Slice(3, 2);
        var yearAsText = dateAsSpan.Slice(6);

        var day = int.Parse(dayAsText);
        var month = int.Parse(monthAsText);
        var year = int.Parse(yearAsText);

        return (day, month, year);
    }
}