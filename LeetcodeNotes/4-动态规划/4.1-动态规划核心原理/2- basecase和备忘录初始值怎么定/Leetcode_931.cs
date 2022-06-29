using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._4_动态规划._4._1_动态规划核心原理._2__basecase和备忘录初始值怎么定
{
    /// <summary>
    /// 是暴⼒穷举解法
    /// </summary>
    internal class Leetcode_931
    {
        public int MinFallingPathSum(int[][] matrix)
        {
            int rowLength = matrix.Length;
            int res = int.MaxValue;

            // 终点可能在最后⼀⾏的任意⼀列
            for (int j = 0; j < rowLength; j++)
                res = Math.Min(res, dp(matrix, rowLength - 1, j));

            return res;
        }

        public int dp(int[][] matrix, int i, int j)
        {
            // ⾮法索引检查
            if (i < 0 || j < 0 || i >= matrix.Length || j >= matrix[0].Length)
                return 666;
            // base case
            if (i == 0)
                return matrix[i][j];
            // 状态转移
            return matrix[i][j] + 
                min(dp(matrix, i - 1, j), dp(matrix, i - 1, j - 1), dp(matrix, i - 1, j + 1));
        }

        public int min(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }
    }

    /// <summary>
    /// 是暴⼒穷举解法加备忘录
    /// </summary>
    internal class Leetcode_931_memo
    {
        int[,] memo;
        public int MinFallingPathSum(int[][] matrix)
        {
            int rowLength = matrix.Length;
            int res = int.MaxValue;

            // 备忘录⾥的值初始化为 666666
            memo = new int[rowLength, rowLength];
            for(int i = 0; i < rowLength; i++)
                for(int j = 0; j < rowLength; j++)
                    memo[i, j] = 666666;

            // 终点可能在最后⼀⾏的任意⼀列
            for (int j = 0; j < rowLength; j++)
                res = Math.Min(res, dp(matrix, rowLength - 1, j));

            return res;
        }

        public int dp(int[][] matrix, int i, int j)
        {
            // ⾮法索引检查
            if (i < 0 || j < 0 || i >= matrix.Length || j >= matrix[0].Length)
                return 999999;
            // base case
            if (i == 0)
                return matrix[0][j];

            if (memo[i, j] != 666666)
                return memo[i, j];

            // 状态转移
            memo[i, j] = matrix[i][j] +
                min(dp(matrix, i - 1, j), dp(matrix, i - 1, j - 1), dp(matrix, i - 1, j + 1));

            return memo[i, j];
        }

        public int min(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }
    }
}
