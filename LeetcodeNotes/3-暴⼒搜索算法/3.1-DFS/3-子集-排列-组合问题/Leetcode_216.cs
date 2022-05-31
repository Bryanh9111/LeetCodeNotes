using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._3_暴_搜索算法._3._1_DFS._3_子集_排列_组合问题
{
    /// <summary>
    /// 
    /// </summary>
    internal class Leetcode_216
    {
        IList<IList<int>> res = new List<IList<int>>();
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            Helper(1, 9, k, n, new List<int>());
            return res;
        }

        public void Helper(int start, int end, int limit, int target, IList<int> track)
        {
            int sum = Sum(track);
            if (track.Count == limit && sum == target)
                res.Add(new List<int>(track));

            if(sum < target && track.Count < limit)
            {
                for(int i = start; i <= end; i++)
                {
                    track.Add(i);
                    Helper(i + 1, end, limit, target, track);
                    track.RemoveAt(track.Count - 1);
                }
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
