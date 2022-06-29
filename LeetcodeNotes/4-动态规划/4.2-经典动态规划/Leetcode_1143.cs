using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._4_动态规划._4._2_经典动态规划
{
    internal class Leetcode_1143
    {
        // 备忘录，消除重叠子问题
        int[,] memo;
        public int LongestCommonSubsequence(string text1, string text2)
        {
            int m = text1.Length;
            int n = text2.Length;
            memo = new int[m, n];
            // 备忘录值为 -1 代表未曾计算
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    memo[i, j] = -1;

            // 计算 s1[0..] 和 s2[0..] 的 lcs 长度
            return dp(text1, 0, text2, 0);
        }
        // 定义：计算 s1[i..] 和 s2[j..] 的最长公共子序列长度
        public int dp(string s1, int i, string s2, int j)
        {
            // base case
            if (i == s1.Length || j == s2.Length)
                return 0;

            if (memo[i, j] != -1)
                return memo[i, j];

            if (s1[i] == s2[j])
            {
                // s1[i] 和 s2[j] 必然在 lcs 中，
                // 加上 s1[i+1..] 和 s2[j+1..] 中的 lcs 长度，就是答案
                memo[i, j] =  1 + dp(s1, i + 1, s2, j + 1);
            }
            else
            {
                memo[i, j] = Math.Max(
                        dp(s1, i + 1, s2, j), 
                        dp(s1, i, s2, j + 1)
                    );
            }

            return memo[i, j];
        }
    }

    internal class Leetcode_1143_loop
    {

        public int LongestCommonSubsequence(string text1, string text2)
        {
            int m = text1.Length;
            int n = text2.Length;
            int[,] dp = new int[m + 1, n + 1];

            // 定义：s1[0..i-1] 和 s2[0..j-1] 的 lcs 长度为 dp[i][j]
            // 目标：s1[0..m-1] 和 s2[0..n-1] 的 lcs 长度，即 dp[m][n]
            // base case: dp[0][..] = dp[..][0] = 0

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    // 现在 i 和 j 从 1 开始，所以要减一
                    if (text2[j - 1] == text1[i - 1])
                        dp[i, j] = 1 + dp[i - 1, j - 1]; // s1[i-1] 和 s2[j-1] 必然在 lcs 中
                    else
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);// s1[i-1] 和 s2[j-1] 至少有一个不在 lcs 中
                }
            }

            return dp[m, n];
        }
        
    }
}
