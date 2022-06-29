using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._4_动态规划._4._2_经典动态规划
{
    internal class Leetcode_300
    {
        public int LengthOfLIS(int[] nums)
        {
            // 定义：dp[i] 表示以 nums[i] 这个数结尾的最⻓递增⼦序列的⻓度
            int[] dp = new int[nums.Length];
            // base case：dp 数组全都初始化为 1
            for (int i = 0; i < dp.Length; i++)
                dp[i] = 1;

            for(int i = 0; i < nums.Length; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }

            int res = 0;
            for(int i = 0; i < dp.Length; i++)
            {
                res = Math.Max(res, dp[i]);
            }
            return res;
        }
    }

    internal class Leetcode_300_BinarySearch
    {
        public int LengthOfLIS(int[] nums)
        {
            int[] top = new int[nums.Length];
            // 牌堆数初始化为 0
            int piles = 0;

            for(int i = 0; i < nums.Length; i++)
            {
                // 要处理的扑克牌
                int poker = nums[i];
                /***** 搜索左侧边界的⼆分查找 *****/
                int left = 0, right = piles;
                while(left < right)
                {
                    int mid = left + (right - left) / 2;
                    if (top[mid] > poker)
                        right = mid;
                    else if (top[mid] < poker)
                        left = mid + 1;
                    else
                        right = mid;
                }
                /*********************************/
                // 没找到合适的牌堆，新建⼀堆
                if (left == piles)
                    piles++;

                top[left] = poker;
            }
            return piles;
        }
    }
}
