using System.Collections.Generic;
using CodingPractices.Tree;
using FluentAssertions;
using NUnit.Framework;

namespace CodingPracticesTest.Tree
{
    [TestFixture]
    public class DictionaryTreeTest
    {
        private DictionaryTree _dictionaryTree;

        [SetUp]
        public void SetUp()
        {
            _dictionaryTree = new DictionaryTree();
        }

        [Test]
        public void Should_Find_Repeated_Words()
        {
            var input = new[] {"cat", "dog", "doggg", "dog", "cat", "cat", "dog"};
            var expected = new[] {"cat", "dog"};
            var res = _dictionaryTree.FindRepeatedWords(input);
            res.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Should_Return_Empty_For_Not_Fully_Repeated_Words()
        {
            var input = new[] { "dog", "doggg" };
            var expected = new string[0];
            var res = _dictionaryTree.FindRepeatedWords(input);
            res.Should().BeEquivalentTo(expected);
        }

        [Test]
        [TestCaseSource(nameof(NullOrEmptyInput))]
        public void Should_Return_Empty_For_Null_Or_Empty_Input(IList<string> input)
        {
            var expected = new string[0];
            var res = _dictionaryTree.FindRepeatedWords(input);
            res.Should().BeEquivalentTo(expected);
        }

        private static readonly IList<string>[] NullOrEmptyInput =
        {
            null,
            new List<string>(),
            new List<string> {""}
        };
    }
}
