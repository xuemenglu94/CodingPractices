using CodingPractices.BruteForce;
using FluentAssertions;
using NUnit.Framework;

namespace CodingPracticesTest.BruteForce
{
    [TestFixture]
    public class CalculationsTest
    {
        private Calculations _calculations;

        [SetUp]
        public void SetUp()
        {
            _calculations = new Calculations();
        }

        [Test]
        public void Should_Calculate_Power()
        {
            _calculations.MyPow(2.00000, 10).Should().Be(1024.0000);
            //_calculations.MyPow(2.10000, 3).Should().Be(9.26100);
            _calculations.MyPow(2.00000, -2).Should().Be(0.25000);
        }

        [Test]
        public void Should_Print_All_Numbers_With_N_Digits()
        {
            var expected = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            _calculations.PrintNumbers(1).Should().BeEquivalentTo(expected);

            _calculations.PrintNumbers(2).Length.Should().Be(99);
        }

        [Test]
        public void Should_Exchange_Odd_Nums_To_Front()
        {
            var input = new[] {1, 2, 3, 4};
            var expected = new[] {1, 3, 2, 4};
            _calculations.Exchange(input).Should().BeEquivalentTo(expected);
        }
    }
}
