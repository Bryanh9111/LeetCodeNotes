using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes._5_其他经典算法._5._2_数学算法._4_当_司机学会了贪_算法
{
    internal class Leetcode_134
    {
        /// <summary>
        /// 图像解法
        /// </summary>
        /// <param name="gas"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int n = gas.Length;
            // 相当于图像中的坐标点和最低点
            int sum = 0;
            int minSum = 0;
            int start = 0;
            for(int i = 0; i < n; i++)
            {
                sum += gas[i] - cost[i];
                if(sum < minSum)
                {
                    // 经过第 i 个站点后，使 sum 到达新低
                    // 所以站点 i + 1 就是最低点（起点）
                    start = i + 1;
                    minSum = sum;
                }
            }
            // 总油量⼩于总的消耗，⽆解
            if (sum < 0)
                return -1;
            // 环形数组特性
            return start == n ? 0 : start;
        }
    }
    internal class Leetcode_134_solution2
    {
        /// <summary>
        /// 贪⼼解法
        /// </summary>
        /// <param name="gas"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int n = gas.Length;
            int sum = 0;
            for (int i = 0; i < n; i++)
                sum += gas[i] - cost[i];
            // 总油量⼩于总的消耗，⽆解
            if (sum < 0)
                return -1;
            // 记录油箱中的油量
            int tank = 0;
            // 记录起点
            int start = 0;
            for(int i = 0; i < n; i++)
            {
                tank += gas[i] - cost[i];
                if(tank < 0)
                {
                    // ⽆法从 start 到达 i + 1
                    // 所以站点 i + 1 应该是起点
                    tank = 0;
                    start = i + 1;
                }
            }
            return start == n ? 0 : start;
        }
    }
}
