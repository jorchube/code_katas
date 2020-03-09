using System;
using System.IO;
using System.Linq;

namespace MarkovChainTextCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            MarkovModel model = new MarkovModel();
            string training_text = System.IO.File.ReadAllText(@"D:\jorch\Code\code_katas\MarkovChainTextCSharp\MarkovChainTextCSharp\sample.txt");

            model.Learn(training_text);

            string word = "The";
            foreach(int i in Enumerable.Range(0, 200)) {
                Console.Write(word);
                word = model.NextState(word);

                if (word != null) {
                    Console.Write(" ");
                } else {
                    break;
                }
            }

            Console.WriteLine("");
        }
    }
}
