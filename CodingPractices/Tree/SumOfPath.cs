using System.Collections.Generic;

namespace CodingPractices.Tree
{
    public partial class TreeNodeUtilities
    {
        public bool IsSumOfPath(TreeNode root, int target)
        {
            var res = new List<IList<int>>();
            var path = new LinkedList<int>();
            Paths(root, res, path, target);

            return res.Count != 0;
            //return res when need to print path
        }

        private void Paths(TreeNode node, IList<IList<int>> res, LinkedList<int> path, int target)
        {
            if (node == null)
            {
                return;
            }

            target -= node.Val;
            path.AddLast(node.Val);

            if (node.Left == null && node.Right == null && target == 0)
            {
                res.Add(new List<int>(path));
            }

            Paths(node.Left, res, path, target);
            Paths(node.Right, res, path, target);

            target += node.Val;
            path.RemoveLast();
        }
    }
}
