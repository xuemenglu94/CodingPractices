using CodingPractices.Stack;
using FluentAssertions;
using NUnit.Framework;

namespace CodingPracticesTest.Stack
{
    [TestFixture]
    public class CQueueTest
    {
        [Test]
        public void CQueue_Operation()
        {
            var cQueue = new CQueue();
            cQueue.DeleteHead().Should().Be(-1);

            cQueue.AppendTail(3);
            cQueue.AppendTail(4);
            cQueue.AppendTail(5);
            cQueue.DeleteHead().Should().Be(3);

            cQueue.AppendTail(6);
            cQueue.DeleteHead().Should().Be(4);
        }
    }
}
