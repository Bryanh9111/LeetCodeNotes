using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._1_基础数据结构._1._1_数组and链表.左右双指针_滑动窗口
{
    class Leetcode_30
    {
        public IList<int> FindSubstring(string s, string[] words)
        {
            if (words.Length == 0) return new List<int> { 0 };
            int wordL = words[0].Length;

            IDictionary<string, int> need = new Dictionary<string, int>();
            IDictionary<string, int> window = new Dictionary<string, int>();

            foreach(var word in words)
            {
                if (need.ContainsKey(word))
                    need[word]++;
                else
                    need.Add(word, 1);
            }

            IList<int> res = new List<int>();
            int loop = wordL - 1;
            while(loop >= 0)
            {
                int left = loop, right = loop;
                int valid = 0;
                int count = 0, countL = 0;
                StringBuilder sb = new StringBuilder();
                StringBuilder sbL = new StringBuilder();
                window = new Dictionary<string, int>();

                while (right < s.Length)
                {
                    count++;
                    sb.Append(s[right++]);
                    if (count == wordL)
                    {
                        string sbs = sb.ToString();
                        if (need.ContainsKey(sbs))
                        {
                            if (window.ContainsKey(sbs))
                                window[sbs]++;
                            else
                                window.Add(sbs, 1);
                            if (window[sbs] == need[sbs])
                                valid++;
                        }
                        count = 0;
                        sb = new StringBuilder();
                    }
                    while (valid == need.Count)
                    {
                        if (right - left == wordL * words.Length)
                            res.Add(left);

                        countL++;
                        sbL.Append(s[left++]);
                        if (countL == wordL)
                        {
                            string sbLs = sbL.ToString();
                            if (need.ContainsKey(sbLs))
                            {
                                if (window[sbLs] == need[sbLs])
                                    valid--;
                                window[sbLs]--;
                            }
                            countL = 0;
                            sbL = new StringBuilder();
                        }
                    }

                }
                loop--;
            }
            
            return res;
        }
    }
}
