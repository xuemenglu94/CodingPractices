using System;
using CodingPractices.Search;
using FluentAssertions;
using NUnit.Framework;

namespace CodingPracticesTest.Search
{
    [TestFixture]
    public class BinarySearchTest
    {
        private BinarySearch _binarySearch;

        [SetUp]
        public void SetUp()
        {
            _binarySearch = new BinarySearch();
        }

        [Test]
        public void Should_Find_Correct_Target_Index()
        {
            var input = new [] {1, 3, 4, 5, 7, 8, 10};
            var target = 8;
            var expected = 5;

            var res = _binarySearch.TargetIndex(input, target);
            res.Should().Be(expected);
        }

        [Test]
        [TestCase(15)]
        [TestCase(0)]
        public void Should_Return_Cannot_Find_Target_Warning(int target)
        {
            var input = new[] { 1, 3, 4, 5, 7, 8, 10 };
            var ex = Assert.Throws<Exception>(() => _binarySearch.TargetIndex(input, target));
            ex.Message.Should().Be("Target cannot be found in given region");
        }

        [Test]
        [TestCase(null)]
        [TestCase(new int[0])]
        public void Should_Return_Invalid_Search_Region_Warning(int[] input)
        {
            var ex = Assert.Throws<Exception>(() => _binarySearch.TargetIndex(input, 5));
            ex.Message.Should().Be("Search region should has at least one number");
        }

        [Test]
        [TestCase(6, 3)]
        [TestCase(0, -1)]
        [TestCase(11, 6)]
        public void Should_Find_Correct_Left_Bound(int target, int expected)
        {
            var input = new[] { 1, 3, 4, 5, 7, 8, 10 };

            var res = _binarySearch.LeftBound(input, target);
            res.Should().Be(expected);
        }

        [Test]
        [TestCase(6, 4)]
        [TestCase(0, 0)]
        [TestCase(11, -1)]
        public void Should_Find_Correct_Right_Bound(int target, int expected)
        {
            var input = new[] { 1, 3, 4, 5, 7, 8, 10 };

            var res = _binarySearch.RightBound(input, target);
            res.Should().Be(expected);
        }

        [Test]
        [TestCase(new[] {1, 2, 3, 0, 1, 1}, 0)]
        [TestCase(new[] {3, 4, 5, 1, 2}, 1)]
        [TestCase(new[] {2, 2, 0, 1, 2}, 0)]
        [TestCase(new[] {1, 0, 1, 1, 1}, 0)]
        [TestCase(new[] {1, 1, 1, 0, 1}, 0)]
        public void Should_Find_Min_In_Rotated_Min_Array(int[] input, int expected)
        {
            _binarySearch.MinArray(input).Should().Be(expected);
        }

        [Test]
        [TestCase(new[] { 3, 4, 5, 1, 2 }, 1)]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 1)]
        [TestCase(new[] { 4, 5, 1, 2, 3 }, 1)]
        [TestCase(null, -1)]
        [TestCase(new int[0], -1)]
        [TestCase(new[] { 1 }, 1)]
        [TestCase(new[] { 2, 1 }, 1)]
        [TestCase(new[] { 6, 1, 2, 3, 4, 5 }, 1)]
        public void Should_Correctly_Return_Min_Value(int[] input, int minValue)
        {
            _binarySearch.FindMinValue(input).Should().Be(minValue);
        }
    }
}
