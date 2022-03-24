using System;
using LeetcodeNotes.田忌赛马背后的决策算法;

namespace LeetcodeNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            //var watch1 = new System.Diagnostics.Stopwatch();
            //watch1.Start();
            /////////////////
            Solution cs1 = new Solution();
            int[][] jagged_arr = new int[][]
            {
                new int[] { 1, 2, 10 },
                new int[] { 2, 3, 20 },
                new int[] { 2, 5, 25 }
            };

            var res = cs1.AdvantageCount(new int[] { 12, 24, 8, 32 }, new int[] { 13, 25, 32, 11 });

            /////////////////
            //watch1.Stop();
            //Console.WriteLine($"Execution Time watch1: {watch1.ElapsedMilliseconds} ms");
        }
    }
}
