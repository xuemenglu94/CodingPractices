namespace ProblemCollections.Offer
{
    public partial class Solution
    {
        public TreeNode MirrorTree(TreeNode root)
        {
            if (root == null) return null;

            var temp = root.right;
            root.right = MirrorTree(root.left);
            root.left = MirrorTree(temp);

            return root;
        }
    }
}
