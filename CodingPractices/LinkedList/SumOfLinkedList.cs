using System;

namespace CodingPractices.LinkedList
{
    public class SumOfLinkedList
    {
        public LinkedNode Sum(LinkedNode head1, LinkedNode head2)
        {
            if (head1 == null && head2 == null) throw new Exception("Both input linked lists are empty");
            if (head1 == null || head2 == null) return head1 ?? head2;

            var preDigit = 0;
            LinkedNode res = null;
            LinkedNode head = null;
            while (head1 != null || head2 != null || preDigit != 0)
            {
                var list1Val = head1?.Value ?? 0;
                var list2Val = head2?.Value ?? 0;
                var sum = list1Val + list2Val + preDigit;
                var digitRes = sum % 10;
                preDigit = sum / 10;

                if (res == null)
                {
                    res = new LinkedNode(digitRes);
                    head = res;
                }
                else
                {
                    res.Next = new LinkedNode(digitRes);
                    res = res.Next;
                }

                head1 = head1?.Next;
                head2 = head2?.Next;
            }

            return head;
        }
    }

    public class LinkedNode
    {
        public LinkedNode(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
        public LinkedNode Next { get; set; }
    }
}
