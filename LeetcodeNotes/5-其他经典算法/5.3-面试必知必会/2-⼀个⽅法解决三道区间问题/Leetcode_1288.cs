using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._5_其他经典算法._5._3_面试必知必会._2__个_法解决三道区间问题
{
    internal class Leetcode_1288
    {
        public int RemoveCoveredIntervals(int[][] intervals)
        {
            // 按照起点升序排列，起点相同时降序排列
            Array.Sort(intervals, (a, b) => {
                if (a[0] == b[0])
                    return b[1] - a[1];
                return a[0] - b[0];
            });
            // 记录合并区间的起点和终点
            int left = intervals[0][0];
            int right = intervals[0][1];

            int res = 0;

            for (int i = 1; i < intervals.Length; i++)
            {
                int[] interval = intervals[i];
                // 情况⼀，找到覆盖区间
                if (left <= interval[0] && right >= interval[1])
                    res++;
                // 情况⼆，找到相交区间，合并
                if (right >= interval[0] && right <= interval[1])
                    right = interval[1];
                // 情况三，完全不相交，更新起点和终点
                if(right < interval[0])
                {
                    left = interval[0];
                    right = interval[1];
                }
            }

            return intervals.Length - res;
        }
    }
}
