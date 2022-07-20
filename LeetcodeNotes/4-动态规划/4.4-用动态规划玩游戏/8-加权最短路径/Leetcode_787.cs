using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._4_动态规划._4._4_用动态规划玩游戏._8_加权最短路径
{
    internal class Leetcode_787
    {
        IDictionary<int, IList<int[]>> indegree;
        int[,] memo;
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
        {
            indegree = new Dictionary<int, IList<int[]>>();
            foreach (int[] f in flights)
            {
                int from = f[0];
                int to = f[1];
                int price = f[2];

                memo = new int[n, k + 1 + 1];
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < k + 1 + 1; j++)
                        memo[i, j] = -2;

                if (indegree.ContainsKey(to))
                    indegree[to].Add(new int[] { from, price });
                else
                    indegree.Add(to, new List<int[]>() { new int[] { from, price } });
            }
            return dp(dst, k + 1, src, dst);
        }
        // 定义：从 src 出发，k 步之内到达 s 的最短路径权重
        public int dp(int s, int k, int src, int dst)
        {
            // base case
            if (s == src)
                return 0;

            if (k == 0)
                return -1;

            if (memo[s, k] != -2)
                return memo[s, k];

            // 初始化为最⼤值，⽅便等会取最⼩值
            int res = int.MaxValue;
            if (indegree.ContainsKey(s))
            {
                // 当 s 有⼊度节点时，分解为⼦问题
                foreach (int[] v in indegree[s])
                {
                    int from = v[0];
                    int price = v[1];
                    // 从 src 到达相邻的⼊度节点所需的最短路径权重
                    int subProblem = dp(from, k - 1, src, dst);
                    // 跳过⽆解的情况
                    if (subProblem != -1)
                        res = Math.Min(res, subProblem + price);
                }
            }

            // 如果还是初始值，说明此节点不可达
            memo[s, k] =  res == int.MaxValue ? -1 : res;
            return memo[s, k];
        }
    }
}
