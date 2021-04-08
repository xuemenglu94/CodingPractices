using System.Collections.Generic;

namespace CodingPractices.Stack
{
    public class CQueue
    {

        public CQueue()
        {
            ValueStack = new Stack<int>();
            AssistStack = new Stack<int>();
        }

        private Stack<int> ValueStack { get; set; }
        private Stack<int> AssistStack { get; set; }

        public void AppendTail(int value)
        {
            ValueStack.Push(value);
        }

        public int DeleteHead()
        {
            if (AssistStack.Count == 0)
            {
                while (ValueStack.Count != 0)
                {
                    AssistStack.Push(ValueStack.Pop());
                }
                if (AssistStack.Count == 0) return -1;
            }
            return AssistStack.Pop();
        }
    }
}
