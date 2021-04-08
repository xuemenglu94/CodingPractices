using CodingPractices.Tree;
using FluentAssertions;
using NUnit.Framework;

namespace CodingPracticesTest.Tree
{
    [TestFixture]
    public class BinaryTreeTest
    {
        private BinaryTree _binaryTree;

        [SetUp]
        public void SetUp()
        {
            _binaryTree = new BinaryTree();
        }

        [Test]
        public void Should_Rebuild_Binary_Tree()
        {
            var preorder = new[] {3, 9, 20, 15, 7};
            var inorder = new[] {9, 3, 15, 20, 7};
            
            var expected = new TreeNode
            {
                Val = 3,
                Left = new TreeNode(9),
                Right = new TreeNode
                {
                    Val = 20,
                    Left = new TreeNode(15),
                    Right = new TreeNode(7)
                }
            };
            _binaryTree.BuildTree(preorder, inorder).Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Should_Find_Next_Inorder_Node()
        {
            var root = new TreeNode
            {
                Val = 3,
                Left = new TreeNode
                {
                    Val = 9,
                    Right = new TreeNode(8)
                },
                Right = new TreeNode
                {
                    Val = 20,
                    Left = new TreeNode(15),
                    Right = new TreeNode(7)
                }
            };
            root.Left.Parent = root;
            root.Left.Right.Parent = root.Left;
            root.Right.Parent = root;
            root.Right.Left.Parent = root.Right;
            root.Right.Right.Parent = root.Right;

            _binaryTree.NextInorderNode(root.Left).Should().BeEquivalentTo(root.Left.Right);
            _binaryTree.NextInorderNode(root).Should().BeEquivalentTo(root.Right.Left);
            _binaryTree.NextInorderNode(root.Right.Left).Should().BeEquivalentTo(root.Right);
            _binaryTree.NextInorderNode(root.Right.Right).Should().BeNull();
            _binaryTree.NextInorderNode(root.Left.Right).Should().BeEquivalentTo(root);
        }
    }
}
