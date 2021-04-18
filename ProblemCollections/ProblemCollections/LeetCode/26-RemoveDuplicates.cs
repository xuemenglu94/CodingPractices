namespace ProblemCollections.LeetCode
{
    public partial class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null) return 0;
            if (nums.Length < 2) return nums.Length;

            var count = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[count - 1])
                {
                    nums[count] = nums[i];
                    count++;
                }
            }

            return count;
        }
    }
}
