using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.TwoPointer_left_right
{
    public class Leetcode_438
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            IDictionary<char, int> needs = new Dictionary<char, int>();
            IDictionary<char, int> window = new Dictionary<char, int>();

            foreach(var c in p)
            {
                if (needs.ContainsKey(c))
                    needs[c]++;
                else needs.Add(c, 1);
            }

            int left = 0;
            int right = 0;
            int valid = 0;
            int len = p.Length;
            IList<int> res = new List<int>();

            while(right < s.Length)
            {
                var c = s[right++];
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
                    if (right - left == len)
                        res.Add(left);
                    var d = s[left++];
                    if (needs.ContainsKey(d))
                    {
                        if (window[d] == needs[d])
                            valid--;
                        window[d]--;
                    }
                }
            }
            return res;
        }
    }
}
