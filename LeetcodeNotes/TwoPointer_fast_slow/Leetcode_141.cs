using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.TwoPointer
{
    //Definition for singly-linked list.
     public class ListNode {
         public int val;
         public ListNode next;
         public ListNode(int x) {
             val = x;
             next = null;
         }
     }
 
    public partial class Solution
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
