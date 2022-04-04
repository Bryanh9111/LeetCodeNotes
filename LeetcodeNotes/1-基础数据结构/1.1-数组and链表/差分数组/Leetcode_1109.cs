using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.DifferencialArray
{
    public class Leetcode_1109
    {
        public int[] CorpFlightBookings_direct(int[][] bookings, int n)
        {
            int[] diff = new int[n];
            for (int i = 0; i < bookings.Length; i++)
            {
                //create diff array
                diff[bookings[i][0] - 1] += bookings[i][2];
                if (bookings[i][1] - 1 < diff.Length - 1)
                    diff[bookings[i][1]] -= bookings[i][2];
            }

            int[] res = new int[diff.Length];
            res[0] = diff[0];
            for (int i = 1; i < diff.Length; i++)
                res[i] = res[i - 1] + diff[i];
            return res;
        }

        public int[] CorpFlightBookings(int[][] bookings, int n)
        {
            int[] nums = new int[n];
            Difference df = new Difference(nums);

            foreach(var booking in bookings)
            {
                int i = booking[0] - 1;
                int j = booking[1] - 1;
                int val = booking[2];

                df.Increment(i, j, val);
            }
            return df.Result();
        }
    }
}
