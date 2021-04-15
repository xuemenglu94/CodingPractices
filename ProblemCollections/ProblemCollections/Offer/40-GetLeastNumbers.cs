using System;

namespace ProblemCollections.Offer
{
    public class Solution
    {
        public int[] GetLeastNumbers(int[] arr, int k)
        {
            var length = arr.Length;
            if (k == 0 || length == 0) return new int[0];
            return QuickSort(arr, k - 1, 0, length-1);
        }

        private static int[] QuickSort(int[] arr, int k, int start, int end)
        {
            var pivotIndex = Partition(arr, start, end);
            if (pivotIndex == k) return arr[new Range(0, pivotIndex + 1)];
            
            return pivotIndex > k 
                ? QuickSort(arr, k, start, pivotIndex - 1) 
                : QuickSort(arr, k, pivotIndex + 1, end);
        }

        private static int Partition(int[] arr, in int start, in int end)
        {
            var pivot = arr[start];
            var marker = start;
            for (int i = start + 1; i <= end; i++)
            {
                if (arr[i] < pivot)
                {
                    marker++;
                    Swap(arr, i, marker);
                }
            }
            Swap(arr, start, marker);
            return marker;
        }

        public int[] GetLeastNumbers_HeapSort(int[] arr, int k)
        {
            var length = arr.Length;
            BuildMinHeap(arr, length);
            return GetHeapTops(arr, length, k);
        }

        private static void BuildMinHeap(int[] arr, in int length)
        {
            for (int i = length/2; i >= 0; i--)
            {
                ShiftUp(arr, i, length);
            }
        }

        private static void ShiftUp(int[] arr, in int i, in int length)
        {
            var leftIndex = 2 * i + 1;
            var rightIndex = 2 * i + 2;
            var minIndex = i;

            if (leftIndex < length && arr[leftIndex] < arr[minIndex])
            {
                minIndex = leftIndex;
            }

            if (rightIndex < length && arr[rightIndex] < arr[minIndex])
            {
                minIndex = rightIndex;
            }

            if (minIndex != i)
            {
                Swap(arr, minIndex, i);
                ShiftUp(arr, minIndex, length);
            }
        }

        private static int[] GetHeapTops(int[] arr, int length, in int k)
        {
            var res = new int[k];

            for (int i = 0; i < k; i++)
            {
                res[i] = arr[0];
                length--;
                Swap(arr, 0, length);
                BuildMinHeap(arr, length);
            }
            return res;
        }

        private static void Swap(int[] arr, in int a, in int b)
        {
            var temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

    }
}
