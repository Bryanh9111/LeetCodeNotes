using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.TwoPointer_left_right
{
    public class Leetcode_76
    {
        public string MinWindow(string s, string t)
        {
            IDictionary<char, int> needs = new Dictionary<char, int>();
            IDictionary<char, int> window = new Dictionary<char, int>();

            foreach(var c in t)
            {
                if (needs.ContainsKey(c))
                    needs[c]++;
                else needs.Add(c, 1);
            }

            int left = 0; int right = 0;
            int valid = 0;
            int start = 0;
            int len = Int32.MaxValue;
            while (right < s.Length)
            {
                char c = s[right++];

                if (needs.ContainsKey(c))
                {
                    if (window.ContainsKey(c))
                        window[c]++;
                    else
                        window.Add(c, 1);

                    if (window[c] == needs[c])
                        valid++;
                }

                while(valid == needs.Count)
                {
                    if(right - left < len)
                    {
                        start = left;
                        len = right - left;
                    }

                    char d = s[left++];
                    if (needs.ContainsKey(d))
                    {
                        if (window[d] == needs[d])
                            valid--;
                        window[d]--;
                    }
                }
                
            }

            return len == Int32.MaxValue ? string.Empty : s.Substring(start, len);
        }
    }
}
