using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._4_动态规划._4._2_经典动态规划
{
    internal class Leetcode_712
    {
        public int MinimumDeleteSum(string s1, string s2)
        {
            int m = s1.Length;
            int n = s2.Length;

            int sum1 = 0;
            int sum2 = 0;

            foreach (var c in s1)
                sum1 += c;

            foreach (var c in s2)
                sum2 += c;

            if (m == 0) return sum2;
            if (n == 0) return sum1;
            Console.WriteLine($"sum1 = {sum1}");
            Console.WriteLine($"sum2 = {sum2}");

            int[,] dp = new int[m + 1, n + 1];

            for(int i = 1; i <= m; i++)
            {
                Console.WriteLine("-------------");
                Console.WriteLine($"i = {i} : s1[i - 1] = {s1[i - 1]}");
                for(int j = 1; j <= n; j++)
                {
                    Console.WriteLine($"j = {j} : s2[j - 1] = {s2[j - 1]}");
                    if (s1[i - 1] == s2[j - 1])
                        dp[i, j] = s1[i - 1] + dp[i - 1, j - 1];
                    else
                    {
                        dp[i, j] = Math.Max(
                            dp[i - 1,j],
                            dp[i,j - 1]
                        );
                    }
                    Console.WriteLine($"dp[{i}, {j}] = {dp[i, j]}");
                }
            }

            return sum1 - dp[m, n] + sum2 - dp[m, n];
        }
    }

    internal class Leetcode_712_backtracking
    {
        int[,] memo;
        public int MinimumDeleteSum(string s1, string s2)
        {
            int m = s1.Length;
            int n = s2.Length;

            int sum1 = 0;
            int sum2 = 0;
            if (m == 0) return sum2;
            if (n == 0) return sum1;

            foreach (var c in s1)
                sum1 += c;

            foreach (var c in s2)
                sum2 += c;

            memo = new int[m, n];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    memo[i, j] = -1;

            int dpres = dp(s1, 0, sum1, s2, 0, sum2);
            return sum1 - dpres + sum2 - dpres;
        }

        public int dp(string s1, int i, int sum1, string s2, int j, int sum2)
        {
            if (i == s1.Length || j == s2.Length)
                return 0;

            if (memo[i, j] != -1)
                return memo[i, j];

            if (s1[i] == s2[j])
                memo[i, j] = s1[i] + dp(s1, i + 1,sum1, s2, j + 1, sum2);
            else
            {
                memo[i, j] = Math.Max(
                    dp(s1, i + 1, sum1, s2, j, sum2),
                    dp(s1, i, sum1, s2, j + 1, sum2)
                    );
            }

            return memo[i, j];
        }
    }
}
