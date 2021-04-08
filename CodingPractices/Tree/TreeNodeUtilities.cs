using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractices.Tree
{
    public partial class TreeNodeUtilities
    {
        private IList<int> _values = new List<int>();
        public IList<int> PreOrder(TreeNode root)
        {
            if (root == null) return _values;

            _values.Add(root.Val);
            PreOrder(root.Left);
            PreOrder(root.Right);
            return _values;
        }

        public void PostOrder(TreeNode root)
        {
            if (root == null) return;

            PostOrder(root.Left);
            Console.WriteLine(root.Val);
            PostOrder(root.Right);
        }

        public void InOrder(TreeNode root)
        {
            if (root == null) return;

            InOrder(root.Left);
            InOrder(root.Right);
            Console.WriteLine(root.Val);
        }
    }
}
