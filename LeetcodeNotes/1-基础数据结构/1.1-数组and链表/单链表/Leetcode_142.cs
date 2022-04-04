using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.单链表
{
    class Leetcode_142
    {
        public ListNode DetectCycle(ListNode head)
        {
            ListNode fast = head, slow = head;
            while(fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
                if (fast == slow) break;
            }

            if (fast == null || fast.next == null) return null;

            slow = head;
            while(fast != slow)
            {
                fast = fast.next;
                slow = slow.next;
            }
            return slow;
        }
    }
}
