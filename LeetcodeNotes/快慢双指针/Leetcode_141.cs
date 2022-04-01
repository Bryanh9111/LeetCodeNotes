using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.TwoPointer
{
    public class Leetcode_141
    {
        public bool HasCycle(ListNode head)
        {
            ListNode fast, slow;
            fast = slow = head;
            while(fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;

                if (fast == slow) return true;
            }
            return false;
        }
    }
}
