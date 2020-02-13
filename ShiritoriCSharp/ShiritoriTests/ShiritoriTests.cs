using System.Collections.Generic;
using NUnit.Framework;

using ShiritoriCSharp;

namespace ShiritoriTests
{
    public class Tests
    {
        Shiritori shiri;

        [SetUp]
        public void Setup()
        {
            shiri = new Shiritori(new ShiritoriDictionaryStub());
        }

        [Test]
        public void ShouldInitializeShiritoriWithDictionary()
        {
            
        }

        [Test]
        public void ShouldReturnValidAnswerAfterProvidingWord()
        {
            Assert.IsTrue(shiri.Challenge("car").StartsWith('r'));
            Assert.IsTrue(shiri.Challenge("myth").StartsWith('h'));
        }

        [Test]
        public void ShouldNotRepeatAnswer()
        {
            // Given
            shiri.Challenge("car");

            // When
            string answer = shiri.Challenge("master");

            // Then
            Assert.IsTrue(answer.StartsWith('r'));
            Assert.AreNotEqual(answer, "rhythm");
        }

        [Test]
        public void ShouldRaiseInvalidChallengeExceptionWhenProvidingAnInvalidChallenge()
        {
            // Given
            shiri.Challenge("car");

            // Then
            Assert.Throws<InvalidChallengeException>(delegate { shiri.Challenge("zazzz"); });
        }

        [Test]
        public void ShouldRaiseILostExceptionWhenUnablerToAnswerAChallenge()
        {
            Assert.Throws<ILostException>(delegate { shiri.Challenge("blerg"); });
        }
    }

    class ShiritoriDictionaryStub : ShiritoriDictionaryInterface
    {
        List<string> word_list;
        
        public ShiritoriDictionaryStub()
        {
            word_list = new List<string>();

            word_list.Add("rhythm");
            word_list.Add("hour");
            word_list.Add("rat");
        }

        public List<string> List()
        {
            return word_list;
        }
    }
}