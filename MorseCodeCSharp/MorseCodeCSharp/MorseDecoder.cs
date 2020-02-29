using System;
using System.Collections.Generic;
using System.Text;

namespace MorseCodeCSharp
{
    public class MorseDecoder
    {
        static string[,] char_conversion_table = {
            {" ", ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.."},
            {"", "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"}
        };

        static Dictionary<string, string> conversion_dict = null;

        public static string Decode(string morse)
        {
            string value = "";
            string[] words;

            MorseDecoder.InitializeConversionDict();

            words = morse.Split("   ");

            foreach (string word in words) { 
                value += DecodeWord(word);
                value += " ";
            }

            return value.Trim();
        }

        static string DecodeWord(string morse)
        {
            string value = "";
            string[] chars = morse.Split(" ");

            foreach (string c in chars) {
                value += DecodeChar(c);
            }

            return value;
        }

        static string DecodeChar(string morse)
        {
            string value;

            if (MorseDecoder.conversion_dict.TryGetValue(morse, out value)) {
                return value;
            }

            return "";
        }

        static void InitializeConversionDict()
        {
            int i;

            MorseDecoder.conversion_dict = new Dictionary<string, string>();
            for (i = 0; i < MorseDecoder.char_conversion_table.GetLength(1); ++i) {
                MorseDecoder.conversion_dict.Add(MorseDecoder.char_conversion_table[0,i], MorseDecoder.char_conversion_table[1,i]);
            }
            
        }
    }
}
