using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._4_动态规划._4._3_背包问题._3_子集背包问题
{
    internal class Leetcode_416
    {
        public bool CanPartition(int[] nums)
        {
            int sum = 0;
            foreach (int num in nums)
                sum += num;

            if (sum % 2 != 0)
                return false;

            sum /= 2;
            int n = nums.Length;
            bool[,] dp = new bool[n + 1, sum + 1];

            for (int i = 0; i <= n; i++)
                dp[i, 0] = true;

            for(int i = 1; i <= n; i++)
            {
                for(int j = 1; j <= sum; j++)
                {
                    if (j - nums[i - 1] >= 0)
                        dp[i, j] = dp[i - 1, j] || dp[i - 1, j - nums[i - 1]];
                    else
                        dp[i, j] = dp[i - 1, j];
                }
            }

            return dp[n, sum];
        }
    }

    internal class Leetcode_416_lessspace
    {
        public bool CanPartition(int[] nums)
        {
            int sum = 0;
            foreach (int num in nums)
                sum += num;

            if (sum % 2 != 0)
                return false;

            sum /= 2;
            int n = nums.Length;
            bool[] dp = new bool[sum + 1];
            dp[0] = true;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"-------------------------------------");
                Console.WriteLine($"i: {i}");
                for (int j = sum; j >= 1; j--) //still not understand
                {
                    Console.WriteLine($"--------------");
                    Console.WriteLine($"j: {j}");
                    if (j - nums[i] >= 0)
                    {
                        Console.WriteLine($"{j} - {nums[i]} = {j - nums[i]}");
                        Console.WriteLine($"dp[j]: dp{j}: {dp[j]}");
                        Console.WriteLine($"dp[j - nums[i]: dp{j - nums[i]}: {dp[j - nums[i]]}");
                        dp[j] = dp[j] || dp[j - nums[i]];
                    }    
                }
            }
            Console.WriteLine($"dp[sum]: dp[{sum}]: {dp[sum]}");
            return dp[sum];
        }
    }
}
