using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._5_其他经典算法._5._2_数学算法._2_两道常考阶乘算法
{
    internal class Leetcode_793
    {
        public int PreimageSizeFZF(int k)
        {
            // 左边界和右边界之差 + 1 就是答案
            return (int)(GetRightBount(k) - GetLeftBound(k) + 1);
        }

        public long TrailingZeros(long n)
        {
            long res = 0;
            for (long d = n; d / 5 > 0; d = d / 5)
                res += d / 5;

            return res;
        }
        /* 搜索 trailingZeroes(n) == K 的左侧边界 */
        public long GetLeftBound(int target)
        {
            long lo = 0, hi = long.MaxValue;
            while(lo < hi)
            {
                long mid = lo + (hi - lo) / 2;
                if (TrailingZeros(mid) < target)
                    lo = mid + 1;
                else if (TrailingZeros(mid) > target)
                    hi = mid;
                else
                    hi = mid;
            }
            return lo;
        }
        /* 搜索 trailingZeroes(n) == K 的右侧边界 */
        public long GetRightBount(int target)
        {
            long lo = 0, hi = long.MaxValue;
            while(lo < hi)
            {
                long mid = lo + (hi - lo) / 2;
                if (TrailingZeros(mid) < target)
                    lo = mid + 1;
                else if (TrailingZeros(mid) > target)
                    hi = mid;
                else
                    lo = mid + 1;
            }
            return lo - 1;
        }
    }
}
