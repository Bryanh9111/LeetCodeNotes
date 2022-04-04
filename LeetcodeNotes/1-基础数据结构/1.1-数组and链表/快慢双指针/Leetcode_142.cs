using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.TwoPointer
{
    public class Leetcode_142
    {
        public ListNode DetectCycle(ListNode head)
        {
            if (head == null || head.next == null)
                return null;

            ListNode fast = head;
            ListNode slow = head;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
                if (fast == slow) break;
            }
            if (fast != slow) return null;

            slow = head;
            while (slow != fast)
            {
                fast = fast.next;
                slow = slow.next;
            }
            return slow;
        }
    }
}
