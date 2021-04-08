using CodingPractices.Sort;
using FluentAssertions;
using NUnit.Framework;

namespace CodingPracticesTest.Sort
{
    [TestFixture]
    public class SortTest
    {
        private BubbleSort _bubbleSort;
        private QuickSort _quickSort;
        private HeapSort _heapSort;
        private MergeSort _mergeSort;

        private int[] _input;
        private readonly int[] _output = { 1, 2, 3, 4, 5, 7, 8, 9 };

        [SetUp]
        public void SetUp()
        {
            _bubbleSort = new BubbleSort();
            _quickSort = new QuickSort();
            _heapSort = new HeapSort();
            _mergeSort = new MergeSort();
        }

        [Test]
        public void Should_Bubble_Sort_Successfully()
        {
            _input = new []{ 8, 3, 2, 5, 4, 7, 9, 1 };
            var res = _bubbleSort.Sort(_input);
            res.Should().BeEquivalentTo(_output);
        }

        [Test]
        public void Should_Quick_Sort_Successfully()
        {
            _input = new []{ 8, 3, 2, 5, 4, 7, 9, 1 };
            var res = _quickSort.Sort(_input);
            res.Should().BeEquivalentTo(_output);
        }

        [Test]
        public void Should_Heap_Sort_Successfully()
        {
            _input = new []{ 8, 3, 2, 5, 4, 7, 9, 1 };
            var res = _heapSort.Sort(_input);
            res.Should().BeEquivalentTo(_output);
        }

        [Test]
        public void Should_Merge_Sort_Successfully()
        {
            _input = new []{ 8, 3, 2, 5, 4, 7, 9, 1 };
            _mergeSort.Sort(_input);
            _input.Should().BeEquivalentTo(_output);
        }
    }
}
