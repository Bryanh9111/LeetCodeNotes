using System;
using LeetcodeNotes.BinarySearch;

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

            var res = cs1.MinEatingSpeed(new int[] { 3, 6, 7, 11 }, 8);

            /////////////////
            //watch1.Stop();
            //Console.WriteLine($"Execution Time watch1: {watch1.ElapsedMilliseconds} ms");
        }
    }
}
