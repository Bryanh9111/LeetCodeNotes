using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._3_暴_搜索算法._3._1_DFS._3_子集_排列_组合问题
{
    /// <summary>
    /// nums = [1,2,3]
    /// [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]
    /// </summary>
    internal class Leetcode_78
    {
        IList<IList<int>> res = new List<IList<int>>();
        public IList<IList<int>> Subsets(int[] nums)
        {
            Helper(nums, 0, new List<int>());
            return res;
        }
        // 回溯算法核心函数，遍历子集问题的回溯树
        public void Helper(int[] nums, int start, IList<int> track)
        {
            // 前序位置，每个节点的值都是一个子集
            res.Add(new List<int>(track));
            // 回溯算法标准框架
            for (int i = start; i < nums.Length; i++)
            {
                //if (i > start && nums[i] == nums[i - 1])
                //    continue;
                // 做选择
                track.Add(nums[i]);
                // 通过 start 参数控制树枝的遍历，避免产生重复的子集
                Helper(nums, i + 1, track);
                // 撤销选择
                track.RemoveAt(track.Count - 1);
            }
        }
    }
}
