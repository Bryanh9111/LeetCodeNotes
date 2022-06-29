using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._4_动态规划._4._2_经典动态规划
{
    internal class Leetcode_583
    {
        public int MinDistance(string word1, string word2)
        {
            int m = word1.Length;
            int n = word2.Length;
            // 定义：s1[0..i-1] 和 s2[0..j-1] 的 lcs 长度为 dp[i][j]
            // 目标：s1[0..m-1] 和 s2[0..n-1] 的 lcs 长度，即 dp[m][n]
            // base case: dp[0][..] = dp[..][0] = 0
            int[,] dp = new int[m + 1, n + 1];

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    // 现在 i 和 j 从 1 开始，所以要减一
                    if (word1[i - 1] == word2[j - 1])
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                    else
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
            return (m - dp[m, n]) + (n - dp[m, n]);
        }
    }
    internal class Leetcode_583_backtracking
    {
        int[,] memo;
        public int MinDistance(string word1, string word2)
        {
            int m = word1.Length;
            int n = word2.Length;
            memo = new int[m, n];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    memo[i, j] = -1;

            int common = dp(word1, 0, word2, 0);
            return (m - common) + (n - common);
        }

        public int dp(string word1, int i, string word2, int j)
        {
            if (i == word1.Length || j == word2.Length)
                return 0;

            if (memo[i, j] != -1)
                return memo[i, j];

            if (word1[i] == word2[j])
                memo[i, j] = 1 + dp(word1, i + 1, word2, j + 1);
            else
            {
                memo[i, j] = Math.Max(
                        dp(word1, i + 1, word2, j), 
                        dp(word1, i, word2, j + 1)
                    );
            }
            return memo[i, j];
        }
    }
}
