using CodingPractices.String;
using FluentAssertions;
using NUnit.Framework;

namespace CodingPracticesTest.String
{
    [TestFixture]
    public class ReplaceEmptySpaceTest
    {
        private ReplaceEmptySpace _replaceEmptySpace;

        [SetUp]
        public void SetUp()
        {
            _replaceEmptySpace = new ReplaceEmptySpace();
        }

        [Test]
        public void Should_Successfully_ReplaceEmptySpace()
        {
            var input = "We are happy";
            var expected = "We%20are%20happy";
            var res = _replaceEmptySpace.Replace(input);
            res.Should().Be(expected);
        }

        [Test]
        public void Should_Successfully_ReplaceEmptySpace_arr()
        {
            var input = "We are happy";
            var expected = "We%20are%20happy";
            var res = _replaceEmptySpace.Replace_arr(input);
            res.Should().Be(expected);
        }
    }
}
