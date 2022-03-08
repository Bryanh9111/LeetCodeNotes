using System;
using LeetcodeNotes.PrefixAndArray;

namespace LeetcodeNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch1 = new System.Diagnostics.Stopwatch();
            watch1.Start();
            /////////////////
            NumArray na = new NumArray(new int[] { -2, 0, 3, -5, 2, -1 });
            na.SumRange(0, 2);
            na.SumRange(2, 5);
            na.SumRange(0, 5);
            /////////////////
            watch1.Stop();
            Console.WriteLine($"Execution Time watch1: {watch1.ElapsedMilliseconds} ms");

            var watch2 = new System.Diagnostics.Stopwatch();
            watch2.Start();
            /////////////////
            NumArray_SLOW nas = new NumArray_SLOW(new int[] { -2, 0, 3, -5, 2, -1 });
            nas.SumRange(0, 2);
            nas.SumRange(2, 5);
            nas.SumRange(0, 5);
            /////////////////
            watch2.Stop();
            Console.WriteLine($"Execution Time watch2: {watch2.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }
    }
}
