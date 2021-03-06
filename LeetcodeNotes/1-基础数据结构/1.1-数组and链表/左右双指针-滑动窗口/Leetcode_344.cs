using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.TwoPointer_left_right
{
    public class Leetcode_344
    {
        public void ReverseString(char[] s)
        {
            int left = 0;
            int right = s.Length - 1;
            while(left < right)
            {
                char temp = s[left];
                s[left++] = s[right];
                s[right--] = temp;
            }
        }
    }
}
