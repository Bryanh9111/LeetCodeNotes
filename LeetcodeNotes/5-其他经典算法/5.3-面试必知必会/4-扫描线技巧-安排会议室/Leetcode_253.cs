using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._5_其他经典算法._5._3_面试必知必会._4_扫描线技巧_安排会议室
{
    internal class Leetcode_253
    {
        public int MinMeetingRooms(int[][] intervals)
        {
            int n = intervals.Length;
            int[] begin = new int[n];
            int[] end = new int[n];
            for(int k = 0; k < n; k++)
            {
                begin[k] = intervals[k][0];
                end[k] = intervals[k][1];
            }
            Array.Sort(begin);
            Array.Sort(end);

            // 扫描过程中的计数器
            int count = 0;
            // 双指针技巧
            int res = count, i = 0, j = 0;
            while(i < n && j < n)
            {
                if (begin[i] < end[j])
                {
                    // 扫描到⼀个红点
                    count++;
                    i++;
                }
                else
                {
                    // 扫描到⼀个绿点
                    count--;
                    j++;
                }
                res = Math.Max(res, count);
            }
            return res;
        }
    }
}
