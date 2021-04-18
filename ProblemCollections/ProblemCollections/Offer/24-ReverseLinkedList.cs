namespace ProblemCollections.Offer
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    
    public partial class Solution
    {
        public ListNode ReverseList(ListNode head)
        {
            var node = head;
            ListNode prev = null;
            while (node != null)
            {
                var temp = node.next;
                node.next = prev;

                prev = node;
                node = temp;
            }

            return prev;
        }
    }
}
