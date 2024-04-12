using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericLiteralDemo
{
    class NumericLiteral
    {
        [Flags]
        public enum Codes
        {
            // Decimal // Binary
            One = 1, // 000001
            Two = 2, // 000010
            Four = 4, // 000100
            Eight = 8, // 001000
        };

        // C# 7 declaration using binary literals
        public const int One = 0b0001;
        public const int Two = 0b0010;
        public const int Four = 0b0100;
        public const int Eight = 0b1000;

        // digit seperators can be used to separate long binary numbers
        public const int Sixteen = 0b0001_0000;
        public const int ThirtyTwo = 0b0010_0000;
        public const int SixtyFour = 0b0100_0000;
        public const int OneHundredTwentyEight = 0b1000_0000;

        // The digit separator can appear anywhere in the constant.
        // For base 10 numbers, it would be common use it as a thousands separator
        public const long OneHunderdBillion = 100_000_000_000;

        // The digit separator can be used decimal, float and double types as well
        public const double AvogadroConstant = 6.022_140_875_747_474e23;
        public const decimal GoldenRatio = 1.618_033_988_749_894_848_204_586_834_365_638_117_720_309_179M;

        static void Main(string[] args)
        {
            // Old way of doing bitwise operations using enums
            Codes code = Codes.One | Codes.Four;
            bool isFour = (code & Codes.Four) != 0;
            Console.WriteLine(isFour);

            // New way of doing it in C# 7
            const int codeNew = One | Four;
            bool isFourNew = (codeNew & Four) != 0;
            Console.WriteLine(isFourNew);

            Console.WriteLine(OneHundredTwentyEight);

            //Calculate the number of atoms in 6 moles of sodium
            Console.WriteLine(6 * AvogadroConstant);
        }
    }
}