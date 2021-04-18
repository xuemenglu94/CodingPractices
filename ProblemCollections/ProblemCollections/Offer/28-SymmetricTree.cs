namespace ProblemCollections.Offer
{
    public partial class Solution
    {
        public bool IsSymmetric(TreeNode root)
        {
            return IsSymmetric(root, root);
        }

        private bool IsSymmetric(TreeNode a, TreeNode b)
        {
            if (a == null) return b == null;
            if (b == null) return false;

            if (a.val != b.val) return false;

            return IsSymmetric(a.left, b.right) && IsSymmetric(a.right, b.left);
        }
    }
}
