using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkovChainTextCSharp
{
    public class MarkovChainState
    {
        private string _key;
        private Dictionary<string, int> transitions_weights;

        public MarkovChainState(string key)
        {
            this._key = key;
            this.transitions_weights = new Dictionary<string, int>();
        }

        public string Key
        {
            get
            {
                return this._key;
            }
        }

        public int NumTransitions()
        {
            return transitions_weights.Count;
        }

        public void AddTransision(string word)
        {
            if (transitions_weights.ContainsKey(word)) {
                transitions_weights[word] += 1;
            } else {
                transitions_weights.Add(word, 1);
            }
        }

        public string WeightedRandomNextState()
        {
            int current_weight = 0;
            int target_weight;
            Random rand = new Random();

            if (NumTransitions() == 0) {
                return "";
            }

            target_weight = rand.Next(0, TotalWeight());

            foreach ((string key, int weight) in transitions_weights) {
                current_weight += weight;
                if (current_weight >= target_weight) {
                    return key;
                }
            }

            return "";
        }

        public int TransitionWeight(string key)
        {
            return transitions_weights.GetValueOrDefault(key);
        }

        private int TotalWeight()
        {
            return transitions_weights.Values.Sum();
        }
    }
}
