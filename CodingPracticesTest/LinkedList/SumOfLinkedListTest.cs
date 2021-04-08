using System;
using CodingPractices.LinkedList;
using FluentAssertions;
using NUnit.Framework;

namespace CodingPracticesTest.LinkedList
{
    [TestFixture]
    public class SumOfLinkedListTest
    {
        private SumOfLinkedList _sumOfLinkedList;

        [SetUp]
        public void SetUp()
        {
            _sumOfLinkedList = new SumOfLinkedList();
        }

        [Test]
        public void Should_Return_Correct_Sum_Of_Linked_List()
        {
            var node1 = new LinkedNode(9);
            var node2 = new LinkedNode(9);
            var node3 = new LinkedNode(9);
            node1.Next = node2;
            node2.Next = node3;

            var node4 = new LinkedNode(1);

            var res1 = new LinkedNode(0);
            var res2 = new LinkedNode(0);
            var res3 = new LinkedNode(0);
            var res4 = new LinkedNode(1);
            res1.Next = res2;
            res2.Next = res3;
            res3.Next = res4;

            _sumOfLinkedList.Sum(node1, node4).Should().BeEquivalentTo(res1);
            _sumOfLinkedList.Sum(node1, null).Should().BeEquivalentTo(node1);
        }

        [Test]
        public void Should_Throw_Exception_When_Both_Inputs_Are_Invalid()
        {
            var ex = Assert.Throws<Exception>(() => _sumOfLinkedList.Sum(null, null));
            ex.Message.Should().Be("Both input linked lists are empty");
        }
    }
}
