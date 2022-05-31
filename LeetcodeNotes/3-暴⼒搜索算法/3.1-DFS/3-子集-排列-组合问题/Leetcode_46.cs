using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._3_暴_搜索算法._3._1_DFS._3_子集_排列_组合问题
{
    /// <summary>
    /// nums = [1,2,3]
    /// [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
    /// </summary>
    internal class Leetcode_46
    {
        IList<IList<int>> res = new List<IList<int>>();
        public IList<IList<int>> Permute(int[] nums)
        {
            Helper(nums, new List<int>());
            return res;
        }
        public void Helper(int[] nums, IList<int> track)
        {
            if (track.Count == nums.Length)
                res.Add(new List<int>(track));

            for(int i = 0; i < nums.Length; i++)
            {
                if (track.Contains(nums[i]))
                    continue;
                track.Add(nums[i]);
                Helper(nums, track);
                track.RemoveAt(track.Count - 1);
            }
        }
    }
}
