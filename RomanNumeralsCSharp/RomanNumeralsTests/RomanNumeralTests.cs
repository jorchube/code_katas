using NUnit.Framework;

using RomanNumeralsCSharp;

namespace RomanNumeralsTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldConvertDirectEquivalentDecimalsToRomans()
        {
            Assert.AreEqual("I", Romans.ToRoman(1));
            Assert.AreEqual("V", Romans.ToRoman(5));
            Assert.AreEqual("X", Romans.ToRoman(10));
            Assert.AreEqual("L", Romans.ToRoman(50));
            Assert.AreEqual("C", Romans.ToRoman(100));
            Assert.AreEqual("D", Romans.ToRoman(500));
            Assert.AreEqual("M", Romans.ToRoman(1000));
        }

        [Test]
        public void ShouldConvertDirectSubstractedDecimalsToRomans()
        {
            Assert.AreEqual("IV", Romans.ToRoman(4));
            Assert.AreEqual("IX", Romans.ToRoman(9));
            Assert.AreEqual("XL", Romans.ToRoman(40));
            Assert.AreEqual("XC", Romans.ToRoman(90));
            Assert.AreEqual("CD", Romans.ToRoman(400));
            Assert.AreEqual("CM", Romans.ToRoman(900));
        }

        [Test]
        public void ShouldConvertAnyDecimalToRoman()
        {
            Assert.AreEqual("II", Romans.ToRoman(2));
            Assert.AreEqual("III", Romans.ToRoman(3));
            Assert.AreEqual("VI", Romans.ToRoman(6));
            Assert.AreEqual("VII", Romans.ToRoman(7));
            Assert.AreEqual("VIII", Romans.ToRoman(8));
            Assert.AreEqual("XV", Romans.ToRoman(15));
            Assert.AreEqual("XXIX", Romans.ToRoman(29));
            Assert.AreEqual("XLV", Romans.ToRoman(45));
            Assert.AreEqual("XLIX", Romans.ToRoman(49));
            Assert.AreEqual("MMMDCCCLXXXVIII", Romans.ToRoman(3888));
            Assert.AreEqual("MMMMCMXCIX", Romans.ToRoman(4999));
        }

        [Test]
        public void ShouldConvertSimpleRomansToDecimals()
        {
            Assert.AreEqual(1, Romans.ToDecimal("I"));
            Assert.AreEqual(10, Romans.ToDecimal("X"));
            Assert.AreEqual(40, Romans.ToDecimal("XL"));
            Assert.AreEqual(900, Romans.ToDecimal("CM"));
        }

        [Test]
        public void ShouldConvertAllRomansToDecimals()
        {
            Assert.AreEqual(2, Romans.ToDecimal("II"));
            Assert.AreEqual(6, Romans.ToDecimal("VI"));
            Assert.AreEqual(1100, Romans.ToDecimal("MC"));
            Assert.AreEqual(900, Romans.ToDecimal("CM"));
            Assert.AreEqual(901, Romans.ToDecimal("CMI"));
            Assert.AreEqual(1949, Romans.ToDecimal("MCMXLIX"));
        }
    }
}