namespace LocalFunctions
{
    class LocalFunctions
    {

        public static IEnumerable<char> AlphabetSubset(char start, char end)
        {
            if ((start < 'a') || (start > 'z'))
                throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
            if ((end < 'a') || (start > 'z'))
                throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");

            if (end <= start)
                throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");
            for (var c = start; c < end; c++)
                yield return c;
        }

        public static IEnumerable<char> AlphabetSubset2(char start, char end)
        {
            if ((start < 'a') || (start > 'z'))
                throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
            if ((end < 'a') || (start > 'z'))
                throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");

            if (end <= start)
                throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");
            // throw exceptions immediately because the public method isn't an iterator method
            return alphabetSubsetImplementation(start, end);
        }

        public static IEnumerable<char> alphabetSubsetImplementation(char start, char end)
        {
            for (var c = start; c < end; c++)
                yield return c;
        }

        public static IEnumerable<char> AlphabetSubset3(char start, char end)
        {
            if ((start < 'a') || (start > 'z'))
                throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
            if ((end < 'a') || (start > 'z'))

                throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");
            if (end <= start)
                throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");
            return alphabetSubsetImplementation();

            //Local function
            IEnumerable<char> alphabetSubsetImplementation()
            {
                for (var c = start; c < end; c++)
                    yield return c;
            }
        }

        static void Main(string[] args)
        {
            // exception thrown because end letter f should be less
            // than or equal to start letter a
            var resultSet = LocalFunctions.AlphabetSubset('a', 'f');
            Console.WriteLine("iterator created");
            foreach (var thing in resultSet)
                Console.Write($"{thing}, ");
        }
    }
}
