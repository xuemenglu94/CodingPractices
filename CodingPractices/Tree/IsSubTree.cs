using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractices.Tree
{
    public partial class TreeNodeUtilities
    {
        public bool IsSubTree(TreeNode A, TreeNode B)
        {
            if (A == null || B == null) return false;

            var matchedRoot = IsMatched(A, B);
            var matchedLeft = IsSubTree(A.Left, B);
            var matchedRight = IsSubTree(A.Right, B);

            return matchedRoot || matchedLeft || matchedRight;
        }

        private bool IsMatched(TreeNode A, TreeNode B)
        {
            if (B == null) return true;

            if (A == null) return false;

            if (A.Val != B.Val) return false;

            return IsMatched(A.Left, B.Left) && IsMatched(A.Right, B.Right);
        }
    }
}
