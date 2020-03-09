using NUnit.Framework;
using System.Collections.Generic;

namespace MarkovChainTextCSharp
{
    public class MarkovChainStateTests
    {
        private MarkovChainState state;

        [SetUp]
        public void Setup()
        {
            state = new MarkovChainState("key");
        }

        [Test]
        public void CreatingStateWithoutTransitions()
        {
            Assert.AreEqual("key", state.Key);
            Assert.AreEqual(0, state.NumTransitions());
            Assert.AreEqual("", state.WeightedRandomNextState());
            Assert.AreEqual(0, state.TransitionWeight("non existent transition"));
        }

        [Test]
        public void CreatingStateWithOneTransition()
        {
            state.AddTransision("transition");

            Assert.AreEqual(1, state.NumTransitions());
            Assert.AreEqual("transition", state.WeightedRandomNextState());
            Assert.AreEqual(1, state.TransitionWeight("transition"));
        }

        [Test]
        public void CreatingStateWithOneTransitionWithMoreWeight()
        {
            state.AddTransision("transition");
            state.AddTransision("transition");
            state.AddTransision("transition");

            Assert.AreEqual(1, state.NumTransitions());
            Assert.AreEqual(3, state.TransitionWeight("transition"));
        }

        [Test]
        public void CreatingStateWithManyTransitions()
        {
            List<string> transitions = new List<string>();
            transitions.Add("transition0");
            transitions.Add("transition1");

            state.AddTransision("transition0");
            state.AddTransision("transition1");

            Assert.AreEqual(2, state.NumTransitions());
            Assert.AreEqual(1, state.TransitionWeight("transition0"));
            Assert.AreEqual(1, state.TransitionWeight("transition1"));
            Assert.IsTrue(transitions.Contains(state.WeightedRandomNextState()));
        }

        [Test]
        public void CreatingStateWithManyTransitionsWithDifferentWeights()
        {
            List<string> transitions = new List<string>();
            transitions.Add("transition0");
            transitions.Add("transition1");

            state.AddTransision("transition0");
            state.AddTransision("transition0");
            state.AddTransision("transition1");
            state.AddTransision("transition1");
            state.AddTransision("transition1");

            Assert.AreEqual(2, state.NumTransitions());
            Assert.AreEqual(2, state.TransitionWeight("transition0"));
            Assert.AreEqual(3, state.TransitionWeight("transition1"));
            Assert.IsTrue(transitions.Contains(state.WeightedRandomNextState()));
        }
    }
}
