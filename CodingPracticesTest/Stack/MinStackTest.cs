using System;
using CodingPractices.Stack;
using FluentAssertions;
using NUnit.Framework;

namespace CodingPracticesTest.Stack
{
    [TestFixture]
    public class MinStackTest
    {

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void Should_Get_Min_In_Stack()
        {
            var res = new MinStack<int>();
            res.Push(3);
            res.GetMin().Should().Be(3);

            res.Push(4);
            res.GetMin().Should().Be(3);

            res.Push(1);
            res.GetMin().Should().Be(1);

            res.Pop();
            res.GetMin().Should().Be(3);
        }

        [Test]
        public void Should_Throw_Exception_When_Stack_Is_Empty()
        {
            var stack = new MinStack<int>();
            var ex = Assert.Throws<Exception>(() => stack.GetMin());
            ex.Message.Should().Be("Stack is Empty");
        }

        [Test]
        public void Should_Operate_Min_Stack_With_String()
        {
            var stack = new MinStack<char>();
            stack.Push('a');
            stack.Push('e');
            stack.GetMin().Should().Be('a');
        }
    }
}
