using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzCSharp
{
    public class FizzBuzz
    {
        const string FIZZ = "Fizz";
        const string BUZZ = "Buzz";

        private static List<int> sequence;

        public static string Sequence(int length)
        {
            sequence = new List<int>(length);

            fillSequence();

            return sequenceAsString();
        }

        private static string sequenceAsString()
        {
            IEnumerable<string> strings_sequence = sequence.Select(element => elementToString(element));

            return string.Join(" ", strings_sequence);
        }

        private static string elementToString(int element)
        {
            if (isElementDivisibleBy(element, divisible_by: 3) && isElementDivisibleBy(element, divisible_by: 5)) {
                return FIZZ + BUZZ;
            }

            if (isElementDivisibleBy(element, divisible_by: 3)) {
                return FIZZ;
            }

            if (isElementDivisibleBy(element, divisible_by: 5)) {
                return BUZZ;
            }

            return element.ToString();
        }

        private static bool isElementDivisibleBy(int element, int divisible_by)
        {
            return element % divisible_by == 0;
        }

        private static void fillSequence()
        {
            for (int i = 0; i < sequence.Capacity; ++i)
            {
                sequence.Insert(i, i + 1);
            }
        }
    }
}
