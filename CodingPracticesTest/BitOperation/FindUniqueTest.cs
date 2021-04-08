using System;
using System.Collections.Generic;
using CodingPractices.BitOperation;
using FluentAssertions;
using NUnit.Framework;

namespace CodingPracticesTest.BitOperation
{
    [TestFixture]
    public class FindUniqueTest
    {
        private FindUnique _findUnique;

        [SetUp]
        public void SetUp()
        {
            _findUnique = new FindUnique();
        }

        [Test]
        public void Should_Find_Unique_Two_Values()
        {
            var input = new[] { 1, 1, 2, 2, 3, 3, 4, 5, 6, 6, 7, 7, 8, 8 };
            var res = _findUnique.TwoValues(input);
            res.Should().Be((4, 5));
        }

        [Test]
        public void Should_Find_Unique_Two_Values_Special()
        {
            var input = new[] { 0, 1 };
            var res = _findUnique.TwoValues(input);
            res.Should().Be((0, 1));
        }

        [Test]
        public void Should_Find_Unique_Single_Value()
        {
            var input = new[] {1, 1, 2, 2, 3, 3, 4, 5, 5, 6, 6, 7, 7, 8, 8};
            int res = _findUnique.SingleValue(input);
            res.Should().Be(4);
        }

        [Test]
        [TestCaseSource(nameof(NullOrEmptyInput))]
        public void Should_Throw_Exception_For_Invalid_Input_Num_List(IList<int> input)
        {
            var ex = Assert.Throws<Exception>(() => _findUnique.SingleValue(input));
            ex.Message.Should().Be("Please enter input with at least one number");
        }

        private static readonly IList<int>[] NullOrEmptyInput =
        {
            null,
            new List<int>()
        };
    }
}
