namespace TupleDemo
{
    class Program
    {
        //Tuples are no longer allocated as objects which decreased performance. They are now allocated as structs
        public static double StandardDeviation(IEnumerable<double> sequence)
        {
            //returns the standard deviation of a list of test scores using tuples
            //var computation = ComputeSumAndSumOfSquares(sequence);
            //var variance = computation.SumOfSquares - computation.Sum * computation.Sum / computation.Count;
            //return Math.Sqrt(variance / computation.Count);
            // deconstruction of a tuple example
            (int count, double sum, double sumOfSquares) = ComputeSumAndSumOfSquares(sequence);
            var variance = sumOfSquares - sum * sum / count;
            return Math.Sqrt(variance / count);
        }

        private static (int count, double sum, double SumOfSquares) ComputeSumAndSumOfSquares(IEnumerable<double> sequence)
        {
            double sum = 0;
            double sumOfSquares = 0;
            int count = 0;

            foreach (var item in sequence)
            {
                count++;
                sum += item;
                sumOfSquares += item * item;
            }
            return (count, sum, sumOfSquares);
        }

        static void Main(string[] args)
        {
            //The 'arity' and 'shape' of all these tuples are compatible.
            //The only difference is the field names being used.
            var unnamed = (42, "The meaning of life");
            var anonymous = (16, "a perfect square");
            var named = (Answer: 42, Message: "The meaning of life");
            var differentNamed = (SecretConstant: 42, Label: "The meaning of life");

            //old way to display tuple contents
            Console.WriteLine($"{unnamed.Item1}, {unnamed.Item2}");

            //unnamed to named
            unnamed = named;

            //named to unnamed
            named = unnamed;

            //'named' still has fields that can be refered to
            // as 'answer', and 'message':
            Console.WriteLine($"{named.Answer}, {named.Message}");

            //named tuples.
            named = differentNamed;
            // The field names are not assigned. 'named' still has
            // fields that can be refered to as 'answer', and 'message':
            //Console.WriteLine($"{named.Answer}, {named.Message}");

            // Does not compile.
            //CS0029: Cannot assign Tuple(int,int,int) to Tuple(int, string)
            //var differentShape = (1, "2", 3);
            //named = differentShape;
            IEnumerable<double> stdDev = new List<double>() { 55, 60, 75, 80, 72, 90, 92 };
            Console.WriteLine("Standard Deviation of: 55, 60, 75, 80, 72, 90, 92 is: " + StandardDeviation(stdDev));
        }
    }
}
