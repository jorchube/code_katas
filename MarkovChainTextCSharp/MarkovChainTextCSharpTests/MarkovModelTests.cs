using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using MarkovChainTextCSharp;

namespace MarkovChainTextCSharp
{
    public class MarkovModelTests
    {
        private MarkovModel model;

        [SetUp]
        public void Setup()
        {
            model = new MarkovModel();
        }

        [Test]
        public void ModellingASingleStateProcess()
        {
            model.Learn("word");

            Assert.AreEqual("word", model.RandomState());
            Assert.IsFalse(model.HasNextState("word"));
        }

        [Test]
        public void ModellingATwoStateProcess()
        {
            List<string> states = new List<string>();
            states.Add("word");
            states.Add("end");

            model.Learn("word end");

            Assert.IsTrue(states.Contains(model.RandomState()));
            Assert.AreEqual("end", model.NextState("word"));
            Assert.AreEqual(null, model.NextState("end"));
        }
    }
}