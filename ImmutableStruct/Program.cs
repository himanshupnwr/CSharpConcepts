namespace ImmutableStruct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Coordinate c = new Coordinate { X = 12, Y = 42 };
            //c.X = 13; //cannot change the value of x now as its set now and is only used for read now
            //we can create a copy of coordiante with new values using the with keyword
            Coordinate cChange = c with { X = 13, Y = 56 }; 

            newCoordiante cnew = new newCoordiante(12, 42) { Z = 56 };
            var (x, y) = cnew;

            //can use compare on structs now if they are records
            newCoordiante dnew = new newCoordiante(12, 42) { Z = 56 };

            Console.WriteLine(cnew == dnew);
            Console.WriteLine("Hello, World!");
        }
    }

    public readonly struct Coordinate
    {
        public Coordinate()
        {
            X = 0;
            Y = 0;
        }

        public int X { get; init; }
        public int Y { get; init; }
    }

    //record structs
    public readonly record struct newCoordiante(int X, int Y)
    {
        public int Z { get; init; }
    }
}
