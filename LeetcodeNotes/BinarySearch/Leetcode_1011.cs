using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.BinarySearch
{
    public partial class Solution
    {
        //函数返回x运载能力下所需天数（题目问什么，什么就是x）
        public int f(int[] weights, int x)
        {
            int days = 0;
            for(int i = 0; i < weights.Length; i++)
            {
                int cap = x;
                while(i < weights.Length)
                {
                    if (cap >= weights[i])
                        cap -= weights[i];
                    else break;
                    i++;
                }
                days++;
            }
            return days;
        }
        public int ShipWithinDays(int[] weights, int days)
        {
            int left = 0;
            int right = 1;
            foreach(var w in weights)
            {
                left = Math.Max(left, w);
                right += w;
            }
            while(left < right)
            {
                int mid = left + (right - left) / 2;
                if (f(weights, mid) == days)
                    right = mid;
                else if (f(weights, mid) < days)
                    right = mid;
                else if (f(weights, mid) > days)
                    left = mid + 1;
            }
            return left;
        }
    }
}
