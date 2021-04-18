namespace ProblemCollections.Offer
{
    public partial class Solution
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            ListNode res;
            if (l1.val < l2.val)
            {
                res = new ListNode(l1.val);
                l1 = l1.next;
            }
            else
            {
                res = new ListNode(l2.val);
                l2 = l2.next;
            }

            res.next = MergeTwoLists(l1, l2);
            return res;
        }
    }
}
