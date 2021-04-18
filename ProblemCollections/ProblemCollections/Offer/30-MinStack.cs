using System;
using System.Collections.Generic;

namespace ProblemCollections.Offer
{
    public class MinStack
    {
        private Stack<int> Values { get; set; }
        private Stack<int> Mins { get; set; }

        public MinStack()
        {
            Values = new Stack<int>();
            Mins = new Stack<int>();
        }

        public void Push(int x)
        {
            Values.Push(x);
            if (Mins.TryPeek(out var currentMin) && currentMin < x) return;
            Mins.Push(x);
        }

        public void Pop()
        {
            var pop = Values.Pop();
            if (Mins.TryPeek(out var currentMin) && currentMin == pop) Mins.Pop();
        }

        public int Top()
        {
            return Values.TryPeek(out var top) ? top : Int32.MaxValue;
        }

        public int Min()
        {
            return Mins.TryPeek(out var min) ? min : Int32.MaxValue;
        }
    }
}
