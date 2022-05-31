using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._3_暴_搜索算法._3._1_DFS._3_子集_排列_组合问题
{
    /// <summary>
    /// candidates = [10,1,2,7,6,1,5], target = 8
    /// [[1,1,6],[1,2,5],[1,7],[2,6]]
    /// </summary>
    internal class Leetcode_40
    {
        IList<IList<int>> res = new List<IList<int>>();
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);
            Helper(candidates, target, new List<int>(), 0);
            return res;
        }

        public void Helper(int[] candidates, int target, IList<int> track, int start)
        {
            int sum = Sum(track);
            if (sum == target)
                res.Add(new List<int>(track));

            if(sum < target)
                for(int i = start; i < candidates.Length; i++)
                {
                    if (sum + candidates[i] > target)
                        continue;
                    if (i > start && candidates[i] == candidates[i - 1])
                        continue;
                    track.Add(candidates[i]);
                    Helper(candidates, target, track, i + 1);
                    track.RemoveAt(track.Count - 1);
                }
        }

        public int Sum(IList<int> track)
        {
            int sum = 0;
            foreach (int t in track)
                sum += t;
            return sum;
        }
    }
}
