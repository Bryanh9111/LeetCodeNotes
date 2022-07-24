using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNotes._5_其他经典算法._5._3_面试必知必会._2__个_法解决三道区间问题
{
    internal class Leetcode_986
    {
        public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
        {
            int i = 0, j = 0;
            IList<IList<int>> res = new List<IList<int>>();
            while(i < firstList.Length && j < secondList.Length)
            {
                int a1 = firstList[i][0];
                int a2 = firstList[i][1];
                int b1 = secondList[j][0];
                int b2 = secondList[j][1];

                //# 两个区间存在交集
                if (b2 >= a1 && a2 >= b1)
                    res.Add(new List<int>() { Math.Max(a1, b1), Math.Min(a2, b2)});

                if (b2 < a2)
                    j++;
                else
                    i++;
            }
            int[][] arrays = res.Select(a => a.ToArray()).ToArray();
            return arrays;
        }
    }
}
