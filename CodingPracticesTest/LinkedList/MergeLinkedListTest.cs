using CodingPractices.LinkedList;
using FluentAssertions;
using NUnit.Framework;

namespace CodingPracticesTest.LinkedList
{
    [TestFixture]
    public class MergeLinkedListTest
    {
        private MergeLinkedList _mergeLinkedList;

        [SetUp]
        public void SetUp()
        {
            _mergeLinkedList = new MergeLinkedList();
        }

        [Test]
        public void Should_Correctly_Merge_Linked_List()
        {
            var a1 = new NumLinkedNode(1);
            var a2 = new NumLinkedNode(3);
            var a3 = new NumLinkedNode(5);
            a1.Next = a2;
            a2.Next = a3;

            var b1 = new NumLinkedNode(2);
            var b2 = new NumLinkedNode(4);
            var b3 = new NumLinkedNode(6);
            b1.Next = b2;
            b2.Next = b3;

            var res = _mergeLinkedList.Merge_Recurse(a1, b1);
            res.Value.Should().Be(1);
            res.Next.Value.Should().Be(2);

            //var res2 = _mergeLinkedList.Merge(null, b1);
            //res2.Value.Should().Be(2);
            //res2.Next.Value.Should().Be(4);
        }
    }
}
