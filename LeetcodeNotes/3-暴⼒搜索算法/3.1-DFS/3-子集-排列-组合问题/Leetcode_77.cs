using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._3_暴_搜索算法._3._1_DFS._3_子集_排列_组合问题
{
    /// <summary>
    /// n = 4, k = 2
    /// [[2,4],[3,4],[2,3],[1,2],[1,3],[1,4]]
    /// </summary>
    internal class Leetcode_77
    {
        IList<IList<int>> res = new List<IList<int>>();
        public IList<IList<int>> Combine(int n, int k)
        {
            Helper(1, n, new List<int>(), k);
            return res;
        }

        public void Helper(int start, int n, IList<int> track, int k)
        {
            if (track.Count == k)
            {
                res.Add(new List<int>(track));
            }

            for (int i = start; i <= n; i++)
            {
                track.Add(i);
                Helper(start + 1, n, track, k);
                track.RemoveAt(track.Count - 1);
            }
        }

    }
}
