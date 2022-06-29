using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._4_动态规划._4._1_动态规划核心原理
{
    internal class Leetcode_509
    {
        public int Fib(int n)
        {
            if (n == 0 || n == 1)
                return n;

            int dp_1 = 1;
            int dp_0 = 0;

            for (int i = 2; i <= n; i++)
            {
                int dp_i = dp_1 + dp_0;
                dp_0 = dp_1;
                dp_1 = dp_i;
            }

            return dp_1;
        }
    }
}
