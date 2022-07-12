using System;
using System.Collections.Generic;
using LeetcodeNotes._4_动态规划._4._3_背包问题._3_子集背包问题;

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
                new int[] { 2,1,3 },
                new int[] { 6,5,4 },
                new int[] { 7,8,9 }
            };
            Leetcode_416_lessspace cs1 = new Leetcode_416_lessspace();
            var a = cs1.CanPartition(new int[] {1, 2, 5 });

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
