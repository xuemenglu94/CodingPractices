using System;
using CodingPractices.DynamicProgramming;
using FluentAssertions;
using NUnit.Framework;

namespace CodingPracticesTest.DynamicProgramming
{
    [TestFixture]
    public class FibonacciTest
    {
        private Fibonacci _fibonacci;

        [SetUp]
        public void SetUp()
        {
            _fibonacci = new Fibonacci();
        }

        [Test]
        public void Should_Get_Fib_With_Correct_Index()
        {
            // 1, 1, 2, 3, 5, 8, 13
            var res = _fibonacci.FibonacciOfIndex(7);
            res.Should().Be(13);
        }

        [Test]
        public void Should_Throw_Exception_For_Fib_With_Invalid_Index()
        {
            var exception = Assert.Throws<Exception>(() => _fibonacci.FibonacciOfIndex(-1));
            exception.Message.Should().Be("Please enter a valid index of fibonacci sequence");
        }

        [Test]
        public void Should_Get_Fib_With_Correct_Index_dp_method()
        {
            // 1, 1, 2, 3, 5, 8, 13
            var res = _fibonacci.Fib_dp(7);
            res.Should().Be(13);
        }

        [Test]
        public void Should_Throw_Exception_For_Fib_With_Invalid_Index_dp_method()
        {
            var exception = Assert.Throws<Exception>(() => _fibonacci.Fib_dp(-1));
            exception.Message.Should().Be("Please enter a valid index of fibonacci sequence");
        }
    }
}
