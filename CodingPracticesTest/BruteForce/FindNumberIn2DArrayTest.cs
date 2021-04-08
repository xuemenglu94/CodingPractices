using CodingPractices.BruteForce;
using FluentAssertions;
using NUnit.Framework;

namespace CodingPracticesTest.BruteForce
{
    [TestFixture]
    public class FindNumberIn2DArrayTest
    {
        [Test]
        public void Should_Find_Number_In_2D_Array()
        {
            int[][] matrix = new int [5][];
            matrix[0] = new[] { 1, 4, 7, 11, 15 };
            matrix[1] = new[] {2, 5, 8, 12, 19};
            matrix[2] = new[] {3, 6, 9, 16, 22};
            matrix[3] = new[] {10, 13, 14, 17, 24};
            matrix[4] = new[] {18, 21, 23, 26, 30};

            var find = new FindNumberIn2DArray();
            find.Find(matrix, 5).Should().BeTrue();
        }

        [Test]
        public void Should_Find()
        {
            var matrix = new[,]
                {{1, 4, 7, 11, 15}, {2, 5, 8, 12, 19}, {3, 6, 9, 16, 22}, {10, 13, 14, 17, 24}};
            var find = new FindNumberIn2DArray();
            find.FindNumIn2DArray(matrix, 5).Should().BeTrue();
        }
    }
}
