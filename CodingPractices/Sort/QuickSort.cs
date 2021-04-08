using System.Collections.Generic;

namespace CodingPractices.Sort
{
    public class QuickSort
    {
        public IList<int> Sort(IList<int> nums)
        {
            return Sort(nums, 0, nums.Count - 1);
        }

        private IList<int> Sort(IList<int> nums, int start, in int end)
        {
            if (start >= end) return nums;

            int pivotIndex = Partition(nums, start, end);
            Sort(nums, start, pivotIndex - 1);
            Sort(nums, pivotIndex + 1, end);
            return nums;
        }

        private int Partition(IList<int> nums, in int start, in int end)
        {
            var pivot = nums[start];
            var mark = start;

            for (int i = mark + 1; i <= end; i++)
            {
                if (nums[i] < pivot)
                {                   
                    mark++;
                    Swap(nums, i, mark);
                }
            }
            Swap(nums, start, mark);
            return mark;
        }

        private void Swap(IList<int> nums, int a, int b)
        {
            var temp = nums[a];
            nums[a] = nums[b];
            nums[b] = temp;
        }
    }
}
