using System;
using ProblemCollections.Offer;

namespace ProblemCollections.LeetCode
{
    public partial class Solution
    {
        public int RobI_dp(int[] nums)
        { 
            if (nums == null || nums.Length == 0) return 0;
            
            var dp = new int[nums.Length + 1];
            dp[0] = 0;
            dp[1] = nums[0];
            var max = dp[1];
            for (int i = 2; i <= nums.Length; i++)
            {
                dp[i] = Math.Max(dp[i - 2] + nums[i - 1], dp[i-1]);
                if (dp[i] > max) max = dp[i];
            }

            return max;
        }

        public int RobI(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            var prev = 0;
            var cur = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                var value = Math.Max(prev + nums[i], cur);
                prev = cur;
                cur = value;
            }

            return cur;
        }

        public int RobII(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            var withFirst = RobI(nums[new Range(0, nums.Length - 1)]);
            var withLast = RobI(nums[new Range(1, nums.Length)]);
            return Math.Max(withFirst, withLast);
        }

        public int RobIII(TreeNode root)
        {
            int[] result = RobTree(root);
            return Math.Max(result[0], result[1]);
        }

        public int[] RobTree(TreeNode node)
        {
            if (node == null) return new int[2];
            int[] result = new int[2];

            int[] left = RobTree(node.left);
            int[] right = RobTree(node.right);

            result[0] = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]); // DO NOT take current node
            result[1] = left[0] + right[0] + node.val; // Take current node

            return result;
        }
    }
}
