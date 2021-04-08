using System;
using System.Collections.Generic;

namespace CodingPractices.LinkedList
{
    public class LinkedNode<T>
    {

        public LinkedNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public LinkedNode<T> Next { get; set; }
    }

    public class LinkedNodeList<T>
    {
        public LinkedNodeList()
        {
            
        }

        public LinkedNodeList(IList<T> inputs)
        {
            foreach (var input in inputs)
            {
                AddLast(input);
            }
        }

        public LinkedNode<T> Head { get; set; }

        public LinkedNode<T> Last()
        {
            var node = Head;
            while (node?.Next != null)
            {
                node = node.Next;
            }

            return node;
        }

        public void AddLast(T newValue)
        {
            var newNode = new LinkedNode<T>(newValue);

            if (Head == null)
            { 
                Head = newNode;
            }
            else
            {
                Last().Next = newNode;
            }
        }

        public void Reverse()
        {
            var cur = Head;
            LinkedNode<T> prev = null;
            while (cur != null)
            {
                var temp = cur.Next;
                cur.Next = prev;

                prev = cur;
                cur = temp;
            }

            Head = prev;
        }

        public bool IsCircled()
        {
            var p1 = Head;
            var p2 = Head;
            while (p2.Next != null)
            {
                p1 = p1.Next;
                p2 = p2.Next.Next;
                if (p1 == p2) return true;
            }
            return false;
        }

        public void RemoveTargetNode(LinkedNode<T> target)
        {
            if (target.Next != null)
            {
                target.Value = target.Next.Value;
                target.Next = target.Next.Next;
            }
            else
            {
                RemoveLast();
            }
        }

        public void RemoveLast()
        {
            var p1 = Head;
            var p2 = Head.Next;
            while (p2.Next != null)
            {
                p1 = p1.Next;
                p2 = p2.Next;
            }

            p1.Next = null;
        }
    }

    public static class LinkedNodeUtilities
    {
        public static LinkedNode<T> Append<T>(LinkedNode<T> head, T newValue)
        {
            var newNode = new LinkedNode<T>(newValue);

            if (head == null)
            {
                return newNode;
            }

            var node = head;
            while (node.Next != null)
            {
                node = node.Next;
            }

            node.Next = newNode;
            return head;
        }

        public static LinkedNode<T> Reverse<T>(LinkedNode<T> head)
        {
            var cur = head;
            LinkedNode<T> prev = null;
            while (cur != null)
            {
                var temp = cur.Next;
                cur.Next = prev;

                prev = cur;
                cur = temp;
            }

            return prev;
        }

        public static LinkedNode<T> RecursiveReserve<T>(LinkedNode<T> node)
        {
            if (node == null || node.Next == null)
                return node;

            var temp = RecursiveReserve<T>(node.Next);
            node.Next.Next = node;
            node.Next = null;

            return temp;
        }

        public static bool IsCircled<T>(LinkedNode<T> head)
        {
            var p1 = head;
            var p2 = head;

            while (p2.Next != null)
            {
                p1 = p1.Next;
                p2 = p2.Next.Next;
                if (p1 == p2) return true;
            }

            return false;
        }

        public static T MiddleValue<T>(LinkedNode<T> head)
        {
            var p1 = head;
            var p2 = head;
            while (p2.Next != null)
            {
                p1 = p1.Next;
                p2 = p2.Next.Next;
                if (p1 == p2) throw new Exception("Cannot find middle value since linked list is circled");
            }

            return p1.Value;
        }

        public static LinkedNode<T> RemoveTargetNode<T>(LinkedNode<T> head, LinkedNode<T> target)
        {
            if (head == null || target == null) throw new Exception("Invalid target linked list");

            if (target.Next != null)
            {
                target.Value = target.Next.Value;
                target.Next = target.Next.Next;
            }
            else
            {
                var prev = head;
                while (prev.Next != target)
                {
                    prev = prev.Next;
                }

                prev.Next = null;
            }

            return head;
        }

        public static LinkedNode<T> DeleteNode<T>(LinkedNode<T> head, int val)
        {
            if (head.Value.Equals(val)) return head.Next;

            var prev = head;
            while (prev.Next.Value.Equals(val))
            {
                prev = prev.Next;
            }
            prev.Next = prev.Next.Next;
            return head;
        }

        public static LinkedNode<T> DeleteNode2<T>(LinkedNode<T> head, T val)
        {
            var cur = head;
            LinkedNode<T> prev = null;
            while (!cur.Value.Equals(val))
            {
                prev = cur;
                cur = cur.Next;
            }

            if (prev == null)
            {
                head = head.Next;
            }
            else
            {
                prev.Next = cur.Next;
            }

            return head;
        }

        public static T[] ReversePrintWithStack<T>(LinkedNode<T> head)
        {
            if (head == null) return new T[0];

            var valStack = new Stack<T>();
            var node = head;
            var count = 0;
            while (node != null)
            {
                valStack.Push(node.Value);
                node = node.Next;
                count++;
            }

            var res = new T[count];
            for (int i = 0; i < count; i++)
            {
                res[i] = valStack.Pop();
            }

            return res;
        }

        public static T[] ReversePrint<T>(LinkedNode<T> head)
        {
            if (head == null) return new T[0];

            var node = head;
            var count = 0;
            while (node != null)
            {
                node = node.Next;
                count++;
            }

            var res = new T[count];
            node = head;
            for (int i = count - 1; i >= 0; i--)
            {
                res[i] = node.Value;
                node = node.Next;
            }

            return res;
        }

        public static LinkedNode<T> GetKthFromEnd<T>(LinkedNode<T> head, int k)
        {
            if (head == null) return null;
            if (k <= 0) throw new Exception("K should be larger than 0");

            var p1 = head;
            var p2 = head;

            for (int i = 0; i < k; i++)
            {
                if (p2 == null) throw new Exception("Invalid k is larger than linked list length");
                p2 = p2.Next;
            }

            while (p2 != null)
            {
                p1 = p1.Next;
                p2 = p2.Next;
            }

            return p1;
        }

        public static LinkedNode<T> GetIntersectionNode<T>(LinkedNode<T> headA, LinkedNode<T> headB)
        {
            LinkedNode<T> A = headA, B = headB;
            while (A != B)
            {
                A = A != null ? A.Next : headB;
                B = B != null ? B.Next : headA;
            }
            return A;
        }

        public static LinkedNode<T> CommonNodeOfTwoLinkedList<T>(LinkedNode<T> headA, LinkedNode<T> headB)
        {
            var lengthA = GetListLength(headA);
            var lengthB = GetListLength(headB);
            var diff = lengthA - lengthB;
            if (diff < 0)
            {
                var temp = headA;
                headA = headB;
                headB = temp;
                diff = -diff;
            }
            
            while (diff > 0)
            {
                headA = headA.Next;
                diff--;
            }

            while (headA != headB)
            {
                headA = headA.Next;
                headB = headB.Next;
            }

            return headA;
        }

        private static int GetListLength<T>(LinkedNode<T> head)
        {
            int count = 0;
            while (head != null)
            {
                count++;
                head = head.Next;
            }

            return count;
        }
    }
}
