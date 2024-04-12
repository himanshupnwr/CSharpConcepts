using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSAEDemoApp
{
    class Students
    {
        // Use tuples to return mean, highest and lowest test scores from a list of percentages
        private static (double Mean, double Highest, double Lowest) computeMeanHighestLowest(IEnumerable<double> testScores)
        {
            double mean = 0;
            double lowest = -100;
            double highest = 0;
            int count = 0;
            double sum = 0;

            foreach (var testScore in testScores)
            {
                if (testScore < lowest)
                    lowest = testScore;
                if (testScore > highest)
                    highest = testScore;

                count++;
                sum += testScore;
            }
            mean = sum / (double)count;

            return (mean, highest, lowest);
        }

        // Use a local function to print all the test scores between a student's lowest score and highest score
        public static IEnumerable<int> highestLowestSubset(int lowest, int highest)
        {
            if (lowest < 0)
                throw new ArgumentOutOfRangeException(paramName: nameof(lowest), message: "start must be greater than or equal to");

            if (highest > 100)
                throw new ArgumentOutOfRangeException(paramName: nameof(highest), message: "start must be less than or equal to");
        
            if (highest < lowest)
                throw new ArgumentException($"{nameof(highest)} must be greater than or equal to {nameof(lowest)}");

            return highestLowestSubsetImplementation();

            IEnumerable<int> highestLowestSubsetImplementation()
            {
                // local function, easier to read and can't be called from outside method
                for (var c = lowest; c < highest; c++)
                    yield return c;
            }
        }

        // Use an out variable to change a test score
        static void ChangeTestScore(out int testScore)
        {
            testScore = 44;
        }

        static void Main(string[] args)
        {
            // Use a tuple function to calculate the highest, lowest and mean scores
            IEnumerable<double> testScore = new List<double>() { 92, 88, 75, 72, 80, 90, 55 };
            var values = computeMeanHighestLowest(testScore);
            Console.WriteLine("The mean score is: " + Math.Round(values.Item1, 2) + " The highest score is " + values.Item2 + " The lowest score is: " + values.Item3);

            // Use a local function to list the test scores

            var scores = highestLowestSubset(100, 95);
            //var scores = highestLowestSubset(95, 100);
            Console.WriteLine("iterator created");
            foreach (var thing in scores)
                Console.WriteLine($"{thing}, ");

            // Use an out variable to set a test score
            ChangeTestScore(out int testScoreed);
            Console.WriteLine("The new test score is: " + testScoreed);
        }
    }
}
