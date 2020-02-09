using NUnit.Framework;

using FizzBuzzCSharp;

namespace FizzBuzzTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldReturnSequenceOfLength1()
        {
            Assert.AreEqual("1", FizzBuzz.Sequence(1));
        }

        [Test]
        public void ShouldReturnSequenceOfLength2()
        {
            Assert.AreEqual("1 2", FizzBuzz.Sequence(2));
        }

        [Test]
        public void ShouldReturnSequenceOfLength3()
        {
            Assert.AreEqual("1 2 Fizz", FizzBuzz.Sequence(3));
        }

        [Test]
        public void ShouldReturnSequenceOfLength5()
        {
            Assert.AreEqual("1 2 Fizz 4 Buzz", FizzBuzz.Sequence(5));
        }

        [Test]
        public void ShouldReturnSequenceOfLength10()
        {
            Assert.AreEqual("1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz", FizzBuzz.Sequence(10));
        }

        [Test]
        public void ShouldReturnSequenceOfLength15()
        {
            Assert.AreEqual("1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz", FizzBuzz.Sequence(15));
        }
    }
}