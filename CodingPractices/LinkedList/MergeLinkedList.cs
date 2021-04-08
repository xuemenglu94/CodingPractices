namespace CodingPractices.LinkedList
{
    public class MergeLinkedList
    {
        public NumLinkedNode Merge(NumLinkedNode a1, NumLinkedNode b1)
        {
            NumLinkedNode p1 = a1;
            NumLinkedNode p2 = b1;
            NumLinkedNode res;
            NumLinkedNode resHead;

            if (a1 == null) return b1;
            if (b1 == null) return a1;

            if (p1.Value < p2.Value)
            {
                res = new NumLinkedNode(p1.Value);
                p1 = p1.Next;
            }
            else
            {
                res = new NumLinkedNode(p2.Value);
                p2 = p2.Next;
            }

            resHead = res;

            while (p1 != null || p2 != null)
            {
                if (p1 == null)
                {
                    res.Next = p2;
                    p2 = p2.Next;
                    res = res.Next;
                    continue;
                }

                if (p2 == null)
                {
                    res.Next = p1;
                    p1 = p1.Next;
                    res = res.Next;
                    continue;
                }

                if (p1.Value < p2.Value)
                {
                    res.Next = p1;
                    p1 = p1.Next;
                }
                else
                {
                    res.Next = p2;
                    p2 = p2.Next;
                }
                res = res.Next;
            }

            return resHead;
        }

        public NumLinkedNode Merge_Recurse(NumLinkedNode a1, NumLinkedNode b1)
        {
            NumLinkedNode res;

            if (a1 == null) return b1;
            if (b1 == null) return a1;

            if (a1.Value < b1.Value)
            {
                res = new NumLinkedNode(a1.Value);
                a1 = a1.Next;
            }
            else
            {
                res = new NumLinkedNode(b1.Value);
                b1 = b1.Next;
            }

            res.Next = Merge_Recurse(a1, b1);

            return res;
        }
    }

    public class NumLinkedNode
    {
        public NumLinkedNode(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
        public NumLinkedNode Next { get; set; }
    }
}
