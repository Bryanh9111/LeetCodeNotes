using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._5_其他经典算法._5._2_数学算法._2_两道常考阶乘算法
{
    internal class Leetcode_172
    {
        public int TrailingZeroes(int n)
        {
            long res = 0;
            long divisor = 5;
            while(divisor <= n)
            {
                res += (n / divisor);
                divisor *= 5;
            }
            return (int)res; 
        }
    }
    internal class Leetcode_172_easyunderstanding
    {
        public int TrailingZeroes(int n)
        {
            int res = 0;
            for (int d = n; d / 5 > 0; d = d / 5)
                res += d / 5;

            return res;
        }
    }
}
