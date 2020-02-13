using System;
using System.Collections.Generic;
using System.Linq;

namespace ShiritoriCSharp
{
    public class Shiritori
    {
        ShiritoriDictionaryInterface dictionary;
        List<string> used_words;
        string last_answer;
        bool is_first_challenge;
        public Shiritori(ShiritoriDictionaryInterface dictionary)
        {
            this.dictionary = dictionary;

            used_words = new List<string>();

            is_first_challenge = true;
        }

        public string Challenge(string challenge)
        {
            if (!IsValidChallenge(challenge)) {
                throw new InvalidChallengeException();
            }

            if (!ChallengeCanBeAnswered(challenge)) {
                throw new ILostException();
            }

            string answer = GetChallengeAnswer(challenge);

            AddToUsedWordsList(answer);
            UpdateLastAnswer(answer);

            is_first_challenge = false;

            return answer;
        }

        private bool ChallengeCanBeAnswered(string challenge)
        {
            return GetAllAnswersToChallenge(challenge).Count() > 0;
        }

        private string GetChallengeAnswer(string challenge)
        {
            return GetAllAnswersToChallenge(challenge).First();
        }

        private IEnumerable<string> GetAllAnswersToChallenge(string challenge)
        {
            IList<string> words = dictionary.List();

            return words.Where(elem => elem.StartsWith(LastChar(challenge))).Except(used_words);
        }

        private void UpdateLastAnswer(string answer)
        {
            last_answer = answer;
        }

        private bool IsValidChallenge(string challenge)
        {
            if (is_first_challenge) {
                return true;
            }

            return challenge.StartsWith(LastChar(last_answer));
        }

        private void AddToUsedWordsList(string word)
        {
            used_words.Add(word);
        }

        private char LastChar(string word)
        {
            return word.ToCharArray()[word.Length - 1];
        }
    }

    public class InvalidChallengeException : Exception { }

    public class ILostException : Exception { }
}
