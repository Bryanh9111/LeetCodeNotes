using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNotes._5_其他经典算法._5._3_面试必知必会._2__个_法解决三道区间问题
{
    internal class Leetcode_56
    {
        public int[][] Merge(int[][] intervals)
        {
            if (intervals.Length == 0)
                return new int[0][];
            //按区间的 start 升序排列
            var intervals_sort = intervals.OrderBy(x => x[0]).ToArray();
            IList<IList<int>> res = new List<IList<int>>();
            res.Add(intervals_sort[0].ToList());
            //res.Add(new List<int>(intervals_sort[0].ToList()));

            for(int i = 1; i < intervals_sort.Length; i++)
            {
                int[] curr = intervals_sort[i];
                //res 中最后一个元素的引用
                IList<int> last = res[res.Count - 1];
                if (curr[0] <= last[1])
                    //找到最大的 end
                    last[1] = Math.Max(last[1], curr[1]);
                else
                {
                    res.Add(curr.ToList());
                    //res.Add(new List<int>(curr.ToList()));
                }
            }
            int[][] arrays = res.Select(a => a.ToArray()).ToArray();
            return arrays;
        }
    }
}
