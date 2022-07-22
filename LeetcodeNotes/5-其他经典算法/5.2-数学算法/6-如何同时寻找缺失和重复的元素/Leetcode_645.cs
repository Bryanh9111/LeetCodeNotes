using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._5_其他经典算法._5._2_数学算法._6_如何同时寻找缺失和重复的元素
{
    internal class Leetcode_645
    {
        public int[] FindErrorNums(int[] nums)
        {
            int[] res = new int[2];
            IDictionary<int, int> dic = new Dictionary<int, int>();
            for(int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(nums[i]))
                {
                    dic[nums[i]]++;
                    res[0] = nums[i];
                }
                else
                    dic.Add(nums[i], 1);
            }
            for(int i = 1; i <= nums.Length; i++)
            {
                if (!dic.ContainsKey(i))
                    res[1] = i;
            }
            return res;
        }
    }

    internal class Leetcode_645_lessspace
    {
        public int[] FindErrorNums(int[] nums)
        {
            int n = nums.Length;
            int dup = -1;
            for(int i = 0; i < n; i++)
            {
                // 现在的元素是从 1 开始的
                int index = Math.Abs(nums[i]) - 1;
                // nums[index] ⼩于 0 则说明重复访问
                if (nums[index] < 0)
                    dup = Math.Abs(nums[i]);
                else
                    nums[index] *= -1;
            }

            int missing = -1;
            for(int i = 0; i < n; i++)
            {
                // nums[i] ⼤于 0 则说明没有访问
                if (nums[i] > 0)
                    // 将索引转换成元素
                    missing = i + 1;
            }

            return new int[] { dup, missing};
        }
    }
}
