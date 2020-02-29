using NUnit.Framework;

using MorseCodeCSharp;

namespace MorseCodeCSharpTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DecodingACharacter()
        {
            Assert.AreEqual("e", MorseDecoder.Decode("."));
            Assert.AreEqual("j", MorseDecoder.Decode(".---"));
        }

        [Test]
        public void DecodingAWord()
        {
            Assert.AreEqual("steak", MorseDecoder.Decode("... - . .- -.-"));
        }

        [Test]
        public void DecodingASentence()
        {
            Assert.AreEqual("i like steaks a lot", MorseDecoder.Decode("..   .-.. .. -.- .   ... - . .- -.- ...   .-   .-.. --- -"));
        }
    }
}