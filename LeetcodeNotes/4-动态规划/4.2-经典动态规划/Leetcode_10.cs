using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._4_动态规划._4._2_经典动态规划
{
    internal class Leetcode_10
    {
        IDictionary<string, bool> memo = new Dictionary<string, bool>();
        public bool IsMatch(string s, string p)
        {
            return dp(s, 0, p, 0);
        }
        //定义：若dp(s, i, p, j) = true，则表示s[i..] 可以匹配p[j..]；若dp(s, i, p, j) = false，则表示s[i..] 无法匹配p[j..]。
        public bool dp(string s, int i, string p, int j)
        {
            //base case
            if (j == p.Length)
                return i == s.Length;
            if(i == s.Length)
            {
                if ((p.Length - j) % 2 == 1)
                    return false;
                for (; j + 1 < p.Length; j += 2)
                    if (p[j + 1] != '*')
                        return false;
                return true;
            }

            string key = i.ToString() + j.ToString();
            if (memo.ContainsKey(key))
                return memo[key];

            bool res = false;

            if (s[i] == p[j] || p[j] == '.')
            {
                // 匹配
                if (j < p.Length - 1 && p[j + 1] == '*')
                {
                    // 有 * 通配符，可以匹配 0 次或多次
                    res = dp(s, i, p, j + 2) || dp(s, i + 1, p, j);
                }
                else
                {
                    // ⽆ * 通配符，⽼⽼实实匹配 1 次
                    res = dp(s, i + 1, p, j + 1);
                }
            }
            else
            {
                // 不匹配
                if (j < p.Length - 1 && p[j + 1] == '*')
                {
                    // 有 * 通配符，只能匹配 0 次
                    res =  dp(s, i, p, j + 2);
                }
                else // ⽆ * 通配符，匹配⽆法进⾏下去了
                    res =  false;
            }

            memo[key] = res;
            return res;
        }
    }
}
