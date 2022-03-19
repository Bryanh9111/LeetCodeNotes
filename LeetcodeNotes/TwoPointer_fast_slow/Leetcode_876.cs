using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.TwoPointer
{
    public partial class Solution
    {
        public ListNode MiddleNode(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;

            while(fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }
    }
}
