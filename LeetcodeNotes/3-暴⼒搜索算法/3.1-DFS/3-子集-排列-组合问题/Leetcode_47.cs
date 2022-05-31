using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._3_暴_搜索算法._3._1_DFS._3_子集_排列_组合问题
{
    /// <summary>
    /// nums = [1,1,2]
    /// [[1,1,2],[1,2,1],[2,1,1]]
    /// </summary>
    internal class Leetcode_47
    {
        IList<IList<int>> res = new List<IList<int>>();
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            Array.Sort(nums);
            Helper(nums, new List<int>(), new bool[nums.Length]);
            return res;
        }
        public void Helper(int[] nums, IList<int> track, bool[] used)
        {
            if (track.Count == nums.Length)
            {
                res.Add(new List<int>(track));
                return;
            }
            else if(track.Count < nums.Length)
                for(int i = 0; i < nums.Length; i++)
                {
                    if (used[i] || (i > 0 && nums[i] == nums[i - 1] && !used[i - 1]))
                        continue;
                    used[i] = true;
                    track.Add(nums[i]);
                    Helper(nums, track, used);
                    used[i] = false;
                    track.RemoveAt(track.Count - 1);
                }
        }
    }
}
