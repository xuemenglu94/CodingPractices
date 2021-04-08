using System;

namespace CodingPractices.Tree
{
    public class BinaryTree
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            var preStart = 0;
            var preEnd = preorder.Length - 1;
            var inStart = 0;
            var inEnd = inorder.Length - 1;
            return BuildTree(preorder, preStart, preEnd, inorder, inStart, inEnd);
        }

        private TreeNode BuildTree(int[] preorder, int preStart, int preEnd, int[] inorder, int inStart, int inEnd)
        {
            if (preStart > preEnd || inStart > inEnd) return null;
            var rootVal = preorder[preStart];
            var root = new TreeNode(rootVal);
            var rootIndexInInorder = FindRootIndex(rootVal, inorder, inStart, inEnd);
            var leftLen = rootIndexInInorder - inStart;
            root.Left = BuildTree(preorder, preStart + 1, preStart + leftLen, inorder, inStart, rootIndexInInorder - 1);
            root.Right = BuildTree(preorder, preStart + leftLen + 1, preEnd, inorder, rootIndexInInorder + 1, inEnd);
            return root;
        }

        private int FindRootIndex(int rootVal, int[] inorder, int inStart,int inEnd)
        {
            for (int i = inStart; i <= inEnd; i++)
            {
                if (inorder[i] == rootVal) return i;
            }

            throw new Exception("Cannot locate root index in inorder");
        }

        public TreeNode NextInorderNode(TreeNode target)
        {
            if (target == null) return null;

            if (target.Right != null) return target.LeftLeaveAtRight();

            var node = target;
            while (node.Parent != null)
            {
                if (node.Parent.Left == node) break;
                node = node.Parent;
            }
            return node.Parent;
        }
    }

    public class TreeNode
    {
        public int Val;
        public TreeNode Left;
        public TreeNode Right;
        public TreeNode Parent { get; set; }

        public TreeNode(int x) { Val = x; }

        public TreeNode()
        {
            
        }

        public TreeNode LeftLeaveAtRight()
        {
            var node = Right;
            while (node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }
    }
}
