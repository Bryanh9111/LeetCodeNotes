using System;
using System.Collections.Generic;
using LeetcodeNotes._2_进阶数据结构._2._1_二叉树.二叉树序列化;

namespace LeetcodeNotes
{
    class Program
    {
        //test
        static void Main(string[] args)
        {
            //var watch1 = new System.Diagnostics.Stopwatch();
            //watch1.Start();
            /////////////////
            Leetcode_297_post cs1 = new Leetcode_297_post();
            var a = cs1.deserialize("#,#,#,#,#,#,2,4,5,3,1,");


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
