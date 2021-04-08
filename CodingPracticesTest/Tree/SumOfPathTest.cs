using CodingPractices.Tree;
using FluentAssertions;
using NUnit.Framework;

namespace CodingPracticesTest.Tree
{
    [TestFixture]
    public class SumOfPathTest
    {
        private TreeNodeUtilities _treeNodeUntilities = new TreeNodeUtilities();

        [Test]
        public void Should_Identify_Is_Sum_Of_Path()
        {
            var root = new TreeNode
            {
                Val = 10,
                Left = new TreeNode
                {
                    Val = 6,
                    Left = new TreeNode(4),
                    Right = new TreeNode(8)
                },
                Right = new TreeNode
                {
                    Val = 14,
                    Left = new TreeNode(12),
                    Right = new TreeNode(16)
                }
            };
            _treeNodeUntilities.IsSumOfPath(root, 16).Should().BeFalse();
            _treeNodeUntilities.IsSumOfPath(root, 20).Should().BeTrue();
            _treeNodeUntilities.IsSumOfPath(root, 40).Should().BeTrue();
        }
    }
}
