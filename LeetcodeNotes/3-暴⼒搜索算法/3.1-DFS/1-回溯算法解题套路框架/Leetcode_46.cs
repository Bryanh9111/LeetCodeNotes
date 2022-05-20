using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._3_暴_搜索算法._3._1_DFS._1_回溯算法解题套路框架
{
    class Leetcode_46
    {
        IList<IList<int>> res = new List<IList<int>>();
        public IList<IList<int>> Permute(int[] nums)
        {
            Helper(new List<int>(), nums);
            return res;
        }

        public void Helper(IList<int> track, int[] nums)
        {
            if(track.Count == nums.Length)
            {
                res.Add(new List<int>(track));
                return;
            }

            for(int i = 0; i < nums.Length; i++)
            {
                if (track.Contains(nums[i]))
                    continue;

                track.Add(nums[i]);
                Helper(track, nums);
                track.RemoveAt(track.Count - 1);
            }
        }
    }
}
