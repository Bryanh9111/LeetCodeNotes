using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._5_其他经典算法._5._3_面试必知必会._5_剪视频剪出_个贪_算法
{
    internal class Leetcode_1024
    {
        public int VideoStitching(int[][] clips, int time)
        {
            // 按照起点升序排列，起点相同时降序排列
            Array.Sort(clips, (a, b) => {
                if (a[0] == b[0])
                    return b[1] - a[1];
                return a[0] - b[0];
            });
            //base
            if (clips[0][0] != 0)
                return -1;
            if (time == 0)
                return 0;

            int res = 0;
            int curEnd = 0, nextEnd = 0;
            int i = 0, n = clips.Length;
            while(i < n && clips[i][0] <= curEnd)
            {
                // 在第 res 个视频的区间内贪⼼选择下⼀个视频
                while(i < n && clips[i][0] <= curEnd)
                {
                    nextEnd = Math.Max(nextEnd, clips[i][1]);
                    i++;
                }
                // 找到下⼀个视频，更新 curEnd
                res++;
                curEnd = nextEnd;
                // 已经可以拼出区间 [0, T]
                if (curEnd >= time)
                    return res;
            }
            return -1;
        }
    }
}
