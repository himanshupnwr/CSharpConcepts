// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Employee objEmp = new Employee { EmpId = 1000, EmpName = "James", Addresses = new List<Address>() };

objEmp.Addresses.Add(new Address { AddressLine = "Address Line" });

//using the indexer
Console.WriteLine(objEmp[0].AddressLine);

class Employee
{
    public int EmpId { get; set; }
    public string EmpName { get; set; }
    public List<Address> Addresses { get; set; }

    //creating an indexer
    public Address this[int index]
    {
        get { return Addresses[index]; }
    }
}

public class Address
{
    public string AddressLine { get; set; }
    public string City { get; set; }
    public string State { get; set; }
}

class ProgramIndex
{
    static void Main(string[] args)
    {
        int[] intArr = new int[5] { 5, 2, 3, 8, 7 };
        MyClass MC = new MyClass(intArr);
        //Get element at the third index.
        Console.WriteLine(MC[3]);
        //Set the value using an indexer.
        MC[3] = 20;
        //Lets check the value again.
        Console.WriteLine(MC[3]);
        Console.ReadLine();
    }
}
class MyClass
{
    public int[] IntArray { get; set; }
    public MyClass(int[] intArray)
    {
        IntArray = intArray;
    }
    //Indexer is defined with the "this" keyword.
    public int this[int index]
    {
        get
        {
            return this.IntArray[index];
        }
        set
        {
            this.IntArray[index] = value;
        }
    }
}