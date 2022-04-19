using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._1_基础数据结构._1._1_数组and链表.左右双指针_滑动窗口
{
    /// <summary>
    /// 没做对
    /// </summary>
    class Leetcode_727
    {
        public string MinWindow(string s1, string s2)
        {
            IDictionary<char, int> need, window;
            need = new Dictionary<char, int>();
            window = new Dictionary<char, int>();

            for (int i = 0; i < s2.Length; i++)
            {
                if (need.ContainsKey(s2[i]))
                    need[s2[i]]++;
                else
                    need.Add(s2[i], 1);
            }

            int left = s1.IndexOf(s2[0]);
            int right = left;
            int valid = 0;
            string res = string.Empty;
            StringBuilder sb = new StringBuilder();

            while (right < s1.Length)
            {
                char c = s1[right++];
                if (need.ContainsKey(c))
                {
                    if (window.ContainsKey(c))
                        window[c]++;
                    else
                        window.Add(c, 1);

                    if(window[c] <= need[c])
                        sb.Append(c);

                    if (window[c] == need[c])
                        valid++;
                }

                while (valid == need.Count)
                {
                    if(string.Equals(sb.ToString(), s2))
                    {
                        if ((right - left < res.Length && !string.IsNullOrEmpty(res)) || string.IsNullOrEmpty(res))
                            res = s1.Substring(left, right - left);
                    }
                    else
                    {
                        right--;
                        left = right;
                        valid = 0;
                        sb = new StringBuilder();
                        window = new Dictionary<char, int>();
                        break;
                    }

                    char d = s1[left++];
                    if (need.ContainsKey(d))
                    {
                        if (window[d] == need[d])
                        {
                            valid--;
                            sb.Remove(0, 1);
                        }  
                        window[d]--;
                    }
                }
            }
            return res;
        }
    }
}
