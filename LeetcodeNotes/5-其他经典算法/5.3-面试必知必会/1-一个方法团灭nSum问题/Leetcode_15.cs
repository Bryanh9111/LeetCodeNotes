using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._5_其他经典算法._5._3_面试必知必会._1_一个方法团灭nSum问题
{
    internal class Leetcode_15
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            return ThreeSumTarget(nums, 0);
        }

        public IList<IList<int>> ThreeSumTarget(int[] nums, int target)
        {
            Array.Sort(nums);
            IList<IList<int>> res = new List<IList<int>>();

            for(int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                IList<IList<int>> twoSumResults = TwoSumTarget(nums, i + 1, target - nums[i]);
                foreach(IList<int> ts in twoSumResults)
                {
                    ts.Add(nums[i]);
                    res.Add(ts);
                }
            }
            return res;
        }

        public IList<IList<int>> TwoSumTarget(int[] nums, int start, int target)
        {
            Array.Sort(nums);
            int lo = start, hi = nums.Length - 1;

            IList<IList<int>> res = new List<IList<int>>();
            while(lo < hi)
            {
                int sum = nums[lo] + nums[hi];
                int left = nums[lo];
                int right = nums[hi];
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
                    res.Add(new List<int>() { left, right });
                    while (lo < hi && nums[lo] == left)
                        lo++;
                    while (lo < hi && nums[hi] == right)
                        hi--;
                }
            }
            return res;
        }
    }
}
