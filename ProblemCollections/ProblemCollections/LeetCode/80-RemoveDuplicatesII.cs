namespace ProblemCollections.LeetCode
{
    public partial class Solution
    {
        public int RemoveDuplicatesII(int[] nums)
        {
            if (nums == null) return 0;
            var length = nums.Length;
            if (length <= 2) return length;

            var count = 2;
            for (int i = 2; i < length; i++)
            {
                if (nums[i] != nums[count - 2])
                {
                    nums[count] = nums[i];
                    count++;
                }
            }

            return count;
        }
    }
}
