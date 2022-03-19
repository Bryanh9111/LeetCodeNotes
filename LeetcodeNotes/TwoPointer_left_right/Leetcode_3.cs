using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.TwoPointer_left_right
{
    public partial class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            IDictionary<char, int> window = new Dictionary<char, int>();
            int left = 0;
            int right = 0;
            int len = 0;
            while (right < s.Length)
            {
                var c = s[right++];
                if (window.ContainsKey(c))
                    window[c]++;
                else
                    window.Add(c, 1);

                while(window[c] > 1)
                {
                    var d = s[left++];
                    window[d]--;
                }
                len = Math.Max(len, right - left);
            }
            return len;
        }
    }
}
