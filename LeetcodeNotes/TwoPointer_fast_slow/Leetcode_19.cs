using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.TwoPointer
{
    public class Leetcode_19
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode fast = head;
            ListNode slow = head;
            while (n-- > 0)
                fast = fast.next;

            if (fast == null)
                return head.next;

            while(fast != null && fast.next != null)
            {
                fast = fast.next;
                slow = slow.next;
            }
            slow.next = slow.next.next;
            return head;
        }
    }
}
