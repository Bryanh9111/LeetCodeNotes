using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.BinarySearch
{
    public class Leetcode_875
    {
        //速度为x时，需要f(x)小时吃完
        public int F(int[] piles, int x)
        {
            int hrs = 0;
            for(int i = 0; i < piles.Length; i++)
            {
                hrs += piles[i] / x;
                if (piles[i] % x > 0)
                    hrs++;
            }
            return hrs;
        }
        public int MinEatingSpeed(int[] piles, int h)
        {
            int left = 1;
            int right = 1000000000 + 1;
            while(left < right)
            {
                int mid = left + (right - left) / 2;
                if (F(piles, mid) == h)
                    right = mid;
                else if (F(piles, mid) < h)
                    right = mid;//f(x)小了要调大，x要调小（mid就是x）
                else if (F(piles, mid) > h)
                    left = mid + 1;//f(x)大了要调小，x要调大（mid就是x）
            }
            return left;
        }
    }
}
