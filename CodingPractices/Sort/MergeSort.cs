using System.Collections.Generic;

namespace CodingPractices.Sort
{
    public class MergeSort
    {
        public void Sort(IList<int> input)
        {
            Sort(input, 0, input.Count - 1);
        }

        private static void Sort(IList<int> input, int left, int right)
        {
            if (left >= right) return;

            var mid = (left + right) / 2;
            Sort(input, left, mid);
            Sort(input, mid + 1, right);

            Merge(input, left, right, mid);
        }

        private static void Merge(IList<int> input, int left, int right, int mid)
        {
            var i = left;
            var j = mid + 1;
            var temp = new List<int>();

            while (i <= mid && j <= right)
            {
                if (input[i] <= input[j])
                {
                    temp.Add(input[i]);
                    i++;
                }
                else
                {
                    temp.Add(input[j]);
                    j++;
                }
            }

            while (i <= mid)
            {
                temp.Add(input[i]);
                i++;
            }

            while (j <= right)
            {
                temp.Add(input[j]);
                j++;
            }

            for (var index = 0; index < temp.Count; index++)
            {
                input[left + index] = temp[index];
            }
        }
    }
}
