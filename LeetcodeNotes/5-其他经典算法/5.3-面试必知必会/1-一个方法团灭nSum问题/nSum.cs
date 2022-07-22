using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._5_其他经典算法._5._3_面试必知必会._1_一个方法团灭nSum问题
{
    internal class nSum
    {
        public IList<IList<int>> nSumTarget(int[] nums, int n, int start, int target)
        {
            IList<IList<int>> res = new List<IList<int>>();
            // 至少是 2Sum，且数组大小不应该小于 n
            if (n < 2 || nums.Length < n)
                return res;

            // 2Sum 是 base case
            if(n == 2)
            {
                int lo = start, hi = nums.Length - 1;
                while(lo < hi)
                {
                    int left = nums[lo], right = nums[hi];
                    int sum = left + right;
                    if(sum < target)
                    {
                        while (lo < hi && nums[lo] == left)
                            lo++;
                    }
                    else if(sum > target)
                    {
                        while (lo < hi && nums[hi] == right)
                            hi--;
                    }
                    else
                    {
                        res.Add(new List<int>() { left, right});
                        while (lo < hi && nums[lo] == left)
                            lo++;
                        while (lo < hi && nums[hi] == right)
                            hi--;
                    }
                }
            }
            else
            {
                // n > 2 时，递归计算 (n-1)Sum 的结果
                for(int i = start; i < nums.Length; i++)
                {
                    if (i > start && nums[i] == nums[i - 1])
                        continue;

                    IList<IList<int>> temp = nSumTarget(nums, n - 1, i + 1, target - nums[i]);
                    foreach(IList<int> t in temp)
                    {
                        t.Add(nums[i]);
                        res.Add(t);
                    }
                }
            }
            return res;
        }
    }
}
