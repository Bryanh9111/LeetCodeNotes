using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.TwoPointer_left_right
{
    public partial class Solution
    {
        public bool CheckInclusion(string s1, string s2)
        {
            IDictionary<char, int> needs = new Dictionary<char, int>();
            IDictionary<char, int> window = new Dictionary<char, int>();

            foreach(var c in s1)
            {
                if (needs.ContainsKey(c))
                    needs[c]++;
                else
                    needs.Add(c, 1);
            }

            int left = 0;
            int right = 0;
            int valid = 0;
            int len = Int32.MaxValue;
            while(right < s2.Length)
            {
                char c = s2[right++];
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
                    len = Math.Min(right - left, len);
                    char d = s2[left++];
                    if (needs.ContainsKey(d))
                    {
                        if (window[d] == needs[d])
                            valid--;
                        window[d]--;
                    }
                }
            }
            return len == s1.Length;
        }

        public bool CheckInclusion2(string s1, string s2)
        {
            IDictionary<char, int> needs = new Dictionary<char, int>();
            IDictionary<char, int> window = new Dictionary<char, int>();

            foreach (var c in s1)
            {
                if (needs.ContainsKey(c))
                    needs[c]++;
                else
                    needs.Add(c, 1);
            }

            int left = 0;
            int right = 0;
            int valid = 0;
            while (right < s2.Length)
            {
                char c = s2[right++];
                if (needs.ContainsKey(c))
                {
                    if (window.ContainsKey(c))
                        window[c]++;
                    else
                        window.Add(c, 1);

                    if (window[c] == needs[c])
                        valid++;
                }

                while (right - left >= s1.Length)
                {
                    if (valid == needs.Count)
                        return true;
                    char d = s2[left++];
                    if (needs.ContainsKey(d))
                    {
                        if (window[d] == needs[d])
                            valid--;
                        window[d]--;
                    }
                }
            }
            return false;
        }
    }
}
