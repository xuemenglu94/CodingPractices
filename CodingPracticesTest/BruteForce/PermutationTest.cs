using System.Collections.Generic;
using CodingPractices.BruteForce;
using FluentAssertions;
using NUnit.Framework;

namespace CodingPracticesTest.BruteForce
{
    [TestFixture]
    public class PermutationTest
    {
        private Permutation _permutation;
        
        [SetUp]
        public void SetUp()
        {
            _permutation = new Permutation();
        }

        [Test]
        public void Should_Permute_int_array()
        {
            var input = new[] {1, 2, 3};
            var expected = new List<List<int>>
            {
                new List<int> {1, 2, 3},
                new List<int> {1, 3, 2},
                new List<int> {2, 1, 3},
                new List<int> {2, 3, 1},
                new List<int> {3, 1, 2},
                new List<int> {3, 2, 1}
            };

            var res = _permutation.Permute(input);
            res.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Should_Permute_string()
        {
            var input = "abc";
            var expected = new List<string>
            {
                "abc",
                "acb",
                "bac",
                "bca",
                "cba",
                "cab"
            };

            var res = _permutation.PermuteString(input);
            res.Should().BeEquivalentTo(expected);
        }
    }
}
