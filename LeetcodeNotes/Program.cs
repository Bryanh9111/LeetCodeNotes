using System;
using System.Collections.Generic;
using LeetcodeNotes._3_暴_搜索算法._3._1_DFS._4_岛屿题;

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
                new int[] { 0,0,1,0,0,0,0,1,0,0,0,0,0 },
                new int[] { 0,0,0,0,0,0,0,1,1,1,0,0,0 },
                new int[] { 0,1,1,0,1,0,0,0,0,0,0,0,0 },
                new int[] { 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0 },
                new int[] { 0,1,0,0,1,1,0,0,1,1,1,0,0 },
                new int[] { 0,0,0,0,0,0,0,0,0,0,1,0,0 },
                new int[] { 0,0,0,0,0,0,0,1,1,1,0,0,0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 }
            };
            Leetcode_695 cs1 = new Leetcode_695();
            var a = cs1.MaxAreaOfIsland(jagged_arr);


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
