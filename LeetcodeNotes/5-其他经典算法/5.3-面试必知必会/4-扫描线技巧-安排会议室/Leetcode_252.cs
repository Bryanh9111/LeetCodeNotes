using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNotes._5_其他经典算法._5._3_面试必知必会._4_扫描线技巧_安排会议室
{
    internal class Leetcode_252
    {
        public bool CanAttendMeetings(int[][] intervals)
        {
            if (intervals.Length == 0)
                return true;

            int[][] intervals_sort = intervals.OrderBy(x => x[0]).ToArray();
            int minStart = intervals_sort[0][0];
            int maxEnd = intervals_sort[0][1];
            for (int i = 1; i < intervals_sort.Length; i++)
            {
                int start = intervals_sort[i][0];
                int end = intervals_sort[i][1];
                if (start < maxEnd)
                    return false;
                maxEnd = Math.Max(maxEnd, end);
            }
            return true;
        }
    }
}
