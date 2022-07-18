using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._4_动态规划._4._4_用动态规划玩游戏._5_经典动态规划__楼扔鸡蛋
{
    internal class Leetcode_887
    {
        int[,] memo;
        public int SuperEggDrop(int k, int n)
        {
            memo = new int[k + 1, n + 1];
            for (int i = 0; i <= k; i++)
                for (int j = 0; j <= n; j++)
                    memo[i, j] = -1;
            return dp(k, n);
        }

        public int dp(int k, int n)
        {
            if (k == 1)
                return n;
            if (n == 0)
                return 0;
            if (memo[k, n] != -1)
                return memo[k, n];

            int res = int.MaxValue;

            for(int i = 1; i < n + 1; i++)
            {
                res = Math.Min(res, Math.Max(
                        dp(k, n - i), //broken
                        dp(k - 1, i - 1) //not broken
                    ) + 1 ); //drop once at i floor
            }
            memo[k, n] = res;
            return res;
        }
    }

    internal class Leetcode_887_二分
    {
        private int[,] memo;
        public int superEggDrop(int k, int n)
        {
            memo = new int[k + 1, n + 1];
            return dp(k, n);
        }
        private int dp(int i, int j)
        {
            if (i == 1) return j;
            if (j == 1) return 1;
            if (memo[i,j] != 0) 
                return memo[i,j];

            int result = j;
            int left = 1;
            int right = j + 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                int left_result = dp(i - 1, mid - 1);//递增函数  关于mid的函数， 当mid 增加 楼层增加，尝试次数增加
                int right_result = dp(i, j - mid);//递减函数 
                                                  //取两个函数的较大部分的 最小值 就是上半部分的 最低谷
                                                  //要找两个函数的y值相同， 如果 递增函数 left_result 比 递减函数right_result值小
                                                  //就应该在 当前 递增函数 mid的x坐标的右边找 所以 当前x左边left = mid+1;
                                                  // 如果left_result y坐标 > right_result y坐标 则 应该在左边找 所以 right = mid 
                result = Math.Min(Math.Max(left_result, right_result) + 1, result);
                if (left_result < right_result)
                {
                    left = mid + 1;
                }
                else if (left_result > right_result)
                {
                    right = mid;
                }
                else
                {
                    break;
                }
            }
            memo[i,j] = result;
            return memo[i,j];
        }
    }
}
