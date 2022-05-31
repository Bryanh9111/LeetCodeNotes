using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._3_暴_搜索算法._3._1_DFS._3_子集_排列_组合问题
{
    internal class Leetcode_39
    {
        /// <summary>
        /// candidates = [2,3,6,7], target = 7
        /// [[2,2,3],[7]]
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        IList<IList<int>> res = new List<IList<int>>();
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);
            Helper(candidates, target, new List<int>(), 0);
            return res;
        }

        public void Helper(int[] candidates, int target, IList<int> track, int start)
        {
            if (Sum(track) == target)
                res.Add(new List<int>(track));

            if(Sum(track) < target)
                for(int i = start; i < candidates.Length; i++)
                {
                    track.Add(candidates[i]);
                    Helper(candidates, target, track, i);
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
