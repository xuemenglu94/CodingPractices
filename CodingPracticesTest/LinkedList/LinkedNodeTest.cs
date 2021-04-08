using System;
using CodingPractices.LinkedList;
using FluentAssertions;
using NUnit.Framework;

namespace CodingPracticesTest.LinkedList
{
    [TestFixture]
    public class LinkedNodeTest
    {
        [Test]
        public void Should_Append_New_Node()
        {
            var res = new LinkedNodeList<int>();
            res.AddLast(3);
            res.Head.Value.Should().Be(3);
            res.Head.Next.Should().BeNull();

            res.AddLast(5);
            res.Head.Value.Should().Be(3);
            res.Head.Next.Value.Should().Be(5);
        }

        [Test]
        public void Should_AddLast_New_Node()
        {
            var res = LinkedNodeUtilities.Append(null, 3);
            res.Value.Should().Be(3);
            res.Next.Should().BeNull();

            res = LinkedNodeUtilities.Append(res, 5);
            res.Value.Should().Be(3);
            res.Next.Value.Should().Be(5);
        }

        [Test]
        public void Should_Reverse_LinkedNodeHead()
        {
            var original = new LinkedNodeList<int>(new[]{1, 2, 3, 4, 5});
            var reversed = new LinkedNodeList<int>(new[]{5, 4, 3, 2, 1});

            var res = LinkedNodeUtilities.Reverse(original.Head);
            res.Should().BeEquivalentTo(reversed.Head);
        }

        [Test]
        public void Should_RecursiveReverse_LinkedNodeHead()
        {
            var original = new LinkedNodeList<int>(new[] { 1, 2, 3, 4, 5 });
            var reversed = new LinkedNodeList<int>(new[] { 5, 4, 3, 2, 1 });

            var res = LinkedNodeUtilities.RecursiveReserve(original.Head);
            res.Should().BeEquivalentTo(reversed.Head);
        }


        [Test]
        public void Should_Reverse_LinkedNodeList()
        {
            var original = new LinkedNodeList<int>(new[] { 1, 2, 3, 4, 5 });
            var reversed = new LinkedNodeList<int>(new[] { 5, 4, 3, 2, 1 });

            original.Reverse();
            original.Should().BeEquivalentTo(reversed);
        }

        [Test]
        public void Should_Notice_Circled_LinkedNodeHead()
        {
            var headWithoutCycle = new LinkedNodeList<int>(new[]{1, 2, 3, 4, 5}).Head;
            var headWithCycle = new LinkedNode<int>(2);
            var next = new LinkedNode<int>(3);
            headWithCycle.Next = next;
            next.Next = headWithCycle;

            LinkedNodeUtilities.IsCircled(headWithoutCycle).Should().BeFalse();
            LinkedNodeUtilities.IsCircled(headWithCycle).Should().BeTrue();
        }

        [Test]
        public void Should_Notice_Circled_LinkedNodeList()
        {
            var listWithoutCycle = new LinkedNodeList<int>(new[] { 1, 2, 3, 4, 5 });
            listWithoutCycle.IsCircled().Should().BeFalse();

            var listWithCycle = new LinkedNodeList<int>(new[] { 1, 2, 3, 4, 5 });
            listWithCycle.Last().Next = listWithCycle.Head;
            listWithCycle.IsCircled().Should().BeTrue();
            LinkedNodeUtilities.IsCircled(listWithCycle.Head).Should().BeTrue();
        }

        [Test]
        public void Should_Find_Middle_Value()
        {
            var head = new LinkedNodeList<int>(new[] {1, 2, 3, 4, 5}).Head;
            LinkedNodeUtilities.MiddleValue(head).Should().Be(3);
        }

        [Test]
        public void Should_Not_Find_Middle_Value_For_Circled_LinkedList()
        {
            var headWithCycle = new LinkedNode<int>(2);
            var next = new LinkedNode<int>(3);
            headWithCycle.Next = next;
            next.Next = headWithCycle;

            var ex = Assert.Throws<Exception>(() => LinkedNodeUtilities.MiddleValue(headWithCycle));
            ex.Message.Should().Be("Cannot find middle value since linked list is circled");
        }

        [Test]
        public void Should_Remove_Target_Node()
        {
            var original = new LinkedNodeList<int>(new[] { 1, 2, 3, 4, 5 });
            var expected = new LinkedNodeList<int>(new[] { 1, 2, 3, 5 });
            var target = original.Head.Next.Next.Next;
            original.RemoveTargetNode(target);
            original.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Should_Remove_Target_Head()
        {
            var original = new LinkedNodeList<int>(new[] { 1, 2, 3, 4, 5 });
            var expected = new LinkedNodeList<int>(new[] { 2, 3, 4, 5 });
            var target = original.Head;
            original.RemoveTargetNode(target);
            original.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Should_Remove_Target_Tail()
        {
            var original = new LinkedNodeList<int>(new[] { 1, 2, 3, 4, 5 });
            var expected = new LinkedNodeList<int>(new[] { 1, 2, 3, 4 });
            var target = original.Head.Next.Next.Next.Next;
            original.RemoveTargetNode(target);
            original.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Should_Remove_Target_Node_Without_List()
        {
            var original = new LinkedNodeList<int>(new[] { 1, 2, 3, 4, 5 });
            var expected = new LinkedNodeList<int>(new[] { 1, 2, 3, 4 });
            var target = original.Last();
            var res = LinkedNodeUtilities.RemoveTargetNode(original.Head, target);
            res.Should().BeEquivalentTo(expected.Head);
        }

        [Test]
        public void Should_Delete_Node()
        {
            var original = new LinkedNodeList<int>(new[] {-3, 5, -99});
            var expected = new LinkedNodeList<int>(new[] {5, -99});

            LinkedNodeUtilities.DeleteNode(original.Head, -3).Should().BeEquivalentTo(expected.Head);
        }

        [Test]
        public void Should_Reverse_Print()
        {
            var input = new LinkedNodeList<int>(new[] { 1, 2, 3, 4, 5 });
            var expected = new [] {5, 4, 3, 2, 1};

            var withStack = LinkedNodeUtilities.ReversePrintWithStack(input.Head);
            withStack.Should().BeEquivalentTo(expected);

            var noStack = LinkedNodeUtilities.ReversePrintWithStack(input.Head);
            noStack.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Should_Get_Kth_From_Tail()
        {
            var input = new LinkedNodeList<int>(new[] {1, 2, 3, 4, 5});
            var expected = new LinkedNodeList<int>(new[] {4, 5});
            LinkedNodeUtilities.GetKthFromEnd(input.Head, 2).Should().BeEquivalentTo(expected.Head);
            
            LinkedNodeUtilities.GetKthFromEnd(input.Head, 5).Should().BeEquivalentTo(input.Head);
            LinkedNodeUtilities.GetKthFromEnd(input.Head, 1).Should().BeEquivalentTo(input.Last());
        }

        [Test]
        public void Should_Throw_Exception_For_Invalid_Kth_From_Tail()
        {
            var input = new LinkedNodeList<int>(new[] { 1, 2, 3, 4, 5 });

            var ex = Assert.Throws<Exception>(() => LinkedNodeUtilities.GetKthFromEnd(input.Head, 6));
            ex.Message.Should().Be("Invalid k is larger than linked list length");

            var ex2 = Assert.Throws<Exception>(() => LinkedNodeUtilities.GetKthFromEnd(input.Head, 0));
            ex2.Message.Should().Be("K should be larger than 0");

            LinkedNodeUtilities.GetKthFromEnd<int>(null, 0).Should().BeNull();
        }

        [Test]
        public void Should_Get_Common_Node()
        {
            var a = new LinkedNodeList<int>(new[] {1, 2, 3});
            var b = new LinkedNodeList<int>(new[] {4, 5});
            a.Last().Next = b.Head;
            LinkedNodeUtilities.CommonNodeOfTwoLinkedList(a.Head, b.Head).Should().BeEquivalentTo(b.Head);
            LinkedNodeUtilities.GetIntersectionNode(a.Head, b.Head).Should().BeEquivalentTo(b.Head);
        }
    }
}
