using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.PrefixSumArray
{
    /// <summary>
    /// Subarray Sum Equals K
    /// </summary>
    public class Solution
    {
        /// <summary>
        /// TC: O(N^2)
        /// SC: O(N)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SubarraySum_Slow(int[] nums, int k)
        {
            int n = nums.Length;
            int[] preSum = new int[n + 1];
            preSum[0] = 0;
            //create preSum array
            for (int i = 0; i < n; i++)
                preSum[i + 1] = preSum[i] + nums[i];

            //exhaustion
            int res = 0;
            for(int i = 1; i <= n; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    if (preSum[i] - preSum[j] == k)
                        res++;
                }
            }
            return res;
        }
        /// <summary>
        /// TC: O(N)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SubarraySum_Fast(int[] nums, int k)
        {
            int n = nums.Length;
            IDictionary<int, int> dic = new Dictionary<int, int>();
            dic.Add(0, 1);

            int res = 0;
            int sum_i = 0;
            for (int i = 0; i < n; i++)
            {
                sum_i += nums[i];
                if (dic.ContainsKey(sum_i - k))
                    res += dic[sum_i - k];

                if (dic.ContainsKey(sum_i))
                    dic[sum_i]++;
                else
                    dic.Add(sum_i, 1);
            }
            return res;
        }
    }
}
