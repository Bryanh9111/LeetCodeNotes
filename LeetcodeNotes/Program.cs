using System;
using LeetcodeNotes.DifferencialArray;

namespace LeetcodeNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch1 = new System.Diagnostics.Stopwatch();
            watch1.Start();
            /////////////////
            Solution cs1 = new Solution();
            int[][] jagged_arr = new int[][]
            {
                new int[] { 1, 3, 2 },
                new int[] { 2, 4, 3 },
                new int[] { 0, 2, -2 }
            };

            var res = cs1.GetModifiedArray(5, jagged_arr);

            /////////////////
            watch1.Stop();
            Console.WriteLine($"Execution Time watch1: {watch1.ElapsedMilliseconds} ms");
        }
    }
}
