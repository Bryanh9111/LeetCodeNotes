using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._4_动态规划._4._1_动态规划核心原理
{
    internal class Leetcode_322
    {
        /// <summary>
        /// 暴力穷举，时间复杂度超过
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int CoinChange(int[] coins, int amount)
        {
            // 题⽬要求的最终结果是 dp(amount)
            return Helper(coins, amount);
        }
        /// <summary>
        /// 所以我们可以这样定义 dp 函数：dp(n) 表示，输⼊⼀个⽬标⾦额 n，返回凑出⽬标⾦额 n 所需的最少硬币
        ///数量
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int Helper(int[] coins, int amount)
        {
            // base case
            if (amount == 0)
                return 0;
            if (amount < 0)
                return -1;

            int res = int.MaxValue;
            foreach(int coin in coins)
            {
                // 计算⼦问题的结果
                int subProblem = Helper(coins, amount - coin);
                // ⼦问题⽆解则跳过
                if (subProblem == -1)
                    continue;

                // 在⼦问题中选择最优解，然后加⼀
                res = Math.Min(res, subProblem + 1);
            }

            return res == int.MaxValue ? -1 : res;
        }
    }


    internal class Leetcode_322_2
    {
        int[] memo;
        /// <summary>
        /// 带备忘录的递归
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int CoinChange(int[] coins, int amount)
        {
            memo = new int[amount + 1];
            for (int i = 0; i < memo.Length; i++)
                memo[i] = -666;

            // 题⽬要求的最终结果是 dp(amount)
            return Helper(coins, amount);
        }
        /// <summary>
        /// 所以我们可以这样定义 dp 函数：dp(n) 表示，输⼊⼀个⽬标⾦额 n，返回凑出⽬标⾦额 n 所需的最少硬币
        ///数量
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int Helper(int[] coins, int amount)
        {
            // base case
            if (amount == 0)
                return 0;
            if (amount < 0)
                return -1;
            // 查备忘录，防⽌重复计算
            if (memo[amount] != -666)
                return memo[amount];

            int res = int.MaxValue;
            foreach (int coin in coins)
            {
                // 计算⼦问题的结果
                int subProblem = Helper(coins, amount - coin);
                // ⼦问题⽆解则跳过
                if (subProblem == -1)
                    continue;

                // 在⼦问题中选择最优解，然后加⼀
                res = Math.Min(res, subProblem + 1);
            }
            // 把计算结果存⼊备忘录
            memo[amount] = res == int.MaxValue ? -1 : res;
            return memo[amount];
        }
    }

    internal class Leetcode_322_3
    {
        /// <summary>
        /// dp 数组的迭代解法
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int CoinChange(int[] coins, int amount)
        {
            // 数组⼤⼩为 amount + 1，初始值也为 amount + 1
            int[] dp = new int[amount + 1];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = amount + 1;

            //base case
            dp[0] = 0;
            // 外层 for 循环在遍历所有状态的所有取值
            for (int i = 0; i < dp.Length; i++)
            {
                // 内层 for 循环在求所有选择的最⼩值
                foreach (int coin in coins)
                {
                    // ⼦问题⽆解，跳过
                    if (i - coin < 0)
                        continue;

                    dp[i] = Math.Min(dp[i], 1 + dp[i - coin]);
                }
            }

            return dp[amount] == amount + 1 ? -1 : dp[amount];
        }
    }
}
