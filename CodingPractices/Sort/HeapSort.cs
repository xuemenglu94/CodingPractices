using System;
using System.Collections.Generic;

namespace CodingPractices.Sort
{
    public class HeapSort
    {
        public IList<int> Sort(IList<int> nums)
        {
            var length = nums.Count - 1;
            BuildMaxHeap(nums, length);
            GetHeapTops(nums, length);
            return nums;
        }

        public IList<int> GetLeastNumbers(int[] nums, int k)
        {
            var length = nums.Length - 1;
            BuildMaxHeap(nums, length);
            GetHeapTops(nums, length, k);
            return nums[new Range(0, k)];
        }

        private void GetHeapTops(IList<int> nums, int length)
        {
            for (int i = length; i > 0; i--)
            {
                Swap(nums, 0, i);
                ShiftDown(nums, 0, i-1);
            }
        }

        private void GetHeapTops(int[] arr, int length, int k)
        {
            for (int i = length; i >= length - k; i--)
            {
                Swap(arr, 0, i);
                ShiftDown(arr, 0, i - 1);
            }
        }

        private void BuildMaxHeap(IList<int> nums, int length)
        {
            for (int i = length / 2; i >= 0; i--)
            {
                ShiftDown(nums, i, length);
            }
        }

        private void ShiftDown(IList<int> nums, int i, int length)
        {
            var leftIndex = 2 * i + 1;
            var rightIndex = 2 * i + 2;
            var maxIndex = i;

            if (leftIndex <= length && nums[maxIndex] < nums[leftIndex])
            {
                maxIndex = leftIndex;
            }

            if (rightIndex <= length && nums[maxIndex] < nums[rightIndex])
            {
                maxIndex = rightIndex;
            }

            if (maxIndex != i)
            {
                Swap(nums, i, maxIndex);
                ShiftDown(nums, maxIndex, length);
            }
        }

        private void Swap(IList<int> nums, int a, int b)
        {
            var temp = nums[a];
            nums[a] = nums[b];
            nums[b] = temp;
        }
    }
}
