using System;
using System.Collections.Generic;

namespace CodingPractices.Search
{
    public class BinarySearch
    {
        public int TargetIndex(IList<int> nums, int target)
        {
            if (nums == null || nums.Count == 0) throw new Exception("Search region should has at least one number");

            int start = 0;
            int end = nums.Count - 1;

            while (start <= end)
            {
                int middle = (start + end) / 2;

                if (target == nums[middle])
                {
                    return middle;
                }

                if (target > nums[middle])
                {
                    start = middle + 1;
                }

                if (target < nums[middle])
                {
                    end = middle - 1;
                }
            }

            throw new Exception("Target cannot be found in given region");
        }

        public int LeftBound(IList<int> nums, int target)
        {
            int start = 0;
            int end = nums.Count - 1;
            
            while (start <= end)
            {
                int mid = (start + end) / 2;

                if (nums[mid] < target)
                {
                    start = mid + 1;
                }

                if (nums[mid] >= target)
                {
                    end = mid - 1;
                }
            }

            if (end < 0) return -1;
            return end;
        }

        public int RightBound(IList<int> nums, int target)
        {
            int start = 0;
            int end = nums.Count - 1;

            while (start <= end)
            {
                int mid = (start + end) / 2;

                if (nums[mid] <= target)
                {
                    start = mid + 1;
                }

                if (nums[mid] > target)
                {
                    end = mid - 1;
                }
            }

            if (start >= nums.Count) return -1;
            return start;
        }

        public int MinArray(int[] numbers)
        {
            var left = 0;
            var right = numbers.Length - 1;
            while (left < right)
            {
                var mid = left + (right - left) / 2;
                if (numbers[mid] > numbers[right])
                {
                    left = mid + 1;
                }
                else if (numbers[mid] < numbers[right])
                {
                    right = mid;
                }
                else
                {
                    right--;
                }
            }

            return numbers[left];
        }

        public int FindMinValue(int[] nums)
        {
            if (nums == null || nums.Length == 0) return -1;
            var start = 0;
            var end = nums.Length - 1;

            while (start <= end)
            {
                var mid = (start + end) / 2;
                var midValue = nums[mid];
                var startValue = nums[start];
                var endValue = nums[end];

                if (midValue > startValue && midValue < endValue)
                {
                    return nums[start];
                }

                if (midValue > startValue && midValue > endValue)
                {
                    start = mid;
                }
                else if (midValue < startValue && midValue < endValue)
                {
                    end = mid;
                }
                else
                {
                    return Math.Min(startValue, endValue);
                }
            }

            return nums[start];
        }
    }
}
