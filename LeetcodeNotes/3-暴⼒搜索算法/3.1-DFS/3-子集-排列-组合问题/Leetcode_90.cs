using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._3_暴_搜索算法._3._1_DFS._3_子集_排列_组合问题
{
    /// <summary>
    /// nums = [1,2,2]
    /// [[],[1],[1,2],[1,2,2],[2],[2,2]]
    /// </summary>
    internal class Leetcode_90
    {
        IList<IList<int>> res = new List<IList<int>>();
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            Array.Sort(nums);
            Helper(nums, 0, new List<int>());
            return res;
        }
        public void Helper(int[] nums, int start, IList<int> track)
        {
            res.Add(new List<int>(track));
            for (int i = start; i < nums.Length; i++)
            {
                if (i > start && nums[i] == nums[i - 1])
                    continue;

                track.Add(nums[i]);
                Helper(nums, i + 1, track);
                track.RemoveAt(track.Count - 1);
            }
        }
    }
}
