using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.DifferencialArray
{
    public partial class Solution
    {
        public bool CarPooling(int[][] trips, int capacity)
        {
            int[] diff = new int[1001];
            foreach(var trip in trips)
            {
                diff[trip[1]] += trip[0];
                if (trip[2] - 1 < 1001 - 1)
                    diff[trip[2] - 1 + 1] -= trip[0];
            }
            int[] res = new int[1001];
            res[0] = diff[0];
            for (int i = 1; i < diff.Length; i++)
                res[i] = res[i - 1] + diff[i];

            foreach(var r in res)
                if (r > capacity)
                    return false;
            return true;
        }
    }
}
