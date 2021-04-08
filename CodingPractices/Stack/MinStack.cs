using System;
using System.Collections.Generic;

namespace CodingPractices.Stack
{
    public class MinStack<T> where T : IComparable
    {
        public MinStack()
        {
            Value = new Stack<T>();
            Min = new Stack<T>();
        }

        private Stack<T> Value { get; }

        private Stack<T> Min { get; }

        public void Push(T input)
        {
            Value.Push(input);
            if (!Min.TryPeek(out var top))
            {
                Min.Push(input);
            }
            else
            {
                if (input.CompareTo(top) <= 0) Min.Push(input);
            }
        }

        public T Pop()
        {
            var res = Value.Pop();
            if (Min.TryPeek(out var top) && res.Equals(top)) Min.Pop();
            return res;
        }

        public T GetMin()
        {
            if (Min.TryPeek(out var top)) return top;
            throw new Exception("Stack is Empty");
        }
    }
}
