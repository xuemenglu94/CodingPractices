using CodingPractices.Tree;
using FluentAssertions;
using NUnit.Framework;

namespace CodingPracticesTest.Tree
{
    [TestFixture]
    public class IsSubTreeTest
    {
        private TreeNodeUtilities _treeNodeUntilities;

        [SetUp]
        public void SetUp()
        {
            _treeNodeUntilities = new TreeNodeUtilities();
        }

        [Test]
        public void Should_Identify_Is_Sub_Tree()
        {
            var A = new TreeNode
            {
                Val = 3,
                Left = new TreeNode
                {
                    Val = 4,
                    Left = new TreeNode(1),
                    Right = new TreeNode(2)
                },
                Right = new TreeNode(5)
            };
            var B = new TreeNode
            {
                Val = 4,
                Left = new TreeNode(1)
            };

            _treeNodeUntilities.IsSubTree(A, B).Should().BeTrue();
            _treeNodeUntilities.IsSubTree(A, null).Should().BeFalse();
            _treeNodeUntilities.IsSubTree(B, A).Should().BeFalse();
        }
    }
}
