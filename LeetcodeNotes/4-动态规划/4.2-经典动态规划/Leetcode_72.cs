using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._4_动态规划._4._2_经典动态规划
{
    internal class Leetcode_72
    {
        int[,] memo;
        public int MinDistance(string word1, string word2)
        {
            memo = new int[word1.Length, word2.Length];
            for (int i = 0; i < word1.Length; i++)
                for (int j = 0; j < word2.Length; j++)
                    memo[i, j] = -1;
            return dp(word1, word1.Length - 1, word2, word2.Length - 1);
        }
        //定义：# dp(i, j)返回 s1[0..i] 和 s2[0..j] 的最⼩编辑距离
        public int dp(string s1, int i, string s2, int j)
        {
            if (i == -1) return j + 1;
            if (j == -1) return i + 1;

            if (memo[i, j] != -1)
                return memo[i, j];

            if (s1[i] == s2[j])
            {
                //解释：
                //本来就相等，不需要任何操作
                //s1[0..i] 和 s2[0..j] 的最⼩编辑距离等于
                //s1[0..i-1] 和 s2[0..j-1] 的最⼩编辑距离
                //也就是说 dp(i, j) 等于 dp(i-1, j-1)
                memo[i,j] = dp(s1, i - 1, s2, j - 1);
            }
            else
            {
                memo[i, j] = Helper_Min(
                    dp(s1, i, s2, j - 1) + 1,    //insert
                    dp(s1, i - 1, s2, j) + 1,    //delete
                    dp(s1, i - 1, s2, j - 1) + 1 //replace
                );
            }
            return memo[i, j];
        }
        public int Helper_Min(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }

        //dp(i, j - 1) + 1, # 插⼊
        //解释：
        //我直接在 s1[i] 插⼊⼀个和 s2[j] ⼀样的字符
        //那么 s2[j] 就被匹配了，前移 j，继续跟 i 对⽐
        //别忘了操作数加⼀

        //dp(i - 1, j) + 1, # 删除
        //解释：
        //我直接把 s[i] 这个字符删掉
        //前移 i，继续跟 j 对⽐
        //操作数加⼀

        //dp(i - 1, j - 1) + 1 # 替换
        //解释：
        //我直接把 s1[i] 替换成 s2[j]，这样它俩就匹配了
        //同时前移 i，j 继续对⽐
        //操作数加⼀
    }
    internal class Leetcode_72_dp_table
    {
        public int MinDistance(string word1, string word2)
        {
            int m = word1.Length; int n = word2.Length;
            // 定义：s1[0..i] 和 s2[0..j] 的最⼩编辑距离是 dp[i-1][j-1]
            int[,] dp = new int[m + 1, n + 1];
            for (int i = 1; i <= m; i++)
                dp[i, 0] = i;
            for (int j = 1; j <= n; j++)
                dp[0, j] = j;

            for(int i = 1; i <= m; i++)
            {
                for(int j = 1; j <= n; j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1];
                    else
                        dp[i, j] = Helper_Min(dp[i, j - 1], dp[i - 1, j], dp[i - 1, j - 1]) + 1;
                }
            }
            return dp[m, n];
        }
  
        public int Helper_Min(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }
    }
}
