namespace ProblemCollections.Offer
{
    public partial class Solution
    {
        public bool IsSubStructure(TreeNode A, TreeNode B)
        {
            if (A == null || B == null) return false;
            var matchedRoot = IsMatched(A, B);
            var matchedLeft = IsSubStructure(A.left, B);
            var matchedRight = IsSubStructure(A.right, B);
            return matchedRoot || matchedLeft || matchedRight;
        }

        private bool IsMatched(TreeNode a, TreeNode b)
        {
            if (b == null) return true;
            if (a == null) return false;
            if (a.val != b.val) return false;
            return IsMatched(a.left, b.left) && IsMatched(a.right, b.right);
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int x)
        {
            val = x;
        }
    }
}
