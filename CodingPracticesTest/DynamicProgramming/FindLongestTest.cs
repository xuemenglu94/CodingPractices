using CodingPractices.DynamicProgramming;
using FluentAssertions;
using NUnit.Framework;

namespace CodingPracticesTest.DynamicProgramming
{
    [TestFixture]
    public class FindLongestTest
    {
        private FindLongest _findLongest;

        [SetUp]
        public void SetUp()
        {
            _findLongest = new FindLongest();
        }

        [Test]
        public void Should_Find_Longest_Common_Sub_Sequence()
        {
            var res = _findLongest.CommonSubSequence("abcdfggg", "acdfgg");
            res.Should().Be(6);
        }

        [Test]
        public void Should_Find_Longest_Common_Sub_String()
        {
            var res = _findLongest.CommonSubString("abcdfggg", "bcdfgg");
            res.Should().Be(6);
        }

        [Test]
        public void Should_Find_Longest_Palindrome()
        {
            var res = _findLongest.Palindrome("cbaectceabd");
            res.Should().Be("baectceab");
        }
    }
}
