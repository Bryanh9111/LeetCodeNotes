using System;
using System.Collections.Generic;
using LeetcodeNotes._5_其他经典算法._5._3_面试必知必会._1_一个方法团灭nSum问题;

namespace LeetcodeNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            //var watch1 = new System.Diagnostics.Stopwatch();
            //watch1.Start();
            /////////////////
            int[][] jagged_arr = new int[][]
            {
                new int[] { -2,-3,3 },
                new int[] { -5,-10,1 },
                new int[] { 10,30,-5 }
            };
            Leetcode_18 cs1 = new Leetcode_18();
            var a = cs1.FourSum(new int[] { 1, 0, -1, 0, -2, 2 }, 0);

            Console.ReadKey();
            //int[][] jagged_arr = new int[][]
            //{
            //    new int[] { 1, 2, 10 },
            //    new int[] { 2, 3, 20 },
            //    new int[] { 2, 5, 25 }
            //};

            //var res = cs1.AdvantageCount(new int[] { 12, 24, 8, 32 }, new int[] { 13, 25, 32, 11 });

            /////////////////
            //watch1.Stop();
            //Console.WriteLine($"Execution Time watch1: {watch1.ElapsedMilliseconds} ms");
        }
    }
}
