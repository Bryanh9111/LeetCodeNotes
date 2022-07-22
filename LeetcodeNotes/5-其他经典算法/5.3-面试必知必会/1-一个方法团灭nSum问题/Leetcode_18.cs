using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._5_其他经典算法._5._3_面试必知必会._1_一个方法团灭nSum问题
{
    internal class Leetcode_18
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            IList<IList<long>> res = new List<IList<long>>();
            IList<IList<int>> res_int = new List<IList<int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                IList<IList<long>> threeSumRes = ThreeSumTarget(nums, i + 1, (long)(target - nums[i]));
                foreach (IList<long> ts in threeSumRes)
                {
                    ts.Add(nums[i]);
                    res.Add(ts);
                }
            }
            //for that over int32 min value test case
            for (int i = 0; i < res.Count; i++)
            {
                IList<int> temp = new List<int>();
                for (int j = 0; j < res[i].Count; j++)
                {
                    temp.Add((int)res[i][j]);
                }
                res_int.Add(temp);
            }
            return res_int;
        }
        public IList<IList<long>> ThreeSumTarget(int[] nums, int start, long target)
        {
            //Array.Sort(nums);
            IList<IList<long>> res = new List<IList<long>>();
            for(int i =  start; i < nums.Length - 1; i++)
            {
                if (i > start && nums[i] == nums[i - 1])
                    continue;

                IList<IList<long>> twoSumRes = TwoSumTarget(nums, i + 1, (long)(target - nums[i]));

                foreach(IList<long> ts in twoSumRes)
                {
                    ts.Add(nums[i]);
                    res.Add(ts);
                }
            }
            return res;
        }
        public IList<IList<long>> TwoSumTarget(int[] nums, int start, long target)
        {
            //Array.Sort(nums);
            int lo = start, hi = nums.Length - 1;
            IList<IList<long>> res = new List<IList<long>>();
            while (lo < hi)
            {
                long left = nums[lo], right = nums[hi];
                long sum = left + right;
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
                    res.Add(new List<long>() { left, right});
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
