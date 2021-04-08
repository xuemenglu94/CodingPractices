using FluentAssertions;
using NUnit.Framework;

namespace CodingPracticesTest.BruteForce
{
    [TestFixture]
    public class PrintMatrixTest
    {
        private PrintMatrix _printMatrix;

        [SetUp]
        public void SetUp()
        {
            _printMatrix = new PrintMatrix();
        }

        [Test]
        public void Should_Correctly_Print_Matrix_Clockwise()
        {
            var matrix = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix[i, j] = i + j;
                }
            }

            var expected = new[] { 0, 1, 2, 3, 4, 3, 2, 1, 2 };
            _printMatrix.Clockwise(matrix).Should().BeEquivalentTo(expected);

            _printMatrix.Clockwise(new[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }).Should()
                .BeEquivalentTo(new[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 });
            _printMatrix.Clockwise(new int[,] { { 1 } }).Should().BeEquivalentTo(new[] { 1 });
            _printMatrix.Clockwise(new int[,] { { 1, 2, 3, 4, 5 } }).Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5 });
        }
    }
}
