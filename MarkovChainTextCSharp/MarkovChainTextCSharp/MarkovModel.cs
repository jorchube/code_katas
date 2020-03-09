using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkovChainTextCSharp
{
    public class MarkovModel
    {
        private Dictionary<string, MarkovChainState> states;

        public MarkovModel()
        {
            states = new Dictionary<string, MarkovChainState>();
        }

        public void Learn(string text)
        {
            int i;
            string[] words = text.Replace(Environment.NewLine, " ").Split(" ");

            for (i = 0; i < words.Length - 1; ++i) {
                LearnState(words[i], words[i+1]);
            }
            LearnState(words.Last());
        }


        private void LearnState(string key, string transition)
        {
            LearnState(key);
            states[key].AddTransision(transition);
        }

        private void LearnState(string key)
        {
            if (!states.ContainsKey(key)) {
                states.Add(key, new MarkovChainState(key));
            }
        }

        public string RandomState()
        {
            return states.Keys.ToArray()[0];
        }

        public string NextState(string key)
        {
            if (HasNextState(key)) {
                return states[key].WeightedRandomNextState();
            }

            return null;
        }

        public bool HasNextState(string key)
        {
            if (states.ContainsKey(key)) {
                return states[key].NumTransitions() > 0;
            }

            return false;
        }
    }
}
