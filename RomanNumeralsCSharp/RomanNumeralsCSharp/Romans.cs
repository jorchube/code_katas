using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace RomanNumeralsCSharp
{
    public class Romans
    {
        static RomansConversionTable conversion_table;

        public static string ToRoman(int value)
        {
            conversion_table = new RomansConversionTable();

            return DecimalToRoman(value);
        }

        public static int ToDecimal(string value)
        {
            conversion_table = new RomansConversionTable();

            return RomanToDecimal(value);
        }

        private static int RomanToDecimal(string value)
        {
            if (value.Length == 1) {
                return conversion_table.ToDecimal(value);
            }

            if (value.Length == 2 && conversion_table.HasRomanKey(value)) {
                return conversion_table.ToDecimal(value);
            }

            if (value.Length > 2 && conversion_table.HasRomanKey(value.Substring(0, 2))) {
                return conversion_table.ToDecimal(value.Substring(0, 2)) + RomanToDecimal(value.Substring(2));
            }

            return conversion_table.ToDecimal(value.Substring(0, 1)) + RomanToDecimal(value.Substring(1));
        }

        private static string DecimalToRoman(int value)
        {
            int substractor;

            if (conversion_table.HasDecimalKey(value)) {
                return conversion_table.ToRoman(value);
            }

            substractor = HighestSubstractor(value);

            return conversion_table.ToRoman(substractor) + DecimalToRoman(value - substractor);
        }

        private static int HighestSubstractor(int value)
        {
            int[] keys = conversion_table.DecimalKeys();

            SortKeysArrayAscending(keys);

            foreach (int key in keys) {
                if (value > key) {
                    return key;
                }
            }

            throw new UnableToFindDivisorException(string.Format("Unable to find substractor for {0}", value));
        }

        private static void SortKeysArrayAscending(int[] keys)
        {
            Array.Sort(keys);
            Array.Reverse(keys);
        }

        private class UnableToFindDivisorException : Exception
        {
            public UnableToFindDivisorException(string message) : base(message)
            {
            }
        }
    }


    class RomansConversionTable
    {
        ValueTuple<int, string>[] equivalences = {
            (1, "I"),
            (4, "IV"),
            (5, "V"),
            (9, "IX"),
            (10, "X"),
            (40, "XL"),
            (50, "L"),
            (90, "XC"),
            (100, "C"),
            (400, "CD"),
            (500, "D"),
            (900, "CM"),
            (1000, "M")
        };

        Dictionary<int, string> decimal_keys_table;
        Dictionary<string, int> roman_keys_table;

        public RomansConversionTable()
        {
            decimal_keys_table = new Dictionary<int, string>();
            roman_keys_table = new Dictionary<string, int>();

            fillKeysTables();
        }

        public bool HasDecimalKey(int key)
        {
            return decimal_keys_table.ContainsKey(key);
        }

        public int[] DecimalKeys()
        {
            int[] keys = new int[decimal_keys_table.Keys.Count];

            decimal_keys_table.Keys.CopyTo(keys, 0);

            return keys;
        }

        public string ToRoman(int key)
        {
            string value;

            decimal_keys_table.TryGetValue(key, out value);

            return value;
        }

        public int ToDecimal(string key)
        {
            int value;

            roman_keys_table.TryGetValue(key, out value);

            return value;
        }

        private void fillKeysTables()
        {
            foreach (ValueTuple<int, string> tuple in equivalences) {
                decimal_keys_table.Add(tuple.Item1, tuple.Item2);
                roman_keys_table.Add(tuple.Item2, tuple.Item1);
            }
        }

        internal bool HasRomanKey(string key)
        {
            return roman_keys_table.ContainsKey(key);
        }
    }
}
